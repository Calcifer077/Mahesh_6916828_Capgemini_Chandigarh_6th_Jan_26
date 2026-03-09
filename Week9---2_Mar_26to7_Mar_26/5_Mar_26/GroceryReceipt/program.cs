class GroceryReceipt2 : GroceryReceiptBase2
{
    public GroceryReceipt2(Dictionary<string, decimal> prices, Dictionary<string, int> discounts)
        : base(prices, discounts)
    {
    }

    public override IEnumerable<(string fruit, decimal price, decimal total)>
        Calculate(List<Tuple<string, int>> shoppingList)
    {
        var res = new List<(string fruit, decimal price, decimal total)>();

        foreach (var item in shoppingList)
        {
            string fruit = item.Item1;
            int quantity = item.Item2;

            decimal price = Prices[fruit];
            int discount = 0;

            if (Discounts.ContainsKey(fruit))
                discount = Discounts[fruit];

            decimal total = price * quantity * (1 - discount / 100m);

            res.Add((fruit, price, total));
        }

        res.Sort((a, b) => a.fruit.CompareTo(b.fruit));

        return res;
    }
}