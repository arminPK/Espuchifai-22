DROP DATABASE IF EXISTS Espuchifai;
SELECT 'Creando bd' Estado;
CREATE DATABASE Espuchifai;

CREATE TABLE
    Espuchifai.Banda(
        nombre VARCHAR(45) NOT NULL,
        fundacion YEAR NOT NULL,
        idBanda SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
        PRIMARY KEY(idBanda),
        FULLTEXT (nombre)
    );

CREATE TABLE
    Espuchifai.Usuario(
        nombre VARCHAR (45) NOT NULL,
        apellido VARCHAR (45) NOT NULL,
        email VARCHAR (45) NOT NULL,
        contrasenia CHAR (64) NOT NULL,
        idUsuario SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
        PRIMARY KEY (idUsuario)
    );

CREATE TABLE
    Espuchifai.Album(
        nombre VARCHAR(45) NOT NULL,
        lanzamiento DATE NOT NULL,
        idBanda SMALLINT UNSIGNED NOT NULL,
        idAlbum MEDIUMINT UNSIGNED NOT NULL AUTO_INCREMENT,
        cantidad MEDIUMINT UNSIGNED NOT NULL,
        PRIMARY KEY (idAlbum),
        CONSTRAINT FK_Album_banda FOREIGN KEY (idBanda) REFERENCES Espuchifai.banda (idBanda),
        CONSTRAINT UQ_Album_nombre UNIQUE (nombre),
        FULLTEXT (nombre)
    );

CREATE TABLE
    Espuchifai.Cancion (
        nombre VARCHAR(45) NOT NULL,
        orden TINYINT UNSIGNED NOT NULL,
        idAlbum MEDIUMINT UNSIGNED NOT NULL,
        idCancion INT UNSIGNED NOT NULL AUTO_INCREMENT,
        cantidad MEDIUMINT UNSIGNED NOT NULL,
        PRIMARY KEY (idCancion),
        CONSTRAINT FK_Cancion_Album FOREIGN KEY(idAlbum) REFERENCES Espuchifai.Album (idAlbum),
        CONSTRAINT UQ_Cancion_nombre UNIQUE (nombre),
        FULLTEXT (nombre)
    );

CREATE TABLE
    Espuchifai.Reproduccion(
        reproduccion DATETIME NOT NULL,
        idCancion INT UNSIGNED NOT NULL,
        idUsuario SMALLINT UNSIGNED NOT NULL,
        PRIMARY KEY (
            reproduccion,
            idCancion,
            idUsuario
        ),
        CONSTRAINT FK_Reproduccion_Cancion FOREIGN KEY (idCancion) REFERENCES Espuchifai.Cancion (idCancion),
        CONSTRAINT FK_Reproduccion_Usuario FOREIGN KEY (idUsuario) REFERENCES Espuchifai.Usuario (idUsuario)
    );