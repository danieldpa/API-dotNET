public class Pessoa 
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public Pessoa(Guid Id, string Nome){
        this.Id = Id;
        this.Nome = Nome;
    }
}