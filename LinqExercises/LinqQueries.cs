using System.Collections;
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
    
    // Method Extension Approach
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
    public IEnumerable<Book> BooksFilteredByDateYearExp(DateTime? after = null, DateTime? before = null)
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

    // Method Extension Approach
    public IEnumerable<Book> BooksFilteredByPages(int? pagesCount = null, string? title = null)
    {
        if (pagesCount == null && title == null) throw new ArgumentNullException(nameof(BooksFilteredByDateYear));
        IEnumerable<Book> filteredBooks = new List<Book>();
        if (pagesCount != null && title != null)
        {
            filteredBooks = _booksCollection
                .Where(b => b.PageCount >= pagesCount)
                .Where(b => b.title != null && b.title.Contains(title));
        }
        else if(pagesCount != null)
        {
            filteredBooks = _booksCollection.Where(b => b.PageCount >= pagesCount);
        } else if (title != null)
        {
            filteredBooks = _booksCollection.Where(b => b.title != null && b.title.Contains(title));
        }

        return filteredBooks;
    }
    
    // Query Expression Approach
    public IEnumerable<Book> BooksFilteredByPagesExp(int? pagesCount = null, string? title = null)
    {
        if (pagesCount == null && title == null) throw new ArgumentNullException(nameof(BooksFilteredByDateYear));
        IEnumerable<Book> filteredBooks = new List<Book>();
        if (pagesCount != null && title != null)
        {
            filteredBooks = from l in _booksCollection
                where l.PageCount >= pagesCount && l.title != null && l.title.Contains(title)
                select l;
        }
        else if(pagesCount != null)
        {
            filteredBooks = from l in _booksCollection where l.PageCount >= pagesCount
                select l;
        } else if (title != null)
        {
            filteredBooks = from l in _booksCollection
                where l.title != null && l.title.Contains(title)
                select l;
        }

        return filteredBooks;
    }
    
    // Method Extension Approach
    public bool BooksFilteredByStatus()
    {
        return _booksCollection.All(b => !string.IsNullOrWhiteSpace(b.Status));
    }
    
    // Method Extension Approach
    public bool BooksFilteredByDatePublished(DateTime date)
    {
        return _booksCollection.Any(b => b.PublishedDate.Year == date.Year);
    }
    
    // Method Extension Approach
    public IEnumerable<Book> BooksFilteredByCategory(string category)
    {
        return _booksCollection.Where(b => b.Categories != null && b.Categories.Contains(category));
    }
    
    // Method Extension Approach
    public IEnumerable<Book> BooksFilteredByCategoryOrderedByName(string category)
    {
        return _booksCollection
            .Where(b => b.Categories != null && b.Categories.Contains(category))
            .OrderBy(b => b.title);
    }
    
    // Method Extension Approach
    public IEnumerable<Book> BooksFilteredByPagesInDescendingOrder(int pages)
    {
        return BooksFilteredByPages(pages).OrderByDescending(b => b.PageCount);
    }
    
    // Method Extension Approach
    public IEnumerable<Book> TopXBooksFilteredByDateAndCategory(int total, string category)
    {
        return _booksCollection
            .Where(b => b.Categories != null && b.Categories.Contains(category))
            .OrderByDescending(b => b.PublishedDate)
            .Take(total);
    }
    
    public IEnumerable<Book> AllCollection()
    {
        return _booksCollection;
    }
}