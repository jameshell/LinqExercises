// See https://aka.ms/new-console-template for more information
using LinqExercises;

LinqQueries queries = new LinqQueries();
PrintValues(queries.AllCollection());

void PrintValues(IEnumerable<Book> bookList)
{
    Console.WriteLine("{0,-60} {1, 15} {2,15}\n", "Title", "Num Of Pages", "Publish Date");
    foreach (var item in bookList)
    {
        Console.WriteLine(
            "{0,-60} {1, 15} {2,15}",
            item.title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}