using System;
using Series.Classes;
using Series.Enum;

namespace Series.Classes
{
    public class AcoesMain
    {
        public static SerieRepositorio repositorio = new SerieRepositorio();
        public string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Séries ao seu dispor!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine();
            Console.WriteLine("1 - Listar as Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar uma Série");
            Console.WriteLine("4 - Excluir uma Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar a Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        public void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("Visualizar Alguma Série");
            Console.WriteLine();
            Console.Write("Digite o ID da Série pra visualizar : ");
            int id = int.Parse(Console.ReadLine());

            Serie visualizarSerie = repositorio.RetornaPorId(id);

            Console.WriteLine(visualizarSerie);
        }
        public int ObterGenero()
        {
            Console.WriteLine();
            Console.WriteLine("Gêneros Disponíveis : ");
            Console.WriteLine("1 - Ação");
            Console.WriteLine("2 - Aventura");
            Console.WriteLine("3 - Comédia");
            Console.WriteLine("4 - Documentario");
            Console.WriteLine("5 - Drama");
            Console.WriteLine("6 - Espionagem");
            Console.WriteLine("7 - Faroeste");
            Console.WriteLine("8 - Fantasia");
            Console.WriteLine("9 - Ficção Científica");
            Console.WriteLine("10 - Musical");
            Console.WriteLine("11 - Romance");
            Console.WriteLine("12 - Suspense");
            Console.WriteLine("13 - Terro");
            Console.WriteLine();
            Console.Write("Digite o número do gênero : ");

            int entradaGenero = int.Parse(Console.ReadLine());
            return entradaGenero;
        }
        public void ListarSerie()
        {
            Console.WriteLine("Lista das Séries");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série foi Listada");
                return;
            }

            foreach (var item in lista)
            {
                Console.WriteLine($"#ID {item.RetornaID()}: {item.RetornaTitulo()}");
            }

        }

        public void InserirSerie()
        {
        VOLTAR:
            Console.WriteLine("Inserir alguma Série");

            int entradaGenero = ObterGenero();

            if ((entradaGenero > 0) && (entradaGenero <= 13))
            {
                Console.WriteLine();
                Console.Write("Digite o Título da Série : ");

                string entradaTitulo = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Digite o ano de lançamento da Série : ");
                int entradaAno = int.Parse(Console.ReadLine());

                if ((entradaAno >= 1946) && (entradaAno <= 2021))
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite a Descrição da Série");
                    Console.WriteLine();

                    string entradaDescricao = Console.ReadLine();

                    Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo.Trim(), descricao: entradaDescricao, ano: entradaAno);

                    repositorio.Insere(novaSerie);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Você digitou um valor incorreto para o Ano de Lançamento.");
                    Console.WriteLine("Favor aperta qualquer tecla para digitar Tudo novamente ou 'X' para sair.");
                    string opcao = Console.ReadLine().ToUpper();

                    if (opcao.ToUpper() == "X")
                    {
                        throw new ArgumentOutOfRangeException("Programa encerrado.");
                    }
                    else
                    {
                        Console.ReadKey();
                        Console.Clear();
                        goto VOLTAR;
                    }

                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Você digitou um valor incorreto para o Gênero.");
                Console.WriteLine("Favor aperta qualquer tecla para digitar novamente ou 'X' para sair.");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao.ToUpper() == "X")
                {
                    throw new ArgumentOutOfRangeException("Programa encerrado.");
                }
                else
                {
                    Console.ReadKey();
                    Console.Clear();
                    goto VOLTAR;
                }
            }
        }

        public void AtualizarSerie()
        {
        BACK:
            Console.WriteLine("Atualizar alguma série");
            Console.WriteLine();
            Console.Write("Digite o número do id da série que deseja ser atualizada :");

            int entradaId = int.Parse(Console.ReadLine());
            Serie verificador = repositorio.RetornaPorId(entradaId);

            if (verificador != null)
            {
            VOLTAR:
                int entradaGenero = ObterGenero();

                if ((entradaGenero > 0) && (entradaGenero <= 13))
                {
                    Console.WriteLine();
                    Console.Write("Digite o Título da Série : ");

                    string entradaTitulo = Console.ReadLine();
                    Console.WriteLine();

                    Console.Write("Digite o ano de lançamento da Série : ");
                    int entradaAno = int.Parse(Console.ReadLine());

                    if ((entradaAno >= 1946) && (entradaAno <= 2021))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Digite a Descrição da Série");
                        Console.WriteLine();

                        string entradaDescricao = Console.ReadLine();

                        Serie atualizaSerie = new Serie(entradaId, genero: (Genero)entradaGenero, titulo: entradaTitulo.Trim(), descricao: entradaDescricao, ano: entradaAno);

                        repositorio.Atualizar(entradaId, atualizaSerie);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Você digitou um valor incorreto para o Ano de Lançamento.");
                        Console.WriteLine("Favor aperta qualquer tecla para digitar Tudo novamente ou 'X' para sair.");
                        string opcao = Console.ReadLine().ToUpper();

                        if (opcao.ToUpper() == "X")
                        {
                            throw new ArgumentOutOfRangeException("Programa encerrado.");
                        }
                        else
                        {
                            Console.Clear();
                            goto VOLTAR;
                        }

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Você digitou um valor incorreto para o Gênero.");
                    Console.WriteLine("Favor aperta qualquer tecla para digitar novamente ou 'X' para sair.");
                    string opcao = Console.ReadLine().ToUpper();

                    if (opcao.ToUpper() == "X")
                    {
                        throw new ArgumentOutOfRangeException("Programa encerrado.");
                    }
                    else
                    {
                        Console.Clear();
                        goto VOLTAR;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("O ID que você digitou não existe.");
                Console.WriteLine("Favor aperta qualquer tecla para digitar Tudo novamente ou 'X' para sair.");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao.ToUpper() == "X")
                {
                    throw new ArgumentOutOfRangeException("Programa encerrado.");
                }
                else
                {
                    Console.Clear();
                    goto BACK;
                }

            }

        }

        public void ExcluirSerie()
        {
            Console.Clear();
            Console.WriteLine("Excluir alguma série da lista.");
            Console.WriteLine();
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Não existe nenhuma Série na sua lista");
                return;
            }
            BACK:
            Console.WriteLine();
            Console.Write("Digite o número do ID da série que deseja excluir : ");
            
            int entradaId = int.Parse(Console.ReadLine());
            Serie verificador = repositorio.RetornaPorId(entradaId);

            if(verificador != null)
            {
                repositorio.Excluir(entradaId);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("O ID que você digitou não existe.");
                Console.WriteLine("Favor aperta qualquer tecla para digitar Tudo novamente ou 'X' para sair.");
                string opcao = Console.ReadLine().ToUpper();

                if (opcao.ToUpper() == "X")
                {
                    throw new ArgumentOutOfRangeException("Programa encerrado.");
                }
                else
                {
                    Console.Clear();
                    goto BACK;
                }
            }
        }

    }
}