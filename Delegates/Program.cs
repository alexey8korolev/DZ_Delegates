using Delegates.Extensions;
using Delegates.FileWork;


Console.WriteLine("!!!Запуск приложения!!!");
string catalog = Directory.GetCurrentDirectory();
Console.WriteLine($"Поиск файлов в папке: {catalog}");

FileProcessr fileProcessor = new();
fileProcessor.Cancellation = false;
fileProcessor.FileFound += FileProcessor_FileFound;
fileProcessor.Find(catalog);


Console.WriteLine("");
Console.WriteLine("Нажмите клавишу, чтобы узнать максимальный элемент");
Console.ReadLine();

// коллекция элементов для поиска максимального
var floats = new List<string>() { "1", "7", "33,6", "-207" , "1.2"};
var maxNum = floats.GetMax<string>(MaxFloat);

Console.WriteLine($"Максимальный элемент {maxNum}");
Console.WriteLine("!!!Окончание работы!!!");



static void FileProcessor_FileFound(object? sender, FileEventArgs e)
{
    //найденный результат выводим в консоль (имя, путь, размер, дата создания файла)
    Console.WriteLine("-->" + e.FileEventInfo.Name + " " + e.FileEventInfo.Length + "_байт"
    + " Создан: " + e.FileEventInfo.CreationTime);

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Продолжить поиск файлов (Д/Н) ?");

        var cmd = Console.ReadLine()!.Trim().ToUpper();

        if (cmd != "Д" && cmd != "Н")
        {
            Console.WriteLine("Введите корректный запрос : Д:(Да), Н:(Нет)");
        }
        else if (cmd == "Д")
        {
            ((FileProcessr)sender!).Cancellation = false;
            break;
        }
        else
        {
            ((FileProcessr)sender!).Cancellation = true;
            return;
        }
    }
}


float MaxFloat<T>(T values)
{
    if (float.TryParse(values!.ToString(), out var num))
    { return num; }
    else
    { return 0; }
}
