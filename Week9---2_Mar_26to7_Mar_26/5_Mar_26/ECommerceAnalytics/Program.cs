class Product : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

class Category : ICategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IProduct> Products { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
        Products = new List<IProduct>();
    }

    public void AddProduct(IProduct product)
    {
        Products.Add(product);
    }
}

class Company : ICompany
{
    private List<ICategory> categories = new List<ICategory>();
    public int Id { get; set; }
    public string Name { get; set; }

    public Company(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddCategory(ICategory category)
    {
        categories.Add(category);
    }

    // Category with most products
    public string GetTopCategoryNameByProductCount()
    {
        int max = -1;
        string result = "";

        foreach (var c in categories)
        {
            if (c.Products.Count > max)
            {
                max = c.Products.Count;
                result = c.Name;
            }
        }

        return result;
    }

    // Products belonging to multiple categories
    public List<IProduct> GetProductsBelongsToMultipleCategory()
    {
        Dictionary<int, int> productCount = new Dictionary<int, int>();
        Dictionary<int, IProduct> productMap = new Dictionary<int, IProduct>();

        foreach (var c in categories)
        {
            foreach (var p in c.Products)
            {
                if (!productCount.ContainsKey(p.Id))
                {
                    productCount[p.Id] = 0;
                    productMap[p.Id] = p;
                }

                productCount[p.Id]++;
            }
        }

        List<IProduct> result = new List<IProduct>();

        foreach (var item in productCount)
        {
            if (item.Value > 1)
                result.Add(productMap[item.Key]);
        }

        return result;
    }

    // Category with highest total product price
    public (string categoryName, decimal totalValue) GetTopCategoryBySumOfProductPrices()
    {
        string name = "";
        decimal max = -1;

        foreach (var c in categories)
        {
            decimal sum = 0;

            foreach (var p in c.Products)
                sum += p.Price;

            if (sum > max)
            {
                max = sum;
                name = c.Name;
            }
        }

        return (name, max);
    }

    // Each category with total price
    public List<(ICategory category, decimal totalValue)> GetCategoriesWithSumOfTheProductPrices()
    {
        List<(ICategory category, decimal totalValue)> result =
            new List<(ICategory category, decimal totalValue)>();

        foreach (var c in categories)
        {
            decimal sum = 0;

            foreach (var p in c.Products)
                sum += p.Price;

            result.Add((c, sum));
        }

        return result;
    }
}