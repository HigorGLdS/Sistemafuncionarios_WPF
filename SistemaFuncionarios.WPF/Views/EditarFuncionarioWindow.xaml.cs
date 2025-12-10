using System;
using System.Windows;
using SistemaFuncionarios.WPF.Models;

namespace SistemaFuncionarios.WPF.Views
{
    public partial class EditarFuncionarioWindow : Window
    {
        public Funcionario Funcionario { get; private set; }

        public EditarFuncionarioWindow(Funcionario funcionario)
        {
            InitializeComponent();
            Funcionario = funcionario ?? throw new ArgumentNullException(nameof(funcionario));

            txtNome.Text = Funcionario.Nome ?? string.Empty;
            txtCargo.Text = Funcionario.Cargo ?? string.Empty;
            txtSalario.Text = Funcionario.Salario.ToString("F2");
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            Funcionario.Nome = txtNome.Text?.Trim() ?? string.Empty;

            // agora Cargo tem setter
            Funcionario.Cargo = txtCargo.Text?.Trim() ?? string.Empty;

            if (double.TryParse(txtSalario.Text, out double sal))
                Funcionario.Salario = sal; // mapeia para SalarioBase

            DialogResult = true;
            Close();
        }
    }
}