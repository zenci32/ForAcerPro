using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.NewsRepository.Validation
{
    internal class NewsValidator:AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.NewsContent).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.NewsTitle).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.NewsTitle).MaximumLength(250).WithMessage("250 Karakterden Fazla Olamaz");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Boş Geçilemez");
        }
    }
}
