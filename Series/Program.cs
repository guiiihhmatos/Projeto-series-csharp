using System;
using Series.Classes;

namespace Series
{
    class Program
    {
        static void Main(string[] args)
        {
            AcoesMain activade = new AcoesMain();
            string opcao = activade.ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {

                switch (opcao)
                {
                    case "1":
                        activade.ListarSerie();
                        break;

                    case "2":
                        activade.InserirSerie();
                        break;

                    case "3":
                        activade.AtualizarSerie();
                        break;

                    case "4":
                        activade.ExcluirSerie();
                        break;

                    case "5":
                        activade.VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Opção inválida");

                }
                opcao = activade.ObterOpcaoUsuario();
            }


        }
    }
} 