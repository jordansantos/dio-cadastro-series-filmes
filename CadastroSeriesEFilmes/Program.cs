using System;
using CadastroSeriesEFilmes.Entidades;
using CadastroSeriesEFilmes.Repository;

namespace CadastroSeriesEFilmes
{
  class Program
  {
    static FilmeRepository repoFilme = new FilmeRepository();

    static void Main(string[] args)
    {
      string opcaoUsuario = ObterOpcaoUsuario("filme");

      while (opcaoUsuario.ToUpper() != "X")
      {
        switch (opcaoUsuario)
        {
          case "1":
            ListarFilmes();
            break;
          case "2":
            InserirFilme();
            break;
          case "3":
            AtualizarFilme();
            break;
          case "4":
            ExcluirFilme();
            break;
          case "5":
            VisualizarFilme();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }

        opcaoUsuario = ObterOpcaoUsuario("filme");
      }

      System.Console.WriteLine("Obrigado por utilizar nossos serviçoes.");
      Console.ReadLine();
    }

    private static string ObterOpcaoUsuario(string opcao)
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine($"1 - Listar {opcao}");
      Console.WriteLine($"2 - Inserir novo {opcao}");
      Console.WriteLine($"3 - Atualizar {opcao}");
      Console.WriteLine($"4 - Excluir {opcao}");
      Console.WriteLine($"5 - Visualizar {opcao}");
      Console.WriteLine("C - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();

      return opcaoUsuario;
    }

    private static void ListarFilmes()
    {
      Console.WriteLine("Listar Filmes:");
      var filmes = repoFilme.BuscarTodos();

      if (filmes.Count == 0)
      {
        Console.WriteLine("Nenhum filme cadastrado");
        return;
      }

      foreach (var it in filmes)
      {
        Console.WriteLine("#ID {0}: {1}", it.Id, it.Titulo);
      }
    }

    private static void InserirFilme()
    {
      Console.WriteLine("Inserir novo filme");

      Console.Write("Digite o Título do filme: ");
      string entradaTitulo = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaTitulo))
      {
        Console.Write("\nNecessário informar o título do filme.\nDigite o Título do filme: ");
        entradaTitulo = Console.ReadLine();
      }

      Console.Write("Digite o Ano de Início do filme: ");
      int entradaAno = int.Parse(Console.ReadLine());

      while (entradaAno == 0)
      {
        Console.Write("\n\nNecessário informar o ano de laçamento do filme.\nDigite o Ano de Lançamento do filme: ");
        entradaAno = int.Parse(Console.ReadLine());
      }

      Console.Write("Digite a Descrição do filme: ");
      string entradaDescricao = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaDescricao))
      {
        Console.Write("\n\nNecessário informar a sinopse do filme.\nDigite a sinopse do filme: ");
        entradaDescricao = Console.ReadLine();
      }

      Console.Write("Digite a duração do filme: ");
      int entradaDuracao = int.Parse(Console.ReadLine());

      Filme novoFilme = new Filme(
        titulo: entradaTitulo,
        anoLancamento: entradaAno,
        descricao: entradaDescricao,
        duracao: entradaDuracao
      );

      repoFilme.Inserir(novoFilme);
    }

    private static void AtualizarFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título do filme: ");
      string entradaTitulo = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaTitulo))
      {
        Console.Write("\nNecessário informar o título do filme.\nDigite o Título do filme: ");
        entradaTitulo = Console.ReadLine();
      }

      Console.Write("Digite o Ano de Lançamento do filme: ");
      int entradaAno = int.Parse(Console.ReadLine());

      while (entradaAno == 0)
      {
        Console.Write("\n\nNecessário informar o ano do filme.\nDigite o Ano de Lançamento do filme: ");
        entradaAno = int.Parse(Console.ReadLine());
      }

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaDescricao))
      {
        Console.Write("\n\nNecessário informar o título do filme.\nDigite o Título do filme: ");
        entradaDescricao = Console.ReadLine();
      }

      Console.Write("Digite a duração do filme: ");
      int entradaDuracao = int.Parse(Console.ReadLine());

      Filme filme = new Filme(
        titulo: entradaTitulo,
        anoLancamento: entradaAno,
        descricao: entradaDescricao,
        duracao: entradaDuracao
      );

      repoFilme.Atualizar(indiceFilme, filme);
    }

    private static void ExcluirFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      repoFilme.Deletar(indiceFilme);
    }

    private static void VisualizarFilme()
    {
      Console.Write("Digite o id do filme: ");
      int indiceFilme = int.Parse(Console.ReadLine());

      var filme = repoFilme.BuscarPeloId(indiceFilme);

      if (filme != null)
      {
        Console.WriteLine("Informações do Filme: ");
        Console.WriteLine($"ID - {filme.Id}");
        Console.WriteLine($"Título - {filme.Titulo}");
        Console.WriteLine($"Lançamento - {filme.AnoLancamento}");
        Console.WriteLine($"Descrição - {filme.Descricao}");
        Console.WriteLine($"Duração - {filme.Duracao}");
      }
      else
      {
        Console.WriteLine($"Filme com o id: {indiceFilme} não encontrado.");
      }
    }
  }
}
