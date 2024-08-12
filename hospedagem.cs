using System;

namespace Hotelaria
{
    // Classe que representa um hóspede
    class Hospede
    {
        public string Nome { get; set; }
        public int NumeroDePessoas { get; set; }
    }

    // Classe que representa uma suíte
    class Suite
    {
        public string Nome { get; set; }
        public decimal ValorBase { get; set; }
        public decimal ValorAdicionalPorPessoa { get; set; }

        public decimal CalcularValorTotal(int numeroDePessoas)
        {
            // Calcula o valor total com base no número de pessoas
            return ValorBase + (ValorAdicionalPorPessoa * (numeroDePessoas - 1));
        }
    }

    // Classe que representa o hotel
    class Hotel
    {
        public Suite Suite { get; set; }

        public void ReservarHospedagem(Hospede hospede)
        {
            decimal valorTotal = Suite.CalcularValorTotal(hospede.NumeroDePessoas);
            Console.WriteLine($"Nome do hóspede: {hospede.Nome}");
            Console.WriteLine($"Número de pessoas: {hospede.NumeroDePessoas}");
            Console.WriteLine($"Valor total a ser pago: R${valorTotal:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Inicializando uma suíte
            Suite suite = new Suite
            {
                Nome = "Suíte Luxo",
                ValorBase = 200.00m, // Valor base da suíte
                ValorAdicionalPorPessoa = 50.00m // Valor adicional por pessoa extra
            };

            // Inicializando o hotel com a suíte
            Hotel hotel = new Hotel
            {
                Suite = suite
            };

            // Recebendo informações do hóspede
            Console.Write("Digite o nome do hóspede: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número de pessoas: ");
            int numeroDePessoas;
            while (!int.TryParse(Console.ReadLine(), out numeroDePessoas) || numeroDePessoas <= 0)
            {
                Console.Write("Número de pessoas inválido. Digite novamente: ");
            }

            Hospede hospede = new Hospede
            {
                Nome = nome,
                NumeroDePessoas = numeroDePessoas
            };

            // Realizando a reserva e mostrando o valor total
            hotel.ReservarHospedagem(hospede);
        }
    }
}
