using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;                 // ✔ CORRETO
using SistemaFuncionarios.WPF.Models;
using SistemaFuncionarios.WPF.Services;

namespace SistemaFuncionarios.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly FuncionarioService _service;

        public ObservableCollection<Funcionario> Funcionarios { get; set; }

        public ICollectionView FuncionariosView { get; }

        public MainViewModel()
        {
            _service = new FuncionarioService();
            Funcionarios = new ObservableCollection<Funcionario>(_service.ObterTodos());

            FuncionariosView = CollectionViewSource.GetDefaultView(Funcionarios);
        }

        public void Adicionar(Funcionario f)
        {
            _service.Adicionar(f);
            Funcionarios.Add(f);
        }

        public void Filtrar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                FuncionariosView.Filter = null;
            }
            else
            {
                FuncionariosView.Filter = obj =>
                {
                    var func = obj as Funcionario;
                    if (func == null) return false;

                    return func.Nome.Contains(texto, StringComparison.OrdinalIgnoreCase)
                        || func.Cargo.Contains(texto, StringComparison.OrdinalIgnoreCase);
                };
            }

            FuncionariosView.Refresh();
        }

        public void Remover(Funcionario f)
        {
            _service.Remover(f);
            Funcionarios.Remove(f);
        }
    }
}