namespace WebApplication1.Middlewares
{
    public class ShabbatMiddelware
    {
        private readonly RequestDelegate _next;
        public ShabbatMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("middleware start");
            var isShabbat= DateTime.Today.DayOfWeek == DayOfWeek.Saturday;
/*                       isShabbat = true;
*/            if (isShabbat)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                Console.WriteLine("Shabbat today!!!");
                return;
            }
            await _next(context);

        }
    }
}
