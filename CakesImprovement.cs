internal class CakesImprovement
{
    const string path = @"CakesPrice.txt";
    private static int? SelectMode()
    {
        Console.WriteLine("Выберите режим: ");
        Console.WriteLine("1 - Выбор торта");
        Console.WriteLine("2 - Внести в прайс новый");
        try
        {
            int? mode = Convert.ToInt32(Console.ReadLine());

            if (mode != 1 && mode != 2)
            {
                return SelectMode();
            }
            return mode;
        }
        catch (Exception)
        {
            return SelectMode();
        }
    }

    private static decimal Prise()
    {
        Console.WriteLine("Цена торта: ");
        decimal price;
        try
        {
            price = Convert.ToDecimal(Console.ReadLine());
        }
        catch (Exception)
        {
            return Prise();
        }
        return price;
    }


    public static void Start()
    {
        int? mode = SelectMode();

        switch (mode)
        {
            case 1:
                Console.WriteLine("Введите название торта: ");
                string? selectedName = Console.ReadLine();

                string contents = File.ReadAllText(path);
                string[] entries = contents.Split("\r\n");

                bool found = false;

                for (int i = 0; i < entries.Length - 1; i++)
                {
                    string entry = entries[i].ToLower();

                    if (entry.Contains(selectedName.ToLower()))
                    {
                        found = true;
                        string[] data = entry.Split(" ");
                        Console.WriteLine($"Название торта: {data[0]}, Цена: {data[1]} руб.");
                    }
                }
                if (found == false)
                {
                    Console.WriteLine("Нет такого торта");
                }
                Console.ReadKey();
                Start();
                break;

            case 2:
                Console.WriteLine("Введите данные о торте");

                Console.Write("Название торта: ");
                string? date = Console.ReadLine();

                decimal price = Prise();

                try
                {
                    File.AppendAllText(path, $"{date} {price}\r\n");
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

                Console.WriteLine("Данные о торте успешно добавлены в файл");
                Console.ReadKey();
                Start();

                break;
        }
    }
}
