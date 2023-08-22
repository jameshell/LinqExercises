// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using LinqExercises;

LinqQueries queries = new();
// PrintValues(queries.AllCollection());

// Filter By Date Exercise
// PrintValues(queries.BooksFilteredByDateYearExp( before: new DateTime(2010, 11, 1)));

// Filter by amount of pages and title exercise
// PrintValues(queries.BooksFilteredByPages(416, "Android"));


// Filter by Status - Check if all boos have a status
// Console.WriteLine(queries.BooksFilteredByStatus());

// Filter by Year of publish - Check if at least 1 book was publish in said year.
// Console.WriteLine(queries.BooksFilteredByDatePublished(new DateTime(2011, 01, 22)));

// Filter By Categories
// PrintValues(queries.BooksFilteredByCategory("Python"));

// Filter by Categories and Order Alphabetically
// PrintValues(queries.BooksFilteredByCategoryOrderedByName("Java"));

// Filter by number of pages and in descending order.
PrintValues(queries.BooksFilteredByPagesInDescendingOrder(450));

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