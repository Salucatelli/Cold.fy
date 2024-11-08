using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ma2_banco_de_dados.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var birthDate = context
            .User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if (birthDate is null)
            return Task.CompletedTask;

        var dataNascimento = Convert.ToDateTime(birthDate.Value); // converte para date time

        var idade = DateTime.Today.Year - dataNascimento.Year;

        if(dataNascimento > DateTime.Today.AddYears(-idade))
            idade--;

        if (idade >= requirement.Idade) // se for maior de 18 é bem sucedido
            context.Succeed(requirement);

        return Task.CompletedTask; // se não for maior de 18, so retorna
    }
}
