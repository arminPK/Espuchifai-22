DROP DATABASE IF EXISTS Espochifai;
CREATE DATABASE Espochifai;
USE Espochifai;
create table Espochifai.Banda(
    idBanda TINYINT NOT NULL,
    idAlbum int not null, 
    nombre VARCHAR(50) not null,
    fundacion DATE not null,
    PRIMARY KEY (idBanda),
    CONSTRAINT FK_Banda_Album FOREIGN KEY (idAlbum)
        REFERENCES Espochifai.Album (idAlbum),
    CONSTRAINT UQ_Banda_nombre UNIQUE (nombre)
);
create Table Espochifai.Album(
    idAlbum TINYINT NOT NULL,
    idCancion TINYINT NOT NULL,
    nombre VARCHAR(45) NOT NULL,
    lanzamiento DATE NOT NULL,
    PRIMARY KEY (idAlbum),
    CONSTRAINT FK_Album_Cancion FOREIGN KEY (idCancion)
        REFERENCES Espochifai.Cancion (idCancion),
    CONSTRAINT UQ_Album_nombre UNIQUE (nombre)
);
create Table Espochifai.Cancion(
    idCancion TINYINT NOT NULL,
    nombre VARCHAR(45) not NULL,
    numero_ord INT not NULL,
    PRIMARY KEY (idCancion),
    CONSTRAINT UQ_Cancion_nombre UNIQUE (nombre)
);
create Table Espochifai.Cliente(
    idCliente SMALLINT not null,
    nombre VARCHAR(45) not null,
    apellido VARCHAR(45) not NULL,
    email VARCHAR(45) not NULL,
    contrasena CHAR(20) not NULL,
    PRIMARY KEY (idCliente)
);
create Table Espochifai.Reproduccion(
    idReproduccion SMALLINT not NULL,
    idCliente int not NULL,
    idCancion INT NOT NULL,
    tiempo_repro DATETIME NOT NULL,
    PRIMARY KEY (idReproduccion),
    CONSTRAINT FK_Cliente_Reproduccion FOREIGN KEY (idCliente) 
        REFERENCES Espochifai.Cliente (idCliente),
    CONSTRAINT FK_Cancion_Reproduccion FOREIGN KEY (idCancion) 
        REFERENCES Espochifai.Cancion (idCancion)
);

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
