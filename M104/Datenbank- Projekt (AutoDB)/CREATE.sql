USE carFinderDB
-- Create Table Kategorie
CREATE Table Kategorie ( 
KategorieID int NOT NULL identity(1,1) PRIMARY KEY,
Art varchar(50)
);

-- Create Table Marke
CREATE Table Marke(
MarkeID int NOT NULL identity(1,1) PRIMARY KEY,
Markenname varchar(50)
);

create table LeistungInPS(
LeistungID int NOT NULL identity(1,1) PRIMARY KEY,
Leistung varchar(20)
);

-- Create Table Autos
CREATE Table Autos(
AutoID int  NOT NULL identity(1,1) PRIMARY KEY,
Bezeichnung varchar(50),
PreisCHF decimal,
Farbe varchar(50),
FK_LeistungID int  NOT NULL FOREIGN KEY REFERENCES LeistungInPS(LeistungID),
FK_KategorieID int  NOT NULL FOREIGN KEY REFERENCES Kategorie(KategorieID),
FK_MarkeID int  NOT NULL FOREIGN KEY REFERENCES Marke(MarkeID)
);





