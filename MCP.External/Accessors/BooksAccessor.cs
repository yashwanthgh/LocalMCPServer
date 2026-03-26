using MCP.External.Data;
using MCP.External.Entities;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace MCP.External.Accessors
{
    [McpServerToolType]
    public class BooksAccessor
    {
        #region Private Methods

        private async Task<List<Book>> GetBooks()
        {
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(BooksStaticResource.BooksJson));
            var jsonDoc = await JsonDocument.ParseAsync(stream);
            var booksElement = jsonDoc.RootElement.GetProperty("books");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var books = JsonSerializer.Deserialize<List<Book>>(booksElement.GetRawText(), options);
            return books ?? new List<Book>();
        }

        private async Task<string> GetBooksAsString(List<Book>? books)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var booksToSerialize = books ?? new List<Book>();
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, booksToSerialize, options);
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        #endregion

        #region Public Methods

        [McpServerTool, Description("Get all books")]
        public async Task<string> GetAllBooks()
        {
            return await GetBooksAsString(await GetBooks());
        }

        [McpServerTool, Description("Get books by category")]
        public async Task<string> GetBooksByCategory(string category)
        {
            var books = await GetBooks();
            var filteredBooks = books.Where(book => book.Genre != null && book.Genre.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            return await GetBooksAsString(filteredBooks);
        }

        #endregion
    }
}
