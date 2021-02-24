SET IDENTITY_INSERT [Category] ON;
INSERT INTO [Category] (Id_Category, Name)
 VALUES (1, 'Triple'),
		(2, 'Spécial'),
		(3, 'Trapiste'),
		(4, 'Stout'),
		(5, 'Pils'),
		(6, 'Abbaye'),
		(7, 'Fruité'),
		(8, 'Blanche'),
		(9, 'Pale lager');
SET IDENTITY_INSERT [Category] OFF;

SET IDENTITY_INSERT [Brewery] ON;
INSERT INTO [Brewery] (Id_Brewery, Name, Headquarter, Country)
 VALUES (1, 'AB InBev', 'Louvain', 'Belgique'),
		(2, 'Abbaye Notre-Dame de Scourmont', 'Chimay', 'Belgique'),
		(3, 'Novabirra', NULL, 'Belgique'),
		(4, 'Brussels Beer Project', 'Bruxelles', 'Belgique'),
		(5, 'Heineken', 'Amsterdam', 'Pays-Bas');
SET IDENTITY_INSERT [Brewery] OFF;

SET IDENTITY_INSERT [Brand] ON;
INSERT INTO [Brand] (Id_Brand, Name, Country, Creation_Year)
 VALUES (1, 'Tripel Karmeliet', 'Belgique', 1996),
		(2, 'Chimay', 'Belgique', 1862),
	    (3, 'Jupiler', 'Belgique', 1966),
		(4, 'Leffe', 'Belgique', 1952),
		(5, 'Hoegaarden', 'Belgique', 1966),
		(6, 'Corona Extra', 'Mexique', 1925), 
		(7, 'Brussels Beer Project', 'Belgique', 2013);
SET IDENTITY_INSERT [Brand] OFF;

SET IDENTITY_INSERT [Beer] ON;
INSERT INTO [Beer] (Id_Beer, Name, Degree, Color, Id_Brewery, Id_Brand)
 VALUES (1, 'Triple karmeliet', 8.4, 'Blonde', 1, 1),
	    (2, 'Chimay Bleue', 9, 'Brune', 2, 2),
		(3, 'Big Mama', 8, 'Noire', 3, NULL),
		(4, 'Delta IPA', 6.5, 'Ambrée', 4, 7),
		(5, 'Jupiler', 5.2, 'Blonde', 1, 3),
		(6, 'Leffe Ruby', 5, 'Rouge', 1, 4),
		(7, 'Hoegaarden', 4.9, 'Blanche', 1, 5),
		(8, 'Jupiler 0,0 %', 0, 'Blonde', 1, 3),
		(9, 'Heineken', 5, 'Blonde', 5, NULL),
		(10, 'Chimay Rouge', 7, 'Brune', 2, 2),
		(11, 'Leffe Brune', 6.5, 'Brune', 1, 4),
		(12, 'Grosse Bertha', 7, 'Blonde', 4, 7),
		(13, 'Jungle Joy', 5.9, 'Blonde', 4, 7),
		(14, 'Leffe Triple', 8.5, 'Blonde', 1, 4),
		(15, 'Corona Extra', 4.6, 'Blonde', 1, 6),
		(16, 'Hoegaarden Rosée', 3, 'Blanche', 1, 5);
SET IDENTITY_INSERT [Beer] OFF;


INSERT INTO [BeerCategory] (Id_Beer, Id_Category)
 VALUES (1, 1),
	    (1, 2),
		(2, 3),
		(3, 4),
		(5, 5),
		(6, 6),
		(6, 7),
		(7, 8),
		(8, 5),
		(9, 5),
		(10, 3),
		(11, 6),
		(14, 1),
		(14, 6),
		(15, 9),
		(16, 8),
		(16, 7);