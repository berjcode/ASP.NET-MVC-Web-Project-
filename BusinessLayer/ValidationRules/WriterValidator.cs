using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz.");
            RuleFor(X => X.WriterAbout).MaximumLength(200).WithMessage("lÜTFEN 200 KARAKTERDEB FAZLA DEĞER GİRİŞİ YAPMAYIN.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(X => X.WriterName).MaximumLength(50).WithMessage("Lütfen 5 karakterden  FAZLA DEĞER GİRİŞİ YAPMAYIN.");
        }
    }
}
