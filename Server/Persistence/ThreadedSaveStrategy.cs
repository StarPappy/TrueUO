using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Server.Guilds;

namespace Server
{
    public class ThreadedSaveStrategy : ISaveStrategy
    {
        private readonly Queue<Item> _DecayQueue = new();
        private bool allFilesSaved = true;
        List<String> expectedFiles = new List<String>();

        public bool Save()
		{
            Thread saveItemsThread = new Thread(SaveItems)
            {
                Name = "Item Save Subset"
            };

            saveItemsThread.Start();

            SaveMobiles();
            SaveGuilds();

            saveItemsThread.Join();
            return allFilesSaved;
        }

		public void ProcessDecay()
		{
			while (_DecayQueue.Count > 0)
			{
				Item item = _DecayQueue.Dequeue();

				if (item.OnDecay())
				{
					item.Delete();
				}
			}
		}

        private void SaveItems()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            Dictionary<Serial, Item> items = World.Items;
            int itemCount = items.Count;
            Console.WriteLine($"Saving {itemCount} items");

            List<List<Item>> chunks = new List<List<Item>>();
            int chunkSize = 500;

            List<Item> currentChunk = new List<Item>();
            int index = 0;

            foreach (var item in items.Values)
            {
                if (index % chunkSize == 0 && currentChunk.Count > 0)
                {
                    chunks.Add(currentChunk);
                    currentChunk = new List<Item>();
                    int currentChuckIndex = chunks.Count - 1;
                    expectedFiles.Add(World.ItemIndexPath.Replace(".idx", $"_{currentChuckIndex.ToString("D" + 8)}.idx"));
                    expectedFiles.Add(World.ItemDataPath.Replace(".bin", $"_{currentChuckIndex.ToString("D" + 8)}.bin"));
                }

                currentChunk.Add(item);
                index++;
            }

            if (currentChunk.Count > 0)
            {
                chunks.Add(currentChunk);
            }

            Console.WriteLine($"Time to split Items: {sw.ElapsedMilliseconds}ms");
            int totalItemCount = 0;

            using (BinaryFileWriter tdb = new BinaryFileWriter(World.ItemTypesPath, false))
            {
                Parallel.ForEach(chunks, (chunk, state, chunkIndex) =>
                {
                    string idxPath = World.ItemIndexPath.Replace(".idx", $"_{chunkIndex.ToString("D" + 8)}.idx");
                    string binPath = World.ItemDataPath.Replace(".bin", $"_{chunkIndex.ToString("D" + 8)}.bin");

                    using (BinaryFileWriter idx = new BinaryFileWriter(idxPath, false))
                    using (BinaryFileWriter bin = new BinaryFileWriter(binPath, true))
                    {
                        int itemsWritten = 0;
                        idx.Write(chunk.Count);
                        foreach (Item item in chunk)
                        {
                            if (item.Decays && item.Parent == null && item.Map != Map.Internal && (item.LastMoved + item.DecayTime) <= DateTime.UtcNow)
                            {
                                _DecayQueue.Enqueue(item);
                            }

                            long start = bin.Position;

                            idx.Write(item.m_TypeRef);
                            idx.Write(item.Serial);
                            idx.Write(start);

                            item.Serialize(bin);

                            idx.Write((int)(bin.Position - start));

                            item.FreeCache();
                            itemsWritten++;
                        }
                        Interlocked.Add(ref totalItemCount, itemsWritten);
                    }
                });
                tdb.Write(World.m_ItemTypes.Count);

                for (int i = 0; i < World.m_ItemTypes.Count; ++i)
                {
                    tdb.Write(World.m_ItemTypes[i].FullName);
                }

                Console.WriteLine("totalItemCount:" + totalItemCount + " original:" + itemCount);

            }
            sw.Stop();
            Console.WriteLine($"Items Save complete: {sw.ElapsedMilliseconds}ms");
            if (totalItemCount != itemCount)
            {
                allFilesSaved = false;
                Console.WriteLine($"Expected to save {itemCount}, but only saved {totalItemCount}. Unthreaded Save will be triggered");
            }
            foreach (var item in expectedFiles)
            {
                if (!File.Exists(item))
                {
                    allFilesSaved = false;
                    Console.WriteLine($"Save is missing file {item}. Unthreaded Save will be triggered");
                }
            }
        }

        private static void SaveMobiles()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Dictionary<Serial, Mobile> mobiles = World.Mobiles;

            BinaryFileWriter idx = new BinaryFileWriter(World.MobileIndexPath, false);
            BinaryFileWriter tdb = new BinaryFileWriter(World.MobileTypesPath, false);
            BinaryFileWriter bin = new BinaryFileWriter(World.MobileDataPath, true);

            idx.Write(mobiles.Count);
            foreach (Mobile m in mobiles.Values)
            {
                long start = bin.Position;

                idx.Write(m.m_TypeRef);
                idx.Write(m.Serial);
                idx.Write(start);

                m.Serialize(bin);

                idx.Write((int)(bin.Position - start));

                m.FreeCache();
            }

            tdb.Write(World.m_MobileTypes.Count);

            for (int i = 0; i < World.m_MobileTypes.Count; ++i)
                tdb.Write(World.m_MobileTypes[i].FullName);

            idx.Close();
            tdb.Close();
            bin.Close();
            sw.Stop();
            Console.WriteLine("mobiles time: " + sw.ElapsedMilliseconds);
        }

        private static void SaveGuilds()
        {
            BinaryFileWriter idx = new BinaryFileWriter(World.GuildIndexPath, false);
            BinaryFileWriter bin = new BinaryFileWriter(World.GuildDataPath, true);

            idx.Write(BaseGuild.List.Count);
            foreach (BaseGuild guild in BaseGuild.List.Values)
            {
                long start = bin.Position;

                idx.Write(0);//guilds have no typeid
                idx.Write(guild.Id);
                idx.Write(start);

                guild.Serialize(bin);

                idx.Write((int)(bin.Position - start));
            }

            idx.Close();
            bin.Close();
        }
    }
}
