namespace POO;

public class Program
{


    public static void Main()
    {
        List<Aluno> alunos = new List<Aluno>();
        List<Professor> professores = new List<Professor>();
        List<Curso> cursos = new List<Curso>();


        while (true)
        {
        Console.WriteLine("\n=== SISTEMA DE ALUNOS ===");
        Console.WriteLine("1 - Cadastrar aluno");
        Console.WriteLine("2 - Listar alunos");
        Console.WriteLine("3 - Buscar aluno");
        Console.WriteLine("4 - Excluir aluno");
        Console.WriteLine("0 - Sair");

        Console.WriteLine("escolha uma opcao de 0 a 4");
        int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    alunos.Add(CadastrarAluno());
                break;

                case 2:
                if (alunos.Count == 0)
                        {
                            Console.WriteLine("Nenhum aluno cadastrado.");
                        }
                        else
                        {
                            foreach (Aluno aluno in alunos)
                            {
                                Console.WriteLine($"Nome: {aluno.Nome}");
                                Console.WriteLine($"Matrícula: {aluno.Matricula}");
                                Console.WriteLine($"Idade: {aluno.Idade}");
                                Console.WriteLine($"Telefone: {aluno.Telefone}\n");
                            }
                        }
                    break;

                case 3:
                Console.WriteLine("digite a madricula do aluno: ");
                int numeroMatricula = Convert.ToInt32(Console.ReadLine());

                bool encontrado = false;

                    foreach (Aluno aluno in alunos)
                    {
                        if (numeroMatricula == aluno.Matricula)
                        {
                            Console.WriteLine($"aluno: {aluno.Nome}");
                            encontrado = true;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("Matricula inexistente");
                    }
                break;
            }


            }

        }

    public static Aluno CadastrarAluno()
    {
        Console.WriteLine($"digite seu nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.WriteLine("digite sua idade");
        int idade = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("digite seu telefone");
        int telefone = Convert.ToInt32(Console.ReadLine());

        Random random = new Random();
        int matricula = random.Next(1000, 10000);

        return new Aluno(matricula, nome, idade, telefone);

    }
}
