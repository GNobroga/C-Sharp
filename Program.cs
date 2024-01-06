using features;

/*
    Construtor primário, permite iniciar a classe como se fosse uma record.
*/
var f1 = new Features.ClassWithInitialConstructor("Gabriel", "Gabriel");

/*

    Novas funcionalidades na classe Random.Shared
*/

// Shuffle - Permite embaralhar um Array assim como no Python
Random.Shared.Shuffle(Features.Names);

Array.ForEach(Features.Names, Console.WriteLine);

// GetItems - Permite obter elementos de forma aleatória
Console.WriteLine();

Array.ForEach(Random.Shared.GetItems(Features.Names, 2), Console.WriteLine);

// {} é o mesmo que string.empty
Console.WriteLine(string.Empty is {});



