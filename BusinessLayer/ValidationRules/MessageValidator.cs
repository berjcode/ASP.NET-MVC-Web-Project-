using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public   class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Boş Geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Boş geçemezsiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(X => X.Subject).MaximumLength(100).WithMessage("lÜTFEN 100 KARAKTERDEB FAZLA DEĞER GİRİŞİ YAPMAYIN.");
        }
    }
}
