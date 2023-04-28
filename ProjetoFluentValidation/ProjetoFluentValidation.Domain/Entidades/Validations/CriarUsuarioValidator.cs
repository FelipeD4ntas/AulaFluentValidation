using FluentValidation;

namespace ProjetoFluentValidation.Domain.Entidades.Validations;

public class CriarUsuarioValidator : AbstractValidator<Usuario>
{ 
    public CriarUsuarioValidator()
    {
        RuleFor(usuario => usuario.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório")
            .MaximumLength(50).WithMessage("O nome não pode passar de 50 caracteres");

        RuleFor(usuario => usuario.Email)
            .NotEmpty().WithMessage("O Email é obrigatório");

        When(usuario => !string.IsNullOrEmpty(usuario.Email), () =>
        {
            RuleFor(usuario => usuario.Email)
                .EmailAddress().WithMessage("O Email deve ser válido.");
        });

        RuleFor(usuario => usuario.Idade)
            .NotEmpty().WithMessage("A idade é ogrigatória")
            .GreaterThanOrEqualTo(18).WithMessage("A idade deve ser maior ou igual a 18 anos");
    }
}
