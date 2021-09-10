using FluentValidation;
using Sa2s.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sa2s.Audit.Domain.Entities;

namespace MercadoAssistente..Validators
{
    public class FuncionariosValidator : AbstractValidator<Funcionarios>
    {
        public FuncionariosValidator()
        {
            RuleFor(c => c)
            .NotNull()
            .OnAnyFailure(x =>
            {
                throw new ArgumentNullException("Objeto não fornecido.");
            });

        }    

    }
}

