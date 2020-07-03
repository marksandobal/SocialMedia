using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Filters
{  // Esta clase crea un filtro de validacion general con los DataAnnotations en los DTOs. Se crea la instancia en el Startup.cs
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // validamos que cumpla con las anotaciones expuestas en el modelo DTO
            if (!context.ModelState.IsValid)
            {// Si no cumple con las anotaciones, retorna un BadRequest y el error del DTO
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }
            // Si cumple, simplemente continua con el request.
            await next();
        }
    }
}
