using System.Text.Json;

namespace LinqExercises;

public class LinqQueries
{
    private List<Book> _booksCollection = new();
    public LinqQueries()
    {
        using (var reader = new StreamReader("books.json"))
        {
            var json = reader.ReadToEnd();
            this._booksCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
    }

    public IEnumerable<Book> AllCollection()
    {
        return _booksCollection;
    }
}