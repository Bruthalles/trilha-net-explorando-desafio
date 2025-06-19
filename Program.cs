using System.Text;
using DesafioProjetoHospedagem.Models;
using static System.Console;
using System.Globalization;

namespace DesafioProjetoHospedage{

    public static class Program{
        public static int qtdPessoas;
        public static int diasReserva;

        static void Main(string[] args){
            OutputEncoding = Encoding.UTF8;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            List<Pessoa> hospedes = new List<Pessoa>();

            //Cadastro dinâmico
            Write("\nQuantas pessoas quer hospedar ? ");
            qtdPessoas = int.Parse(ReadLine());

            for (int i = 0; i < qtdPessoas; i++){
                Pessoa p = new Pessoa();

                Write($"\nDigite o nome da {i+1}° pessoa: ");
                p.Nome = ReadLine();
                hospedes.Add(p);
            }
            // Cria a suíte
            Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 100);

            // Cria Reserva e cadastra a suite
            Reserva reserva = new Reserva();
            reserva.CadastrarSuite(suite);

            // Verifica e cadastra os hóspedes
            reserva.CadastrarHospedes(hospedes);

            //Salvando dias reservados
            Write("\nQuantos dias deseja se hospedar ? ");
            diasReserva = Convert.ToInt32(ReadLine()); 
            reserva.DiasReservados = diasReserva;

            // Exibe a quantidade de hóspedes e o valor da diária
            reserva.ObterQuantidadeHospedes();
            reserva.CalcularValorDiaria();
        }
    }
}