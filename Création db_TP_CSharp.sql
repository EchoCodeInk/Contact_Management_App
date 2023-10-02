USE db_TP_CSharp


DROP TABLE IF EXISTS Contacts
GO
DROP TABLE IF EXISTS Members
GO

CREATE TABLE Members(
	id INT PRIMARY KEY CLUSTERED IDENTITY (1,1),
	utilisateur VARCHAR (30) UNIQUE NOT NULL,
	password VARCHAR (30) NOT NULL
    )

	INSERT Members (utilisateur, password) VALUES ( 'evan', 'evan')
	INSERT Members (utilisateur, password) VALUES ( 'taoufik', 'taoufik')

CREATE TABLE Contacts(
	id INT PRIMARY KEY CLUSTERED IDENTITY (1,1),
	prenom VARCHAR(25)NOT NULL,
	nom VARCHAR(25)NOT NULL,
	adresse VARCHAR(30)NULL,
	ville VARCHAR(30)NOT NULL,
	code_postal VARCHAR(30)NULL,
	cell_phone VARCHAR(14) NULL CHECK (cell_phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
	mail VARCHAR(100)  NULL,
	member_utilisateur VARCHAR (30) FOREIGN KEY REFERENCES Members(utilisateur)NULL
	)

	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Evan', 'Cholette','280 Viau','Châteauguay','J6k2M7','(514)778-8120','e_cholette@hotmail.com','evan')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Taoufik','Boussemousse','2495 Rue Jean-Talon E','Montréal','H2E 1W3','(579)372-5166','boussemoussetaoufik@gmail.com','taoufik')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'William','Fossi Ngambu','3358 chemin Hudson','Montréal','H4J 1M9','(514)805-0213','2210054@isi-montreal.com','evan')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Sara','Salek','2252 rue Levy','Montréal','H3C 5K4','(514)603-7875','2130084@isi-montreal.com','taoufik')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Khadija','Elaogdi','109  René-Lévesque Blvd','Montréal','H3B 4W8','(514)583-3397','2220023@isi-montreal.com','evan')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Montassa', 'Boukhari','538 Saint-Denis Street','Montréal','H9R 3J4','(514)694-8290','2130091@isi-montreal.com','taoufik')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Arona', 'Papa Diop','3827  Ste. Catherine Ouest','Montréal','H3B 4W5','(514)788-9801','2220108@isi-montreal.com','evan')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Ho', 'CongTai','2432  Sherbrooke Ouest','Montréal','H4A 1H3','(514)248-5572','2130077@isi-montreal.com','taoufik')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Arnold', 'Kokouvi Biova Adadjisso','3502  rue de la Gauchetière','Montréal','H3B 2M3','(514)823-8855','2220025@isi-montreal.com','evan')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Samuel', 'Milord','4070  chemin Georges','Laval','J0K 1H0','(450)547-0319','2210084@isi-montreal.com','taoufik')
	INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Saliou', 'Thiongane','775  rue Ontario Ouest','Montréal','H2X 1Y8','(514)840-6128','2220107@isi-montreal.com','evan')
    INSERT Contacts (prenom, nom, adresse, ville, code_postal,cell_phone, mail, member_utilisateur) VALUES ( 'Antoine','Zacharie Ouellet','2683 rue Saint-Charles','Longueuil','J4H 1M3','(439)398-9392','2220101@isi-montreal.com','taoufik')
	
