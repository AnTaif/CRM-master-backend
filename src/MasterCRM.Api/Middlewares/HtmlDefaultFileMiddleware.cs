namespace MasterCRM.Api.Middlewares;

public class HtmlDefaultFileMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;
        
        if (!path!.EndsWith("/") && !Path.HasExtension(path))
            context.Request.Path = new PathString(path + "/index.html");

        await next(context);
    }
}