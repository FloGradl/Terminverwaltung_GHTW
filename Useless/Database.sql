DROP TABLE Unternehmen CASCADE CONSTRAINTS;
DROP TABLE Benutzer CASCADE CONSTRAINTS;
DROP TABLE Fahrzeuge CASCADE CONSTRAINTS;
DROP TABLE fährt CASCADE CONSTRAINTS;
DROP TABLE Gruppe CASCADE CONSTRAINTS;
DROP TABLE istIn CASCADE CONSTRAINTS;
DROP TABLE Termin CASCADE CONSTRAINTS;
DROP TABLE nimmtTerminTeil CASCADE CONSTRAINTS;

CREATE TABLE Unternehmen(
    unId INTEGER,
    bezeichnung VARCHAR2(50),
    
    CONSTRAINT pkUnternehmen PRIMARY KEY(unId)
);

CREATE TABLE Benutzer(
    bId INTEGER,
    bname VARCHAR2(50),
    email VARCHAR2(50),
    passwort VARCHAR2(50),
    telnr VARCHAR2(50),
    plz INTEGER,
    ort VARCHAR2(50),
    straße VARCHAR2(50),
    utId INTEGER,
    isGroupAdmin INTEGER,
	isSuperAdmin INTEGER,
    
    CONSTRAINT pkBenutzer PRIMARY KEY(bId),
    CONSTRAINT fkBenutzerUnternehmen FOREIGN KEY(utId) REFERENCES Unternehmen(unId)
);

CREATE TABLE Fahrzeuge(
	fid INTEGER,
    nummerntafel VARCHAR2(50),
    bezeichnung VARCHAR2(50),
    fahrUid INTEGER,
    fposition SDO_GEOMETRY,
    
    CONSTRAINT pkFahrzeuge PRIMARY KEY(fid),
    CONSTRAINT fkUnternehFahrz FOREIGN KEY(fahrUid) REFERENCES Unternehmen(unId)
);

CREATE TABLE fährt(
	faehrtId INTEGER,
    fahrzeugId INTEGER,
    benutzerId INTEGER,
    kilometer INTEGER,
	terminfId INTEGER,
    abfahrtsort SDO_GEOMETRY,
    zielort SDO_GEOMETRY,
    
    CONSTRAINT pkFährt PRIMARY KEY(faehrtId),
	CONSTRAINT fkFährtFahrzeug FOREIGN KEY(fahrzeugId) REFERENCES Fahrzeuge(fid),
	CONSTRAINT fkBenutzerfährt FOREIGN KEY(benutzerId) REFERENCES Benutzer(bId)
);

CREATE TABLE Gruppe(
    gId INTEGER,
    bezeichnung VARCHAR2(50),
    
    CONSTRAINT pkGruppe PRIMARY KEY(gId)
);

CREATE TABLE istIn(
    gruppenId INTEGER,
    benutzerId INTEGER,
    
    CONSTRAINT pkIstIn PRIMARY KEY(gruppenId, benutzerId),
	CONSTRAINT fkGruppeIstIn FOREIGN KEY(gruppenId) REFERENCES Gruppe(gId),
	CONSTRAINT fkBenutzeristIn FOREIGN KEY(benutzerId) REFERENCES Benutzer(bId)
);

CREATE TABLE Termin(
	terminId INTEGER,
	datum DATE,
	ort VARCHAR2(50),
	thema VARCHAR2(50),
	beschreibung VARCHAR2(50),
	
	CONSTRAINT pkTermin PRIMARY KEY(terminId)
);

CREATE TABLE nimmtTerminTeil(
	nimmtTerminId INTEGER,
	nimmtBenutzerId INTEGER,
	
	CONSTRAINT pknimmtTerminTeil PRIMARY KEY(nimmtTerminId, nimmtBenutzerId),
	CONSTRAINT fknimmtTerminteil FOREIGN KEY(nimmtTerminId) REFERENCES Termin(terminId),
	CONSTRAINT fknimmtBenutzerteil FOREIGN KEY(nimmtBenutzerId) REFERENCES Benutzer(bId)
);

