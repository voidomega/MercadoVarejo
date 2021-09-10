using FluentValidation;
using Ma.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ma.MercadoAssistente.Api.Entidades;

namespace MercadoAssistente.Validators
{
    public class ItemPedidosValidator : AbstractValidator<ItemPedidos>
    {
        public ItemPedidosValidator()
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

