using Infrastructure.Models;
using Infrastructure.Services;

for (;;)
{
    var libr = new BookService();
    Console.WriteLine("for show books enter : 1");
    Console.WriteLine("for show add book enter : 2");
    Console.WriteLine("for show update book enter : 3");
    Console.WriteLine("for show delete book enter : 4");
    Console.WriteLine("exite : 0");
    Console.Write("command : ");
    int command = Convert.ToInt32(Console.ReadLine());
    if (command == 1)
    {
        foreach (var VARIABLE in libr.getBooks())
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"Id : '{VARIABLE.Id}'");
            Console.WriteLine($"Title : '{VARIABLE.Title}'");
            Console.WriteLine($"Author : '{VARIABLE.Author}'");
            Console.WriteLine($"Description : '{VARIABLE.Description}'");
            Console.WriteLine($"Price: '{VARIABLE.Price}'");

        }
        Console.WriteLine("------------------------------------------------------");
    }

    else if (command == 2)
    {
        var bb = new Book();
        Console.Write($"Title : ");
        bb.Title = Console.ReadLine();
        Console.Write($"Author : ");
        bb.Author = Console.ReadLine();
        Console.Write($"Description : ");
        bb.Description = Console.ReadLine();
        Console.Write($"Price: ");
        bb.Price = Convert.ToDecimal(Console.ReadLine());
        libr.addBook(bb);
    }
    else if (command == 3)
    {
        var bb = new Book();
        Console.Write($"Id : ");
        bb.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write($"Title : ");
        bb.Title = Console.ReadLine();
        Console.Write($"Author : ");
        bb.Author = Console.ReadLine();
        Console.Write($"Description : ");
        bb.Description = Console.ReadLine();
        Console.Write($"Price: ");
        bb.Price = Convert.ToDecimal(Console.ReadLine());
        libr.updateBook(bb);
    }
    else if (command == 4)
    {
        Console.Write($"Id : ");
        int id = Convert.ToInt32(Console.ReadLine());
        libr.deleteBook(id);
    }
    else if (command == 0)break;
}
