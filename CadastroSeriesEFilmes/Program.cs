using System;
using CadastroSeriesEFilmes.Entidades;
using CadastroSeriesEFilmes.Repository;

namespace CadastroSeriesEFilmes
{
  class Program
  {
    static FilmeRepository repoFilme = new FilmeRepository();
    static SerieRepository repoSerie = new SerieRepository();

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
          case "6":
            ListarSeries();
            break;
          case "7":
            InserirSerie();
            break;
          case "8":
            AtualizarSerie();
            break;
          case "9":
            ExcluirSerie();
            break;
          case "10":
            VisualizarSerie();
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
      Console.WriteLine("<<<------------------------->>>");
      Console.WriteLine("6 - Listar Séries");
      Console.WriteLine("7 - Inserir nova Série");
      Console.WriteLine("8 - Atualizar Série");
      Console.WriteLine("9 - Excluir Série");
      Console.WriteLine("10 - Visualizar Série");
      Console.WriteLine("<<<------------------------->>>");
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

    private static void ListarSeries()
    {
      Console.WriteLine("Listar Séries:");
      var series = repoSerie.BuscarTodos();

      if (series.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada");
        return;
      }

      foreach (var it in series)
      {
        Console.WriteLine("#ID {0}: {1}", it.Id, it.Titulo);
      }
    }

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      Console.Write("Digite o Título da série: ");
      string entradaSerie = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaSerie))
      {
        Console.Write("\nNecessário informar o título da série.\nDigite o Título da série: ");
        entradaSerie = Console.ReadLine();
      }

      Console.Write("Digite o Ano de Laçamento da série: ");
      int entradaAnoLancamento = int.Parse(Console.ReadLine());

      while (entradaAnoLancamento == 0)
      {
        Console.Write("\n\nNecessário informar o ano de laçamento da série.\nDigite o Ano de Lançamento da série: ");
        entradaAnoLancamento = int.Parse(Console.ReadLine());
      }

      Console.Write("Digite a Descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaDescricao))
      {
        Console.Write("\n\nNecessário informar a sinopse da série.\nDigite a sinopse da série: ");
        entradaDescricao = Console.ReadLine();
      }

      Console.Write("Digite as temporadas da série: ");
      int entradaTemporada = int.Parse(Console.ReadLine());

      Serie novaSerie = new Serie(
        titulo: entradaSerie,
        anoLancamento: entradaAnoLancamento,
        descricao: entradaDescricao,
        temporada: entradaTemporada
      );

      repoSerie.Inserir(novaSerie);
    }

    private static void AtualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      Console.Write("Digite o Título da série: ");
      string entradaTitulo = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaTitulo))
      {
        Console.Write("\nNecessário informar o título da série.\nDigite o Título da série: ");
        entradaTitulo = Console.ReadLine();
      }

      Console.Write("Digite o Ano de Lançamento da série: ");
      int entradaAno = int.Parse(Console.ReadLine());

      while (entradaAno == 0)
      {
        Console.Write("\n\nNecessário informar o ano da série.\nDigite o Ano de Lançamento da série: ");
        entradaAno = int.Parse(Console.ReadLine());
      }

      Console.Write("Digite a Descrição da Série: ");
      string entradaDescricao = Console.ReadLine();

      while (String.IsNullOrWhiteSpace(entradaDescricao))
      {
        Console.Write("\n\nNecessário informar a sinopse da série.\nDigite a sinopse da série: ");
        entradaDescricao = Console.ReadLine();
      }

      Console.Write("Digite a duração da série: ");
      int entradaTemporada = int.Parse(Console.ReadLine());

      Serie serie = new Serie(
        titulo: entradaTitulo,
        anoLancamento: entradaAno,
        descricao: entradaDescricao,
        temporada: entradaTemporada
      );

      repoSerie.Atualizar(indiceSerie, serie);
    }

    private static void ExcluirSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      repoSerie.Deletar(indiceSerie);
    }

    private static void VisualizarSerie()
    {
      Console.Write("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      var serie = repoSerie.BuscarPeloId(indiceSerie);

      if (serie != null)
      {
        Console.WriteLine("Informações da Série: ");
        Console.WriteLine($"ID - {serie.Id}");
        Console.WriteLine($"Título - {serie.Titulo}");
        Console.WriteLine($"Lançamento - {serie.AnoLancamento}");
        Console.WriteLine($"Descrição - {serie.Descricao}");
        Console.WriteLine($"Temporadas - {serie.Temporadas}");
      }
      else
      {
        Console.WriteLine($"Série com o id: {indiceSerie} não encontrado.");
      }
    }
  }
}
