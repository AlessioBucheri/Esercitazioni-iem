
CREATE TABLE Membro(
	membroID INT PRIMARY KEY IDENTITY(1,1),
	codice_abbonamento INT NOT NULL UNIQUE,
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	data_di_nascita DATE NOT NULL,
	sesso VARCHAR(5) CHECK(sesso IN ('Uomo', 'Donna', 'Altro')),
	email VARCHAR(250) NOT NULL UNIQUE,
	tipo_abbonamento VARCHAR(250) NOT NULL CHECK (tipo_abbonamento IN ('Mensile', 'Trimestrale', 'Annuale')),
	telefono VARCHAR(15) NOT NULL,
	data_di_iscrizione DATE DEFAULT CURRENT_TIMESTAMP
);

/*
CREATE TABLE Abbonamento(
	abbonamentoID INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR(11) NOT NULL CHECK (tipo IN ('Mensile', 'Trimestrale', 'Annuale')),
	prez DECIMAL NOT NULL,
	membroRIF INT NOT NULL,
	FOREIGN KEY (membroRIF) REFERENCES Membro(membroID)
);
*/

CREATE TABLE Istruttore(
	istruttoreID INT PRIMARY KEY IDENTITY(1,1),
	identificativo INT NOT NULL UNIQUE,
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	specializzazione VARCHAR(250) NOT NULL CHECK (specializzazione IN ('Insegnante di Yoga', 'Istruttore di Spinning', 'Istruttore di Pilates', 'Istruttore di Sollevamento Pesi')),
	orario_di_lavoro VARCHAR(250) NOT NULL CHECK (orario_di_lavoro IN ('09:00-17:00', '12:00-20:00', '13:00-23:00'))
); 

CREATE TABLE Classe(
	classeID INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('Yoga', 'Spinning', 'Pilates', 'Sollevamento Pesi')),
	nome VARCHAR(100) NOT NULL,
	descrizione TEXT,
	orario VARCHAR(250) NOT NULL CHECK (orario IN ('9:00-10:30', '10:30-12:00', '12:00-13:30', '15:00-16:30', '16:30-18:00', '18:00-19:30','19:30-21:00')),
	giorno_settimanale VARCHAR(250) NOT NULL CHECK (giorno_settimanale IN ('Lunedì', 'Martedì', 'Mercoledì', 'Giovedì', 'Venerdì', 'Sabato', 'Domenica')),
	numero_massimo_partecipanti INT NOT NULL,
	istruttoreRIF INT NOT NULL,
	FOREIGN KEY (istruttoreRIF) REFERENCES Istruttore(istruttoreID),
); 

CREATE TABLE Prenotazione(
	prenotazioneID INT PRIMARY KEY IDENTITY(1,1),
	numero_prenotazione INT NOT NULL,
	data_preotazione DATETIME DEFAULT CURRENT_TIMESTAMP,
	canc BIT NOT NULL DEFAULT 0,
	membroRIF INT NOT NULL,
	classeRIF INT NOT NULL, 
	FOREIGN KEY (membroRIF) REFERENCES Membro(membroID),
	FOREIGN KEY (classeRIF) REFERENCES Classe(classeID)
);

CREATE TABLE Attrezzatura(
	attrezzaturaID INT PRIMARY KEY IDENTITY(1,1),
	tipo VARCHAR(100) NOT NULL CHECK (tipo IN ('Tapis Roulant', 'Bici da Spinning', 'Pesi liberi')),
	descrizione TEXT,
	data_di_acquisto DATE NOT NULL,
	stato VARCHAR(15) NOT NULL CHECK (stato IN ('Disponibile', 'Manutenzione', 'Fuori Servizio')),
	istruttoreRIF INT NOT NULL,
	FOREIGN KEY (istruttoreRIF) REFERENCES Istruttore(istruttoreID) ON DELETE CASCADE
);

-- -----------------------------------INSERIMENTI IN DATABASE----------------------------------------------------------------

