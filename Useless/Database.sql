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
