namespace POO;

public class Aluno
{
    public int Matricula {get; set;}
    public string Nome {get; set;}
    public int Idade{get;set;}
    public int Telefone{get;set;}

    public Aluno(int matricula, string nome, int idade, int telefone)
    {
        Matricula = matricula;
        Nome = nome;
        Idade = idade;
        Telefone = telefone;
    }
   
};
