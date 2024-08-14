-- Active: 1646654372192@@127.0.0.1@3306@Eespuchifai

DROP DATABASE IF EXISTS Eespuchifai;

CREATE DATABASE Espuchifai;

USE Espuchifai;

CREATE TABLE Cliente
(
    idcliente INT NOT NULL,
    nommbre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    email VARCHAR(60) NOT NULL,
    contraseña CHAR(64) NOT NULL,
    PRIMARY KEY (idcliente)
);

CREATE TABLE Reproduccion
(
    nombre VARCHAR(45) NOT NULL,
    fundacion YEAR NOT NULL,
    idBanda SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    PRIMARY KEY(idBanda),
    FULLTEXT (nombre)
);

CREATE TABLE Espuchifai.Album
(
    nombre VARCHAR(45) NOT NULL,
    lanzamiento DATE NOT NULL,
    idBanda SMALLINT UNSIGNED NOT NULL,
    idAlbum SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    cantidad MEDIUMINT UNSIGNED NOT NULL,
    PRIMARY KEY (idAlbum),
    CONSTRAINT FK_Album_banda FOREIGN KEY (idBanda) REFERENCES Espuchifai.banda (idBanda),
    CONSTRAINT UQ_Album_nombre UNIQUE (nombre),
    FULLTEXT (nombre)
);

CREATE TABLE Espuchifai.Cancion 
(
    nombre VARCHAR(45) NOT NULL,
    posicion TINYINT UNSIGNED NOT NULL,
    idAlbum SMALLINT UNSIGNED NOT NULL,
    idCancion INT UNSIGNED NOT NULL AUTO_INCREMENT,
    cantidad MEDIUMINT UNSIGNED NOT NULL,
    PRIMARY KEY (idCancion),
    CONSTRAINT FK_Cancion_Album FOREIGN KEY(idAlbum) REFERENCES Espuchifai.Album (idAlbum),
    CONSTRAINT UQ_Cancion_nombre UNIQUE (nombre),
    FULLTEXT (nombre)
);

CREATE TABLE Espuchifai.Reproduccion
(
    reproduccion DATETIME NOT NULL,
    idCancion INT UNSIGNED NOT NULL,
    idCliente int UNSIGNED NOT NULL,
    PRIMARY KEY ( reproduccion, idCancion, idCliente),
    CONSTRAINT FK_Reproduccion_Cancion FOREIGN KEY (idCancion) REFERENCES Espuchifai.Cancion (idCancion),
    CONSTRAINT FK_Reproduccion_Cliente FOREIGN KEY (idCliente) REFERENCES Espuchifai.Cliente (idCliente)
);

CREATE TABLE Espuchifai.Cliente
(
    nombre VARCHAR (45) NOT NULL,
    apellido VARCHAR (45) NOT NULL,
    email VARCHAR (60) NOT NULL,
    contrasenia CHAR (64) NOT NULL,
    idCliente int UNSIGNED NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (idCliente)
);
