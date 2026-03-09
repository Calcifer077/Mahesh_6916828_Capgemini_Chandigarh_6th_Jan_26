public class LibrarySystem : ILibrarySystem
{
    private Dictionary<IBook, int> _books = new Dictionary<IBook, int>();

    public void AddBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
            _books[book] += quantity;
        else
            _books.Add(book, quantity);
    }

    public void RemoveBook(IBook book, int quantity)
    {
        if (_books.ContainsKey(book))
        {
            if (_books[book] <= quantity)
                _books.Remove(book);
            else
                _books[book] -= quantity;
        }
    }

    public int CalculateTotal()
    {
        int res = 0;

        foreach (var el in _books)
        {
            res += el.Key.Price * el.Value;
        }

        return res;
    }

    public List<(string, int)> CategoryTotalPrice()
    {
        var dict = new Dictionary<string, int>();

        foreach (var el in _books)
        {
            var total = el.Key.Price * el.Value;

            if (dict.ContainsKey(el.Key.Category))
                dict[el.Key.Category] += total;
            else
                dict.Add(el.Key.Category, total);
        }

        return dict.Select(x => (x.Key, x.Value)).ToList();
    }

    public List<(string, int, int)> BooksInfo()
    {
        var res = new List<(string, int, int)>();

        foreach (var el in _books)
        {
            res.Add((el.Key.Title, el.Value, el.Key.Price));
        }

        return res;
    }

    public List<(string, string, int)> CategoryAndAuthorWithCount()
    {
        var result = new List<(string, string, int)>();

        var grouped = _books
            .GroupBy(x => new { x.Key.Category, x.Key.Author });

        foreach (var group in grouped)
        {
            int count = group.Sum(x => x.Value);
            result.Add((group.Key.Category, group.Key.Author, count));
        }

        return result;
    }
}