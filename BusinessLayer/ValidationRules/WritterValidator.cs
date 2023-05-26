using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WritterValidator : AbstractValidator<Writter>
	{
		public WritterValidator()
		{
			RuleFor(x => x.WritterName).NotEmpty().WithMessage("Yazar adı soyadı alanı boş geçilemez!");
			RuleFor(x => x.WritterMail).NotEmpty().WithMessage("Mail adresi alanı boş geçilemez!");
			RuleFor(x => x.WritterPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
			RuleFor(x => x.WritterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız!");
		}
	}
}
