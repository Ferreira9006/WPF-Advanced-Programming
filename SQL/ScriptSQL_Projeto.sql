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
    [NomeVendedor] NVARCHAR(250) NULL,
    [Foto] NVARCHAR(250) NULL
) ;

CREATE TABLE [dbo].[Marca] (
    [MarcaID] INT PRIMARY KEY, 
    [DescricaoMarca] NVARCHAR(250) NULL
) ;

CREATE TABLE [dbo].[Venda] (
    [VendaID] INT PRIMARY KEY, 
    [DataVenda] DATETIME NULL,
    [Preco] REAL NULL,
    [VendedorID] INT NOT NULL,
    [MarcaID] INT NOT NULL,
    FOREIGN KEY (VendedorID) REFERENCES Vendedor(VendedorID),
    FOREIGN KEY (MarcaID) REFERENCES Marca(MarcaID)
) ;


-------------------------------------INSERTS----------------------
-- Inserir 10 Vendedores
INSERT INTO [dbo].[Vendedor] ([VendedorID], [NomeVendedor], [Foto])
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



	INSERT INTO [dbo].[Marca] ([MarcaID], [DescricaoMarca]) 
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

GO

-------------------------------PROCEDURES----------------------
CREATE PROCEDURE ListarVendas 
AS

BEGIN
SELECT 
    v.VendaID, 
    v.DataVenda, 
    v.Preco, 
    ve.NomeVendedor,
    m.DescricaoMarca
FROM Venda v
JOIN Marca m ON v.MarcaID = m.MarcaID
JOIN Vendedor ve ON v.VendedorID = ve.VendedorID

END
GO


-------- Inserir 100 vendas com dados manuais para VendaID
DECLARE @i INT = 1;

WHILE @i <= 100
BEGIN
    DECLARE @VendaData DATETIME = DATEADD(DAY, -ABS(CHECKSUM(NEWID()) % 365), GETDATE());  -- Gera uma data aleat ria entre hoje e um ano atr s
    DECLARE @Preco DECIMAL(10, 2) = CAST((RAND() * (100000 - 20000) + 20000) AS DECIMAL(10, 2));  -- Pre o aleat rio entre 20.000 e 100.000
    DECLARE @VendedorID INT = (ABS(CHECKSUM(NEWID())) % 10) + 1;  -- Vendedor aleat rio de 1 a 10
    DECLARE @MarcaID INT = (ABS(CHECKSUM(NEWID())) % 10) + 1;  -- Marca aleat ria de 1 a 10

    -- Inserir a venda, agora incluindo o VendaID manualmente
    INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID])
    VALUES (@i, @VendaData, @Preco, @VendedorID, @MarcaID);
    
    SET @i = @i + 1;  -- Incrementar o VendaID manualmente
END

-------- Inserir valores para datas recentes
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (101, '2025-05-15', 75151, 7, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (102, '2025-05-16', 50534, 7, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (103, '2025-05-17', 97337, 7, 9);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (104, '2025-05-18', 44669, 2, 6);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (105, '2025-05-19', 25816, 9, 10);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (106, '2025-05-20', 97192, 10, 6);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (107, '2025-05-21', 91217, 2, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (108, '2025-05-22', 31862, 4, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (109, '2025-05-23', 84106, 7, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (110, '2025-05-24', 55536, 5, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (111, '2025-05-25', 93981, 8, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (112, '2025-05-26', 41626, 2, 2);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (113, '2025-05-27', 97806, 2, 5);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (114, '2025-05-28', 67131, 8, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (115, '2025-05-29', 40777, 6, 9);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (116, '2025-05-30', 87608, 5, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (117, '2025-05-31', 99655, 10, 7);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (118, '2025-06-01', 86138, 6, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (119, '2025-06-02', 94098, 10, 8);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (120, '2025-06-03', 92511, 8, 6);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (121, '2025-06-04', 77186, 5, 2);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (122, '2025-06-05', 33933, 6, 5);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (123, '2025-06-06', 76822, 3, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (124, '2025-06-07', 31925, 7, 7);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (125, '2025-06-08', 53873, 3, 9);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (126, '2025-06-09', 70689, 4, 6);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (127, '2025-06-10', 68286, 5, 6);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (128, '2025-06-11', 74023, 6, 7);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (129, '2025-06-12', 65049, 4, 8);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (130, '2025-06-13', 89617, 4, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (131, '2025-06-14', 24927, 8, 2);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (132, '2025-06-15', 66537, 1, 3);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (133, '2025-06-16', 57294, 2, 2);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (134, '2025-06-17', 78965, 5, 8);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (135, '2025-06-18', 68126, 2, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (136, '2025-06-19', 84713, 8, 8);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (137, '2025-06-20', 74230, 10, 10);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (138, '2025-06-21', 34592, 10, 10);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (139, '2025-06-22', 24802, 1, 2);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (140, '2025-06-23', 39981, 9, 2);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (141, '2025-06-24', 54529, 3, 8);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (142, '2025-06-25', 65797, 1, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (143, '2025-06-26', 85741, 9, 5);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (144, '2025-06-27', 98331, 6, 3);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (145, '2025-06-28', 49089, 6, 4);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (146, '2025-06-29', 33425, 7, 1);
INSERT INTO [dbo].[Venda] ([VendaID], [DataVenda], [Preco], [VendedorID], [MarcaID]) VALUES (147, '2025-06-30', 22126, 10, 4);

