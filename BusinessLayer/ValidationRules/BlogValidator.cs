using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle)
                .NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz!")
                .MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız!")
                .MinimumLength(2).WithMessage("Lütfen 2 karakterden daha falza veri girişi yapınız!");
            RuleFor(x => x.BlogContent)
                .NotNull().WithMessage("Blog içeriğini boş geçemezsiniz!")
				.MaximumLength(1500).WithMessage("Lütfen 1500 karakterden daha az veri girişi yapınız!")
				.MinimumLength(2).WithMessage("Lütfen 8 karakterden daha falza veri girişi yapınız!");
            RuleFor(x => x.BlogImage)
                .NotEmpty().WithMessage("Blog görselini boş geçemezsiniz!")
                .MinimumLength(2).WithMessage("Lütfen 2 karakterden daha fazla içerik giriniz");
            RuleFor(x => x.CategoryID)
                .NotNull().WithMessage("Kategori alanı boş geçilemez, lütfen bir seçim yapınız!");
        }
    }
}
