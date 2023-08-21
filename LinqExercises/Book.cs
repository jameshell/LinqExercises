namespace LinqExercises;

public class Book
{
    public string? title { get; set; } = String.Empty;
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string? ShortDescription { get; set; }
    public string? Status { get; set; }
    public string[]? Authors { get; set; } = Array.Empty<string>();
    public string[]? Categories { get; set; } = Array.Empty<string>();
}