using System;
using TMDbLib.Client;



namespace AppCadastroSeries
{
    
    class Program
    {
      

        static SerieRepositório repositorio = new SerieRepositório();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario() ;

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case"3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
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
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            



            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#Id {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "***Excluido***" : " "));
            
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série:  ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite a nota da série (em números inteiros): ");
            int entradaNota = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                                        genero : (Genero)entradaGenero,
                                                        titulo: entradaTitulo,
                                                        ano: entradaAno,
                                                        descricao: entradaDescricao,
                                                        nota: entradaNota);
            repositorio.Insere(novaSerie);       
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", 1, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("Digite a nota da série: ");
            int entradaNota = int.Parse(Console.ReadLine());

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero : (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao,
                                            nota: entradaNota);
            repositorio.Atualiza(indiceSerie,atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série:");
            int indiceSerie=int.Parse(Console.ReadLine());

            Console.Write("Tem certeza? y/n");
            Console.Write("");
            string confirmacao = Console.ReadLine();
            if (confirmacao == "y")
            {
                repositorio.Exclui(indiceSerie);
            } 
                       
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série:");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("AppCadastroSeries");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair" );
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
