-- Active: 1646654372192@@127.0.0.1@3306@Eespuchifai

DROP DATABASE IF EXISTS Espuchifai;

CREATE DATABASE Espuchifai;

USE Espuchifai;

CREATE TABLE Cliente
(
    idcliente INT NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    apellido VARCHAR(45) NOT NULL,
    email VARCHAR(60) NOT NULL,
    contrasenia CHAR(64) NOT NULL,
    PRIMARY KEY (idcliente)
);

CREATE TABLE Banda
(
    idbanda SMALLINT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    fundacion YEAR NOT NULL,
    PRIMARY KEY (idbanda)
);

CREATE TABLE Album
(
    idalbum TINYINT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    lanzamiento DATE NOT NULL,
    cantidad INT NOT NULL,
    idbanda SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idalbum),
    CONSTRAINT fk_Album_idbanda FOREIGN KEY(idbanda) REFERENCES Banda (idbanda)
);

CREATE TABLE Cancion
(
    idcancion TINYINT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    numorden INT UNDESIGNED NOT NULL,
    cantidad INT UNDESIGNED NOT NULL,
    idalbum TINYINT UNSIGNED NOT NULL,
    PRIMARY KEY (idcancion),
    CONSTRAINT fk_Cancion_idalbum FOREIGN KEY(idalbum) REFERENCES Album (idalbum)
);

CREATE TABLE Reproduccion
(
    idreproduccion INT UNSIGNED NOT NULL,
    idcliente INT NOT NULL,
    idcancion TINYINT UNSIGNED NOT NULL,
    momreproduccion DATETIME NOT NULL,
    PRIMARY KEY (idreproduccion),
    CONSTRAINT fk_Reproduccion_idcliente FOREIGN KEY(idcliente) REFERENCES Cliente (idcliente),
    CONSTRAINT fk_Reproduccion_idcancion FOREIGN KEY(idcancion) REFERENCES Cancion (idcancion)
);