-- INSERIMENTO MEMBRI
INSERT INTO Membro (codice_abbonamento, nome, cognome, data_di_nascita, sesso, email, telefono, tipo_abbonamento) VALUES
	(101, 'Mario', 'Rossi', '1990-05-12', 'Uomo', 'mario.rossi@example.com', '3456781234','Mensile'),
	(102, 'Luca', 'Bianchi', '1985-03-30', 'Uomo', 'luca.bianchi@example.com', '3476782345','Annuale'),
	(103, 'Giulia', 'Verdi', '1992-08-15', 'Donna', 'giulia.verdi@example.com', '3486783456','Annuale'),
	(104, 'Laura', 'Neri', '1988-12-20', 'Donna', 'laura.neri@example.com', '3496784567','Trimestrale'),
	(105, 'Paolo', 'Gialli', '1995-07-25', 'Uomo', 'paolo.gialli@example.com', '3506785678','Mensile'),
	(106, 'Federica', 'Rossi', '1993-10-10', 'Donna', 'federica.rossi@example.com', '3516786789','Mensile'),
	(107, 'Sara', 'Bianco', '1989-11-22', 'Donna', 'sara.bianco@example.com', '3526787890','Mensile'),
	(108, 'Giovanni', 'Ferrari', '1991-04-18', 'Uomo', 'giovanni.ferrari@example.com', '3536788901','Mensile'),
	(109, 'Elena', 'Marino', '1994-06-05', 'Donna', 'elena.marino@example.com', '3546789012','Trimestrale'),
	(110, 'Matteo', 'Ricci', '1987-09-09', 'Uomo', 'matteo.ricci@example.com', '3556780123','Mensile'),
	(111, 'Carlo', 'Ruggeri', '1986-01-15', 'Uomo', 'carlo.ruggeri@example.com', '3566781234','Annuale'),
	(112, 'Simone', 'Costa', '1990-11-12', 'Uomo', 'simone.costa@example.com', '3576782345','Annuale'),
	(113, 'Claudia', 'Rinaldi', '1995-02-08', 'Donna', 'claudia.rinaldi@example.com', '3586783456','Mensile'),
	(114, 'Alessia', 'Romano', '1987-09-24', 'Donna', 'alessia.romano@example.com', '3596784567','Trimestrale'),
	(115, 'Andrea', 'Leone', '1993-05-17', 'Uomo', 'andrea.leone@example.com', '3606785678','Trimestrale'),
	(116, 'Roberta', 'Fabbri', '1989-04-03', 'Donna', 'roberta.fabbri@example.com', '3616786789','Mensile'),
	(117, 'Francesco', 'Serra', '1991-10-29', 'Uomo', 'francesco.serra@example.com', '3626787890','Mensile'),
	(118, 'Sabrina', 'Conti', '1992-07-14', 'Donna', 'sabrina.conti@example.com', '3636788901','Mensile'),
	(119, 'Marco', 'Sartori', '1988-03-21', 'Uomo', 'marco.sartori@example.com', '3646789012','Trimestrale'),
	(120, 'Veronica', 'Galli', '1994-12-05', 'Donna', 'veronica.galli@example.com', '3656780123','Annuale');
INSERT INTO Membro (codice_abbonamento, nome, cognome, data_di_nascita, sesso, email, telefono, tipo_abbonamento, data_di_iscrizione) VALUES
	(122, 'Ajeje', 'Brazov', '1990-05-12', 'Uomo', 'ajeje.brazov@example.com', '3456781234','Mensile', '2022-05-14');

-- INSERIMENTO ISTRUTTORI
INSERT INTO Istruttore (identificativo, nome, cognome, specializzazione, orario_di_lavoro) VALUES
	(201, 'Giovanni', 'Neri', 'Insegnante di Yoga', '09:00-17:00'),
	(202, 'Luca', 'Bianchi', 'Istruttore di Spinning', '12:00-20:00'),
	(203, 'Sara', 'Verdi', 'Istruttore di Pilates', '13:00-23:00'),
	(204, 'Maria', 'Rossi', 'Istruttore di Sollevamento Pesi', '09:00-17:00'),
	(205, 'Davide', 'Gialli', 'Insegnante di Yoga', '12:00-20:00'),
	(206, 'Elena', 'Marino', 'Istruttore di Pilates', '09:00-17:00'),
	(207, 'Francesco', 'Ferrari', 'Istruttore di Spinning', '13:00-23:00'),
	(208, 'Alessandra', 'Ricci', 'Insegnante di Yoga', '12:00-20:00'),
	(209, 'Matteo', 'Conti', 'Istruttore di Sollevamento Pesi', '13:00-23:00'),
	(210, 'Giulia', 'Leone', 'Istruttore di Spinning', '09:00-17:00');

