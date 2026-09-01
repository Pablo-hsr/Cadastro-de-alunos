namespace POO;
using MySqlConnector;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

public class Program
{


    public static void Main()
    {

       
            string senha = Environment.GetEnvironmentVariable("DB_PASSWORD")??"";

        if (string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("Erro: A variável de ambiente DB_PASSWORD não foi encontrada.");
                return;
            }

        string stringDeConexao = $"Server=127.0.0.1;User ID=root;Password={senha};Database=escola";
        using var conexao = new MySqlConnection(stringDeConexao);

        try
        {
            conexao.Open();
            Console.WriteLine("Conectado ao DB com sucesso pai");

        }
        catch(Exception ex)
        {
            Console.WriteLine($"deu erro ao conectar ao banco{ex.Message}");
            return;
        }

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
                    Aluno novoAluno = CadastrarAluno();
                    string sqlinsert = "INSERT INTO Alunos(Matricula, Nome, Idade, Telefone)VALUES(@matricula, @nome, @idade, @telefone)";
                    using (var cmd = new MySqlCommand(sqlinsert, conexao))
                    {
                        cmd.Parameters.AddWithValue("@matricula", novoAluno.Matricula);
                        cmd.Parameters.AddWithValue("@nome", novoAluno.Nome);
                        cmd.Parameters.AddWithValue("@idade", novoAluno.Idade);
                        cmd.Parameters.AddWithValue("@telefone", novoAluno.Telefone);

                        cmd.ExecuteNonQuery();

                    }
                    Console.WriteLine("aluno cadastrado");
                    break;

                case 2:
                    string SqlSelect = "SELECT Matricula, Nome, Idade, Telefone FROM Alunos";
                    using (var cmd = new MySqlCommand(SqlSelect, conexao))
                    using (var reader = cmd.ExecuteReader())
                    {

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Nenhum aluno cadastrado.");
                        }
                        else
                        {
                            while(reader.Read())
                            {
                                Console.WriteLine($"Matrícula: {reader.GetInt32("Matricula")}");
                                Console.WriteLine($"Nome: {reader.GetString("Nome")}");
                                Console.WriteLine($"Idade: {reader.GetInt32("Idade")}");
                                Console.WriteLine($"Telefone: {reader.GetString("Telefone")}\n");
                            }
                         
                        }
                    }
                    break;

                case 3:
                Console.WriteLine("digite a madricula do aluno: ");
                int numeroMatricula = Convert.ToInt32(Console.ReadLine());

                string SqlBuscar = "SELECT Nome, Idade, Telefone From Alunos WHERE Matricula = @numeroMatricula";
                using (var cmd = new MySqlCommand(SqlBuscar, conexao))
                {
                    cmd.Parameters.AddWithValue("@numeroMatricula", numeroMatricula);
                    using var reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        Console.WriteLine($"\nAluno encontrado: {reader.GetString("Nome")}");
                        Console.WriteLine($"Idade: {reader.GetInt32("Idade")}");
                        Console.WriteLine($"Telefone: {reader.GetInt32("Telefone")}");
                    }
                    else
                    {
                        Console.WriteLine("\nMatrícula não encontrada no banco.");
                    }


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
        string telefone = Console.ReadLine() ?? "";

        Random random = new Random();
        int matricula = random.Next(1000, 10000);

        return new Aluno(matricula, nome, idade, telefone);

    }
}
