using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Validators
{
    //Esta clase te permite hacer validaciones de parametos por DTOs usando la libreria *FluentValidation.AspNetCore*
   public class PostValidator : AbstractValidator<PostsDto>
    {
        public PostValidator()
        {// Valida que la descripcion no sea nula y que cumpla con el tamaño solicitado
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 250);
            // Valida que la fecha no sea nula
            RuleFor(post => post.Date)
                .NotNull();
        }
    }
}