-- INSERIMENTO CLASSI
-- Lunedì
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES
	('Yoga', 'Yoga Rilassante', 'Classe di Yoga per principianti con tecniche di rilassamento.', '9:00-10:30', 'Lunedì', 20, 1),
	('Spinning', 'Spinning Intermedio', 'Lezione di spinning per migliorare la resistenza.', '10:30-12:00', 'Lunedì', 25, 2),
	('Pilates', 'Pilates Base', 'Introduzione ai principi base del Pilates.', '15:00-16:30', 'Lunedì', 15, 6),
	('Sollevamento Pesi', 'Forza e Resistenza', 'Allenamento per aumentare la forza muscolare.', '18:00-19:30', 'Lunedì', 12, 4);
-- Martedì
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES 
	('Yoga', 'Yoga Dinamico', 'Lezione intermedia di Yoga con movimenti fluidi.', '9:00-10:30', 'Martedì', 20, 1),
	('Spinning', 'Spinning Avanzato', 'Lezione avanzata per migliorare la forma fisica.', '10:30-12:00', 'Martedì', 25, 10),
	('Pilates', 'Pilates Base', 'Sessione introduttiva di Pilates.', '15:00-16:30', 'Martedì', 15, 3),
	('Sollevamento Pesi', 'Potenziamento muscolare', 'Sollevamento pesi per migliorare la forza.', '18:00-19:30', 'Martedì', 12, 4);
-- Mercoledì
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES 
	('Yoga', 'Yoga Rilassante', 'Sessione di Yoga per il relax.', '9:00-10:30', 'Mercoledì', 20, 5),
	('Spinning', 'Spinning Base', 'Introduzione allo spinning per principianti.', '10:30-12:00', 'Mercoledì', 25, 10),
	('Pilates', 'Pilates Intermedio', 'Lezione di Pilates per migliorare la flessibilità.', '15:00-16:30', 'Mercoledì', 15, 6),
	('Sollevamento Pesi', 'Forza e Resistenza', 'Allenamento avanzato di sollevamento pesi.', '18:00-19:30', 'Mercoledì', 12, 9);
-- Giovedì
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES
	('Yoga', 'Yoga Dinamico', 'Sessione di Yoga intermedia.', '9:00-10:30', 'Giovedì', 20, 5),
	('Spinning', 'Spinning Intermedio', 'Lezione di spinning per migliorare la resistenza e la forma fisica.', '10:30-12:00', 'Giovedì', 25, 7),
	('Pilates', 'Pilates Base', 'Sessione introduttiva di Pilates per tutti.', '15:00-16:30', 'Giovedì', 15, 6),
	('Sollevamento Pesi', 'Potenziamento muscolare', 'Sollevamento pesi avanzato.', '18:00-19:30', 'Giovedì', 12, 9);
-- Venerdì
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES
	('Yoga', 'Yoga Rilassante', 'Sessione rilassante di Yoga.', '9:00-10:30', 'Venerdì', 20, 8),
	('Spinning', 'Spinning Base', 'Spinning per principianti.', '10:30-12:00', 'Venerdì', 25, 7),
	('Pilates', 'Pilates Intermedio', 'Lezione avanzata di Pilates.', '15:00-16:30', 'Venerdì', 15, 6),
	('Sollevamento Pesi', 'Forza e Resistenza', 'Sessione di sollevamento pesi per migliorare la forza.', '18:00-19:30', 'Venerdì', 12, 4);
