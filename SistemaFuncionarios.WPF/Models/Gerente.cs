namespace SistemaFuncionarios.WPF.Models
{
    public class Gerente : Funcionario
    {
        public double Bonus { get; set; }

        public Gerente(string nome, double salarioBase, double bonus)
            : base(nome, salarioBase)
        {
            Bonus = bonus;
            Cargo = "Gerente";
        }

        public override double CalcularSalario()
        {
            return SalarioBase + Bonus;
        }

        // mantém possibilidade de alterar cargo se necessário
        public override string Cargo
        {
            get => base.Cargo;
            set => base.Cargo = value;
        }
    }
}