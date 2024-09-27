CREATE TABLE Utente(
	utenteID INT PRIMARY KEY IDENTITY(1,1),
	codiceUtente VARCHAR(250) NOT NULL DEFAULT NEWID(),
	nome VARCHAR(50) NOT NULL,
	cognome VARCHAR(50) NOT NULL,
	email VARCHAR(250) NOT NULL UNIQUE
);

CREATE TABLE Libro(
	libroID INT PRIMARY KEY IDENTITY(1,1),
	codiceLibro VARCHAR(250) NOT NULL DEFAULT NEWID(),
	titolo VARCHAR(250) NOT NULL,
	anno_pubblicazione CHAR(4) NOT NULL,
	isDisponibile BIT DEFAULT 1
);


CREATE TABLE Prestito(
	prestitoID INT PRIMARY KEY IDENTITY(1,1),
	codicePrestito VARCHAR(250) NOT NULL DEFAULT NEWID(),
	data_inizio DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
	data_fine DATETIME,
	CONSTRAINT checkDate CHECK(data_fine > data_inizio),
	utenteRIF INT,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID) ON DELETE CASCADE,
	libroRIF INT,
	FOREIGN KEY (libroRIF) REFERENCES Libro(libroID) ON DELETE CASCADE	
);

INSERT INTO UTENTE (nome, cognome, email) VALUES 
	('Marco', 'Rossi', 'marco.rossi@example.com'),
	('Giulia', 'Bianchi', 'giulia.bianchi@example.com'),
	('Luca', 'Esposito', 'luca.esposito@example.com'),
	('Sofia', 'Conti', 'sofia.conti@example.com'),
	('Francesco', 'De Luca', 'francesco.deluca@example.com'),
	('Chiara', 'Romano', 'chiara.romano@example.com'),
	('Alessandro', 'Greco', 'alessandro.greco@example.com'),
	('Martina', 'Ferrari', 'martina.ferrari@example.com'),
	('Davide', 'Costa', 'davide.costa@example.com'),
	('Alice', 'Marino', 'alice.marino@example.com');

INSERT INTO LIBRO (titolo, anno_pubblicazione, isDisponibile) VALUES
	('Il Signore degli Anelli', '1954', 1),
	('1984', '1949', 1),
	('Orgoglio e Pregiudizio', '1813', 1),
	('Il Grande Gatsby', '1925', 0),
	('Harry Potter', '1997', 1),
	('Cime Tempestose', '1847', 0),
	('Moby Dick', '1851', 1),
	('Guerra e Pace', '1869', 1),
	('Amleto', '1603', 1),
	('La Divina Commedia', '1320', 0);

INSERT INTO PRESTITO (utenteRIF, libroRIF, data_inizio, data_fine) VALUES 
    (1, 1, '01-11-2023 10:00:00', '01-12-2023 10:00:00'),
    (2, 2, '10-12-2023 11:00:00', '10-01-2024 11:00:00'),
    (3, 3, '15-10-2023 09:30:00', '15-11-2023 09:30:00'),
    (4, 4, '15-11-2023 08:30:00', '20-11-2023 10:00:00'),
    (5, 5, '25-11-2023 14:45:00', '25-12-2023 14:45:00'),
    (6, 6, '02-01-2024 13:20:00', '02-02-2024 13:20:00'),
    (7, 7, '20-10-2023 08:15:00', '20-11-2023 08:15:00'),
    (8, 8, '12-10-2023 16:00:00', '18-10-2023 20:00:00'),
    (9, 9, '25-12-2023 12:00:00', '25-01-2024 12:00:00'),
    (10, 10, '30-11-2023 16:50:00', '31-12-2023 16:50:00'), 
    (1, 2, '05-11-2023 09:00:00', '05-12-2023 09:00:00'),
    (2, 3, '15-12-2023 14:30:00', '15-01-2024 14:30:00'),
    (3, 4, '20-10-2023 12:00:00', '20-11-2023 12:00:00'),
    (4, 5, '10-01-2024 11:15:00', '10-02-2024 11:15:00'),
    (5, 6, '25-11-2023 15:45:00', '25-12-2023 15:45:00'),
    (6, 7, '03-12-2023 09:20:00', '03-01-2024 09:20:00'),
    (7, 8, '12-10-2023 16:00:00', '12-11-2023 16:00:00'),
    (8, 9, '28-12-2023 10:40:00', '29-12-2023 11:00:00'),
    (9, 10, '28-12-2023 10:40:00', '28-01-2024 10:40:00'),
    (10, 1, '30-11-2023 13:10:00', '31-12-2023 13:10:00');


SELECT * FROM UTENTE;
SELECT * FROM LIBRO;
SELECT * FROM Prestito;