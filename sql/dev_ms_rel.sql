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

--
-- Name: EntityFrameworkHiLoSequence; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."EntityFrameworkHiLoSequence"
    START WITH 1
    INCREMENT BY 10
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."EntityFrameworkHiLoSequence" OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Orders" (
    "Id" uuid NOT NULL,
    "Price" numeric NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "CreatedById" uuid
);


ALTER TABLE public."Orders" OWNER TO postgres;

--
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    "Id" uuid NOT NULL
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Orders" ("Id", "Price", "CreatedAt", "CreatedById") FROM stdin;
dae3ecfc-2772-49af-a884-941060c07601	10.55	2020-10-11 12:34:04.276	\N
\.


--
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" ("Id") FROM stdin;
\.


--
-- Name: EntityFrameworkHiLoSequence; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."EntityFrameworkHiLoSequence"', 1, false);


--
-- Name: Orders PK_Orders; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_Orders" PRIMARY KEY ("Id");


--
-- Name: User PK_User; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "PK_User" PRIMARY KEY ("Id");


--
-- Name: IX_Orders_CreatedById; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Orders_CreatedById" ON public."Orders" USING btree ("CreatedById");


--
-- Name: Orders FK_Orders_User_CreatedById; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_User_CreatedById" FOREIGN KEY ("CreatedById") REFERENCES public."User"("Id") ON DELETE RESTRICT;


--
-- PostgreSQL database dump complete
--

