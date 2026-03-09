public class Inventory : IInventory
{
    private List<IProduct> _products = new List<IProduct>();

    public void AddProduct(IProduct product)
    {
        _products.Add(product);
    }

    public void RemoveProduct(IProduct product)
    {
        _products.Remove(product);
    }

    public int CalculateTotalValue()
    {
        int res = 0;

        foreach (var el in _products)
        {
            res += el.Price * el.Stock;
        }

        return res;
    }

    public List<IProduct> GetProductsByCategory(string category)
    {
        var res = new List<IProduct>();

        foreach (var el in _products)
        {
            if (el.Category == category)
                res.Add(el);
        }

        return res;
    }

    public List<IProduct> SearchProductsByName(string name)
    {
        var res = new List<IProduct>();

        foreach (var el in _products)
        {
            if (el.Name == name)
                res.Add(el);
        }

        return res;
    }

    public List<(string, int)> GetProductsByCategoryWithCount()
    {
        var dict = new Dictionary<string, int>();

        foreach (var el in _products)
        {
            if (dict.ContainsKey(el.Category))
                dict[el.Category]++;
            else
                dict.Add(el.Category, 1);
        }

        var res = new List<(string, int)>();

        foreach (var el in dict)
        {
            res.Add((el.Key, el.Value));
        }

        return res;
    }

    public List<(string, List<IProduct>)> GetAllProductsByCategory()
    {
        var dict = new Dictionary<string, List<IProduct>>();

        foreach (var el in _products)
        {
            if (dict.ContainsKey(el.Category))
            {
                dict[el.Category].Add(el);
            }
            else
            {
                dict[el.Category] = new List<IProduct> { el };
            }
        }

        var res = new List<(string, List<IProduct>)>();

        foreach (var el in dict)
        {
            res.Add((el.Key, el.Value));
        }

        return res;
    }
}