namespace POO;

public class Aluno
{
    public int Matricula {get; set;}
    public string Nome {get; set;}
    public int Idade{get;set;}
    public string Telefone{get;set;}

    public Aluno(int matricula, string nome, int idade, string telefone)
    {
        Matricula = matricula;
        Nome = nome;
        Idade = idade;
        Telefone = telefone;
    }

};
