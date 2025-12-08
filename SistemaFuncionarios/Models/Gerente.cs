namespace SistemaFuncionarios.Models;

public class Gerente : Funcionario
{
    public double Bonus { get; set; }

    public Gerente(string nome, double salarioBase, double bonus)
        : base(nome, salarioBase)
    {
        Bonus = bonus;
    }

    public override double CalcularSalario()
    {
        return SalarioBase + Bonus;
    }

    public override string Cargo => "Gerente";
}