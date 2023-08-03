
/* Creacion de tablas */

CREATE TABLE Categoria(
CategoriaId int NOT NULL IDENTITY,
NomCategoria nvarchar(120) NOT NULL,
FechCreacion datetime2 NOT NULL
);

CREATE TABLE Producto(
ProductoId int NOT NULL IDENTITY,
NomProducto nvarchar(150) NOT NULL,
DesProducto nvarchar(200) NOT NULL,
StockProducto int NOT NULL,
Precio numeric(9,2),
FechProducto datetime2 NOT  NULL,
ImagenUrl nvarchar(200),
CategoriaId int NOT NULL
);

/* Definir las claves primarias de la tabla Categoria y Producto */

ALTER TABLE Categoria
ADD CONSTRAINT PK_Categoria PRIMARY KEY (CategoriaId);

ALTER TABLE Producto
ADD CONSTRAINT PK_Producto PRIMARY KEY (ProductoId);

/* Definimos la clave foranea de la tabla Producto */

ALTER TABLE Producto
ADD CONSTRAINT FK_Producto_Categoria_CategoriaId FOREIGN KEY (CategoriaId)
REFERENCES Categoria (CategoriaId) ON DELETE CASCADE

/* Registramos datos en la tabla Producto y Categoria */

INSERT INTO Categoria(NomCategoria, FechCreacion)
VALUES ('Limpieza','01-08-2023');

INSERT INTO Categoria(NomCategoria, FechCreacion)
VALUES ('Licores','02-08-2023');

INSERT INTO Categoria(NomCategoria, FechCreacion)
VALUES ('Abarrotes','03-08-2023');

INSERT INTO Producto (NomProducto, DesProducto, StockProducto, Precio, FechProducto, CategoriaId)
VALUES ('Pisco', 'Whisky BLACK WHISKEY Botella 700ml', 20, 15.5, '02-08-2023', 2);

INSERT INTO Producto (NomProducto, DesProducto, StockProducto, Precio, FechProducto, CategoriaId)
VALUES ('Arroz', 'Arroz Extra COSTEÑO Bolsa 5Kg', 10, 5.5, '03-08-2023', 3);

INSERT INTO Producto (NomProducto, DesProducto, StockProducto, Precio, FechProducto, CategoriaId)
VALUES ('Suavitel', 'Suavizante SUAVITEL Fresca Primavera Botella 2.8L', 15, 10.5, '01-08-2023', 1);

/* Realizamos la consultas de las tablas Producto y Categoria */

SELECT * FROM Categoria;

SELECT * FROM Producto;