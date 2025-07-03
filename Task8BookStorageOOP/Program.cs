namespace BookStorage
{
    public class Program
    {
        public static void Main()
        {
            var bk = new BookStorage();
            var book1 = new Book("Тихий Дэн", "Ozon666Games", 2025, 1);
            var book2 = new Book("Биборан", "Абдуль", 2025, 2);
            var book3 = new Book("МайнКампф", "Адольф Гитлер", 2025, 3);
            var book4 = new Book("????", "Богатый папа, бедный папа", 2025, 4);
            bk.AddBook("Тихий Дэн", "Ozon666Games", 2025, 1);
            bk.AddBook("Биборан", "Абдуль", 2025, 2);
            while (true)
            {
                Console.WriteLine("Чтобы войти в систему управления библиотекой, нажмите ENTER");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Ваши действия?");
                    Console.WriteLine("1. Добавить книгу.");
                    Console.WriteLine("2. Убрать книгу из реестра.");
                    Console.WriteLine("3. Показать все книги.");
                    Console.WriteLine("4. Показать книги по параметрам");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true - чтобы клавиша не отображалась
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("Введите через запятую - НАЗВАНИЕ/АВТОР/ДАТА_РЕЛИЗА/ID");
                            string input = Console.ReadLine();
                            try
                            {
                                string[] parts = input.Split(',')
                                    .Select(p => p.Trim())
                                    .ToArray();
                                if (parts.Length == 4)
                                {
                                    string bookName = parts[0];
                                    string author = parts[1];

                                    DateTime releaseDate;
                                    if (!DateTime.TryParse(parts[2], out releaseDate))
                                    {
                                        Console.WriteLine(
                                            "Ошибка: неверный формат даты. Используйте дд/мм/гггг или дд-мм-гггг");
                                        return;
                                    }

                                    if (!int.TryParse(parts[3], out int bookUniqID))
                                    {
                                        Console.WriteLine("Ошибка: ID должен быть числом");
                                        return;
                                    }

                                    bk.AddBook(bookName, author, releaseDate.Year,
                                        bookUniqID);
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат ввода. Нужно ввести 4 значения через запятую.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }

                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("Введите ID удаляемой книги");
                            string input1 = Console.ReadLine();
                            if (input1 != null)
                            {
                                int BookUniqIDinput = int.Parse(input1);
                                bk.RemoveBook(BookUniqIDinput);
                            }

                            break;
                        case ConsoleKey.D3:
                            Console.WriteLine("Книги в реестре:");
                            bk.PrintBooks();
                            break;
                        case ConsoleKey.D4:
                            Console.WriteLine("ПАРАМЕТРЫ. Введите номер параметра:");
                            Console.WriteLine("1. Автор");
                            Console.WriteLine("2. Название");
                            Console.WriteLine("3. Дата релиза");
                            Console.WriteLine("4. По ID");

                            var searchKey = Console.ReadKey(true).Key;
                            Console.WriteLine(); // Переход на новую строку

                            List<Book> foundBooks = new List<Book>();
                            string searchTerm;

                            switch (searchKey)
                            {
                                case ConsoleKey.D1:
                                    Console.Write("Введите имя автора: ");
                                    searchTerm = Console.ReadLine();
                                    foundBooks = BookStorage.FindBooks(b => 
                                        b.Autor.ToLower().Contains(searchTerm.ToLower()));
                                    break;

                                case ConsoleKey.D2:
                                    Console.Write("Введите название книги: ");
                                    searchTerm = Console.ReadLine();
                                    foundBooks = BookStorage.FindBooks(b =>
                                        b.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase));
                                    break;

                                case ConsoleKey.D3:
                                    Console.Write("Введите год релиза (ГГГГ): ");
                                    if (int.TryParse(Console.ReadLine(), out int year))
                                    {
                                        foundBooks = BookStorage.FindBooks(b => b.RealeseDate == year);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный формат года!");
                                    }

                                    break;

                                case ConsoleKey.D4:
                                    Console.Write("Введите ID книги: ");
                                    if (int.TryParse(Console.ReadLine(), out int id))
                                    {
                                        foundBooks = BookStorage.FindBooks(b => b.BookUniqID == id);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID должен быть числом!");
                                    }

                                    break;

                                default:
                                    Console.WriteLine("Неверный выбор параметра!");
                                    break;
                            }
                            if (foundBooks.Any())
                            {
                                Console.WriteLine("\nНайдены книги:");
                                foreach (var book in foundBooks)
                                {
                                    Console.WriteLine(book);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Книги не найдены");
                            }
                            break;
                    }
                }
            }
        }
    }
}
