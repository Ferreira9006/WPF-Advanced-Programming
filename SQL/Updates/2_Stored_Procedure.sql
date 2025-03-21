GO
CREATE PROCEDURE ListarVendas 
@dataInicio datetime, @dataFim datetime
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