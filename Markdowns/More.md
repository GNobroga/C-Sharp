## IMemoryCache

O C# provê um recurso de cache em memória não distribuído para utilizar.

```cs
    builder.Services.AddMemoryCache();


    class MyService(IMemoryCache cache)
    {
        
    }
```

## DelegatingHandler

Essa classe permite interceptar requisições http, utilizando http client. Por exemplo, adicionar o token no authorization header.

```cs
    builder.Services.AddHttpClient<MyService>(options => {
        options.BaseAddress = new Uri("api_address");
    }).AddHttpMessageHandler<MyDelegatingHandler>();
```