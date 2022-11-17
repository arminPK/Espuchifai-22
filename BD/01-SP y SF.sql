-- Realizar los SP para dar de alta todas las entidades menos las tablas Cliente y Reproducción. En la tabla reproducción el SP se debe llamar ‘Reproducir’.
USE Espuchifai;
DELIMITER $$
DROP PROCEDURE
IF EXISTS altaBanda $$
CREATE PROCEDURE altaBanda ( unnombre VARCHAR(45), unafundacion YEAR, unidBanda SMALLINT UNSIGNED) 
BEGIN
    INSERT INTO Banda (nombre, fundacion, idBanda)
    VALUES ( unnombre, unafundacion, unidBanda);
    INSERT INTO Banda (idBanda) VALUE (nombre);
	SET unidBanda = LAST_INSERT_ID();
END $$

DELIMITER $$
DROP PROCEDURE
IF EXISTS altaAlbum $$
CREATE PROCEDURE altaAlbum ( unnombre VARCHAR(45), unlanzamiento DATE, unidBanda SMALLINT UNSIGNED, unidAlbum MEDIUMINT UNSIGNED) 
BEGIN
    INSERT INTO Album ( nombre, lanzamiento, idBanda, idAlbum, cantidad)
    VALUES ( unnombre, unlanzamiento, unidBanda, unidAlbum, 0);
    INSERT INTO Album (idAlbum) VALUE (nombre);
	SET unidAlbum = LAST_INSERT_ID();
END $$

DELIMITER $$
DROP PROCEDURE
IF EXISTS altaCancion $$
CREATE PROCEDURE altaCancion ( unnombre VARCHAR(45), unorden TINYINT UNSIGNED, unidAlbum MEDIUMINT UNSIGNED, unidCancion INT UNSIGNED) 
BEGIN
    INSERT INTO Cancion ( nombre, orden, idAlbum, idCancion, cantidad)
    VALUES ( unnombre, unorden, unidAlbum, unidCancion, 0);
    INSERT INTO Cancion (idCancion) VALUE (nombre);
	SET unidCancion = LAST_INSERT_ID();
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS Reproducir $$
CREATE PROCEDURE Reproducir ( unareproduccion DATETIME, unidCancion INT UNSIGNED, unidUsuario SMALLINT UNSIGNED)
BEGIN
    INSERT INTO Reproduccion ( reproduccion, idCancion, idUsuario)
    VALUES ( unareproduccion, unidCancion, unidUsuario);
END $$
-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.

-- Se pide hacer el SF ‘CantidadReproduccionesBanda’ que reciba por parámetro un identificador de banda y 2 fechas, se debe devolver la cantidad de 
-- reproducciones que tuvieron las canciones de esa banda entre esas 2 fechas (inclusive).

-- Se pide hacer el SP ‘Buscar’ que reciba por parámetro una cadena. El SP tiene que devolver las canciones que contengan la cadena en su título, nombre de álbum o nombre de banda
