using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("İsim Kısmı Boş Bırakılamaz!");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("İsim 5 Karakterden kısa olamaz!");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Puan Boş Bırakılamaz!");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum Kısmı Boş Geçilemez!");
            RuleFor(x => x.Comment).MinimumLength(20).WithMessage("Yorum minimum 20 karakter olabilir");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Yorum maksimum 500 karakter olabilir");
        }
    }
}