CREATE SEQUENCE  "D5B07"."SEQ_UNTERNEHMEN_ID"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "D5B07"."SEQ_FAHRZEUGE_ID"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "D5B07"."SEQ_TERMIN_ID"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "D5B07"."SEQ_BENUTZER_ID"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "D5B07"."SEQ_GRUPPE_ID"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;
CREATE SEQUENCE  "D5B07"."SEQ_FÄHRT"  MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 NOORDER  NOCYCLE ;

INSERT INTO Unternehmen VALUES(SEQ_UNTERNEHMEN_ID.NEXTVAL,'GHTW Performance');
INSERT INTO Unternehmen VALUES(SEQ_UNTERNEHMEN_ID.NEXTVAL,'3M');
INSERT INTO Unternehmen VALUES(SEQ_UNTERNEHMEN_ID.NEXTVAL,'CaseKingz');
INSERT INTO Unternehmen VALUES(SEQ_UNTERNEHMEN_ID.NEXTVAL,'Verlust GmbH');
INSERT INTO Unternehmen VALUES(SEQ_UNTERNEHMEN_ID.NEXTVAL,'Martinez GmbH');

INSERT INTO Termin VALUES(1,TO_DATE('17/12/2015', 'DD/MM/YYYY'),'Villach','Reperatur','Teil repariert');
INSERT INTO Termin VALUES(SEQ_TERMIN_ID.NEXTVAL,TO_DATE('24/04/2016', 'DD/MM/YYYY'),'Klagenfurt','Kundengespräch','Werbung');
INSERT INTO Termin VALUES(SEQ_TERMIN_ID.NEXTVAL,TO_DATE('12/09/2017', 'DD/MM/YYYY'),'Oberdrauburg','Montage','Tisch montiert');
INSERT INTO Termin VALUES(SEQ_TERMIN_ID.NEXTVAL,TO_DATE('02/03/2014', 'DD/MM/YYYY'),'Hermagor','Montage','Wandregal montiert');
INSERT INTO Termin VALUES(SEQ_TERMIN_ID.NEXTVAL,TO_DATE('08/04/2016', 'DD/MM/YYYY'),'Velden','Reparatur','Reparatur vor Ort');
INSERT INTO Termin VALUES(SEQ_TERMIN_ID.NEXTVAL,TO_DATE('03/01/2017', 'DD/MM/YYYY'),'Finkenstein','Kundengespräch','Plannung der Küche');
INSERT INTO Termin VALUES(SEQ_TERMIN_ID.NEXTVAL,TO_DATE('19/11/2017', 'DD/MM/YYYY'),'Arnoldstein','Kundengespräch','Plannung des Schrankes');

INSERT INTO Benutzer VALUES(1,'Superadmin', 'admin@ghtw.com','admin','066006600660','9500','Villach','Tschinowitscherweg 12',2,0,1);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Groupadmin', 'admin@ghtw.com','admin','066006600660','9500','Villach','Tschinowitscherweg 12',2,1,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Markus Pschernig', 'pschernig@gmail.com','pschernig','0650987653','9500','Villach','Musterstraße 22',5,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Josef Huber', 'huber@gmx.com','huber','0660987532','9020','Klagenfurt','Udinestraße 1',5,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Elrike Igel', 'igel@yahoo.com','igel','0676123889','9500','Villach','Klagenfurtstraße 22',5,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Adolf Gasser', 'gasser@live.at','gasser','0650876322','9500','Villach','Zauberstraße 2',3,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Heidrun Weber', 'weber@gmail.com','weber','06503321555','9500','Villach','Judendorfstraße 1',3,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Christoph Huber', 'huber@gmail.com','huber','066031666443','9020','Klagenfurt','Musterstraße 5',2,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Fritz Lorenz', 'lorenz@gmail.com','lorenz','065087224','9500','Villach','Nagelstraße 22',6,0,0);
INSERT INTO Benutzer VALUES(SEQ_BENUTZER_ID.NEXTVAL,'Martinez Estagoros', 'estagoros@gmail.com','estagoros','066032553122','9020','Klagenfurt','Erfundenestraße 1',6,0,0);

