using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator: AbstractValidator<Contact>
    {

        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Boş Geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.");
            RuleFor(x => x.UserMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(x => x.UserMail).MaximumLength(20).WithMessage("lÜTFEN 20 KARAKTERDEB FAZLA DEĞER GİRİŞİ YAPMAYIN.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 Karakterden fazla giriş yapmayın.");
        }
    }
}
