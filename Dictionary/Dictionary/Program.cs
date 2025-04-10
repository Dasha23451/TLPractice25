class Program
{
    private static Dictionary<string, string> dictionary = new Dictionary<string, string>();
    private static string dictionaryFile = "dictionary.txt";
    private static char separator = ':';

    static void PrintMenu()
    {
        Console.WriteLine( "Добро пожаловать в словарь!" );
        Console.WriteLine( "Доступные команды:" );
        Console.WriteLine( "1. Перевести слово" );
        Console.WriteLine( "2. Добавить слово" );
        Console.WriteLine( "3. Выход" );
        Console.Write( "Введите номер команды: " );
    }

    static void LoadDictionary()
    {
        if ( !File.Exists( dictionaryFile ) )
        {
            Console.WriteLine( "Файл словаря не найден. Будет создан новый." );
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines( dictionaryFile );
            foreach ( var line in lines )
            {
                if ( string.IsNullOrWhiteSpace( line ) )
                    continue;

                var parts = line.Split( separator );
                if ( parts.Length == 2 )
                {
                    dictionary[ parts[ 0 ].Trim().ToLower() ] = parts[ 1 ].Trim().ToLower();
                    dictionary[ parts[ 1 ].Trim().ToLower() ] = parts[ 0 ].Trim().ToLower();
                }
            }

            Console.WriteLine( $"Словарь загружен. Всего слов: {dictionary.Count / 2}" );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Ошибка при загрузке словаря: {ex.Message}" );
        }
    }

    static void SaveDictionary()
    {
        try
        {
            var uniquePairs = new HashSet<string>();

            foreach ( var pair in dictionary )
            {
                if ( !uniquePairs.Contains( $"{pair.Value}{separator}{pair.Key}" ) )
                {
                    uniquePairs.Add( $"{pair.Key}{separator}{pair.Value}" );
                }
            }

            File.WriteAllLines( dictionaryFile, uniquePairs );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Ошибка при сохранении словаря: {ex.Message}" );
        }
    }

    static void TranslateWord()
    {
        Console.Write( "Введите слово, перевод которого вы хотите получить: " );
        string word = Console.ReadLine();
        if ( string.IsNullOrWhiteSpace( word ) )
        {
            Console.WriteLine( "Слово не может быть пустым." );
            return;
        }
        string lowerWord = word.ToLower();

        if ( dictionary.TryGetValue( lowerWord, out string translation ) )
        {
            Console.WriteLine( $"Перевод: {translation}" );
        }
        else
        {
            Console.WriteLine( $"Слово '{word}' не найдено в словаре." );
            Console.Write( "Хотите добавить его в словарь? (y/n) (д/н): " );
            var response = Console.ReadLine().Trim().ToLower();

            if ( response == "y" || response == "д" )
            {
                Console.Write( $"Введите перевод для '{word}': " );
                string newTranslation = Console.ReadLine().Trim();
                AddWord( $"{word}{separator}{newTranslation}" );
                Console.WriteLine( "Перевод добавлен." );
            }
            else
            {
                Console.WriteLine( $"Слово {word} было проигнорировано" );
            }
        }
    }

    static void AddWord( string wordPair )
    {
        var parts = wordPair.Split( separator );
        if ( parts.Length != 2 )
        {
            Console.WriteLine( "Неверный формат. Используйте слово:перевод" );
            return;
        }

        string word = parts[ 0 ].Trim().ToLower();
        string translation = parts[ 1 ].Trim().ToLower();

        if ( string.IsNullOrWhiteSpace( word ) || string.IsNullOrWhiteSpace( translation ) )
        {
            Console.WriteLine( "Слово и перевод не могут быть пустыми." );
            return;
        }

        dictionary[ word ] = translation;
        dictionary[ translation ] = word;

        Console.WriteLine( $"Слово '{word}' и его перевод '{translation}' добавлены в словарь." );
    }

    static void Main( string[] args )
    {
        LoadDictionary();

        string comand = "0";
        bool flag = true;
        string word;

        while ( flag )
        {
            PrintMenu();
            comand = Console.ReadLine().Trim();

            switch ( comand )
            {
                case "1":
                    TranslateWord();
                    break;
                case "2":
                    Console.WriteLine( "Ввдедите слово с переводом в формате: слово:перевод " );
                    word = Console.ReadLine();
                    AddWord( word );
                    break;
                case "3":
                    flag = false;
                    break;
                default:
                    Console.WriteLine( "Неизвестная команда." );
                    break;
            }

            SaveDictionary();

            Console.WriteLine( "______________________________________________________________________________________" );
        }

        Console.WriteLine( "Словарь сохранен. До свидания!" );
    }
}