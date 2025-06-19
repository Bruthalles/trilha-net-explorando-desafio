using System.Globalization;
namespace DesafioProjetoHospedagem.Models{
    public class Reserva{
        
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados){
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes){
            
            if (Suite.Capacidade >= hospedes.Count)Hospedes = hospedes;

            else throw new StackOverflowException($" Você excedeu a Capacidade da suite de {Suite.Capacidade} pessoas. A reserva está cancelada! ");
        }

        public void CadastrarSuite(Suite suite){
            Suite = suite;
        }

        public int ObterQuantidadeHospedes(){

            Console.WriteLine($"Capacidade total da suíte reservada: {Suite.Capacidade}");
            Console.WriteLine($"Quantidade de hóspedes cadastrados: {Hospedes.Count}");
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria(){
            
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10){
                Console.WriteLine("Você recebeu um desconto de 10% !");
                Console.WriteLine($"Valor original: {valor:C}");
                decimal desconto = (10 * valor) / 100;
                valor -= desconto;
                Console.WriteLine($"Valor final: {valor:C}");
            }
            else Console.WriteLine($"Valor final: {valor:C}");

            return valor;
        }
    }
}