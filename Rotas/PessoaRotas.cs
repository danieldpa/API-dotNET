
using Microsoft.AspNetCore.Mvc.ApplicationParts;

public static class PessoaRotas
{
    public static List<Pessoa> Pessoas =
    [
        new(Guid.NewGuid(),"Daniel"),
        new(Guid.NewGuid(),"Matheus")
    ];

    public static void MapPessoaRotas(this WebApplication app)
    {
        app.MapGet("/pessoas", () => Pessoas);

        app.MapGet("/pessoas/{nome}", (string nome) => Pessoas.Find(x => x.Nome == nome));

        app.MapPost("/pessoas", (Pessoa pessoa) =>
        {
            if (pessoa.Nome == "Daniel")
            {
                return Results.BadRequest(new { message = "Não aceitamos nome Daniel" }); //Como se fosse o try/cath
            }
            Pessoas.Add(pessoa);
            return Results.Ok(pessoa);
        });

        app.MapPut("/pessoas/{id}", (Guid id, Pessoa pessoa) =>
        {
            var encontrado = Pessoas.Find(x => x.Id == id);

            if(encontrado == null)
                return Results.NotFound();
            
            encontrado.Nome = pessoa.Nome;

            return Results.Ok(encontrado);
        });
    }
}