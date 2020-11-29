--
-- PostgreSQL database dump
--

-- Dumped from database version 13.0 (Ubuntu 13.0-1.pgdg20.04+1)
-- Dumped by pg_dump version 13.0 (Ubuntu 13.0-1.pgdg20.04+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: messages; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.messages (
    id uuid NOT NULL,
    room_id uuid NOT NULL,
    content character varying(255) NOT NULL,
    user_id uuid NOT NULL,
    created_at timestamp without time zone
);


ALTER TABLE public.messages OWNER TO postgres;

--
-- Name: rooms; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rooms (
    id uuid NOT NULL
);


ALTER TABLE public.rooms OWNER TO postgres;

--
-- Name: user_rooms; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_rooms (
    id uuid NOT NULL,
    room_id uuid NOT NULL,
    user_id uuid NOT NULL
);


ALTER TABLE public.user_rooms OWNER TO postgres;

--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id uuid NOT NULL,
    login character varying(50) NOT NULL,
    external_id bigint NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Data for Name: messages; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.messages (id, room_id, content, user_id, created_at) FROM stdin;
bd9b2386-9b1c-422f-beb0-ac506c09d742	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasa	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 11:02:24.363624
7f4c6330-4f3e-406f-a070-3b78403cc9fb	e7118dca-0f94-40f4-a357-b538fb9a8ddf	das	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:02:38.509213
92198dca-fee1-407e-8ff4-e775ed5fb386	e7118dca-0f94-40f4-a357-b538fb9a8ddf	das	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:03:02.593376
f703af66-d0a2-4103-b24f-4b0f2365d332	e7118dca-0f94-40f4-a357-b538fb9a8ddf	das	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:04:50.971174
62c78677-40a1-48c6-a21f-bf0efc83d7d7	e7118dca-0f94-40f4-a357-b538fb9a8ddf	qweqwewe	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:04:55.482932
94a685c8-b37f-4308-a59b-9a311a439cb3	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dsads	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:04:58.783157
ffc7fcd8-ba07-45b1-9994-911c6515ee67	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasdasdasdas	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:05:52.948998
393f5fae-907c-4e34-9ff1-6a6afdc2e011	42e6424c-b874-4449-a56a-8a019df278ec	dasdasd	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:05:58.397673
b1c3e44c-8f34-48d9-abef-53095cf3787a	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasaasdas	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:07:36.965122
a547adf6-7de0-4236-8047-002a8326e553	42e6424c-b874-4449-a56a-8a019df278ec	qwewqewq	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:07:42.429551
99b0b0c3-f8ac-4a02-9604-2d1cb7fcc1bd	42e6424c-b874-4449-a56a-8a019df278ec	qweqweq	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:07:46.111487
333a8fec-4f5f-407c-8a57-4dd4273b3361	42e6424c-b874-4449-a56a-8a019df278ec	eqwewew	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:07:58.848745
8fa4e233-fd48-46d6-824d-f84f7999fba5	42e6424c-b874-4449-a56a-8a019df278ec	eqeqw	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:08:23.430975
aa0dd44b-4d86-49c3-b368-205897aeb427	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dsasd	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:08:29.888935
9d2b4433-ee1a-4bb1-b42b-8ae6b8e25c9a	42e6424c-b874-4449-a56a-8a019df278ec	dasa	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:09:34.74918
32fd1b1e-6752-4b0e-bd86-810375c26998	42e6424c-b874-4449-a56a-8a019df278ec	dfsfd	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:12:02.914178
78afc714-f594-4376-9d68-86d1a8e2df57	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasas	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:13:07.88247
a7b1d989-a708-49dc-ba0e-0236fa6b3196	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dsaa	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:15:12.198898
2d2e34e3-f333-4e5e-8440-3d1e1d96542c	e7118dca-0f94-40f4-a357-b538fb9a8ddf	das	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:16:37.312824
245cf495-bcb6-4807-af90-30cc8f5cbe00	e7118dca-0f94-40f4-a357-b538fb9a8ddf	sdsa	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:27:09.809976
b7843f72-5c68-4a36-998f-754acd679009	e7118dca-0f94-40f4-a357-b538fb9a8ddf	daddsdsd	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:31:20.815802
84fb39eb-a2fd-468f-8694-9dedb76dddda	e7118dca-0f94-40f4-a357-b538fb9a8ddf	adasdsdasd	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:35:14.422813
0f0f7d50-08ab-422e-a943-6dce5d68bc8a	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasdas	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:37:53.938634
78261185-6360-42ee-924d-e5774bee2aa0	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dassdsadsad	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:37:56.733768
8a989df1-5bf4-42de-af43-a51dfcd2c147	42e6424c-b874-4449-a56a-8a019df278ec	dadas	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:38:01.502701
0a68ce3d-dc28-4a99-84e8-457aa2547df7	42e6424c-b874-4449-a56a-8a019df278ec	dsadsadsad	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:38:09.391539
61107ffc-4c2d-41c4-8668-3f4b4cd3f78b	42e6424c-b874-4449-a56a-8a019df278ec	dsadasdsadsad	07f0d74e-60bd-4487-acd6-b9d2305417e7	2020-11-22 11:38:13.607807
e4261ec4-c611-4c30-a604-51976366f098	42e6424c-b874-4449-a56a-8a019df278ec	dasdasd	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 11:38:20.496312
61e7c16f-d73f-4502-a155-32362afe0be4	bf2bd6f5-05fe-47a3-b4db-2340d7668686	dasdsa	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 11:38:24.043314
b524d77f-f97a-4158-a80f-890804b6813c	42e6424c-b874-4449-a56a-8a019df278ec	dgfgd	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 16:38:47.257458
5e1c379d-44c4-414e-8e65-094ff7791a05	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dsadsa	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 17:00:00.367321
33948a9f-c4a3-4bbb-97eb-9e0b7078acb9	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasda	7356e54b-1a7b-428c-aa42-2c380096c4f7	2020-11-22 17:00:06.035179
f799ba91-88c3-43cd-af3d-ac2f85c99cec	e7118dca-0f94-40f4-a357-b538fb9a8ddf	fhgjh	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:52:37.335087
7e064d67-85af-4dab-99bb-ce7ed8bfd5ef	42e6424c-b874-4449-a56a-8a019df278ec	qqqqqqqq	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:53:08.720119
b4aa0335-e9f6-4706-8606-720d7b18ed10	e7118dca-0f94-40f4-a357-b538fb9a8ddf	sadsad	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:55:41.745122
1296f0c8-27f0-48f6-a4ca-aebcd0221590	e7118dca-0f94-40f4-a357-b538fb9a8ddf	wqewqeww	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:55:52.97484
8caee0c7-7c15-4584-a2f9-3b2540166b60	42e6424c-b874-4449-a56a-8a019df278ec	dawdwa	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:57:57.161121
3e303486-eaec-413b-a0c3-a5f39e191c38	42e6424c-b874-4449-a56a-8a019df278ec	dadsd	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:58:02.370283
c9fa52d8-9f36-49d2-94c5-78de48e020bd	42e6424c-b874-4449-a56a-8a019df278ec	1111	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:58:14.988531
10ef8150-237d-4a9b-803e-22b379a187d1	42e6424c-b874-4449-a56a-8a019df278ec	qwe	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-22 18:59:43.740262
e6aec049-c1c1-4b7f-b08d-d3bf12318ea2	e7118dca-0f94-40f4-a357-b538fb9a8ddf	dasda	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-25 18:24:20.911674
90271761-3d7a-456e-afa8-13d2daa81618	42e6424c-b874-4449-a56a-8a019df278ec	dasd	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-25 18:24:34.894023
215346ee-1b16-4043-93cd-c1b1283e9d91	e7118dca-0f94-40f4-a357-b538fb9a8ddf	aaaaaa	c32bc3ce-0323-425a-9b3a-cfd45076ac39	2020-11-26 20:37:32.393262
\.


--
-- Data for Name: rooms; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.rooms (id) FROM stdin;
e7118dca-0f94-40f4-a357-b538fb9a8ddf
42e6424c-b874-4449-a56a-8a019df278ec
bf2bd6f5-05fe-47a3-b4db-2340d7668686
\.


--
-- Data for Name: user_rooms; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_rooms (id, room_id, user_id) FROM stdin;
c2768004-14c6-4111-910c-cb07ff65e288	e7118dca-0f94-40f4-a357-b538fb9a8ddf	7356e54b-1a7b-428c-aa42-2c380096c4f7
df5ed5b8-eb7e-42df-8c92-7df66a48dab1	e7118dca-0f94-40f4-a357-b538fb9a8ddf	c32bc3ce-0323-425a-9b3a-cfd45076ac39
0893e538-3e52-469b-b2dc-eab80a7abc34	42e6424c-b874-4449-a56a-8a019df278ec	c32bc3ce-0323-425a-9b3a-cfd45076ac39
1fba09d4-30eb-4d90-b76b-015c39fb3914	42e6424c-b874-4449-a56a-8a019df278ec	07f0d74e-60bd-4487-acd6-b9d2305417e7
802eda32-84c6-457c-b86c-5127eccd6cb9	bf2bd6f5-05fe-47a3-b4db-2340d7668686	07f0d74e-60bd-4487-acd6-b9d2305417e7
b69138cf-27fc-4387-b802-9b5b3d15abe4	bf2bd6f5-05fe-47a3-b4db-2340d7668686	7356e54b-1a7b-428c-aa42-2c380096c4f7
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, login, external_id) FROM stdin;
c32bc3ce-0323-425a-9b3a-cfd45076ac39	test	1
7356e54b-1a7b-428c-aa42-2c380096c4f7	test2	2
07f0d74e-60bd-4487-acd6-b9d2305417e7	test3	3
\.


--
-- Name: messages messages_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.messages
    ADD CONSTRAINT messages_pkey PRIMARY KEY (id);


--
-- Name: rooms rooms_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rooms
    ADD CONSTRAINT rooms_pkey PRIMARY KEY (id);


--
-- Name: user_rooms user_rooms_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_rooms
    ADD CONSTRAINT user_rooms_pkey PRIMARY KEY (id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: messages fk_messages_to_rooms; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.messages
    ADD CONSTRAINT fk_messages_to_rooms FOREIGN KEY (room_id) REFERENCES public.rooms(id);


--
-- Name: user_rooms fk_user_rooms_to_rooms; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_rooms
    ADD CONSTRAINT fk_user_rooms_to_rooms FOREIGN KEY (room_id) REFERENCES public.rooms(id);


--
-- Name: messages user_to_messages; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.messages
    ADD CONSTRAINT user_to_messages FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- Name: user_rooms user_to_user_rooms; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_rooms
    ADD CONSTRAINT user_to_user_rooms FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- PostgreSQL database dump complete
--