-- Sabato
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES
	('Yoga', 'Yoga Dinamico', 'Sessione avanzata di Yoga.', '9:00-10:30', 'Sabato', 20, 8),
	('Spinning', 'Spinning Avanzato', 'Lezione avanzata di spinning.', '10:30-12:00', 'Sabato', 25, 2),
	('Pilates', 'Pilates Base', 'Sessione base di Pilates.', '15:00-16:30', 'Sabato', 15, 3),
	('Sollevamento Pesi', 'Potenziamento muscolare', 'Allenamento per sollevamento pesi avanzato.', '18:00-19:30', 'Sabato', 12, 9);
-- Domenica
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES
	('Yoga', 'Yoga Rilassante', 'Sessione di Yoga rilassante per concludere la settimana.', '9:00-10:30', 'Domenica', 20, 1),
	('Spinning', 'Spinning Intermedio', 'Lezione intermedia di spinning.', '10:30-12:00', 'Domenica', 25, 2),
	('Pilates', 'Pilates Avanzato', 'Sessione di Pilates per migliorare la flessibilità.', '15:00-16:30', 'Domenica', 15, 3),
	('Sollevamento Pesi', 'Forza e Resistenza', 'Sessione di sollevamento pesi avanzato.', '18:00-19:30', 'Domenica', 12, 4);
INSERT INTO Classe (tipo, nome, descrizione, orario, giorno_settimanale, numero_massimo_partecipanti, istruttoreRIF) VALUES
	('Yoga', 'Yoga Rilassante', 'Sessione di Yoga rilassante per concludere la settimana.', '9:00-10:30', 'Sabato', 20, 1),
	('Yoga', 'Yoga Rilassante', 'Sessione di Yoga rilassante per concludere la settimana.', '9:00-10:30', 'Martedì', 20, 1),
	('Yoga', 'Yoga Rilassante', 'Sessione di Yoga rilassante per concludere la settimana.', '9:00-10:30', 'Giovedì', 20, 1),
	('Yoga', 'Yoga Rilassante', 'Sessione di Yoga rilassante per concludere la settimana.', '9:00-10:30', 'Domenica', 20, 1);


-- INSERIMENTO PRENOTAZIONI 
-- Prenotazioni per Lunedì
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES
	(1001, 1, 6),  -- Membro 1 prenota la classe 1 (Yoga Rilassante, Lunedì 9:00)
	(1002, 2, 2),  -- Membro 2 prenota la classe 2 (Spinning Intermedio, Lunedì 10:30)
	(1003, 3, 3),  -- Membro 3 prenota la classe 3 (Pilates Base, Lunedì 15:00)
	(1004, 4, 4);  -- Membro 4 prenota la classe 4 (Sollevamento Pesi, Lunedì 18:00)
-- Prenotazioni per Martedì
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES 
	(1005, 1, 5),  -- Membro 1 prenota la classe 5 (Yoga Dinamico, Martedì 9:00)
	(1006, 5, 6),  -- Membro 5 prenota la classe 6 (Spinning Avanzato, Martedì 10:30)
	(1007, 6, 7),  -- Membro 6 prenota la classe 7 (Pilates Base, Martedì 15:00)
	(1008, 7, 8);  -- Membro 7 prenota la classe 8 (Sollevamento Pesi, Martedì 18:00)
-- Prenotazioni per Mercoledì
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES
	(1009, 2, 9),  -- Membro 2 prenota la classe 9 (Yoga Rilassante, Mercoledì 9:00)
	(1010, 8, 10),  -- Membro 8 prenota la classe 10 (Spinning Base, Mercoledì 10:30)
	(1011, 3, 11),  -- Membro 3 prenota la classe 11 (Pilates Intermedio, Mercoledì 15:00)
	(1012, 9, 12);  -- Membro 9 prenota la classe 12 (Sollevamento Pesi, Mercoledì 18:00)
-- Prenotazioni per Giovedì
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES
	(1013, 4, 13),  -- Membro 4 prenota la classe 13 (Yoga Dinamico, Giovedì 9:00)
	(1014, 10, 14), -- Membro 10 prenota la classe 14 (Spinning Intermedio, Giovedì 10:30)
	(1015, 5, 15),  -- Membro 5 prenota la classe 15 (Pilates Base, Giovedì 15:00)
	(1016, 6, 16);  -- Membro 6 prenota la classe 16 (Sollevamento Pesi, Giovedì 18:00)
