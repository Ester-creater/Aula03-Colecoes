using System;
using Aula03Colecoes.Models;
using  Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {

        static List<Funcionario> lista = new List<Funcionario>();


        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Obter por nome ");
                Console.WriteLine("2 - Obter Funcionários Recentes");
                Console.WriteLine("3 - Obter Estatisticas ");
                Console.WriteLine("4 - Obter por Tipo ");
                Console.WriteLine("5 - Criar Lista ");
                Console.WriteLine("6 - Exibir Lista ");
                Console.WriteLine("7 - Adicionar Funcionário (TESTAR VALIDAÇÕES)"); 

                Console.WriteLine("0 - Sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ObterPorNome(lista);
                        break;
                    case "2":
                        ObterFuncionariosRecentes(lista);
                        break;
                    case "3":
                        ObterEstatisticas(lista);
                        break;
                    case "4":
                        ObterPorTipo(lista);
                        break;
                    case "5":
                        CriarLista();
                        break;
                    case "6":
                        Exibirista(lista);
                        break;
                        case "7":
                        AdicionarFuncionario();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }

        }

        public static void CriarLista()
        {
            lista.Clear(); 

            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

         public static void Exibirista(List<Funcionario> funcionarios)
        {
                 if (funcionarios.Count == 0) 
                        {
                            Console.WriteLine("Lista vazia! Use a opção 5 primeiro.");
                            return;
                        }

                string dados = "";
                for (int i = 0; i < funcionarios.Count; i++)
                    {
                        dados += "===========================\n";
                        dados += string.Format("Id: {0} \n", funcionarios[i].Id);
                        dados += string.Format("Nome: {0} \n", funcionarios[i].Nome);
                        dados += string.Format("CPF: {0} \n", funcionarios[i].Cpf);
                        dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                        dados += string.Format("Salário: {0:c2} \n", funcionarios[i].Salario);
                        dados += string.Format("Tipo: {0} \n", funcionarios[i].TipoFuncionario);
                        dados += "===========================\n";
                    }
                         Console.WriteLine(dados);
        }


        public static void ObterPorNome(List<Funcionario> funcionarios)
        {
            Console.WriteLine("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            bool encontrado = false;
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (funcionarios[i].Nome.ToLower() == nome.ToLower())
                {
                    Console.WriteLine($"ID: {funcionarios[i].Id}, Nome: {funcionarios[i].Nome}, Salario: {funcionarios[i].Salario}, Data: {funcionarios[i].DataAdmissao}, Tipo: {funcionarios[i].TipoFuncionario}");
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Funcionário não encontrado!");
            }
        }

        public static void ObterFuncionariosRecentes(List<Funcionario> funcionarios)
        {
            List<Funcionario> listatemp = new List<Funcionario>();
            for (int i = 0; i < funcionarios.Count; i++)
            {

                if (funcionarios[i].Id >= 4)
                {
                    listatemp.Add(funcionarios[i]);
                }

            }
            for (int i = 0; i < listatemp.Count - 1; i++)
            {
                for (int j = i + 1; j < listatemp.Count; j++)
                {
                    if (listatemp[i].Salario < listatemp[j].Salario)
                    {
                        Funcionario temp = listatemp[i];
                        listatemp[i] = listatemp[j];
                        listatemp[j] = temp;
                    }
                }
            }

            Console.WriteLine("Funcionários com ID >= a 4 (ordenados por salario:");
            for (int i = 0; i < listatemp.Count; i++)
            {
                Console.WriteLine($"ID: {listatemp[i].Id}, Nome: {listatemp[i].Nome}, Salario: {listatemp[i].Salario}");
            }

        }
        public static void ObterEstatisticas(List<Funcionario> funcionarios)
        {
            int quantidade = 0;
            decimal totalSalarios = 0;

            for (int i = 0; i < funcionarios.Count; i++)
            {
                quantidade++;
                totalSalarios += funcionarios[i].Salario;
            }
            Console.WriteLine($"Total de funcionários: {quantidade}");
            Console.WriteLine($"Soma dos Salários: {totalSalarios}");

        }

        public static void ObterPorTipo(List<Funcionario> funcionarios)
        {
            Console.WriteLine("Escolha o tipo: ");
            Console.WriteLine("1 - CLT ");
            Console.WriteLine("2 - Aprendiz ");

            Console.WriteLine("Digite o número: ");
            string opcao = Console.ReadLine();

            Console.WriteLine("\nFuncionários Encontrados: ");
            bool encontrado = false;

            for (int i = 0; i < funcionarios.Count; i++)
            {
                Funcionario func = funcionarios[i];

                if ((opcao == "1" && func.TipoFuncionario == TipoFuncionarioEnum.CLT) || (opcao == "2" && func.TipoFuncionario == TipoFuncionarioEnum.Aprendiz))

                {
                    Console.WriteLine($"ID: {func.Id}, Nome: {func.Nome}, Salário {func.Salario}, Tipo: {func.TipoFuncionario}");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Nenhum funcionário encontrado desse tipo");
            }
        }

        public static bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 2)
            {
                Console.WriteLine("Erro: Nome deve ter pelo menos 2 caracteres!");
                return false;
            }

            return true;
        }
        
         public static bool ValidarSalarioAdmissao(decimal salario, DateTime dataAdmissao)
        {
            if (salario <= 0)
            {
                Console.WriteLine("Erro: Salário não pode ser zero ou negativo!");
                return false;
            }

            if (dataAdmissao > DateTime.Now)
            {
                Console.WriteLine("Erro: Data de admissão não pode ser futura!");
                return false;
            }

            return true;
        }

         public static void AdicionarFuncionario()
        {
            Console.WriteLine("\n=== ADICIONAR NOVO FUNCIONÁRIO ===");
            Console.WriteLine("(Teste as validações abaixo)");

            Console.Write("\nDigite o nome: ");
            string nome = Console.ReadLine();
            
            if (!ValidarNome(nome))
            {
                Console.WriteLine(" Validação de nome falhou!");
                return;
            }

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Digite o salário: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                Console.WriteLine(" Salário inválido!");
                return;
            }

            Console.Write("Digite a data de admissão (dd/MM/aaaa): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataAdmissao))
            {
                Console.WriteLine(" Data inválida!");
                return;
            }

            if (!ValidarSalarioAdmissao(salario, dataAdmissao))
            {
                Console.WriteLine(" Validação de salário/data falhou!");
                return;
            }

            Console.Write("Digite o tipo (1 - CLT, 2 - Aprendiz): ");
            string tipoOpcao = Console.ReadLine();
            TipoFuncionarioEnum tipo;
            
            if (tipoOpcao == "1")
                tipo = TipoFuncionarioEnum.CLT;
            else if (tipoOpcao == "2")
                tipo = TipoFuncionarioEnum.Aprendiz;
            else
            {
                Console.WriteLine(" Tipo inválido!");
                return;
            }

            Funcionario novoFuncionario = new Funcionario();
            novoFuncionario.Id = lista.Count + 1;
            novoFuncionario.Nome = nome;
            novoFuncionario.Cpf = cpf;
            novoFuncionario.Salario = salario;
            novoFuncionario.DataAdmissao = dataAdmissao;
            novoFuncionario.TipoFuncionario = tipo;

            lista.Add(novoFuncionario);
            Console.WriteLine(" Funcionário adicionado com sucesso!");
        }
        

    }
}
//para subir a pasta resposta