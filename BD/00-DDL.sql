DROP DATABASE IF EXISTS Espuchifai;
CREATE DATABASE Espuchifai;
CREATE TABLE Espuchifai.Banda(
    idBanda TINYINT UNSIGNED NOT NULL,
    nombre VARCHAR(45)   NOT NULL,
    fundacion YEAR NOT NULL,
    PRIMARY KEY(idBanda),
);
CREATE TABLE Espuchifai.Album(
    idAlbum INT UNSIGNED NOT NULL,
    idBanda TINYINT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    lanzamiento DATE NOT NULL,
    PRIMARY KEY (idAlbum),
    CONSTRAINT FK_Album_banda FOREIGN KEY (idBanda)
        REFERENCES Espuchifai.banda (idBanda),
    CONSTRAINT UQ_Album_nombre UNIQUE (nombre)
);
CREATE TABLE Espuchifai.Cancion (
    idCancion INT UNSIGNED NOT NULL,
    idAlbum MEDIUMINT UNSIGNED NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    posicion TINYINT UNSIGNED NOT NULL,
    PRIMARY KEY (idCancion),
    CONSTRAINT FK_Cancion_Album FOREIGN KEY(idAlbum)
        REFERENCES Espuchifai.Album (idAlbum),
    CONSTRAINT UQ_Cancion_nombre UNIQUE (nombre)
);
CREATE TABLE Espuchifai.Reproduccion(
    idCliente  SMALLINT UNSIGNED NOT NULL,
    idCancion  INT UNSIGNED NOT NULL,
    reproduccion DATETIME NOT NULL,
    PRIMARY KEY (idCliente),
    CONSTRAINT FK_Reproduccion_Cancion FOREIGN KEY (idCancion)
        REFERENCES Espuchifai.Cancion (idCancion),
    CONSTRAINT FK_Reproduccion_idCliente FOREIGN KEY  (idCliente)
        REFERENCES Espuchifai.Cliente (idCliente)
);
CREATE TABLE Espuchifai.Cliente(
    idCliente SMALLINT UNSIGNED NOT NULL,
    nombre VARCHAR (45) NOT NULL,
    apellido VARCHAR (45) NOT NULL,
    email VARCHAR (45) NOT NULL,
    contrasenia CHAR (64) NOT NULL,
    PRIMARY KEY (idCliente)
);