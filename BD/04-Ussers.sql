--Administrador
--Desde cualquier lado puede ver todas las tablas.
--Desde la terminal donde corre el sistema puede agregar y modificar bandas, álbumes y canciones.
CREATE USER IF NOT EXISTS Administrador@% IDENTIFIED BY '1111';
GRANT SELECT ON Espuchifai.* TO Administrador;
GRANT INSERT,UPDATE ON Espuchifai.Bandas TO Administrador;
GRANT INSERT,UPDATE ON Espuchifai.Albunes TO Administrador;
GRANT INSERT,UPDATE ON Espuchifai.Canciones TO Administrador;
--Banda: desde cualquier lado puede dar de alta álbumes, canciones y ver la tabla reproducciones.
CREATE USER IF NOT EXISTS Banda@% IDENTIFIED BY '2222';
GRANT INSERT,SELECT ON Espuchifai.Banda TO Banda;
GRANT INSERT,SELECT ON Espuchifai.Album TO Banda;
GRANT INSERT,SELECT ON Espuchifai.Cancion TO Banda;
--Cliente: desde cualquier lado puede ver su información personal, información de las bandas y álbumes. 
--Con respecto a las reproducciones puede verlas, agregar y eliminar.
CREATE USER IF NOT EXISTS Cliente@% IDENTIFIED BY '3333';
GRANT SELECT ON Espuchifai.Cliente TO Cliente;
GRANT SELECT ON Espuchifai.BandaTO Cliente;
GRANT SELECT ON Espuchifai.Album TO Cliente;
GRANT INSEERT,SELECT,DELETE ON Espuchifai.Reproduccion TO Cliente;