-- Prenotazioni per Venerdì
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES
	(1017, 7, 17),  -- Membro 7 prenota la classe 17 (Yoga Rilassante, Venerdì 9:00)
	(1018, 8, 18),  -- Membro 8 prenota la classe 18 (Spinning Base, Venerdì 10:30)
	(1019, 9, 19),  -- Membro 9 prenota la classe 19 (Pilates Intermedio, Venerdì 15:00)
	(1020, 10, 20); -- Membro 10 prenota la classe 20 (Sollevamento Pesi, Venerdì 18:00)
-- Prenotazioni per Sabato
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES
	(1021, 1, 21),  -- Membro 1 prenota la classe 21 (Yoga Dinamico, Sabato 9:00)
	(1022, 2, 22);  -- Membro 2 prenota la classe 22 (Spinning Avanzato, Sabato 10:30)
INSERT INTO Prenotazione (numero_prenotazione, membroRIF, classeRIF) VALUES
	(1026, 8, 22),
	(1027, 8, 22),
	(1028, 8, 24);
INSERT INTO Prenotazione (numero_prenotazione, data_preotazione, canc, membroRIF, classeRIF) VALUES
	(1029, 2024-09-01, 1, 8, 22);
INSERT INTO Prenotazione (numero_prenotazione, data_preotazione, canc, membroRIF, classeRIF) VALUES
	(10309, 2024-05-01, 6, 6, 19);
INSERT INTO Prenotazione (numero_prenotazione, data_preotazione, canc, membroRIF, classeRIF) VALUES
	(1039, 2024-03-25, 6, 6, 19);
INSERT INTO Prenotazione (numero_prenotazione, data_preotazione, canc, membroRIF, classeRIF) VALUES
	(1100, 1993-06-14, 6, 6, 19);

-- INSERIMENTO PESI
-- Inserimento di un Tapis Roulant
INSERT INTO Attrezzatura (tipo, descrizione, data_di_acquisto, stato, istruttoreRIF)
VALUES ('Tapis Roulant', 'Tapis roulant elettrico con schermo LCD.', '2022-01-15', 'Disponibile', 2);
-- Inserimento di una Bici da Spinning
INSERT INTO Attrezzatura (tipo, descrizione, data_di_acquisto, stato, istruttoreRIF)
VALUES ('Bici da Spinning', 'Bici da spinning professionale con resistenza regolabile.', '2023-03-10', 'Fuori Servizio', 7);
-- Inserimento di Pesi liberi
INSERT INTO Attrezzatura (tipo, descrizione, data_di_acquisto, stato, istruttoreRIF)
VALUES ('Pesi liberi', 'Set di pesi liberi variabile da 2kg a 20kg.', '2021-06-20', 'Manutenzione', 9);


-- -------------------------------- QUERY ---------------------------------------------------------------

--1. Recupera tutti i membri registrati nel sistema.
SELECT *	
	FROM Membro;

--2. Recupera il nome e il cognome di tutti i membri che hanno un abbonamento mensile
SELECT * 
	FROM Membro
	WHERE Membro.tipo_abbonamento = 'Mensile';

--3.	Recupera l'elenco delle classi di yoga offerte dal centro fitness.
SELECT *
	FROM Classe
	WHERE tipo = 'Yoga';

--4. Recupera il nome e il cognome di tutti gli istruttori che insegnano Pilates
SELECT *
	FROM Istruttore
	WHERE specializzazione = 'Istruttore di Pilates';

--5. Recupera i dettagli delle classi programmate per il lunedì
SELECT * 
	FROM Classe 
	WHERE giorno_settimanale = 'Lunedì';

--6. Recupera l'elenco dei membri che hanno prenotato una classe di spinning
SELECT Membro.nome, Membro.cognome, Classe.tipo, Classe.nome, giorno_settimanale, data_preotazione
	FROM Classe	
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
	WHERE tipo = 'Spinning';

