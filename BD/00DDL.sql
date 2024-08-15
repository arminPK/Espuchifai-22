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
    idreproduccion INT UNSIGNED NOT NULL AUTO_INCREMENT,
    idcliente INT NOT NULL,
    idcancion TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    momreproduccion DATETIME NOT NULL,
    PRIMARY KEY (idreproduccion)
    CONSTRAINT fk_Reproduccion_idcliente FOREIGN KEY(idcliente) REFERENCES Cliente (idcliente),
    CONSTRAINT fk_Reproduccion_idcancion FOREIGN KEY(idcancion) REFERENCES Cancion (idcancion)
);

CREATE TABLE Cancion
(
    idcancion TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    numorden INT UNSIGNED NOT NULL AUTO_INCREMENT,
    idalbum TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (idcancion),
    CONSTRAINT fk_Cancion_idalbum FOREIGN KEY(idalbum) REFERENCES Album (idalbum)
);

CREATE TABLE Album
(
    idalbum TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(45) NOT NULL,
    lanzamiento DATE NOT NULL,
    idbanda SAMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (idalbum),
    CONSTRAINT fk_Album_idbanda FOREIGN KEY(idbanda) REFERENCES Bandaa (idbanda)
);

CREATE TABLE Banda
(
    idbanda SMALLINT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    fundacion YEAR NOT NULL,
    PRIMARY KEY (idbanda)
);
