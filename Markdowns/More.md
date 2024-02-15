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

Além disso é possível implementar um retry pra que a requisição seja feita novamente.

```cs
public class RetryDelegatingHandler : DelegatingHandler
{
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy =
        Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .RetryAsync(2);

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var policyResult = await _retryPolicy.ExecuteAndCaptureAsync(
            () => base.SendAsync(request, cancellationToken));

        if (policyResult.Outcome == OutcomeType.Failure)
        {
            throw new HttpRequestException(
                "Something went wrong",
                policyResult.FinalException);
        }

        return policyResult.Result;
    }
}
```

## FormUrlEncodedContent

Semelhante ao FormData do JavaScript permite enviar dados

```cs
    var form = new FormUrlEncodedContent(new Dictionary<string, string>() {});
```