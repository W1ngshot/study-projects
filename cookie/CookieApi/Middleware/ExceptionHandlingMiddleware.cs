using System.ComponentModel.DataAnnotations;

namespace CookieApi.Middleware;

public class ExceptionHandlingMiddleware
{
    public readonly RequestDelegate Next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new {ex.Message});
        } 
        catch (FluentValidation.ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { Message = "Внутренняя ошибка сервера" });
        }
    }
}