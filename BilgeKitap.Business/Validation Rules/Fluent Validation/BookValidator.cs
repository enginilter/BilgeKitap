using BilgeKitap.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BilgeKitap.Business.Validation_Rules.Fluent_Validation
{
    public class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            //RuleFor(b => b.BookName).NotEmpty();
            //RuleFor(b => b.NumberOfPages).NotEmpty();
            //RuleFor(b => b.Price).NotEmpty();
            //RuleFor(b => b.AuthorId).NotEmpty();
        }
   
    }
}
