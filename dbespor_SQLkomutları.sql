--
-- PostgreSQL database dump
--

-- Dumped from database version 17.4
-- Dumped by pg_dump version 17.4

-- Started on 2025-05-17 13:47:49

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 228 (class 1255 OID 16579)
-- Name: get_user_age(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_user_age(p_user_id integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    avg_age DOUBLE PRECISION;
BEGIN
    SELECT AVG(DATE_PART('year', AGE(birth_date)))
    INTO avg_age
    FROM users
    WHERE id = p_user_id
    HAVING AVG(DATE_PART('year', AGE(birth_date))) IS NOT NULL;

    RETURN FLOOR(avg_age);
END;
$$;


ALTER FUNCTION public.get_user_age(p_user_id integer) OWNER TO postgres;

--
-- TOC entry 230 (class 1255 OID 16592)
-- Name: log_user_delete(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.log_user_delete() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO logs(log_message)
    VALUES (OLD.username || ' kullanıcısı sistemden silindi.');
    RETURN OLD;
END;
$$;


ALTER FUNCTION public.log_user_delete() OWNER TO postgres;

--
-- TOC entry 229 (class 1255 OID 16590)
-- Name: log_user_insert(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.log_user_insert() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO logs(log_message)
    VALUES (NEW.username || ' kullanıcısı sisteme kaydoldu.');
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.log_user_insert() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 16408)
-- Name: tournaments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tournaments (
    id integer NOT NULL,
    tname character varying(100) NOT NULL,
    tgame character varying(50) NOT NULL,
    start_date date NOT NULL,
    prize_pool numeric(10,2) NOT NULL,
    description text,
    organizer_id integer,
    created_at timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    participation_type character varying(10) NOT NULL,
    participant_limit integer NOT NULL,
    tid integer
);


ALTER TABLE public.tournaments OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16575)
-- Name: list_tournament; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.list_tournament AS
 SELECT id,
    tname,
    tgame,
    start_date,
    prize_pool,
    description,
    participation_type,
    participant_limit
   FROM public.tournaments;


ALTER VIEW public.list_tournament OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16581)
-- Name: logs; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.logs (
    id integer NOT NULL,
    log_message text,
    log_date timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE public.logs OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 16580)
-- Name: logs_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.logs_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.logs_id_seq OWNER TO postgres;

--
-- TOC entry 4961 (class 0 OID 0)
-- Dependencies: 226
-- Name: logs_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.logs_id_seq OWNED BY public.logs.id;


--
-- TOC entry 224 (class 1259 OID 16435)
-- Name: participants; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.participants (
    id integer NOT NULL,
    user_id integer,
    tournament_id integer NOT NULL,
    team_id integer,
    participation_type character varying(10) NOT NULL,
    score integer,
    CONSTRAINT participation_type_check CHECK ((((user_id IS NOT NULL) AND (team_id IS NULL) AND ((participation_type)::text = 'bireysel'::text)) OR ((user_id IS NULL) AND (team_id IS NOT NULL) AND ((participation_type)::text = 'takım'::text))))
);


ALTER TABLE public.participants OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16434)
-- Name: participants_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.participants_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.participants_id_seq OWNER TO postgres;

--
-- TOC entry 4962 (class 0 OID 0)
-- Dependencies: 223
-- Name: participants_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.participants_id_seq OWNED BY public.participants.id;


--
-- TOC entry 222 (class 1259 OID 16423)
-- Name: teams; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.teams (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    captain_id integer NOT NULL,
    game character varying NOT NULL,
    created_at date NOT NULL
);


ALTER TABLE public.teams OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16422)
-- Name: teams_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.teams_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.teams_id_seq OWNER TO postgres;

--
-- TOC entry 4963 (class 0 OID 0)
-- Dependencies: 221
-- Name: teams_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.teams_id_seq OWNED BY public.teams.id;


--
-- TOC entry 219 (class 1259 OID 16407)
-- Name: tournaments_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tournaments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.tournaments_id_seq OWNER TO postgres;

--
-- TOC entry 4964 (class 0 OID 0)
-- Dependencies: 219
-- Name: tournaments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tournaments_id_seq OWNED BY public.tournaments.id;


