using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using SistemaFuncionarios.WPF.ViewModels;
using SistemaFuncionarios.WPF.Views;
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

        private GridViewColumnHeader colunaAtual = null!;
        private ListSortDirection direcaoAtual = ListSortDirection.Ascending;

        private void Ordenar_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is GridViewColumnHeader coluna && coluna.Tag is string propriedade)
            {
                if (colunaAtual == coluna)
                {
                    direcaoAtual = direcaoAtual == ListSortDirection.Ascending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
                }
                else
                {
                    colunaAtual = coluna;
                    direcaoAtual = ListSortDirection.Ascending;
                }

                ViewModel.FuncionariosView.SortDescriptions.Clear();
                ViewModel.FuncionariosView.SortDescriptions.Add(
                    new SortDescription(propriedade, direcaoAtual));

                ViewModel.FuncionariosView.Refresh();
            }
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            string nome = txtNome.Text?.Trim() ?? string.Empty;
            string cargo = txtCargo.Text?.Trim() ?? string.Empty;
            double.TryParse(txtSalario.Text, out double valor);

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome.");
                return;
            }

            Funcionario f;

            if (cargo.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                f = new Gerente(nome, valor, 0.0);
            }
            else if (cargo.StartsWith("est", StringComparison.OrdinalIgnoreCase) ||
                     cargo.Equals("Estagiário", StringComparison.OrdinalIgnoreCase) ||
                     cargo.Equals("Estagiario", StringComparison.OrdinalIgnoreCase))
            {
                f = new Estagiario(nome, 0, valor);
            }
            else
            {
                f = new Funcionario(nome, valor);
                f.Cargo = cargo; // cargo agora com setter
            }

            ViewModel.Adicionar(f);

            txtNome.Text = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            if (ListaFuncionarios.SelectedItem is Funcionario f)
            {
                var win = new EditarFuncionarioWindow(f);

                if (win.ShowDialog() == true)
                {
                    ViewModel.FuncionariosView.Refresh();
                }
            }
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (ListaFuncionarios.SelectedItem is Funcionario f)
                ViewModel.Remover(f);
        }

        private void txtBusca_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.Filtrar(txtBusca.Text);
        }
    }
}