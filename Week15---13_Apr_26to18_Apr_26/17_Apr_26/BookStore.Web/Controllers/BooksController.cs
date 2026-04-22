using System.Text;
using System.Text.Json;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Web.Controllers;

public class BooksController : Controller
{
    private readonly HttpClient _http;
    private readonly string _apiBase;
    private static readonly JsonSerializerOptions _json = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public BooksController(IHttpClientFactory factory, IConfiguration config)
    {
        _http = factory.CreateClient();
        _apiBase =
            config["ApiBaseUrl"]
            ?? "https://bookstoreapi-mahesh-cfezgdemcuhda2h7.koreacentral-01.azurewebsites.net";
    }

    public async Task<IActionResult> Index()
    {
        var res = await _http.GetStringAsync($"{_apiBase}/books");
        var books = JsonSerializer.Deserialize<List<BookViewModel>>(res, _json) ?? [];
        return View(books);
    }

    public IActionResult Create() => View(new BookViewModel());

    [HttpPost]
    public async Task<IActionResult> Create(BookViewModel book)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(book),
            Encoding.UTF8,
            "application/json"
        );
        await _http.PostAsync($"{_apiBase}/books", content);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var res = await _http.GetStringAsync($"{_apiBase}/books");
        var books = JsonSerializer.Deserialize<List<BookViewModel>>(res, _json) ?? [];
        var book = books.FirstOrDefault(b => b.Id == id);
        return book is null ? NotFound() : View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, BookViewModel book)
    {
        var content = new StringContent(
            JsonSerializer.Serialize(book),
            Encoding.UTF8,
            "application/json"
        );
        await _http.PutAsync($"{_apiBase}/books/{id}", content);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _http.DeleteAsync($"{_apiBase}/books/{id}");
        return RedirectToAction(nameof(Index));
    }
}