INSERT INTO Fahrzeuge VALUES(1,'VI111AU','BMW','2',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.601719, 13.843180, null),
     null, 
     null 
  ));

INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'VI233EB','Audi','2',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.601719, 13.843180, null),
     null, 
     null 
  ));
  
  INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'K56IE','Mercedes','5',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.641068, 14.282197, null),
     null, 
     null 
  ));
  
   INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'K983UE','Toyota','5',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.641068, 14.282197, null),
     null, 
     null 
  ));
  
  INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'SP786WQ','Audi','6',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.822381, 13.516850, null),
     null, 
     null 
  ));
  INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'SP987TR','Audi','6',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.822381, 13.516850, null),
     null, 
     null 
  ));
  
    INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'VI212UZ','BMW','4',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.629164, 13.851524, null),
     null, 
     null 
  ));
  
INSERT INTO Fahrzeuge VALUES(SEQ_FAHRZEUGE_ID.NEXTVAL,'VI908ER','BMW','4',SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.629164, 13.851524, null),
     null, 
     null 
));

INSERT INTO Gruppe VALUES(1,'Gruppe 1');
INSERT INTO Gruppe VALUES(SEQ_GRUPPE_ID.NEXTVAL,'Gruppe 2');
INSERT INTO Gruppe VALUES(SEQ_GRUPPE_ID.NEXTVAL,'Gruppe 3');
INSERT INTO Gruppe VALUES(SEQ_GRUPPE_ID.NEXTVAL,'Gruppe 4');
INSERT INTO Gruppe VALUES(SEQ_GRUPPE_ID.NEXTVAL,'Gruppe 5');

INSERT INTO fährt VALUES(1,1,3,112987,1,SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.601719, 13.843180, null),
     null, 
     null 
  ),SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.614022, 13.831426, null),
     null, 
     null 
));

INSERT INTO fährt VALUES(SEQ_FÄHRT.NEXTVAL,11,5,98,1,SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.601719, 13.843180, null),
     null, 
     null 
  ),SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.629409, 13.873384, null),
     null, 
     null 
));

INSERT INTO fährt VALUES(SEQ_FÄHRT.NEXTVAL,14,8,22,3,SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.822381, 13.516850, null),
     null, 
     null 
  ),SDO_GEOMETRY( 
     2001,
     8307, 
     SDO_POINT_TYPE(46.822358, 13.523871, null),
     null, 
     null 
));

INSERT INTO istin VALUES(1,1);
INSERT INTO istin VALUES(2,2);
INSERT INTO istin VALUES(3,3);
INSERT INTO istin VALUES(3,4);
INSERT INTO istin VALUES(4,5);
INSERT INTO istin VALUES(5,6);
INSERT INTO istin VALUES(1,7);

INSERT INTO nimmtterminteil VALUES(1,1);
INSERT INTO nimmtterminteil VALUES(2,4);
INSERT INTO nimmtterminteil VALUES(2,5);
INSERT INTO nimmtterminteil VALUES(3,6);
INSERT INTO nimmtterminteil VALUES(4,3);
INSERT INTO nimmtterminteil VALUES(5,9);
INSERT INTO nimmtterminteil VALUES(6,8);
INSERT INTO nimmtterminteil VALUES(7,7);

select bname,datum,thema,beschreibung from benutzer JOIN nimmtterminteil ON benutzer.bid = nimmtterminteil.nimmtbenutzerid JOIN termin ON termin.terminid = nimmtterminteil.nimmtterminid;



