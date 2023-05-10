# KinopubApi
Для того, чтобы создать клиент используйте KinopubClientBuilder:

	var client = KinopubClientBuilder.CreateBuilder()
      .AddApiKeys("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET")
      .UseHttpClient(httpClient)
      .UseHttpClientHandler(httpClientHandler)
      .Build();

Если у вас еще нет accessToken, то для регистрации устройства нужно будет ввести на сайте сгенерированный код.
Код получается посредством вызова метода клиента:

	var response = await client.GetDeviceCodeAsync();

	if (response.IsSuccess)
	{
		var code = response.Data;
	}
	
Далее полученный код нужно ввести на сайте Кинопаб в разделе добавления устройств.
Как только Вы добавите устройство, свойство IsAuthenticated станет true. Можно его как угодно ожидать, хоть в цикле, хоть в таймере, например:

	while (!client.IsAuthenticated)
	{
		await Task.Delay(1000);
	}
	
После этого будут доступны AccessToken и RefreshToken (свойства клиента). Их можно сохранить, чтобы потом использовать их при аутентификации. 
Чтобы использовать токены, клиент создается таким образом:

	var client = KinopubClientBuilder.CreateBuilder()
		.AddApiKeys("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET")
		.UseHttpClient(httpClient)
		.UseHttpClientHandler(httpClientHandler)
		.UseToken("YOUR_ACCESS_TOKEN", "YOUR_REFRESH_TOKEN");
		
Клиент сразу будет аутентифицирован (IsAuthenticated == true), и Вы можете использовать процессоры для обращения к API, например:

Получим информацию о текущем устройстве:

	var response = await _client.DevicesProcessor.GetCurrentDeviceInfoAsync();

## Процессоры
Разделы документации API Кинопаба реализованы процессорами с такими же именами. Вот все реализованные:

	public IAuthProcessor AuthProcessor { get; private set; }
	public IUserProcessor UserProcessor { get; private set; }
	public IReferencesProcessor ReferencesProcessor { get; private set; }
	public IDevicesProcessor DevicesProcessor { get; private set; }
	public IVideoContentProcessor VideoContentProcessor { get; private set; }
