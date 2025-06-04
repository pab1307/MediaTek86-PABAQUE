CREATE TABLE service(
   idservice INT AUTO_INCREMENT,
   nom VARCHAR(50) ,
   PRIMARY KEY(idservice)
);

CREATE TABLE motif(
   idmotif INT AUTO_INCREMENT,
   libelle VARCHAR(128) ,
   PRIMARY KEY(idmotif)
);

CREATE TABLE personnel(
   idpersonnel INT AUTO_INCREMENT,
   nom VARCHAR(50) ,
   prenom VARCHAR(50) ,
   tel VARCHAR(15) ,
   mail VARCHAR(128) ,
   idservice INT NOT NULL,
   PRIMARY KEY(idpersonnel),
   FOREIGN KEY(idservice) REFERENCES service(idservice)
);

CREATE TABLE absence(
   idpersonnel INT,
   datedebut DATETIME,
   datefin DATETIME,
   idmotif INT NOT NULL,
   PRIMARY KEY(idpersonnel, datedebut),
   FOREIGN KEY(idpersonnel) REFERENCES personnel(idpersonnel),
   FOREIGN KEY(idmotif) REFERENCES motif(idmotif)
);

CREATE TABLE responsable(
   login VARCHAR(64),
   pwd VARCHAR(128)
);

DROP USER IF EXISTS 'Respmed'@'%';
CREATE USER 'Respmed'@'%' IDENTIFIED BY 'BTSSIO*';

GRANT ALL PRIVILEGES ON mediatek86.* TO 'Respmed'@'%';

INSERT INTO responsable (login, pwd) VALUES ("Respmed", SHA2("BTSSIO*", 256));

INSERT INTO motif (libelle) VALUES ("vacances"), ("maladie"), ("motif familial"), ("congé parental");

INSERT INTO service (nom) VALUES ("administratif"), ("médiation culturelle"), ("prêt");

INSERT INTO personnel (nom, prenom, tel, mail, idservice)
VALUES
  ("Mercier","Lucas","0612345678","lucas.mercier@example.com",1),
  ("Gautier","Camille","0723456789","camille.gautier@mail.fr",2),
  ("Rousseau","Maxime","0698765432","maxime.rousseau@sample.org",3),
  ("Moulin","Lucie","0711223344","lucie.moulin@test.fr",1),
  ("Lefevre","Aurélie","0622334455","aurelie.lefevre@domain.com",2),
  ("Simon","Julien","0733445566","julien.simon@example.com",3),
  ("Bouchet","Juliette","0644556677","juliette.bouchet@mail.fr",1),
  ("Leclerc","Thomas","0755667788","thomas.leclerc@sample.org",2),
  ("Garcia","Chloé","0666778899","chloe.garcia@test.fr",3),
  ("Martinez","Manon","0777889900","manon.martinez@domain.com",1);
  
INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif)
VALUES
  (2,"2024-03-01 09:00:00","2024-03-05 17:00:00",1),
  (2,"2024-04-10 08:30:00","2024-04-12 12:00:00",2),
  (2,"2024-05-15 13:00:00","2024-06-01 09:00:00",3),
  (5,"2024-07-01 08:00:00","2024-07-15 18:00:00",1),
  (2,"2024-08-20 09:15:00","2024-08-25 18:45:00",4),
  (8,"2024-09-05 10:30:00","2024-09-10 11:20:00",1),
  (1,"2024-10-12 14:00:00","2024-10-20 16:30:00",2),
  (5,"2024-11-01 09:45:00","2024-11-10 17:00:00",3),
  (8,"2024-12-15 08:00:00","2024-12-20 12:00:00",2),
  (5,"2025-01-05 09:00:00","2025-01-10 17:00:00",4),
  (4,"2025-02-10 09:00:00","2025-02-20 17:00:00",3),
  (2,"2025-03-01 08:30:00","2025-03-05 12:00:00",1),
  (3,"2025-04-10 13:00:00","2025-04-15 09:00:00",2),
  (6,"2025-05-20 13:00:00","2025-06-01 20:00:00",3),
  (8,"2025-07-10 09:15:00","2025-07-20 18:45:00",1),
  (4,"2025-08-05 10:30:00","2025-08-10 11:20:00",4),
  (10,"2025-09-12 14:00:00","2025-09-20 16:30:00",2),
  (4,"2025-10-01 09:45:00","2025-10-10 17:00:00",3),
  (7,"2025-11-15 08:00:00","2025-11-20 12:00:00",1),
  (3,"2025-12-05 09:00:00","2025-12-15 17:00:00",2),
  (9,"2024-01-01 08:00:00","2024-01-10 17:00:00",1),
  (6,"2024-02-05 09:00:00","2024-02-12 16:00:00",2),
  (1,"2024-03-10 08:30:00","2024-03-20 17:30:00",3),
  (3,"2024-04-15 09:15:00","2024-04-25 18:45:00",4),
  (5,"2024-05-20 07:45:00","2024-05-30 16:15:00",1),
  (7,"2024-01-05 09:00:00","2024-01-15 17:00:00",2),
  (6,"2024-02-10 08:00:00","2024-02-20 16:00:00",3),
  (4,"2024-03-15 07:30:00","2024-03-25 15:30:00",4),
  (2,"2024-04-20 10:00:00","2024-04-30 18:00:00",1),
  (7,"2024-05-25 09:45:00","2024-06-04 17:45:00",2),
  (10,"2024-01-10 08:15:00","2024-01-20 16:15:00",3),
  (9,"2024-02-15 09:30:00","2024-02-25 17:30:00",4),
  (1,"2024-03-20 08:45:00","2024-03-30 16:45:00",1),
  (8,"2024-04-25 09:00:00","2024-05-05 17:00:00",2),
  (3,"2024-06-01 07:00:00","2024-06-10 15:00:00",3),
  (2,"2024-01-15 07:30:00","2024-01-25 15:30:00",4),
  (4,"2024-02-20 08:00:00","2024-03-01 16:00:00",1),
  (6,"2024-03-25 09:15:00","2024-04-05 17:15:00",2),
  (9,"2024-04-30 10:00:00","2024-05-10 18:00:00",3),
  (2,"2024-06-05 08:30:00","2024-06-15 16:30:00",4),
  (10,"2024-01-20 09:00:00","2024-01-30 17:00:00",1),
  (7,"2024-02-25 08:15:00","2024-03-06 16:15:00",2),
  (8,"2024-03-30 09:30:00","2024-04-09 17:30:00",3),
  (4,"2024-05-05 10:45:00","2024-05-15 18:45:00",4),
  (8,"2024-06-10 07:15:00","2024-06-20 15:15:00",1),
  (5,"2024-01-25 08:00:00","2024-02-04 16:00:00",2),
  (3,"2024-03-01 09:00:00","2024-03-11 17:00:00",3),
  (6,"2024-04-05 07:45:00","2024-04-15 15:45:00",4),
  (7,"2024-05-10 08:30:00","2024-05-20 16:30:00",1),
  (1,"2024-06-15 09:15:00","2024-06-25 17:15:00",2),
  (5,"2024-01-30 07:00:00","2024-02-09 15:00:00",3);