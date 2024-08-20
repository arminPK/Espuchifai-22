USE Espuchifai ;

/* 1) Cada vez que se inserta una reproducción, se incrementa el contador de reproducciones de la canción en uno.*/

DELIMITER $$
DROP TRIGGER IF EXISTS AfInsReproduccion $$
CREATE TRIGGER AfInsReproduccion AFTER INSERT ON Reproduccion 
FOR EACH ROW 
BEGIN
    UPDATE Cancion
    SET cantidad = cantidad + 1
    WHERE idcancion = new.idcancion;
END $$

-- 2) Cada vez que se actualiza el contador de la canción en N reproducciones, se incrementa el contador del álbum también en N.

DELIMITER $$

CREATE TRIGGER incrementaReproduccionAlbum
AFTER UPDATE ON Cancion
FOR EACH ROW
BEGIN
    DECLARE incremento INT;
    SET incremento = NEW.cantidad - OLD.cantidad;
    IF incremento > 0 THEN
        UPDATE Album
        SET cantidad = cantidad + incremento
        WHERE idalbum = NEW.idalbum;
    END IF;
END $$

DELIMITER ;
