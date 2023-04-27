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
            .NotEmpty().WithMessage("O e-mail é obrigatório")
            .EmailAddress().WithMessage("Precisa ser um e-mail válido");

        RuleFor(usuario => usuario.Idade)
            .NotEmpty().WithMessage("A idade é ogrigatória")
            .LessThanOrEqualTo(100).WithMessage("A idade do usuário não pode ser maior que 100 anos");
    }
}
