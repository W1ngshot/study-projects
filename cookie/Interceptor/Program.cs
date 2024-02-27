using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8080/"); // Указываем адрес, на котором будет слушать сервер
listener.Start();

Console.WriteLine("Сервер запущен. Ожидание запросов...");

while (true)
{
    var context = listener.GetContext(); // Получаем контекст запроса

    // Получаем все куки из заголовков запроса
    var cookies = context.Request.Cookies;

    // Обрабатываем каждую куку
    foreach (Cookie cookie in cookies)
    {
        // Выполняем действия с кукой (например, выводим ее значения)
        Console.WriteLine($"Имя куки: {cookie.Name}, Значение: {cookie.Value}");
    }

    // Отправляем пустой ответ
    context.Response.Close();
}