

--  *********************************  CONSULTAS ****************************************************



-- Consulta para Obtener el Producto con mayor cantidad en el stock

CREATE proc [dbo].[ProductoMayorStock]

as
select top 1 NombreProducto as [Nombre del Producto], sum(Stock) as [Total en Stock] from Productos
group by NombreProducto
ORDER BY [Total en Stock] DESC;


-- Consulta para Obtener el Producto con mayor Venta

CREATE proc [dbo].[ProductoMayorVenta]

as
select top 1 Producto, sum(Cantidad) as [Total ventas] from N_Venta
group by Producto
ORDER BY [Total ventas] DESC;