----------------------------------------DROPS--------------------------------------------------
BEGIN
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Venda]') AND type in (N'U'))
DROP TABLE [dbo].[Venda]
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Marca]') AND type in (N'U'))
DROP TABLE [dbo].[Marca]
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vendedor]') AND type in (N'U'))
DROP TABLE [dbo].[Vendedor]


END

----------------------------------------CREATES----------------------------------------------------------
CREATE TABLE [dbo].[Vendedor] (
    [VendedorID] INT PRIMARY KEY,  
    [Nome] NVARCHAR(250) NULL,
    [Foto] NVARCHAR(250) NULL
) ;

CREATE TABLE [dbo].[Marca] (
    [MarcaID] INT PRIMARY KEY, 
    [Descricao] NVARCHAR(250) NULL
) ;

CREATE TABLE [dbo].[Venda] (
    [VendaID] INT PRIMARY KEY, 
    [Data] DATETIME NULL,
    [Preco] REAL NULL,
    [VendedorID] INT NOT NULL,
    [MarcaID] INT NOT NULL,
    FOREIGN KEY (VendedorID) REFERENCES Vendedor(VendedorID),
    FOREIGN KEY (MarcaID) REFERENCES Marca(MarcaID)
) ;


-------------------------------------INSERTS----------------------
-- Inserir 10 Vendedores
INSERT INTO [dbo].[Vendedor] ([VendedorID], [Nome], [Foto])
VALUES 
    (1, 'Joao Silva', 'C:\Fotos\JoaoSilva.jpg'),
    (2, 'Maria Oliveira', 'C:\Fotos\MariaOliveira.jpg'),
    (3, 'Carlos Pereira', 'C:\Fotos\CarlosPereira.jpg'),
    (4, 'Ana Costa', 'C:\Fotos\AnaCosta.jpg'),
    (5, 'Lucas Souza', 'C:\Fotos\LucasSouza.jpg'),
    (6, 'Roberta Lima', 'C:\Fotos\RobertaLima.jpg'),
    (7, 'Felipe Almeida', 'C:\Fotos\FelipeAlmeida.jpg'),
    (8, 'Larissa Rocha', 'C:\Fotos\LarissaRocha.jpg'),
    (9, 'Thiago Martins', 'C:\Fotos\ThiagoMartins.jpg'),
    (10, 'Patricia Pereira', 'C:\Fotos\PatriciaPereira.jpg');



	INSERT INTO [dbo].[Marca] ([MarcaID], [Descricao]) 
VALUES 
    (1, 'Toyota'),
    (2, 'Honda'),
    (3, 'Ford'),
    (4, 'Chevrolet'),
    (5, 'Volkswagen'),
    (6, 'BMW'),
    (7, 'Mercedes-Benz'),
    (8, 'Audi'),
    (9, 'Nissan'),
    (10, 'Hyundai');


-- Inserir 1000 vendas com dados manuais para VendaID
DECLARE @i INT = 1;

WHILE @i <= 1000
BEGIN
    DECLARE @VendaData DATETIME = DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 365), GETDATE());  -- Gera uma data aleatória entre hoje e um ano atrás
    DECLARE @Preco DECIMAL(10, 2) = CAST((RAND() * (100000 - 40000) + 40000) AS DECIMAL(10, 2));  -- Preço aleatório entre 40.000 e 100.000
    DECLARE @VendedorID INT = (ABS(CHECKSUM(NEWID())) % 10) + 1;  -- Vendedor aleatório de 1 a 10
    DECLARE @MarcaID INT = (ABS(CHECKSUM(NEWID())) % 10) + 1;  -- Marca aleatória de 1 a 10

    -- Inserir a venda, agora incluindo o VendaID manualmente
    INSERT INTO [dbo].[Venda] ([VendaID], [Data], [Preco], [VendedorID], [MarcaID])
    VALUES (@i, @VendaData, @Preco, @VendedorID, @MarcaID);
    
    SET @i = @i + 1;  -- Incrementar o VendaID manualmente
END


