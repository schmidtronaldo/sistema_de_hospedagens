using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Console.Write("Digite a quantidade de pessoas: ");
int quantidadePessoas = int.Parse(Console.ReadLine());

for (int i = 1; i <= quantidadePessoas; i++)
{
    Console.Write($"Digite o nome do hóspede {i}: ");
    string nome = Console.ReadLine();
    hospedes.Add(new Pessoa(nome: nome));
}

Console.Write("Digite a quantidade de dias para reserva: ");
int diasReservados = int.Parse(Console.ReadLine());

decimal valorDiaria = 90;
int capacidadePorSuite = 2;

int numeroDeSuites = (int)Math.Ceiling((double)quantidadePessoas / capacidadePorSuite);

List<Reserva> reservas = new List<Reserva>();

for (int i = 0; i < numeroDeSuites; i++)
{
    Suite suite = new Suite(tipoSuite: "Popular", capacidade: capacidadePorSuite, valorDiaria: valorDiaria);
    Reserva reserva = new Reserva(diasReservados: diasReservados);
    reserva.CadastrarSuite(suite);

    int inicio = i * capacidadePorSuite;
    int fim = Math.Min(inicio + capacidadePorSuite, quantidadePessoas);
    reserva.CadastrarHospedes(hospedes.GetRange(inicio, fim - inicio));

    reservas.Add(reserva);
}

decimal valorTotal = 0;
foreach (var reserva in reservas)
{
    valorTotal += reserva.CalcularValorDiaria();
}

for (int i = 0; i < reservas.Count; i++)
{
    Console.WriteLine($"Reserva {i + 1}:");
    Console.WriteLine($"  Hóspedes: {reservas[i].ObterQuantidadeHospedes()}");
    Console.WriteLine($"  Valor total da diária para {diasReservados} dias: {reservas[i].CalcularValorDiaria():C}");
    
}

Console.WriteLine($"  Valor da diaria: {valorDiaria:C}");
Console.WriteLine($"  Capacidade por suite: {capacidadePorSuite}");
Console.WriteLine($"Valor total geral da reserva: {valorTotal:C}");

