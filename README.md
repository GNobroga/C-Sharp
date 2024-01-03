# Novidades C# 12 e Formas de otimizar o código

### Logs

No ASP NET não é mais necessário injetar interface ILogger para se obter uma instância de Logger, agora é possível
utilizar **Attribute**.

Exemplo:

```cs
    public static partial class Log 
    {
        [LoggerMessage(EventId = 0, Level = LogLevel.Error, Message = "An error occurred")]
        public static partial Error(this ILogger, string YourMessage);
    }
```

### Conditions

Agora é possível fazer condições utilizando um nível mais elevado de sintaxe.

```cs
    if (score is >= 60 and <= 100)
    {
        Console.WriteLine("Make Something");
    }
```

### Primary Constructors

Essa funcionalidade permite utilizar uma classe de forma semelhante a um record. 

Obs: Como é um construtor primário é permitido utilizar ele pra injetar dependências.

```cs
    public class PrimaryConstructor(string arg1, string arg2)
    {
        public string ArgUpper => arg1.ToUpper();
        public string ArgLower => arg2.ToLower();
    }
```


### Spread Operator

Assim como no JavaScript, agora no C# é possível utilizar o operador spread que é denotado com **..**. Além disso,
uma nova forma de se declarar Arrays e Lists surgiu que usando o **[]**.


```cs
    List<string> names = ["Gabriel", "Lívia", "Children"];

    List<string> expandFamily = [..names, "Claudio", "José", "Wilson", "Chimbinha"];
```

### Random

Dentro da classe Random tem a classe **Shared** que contém métodos generics úteis para randomificação distribuída.

**Shuffle** - Permite embaralhar um Array (Apenas Array)

```cs
    string[] names = ["Gabriel", "Lívia", "Children"];

    Random.Shared.Shuffle(names);

    Array.ForEach(names, Console.WriteLine);
```

**GetItems** - Permite obter elementos de um Enumerable de forma aleatória.

```cs
    string[] names = ["Gabriel", "Lívia", "Children"];

    Array.ForEach(Random.Shared.GetItems(names, 2), Console.WriteLine);
```
<<<<<<< HEAD:RADME.md

#### Otimization Comparison

```cs
    public bool TheNamesIsSimilar(string first, string second)
    {
        return string.Equals(first, second, StringComparsion.OrdinalIgnoreCase);
    }
```


### Null Condition Operator

Permite navegar sobre propriedades de um objeto que pode ser nulo, mas sem gerar Exception. Isso evita a utilização de **If** desnecessários.

```cs
    customer?.Orders?.Ship();
```

### Null Argument Checks 

**ArgumentNullException** é uma classe que contém metódos pra validar objetos nulos.


```cs
    public void MapTo <T> (T source) where T: class
    {
        ArgumentNullException.ThrowIfNull(source);
    }
```

### Parallel ForEach Loop

Permite executar um loop ForEach de forma assincrona, dividindo em threads, muito útil para operações custosas.

```cs
   List<string> paths = GetFilePathList();

   Parallel.ForEach(paths, CompressFile);
```

### Cancel Tasks 

No Javascript tem o **AbortController** no C# tem o **CancellationTokenSource** pra cancelar operações assincronas por meio de Task. Lembrando que isso não funciona com TaskValue, inclusive, isso é uma das diferenças entre utilizar Task e TaskValue.

```cs

    CancellationTokenSource tokenSource = new()/
    CancellationToken token = tokenSource.Token;

    Task task = Task.Run(async () => 
    {
        await using var reader = new("./file.txt");

        while (reader.ReadLine() is {} line && !token.IsCancellationRequested)
        {
            Console.WriteLine(line);
        }
        
    }, token);

```

