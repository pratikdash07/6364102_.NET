-- 1. ROW_NUMBER(): Unique rank within each category
SELECT 
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum
FROM Products;

-- 2. RANK(): Handles ties with gaps
SELECT 
    ProductName,
    Category,
    Price,
    RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum
FROM Products;

-- 3. DENSE_RANK(): Handles ties without gaps
SELECT 
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
FROM Products;

-- 4. Top 3 most expensive products in each category using DENSE_RANK()
WITH RankedProducts AS (
    SELECT 
        ProductName,
        Category,
        Price,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE DenseRankNum <= 3;
