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
-- Name: mt_immutable_timestamp(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.mt_immutable_timestamp(value text) RETURNS timestamp without time zone
    LANGUAGE sql IMMUTABLE
    AS $$
    select value::timestamp
$$;


ALTER FUNCTION public.mt_immutable_timestamp(value text) OWNER TO postgres;

--
-- Name: mt_immutable_timestamptz(text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.mt_immutable_timestamptz(value text) RETURNS timestamp with time zone
    LANGUAGE sql IMMUTABLE
    AS $$
    select value::timestamptz
$$;


ALTER FUNCTION public.mt_immutable_timestamptz(value text) OWNER TO postgres;

--
-- Name: mt_insert_product(jsonb, character varying, uuid, uuid); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.mt_insert_product(doc jsonb, docdotnettype character varying, docid uuid, docversion uuid) RETURNS uuid
    LANGUAGE plpgsql
    AS $$
BEGIN
INSERT INTO public.mt_doc_product ("data", "mt_dotnet_type", "id", "mt_version", mt_last_modified) VALUES (doc, docDotNetType, docId, docVersion, transaction_timestamp());

  RETURN docVersion;
END;
$$;


ALTER FUNCTION public.mt_insert_product(doc jsonb, docdotnettype character varying, docid uuid, docversion uuid) OWNER TO postgres;

--
-- Name: mt_update_product(jsonb, character varying, uuid, uuid); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.mt_update_product(doc jsonb, docdotnettype character varying, docid uuid, docversion uuid) RETURNS uuid
    LANGUAGE plpgsql
    AS $$
DECLARE
  final_version uuid;
BEGIN
  UPDATE public.mt_doc_product SET "data" = doc, "mt_dotnet_type" = docDotNetType, "mt_version" = docVersion, mt_last_modified = transaction_timestamp() where id = docId;

  SELECT mt_version FROM public.mt_doc_product into final_version WHERE id = docId ;
  RETURN final_version;
END;
$$;


ALTER FUNCTION public.mt_update_product(doc jsonb, docdotnettype character varying, docid uuid, docversion uuid) OWNER TO postgres;

--
-- Name: mt_upsert_product(jsonb, character varying, uuid, uuid); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.mt_upsert_product(doc jsonb, docdotnettype character varying, docid uuid, docversion uuid) RETURNS uuid
    LANGUAGE plpgsql
    AS $$
DECLARE
  final_version uuid;
BEGIN
INSERT INTO public.mt_doc_product ("data", "mt_dotnet_type", "id", "mt_version", mt_last_modified) VALUES (doc, docDotNetType, docId, docVersion, transaction_timestamp())
  ON CONFLICT ON CONSTRAINT pk_mt_doc_product
  DO UPDATE SET "data" = doc, "mt_dotnet_type" = docDotNetType, "mt_version" = docVersion, mt_last_modified = transaction_timestamp();

  SELECT mt_version FROM public.mt_doc_product into final_version WHERE id = docId ;
  RETURN final_version;
END;
$$;


ALTER FUNCTION public.mt_upsert_product(doc jsonb, docdotnettype character varying, docid uuid, docversion uuid) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: mt_doc_product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.mt_doc_product (
    id uuid NOT NULL,
    data jsonb NOT NULL,
    mt_last_modified timestamp with time zone DEFAULT transaction_timestamp(),
    mt_version uuid DEFAULT (md5(((random())::text || (clock_timestamp())::text)))::uuid NOT NULL,
    mt_dotnet_type character varying
);


ALTER TABLE public.mt_doc_product OWNER TO postgres;

--
-- Name: TABLE mt_doc_product; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE public.mt_doc_product IS 'origin:Marten.IDocumentStore, Marten, Version=3.13.1.0, Culture=neutral, PublicKeyToken=null';


--
-- Data for Name: mt_doc_product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.mt_doc_product (id, data, mt_last_modified, mt_version, mt_dotnet_type) FROM stdin;
707028f9-ec06-4aef-93a5-2127249760df	{"Id": "707028f9-ec06-4aef-93a5-2127249760df", "Name": "Test No. 1"}	2020-10-10 21:35:29.414959+02	01751402-cd74-472d-9bf7-97100a66ca9e	ProductAPI.DAL.Model.Product
\.


--
-- Name: mt_doc_product pk_mt_doc_product; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.mt_doc_product
    ADD CONSTRAINT pk_mt_doc_product PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

