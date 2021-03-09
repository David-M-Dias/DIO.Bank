using System;
using System.Collections.Generic;
namespace DIO.Bank
{
    class Program
    {
        static List <Conta> listConta = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                     case "C":
                        Console.Clear();
                        break;
                   
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
               opcaoUsuario = ObterOpcaoUsuario(); 

            }

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Obrigado por utilizar nossos serviços.Tenha um otimo dia!");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.ReadLine();
        }

        //Metodo para transferir
        private static void Transferir()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("\t\t TRANSFERÊNCIA");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.Write("Digite a conta de origem: ");
            int indeceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listConta[indeceContaOrigem].Transferir(valorTransferencia, listConta[indiceContaDestino]);
        }

        //Metodo para Depositar.
        private static void Depositar()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("\t\t DEPOSITO");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.Write("Digite o número da conta: ");
            int indeceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser Depositado: R$");
            double valorDeposito = double.Parse(Console.ReadLine());

            listConta[indeceConta].Depositar(valorDeposito);
        }

        //Metodo Sacar
        private static void Sacar()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("\t\t Saque");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.Write("Digite o número da Conta:");
            int indeceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser sacado:R$ ");
            double valorSaque = double.Parse(Console.ReadLine());

            listConta[indeceConta].Sacar(valorSaque);
        }

        //metodo para Listar as contas
        private static void ListarContas()
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("\t\t Listar Conta");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            if(listConta.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listConta.Count; i++){
                Conta conta = listConta[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        //Metodo Inserir Conta
        private static void InserirConta()
        {  
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("\t\t Inserir nova conta");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            Console.Write("Digite [1] para Conta Física ou [2] para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial do Cliente: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito:entradaCredito,
                                        nome: entradaNome);



            listConta.Add(novaConta);

        }

        //Menu Interface Para Usuario
        private static string ObterOpcaoUsuario()
        {   
            Console.WriteLine();
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("\t\tDio Bank \n \t Bem Mais que um Banco!");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("[1] - Listar Contas");
            Console.WriteLine("[2] - Inserir Nova Conta");
            Console.WriteLine("[3] - Transferir");
            Console.WriteLine("[4] - Sacar");
            Console.WriteLine("[5] - Depositar");
            Console.WriteLine("[C] - Limpar Tela");
            Console.WriteLine("[X] - Sair\n");
            Console.Write("Informe a opção desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