--
-- TOC entry 218 (class 1259 OID 16391)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    username character varying(50) NOT NULL,
    full_name character varying(50) NOT NULL,
    email character varying(100) NOT NULL,
    phone_number character varying(20) NOT NULL,
    password_hash character varying(255) NOT NULL,
    gender character varying(10) NOT NULL,
    birth_date timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    role character varying(20) DEFAULT 'kullanici'::character varying,
    fav_game character varying(255)
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16390)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 4965 (class 0 OID 0)
-- Dependencies: 217
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4776 (class 2604 OID 16584)
-- Name: logs id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.logs ALTER COLUMN id SET DEFAULT nextval('public.logs_id_seq'::regclass);


--
-- TOC entry 4775 (class 2604 OID 16438)
-- Name: participants id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.participants ALTER COLUMN id SET DEFAULT nextval('public.participants_id_seq'::regclass);


--
-- TOC entry 4774 (class 2604 OID 16426)
-- Name: teams id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teams ALTER COLUMN id SET DEFAULT nextval('public.teams_id_seq'::regclass);


--
-- TOC entry 4772 (class 2604 OID 16411)
-- Name: tournaments id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments ALTER COLUMN id SET DEFAULT nextval('public.tournaments_id_seq'::regclass);


--
-- TOC entry 4769 (class 2604 OID 16394)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 4955 (class 0 OID 16581)
-- Dependencies: 227
-- Data for Name: logs; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.logs (id, log_message, log_date) FROM stdin;
32	cks kullanıcısı sisteme kaydoldu.	2025-05-17 12:10:07.136408
33	Ümüt kullanıcısı sisteme kaydoldu.	2025-05-17 12:13:44.070365
34	Closer kullanıcısı sisteme kaydoldu.	2025-05-17 12:22:15.939278
35	StoneKiller kullanıcısı sisteme kaydoldu.	2025-05-17 12:25:55.949174
36	Galadriel kullanıcısı sisteme kaydoldu.	2025-05-17 12:30:35.256293
37	Beheaded kullanıcısı sisteme kaydoldu.	2025-05-17 12:35:14.195234
38	TokmakHead kullanıcısı sisteme kaydoldu.	2025-05-17 12:37:34.770372
39	ÇobanKomiser kullanıcısı sisteme kaydoldu.	2025-05-17 12:39:09.381812
40	İskenderBüyük kullanıcısı sisteme kaydoldu.	2025-05-17 12:41:11.635846
41	GreyWizard kullanıcısı sisteme kaydoldu.	2025-05-17 12:43:48.00272
42	GreyWizard kullanıcısı sistemden silindi.	2025-05-17 12:46:40.175702
43	GreyWizard kullanıcısı sisteme kaydoldu.	2025-05-17 12:47:40.867102
44	WhiteWizard kullanıcısı sisteme kaydoldu.	2025-05-17 12:48:35.888174
\.


--
-- TOC entry 4953 (class 0 OID 16435)
-- Dependencies: 224
-- Data for Name: participants; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.participants (id, user_id, tournament_id, team_id, participation_type, score) FROM stdin;
62	\N	31	31	takım	100
60	\N	31	29	takım	80
61	\N	31	30	takım	60
59	\N	31	28	takım	40
70	52	33	\N	bireysel	100
69	51	33	\N	bireysel	80
63	41	33	\N	bireysel	60
64	42	33	\N	bireysel	40
65	43	33	\N	bireysel	20
66	44	33	\N	bireysel	10
67	45	33	\N	bireysel	5
68	46	33	\N	bireysel	2
\.


--
-- TOC entry 4951 (class 0 OID 16423)
-- Dependencies: 222
-- Data for Name: teams; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.teams (id, name, captain_id, game, created_at) FROM stdin;
28	Kerem'in Takımı	41	League of Legends	2025-05-17
29	Ümit'in Takımı	42	League of Legends	2025-05-17
30	Ali'nin Takımı	43	League of Legends	2025-05-17
31	Mehmet'in Takımı	44	League of Legends	2025-05-17
32	Zeynep'in Takımı	45	League of Legends	2025-05-17
33	Zeynep'in Takımı	45	Valorant	2025-05-17
34	Emir Han'ın Takımı	46	Valorant	2025-03-01
35	Tunç'un Takımı	47	Valorant	2025-05-17
36	Hüsnü'nün Takımı	48	Valorant	2025-05-17
37	İskender'in Takımı	49	CS:GO	2025-05-17
38	Gandalf'ın Takımı	51	CS:GO	2025-05-17
\.