--7. Recupera tutte le attrezzature che sono attualmente fuori servizio
SELECT * 
	FROM Attrezzatura
	WHERE stato = 'Fuori Servizio';

--8. Conta il numero di partecipanti per ciascuna classe programmata per il mercoledì
SELECT COUNT(*) AS 'Prenotati per Sabato'
	FROM Classe
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF
	WHERE giorno_settimanale = 'Sabato';

--9. Recupera l'elenco degli istruttori disponibili per tenere una lezione sabato
SELECT Istruttore. *
	FROM Classe
	JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
	WHERE giorno_settimanale ='Sabato';

--10.Recupera tutti i membri con un abbonamento attivo dal 2023
SELECT *
	FROM Membro
	WHERE data_di_iscrizione > '2023-01-01';

--11. Trova il numero massimo di partecipanti per tutte le classi di sollevamento pesi
SELECT COUNT(*) AS 'Prenotati per Sollevamento Pesi '
	FROM Classe
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF;

--12. Recupera tutte le prenotazioni effettuate da un membro specifico
SELECT * 
	FROM Prenotazione
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
	WHERE Membro.nome = 'Mario' AND Membro.cognome = 'Rossi';

--13. Recupera l'elenco degli istruttori che conducono più di 5 classi alla settimana
SELECT Istruttore.cognome, COUNT(*) AS Numero_Classi
	FROM Istruttore
	JOIN Classe ON Istruttore.istruttoreID = Classe.istruttoreRIF
	GROUP BY Istruttore.cognome
	HAVING COUNT(*)>5;

--14. Recupera le classi che hanno ancora posti disponibili per nuove prenotazioni
SELECT COUNT(*) AS 'Numero prenotati per classe', Classe.tipo, Classe.numero_massimo_partecipanti
	FROM Prenotazione
	JOIN Classe ON Prenotazione.classeRIF = Classe.classeID
	GROUP BY Classe.tipo, Classe.numero_massimo_partecipanti
	HAVING COUNT(*) < Classe.numero_massimo_partecipanti;

-- 15. Recupera l'elenco dei membri che hanno annullato una prenotazione negli ultimi 30 gg
SELECT *
	FROM Prenotazione
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
	WHERE canc = 1 AND data_preotazione BETWEEN data_preotazione AND 2024-08-01;

--16. Recupera l'elenco delle attrezzature acquistate prima del 2022
SELECT * 
	FROM Attrezzatura
	WHERE data_di_acquisto < '2022-01-01';

--17. Recupera l'elenco dei membri che hanno prenotato una classe in cui l'istruttore è "Giovanni Neri"
SELECT Membro.nome, Membro.cognome, Classe.tipo, Istruttore.nome, Istruttore.cognome 
	FROM Istruttore
	JOIN Classe ON Istruttore.istruttoreID = Classe.istruttoreRIF
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
	WHERE Istruttore.nome = 'Giovanni' AND Istruttore.cognome ='Neri';

--18. Calcola il numero totale di prenotazioni per ogni classe per un determinato periodo di tempo
SELECT COUNT(*), data_preotazione
	FROM Classe
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF
	GROUP BY data_preotazione
	HAVING Prenotazione.data_preotazione BETWEEN '1905-05-01' AND '1905-07-01';

--19.	Trova tutte le classi associate a un'istruttore specifico e i membri che vi hanno partecipato.
SELECT *
	FROM Classe
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
	WHERE Classe.istruttoreRIF = 8;

--20.	Recupera tutte le attrezzature in manutenzione e il nome degli istruttori che le utilizzano nelle loro classi.
SELECT *
	FROM Attrezzatura
	JOIN Istruttore ON Istruttore.istruttoreID = Attrezzatura.istruttoreRIF
	WHERE stato = 'Manutenzione';

-- ------------------------------------------- VIEW ------------------------------------------------------------

--1.	Crea una view che mostra l'elenco completo dei membri con il loro nome, cognome e tipo di abbonamento.
CREATE VIEW ElencoMembri 
	AS SELECT Membro.nome, Membro.cognome, Membro.codice_abbonamento, Membro.tipo_abbonamento
	FROM Membro;
