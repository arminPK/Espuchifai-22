USE Espuchifai;

CALL altaBanda ('BABYMETAL', '2010', @bandaBABYMETAL);
CALL altaAlbum ('Metal Galaxi', '2019-10-08', @bandaBABYMETAL, @albumMetalGalaxi);
CALL altaAlbum ('Babymetal', '2014-02-26', @bandaBABYMETAL, @albumBabymetal);
CALL altaCancion ('Onedari Daisakusen', 1, @albumBabymetal, @OnedariDaisakusen);
CALL altaCancion ('Gimme Chocolate!', 2, @albumBabymetal, @GimmeChocolate);
CALL altaCancion ('Doki Doki Morning', 3, @albumBabymetal, @DokiDokiMorning);
CALL altaCancion ('Oh! MAJINAI ', 1, @albumMetalGalaxi, @OhMAJINAI);
CALL altaCancion ('PA PA YA!!', 2, @albumMetalGalaxi, @PAPAYA);
CALL altaCancion ('Distortion', 3, @albumMetalGalaxi, @Distortion);
CALL registrarCliente( 'Armin', 'Mercado', 'armin.mercado@gmail.com', 'Armin123', @ClienteArmin);
CALL Reproducir (now(), @GimmeChocolate, @ClienteArmin);
CALL Reproducir (now(), @DokiDokiMorning, @ClienteArmin);
CALL Reproducir (now(), @OhMAJINAI, @ClienteArmin);