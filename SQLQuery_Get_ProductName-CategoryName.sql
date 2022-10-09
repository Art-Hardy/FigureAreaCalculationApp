USE Store

SELECT P.Name, C.Name
FROM Products as P
LEFT JOIN ProductsCategories as PC on P.Id = PC.ProductId
LEFT JOIN Categories as C on PC.CategoryId = C.Id
GROUP BY P.Name, C.Name