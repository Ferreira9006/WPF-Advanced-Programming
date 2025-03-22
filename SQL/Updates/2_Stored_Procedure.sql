GO
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