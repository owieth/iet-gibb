USE carFinderDB
INSERT INTO Kategorie(Art)
VALUES ('Sportwagen'), ('Kombi'), ('SUV'), ('Limousine');
SELECT * FROM Autos;
SELECT * FROM Marke;
SELECT * FROM Kategorie;
SELECT * FROM LeistungInPS;
delete from Marke where MarkeID between 10 and 27;
DELETE FROM LeistungInPS where LeistungID < 9;

INSERT INTO Marke(Markenname)
VALUES ('BMW'), ('Mercedes Benz'), ('Porsche'), ('Audi'), ('Ferrari'), ('Lamborghini'), ('McLaren'), ('Rolls Royce'), ('Bentley');

insert into LeistungInPS(Leistung)
values ('750PS'), ('630PS'), ('600PS'), ('180PS'); 

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('X3', '56900', 'Blau', '4', '3', '1');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('C220D', '53200', 'Schwarz', '4', '4', '2');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Cayenne Turbo', '183900', 'Weiss', '3', '3', '3');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('RS6 Avant Performance', '144600', 'Rot', '3', '2', '4');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('488 Pista', '285000', 'Ferrari Rot', '1', '1', '5');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Aventador Superveloce', '599000', 'Gelb', '1', '1', '6');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Senna', '922000', 'Orange', '1', '1', '7');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Ghost', '325000', 'Gold', '2', '4', '8');		 

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Continental GT 2018', '204000', 'Grau', '2', '4', '9');

<!-- Weiter Autos voms Oli-->
INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('M3 Limousine CS', '110000', 'Blau', '450PS', '4', '1');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('AMG GLS 63', '200000', 'Schwarz', '3', '3', '2');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Panamera Sport Turismo', '200000', 'Weiss', '3', '2', '3');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('SQ7 TDI', '110000', 'Gelb', '450PS', '3', '4');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('812 Superfast', '280000', 'Ferrari Rot', '1', '1', '5');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Huracan Performante', '230000', 'Orange', '2', '2', '6');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('720s', '250000', 'Weiss', '1', '1', '7');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Cullinan', '350000', 'Grün', '2', '3', '8');

INSERT INTO Autos(Bezeichnung, PreisCHF, Farbe, FK_LeistungID, FK_KategorieID, FK_MarkeID)
VALUES ('Continental Supersports', '250000', 'Blau', '1', '1', '9');
