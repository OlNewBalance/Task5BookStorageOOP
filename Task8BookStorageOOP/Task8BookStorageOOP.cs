namespace BookStorage;

public class Book
{
    public string Name;
    public string Autor;
    public int RealeseDate;
    public int BookUniqID;

    public Book(string name, string autor, int realeseDate, int bookUniqID)
    {
        Name = name;
        Autor = autor;
        RealeseDate = realeseDate;
        BookUniqID = bookUniqID;
    }

    public override string ToString()
    {
        return $"Название: {Name}, Автор: {Autor}, Год: {RealeseDate}, ID: {BookUniqID}";
    }
}

public class BookStorage
{
    static List<Book> booksStorage = new List<Book>();

    public void AddBook(string bookName, string autor, int realeseDate, int bookUniqID)
    {
        if (!booksStorage.Any(b => b.BookUniqID == bookUniqID))
        {
            Book book = new Book(bookName, autor, realeseDate, bookUniqID);
            booksStorage.Add(book);
            Console.WriteLine($"В библиотеке появилась новая книга! Книга: {book.Name}");
        }
        else
        {
            Console.WriteLine($"К сожалению... Таковая книга уже имеется: {booksStorage[bookUniqID].Name}...");
        }
    }

    public void RemoveBook(int bookUniqID)
    {
        var bookToRemove = booksStorage.FirstOrDefault(b => b.BookUniqID == bookUniqID);
        if (bookToRemove != null)
        {
            booksStorage.Remove(bookToRemove);
            Console.WriteLine($"Книга \"{bookToRemove.Name}\" только что была убрана с полок.");
        }
        else
        {
            Console.WriteLine($"Книга с ID {bookUniqID} не найдена!");
        }
    }

    public void PrintBooks()
    {
        if (booksStorage.Count > 0)
        {
            foreach (var book in booksStorage)
            {
                Console.WriteLine($"Все книги на полках: {book}");
            }
        }
        else
        {
            Console.WriteLine("На полках нет книг!");
        }
    }

    public static List<Book> FindBooks(Func<Book, bool> predicate)
    {
        if (booksStorage == null)
        {
            throw new InvalidOperationException("Хранилище книг не инициализировано");
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate), "Условие поиска не может быть null");
        }

        try
        {
            return booksStorage
                .AsParallel() // Параллельная обработка для больших коллекций
                .Where(predicate)
                .ToList();
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            Console.WriteLine($"Ошибка при поиске книг: {ex.Message}");
            return new List<Book>(); // Возвращаем пустой список вместо исключения
        }
    }
}