SELECT *
	FROM ElencoMembri;

--2.	Crea una view che elenca tutte le classi disponibili con i rispettivi nomi degli istruttori.
CREATE VIEW ClassiLibere AS 
	SELECT COUNT(*) AS 'Numero prenotati per classe', Classe.tipo, Classe.numero_massimo_partecipanti, Istruttore.nome AS Nome_Istruttore, Istruttore.cognome AS Cognome_Istruttore
	FROM Prenotazione
	JOIN Classe ON Prenotazione.classeRIF = Classe.classeID
	JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
	GROUP BY Classe.tipo, Classe.numero_massimo_partecipanti, Istruttore.nome, Istruttore.cognome
	HAVING COUNT(*) < Classe.numero_massimo_partecipanti; 
SELECT *
	FROM ClassiLibere;

--3.	Crea una view che mostra le classi prenotate dai membri insieme al nome della classe e alla data di prenotazione.
CREATE VIEW ClassiPrenotate AS 
	SELECT Classe.tipo AS Nome_Classe, Classe.orario, Classe.giorno_settimanale, Prenotazione.data_preotazione, Membro.nome AS Nome_Membro, Membro.cognome AS Membro_Cognome
	FROM Classe
	JOIN Prenotazione ON Classe.classeID = Prenotazione.classeRIF
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
SELECT * 
	FROM ClassiPrenotate;

--4.	Crea una view che elenca tutte le attrezzature attualmente disponibili, con la descrizione e lo stato.
CREATE VIEW AttrezzatureDisponibili AS 
	SELECT tipo AS Tipo_Attrezzatura, descrizione, stato
	FROM Attrezzatura
	WHERE stato ='Disponibile';
SELECT * 
	FROM AttrezzatureDisponibili;

--5.	Crea una view che mostra i membri che hanno prenotato una classe di spinning negli ultimi 30 giorni.
CREATE VIEW PrenotazioniClasseSpinning30Giorni AS
	SELECT Membro.nome AS Nome_Membro, Membro.cognome AS Cognome_Membro, data_preotazione, Classe.tipo
	FROM Prenotazione
	JOIN Membro ON Prenotazione.membroRIF = Membro.membroID
	JOIN Classe ON Membro.membroID = Classe.classeID
	WHERE data_preotazione >= CURRENT_TIMESTAMP - 30;

SELECT *
	FROM PrenotazioniClasseSpinning30Giorni;

--6.	Crea una view che elenca gli istruttori con il numero totale di classi che conducono.
CREATE VIEW NumeroClassiIstruttore AS
	SELECT COUNT(*), Classe.tipo
		FROM Classe
		JOIN Istruttore ON Classe.classeID = Istruttore.istruttoreID
		GROUP BY Classe.tipo;
		
--7.	Crea una view che mostri il nome delle classi e il numero di partecipanti registrati per ciascuna classe.
CREATE VIEW PartecipantiXClasse AS
	SELECT COUNT(*) AS Numero_Partecipanti, Classe.tipo
	FROM Prenotazione
	JOIN Classe ON Prenotazione.classeRIF = Classe.classeID
	GROUP BY Classe.tipo;
SELECT * 
	FROM PartecipantiXClasse;
--8.	Crea una view che elenca i membri che hanno un abbonamento attivo insieme alla data di inizio e la data di scadenza.

--9.	Crea una view che mostra l'elenco degli istruttori che conducono classi il lunedì e il venerdì.
CREATE VIEW IstruttoriLunedìVenerdì AS 
	SELECT Istruttore.nome AS Nome_Istruttore, Istruttore.cognome AS Cognome_Istruttore, Classe.giorno_settimanale, Classe.tipo 
	FROM Prenotazione
	JOIN Classe ON Prenotazione.classeRIF = Classe.classeID
	JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
	WHERE Classe.giorno_settimanale = 'Lunedì' OR Classe.giorno_settimanale = 'Venerdì';
SELECT *
	FROM IstruttoriLunedìVenerdì;

