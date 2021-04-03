namespace Server.Items
{
    public class BelfryAddon : BaseAddon
    {
        private static readonly int[,] m_AddOnSimpleComponents =
        {
              {1309, -21, -8, 0}, {1194, -16, -1, 0}, {1206, -18, -4, 0}// 1	2	3	
			, {1309, -18, -8, 0}, {1194, -17, -4, 0}, {1309, -19, -8, 0}// 4	5	6	
			, {1194, -18, -7, 0}, {1194, -17, -2, 0}, {1309, -20, -8, 0}// 7	8	9	
			, {1206, -16, -6, 0}, {1206, -18, -6, 0}, {1309, -22, -8, 0}// 10	11	12	
			, {1194, -16, -5, 0}, {1206, -17, -5, 0}, {1206, -17, -1, 0}// 13	14	15	
			, {1206, -16, -2, 0}, {1206, -16, -4, 0}, {1309, -16, -8, 0}// 16	17	18	
			, {1309, -17, -8, 0}, {1309, -23, -8, 0}, {1194, -18, -5, 0}// 19	20	21	
			, {1194, -18, -3, 0}, {1206, -17, -7, 0}, {1194, -16, -7, 0}// 22	23	24	
			, {1206, -17, -3, 0}, {1194, -17, -6, 0}, {1194, -16, -3, 0}// 25	26	27	
			, {1194, -18, -1, 0}, {1206, -18, -2, 0}, {1206, -19, -1, 0}// 28	29	30	
			, {1194, -19, -2, 0}, {1206, -19, -3, 0}, {1194, -19, -4, 0}// 31	32	33	
			, {1206, -19, -5, 0}, {1206, -22, -6, 0}, {1194, -22, -5, 0}// 34	35	36	
			, {1206, -22, -4, 0}, {1194, -22, -3, 0}, {1206, -22, -2, 0}// 37	38	39	
			, {1194, -22, -1, 0}, {1206, -21, -7, 0}, {1194, -21, -6, 0}// 40	41	42	
			, {1206, -21, -5, 0}, {1194, -21, -4, 0}, {1206, -21, -3, 0}// 43	44	45	
			, {1194, -21, -2, 0}, {1206, -21, -1, 0}, {1194, -20, -7, 0}// 46	47	48	
			, {1206, -20, -6, 0}, {1194, -20, -5, 0}, {1206, -20, -4, 0}// 49	50	51	
			, {1194, -20, -3, 0}, {1206, -20, -2, 0}, {1194, -20, -1, 0}// 52	53	54	
			, {1206, -19, -7, 0}, {1194, -19, -6, 0}, {1194, -22, -7, 0}// 55	56	57	
			, {1206, -23, -5, 0}, {1194, -23, -4, 0}, {1206, -23, -3, 0}// 58	59	60	
			, {1194, -23, -2, 0}, {1206, -23, -1, 0}, {1206, -23, -7, 0}// 61	62	63	
			, {1194, -23, -6, 0}, {1194, -17, 0, 0}, {1194, -18, 5, 0}// 64	65	66	
			, {1194, -17, 2, 0}, {1206, -18, 0, 0}, {1206, -18, 2, 0}// 67	68	69	
			, {1206, -18, 6, 0}, {1309, -16, 8, 0}, {1206, -16, 2, 0}// 70	71	72	
			, {1309, -19, 8, 0}, {1206, -19, 1, 0}, {1309, -21, 8, 0}// 73	74	75	
			, {1206, -17, 7, 0}, {1206, -18, 4, 0}, {1194, -18, 1, 0}// 76	77	78	
			, {1309, -20, 8, 0}, {1194, -18, 7, 0}, {1206, -16, 0, 0}// 79	80	81	
			, {1309, -22, 8, 0}, {1194, -16, 3, 0}, {1206, -16, 4, 0}// 82	83	84	
			, {1194, -19, 2, 0}, {1194, -16, 1, 0}, {1206, -19, 3, 0}// 85	86	87	
			, {1194, -19, 0, 0}, {1194, -17, 4, 0}, {1309, -17, 8, 0}// 88	89	90	
			, {1309, -18, 8, 0}, {1194, -16, 7, 0}, {1194, -19, 6, 0}// 91	92	93	
			, {1194, -19, 4, 0}, {1206, -19, 5, 0}, {1206, -17, 1, 0}// 94	95	96	
			, {1206, -17, 3, 0}, {1194, -17, 6, 0}, {1194, -18, 3, 0}// 97	98	99	
			, {1194, -16, 5, 0}, {1206, -19, 7, 0}, {1206, -16, 6, 0}// 100	101	102	
			, {1206, -17, 5, 0}, {1309, -23, 8, 0}, {1206, -22, 0, 0}// 103	104	105	
			, {1194, -22, 1, 0}, {1206, -22, 2, 0}, {1194, -22, 3, 0}// 106	107	108	
			, {1206, -22, 4, 0}, {1194, -22, 5, 0}, {1206, -22, 6, 0}// 109	110	111	
			, {1194, -22, 7, 0}, {1194, -21, 0, 0}, {1206, -21, 1, 0}// 112	113	114	
			, {1194, -21, 2, 0}, {1206, -21, 3, 0}, {1194, -21, 4, 0}// 115	116	117	
			, {1206, -21, 5, 0}, {1194, -21, 6, 0}, {1206, -21, 7, 0}// 118	119	120	
			, {1206, -20, 0, 0}, {1194, -20, 1, 0}, {1206, -20, 2, 0}// 121	122	123	
			, {1194, -20, 3, 0}, {1206, -20, 4, 0}, {1194, -20, 5, 0}// 124	125	126	
			, {1206, -20, 6, 0}, {1194, -20, 7, 0}, {1206, -23, 5, 0}// 127	128	129	
			, {1194, -23, 6, 0}, {1206, -23, 7, 0}, {1206, -23, 1, 0}// 130	131	132	
			, {1194, -23, 2, 0}, {1206, -23, 3, 0}, {1194, -23, 4, 0}// 133	134	135	
			, {1194, -23, 0, 0}, {1206, -5, -7, 0}, {1309, -8, -8, 0}// 136	137	138	
			, {1206, -15, -7, 0}, {132, -5, -5, 0}, {1194, -4, -1, 0}// 139	140	141	
			, {132, -1, -5, 0}, {1206, -4, -4, 0}, {1194, -2, -7, 0}// 142	143	144	
			, {1194, -5, -2, 0}, {1206, -15, -1, 0}, {1206, -5, -3, 0}// 145	146	147	
			, {1194, -1, -6, 0}, {1194, 0, -7, 0}, {1194, -6, -1, 0}// 148	149	150	
			, {6019, -4, -1, 22}, {1309, -7, -8, 0}, {1309, -13, -8, 0}// 151	152	153	
			, {1206, -4, -6, 0}, {1194, 0, -1, 0}, {1194, -1, -4, 0}// 154	155	156	
			, {132, -6, -7, 0}, {1206, -1, -7, 0}, {1206, -1, -5, 0}// 157	158	159	
			, {1206, -15, -3, 0}, {1206, -6, -6, 0}, {1194, -6, -7, 0}// 160	161	162	
			, {1194, -8, -1, 0}, {1206, -15, -5, 0}, {132, -2, -2, 0}// 163	164	165	
			, {132, -5, -1, 0}, {1194, 0, -5, 0}, {6018, 0, -6, 22}// 166	167	168	
			, {1206, -1, -1, 0}, {1309, -1, -8, 0}, {1309, -14, -8, 0}// 169	170	171	
			, {132, -4, -5, 0}, {6024, -3, -4, 22}, {1194, -7, -4, 0}// 172	173	174	
			, {1206, -3, -3, 0}, {1194, -1, -2, 0}, {1206, 0, -2, 0}// 175	176	177	
			, {1309, -12, -8, 0}, {1194, -5, -6, 0}, {1194, -2, -5, 0}// 178	179	180	
			, {1206, -1, -3, 0}, {1194, -2, -3, 0}, {1194, -4, -5, 0}// 181	182	183	
			, {1309, 0, -8, 0}, {1194, -2, -1, 0}, {6024, -4, -2, 22}// 184	185	186	
			, {1194, -3, -2, 0}, {1194, -15, -6, 0}, {1206, -7, -5, 0}// 187	188	189	
			, {1194, -5, -4, 0}, {1206, -3, -1, 0}, {1309, -6, -8, 0}// 190	191	192	
			, {1206, -5, -5, 0}, {1194, -14, -1, 0}, {1206, -3, -5, 0}// 193	194	195	
			, {6025, -3, -4, 22}, {1206, -3, -7, 0}, {132, -5, -6, 0}// 196	197	198	
			, {1206, -7, -1, 0}, {1206, -6, -4, 0}, {1309, -3, -8, 0}// 199	200	201	
			, {1206, -4, -2, 0}, {1309, -10, -8, 0}, {1309, -11, -8, 0}// 202	203	204	
			, {1309, -5, -8, 0}, {1194, -14, -5, 0}, {1194, -4, -3, 0}// 205	206	207	
			, {1206, 0, -6, 0}, {1206, 0, -4, 0}, {1194, -3, -4, 0}// 208	209	210	
			, {1309, -9, -8, 0}, {1309, -15, -8, 0}, {1194, -14, -7, 0}// 211	212	213	
			, {1194, -15, -4, 0}, {1194, -6, -5, 0}, {132, -2, -5, 0}// 214	215	216	
			, {1194, 0, -3, 0}, {132, -5, -7, 0}, {1194, -7, -6, 0}// 217	218	219	
			, {132, -4, -6, 0}, {6025, -4, -3, 22}, {1309, -4, -8, 0}// 220	221	222	
			, {1309, -2, -8, 0}, {1194, -15, -2, 0}, {1206, -2, -4, 0}// 223	224	225	
			, {1206, -7, -3, 0}, {1206, -2, -2, 0}, {1206, -6, -2, 0}// 226	227	228	
			, {1194, -4, -7, 0}, {1194, -3, -6, 0}, {1206, -2, -6, 0}// 229	230	231	
			, {1206, -7, -7, 0}, {1206, -5, -1, 0}, {1194, -6, -3, 0}// 232	233	234	
			, {1206, -14, -6, 0}, {1206, -14, -4, 0}, {1206, -14, -2, 0}// 235	236	237	
			, {1194, -14, -3, 0}, {1194, -7, -2, 0}, {132, -4, -4, 0}// 238	239	240	
			, {6025, -2, -5, 22}, {1206, -8, -2, 0}, {1206, -11, -5, 0}// 241	242	243	
			, {1194, -11, -4, 0}, {1206, -11, -3, 0}, {1194, -11, -2, 0}// 244	245	246	
			, {1206, -11, -1, 0}, {1194, -10, -7, 0}, {1206, -10, -6, 0}// 247	248	249	
			, {1194, -10, -5, 0}, {1206, -10, -4, 0}, {1194, -10, -3, 0}// 250	251	252	
			, {1206, -10, -2, 0}, {1194, -10, -1, 0}, {1206, -9, -7, 0}// 253	254	255	
			, {1194, -9, -6, 0}, {1206, -9, -5, 0}, {1194, -9, -4, 0}// 256	257	258	
			, {1206, -9, -3, 0}, {1194, -9, -2, 0}, {1206, -9, -1, 0}// 259	260	261	
			, {1194, -8, -7, 0}, {1206, -8, -6, 0}, {1194, -8, -5, 0}// 262	263	264	
			, {1206, -8, -4, 0}, {1194, -8, -3, 0}, {1206, -11, -7, 0}// 265	266	267	
			, {1194, -11, -6, 0}, {1206, -12, -4, 0}, {1194, -12, -3, 0}// 268	269	270	
			, {1206, -12, -2, 0}, {1194, -12, -1, 0}, {1194, -12, -7, 0}// 271	272	273	
			, {1206, -12, -6, 0}, {1194, -12, -5, 0}, {1194, -13, -6, 0}// 274	275	276	
			, {1206, -13, -5, 0}, {1194, -13, -4, 0}, {1206, -13, -3, 0}// 277	278	279	
			, {1194, -13, -2, 0}, {1206, -13, -1, 0}, {132, -4, -2, 0}// 280	281	282	
			, {132, -4, -3, 0}, {1206, -13, -7, 0}, {6013, -1, -2, 22}// 283	284	285	
			, {6013, -1, -3, 22}, {6013, 0, -5, 22}, {6013, 0, -4, 22}// 286	287	288	
			, {6013, -2, -1, 22}, {132, -3, -5, 0}, {132, 0, -6, 0}// 289	290	291	
			, {6013, -2, -2, 22}, {6013, 0, -2, 22}, {6013, -2, -3, 22}// 292	293	294	
			, {6013, 0, -3, 22}, {6013, -2, -4, 22}, {6013, 0, -1, 22}// 295	296	297	
			, {6013, -1, -1, 22}, {132, -4, -1, 0}, {6013, -3, -3, 22}// 298	299	300	
			, {6013, -3, -2, 22}, {6013, -3, -1, 22}, {6019, -4, -3, 22}// 301	302	303	
			, {6019, -4, -2, 22}, {132, 0, -5, 0}, {132, -1, -3, 0}// 304	305	306	
			, {132, -3, -3, 0}, {132, 0, -3, 0}, {132, -1, -4, 0}// 307	308	309	
			, {6013, -1, -4, 22}, {132, -3, -1, 0}, {6013, -1, -5, 22}// 310	311	312	
			, {132, -3, -2, 0}, {132, 0, -4, 0}, {132, -2, -1, 0}// 313	314	315	
			, {132, -2, -4, 0}, {132, -1, -2, 0}, {132, -2, -3, 0}// 316	317	318	
			, {132, -1, -1, 0}, {132, 0, -1, 0}, {132, -3, -4, 0}// 319	320	321	
			, {132, 0, -2, 0}, {132, -6, -6, 0}, {6025, -3, -5, 22}// 322	323	324	
			, {1206, 0, 0, 0}, {132, 0, 5, 0}, {1194, 0, 3, 0}// 325	326	327	
			, {132, -4, 2, 0}, {1206, -5, 1, 0}, {6024, -2, 5, 22}// 328	329	330	
			, {132, -5, 0, 0}, {1194, -2, 7, 0}, {1206, -7, 1, 0}// 331	332	333	
			, {1206, -2, 6, 0}, {1194, -15, 2, 0}, {1309, -2, 8, 0}// 334	335	336	
			, {6025, -4, 1, 22}, {1309, -14, 8, 0}, {6814, -3, 6, 8}// 337	338	339	
			, {6816, -4, 7, 8}, {1206, -4, 2, 0}, {1194, -5, 2, 0}// 340	341	342	
			, {1194, -3, 0, 0}, {1194, -4, 3, 0}, {1194, -5, 0, 0}// 343	344	345	
			, {1206, -1, 5, 0}, {132, -3, 5, 0}, {1309, -6, 8, 0}// 346	347	348	
			, {1206, -2, 4, 0}, {1206, -6, 2, 0}, {6019, -4, 1, 22}// 349	350	351	
			, {1206, -7, 7, 0}, {1309, -3, 8, 0}, {1206, -8, 0, 0}// 352	353	354	
			, {6024, -3, 4, 22}, {1206, -1, 1, 0}, {1206, -1, 3, 0}// 355	356	357	
			, {6816, -2, 6, 8}, {1206, -6, 0, 0}, {6020, 0, 6, 22}// 358	359	360	
			, {6019, -4, 3, 22}, {1194, -4, 5, 0}, {1194, -8, 5, 0}// 361	362	363	
			, {1206, -15, 3, 0}, {1194, -7, 6, 0}, {1206, -3, 7, 0}// 364	365	366	
			, {1194, -6, 3, 0}, {1194, -6, 1, 0}, {1309, -7, 8, 0}// 367	368	369	
			, {1194, 0, 7, 0}, {1194, -6, 5, 0}, {1194, -3, 4, 0}// 370	371	372	
			, {1309, -13, 8, 0}, {1206, -4, 6, 0}, {1194, -1, 0, 0}// 373	374	375	
			, {1194, -15, 6, 0}, {1206, -4, 4, 0}, {1194, -1, 6, 0}// 376	377	378	
			, {1206, 0, 6, 0}, {1194, -5, 6, 0}, {1206, -8, 4, 0}// 379	380	381	
			, {1194, -8, 7, 0}, {1206, -6, 4, 0}, {1194, -2, 5, 0}// 382	383	384	
			, {1194, -6, 7, 0}, {1206, -8, 6, 0}, {1206, -4, 0, 0}// 385	386	387	
			, {1206, -8, 2, 0}, {1194, 0, 5, 0}, {1194, -3, 2, 0}// 388	389	390	
			, {1194, -1, 2, 0}, {132, -1, 2, 0}, {1206, -3, 1, 0}// 391	392	393	
			, {1194, -7, 4, 0}, {1309, 0, 8, 0}, {1309, -11, 8, 0}// 394	395	396	
			, {1206, -7, 3, 0}, {6019, -4, 0, 22}, {1206, -5, 7, 0}// 397	398	399	
			, {6024, -3, 5, 22}, {1309, -8, 8, 0}, {1309, -12, 8, 0}// 400	401	402	
			, {1309, -5, 8, 0}, {1309, -10, 8, 0}, {1206, 0, 4, 0}// 403	404	405	
			, {6025, -3, 4, 22}, {132, 0, 2, 0}, {1206, -5, 5, 0}// 406	407	408	
			, {1194, -8, 1, 0}, {1309, -9, 8, 0}, {1206, -1, 7, 0}// 409	410	411	
			, {1206, -2, 2, 0}, {1194, -7, 2, 0}, {6024, -4, 2, 22}// 412	413	414	
			, {1309, -4, 8, 0}, {132, -5, 5, 0}, {132, -4, 5, 0}// 415	416	417	
			, {1194, -8, 3, 0}, {132, -5, 1, 0}, {1194, -2, 3, 0}// 418	419	420	
			, {132, 0, 6, 0}, {132, -4, 4, 0}, {132, -1, 5, 0}// 421	422	423	
			, {1309, -15, 8, 0}, {1194, -7, 0, 0}, {1309, -1, 8, 0}// 424	425	426	
			, {1194, -1, 4, 0}, {1206, -15, 1, 0}, {1206, -15, 5, 0}// 427	428	429	
			, {1206, -6, 6, 0}, {1194, -4, 1, 0}, {1194, -3, 6, 0}// 430	431	432	
			, {1206, -3, 5, 0}, {1206, -5, 3, 0}, {1206, -3, 3, 0}// 433	434	435	
			, {1206, -2, 0, 0}, {1194, -4, 7, 0}, {1194, -5, 4, 0}// 436	437	438	
			, {1194, -2, 1, 0}, {1206, -7, 5, 0}, {1194, -15, 0, 0}// 439	440	441	
			, {1206, 0, 2, 0}, {1206, -14, 0, 0}, {1206, -15, 7, 0}// 442	443	444	
			, {1194, 0, 1, 0}, {1206, -14, 2, 0}, {1194, -14, 1, 0}// 445	446	447	
			, {1194, -15, 4, 0}, {1194, -11, 0, 0}, {1206, -11, 1, 0}// 448	449	450	
			, {1194, -11, 2, 0}, {1206, -11, 3, 0}, {1194, -11, 4, 0}// 451	452	453	
			, {1206, -11, 5, 0}, {1194, -11, 6, 0}, {1206, -11, 7, 0}// 454	455	456	
			, {1206, -10, 0, 0}, {1194, -10, 1, 0}, {1206, -10, 2, 0}// 457	458	459	
			, {1194, -10, 3, 0}, {1206, -10, 4, 0}, {1194, -10, 5, 0}// 460	461	462	
			, {1206, -10, 6, 0}, {1194, -10, 7, 0}, {1194, -9, 0, 0}// 463	464	465	
			, {1206, -9, 1, 0}, {1194, -9, 2, 0}, {1206, -9, 3, 0}// 466	467	468	
			, {1194, -9, 4, 0}, {1206, -9, 5, 0}, {1194, -9, 6, 0}// 469	470	471	
			, {1206, -9, 7, 0}, {1206, -12, 6, 0}, {1194, -12, 7, 0}// 472	473	474	
			, {1206, -12, 2, 0}, {1194, -12, 3, 0}, {1206, -12, 4, 0}// 475	476	477	
			, {1194, -12, 5, 0}, {1206, -12, 0, 0}, {1194, -12, 1, 0}// 478	479	480	
			, {1206, -13, 7, 0}, {1194, -13, 2, 0}, {1206, -13, 3, 0}// 481	482	483	
			, {1194, -13, 4, 0}, {1206, -13, 5, 0}, {1194, -13, 6, 0}// 484	485	486	
			, {1206, -13, 1, 0}, {1194, -13, 0, 0}, {1194, -14, 3, 0}// 487	488	489	
			, {1206, -14, 4, 0}, {1194, -14, 5, 0}, {1206, -14, 6, 0}// 490	491	492	
			, {1194, -14, 7, 0}, {132, -5, 7, 0}, {6013, -2, 3, 22}// 493	494	495	
			, {6013, 0, 3, 22}, {6013, -1, 4, 22}, {6013, 0, 1, 22}// 496	497	498	
			, {6013, 0, 2, 22}, {132, -4, 0, 0}, {6013, -1, 3, 22}// 499	500	501	
			, {6013, -1, 2, 22}, {6013, 0, 0, 22}, {6013, -2, 0, 22}// 502	503	504	
			, {6013, -1, 1, 22}, {6013, -2, 2, 22}, {6013, -2, 1, 22}// 505	506	507	
			, {6013, 0, 4, 22}, {6013, -2, 4, 22}, {6013, 0, 5, 22}// 508	509	510	
			, {6013, -1, 0, 22}, {6013, -1, 5, 22}, {132, -4, 1, 0}// 511	512	513	
			, {6013, -3, 0, 22}, {132, 0, 1, 0}, {6013, -3, 3, 22}// 514	515	516	
			, {6013, -3, 2, 22}, {6013, -3, 1, 22}, {132, -2, 0, 0}// 517	518	519	
			, {132, 0, 3, 0}, {132, -2, 2, 0}, {132, -1, 0, 0}// 520	521	522	
			, {132, -3, 2, 0}, {132, 0, 0, 0}, {132, -2, 1, 0}// 523	524	525	
			, {132, -1, 3, 0}, {132, -1, 1, 0}, {132, -2, 3, 0}// 526	527	528	
			, {132, 0, 4, 0}, {132, -2, 4, 0}, {132, -3, 0, 0}// 529	530	531	
			, {132, -1, 4, 0}, {132, -3, 4, 0}, {132, -3, 1, 0}// 532	533	534	
			, {132, -3, 3, 0}, {132, -4, 6, 0}, {132, -6, 7, 0}// 535	536	537	
			, {132, -5, 6, 0}, {132, -6, 6, 0}, {132, -2, 5, 0}// 538	539	540	
			, {132, -4, 3, 0}, {6019, -4, 2, 22}, {1194, 15, -4, 0}// 541	542	543	
			, {1206, 14, -2, 0}, {132, 8, -6, 0}, {1309, 11, -8, 0}// 544	545	546	
			, {1309, 10, -8, 0}, {1194, 7, -4, 0}, {1309, 9, -8, 0}// 547	548	549	
			, {1309, 8, -8, 0}, {1206, 2, -2, 0}, {1194, 3, -2, 0}// 550	551	552	
			, {1206, 4, -4, 0}, {1206, 13, -3, 0}, {1309, 15, -8, 0}// 553	554	555	
			, {1194, 2, -5, 0}, {1194, 12, -5, 0}, {1206, 12, -4, 0}// 556	557	558	
			, {1206, 6, -4, 0}, {1206, 5, -5, 0}, {1194, 4, -7, 0}// 559	560	561	
			, {1206, 11, -3, 0}, {1194, 3, -6, 0}, {1206, 4, -2, 0}// 562	563	564	
			, {1194, 12, -3, 0}, {1206, 7, -7, 0}, {1194, 12, -7, 0}// 565	566	567	
			, {1309, 1, -8, 0}, {1194, 6, -1, 0}, {1194, 7, -6, 0}// 568	569	570	
			, {6024, 6, -3, 22}, {1206, 2, -6, 0}, {1194, 13, -2, 0}// 571	572	573	
			, {1206, 16, -6, 0}, {1194, 16, -1, 0}, {1194, 14, -5, 0}// 574	575	576	
			, {1194, 4, -3, 0}, {1206, 16, -2, 0}, {132, 2, -6, 0}// 577	578	579	
			, {1206, 2, -4, 0}, {1194, 16, -7, 0}, {1194, 11, -2, 0}// 580	581	582	
			, {1194, 15, -2, 0}, {1194, 14, -1, 0}, {6013, 5, -3, 22}// 583	584	585	
			, {1194, 4, -5, 0}, {1206, 15, -3, 0}, {1194, 16, -5, 0}// 586	587	588	
			, {132, 6, -3, 0}, {1206, 15, -5, 0}, {1206, 3, -3, 0}// 589	590	591	
			, {1206, 16, -4, 0}, {1194, 16, -3, 0}, {1206, 5, -3, 0}// 592	593	594	
			, {6013, 5, -2, 22}, {1194, 4, -1, 0}, {132, 7, -1, 0}// 595	596	597	
			, {1194, 6, -7, 0}, {1194, 5, -6, 0}, {1194, 2, -3, 0}// 598	599	600	
			, {1206, 4, -6, 0}, {1194, 14, -3, 0}, {1206, 13, -5, 0}// 601	602	603	
			, {1194, 13, -4, 0}, {6018, 1, -6, 22}, {1206, 14, -6, 0}// 604	605	606	
			, {132, 6, -2, 0}, {1309, 16, -8, 0}, {6021, 6, -2, 22}// 607	608	609	
			, {1194, 2, -1, 0}, {1194, 8, -5, 0}, {6018, 2, -6, 22}// 610	611	612	
			, {1206, 15, -7, 0}, {1206, 6, -6, 0}, {1194, 12, -1, 0}// 613	614	615	
			, {1206, 5, -7, 0}, {1206, 14, -4, 0}, {6021, 6, -1, 22}// 616	617	618	
			, {1194, 5, -2, 0}, {1194, 5, -4, 0}, {1206, 3, -1, 0}// 619	620	621	
			, {1206, 11, -1, 0}, {1206, 1, -3, 0}, {1206, 12, -6, 0}// 622	623	624	
			, {1206, 13, -1, 0}, {1194, 7, -2, 0}, {1194, 14, -7, 0}// 625	626	627	
			, {1309, 2, -8, 0}, {1194, 15, -6, 0}, {1194, 13, -6, 0}// 628	629	630	
			, {1206, 13, -7, 0}, {1206, 15, -1, 0}, {1309, 3, -8, 0}// 631	632	633	
			, {1206, 7, -5, 0}, {1206, 12, -2, 0}, {1194, 1, -2, 0}// 634	635	636	
			, {1309, 14, -8, 0}, {1206, 5, -1, 0}, {132, 7, -5, 0}// 637	638	639	
			, {1206, 1, -7, 0}, {1206, 3, -7, 0}, {1194, 1, -4, 0}// 640	641	642	
			, {1206, 10, -2, 0}, {132, 8, -7, 0}, {1309, 6, -8, 0}// 643	644	645	
			, {1309, 5, -8, 0}, {1206, 6, -2, 0}, {1309, 4, -8, 0}// 646	647	648	
			, {1309, 7, -8, 0}, {1194, 6, -5, 0}, {1194, 6, -3, 0}// 649	650	651	
			, {6022, 5, -4, 22}, {1194, 2, -7, 0}, {6022, 4, -5, 22}// 652	653	654	
			, {1206, 1, -5, 0}, {1206, 1, -1, 0}, {1194, 1, -6, 0}// 655	656	657	
			, {1309, 12, -8, 0}, {1309, 13, -8, 0}, {1206, 3, -5, 0}// 658	659	660	
			, {1194, 3, -4, 0}, {6013, 5, -1, 22}, {1194, 11, -6, 0}// 661	662	663	
			, {1194, 9, -2, 0}, {1206, 11, -7, 0}, {1194, 8, -3, 0}// 664	665	666	
			, {1194, 11, -4, 0}, {1206, 8, -4, 0}, {1206, 10, -6, 0}// 667	668	669	
			, {1194, 9, -6, 0}, {1194, 10, -1, 0}, {1206, 9, -5, 0}// 670	671	672	
			, {1206, 9, -3, 0}, {1206, 8, -6, 0}, {1206, 8, -2, 0}// 673	674	675	
			, {1194, 10, -7, 0}, {1194, 8, -7, 0}, {1206, 7, -1, 0}// 676	677	678	
			, {1194, 10, -3, 0}, {1206, 7, -3, 0}, {1206, 9, -1, 0}// 679	680	681	
			, {1194, 9, -4, 0}, {1206, 9, -7, 0}, {1194, 8, -1, 0}// 682	683	684	
			, {1206, 10, -4, 0}, {1206, 11, -5, 0}, {1194, 10, -5, 0}// 685	686	687	
			, {132, 7, -7, 0}, {132, 7, -6, 0}, {132, 6, -1, 0}// 688	689	690	
			, {6013, 4, -4, 22}, {6013, 3, -1, 22}, {6013, 4, -1, 22}// 691	692	693	
			, {6013, 4, -3, 22}, {6013, 3, -4, 22}, {6013, 2, -2, 22}// 694	695	696	
			, {132, 5, -5, 0}, {132, 3, -5, 0}, {132, 4, -5, 0}// 697	698	699	
			, {132, 1, -6, 0}, {132, 2, -5, 0}, {132, 1, -5, 0}// 700	701	702	
			, {6013, 1, -2, 22}, {6013, 1, -5, 22}, {6013, 3, -5, 22}// 703	704	705	
			, {6013, 2, -5, 22}, {6013, 1, -3, 22}, {6013, 3, -2, 22}// 706	707	708	
			, {6013, 2, -3, 22}, {6013, 1, -1, 22}, {6013, 3, -3, 22}// 709	710	711	
			, {6013, 2, -1, 22}, {6013, 2, -4, 22}, {6013, 4, -2, 22}// 712	713	714	
			, {6013, 1, -4, 22}, {132, 5, -2, 0}, {132, 5, -1, 0}// 715	716	717	
			, {132, 5, -4, 0}, {132, 5, -3, 0}, {132, 6, -5, 0}// 718	719	720	
			, {132, 6, -4, 0}, {132, 2, -2, 0}, {132, 1, -4, 0}// 721	722	723	
			, {132, 4, -4, 0}, {132, 2, -1, 0}, {132, 3, -2, 0}// 724	725	726	
			, {132, 1, -2, 0}, {132, 4, -2, 0}, {132, 4, -1, 0}// 727	728	729	
			, {132, 1, -1, 0}, {132, 1, -3, 0}, {132, 4, -3, 0}// 730	731	732	
			, {132, 2, -4, 0}, {132, 3, -4, 0}, {132, 3, -1, 0}// 733	734	735	
			, {132, 3, -3, 0}, {132, 2, -3, 0}, {132, 6, -6, 0}// 736	737	738	
			, {6021, 6, -3, 22}, {6022, 6, -4, 22}, {6814, 7, -3, 8}// 739	740	741	
			, {1206, 3, 1, 0}, {1194, 15, 2, 0}, {1194, 11, 0, 0}// 742	743	744	
			, {1194, 10, 3, 0}, {1206, 14, 4, 0}, {1194, 5, 4, 0}// 745	746	747	
			, {132, 2, 4, 0}, {1194, 9, 4, 0}, {1194, 3, 2, 0}// 748	749	750	
			, {1194, 6, 5, 0}, {1194, 13, 6, 0}, {1194, 4, 1, 0}// 751	752	753	
			, {1194, 10, 5, 0}, {1206, 11, 5, 0}, {1206, 16, 0, 0}// 754	755	756	
			, {132, 7, 0, 0}, {6013, 5, 0, 22}, {1194, 1, 0, 0}// 757	758	759	
			, {6816, 7, 2, 7}, {1194, 10, 1, 0}, {1309, 7, 8, 0}// 760	761	762	
			, {132, 4, 5, 0}, {1194, 5, 2, 0}, {1206, 11, 7, 0}// 763	764	765	
			, {1194, 12, 5, 0}, {1206, 13, 1, 0}, {1309, 13, 8, 0}// 766	767	768	
			, {1206, 5, 1, 0}, {1194, 3, 4, 0}, {1194, 14, 1, 0}// 769	770	771	
			, {1309, 2, 8, 0}, {1206, 2, 6, 0}, {1194, 16, 5, 0}// 772	773	774	
			, {1194, 15, 4, 0}, {1309, 12, 8, 0}, {6020, 2, 6, 22}// 775	776	777	
			, {6021, 6, 0, 22}, {1206, 3, 3, 0}, {6023, 4, 5, 22}// 778	779	780	
			, {132, 2, 6, 0}, {1206, 1, 5, 0}, {1194, 4, 3, 0}// 781	782	783	
			, {1206, 14, 6, 0}, {1194, 15, 0, 0}, {1194, 11, 2, 0}// 784	785	786	
			, {1194, 13, 0, 0}, {1194, 2, 3, 0}, {132, 6, 4, 0}// 787	788	789	
			, {1194, 4, 7, 0}, {1206, 4, 6, 0}, {1206, 4, 4, 0}// 790	791	792	
			, {1194, 1, 4, 0}, {1194, 4, 5, 0}, {1206, 2, 0, 0}// 793	794	795	
			, {1206, 14, 0, 0}, {1206, 12, 6, 0}, {132, 5, 5, 0}// 796	797	798	
			, {6021, 6, 3, 22}, {6020, 1, 6, 22}, {1194, 5, 6, 0}// 799	800	801	
			, {1194, 14, 5, 0}, {6024, 6, 3, 22}, {1206, 15, 5, 0}// 802	803	804	
			, {1206, 5, 5, 0}, {1309, 15, 8, 0}, {1194, 3, 6, 0}// 805	806	807	
			, {1194, 6, 7, 0}, {1206, 12, 4, 0}, {1206, 2, 4, 0}// 808	809	810	
			, {1194, 15, 6, 0}, {132, 1, 6, 0}, {6021, 6, 1, 22}// 811	812	813	
			, {1206, 13, 3, 0}, {1194, 2, 1, 0}, {6022, 5, 5, 22}// 814	815	816	
			, {1206, 3, 5, 0}, {1194, 1, 6, 0}, {1206, 11, 3, 0}// 817	818	819	
			, {1194, 12, 1, 0}, {1194, 14, 3, 0}, {1206, 6, 4, 0}// 820	821	822	
			, {1206, 16, 6, 0}, {1206, 5, 7, 0}, {1194, 2, 5, 0}// 823	824	825	
			, {1309, 14, 8, 0}, {132, 3, 4, 0}, {1194, 3, 0, 0}// 826	827	828	
			, {1206, 6, 6, 0}, {6023, 5, 4, 22}, {1309, 8, 8, 0}// 829	830	831	
			, {1206, 2, 2, 0}, {1194, 7, 0, 0}, {6024, 6, 1, 22}// 832	833	834	
			, {1194, 11, 6, 0}, {1194, 16, 7, 0}, {1206, 15, 3, 0}// 835	836	837	
			, {1206, 4, 0, 0}, {1309, 16, 8, 0}, {1206, 14, 2, 0}// 838	839	840	
			, {1194, 16, 1, 0}, {1194, 13, 2, 0}, {1206, 13, 7, 0}// 841	842	843	
			, {1194, 12, 3, 0}, {1194, 12, 7, 0}, {1206, 12, 2, 0}// 844	845	846	
			, {1206, 15, 1, 0}, {1194, 14, 7, 0}, {1194, 5, 0, 0}// 847	848	849	
			, {1206, 13, 5, 0}, {1206, 4, 2, 0}, {1309, 5, 8, 0}// 850	851	852	
			, {1206, 10, 6, 0}, {1309, 1, 8, 0}, {1206, 3, 7, 0}// 853	854	855	
			, {1206, 15, 7, 0}, {1194, 11, 4, 0}, {1194, 1, 2, 0}// 856	857	858	
			, {1206, 11, 1, 0}, {1194, 13, 4, 0}, {1309, 10, 8, 0}// 859	860	861	
			, {1309, 11, 8, 0}, {132, 3, 5, 0}, {1194, 2, 7, 0}// 862	863	864	
			, {1206, 9, 3, 0}, {6021, 6, 2, 22}, {1194, 16, 3, 0}// 865	866	867	
			, {1206, 5, 3, 0}, {1206, 16, 4, 0}, {1206, 16, 2, 0}// 868	869	870	
			, {6814, 7, 4, 11}, {1206, 1, 3, 0}, {1206, 12, 0, 0}// 871	872	873	
			, {1309, 9, 8, 0}, {1309, 4, 8, 0}, {1206, 6, 0, 0}// 874	875	876	
			, {1194, 6, 3, 0}, {1206, 6, 2, 0}, {1309, 3, 8, 0}// 877	878	879	
			, {1194, 6, 1, 0}, {132, 2, 5, 0}, {1309, 6, 8, 0}// 880	881	882	
			, {132, 1, 5, 0}, {132, 6, 6, 0}, {1206, 1, 7, 0}// 883	884	885	
			, {132, 6, 3, 0}, {1206, 1, 1, 0}, {1194, 8, 5, 0}// 886	887	888	
			, {1194, 8, 3, 0}, {1194, 7, 4, 0}, {1194, 9, 6, 0}// 889	890	891	
			, {1206, 8, 4, 0}, {1194, 9, 2, 0}, {1206, 10, 2, 0}// 892	893	894	
			, {1194, 8, 7, 0}, {1206, 7, 7, 0}, {1206, 10, 0, 0}// 895	896	897	
			, {1206, 9, 5, 0}, {1194, 8, 1, 0}, {1194, 9, 0, 0}// 898	899	900	
			, {1206, 8, 0, 0}, {1206, 8, 2, 0}, {1206, 7, 5, 0}// 901	902	903	
			, {1206, 10, 4, 0}, {1206, 8, 6, 0}, {1206, 9, 1, 0}// 904	905	906	
			, {1194, 7, 2, 0}, {1206, 9, 7, 0}, {1206, 7, 3, 0}// 907	908	909	
			, {1194, 10, 7, 0}, {1206, 7, 1, 0}, {1194, 7, 6, 0}// 910	911	912	
			, {132, 7, 7, 0}, {132, 8, 7, 0}, {132, 8, 6, 0}// 913	914	915	
			, {132, 6, 0, 0}, {132, 6, 1, 0}, {132, 7, 6, 0}// 916	917	918	
			, {132, 7, 5, 0}, {132, 6, 5, 0}, {6013, 2, 4, 22}// 919	920	921	
			, {6013, 1, 5, 22}, {6013, 2, 1, 22}, {6022, 6, 2, 22}// 922	923	924	
			, {6816, 5, 6, 8}, {6013, 3, 4, 22}, {132, 6, 2, 0}// 925	926	927	
			, {132, 7, 1, 0}, {6013, 3, 2, 22}, {6013, 1, 4, 22}// 928	929	930	
			, {6013, 3, 1, 22}, {6013, 1, 2, 22}, {6013, 1, 0, 22}// 931	932	933	
			, {6013, 2, 3, 22}, {6013, 3, 0, 22}, {6013, 1, 3, 22}// 934	935	936	
			, {6013, 2, 0, 22}, {6013, 3, 3, 22}, {6013, 1, 1, 22}// 937	938	939	
			, {6013, 3, 5, 22}, {6013, 2, 5, 22}, {6013, 2, 2, 22}// 940	941	942	
			, {132, 5, 2, 0}, {132, 5, 3, 0}, {132, 5, 4, 0}// 943	944	945	
			, {132, 5, 0, 0}, {132, 5, 1, 0}, {132, 4, 3, 0}// 946	947	948	
			, {132, 4, 4, 0}, {6013, 5, 1, 22}, {6013, 5, 2, 22}// 949	950	951	
			, {6013, 5, 3, 22}, {132, 2, 2, 0}, {132, 1, 3, 0}// 952	953	954	
			, {132, 2, 0, 0}, {132, 1, 0, 0}, {132, 1, 4, 0}// 955	956	957	
			, {132, 4, 0, 0}, {132, 3, 3, 0}, {132, 3, 0, 0}// 958	959	960	
			, {132, 4, 1, 0}, {132, 1, 1, 0}, {132, 3, 1, 0}// 961	962	963	
			, {132, 1, 2, 0}, {132, 3, 2, 0}, {132, 4, 2, 0}// 964	965	966	
			, {132, 2, 1, 0}, {132, 2, 3, 0}, {6022, 6, 0, 22}// 967	968	969	
			, {6013, 4, 0, 22}, {6013, 4, 1, 22}, {6013, 4, 2, 22}// 970	971	972	
			, {6013, 4, 3, 22}, {6013, 4, 4, 22}, {1206, 17, -7, 0}// 973	974	975	
			, {1206, 20, -2, 0}, {1194, 23, -4, 0}, {1309, 23, -8, 0}// 976	977	978	
			, {1206, 19, -5, 0}, {1206, 21, -7, 0}, {1309, 22, -8, 0}// 979	980	981	
			, {1194, 23, -1, 0}, {1206, 20, -6, 0}, {1206, 21, -5, 0}// 982	983	984	
			, {1206, 21, -1, 0}, {1194, 21, -4, 0}, {1194, 20, -7, 0}// 985	986	987	
			, {1194, 19, -6, 0}, {1194, 21, -6, 0}, {1309, 21, -8, 0}// 988	989	990	
			, {1206, 17, -1, 0}, {1194, 20, -3, 0}, {1194, 22, -1, 0}// 991	992	993	
			, {1194, 17, -2, 0}, {1194, 19, -2, 0}, {1206, 20, -4, 0}// 994	995	996	
			, {1206, 17, -3, 0}, {1194, 23, -6, 0}, {1206, 23, -5, 0}// 997	998	999	
			, {1206, 21, -3, 0}, {1309, 19, -8, 0}, {1194, 21, -2, 0}// 1000	1001	1002	
			, {1194, 19, -4, 0}, {1206, 19, -3, 0}, {1206, 17, -5, 0}// 1003	1004	1005	
			, {1206, 18, -6, 0}, {1206, 19, -1, 0}, {1194, 17, -6, 0}// 1006	1007	1008	
			, {1194, 22, -3, 0}, {1309, 20, -8, 0}, {1208, 22, -2, 0}// 1009	1010	1011	
			, {1194, 18, -5, 0}, {1194, 17, -4, 0}, {1194, 20, -5, 0}// 1012	1013	1014	
			, {1309, 18, -8, 0}, {1206, 19, -7, 0}, {1194, 23, -2, 0}// 1015	1016	1017	
			, {1194, 22, -7, 0}, {1206, 22, -6, 0}, {1194, 22, -5, 0}// 1018	1019	1020	
			, {1206, 22, -4, 0}, {1194, 20, -1, 0}, {1309, 17, -8, 0}// 1021	1022	1023	
			, {1194, 23, -3, 0}, {1206, 23, -7, 0}, {1206, 18, -4, 0}// 1024	1025	1026	
			, {1194, 18, -3, 0}, {1206, 18, -2, 0}, {1194, 18, -1, 0}// 1027	1028	1029	
			, {1194, 18, -7, 0}, {1206, 20, 0, 0}, {1194, 20, 7, 0}// 1030	1031	1032	
			, {1206, 20, 4, 0}, {1194, 23, 6, 0}, {1309, 17, 8, 0}// 1033	1034	1035	
			, {1194, 17, 6, 0}, {1206, 21, 5, 0}, {1206, 21, 1, 0}// 1036	1037	1038	
			, {1194, 23, 7, 0}, {1194, 19, 6, 0}, {1194, 23, 0, 0}// 1039	1040	1041	
			, {1194, 19, 2, 0}, {1194, 23, 3, 0}, {1309, 18, 8, 0}// 1042	1043	1044	
			, {1194, 21, 6, 0}, {1309, 23, 8, 0}, {1309, 22, 8, 0}// 1045	1046	1047	
			, {1194, 23, 1, 0}, {1206, 19, 1, 0}, {1206, 20, 2, 0}// 1048	1049	1050	
			, {1206, 21, 3, 0}, {1194, 17, 0, 0}, {1206, 22, 2, 0}// 1051	1052	1053	
			, {1194, 18, 3, 0}, {1206, 19, 3, 0}, {1206, 19, 7, 0}// 1054	1055	1056	
			, {1309, 19, 8, 0}, {1194, 19, 0, 0}, {1206, 18, 6, 0}// 1057	1058	1059	
			, {1194, 18, 7, 0}, {1206, 21, 7, 0}, {1206, 22, 4, 0}// 1060	1061	1062	
			, {1194, 21, 0, 0}, {1194, 20, 5, 0}, {1194, 21, 4, 0}// 1063	1064	1065	
			, {1309, 20, 8, 0}, {1194, 21, 2, 0}, {1194, 18, 5, 0}// 1066	1067	1068	
			, {1206, 17, 3, 0}, {1194, 17, 2, 0}, {1206, 17, 1, 0}// 1069	1070	1071	
			, {1206, 17, 5, 0}, {1309, 21, 8, 0}, {1194, 23, 2, 0}// 1072	1073	1074	
			, {1194, 19, 4, 0}, {1194, 18, 1, 0}, {1206, 19, 5, 0}// 1075	1076	1077	
			, {1194, 20, 1, 0}, {1194, 22, 7, 0}, {1194, 22, 1, 0}// 1078	1079	1080	
			, {1206, 22, 0, 0}, {1194, 22, 3, 0}, {1206, 22, 6, 0}// 1081	1082	1083	
			, {1194, 22, 5, 0}, {1206, 20, 6, 0}, {1194, 17, 4, 0}// 1084	1085	1086	
			, {1206, 18, 2, 0}, {1194, 20, 3, 0}, {1194, 23, 5, 0}// 1087	1088	1089	
			, {1194, 23, 4, 0}, {1206, 18, 4, 0}, {1206, 18, 0, 0}// 1090	1091	1092	
			, {1206, 17, 7, 0}// 1093	
		};



        public override BaseAddonDeed Deed => null;

        [Constructable]
        public BelfryAddon()
        {

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent(new AddonComponent(m_AddOnSimpleComponents[i, 0]), m_AddOnSimpleComponents[i, 1], m_AddOnSimpleComponents[i, 2], m_AddOnSimpleComponents[i, 3]);


        }

        public BelfryAddon(Serial serial) : base(serial)
        {
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
