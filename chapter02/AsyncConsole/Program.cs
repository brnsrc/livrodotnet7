HttpClient client = new();
HttpResponseMessage response = await client.GetAsync("https://www.pelando.com.br");
WriteLine("Apple's home page has {0:N0} bytes.", response.Content.Headers.ContentLength);

var x = 5;
var y = 3;

var resulingOfAdding = x + y;
var resultMultiplying = x * y;

WriteLine(resulingOfAdding);
WriteLine(resultMultiplying);


