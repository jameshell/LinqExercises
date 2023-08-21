// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using LinqExercises;

LinqQueries queries = new();
// PrintValues(queries.AllCollection());

// Filter By Date Exercise
// PrintValues(queries.BooksFilteredByDateYearExp( before: new DateTime(2010, 11, 1)));

// Filter by amount of pages and title exercise
PrintValues(queries.BooksFilteredByPages(416, "Android"));
void PrintValues(IEnumerable<Book> bookList)
{
    var books = bookList.ToList();
    Console.WriteLine($"Total Items = {books.Count}");
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n", "Title", "Num Of Pages", "Publish Date");
    foreach (var item in books)
    {
        Console.WriteLine(
            "{0,-60} {1, 15} {2,15}",
            item.title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}