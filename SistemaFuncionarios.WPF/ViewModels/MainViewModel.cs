using System.Collections.ObjectModel;                      // ✔ NECESSÁRIO
using SistemaFuncionarios.WPF.Models;
using SistemaFuncionarios.WPF.Services;

namespace SistemaFuncionarios.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly FuncionarioService _service;

        public ObservableCollection<Funcionario> Funcionarios { get; set; }

        public MainViewModel()
        {
            _service = new FuncionarioService();
            Funcionarios = new ObservableCollection<Funcionario>(_service.ObterTodos());
        }

        public void Adicionar(Funcionario f)
        {
            _service.Adicionar(f);
            Funcionarios.Add(f);
        }

        public void Remover(Funcionario f)
        {
            _service.Remover(f);
            Funcionarios.Remove(f);
        }
    }
}