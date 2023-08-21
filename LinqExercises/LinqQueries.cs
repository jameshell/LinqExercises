using System.Runtime.InteropServices;
using System.Text.Json;

namespace LinqExercises;

public class LinqQueries
{
    private readonly List<Book> _booksCollection;
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
    
    // Extension Approach
    public IEnumerable<Book> BooksFilteredByDateYear(DateTime? after = null, DateTime? before = null)
    {
        if (after == null && before == null) throw new ArgumentNullException(nameof(BooksFilteredByDateYear));
        IEnumerable<Book> filteredBooks = new List<Book>();
        if (after != null && before != null)
        {
            filteredBooks = _booksCollection
                .Where(b => b.PublishedDate.Year > after?.Year && b.PublishedDate.Year < before?.Year);
        }
        else if(after != null)
        {
            filteredBooks = _booksCollection.Where(b => b.PublishedDate.Year > after?.Year);
        } else if (before != null)
        {
            filteredBooks = _booksCollection.Where(b => b.PublishedDate.Year < before?.Year);
        }

        return filteredBooks;
    }
    
    // Query Expression approach
    public IEnumerable<Book> BooksFilteredByDateYearEx(DateTime? after = null, DateTime? before = null)
    {
        if (after == null && before == null) throw new ArgumentNullException(nameof(BooksFilteredByDateYear));
        IEnumerable<Book> filteredBooks = new List<Book>();
        if (after != null && before != null)
        {
            filteredBooks = from b in _booksCollection
                where b.PublishedDate.Year > after?.Year && b.PublishedDate.Year < before?.Year
                select b;
        }
        else if(after != null)
        {
            filteredBooks = from b in _booksCollection
                where b.PublishedDate.Year > after?.Year
                select b;
        } else if (before != null)
        {
            filteredBooks = from b in _booksCollection
                where b.PublishedDate.Year < before?.Year
                select b;
        }

        return filteredBooks;
    }

    public IEnumerable<Book> AllCollection()
    {
        return _booksCollection;
    }
}