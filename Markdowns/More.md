## IMemoryCache

O C# provê um recurso de cache em memória não distribuído para utilizar.

```cs
    builder.Services.AddMemoryCache();


    class MyService(IMemoryCache cache)
    {
        
    }
```