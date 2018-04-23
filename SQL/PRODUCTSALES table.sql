create proc POWERBANKEN.Insert_ProductSales(
@sku nvarchar(20),
@quantity	int,
@date	date
)
as
begin
INSERT INTO POWERBANKEN.PRODUCTSALES (sku, quantity, periodend) VALUES (@sku, @quantity, @date)
end
