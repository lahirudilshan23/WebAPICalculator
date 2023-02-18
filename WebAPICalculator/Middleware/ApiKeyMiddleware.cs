using JsonFlatFileDataStore;

namespace WebAPICalculator.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private
        const string APIKEY = "x-api-key";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var extractHeader = context.Request.Headers.Where(x => x.Key == APIKEY);

            if (extractHeader == null || !extractHeader.Any())
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }

            string extractedApiKey = extractHeader.First().Value;

            var store = new DataStore("db.json");

            string apiKey = store.GetItem<string>("apiKey");

            if (!apiKey.Equals(extractedApiKey.ToString()))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}
