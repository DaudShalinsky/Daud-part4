using Microsoft.VisualBasic.FileIO;

public class WeatherJournal
{
    const string PATH = @"Weather.txt";
    const string DATE_FORMAT = "dd.MM.yyyy";

    private static DateTime GetDate ()
    {
        Console.Write("Дата: ");
        string? rawDate = Console.ReadLine();
        DateTime date;
        bool dateOk = DateTime.TryParse(rawDate, out date);

        if (dateOk == false)
        {
            return GetDate();
        }
        return date;
    }


    private static int? SelectMode()
    {
        // Просим ввести
        Console.Clear();
        Console.WriteLine("Выберите режим: ");
        Console.WriteLine("1 - Чтение");
        Console.WriteLine("2 - Запись");

        try
        {
            // Пытаемся получить числовое значение
            int? mode = Convert.ToInt32(Console.ReadLine());

            if (mode != 1 && mode != 2)
            {
                // Если ошибка, запускаем текущий метод, заново
                return SelectMode();
            }

            // Если код дошел сюда, возвращаем значение выбранного режима
            return mode;
        }
        catch (Exception ex)
        {
            // Если ошибка, запускаем текущий метод, заново
            return SelectMode();
        }
    }

    public static void Start()
    {
        // Выбор режима
        int? mode = SelectMode();

        switch (mode)
        {
            case 1:
                Console.WriteLine("Введите дату:");
                string? selectedDate = Console.ReadLine();
                string? contents;
                try
                {
                    contents = File.ReadAllText(PATH);
                }
                catch (Exception)
                {
                    Console.WriteLine("Не удалось прочитать файл, проверь свой компьютер, очисти от пыли");
                    Console.ReadKey();
                    Start();
                    return;
                }

                string[] entries = contents.Split("\r\n");

                bool found = false;

                for (int i = 0; i < entries.Length - 1; i++)
                {
                    string entry = entries[i];

                    if (entry.Contains(selectedDate))
                    {
                        found = true;
                        string[] data = entry.Split(" ");
                        Console.WriteLine($"Дата: {data[0]}, Погода: {data[3]}, Температура: {data[1]}°C, Влажность: {data[2]}%.");
                    }
                }

                if (found == false)
                {
                    Console.WriteLine("Нет данных.");
                }

                Console.ReadKey();
                Start();

                break;
            case 2:
                Console.WriteLine("Введите информацию о погоде:");

                DateTime date = GetDate();
            
                Console.Write("Температура: ");
                string? temperature = Console.ReadLine();

                Console.Write("Влажность: ");
                string? humidity = Console.ReadLine();

                Console.Write("Описание: ");
                string? description = Console.ReadLine();

                /*
                    1. определить путь
                    2. создать или открыть файл
                    3. записать данные в формате:
                        11.11.2012 30 45 Солнечно
                        12.11.2012 30 45 Дождь
                */

                try
                {
                    File.AppendAllText(PATH, $"{date.ToString(DATE_FORMAT)} {temperature} {humidity} {description}\r\n");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Нет доступа к указанному пути");
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Возникла непонятная ошибка");
                    return;
                }

                Console.WriteLine("Строка успешно добавлена в файл");
                Console.ReadKey();
                Start();

                break;
        }
    }
}
