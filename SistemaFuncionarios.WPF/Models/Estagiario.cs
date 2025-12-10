namespace SistemaFuncionarios.WPF.Models
{
    public class Estagiario : Funcionario
    {
        public int HorasTrabalhadas { get; set; }
        public double ValorHora { get; set; }

        public Estagiario(string nome, int horas, double valorHora)
            : base(nome, horas * valorHora)
        {
            HorasTrabalhadas = horas;
            ValorHora = valorHora;
            Cargo = "Estagiário";
        }

        public override double CalcularSalario()
        {
            return HorasTrabalhadas * ValorHora;
        }

        public override string Cargo
        {
            get => base.Cargo;
            set => base.Cargo = value;
        }
    }
}