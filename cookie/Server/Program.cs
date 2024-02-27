using System.Net;
using System.Text;

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8000/");
listener.Start();

Console.WriteLine("Сервер запущен. Ожидание запросов...");

while (true)
{
    var context = listener.GetContext(); 
    
    var cookie = new Cookie("MyCookie", "Hello, World!");
    
    context.Response.Headers.Add("Set-Cookie", cookie.ToString());
    
    var responseBytes = "Cookie added"u8.ToArray();
    context.Response.ContentLength64 = responseBytes.Length;
    context.Response.ContentEncoding = Encoding.UTF8;
    context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);

    context.Response.Close();
}