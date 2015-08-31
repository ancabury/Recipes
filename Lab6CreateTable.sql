CREATE TABLE Categorii 
	(codC int PRIMARY KEY, 
	 numeC varchar(30)
	 )

CREATE TABLE Preparate 
	(codP int PRIMARY KEY IDENTITY(1,1), 
	 codC int REFERENCES Categorii(codC), 
	 numeP varchar(20), 
	 pret float, 
	 timp_preparare int
	 )

CREATE TABLE Ingrediente
	(codI int PRIMARY KEY IDENTITY(1,1),
	 numeI varchar(30),
	 unitate_masura varchar(20)
	 )

CREATE TABLE Retete
	(codP int REFERENCES Preparate(codP) ON DELETE CASCADE,	
	 codI int REFERENCES Ingrediente(codI),
	 cantitate float,
	 CONSTRAINT codR PRIMARY KEY (codP, codI)
	 )

drop table Retete
drop table Ingrediente
drop table Preparate
drop table Categorii