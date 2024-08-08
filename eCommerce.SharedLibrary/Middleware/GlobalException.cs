using Microsoft.AspNetCore.Http;
using System.Net;

namespace eCommerce.SharedLibrary.Middleware
{
    public class GlobalException(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            //Declare variables 
            string message = "sorry, internal server error occirred. Kindly try again";
            int statusCOde = (int) HttpStatusCode.InternalServerError;
            string title = "Error";

            try
            {
                await next(context);

                //check if exception is too Many requests //429
                if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    title = "Warning";
                    message = "Too many requets";
                }

            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
