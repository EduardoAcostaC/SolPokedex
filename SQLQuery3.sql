CREATE DATABASE PokemonData;

USE PokemonData;

CREATE TABLE Pokemones(
	idPokemon INT IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(100) NOT NULL,
	tipo VARCHAR(100) NOT NULL,
	generacion INT NOT NULL,
	evoluciones INT NOT NULL,
	obtenido BIT NOT NULL,
	numeroPokemon VARCHAR(50) NOT NULL
);

SELECT * FROM Pokemones;

INSERT INTO Pokemones (nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon)
VALUES ('Pichu', 'Eléctrico', 1, 2, 1, 172 );

INSERT INTO Pokemones (nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon)
VALUES ('Squirtle', 'Agua', 1, 1, 0, 7 );

INSERT INTO Pokemones (nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon)
VALUES ('Charmander', 'Fuego', 2, 2, 1, 4 );

INSERT INTO Pokemones (nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon)
VALUES ('Bulbasaur', 'Agua', 1, 2, 0, 1 );

INSERT INTO Pokemones (nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon)
VALUES ('Wartortle', 'Agua', 1, 2, 0, 8 );

SELECT idPokemon, nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon 
FROM Pokemones;

SELECT idPokemon, nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon 
FROM Pokemones WHERE idPokemon = '6';

UPDATE Pokemones SET nombre = 'Sneasel', tipo = 'Siniestro', generacion = 2 , evoluciones = 1, obtenido = 0, numeroPokemon = '215'
WHERE idPokemon = 3;

DELETE Pokemones WHERE idPokemon = 10;