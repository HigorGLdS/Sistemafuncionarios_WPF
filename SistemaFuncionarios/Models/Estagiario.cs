namespace SistemaFuncionarios.Models;

public class Estagiario : Funcionario
{
    public int HorasTrabalhadas { get; set; }
    public double ValorHora { get; set; }

    public Estagiario(string nome, int horas, double valorHora)
        : base(nome, 0)
    {
        HorasTrabalhadas = horas;
        ValorHora = valorHora;
    }

    public override double CalcularSalario()
    {
        return HorasTrabalhadas * ValorHora;
    }

    public override string Cargo => "Estagiário";
}