create proc POWERBANKEN.UPDATE_PRODUCT
(
@id	int,
@name	nvarchar(max),
@sku	nvarchar(20),
@price	float, 
@stockamount	int, 
@minstock	int, 
@maxstock	int,
@productionhours	float,
@isactive	bit
)
as 
begin 
UPDATE POWERBANKEN.PRODUCT
SET PRODUCTNAME = @name, SKU = @sku, PURCHASEPRICE = @price, AMOUNT = @stockamount, MINSTOCK = @minstock, MAXSTOCK = @maxstock, PRODUCTIONINHOURS = @productionhours, ACTIVE = @isactive
WHERE PRODUCT.PRODUCTID = @id
END