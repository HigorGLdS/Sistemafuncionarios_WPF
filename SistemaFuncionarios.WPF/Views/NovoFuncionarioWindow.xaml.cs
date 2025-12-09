using System;
using System.Windows;
using System.Windows.Controls;
using SistemaFuncionarios.WPF.Models;

namespace SistemaFuncionarios.WPF.Views
{
    public partial class NovoFuncionarioWindow : Window
    {
        public Funcionario? NovoFuncionario { get; private set; }

        public NovoFuncionarioWindow()
        {
            InitializeComponent();
            CmbCargo.SelectedIndex = 0;
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNome.Text?.Trim() ?? string.Empty;
            string cargo = (CmbCargo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Funcionário";
            
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // tenta parse seguro
            double.TryParse(TxtValor1.Text, out double v1);
            double.TryParse(TxtValor2.Text, out double v2);

            if (cargo == "Funcionário")
            {
                NovoFuncionario = new Funcionario(nome, v1);
            }
            else if (cargo == "Gerente")
            {
                NovoFuncionario = new Gerente(nome, v1, v2);
            }
            else // Estagiário
            {
                int horas = (int)Math.Round(v1);
                NovoFuncionario = new Estagiario(nome, horas, v2);
            }

            DialogResult = true;
            Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}