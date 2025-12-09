using SistemaFuncionarios.WPF.Models;

namespace SistemaFuncionarios.WPF.Services
{
    
public class FuncionarioService
{
    private readonly List<Funcionario> _funcionarios = new();

    public void Adicionar(Funcionario f)
    {
        _funcionarios.Add(f);
    }

    public void Remover(Funcionario f)
    {
        _funcionarios.Remove(f);
    }

    public IEnumerable<Funcionario> ObterTodos()
    {
        return _funcionarios;
    }
}
}

public class FuncionarioService
{
    private readonly List<Funcionario> _funcionarios = new();

    public void Adicionar(Funcionario f)
    {
        _funcionarios.Add(f);
    }

    public void Remover(Funcionario f)
    {
        _funcionarios.Remove(f);
    }

    public IEnumerable<Funcionario> ObterTodos()
    {
        return _funcionarios;
    }
}