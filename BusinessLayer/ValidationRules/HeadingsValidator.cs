using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingsValidator:AbstractValidator<Heading>
    {

        public HeadingsValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Boş Geçemezsiniz.");
            RuleFor(x => x.WriterID).NotEmpty().WithMessage("Boş Geçemezsiniz.");
        }
    }
}
