while (true)
{
    Console.WriteLine("Введите число от 1 до 7");
    var symbol = Console.ReadLine();

    if(int.TryParse(symbol, out var number))
    {
        string dayName;

        switch (number)
        {
            case 1:
                dayName = "Понедельник";
                break;
            case 2:
                dayName = "Вторник";
                break;
            case 3:
                dayName = "Среда";
                break;
            case 4:
                dayName = "Четверг";
                break;
            case 5:
                dayName = "Пятница";
                break;
            case 6:
                dayName = "Суббота";
                break;
            case 7:
                dayName = "Воскресение";
                break;
            default:
                Console.WriteLine($"Ошибка. {number} - число не входит в диапазон [1,7]");
                continue;
        }

        Console.WriteLine($"{number} - {dayName}");
    }
    else
    {
        Console.WriteLine($"Ошибка. {symbol} - не является корректным значением");
    }
}