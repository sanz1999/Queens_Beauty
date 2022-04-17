insert into service (sid, sname, scat, sdur, spri, sprip, sp) values (1, 'Feniranje', 'KoŠa', 120, 15.4, 100, 5);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('Pranje', 'KoŠa', 35, 02.222, 50, 2);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('Lakiranje', 'Nokti', 600, 10.02, 20, 3);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('Sisanje', 'Muska Frizura', 10, 400, 500, 6);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('Sisanje', 'Zenska Frizura', 180, 210, 12, 20);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('Farbanje', 'Papaka', 35, 6.9, 52, 33);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('HaosBato', 'Znaci', 20, 32, 42, 20);
insert into service (sname, scat, sdur, spri, sprip, sp) values ('Koja', 'Kojic', 40, 5.5, 10000, 10);

insert into customer (cid, cname, csname, cdob, cnum, cmail, csex, cp, cloyal) values (1, 'Sasa', 'Kitic',TO_DATE('23-MAR-1999', 'DD-MON-YYYY'), '(+361)63 1234 12', 'sasak@yahoo.com', 'M', 420, 555555);

insert into worker (wid, wname) values (1, 'Pacenik');


insert into appointment (aid, cid, atime, aprice, astate) values (1, 1, TO_DATE('16:30 12-JAN-2022', 'HH24:MI DD-MON-YYYY', 'NLS_DATE_LANGUAGE=AMERICAN'), 14.69, 1);


insert into sia(aid, sid, wid) values (1, 1, 1);