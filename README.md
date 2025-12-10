📘 Sistema de Funcionários – WPF (.NET 10)

Um sistema desktop feito com WPF, arquitetura MVVM, classes polimórficas (Funcionário / Gerente / Estagiário), suporte a listagem, filtro, ordenação, edição e remoção de funcionários, além de uma estrutura preparada para persistência futura (JSON ou banco de dados).

📌 Funcionalidades

✔ Adicionar Funcionários
✔ Classes polimórficas: Funcionario, Gerente, Estagiario
✔ Edição de funcionários em uma janela dedicada
✔ Remoção de funcionários
✔ Filtro por nome/cargo em tempo real
✔ Ordenação clicando no cabeçalho das colunas
✔ Arquitetura MVVM
✔ Base pronta para persistência (serviço de dados)
✔ Uso de ICollectionView para manipular a lista exibida

🧱 Arquitetura do Projeto
SistemaFuncionarios/
│
├── SistemaFuncionarios.WPF/
│   ├── Models/
│   │   ├── Funcionario.cs
│   │   ├── Gerente.cs
│   │   ├── Estagiario.cs
│   │
│   ├── Services/
│   │   ├── FuncionarioService.cs
│   │
│   ├── ViewModels/
│   │   ├── MainViewModel.cs
│   │
│   ├── Views/
│   │   ├── MainWindow.xaml
│   │   ├── MainWindow.xaml.cs
│   │   ├── EditarFuncionarioWindow.xaml
│   │   ├── EditarFuncionarioWindow.xaml.cs
│   │
│   ├── App.xaml
│   └── App.xaml.cs
│
└── README.md

🧩 Modelos
🔹 Funcionario

Classe base com:

Nome

Cargo

SalarioBase

Salario (calculado, porém editável)

🔹 Gerente

Possui salário base + bônus.

🔹 Estagiario

Salário baseado em:
HorasTrabalhadas * ValorHora.

Todas são compatíveis com a UI por causa do polimorfismo + MVVM.

🧠 MVVM — Lógica principal

A ViewModel utiliza:

ObservableCollection → lista dinâmica

ICollectionView → filtro e ordenação

SortDescription → ordenar colunas

Filter → busca em tempo real

📺 Interface

Tela principal com formulário de cadastro

Campo de busca dinâmica

Lista com GridView

Botões para editar e remover

Janela modal para edição

🔧 Como executar
Pré-requisitos

.NET SDK 10.0+

Windows 10/11

Visual Studio, Visual Studio Code ou Rider

Executar
dotnet build
dotnet run --project SistemaFuncionarios.WPF
🏗️ Tecnologias utilizadas

C# 10

WPF (.NET 10.0-windows)

MVVM Pattern

ObservableCollection

ICommand (se quiser, posso converter os eventos em comandos MVVM)

📜 Licença

Este projeto é livre para uso acadêmico e profissional.

✨ Autor

Higor Gabriel
🔹 Projetos em C#, Python, Web, Automação e Ciência de Dados.