--10.	Crea una view che elenca tutte le attrezzature acquistate nel 2023 insieme al loro stato attuale.
CREATE VIEW Attrezzature2023 AS 
	SELECT Attrezzatura.tipo, attrezzatura.data_di_acquisto, Attrezzatura.stato
	FROM Attrezzatura
	WHERE YEAR(data_di_acquisto) = 2023;
SELECT * 
	FROM Attrezzature2023;

-- ------------------------------------------------- STORED PROCEDURE -------------------------------------------------------
--1.	Scrivi una stored procedure che permette di inserire un nuovo membro nel sistema con tutti i suoi dettagli:
--		nome, cognome, data di nascita, tipo di abbonamento, ecc.
CREATE PROCEDURE InsertMembro 
	@NomeMembro VARCHAR(250), 
	@CognomeMembro VARCHAR(250),
	@Data_di_Nascita DATE,
	@Sesso VARCHAR(5),
	@Email VARCHAR(250),
	@Tipo_abbonamento VARCHAR(250),
	@Telefono VARCHAR(15),
	@Data_di_iscrizione DATE = NULL,
	@Codice_abbonamento INT
AS
	BEGIN 
		INSERT INTO Membro(codice_abbonamento, nome, cognome, data_di_nascita, sesso, email, telefono, tipo_abbonamento) VALUES
		(@Codice_abbonamento, @NomeMembro, @CognomeMembro, @Data_di_Nascita, @Sesso, @Email, @Telefono, @Tipo_abbonamento)
	END

EXEC InsertMembro @Codice_abbonamento = 5555, @NomeMembro = 'Alessio', @CognomeMembro = 'Bucheri' , @Data_di_Nascita = '14-06-1993', @Sesso = 'Uomo', @Email = 'ale@buc.com', @Telefono = '555555555', @Tipo_abbonamento = 'Annuale';
SELECT * 
	FROM Membro
	WHERE nome = 'Alessio';
--2.	Scrivi una stored procedure per aggiornare lo stato di un'attrezzatura (ad esempio, disponibile, in manutenzione, fuori servizio).
CREATE PROCEDURE CambioStatoAttrezzatura 
	@NewStato VARCHAR(15),
	@AttrezzaturaID INT
AS
	BEGIN
		UPDATE Attrezzatura
		SET stato = @NewStato
		WHERE attrezzaturaID = @AttrezzaturaID;
	END
SELECT * FROM Attrezzatura;
EXEC CambioStatoAttrezzatura @AttrezzaturaID = 1, @NewStato = 'Disponibile';
--3.	Scrivi una stored procedure che consenta a un membro di prenotare una classe specifica.
CREATE PROCEDURE InsertPrenotazione
	@Numero_prenotazione INT, 
	@MembroRIF INT, 
	@ClasseRIF INT
AS
	BEGIN 
		INSERT INTO Prenotazione( numero_prenotazione, membroRIF, classeRIF) VALUES
			(@Numero_prenotazione, @MembroRIF, @ClasseRIF)
	END
EXEC InsertPrenotazione @Numero_prenotazione = 1122, @MembroRIF = 5, @ClasseRIF = 17;
SELECT * FROM Prenotazione;
--4.	sql
--5.	Scrivi una stored procedure per permettere ai membri di cancellare una prenotazione esistente.
CREATE PROCEDURE DeletePrenotazione
	@NumeroPrenotazione INT
AS
	BEGIN
		DELETE
		FROM Prenotazione
		WHERE numero_prenotazione = @NumeroPrenotazione
	END
EXEC DeletePrenotazione @NumeroPrenotazione = 1003;
SELECT * FROM Prenotazione
--6.	Scrivi una stored procedure che restituisce il numero di classi condotte da un istruttore specifico.
CREATE PROCEDURE ClassiIstruttore
	@CodiceIstruttore INT
AS
	BEGIN
		SELECT *
		FROM Classe 
		JOIN Istruttore ON Classe.istruttoreRIF = Istruttore.istruttoreID
		WHERE Istruttore.identificativo = @CodiceIstruttore
	END

SELECT * FROM Istruttore;
EXEC ClassiIstruttore @CodiceIstruttore = 201;