--
-- TOC entry 4949 (class 0 OID 16408)
-- Dependencies: 220
-- Data for Name: tournaments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tournaments (id, tname, tgame, start_date, prize_pool, description, organizer_id, created_at, participation_type, participant_limit, tid) FROM stdin;
31	Turnuva1(4)	League of Legends	2025-05-27	10000.00	Kazanana 10000TL	8	2025-05-17 12:49:39.712063+03	takım	4	\N
32	Turnuva2(8)	CS:GO	2025-05-30	7000.00	Kazanana 7000TL	8	2025-05-17 12:50:16.28074+03	takım	8	\N
33	Turnuva3(8)	CS:GO	2025-06-20	10000.00	Kazanana 10000TL	8	2025-05-17 12:51:36.771597+03	bireysel	8	\N
34	Turnuva4(4)	Valorant	2025-06-18	5000.00	Kazanana 5000TL	8	2025-05-17 12:52:41.91752+03	bireysel	4	\N
35	Turnuva5(8)	CS:GO	2025-05-27	10000.00	Kazanana 10000TL	8	2025-05-17 12:52:59.481381+03	takım	8	\N
36	Turnuva6(4)	League of Legends	2025-08-15	2000.00	Kazanana 2000TL	8	2025-05-17 12:53:15.888323+03	bireysel	4	\N
37	Turnuva7(4)	CS:GO	2025-06-13	3000.00	Kazanana 3000TL	8	2025-05-17 12:53:48.087846+03	takım	4	\N
38	Turnuva8(4)	CS:GO	2025-05-25	10000.00	Kazanana 10000TL	8	2025-05-17 12:54:26.440448+03	bireysel	4	\N
39	Turnuva9(4)	Valorant	2025-09-11	10000.00	Kazanana 10000TL	8	2025-05-17 12:54:59.234687+03	bireysel	4	\N
40	Turnuva10(4)	Valorant	2025-07-10	10000.00	Kazanana 10000TL	8	2025-05-17 12:55:09.971979+03	takım	4	\N
\.


--
-- TOC entry 4947 (class 0 OID 16391)
-- Dependencies: 218
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, username, full_name, email, phone_number, password_hash, gender, birth_date, role, fav_game) FROM stdin;
52	WhiteWizard	Saruman	saruman@gmail.com	(589) 635-4875	10	Erkek	1975-06-01 00:00:00+03	kullanici	League of Legends
8	Melkor	Halit Efe Bilgin	hebilgin27@gmail.com	(545) 397-9627	052527	Erkek	2004-10-27 18:00:00+03	admin	\N
41	cks	Cem Kerem Şahin	cks@gmail.com	(548) 789-9635	0	Erkek	2005-06-21 00:00:00+03	kullanici	League of Legends
42	Ümüt	Ümit Zengin	ümit@gmail.com	(548) 796-2358	1	Erkek	2005-02-14 00:00:00+02	kullanici	League of Legends
43	Closer	Ali Yılmaz	ali@gmail.com	(598) 756-9354	2	Erkek	1995-05-17 00:00:00+03	kullanici	CS:GO
44	StoneKiller	Mehmet Kaya	mehmet@gmail.com	(548) 789-6325	3	Erkek	2003-05-17 00:00:00+03	kullanici	Valorant
45	Galadriel	Zeynep Genç	zeynep@gmail.com	(563) 487-9635	4	Kadın	2006-10-01 00:00:00+03	kullanici	Valorant
46	Beheaded	Emir Han Kelleci	emirhan@gmail.com	(524) 789-6354	5	Erkek	2002-06-17 00:00:00+03	kullanici	CS:GO
47	TokmakHead	Tunç Güneri	tunç@gmail.com	(587) 963-5487	6	Erkek	1999-07-01 00:00:00+03	kullanici	CS:GO
48	ÇobanKomiser	Hüsnü Çoban	hüsnü@gmail.com	(589) 635-4785	7	Erkek	1980-06-01 00:00:00+03	kullanici	CS:GO
49	İskenderBüyük	İskender Büyük	iskender@gmail.com	(598) 753-2456	8	Erkek	1963-01-17 00:00:00+03	kullanici	CS:GO
51	GreyWizard	Gandalf	gandalf@gmail.com	(548) 963-5462	9	Erkek	1984-02-01 00:00:00+03	kullanici	League of Legends
\.


