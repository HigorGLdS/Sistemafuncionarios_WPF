using System;
using System.Windows;
using SistemaFuncionarios.WPF.ViewModels;
using SistemaFuncionarios.WPF.Models;

namespace SistemaFuncionarios.WPF
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text?.Trim() ?? string.Empty;
            string cargo = txtCargo.Text?.Trim() ?? string.Empty;
            double valor;
            double.TryParse(txtSalario.Text, out valor); // valor interpretado conforme cargo

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Escolha do tipo de funcionário conforme texto do campo Cargo.
            // - "Gerente" -> cria Gerente(nome, salarioBase, bonus=0)
            // - "Estagiário" -> cria Estagiario(nome, horas=0, valorHora=valor)
            // - outro -> funcionário comum com salario base = valor
            Funcionario f;
            if (cargo.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                f = new Gerente(nome, valor, 0.0);
            }
            else if (cargo.StartsWith("est", StringComparison.OrdinalIgnoreCase) ||
                     cargo.Equals("Estagiário", StringComparison.OrdinalIgnoreCase) ||
                     cargo.Equals("Estagiario", StringComparison.OrdinalIgnoreCase))
            {
                // Interpretamos o campo Salário como "valor por hora" no caso do estagiário,
                // e inicializamos HorasTrabalhadas com 0 (poderá ser editado depois).
                f = new Estagiario(nome, 0, valor);
            }
            else
            {
                // funcionário padrão
                f = new Funcionario(nome, valor);
            }

            ViewModel.Adicionar(f);

            // limpar campos
            txtNome.Text = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (ListaFuncionarios.SelectedItem is Funcionario f)
                ViewModel.Remover(f);
        }
    }
}