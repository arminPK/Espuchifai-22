-- Realizar los SP para dar de alta todas las entidades menos las tablas Cliente y Reproducción. En la tabla reproducción el SP se debe llamar ‘Reproducir’.
USE Espuchifai ;

DELIMITER $$
DROP PROCEDURE IF EXISTS altaBanda $$
CREATE PROCEDURE altaBanda (unidbanda SMALLINT UNSIGNED, unnombre VARCHAR(45), unafundacion YEAR)
BEGIN
INSERT INTO Banda (idbanda,nombre,fundacion)
VALUES (unidbanda,unnombre,unafundacion);
END $$ 

DELIMITER $$
DROP PROCEDURE IF EXISTS altaAlbum $$
CREATE PROCEDURE altaAlbum (unidalbum TINYINT UNSIGNED, unnombre VARCHAR(45),unlanzamiento DATE,unidbanda SMALLINT UNSIGNED) 
BEGIN
INSERT INTO Album (idalbum,nombre,lanzamiento,idbanda,cantidad)
VALUES (unidalbum,unnombre,unlanzamiento,unidbanda,0);
SET unidAlbum = LAST_INSERT_ID();
END $$ 
    
DELIMITER $$
DROP PROCEDURE IF EXISTS altaCancion $$
CREATE PROCEDURE altaCancion (unidcancion TINYINT UNSIGNED,unnombre VARCHAR(45),unnumorden INT UNSIGNED,unidalbum TINYINT UNSIGNED) 
BEGIN
INSERT INTO Cancion (idcancion,nombre,numorden,idalbum,cantidad)
VALUES (unidcancion,unnombre,unnumorden,unidalbum,0);
END $$ 

DELIMITER $$
DROP PROCEDURE IF EXISTS Reproducir $$
CREATE PROCEDURE Reproducir (unidreproduccion INT UNSIGNED,unidcliente INT UNSIGNED,unidcancion TINYINT UNSIGNED,unmomreproduccion DATETIME) 
BEGIN
INSERT INTO Reproduccion (idreproduccion,idcliente,idcancion,momreproduccion)
VALUES (unidreproduccion,unidcliente,unidCancion,unmomreproduccion);
END $$

-- 2) Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256
contrasenia
DELIMITER $$
DROP PROCEDURE IF EXISTS registrarCliente $$
CREATE PROCEDURE registrarCliente   (unidcliente INT UNSIGNED, unnombre VARCHAR(45), unapellido VARCHAR(45), unemail VARCHAR(45), unacontrasenia CHAR(60))
BEGIN
INSERT INTO Cliente (idcliente,nombre,apellido,email,contrasenia)
VALUES (unidcliente,unnombre,unapellido,unemail,SHA2(unaContrasenia,256));
END $$
    
-- 3) Se pide hacer el SF ‘CantidadReproduccionesBanda’ que reciba por parámetro un identificador de banda y 2 fechas,se debe devolver la cantidad de reproducciones que tuvieron las canciones de esa banda entre esas 2 fechas (inclusive).

DELIMITER $$

DROP FUNCTION IF EXISTS CantidadReproduccionesBanda $$
CREATE FUNCTION CantidadReproduccionesBanda (unidbanda SMALLINT UNSIGNED,uninicio DATETIME,unfin DATETIME) RETURNS INT reads sql data 
BEGIN 
DECLARE resultado INT;

SELECT COUNT(*) INTO resultado
FROM Reproduccion
    INNER JOIN Cancion USING(idcancion)
    INNER JOIN Album USING(idalbum)
WHERE idbanda = unidbanda
AND reproduccion BETWEEN uninicio and unfin;

RETURN resultado ;

END $$

-- 4) Se pide hacer el SP ‘Buscar’ que reciba por parámetro una cadena. El SP tiene que devolver las canciones que contengan la cadena en su título, nombre de álbum o nombre de banda

DELIMITER $$

DROP PROCEDURE IF EXISTS Buscar $$
CREATE PROCEDURE Buscar (cadena VARCHAR(45)) BEGIN
SELECT C.nombre,numorden,C.idalbum,C.idcancion
FROM Cancion C
JOIN Album USING (idalbum)
WHERE
MATCH (C.nombre, A.nombre, B.nombre) AGAINST (cadena);
END $$ 
