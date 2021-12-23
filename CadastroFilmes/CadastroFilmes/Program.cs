using System;



namespace CadastroFilmes
{
    class Program
    {
		static FilmeRepositorio repositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            

            string opcaoUsuario = ObterOpcaoUsuario();

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

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();

		}
        // Listar filmes do catálogo
        public static void ListarFilmes()
        {
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
				var excluido = filme.retornaExcludio();

                Console.WriteLine($"# ID {filme.retornaId()} - {filme.retornaTitulo()} {(excluido ? "*Excluido*" : "")}");
            }
        }

		// Inserir filme no catálogo
		private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo Filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do ator: ");
			string entradaAtor = Console.ReadLine();

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										atorPrincipal: entradaAtor,
										ano: entradaAno,
										descricao: entradaDescricao);;

			repositorio.Insere(novoFilme);
		}

		// Atualizar catálogo de filme
		private static void AtualizarFilme()
		{
			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Lançamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do ator: ");
			string entradaAtor = Console.ReadLine();

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										atorPrincipal: entradaAtor,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceFilme, atualizaFilme);
		}

		//Excluidr filme do catálogo
		private static void ExcluirFilme()
		{
			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceFilme);
		}

		//Visualizar filme
		private static void VisualizarFilme()
		{

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

		private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Catalogo de filmes, los niños!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar filmes");
            Console.WriteLine("2- Inserir novo filme");
            Console.WriteLine("3- Atualizar filme");
            Console.WriteLine("4- Excluir filme");
            Console.WriteLine("5- Visualizar filme");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("x- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
