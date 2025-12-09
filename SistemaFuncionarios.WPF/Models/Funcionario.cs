namespace SistemaFuncionarios.WPF.Models
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public double SalarioBase { get; set; }

        public Funcionario(string nome, double salarioBase)
        {
            Nome = nome;
            SalarioBase = salarioBase;
        }

        public virtual double CalcularSalario()
        {
            return SalarioBase;
        }

        // propriedade calculada para facilitar binding na View
        public double Salario => CalcularSalario();

        // cargo permanece somente leitura — polimorfismo nas classes derivadas
        public virtual string Cargo => "Funcionário";
    }
}