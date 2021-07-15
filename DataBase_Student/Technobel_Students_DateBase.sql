CREATE DATABASE Technobel_Students

USE Technobel_Students

CREATE TABLE Student(
	StudentId INT IDENTITY, 
	Nom VARCHAR(255) NOT NULL,
	Prenom VARCHAR(255) NOT NULL,
	Numero VARCHAR(255)
);
INSERT INTO Student VALUES('Georges','Lucas',null)
INSERT INTO Student VALUES('Clint','Eastwood', '0487/573314')
INSERT INTO Student VALUES('Sean','Connery', null)
INSERT INTO Student VALUES('Robert','De Niro', '0487573314')
INSERT INTO Student VALUES('Kevin', 'Bacon', '+32487573314')
INSERT INTO Student VALUES('Kim', 'Basinger', null)
INSERT INTO Student VALUES('Johnny', 'Depp', null)

INSERT INTO Student(Nom,Prenom,Numero) OUTPUT inserted.StudentId VALUES ('Petrov', 'Constantin', null)

