public class Curso
{
    public int ID {get; set;}
    public string Nome {get; set;}
    public int Periodo{get; set;}
    public Curso(int id, string nome, int periodo)
    {
        ID = id;
        Nome = nome;
        Periodo = periodo;
    }
}