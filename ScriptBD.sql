CREATE DATABASE abccCoppel;

USE abccCoppel;

GO

CREATE TABLE Clase (
  Num_Clase INT NOT NULL IDENTITY(1,1) CONSTRAINT [CK_Num_Clase] CHECK (Num_Clase >= 0 AND Num_Clase < 100),
  Nombre_Clase VARCHAR(50) NOT NULL,
  PRIMARY KEY (Num_Clase)
);

CREATE TABLE Departamento (
  Num_Departamento INT NOT NULL IDENTITY(1,1) CONSTRAINT [CK_Num_Departamento] CHECK (Num_Departamento >= 0 AND Num_Departamento < 10),
  Nombre_Departamento VARCHAR(50) NOT NULL,
  PRIMARY KEY (Num_Departamento)
);

CREATE TABLE Familia (
  Num_Familia INT NOT NULL IDENTITY(1,1) CONSTRAINT [CK_Num_Familia] CHECK (Num_Familia >= 0 AND Num_Familia < 1000),
  Nombre_Familia VARCHAR(50) NOT NULL,
  PRIMARY KEY (Num_Familia)
);

CREATE TABLE Productos (
  Sku INT NOT NULL IDENTITY(1,1) CONSTRAINT [CK_Sku] CHECK ([Sku] >= 0 AND [Sku] < 1000000),
  Articulo VARCHAR(15) NOT NULL,
  Marca VARCHAR(15) NOT NULL,
  Modelo VARCHAR(20) NOT NULL,
  Num_Departamento INT NOT NULL CONSTRAINT [CK_Departamento] CHECK (Num_Departamento >= 0 AND Num_Departamento < 10),
  Num_Clase INT NOT NULL CONSTRAINT [CK_Clase] CHECK (Num_Clase >= 0 AND Num_Clase < 100),
  Num_Familia INT NOT NULL CONSTRAINT [CK_Familia] CHECK (Num_Familia >= 0 AND Num_Familia < 1000),
  Fecha_Alta DATE NOT NULL,
  Stock INT NOT NULL CONSTRAINT [CK_Stock] CHECK (Stock >= 0 AND Stock < 1000000000),
  Cantidad INT NOT NULL CONSTRAINT [CK_Cantidad] CHECK (Cantidad >= 0 AND Cantidad < 1000000000),
  Descontinuado INT NOT NULL CONSTRAINT [CK_Descontinuado] CHECK (Descontinuado >= 0 AND Descontinuado < 10),
  Fecha_Baja DATE,
  PRIMARY KEY (Sku),
  FOREIGN KEY (Num_Clase) REFERENCES Clase(Num_Clase),
  FOREIGN KEY (Num_Departamento) REFERENCES Departamento(Num_Departamento),
  FOREIGN KEY (Num_Familia) REFERENCES Familia(Num_Familia)
);

GO
-- INSERCIONES DE ALGUNOS DATOS EN LAS TABLAS

INSERT INTO Clase (Nombre_Clase) VALUES 
  ('Comestibles'),
  ('Licuadoras'),
  ('Balon'),
  ('Pantalon')
 ;

 INSERT INTO Departamento (Nombre_Departamento) VALUES 
  ('Electrónica'),
  ('Hogar'),
  ('Ropa'),
  ('Deportes')
 ;

 INSERT INTO Familia (Nombre_Familia) VALUES 
  ('Televisores'),
  ('Celulares'),
  ('Muebles'),
  ('Electrodomésticos'),
  ('Ropa para hombres'),
  ('Ropa para mujeres'),
  ('Fútbol'),
  ('Basketball')
 ;

 INSERT INTO Productos (Articulo, Marca, Modelo, Num_Departamento, Num_Clase, Num_Familia, Fecha_Alta, Stock, Cantidad, Descontinuado) VALUES
 ('iPhone', 'Apple', 'X', 1, 2, 2, GETDATE(), 100, 100, 0),
 ('LicuaMax', 'Samsung', 'Pro', 1, 2, 4, GETDATE(), 50, 50, 0)
 ;

 GO

 -- SELECT * FROM Productos;

 --	 PROCEDIMIENTOS ALMACENADOS
CREATE PROCEDURE ObtenerTodosLosProductos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM Productos;
END;
GO

CREATE PROCEDURE ObtenerProductoPorSku
    @sku INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT *
    FROM Productos
    WHERE Sku = @sku;
END
GO

CREATE PROCEDURE InsertarProducto
    @Articulo VARCHAR(15),
    @Marca VARCHAR(15),
    @Modelo VARCHAR(20),
    @Num_Departamento INT,
    @Num_Clase INT,
    @Num_Familia INT,
    @Fecha_Alta DATE,
    @Stock INT,
    @Cantidad INT,
    @Descontinuado INT
AS
BEGIN
    INSERT INTO Productos (Articulo, Marca, Modelo, Num_Departamento, Num_Clase, Num_Familia, Fecha_Alta, Stock, Cantidad, Descontinuado)
    VALUES (@Articulo, @Marca, @Modelo, @Num_Departamento, @Num_Clase, @Num_Familia, @Fecha_Alta, @Stock, @Cantidad, @Descontinuado)
END
GO

CREATE PROCEDURE ActualizarProducto
    @Sku INT,
    @Articulo VARCHAR(15),
    @Marca VARCHAR(15),
    @Modelo VARCHAR(20),
    @Num_Departamento INT,
    @Num_Clase INT,
    @Num_Familia INT,
    @Fecha_Alta DATE,
    @Stock INT,
    @Cantidad INT,
    @Descontinuado INT
AS
BEGIN
    UPDATE Productos
    SET Articulo = @Articulo,
        Marca = @Marca,
        Modelo = @Modelo,
        Num_Departamento = @Num_Departamento,
        Num_Clase = @Num_Clase,
        Num_Familia = @Num_Familia,
        Fecha_Alta = @Fecha_Alta,
        Stock = @Stock,
        Cantidad = @Cantidad,
        Descontinuado = @Descontinuado
    WHERE Sku = @Sku
END
GO

CREATE PROCEDURE BorrarProducto
    @Sku INT
AS
BEGIN
    DELETE FROM Productos
    WHERE Sku = @Sku
END
GO

-- USO DE PROCEDIMIENTOS
EXECUTE ObtenerTodosLosProductos;
GO

EXECUTE ObtenerProductoPorSku 1;
GO

EXECUTE InsertarProducto 
    @Articulo = 'Mochila escolar',
    @Marca = 'Nike',
    @Modelo = 'Schoolpack',
    @Num_Departamento = 1,
    @Num_Clase = 1,
    @Num_Familia = 1,
    @Fecha_Alta = GETDATE(),
    @Stock = 20,
    @Cantidad = 20,
    @Descontinuado = 0;
GO

EXECUTE BorrarProducto @Sku = 2;
GO
