public class Professor
{
    public int ID {get; set;}
    public string Nome {get; set;}
    public int Idade{get;set;}
    public int Telefone{get;set;}

    public Professor(int id, string nome, int idade, int telefone)
    {
        ID = id;
        Nome = nome;
        Idade = idade;
        Telefone = telefone;
    }
}