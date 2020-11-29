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
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    login character varying(50) NOT NULL,
    passwordhash bytea NOT NULL,
    passwordsalt bytea NOT NULL,
    id integer NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (login, passwordhash, passwordsalt, id) FROM stdin;
test	\\x10c2bc03be7be1f5a8a544581b4fd226317201bc33ec562973ee79c1a4be1bb71ebb4038e328bfb1a95e5ae793fb1e3f51724e250facc907df0caf893b5da9d1	\\x973a5f1f97cab8ae26e79b56a133df9f41c60eaf162eae328e077617d8a4dc7a0612a9ccf339ca373cfdcdf81cbccb322f3d8575781b1f1391ee111a6da8726b7c00650a109ddbb49d81390a78ee4e13453283184dfca775d9002b9cc720b482e6d8d97db8aa3c00c03ea2266d5037a97ce1ea013810b334f6f36dc9a68ace10	1
test2	\\x8c2020c6cffebda15978ad29f190200550442785b0e20d5192b20fa4ae3b33fb482e63bf301bab9db013a5cae8d4ae30f660322b597a85d0cc81c78c015eda88	\\x998743431e32a4542e10bda8219558c3d2e8715e6cabda344e83a9b330393d084a409ad34d54467949808e9949c9dfc8d00b871bc6d68b8cff98be2d075aa06ff6e02d8588c2032443a83444aa1cfc7aadbe3b9781175d9ff8969dd603b6a547a5df64265f3c8e2f8325a7635ed94ae3cfc616f3a3fd6cc5fe0bd7c41510b2da	2
test3	\\x7f8dd0910fa712a30e91112d7ad04189d2549bb8f47ebaa97185f779faa8fac916b70d0b974cb9ff6e30d5fd9163366be4cd71174c79ffe28ce462d2358fcae9	\\x56a416074890c9af2ce5179ba81e4cc66eb5cc1cfb7ba7d0df6bdda7e795801f26f4ccaa97938624893e8427e4b42bdba3c41f10741a7aad8b52b4be0ed17a24b02e1da95d69589e3a6bbf8e26356dcfa134648fb440d3007edc8475187fa484e4f38fdedfe08181467ac0c0df54e2c1f1ea051944e1ed14920a594a1e4172bd	3
\.


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 3, true);


--
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

