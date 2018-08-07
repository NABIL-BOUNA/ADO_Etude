create database GET_Etude
go
use GET_Etude
go

create table Region
(
idRegion int primary key,
nomRegion Char(50)
)

create table Academie
(
idAcademie int primary key,
nomAcademie char(50),
idRegion int foreign key references Region(idRegion)
)

Create table Lycee
(
idLycee int primary key,
nom Char(50),
ville Char(50),
idAcademie int foreign key references Academie(idAcademie)
)

create table Professeur
(
idProfesseur int primary key,
nom Char(10),
prenom Char(10),
dateN date,
email varChar(15),
pass varChar(50),
dateAffLycee date,
EtatCivil varChar(50),
NEnfants int,
idLycee int foreign key references Lycee(idLycee)
)


create table Demande
(
idDemande int primary key,
dateDem date,
idProfesseur int foreign key references Professeur(idProfesseur)
)

create table Detail_Demande
(
idDemande int,
idLycee int,
numOrdre int
)

alter table Detail_Demande
Add constraint FkA Foreign key (idDemande) references Demande(idDemande)

alter table Detail_Demande
Add constraint FkB Foreign key (idLycee) references Lycee(idLycee)





CREATE proc [dbo].[getdemande]
as
select count(idDemande),Academie.nomAcademie from Demande,Professeur,Lycee,Academie where Professeur.idProfesseur=Demande.idProfesseur and Lycee.idLycee=Professeur.idLycee and Lycee.idAcademie=Academie.idAcademie group by Academie.nomAcademie

GO




CREATE proc [dbo].[getrep] 
@Id int
as
select Professeur.nom,prenom,email,pass,dateAffLycee,EtatCivil,dateN,NEnfants,Lycee.nom,ville from Lycee,Professeur where Lycee.idLycee=@Id and Lycee.idLycee=Professeur.idLycee

GO

