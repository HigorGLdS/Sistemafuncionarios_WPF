using SistemaFuncionarios.Models;

namespace SistemaFuncionarios.Services;

public class FuncionarioService
{
    private readonly List<Funcionario> funcionarios = new();

    public void Adicionar(Funcionario f)
    {
        funcionarios.Add(f);
        Console.WriteLine("\nFuncionário adicionado com sucesso!");
    }

    public void Listar()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE FUNCIONÁRIOS ===");

        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        foreach (var f in funcionarios)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Nome: {f.Nome}");
            Console.WriteLine($"Cargo: {f.Cargo}");
            Console.WriteLine($"Salário: {f.CalcularSalario():C}"); // <-- AQUI É FUNDAMENTAL!!!
        }

        Console.WriteLine("--------------------------");
    }
}