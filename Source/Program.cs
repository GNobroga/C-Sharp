// using features;

// /*
//     Construtor primário, permite iniciar a classe como se fosse uma record.
// */
// var f1 = new Features.ClassWithInitialConstructor("Gabriel", "Gabriel");

// /*

//     Novas funcionalidades na classe Random.Shared
// */

// // Shuffle - Permite embaralhar um Array assim como no Python
// Random.Shared.Shuffle(Features.Names);

// Array.ForEach(Features.Names, Console.WriteLine);

// // GetItems - Permite obter elementos de forma aleatória
// Console.WriteLine();

// Array.ForEach(Random.Shared.GetItems(Features.Names, 2), Console.WriteLine);

// // {} é o mesmo que string.empty
// Console.WriteLine(string.Empty is {});


// Span<string> values = ["asa", "sas"," as"];

// Console.WriteLine(values.ContainsAny("asa", "as"));


/* Property Pattern */

var p = new Product("Celular", 1000, "LIMPEZA");

if (p is { Category: "LIMPEZA", Price: >= 1000 })
{
    Console.WriteLine("SIM");
}

public class Product(string name, decimal price, string category)
{
    public string Name { get; set; } = name;

    public decimal Price { get; set; } = price;
    public string Category { get; set; } = category;
}