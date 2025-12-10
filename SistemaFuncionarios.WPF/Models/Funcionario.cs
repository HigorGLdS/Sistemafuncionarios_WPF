namespace SistemaFuncionarios.WPF.Models
{
    public class Funcionario
    {
        public string Nome { get; set; }

        // campo de persistência do salário base
        public double SalarioBase { get; set; }

        public Funcionario(string nome, double salarioBase)
        {
            Nome = nome ?? string.Empty;
            SalarioBase = salarioBase;
            Cargo = "Funcionário";
        }

        public virtual double CalcularSalario()
        {
            return SalarioBase;
        }

        // propriedade para binding que também pode ser alterada pelo usuário
        public double Salario
        {
            get => CalcularSalario();
            set => SalarioBase = value;
        }

        // Cargo agora tem setter para permitir edição pela UI
        public virtual string Cargo { get; set; }
    }
}