--
-- TOC entry 4966 (class 0 OID 0)
-- Dependencies: 226
-- Name: logs_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.logs_id_seq', 44, true);


--
-- TOC entry 4967 (class 0 OID 0)
-- Dependencies: 223
-- Name: participants_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.participants_id_seq', 70, true);


--
-- TOC entry 4968 (class 0 OID 0)
-- Dependencies: 221
-- Name: teams_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.teams_id_seq', 38, true);


--
-- TOC entry 4969 (class 0 OID 0)
-- Dependencies: 219
-- Name: tournaments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tournaments_id_seq', 40, true);


--
-- TOC entry 4970 (class 0 OID 0)
-- Dependencies: 217
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 52, true);


--
-- TOC entry 4792 (class 2606 OID 16589)
-- Name: logs logs_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.logs
    ADD CONSTRAINT logs_pkey PRIMARY KEY (id);


--
-- TOC entry 4788 (class 2606 OID 16440)
-- Name: participants participants_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.participants
    ADD CONSTRAINT participants_pkey PRIMARY KEY (id);


--
-- TOC entry 4786 (class 2606 OID 16428)
-- Name: teams teams_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teams
    ADD CONSTRAINT teams_pkey PRIMARY KEY (id);


--
-- TOC entry 4783 (class 2606 OID 16416)
-- Name: tournaments tournaments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments
    ADD CONSTRAINT tournaments_pkey PRIMARY KEY (id);


--
-- TOC entry 4790 (class 2606 OID 16457)
-- Name: participants unique_participation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.participants
    ADD CONSTRAINT unique_participation UNIQUE (user_id, tournament_id);


--
-- TOC entry 4780 (class 2606 OID 16397)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4781 (class 1259 OID 16558)
-- Name: fki_teamtournamet_fk; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_teamtournamet_fk ON public.tournaments USING btree (tid);


--
-- TOC entry 4784 (class 1259 OID 16552)
-- Name: fki_tourteam; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_tourteam ON public.teams USING btree (id);


--
-- TOC entry 4798 (class 2620 OID 16593)
-- Name: users trg_user_delete; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_user_delete AFTER DELETE ON public.users FOR EACH ROW EXECUTE FUNCTION public.log_user_delete();


--
-- TOC entry 4799 (class 2620 OID 16591)
-- Name: users trg_user_insert; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_user_insert AFTER INSERT ON public.users FOR EACH ROW EXECUTE FUNCTION public.log_user_insert();


--
-- TOC entry 4793 (class 2606 OID 16417)
-- Name: tournaments fk_organizer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tournaments
    ADD CONSTRAINT fk_organizer FOREIGN KEY (organizer_id) REFERENCES public.users(id);


--
-- TOC entry 4795 (class 2606 OID 16565)
-- Name: participants participants_team_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.participants
    ADD CONSTRAINT participants_team_id_fkey FOREIGN KEY (team_id) REFERENCES public.teams(id) ON DELETE CASCADE;


--
-- TOC entry 4796 (class 2606 OID 16487)
-- Name: participants participants_tournament_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.participants
    ADD CONSTRAINT participants_tournament_id_fkey FOREIGN KEY (tournament_id) REFERENCES public.tournaments(id) ON DELETE CASCADE;


--
-- TOC entry 4797 (class 2606 OID 16560)
-- Name: participants participants_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.participants
    ADD CONSTRAINT participants_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 4794 (class 2606 OID 16570)
-- Name: teams teams_captain_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.teams
    ADD CONSTRAINT teams_captain_id_fkey FOREIGN KEY (captain_id) REFERENCES public.users(id) ON DELETE CASCADE;


-- Completed on 2025-05-17 13:47:49

--
-- PostgreSQL database dump complete
--

