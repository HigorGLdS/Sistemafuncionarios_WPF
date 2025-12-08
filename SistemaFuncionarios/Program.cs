using SistemaFuncionarios.Models;
using SistemaFuncionarios.Services;

class Program
{
    static void Main()
    {
        FuncionarioService service = new FuncionarioService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE FUNCIONÁRIOS ===");
            Console.WriteLine("1 - Adicionar Funcionário");
            Console.WriteLine("2 - Listar Funcionários");
            Console.WriteLine("3 - Sair");

            Console.Write("\nOpção: ");
            string opc = LerString();

            switch (opc)
            {
                case "1": AdicionarFuncionario(service); break;
                case "2": service.Listar(); Console.ReadKey(); break;
                case "3": return;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }
    }

    static void AdicionarFuncionario(FuncionarioService service)
    {
        Console.Clear();
        Console.WriteLine("Escolha o Tipo:");
        Console.WriteLine("1 - Funcionário");
        Console.WriteLine("2 - Gerente");
        Console.WriteLine("3 - Estagiário");

        Console.Write("Opção: ");
        string opc = LerString();

        Console.Write("Nome: ");
        string nome = LerString();

        if (opc == "1")
        {
            Console.Write("Salário Base: ");
            double salario = LerDouble();
            service.Adicionar(new Funcionario(nome, salario));
        }
        else if (opc == "2")
        {
            Console.Write("Salário Base: ");
            double salario = LerDouble();

            Console.Write("Bônus: ");
            double bonus = LerDouble();

            service.Adicionar(new Gerente(nome, salario, bonus));
        }
        else if (opc == "3")
        {
            Console.Write("Horas Trabalhadas: ");
            int h = LerInt();

            Console.Write("Valor por Hora: ");
            double v = LerDouble();

            service.Adicionar(new Estagiario(nome, h, v));
        }
    }

    // ------ MÉTODOS DE LEITURA SEGUROS ------ //

    static string LerString()
    {
        string? entrada = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.Write("Entrada inválida, digite novamente: ");
            entrada = Console.ReadLine();
        }
        return entrada;
    }

    static double LerDouble()
    {
        string? entrada = Console.ReadLine();
        double valor;

        while (!double.TryParse(entrada, out valor))
        {
            Console.Write("Valor inválido! Digite um número: ");
            entrada = Console.ReadLine();
        }

        return valor;
    }

    static int LerInt()
    {
        string? entrada = Console.ReadLine();
        int valor;

        while (!int.TryParse(entrada, out valor))
        {
            Console.Write("Valor inválido! Digite um número inteiro: ");
            entrada = Console.ReadLine();
        }

        return valor;
    }
}