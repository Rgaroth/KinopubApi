# KinopubApi
Для того, чтобы создать клиент используйте KinopubClientBuilder:

   var client = KinopubClientBuilder.CreateBuilder()
            .AddApiKeys("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET")
            .UseHttpClient(httpClient)
            .UseHttpClientHandler(httpClientHandler)
            .Build();
