--Administrador
--Desde cualquier lado puede ver todas las tablas.
--Desde la terminal donde corre el sistema puede agregar y modificar bandas, álbumes y canciones.

USE Espuchifai;
DROP USER IF EXISTS 'Administrador'@'%';
CREATE USER 'Administrador'@'%' IDENTIFIED BY 'passAdministrador';
GRANT SELECT ON Espuchifai.* TO 'Administrador'@'%';
DROP USER IF EXISTS 'Administrador'@'LocalHost';
CREATE USER 'Administrador'@'LocalHost' IDENTIFIED BY 'passAdministrador';
GRANT INSERT, UPDATE ON Espuchifai.Banda TO 'Administrador'@'LocalHost';
GRANT INSERT, UPDATE ON Espuchifai.Album TO 'Administrador'@'LocalHost';
GRANT INSERT, UPDATE ON Espuchifai.Cancion TO 'Administrador'@'LocalHost';
--Banda: desde cualquier lado puede dar de alta álbumes, canciones y ver la tabla reproducciones.
DROP USER IF EXISTS 'Banda'@'%';
CREATE USER 'Banda'@'&' IDENTIFIED BY 'passBanda';
GRANT INSERT ON Espuchifai.Album TO 'Banda'@'&';
GRANT INSERT ON Espuchifai.Cancion TO 'Banda'@'&';
GRANT SELECT ON Espuchifai.Repreoduccion TO 'Banda'@'&';
--Cliente: desde cualquier lado puede ver su información personal, información de las bandas y álbumes. 
--Con respecto a las reproducciones puede verlas, agregar y eliminar.
DROP USER IF EXISTS 'Cliente'@'%';
CREATE USER 'Cliente'@'%' IDENTIFIED BY 'passCliente';
GRANT SELECT ON Espuchifai.Cliente TO 'Cliente'@'%';
GRANT SELECT ON Espuchifai.Banda TO 'Cliente'@'%';
GRANT SELECT ON Espuchifai.Album TO 'Cliente'@'%';
GRANT INSERT,SELECT,DELETE ON Espuchifai.Reproduccion TO 'Cliente'@'%';
