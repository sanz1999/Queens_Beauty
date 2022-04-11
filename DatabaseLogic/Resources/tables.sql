﻿DROP TABLE sia CASCADE CONSTRAINTS;
DROP TABLE service CASCADE CONSTRAINTS;
DROP TABLE customer CASCADE CONSTRAINTS;
DROP TABLE worker CASCADE CONSTRAINTS;
DROP TABLE appointment CASCADE CONSTRAINTS;

CREATE TABLE service(
	sid				NUMBER GENERATED BY DEFAULT AS IDENTITY,
	sname			VARCHAR2(255 CHAR) NOT NULL,
	scat			VARCHAR2(255 CHAR),
	sdur			INT NOT NULL,
	spri			DECIMAL(38, 3) NOT NULL,
	sprip			INT,
	sp				INT,
	CONSTRAINT service_pk PRIMARY KEY ( sid ),
    CONSTRAINT service_dur_ch CHECK (sdur >= 0),
    CONSTRAINT service_price_ch CHECK (spri >= 0),
    CONSTRAINT service_pricep_ch CHECK (sprip >= 0),
    CONSTRAINT service_sp_ch CHECK (sp >= 0)
);

CREATE TABLE customer(
	cid				NUMBER GENERATED BY DEFAULT AS IDENTITY,
	cname			VARCHAR2(255 CHAR) NOT NULL,
	csname			VARCHAR2(255 CHAR) NOT NULL,
	cnum			VARCHAR2(255 CHAR) DEFAULT '',
	cmail			VARCHAR2(255 CHAR) DEFAULT '',
	csex			CHAR(1) DEFAULT 'N',
	cp				INT DEFAULT 0,
	cloyal			INT,
	CONSTRAINT customer_pk PRIMARY KEY ( cid ),	
	CONSTRAINT customer_uk UNIQUE (cloyal),
    CONSTRAINT customer_cp_ch CHECK (cp >= 0)
);

CREATE TABLE worker(
	wid				NUMBER GENERATED BY DEFAULT AS IDENTITY,
	wname			VARCHAR2(255 CHAR) NOT NULL,
	CONSTRAINT worker_pk PRIMARY KEY ( wid )	
);

CREATE TABLE appointment(
	aid				NUMBER GENERATED BY DEFAULT AS IDENTITY,
	cid				INT NOT NULL,
	atime			TIMESTAMP(0) NOT NULL,
	aprice			DECIMAL(38, 3),
	astate			NUMBER(1) DEFAULT 0,
	CONSTRAINT appointment_pk PRIMARY KEY (aid),
    CONSTRAINT appointment_fk FOREIGN KEY (cid) REFERENCES customer(cid),
    CONSTRAINT appointment_ch CHECK (astate IN (0, 1)) ,
    CONSTRAINT appointment_price_ch CHECK (aprice >= 0)
);

CREATE TABLE sia(
	aid				INT NOT NULL,
	sid				INT NOT NULL,
	wid				INT NOT NULL,
	CONSTRAINT sia_pk PRIMARY KEY (aid, sid ),
    CONSTRAINT sia_appointment_fk FOREIGN KEY (aid) REFERENCES appointment(aid),
	CONSTRAINT sia_service_fk FOREIGN KEY (sid) REFERENCES service(sid),
	CONSTRAINT sia_worker_fk FOREIGN KEY (wid) REFERENCES worker(wid)
);