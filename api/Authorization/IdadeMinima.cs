using Microsoft.AspNetCore.Authorization;

namespace ma2_banco_de_dados.Authorization;

public class IdadeMinima : IAuthorizationRequirement
{
    public IdadeMinima(int idade)
    {
        Idade = idade;
    }

    public int Idade { get; set; }
}
