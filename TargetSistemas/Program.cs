using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
class Program
{
    static void Main()
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Soma até o índice");
        Console.WriteLine("2 - Verificar Fibonacci");
        Console.WriteLine("3 - Análise de faturamento diário");
        Console.WriteLine("4 - Percentual por estado");
        Console.WriteLine("5 - Inverter string");
        Console.Write("Opção: ");

        var opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                SomaIndice();
                break;
            case "2":
                VerificarFibonacci();
                break;
            case "3":
                AnalisarFaturamento();
                break;
            case "4":
                PercentualEstados();
                break;
            case "5":
                InverterString();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    static void SomaIndice()
    {
        int indice = 13, soma = 0, k = 0;
        while (k < indice)
        {
            k++;
            soma += k;
        }
        Console.WriteLine($"SOMA: {soma}");
    }

    static void VerificarFibonacci()
    {
        int numero = 21;
        int a = 0, b = 1;

        while (b < numero)
        {
            (a, b) = (b, a + b);
        }

        Console.WriteLine(b == numero || numero == 0
            ? $"{numero} pertence à sequência de Fibonacci."
            : $"{numero} NÃO pertence à sequência de Fibonacci.");
    }

    static void AnalisarFaturamento()
    {
        var json = File.ReadAllText("faturamento.json");
        var dados = JsonSerializer.Deserialize<List<Dados>>(json);

        var diasValidos = dados.Where(d => d.Valor > 0).ToList();
        var media = diasValidos.Average(d => d.Valor);
        var menor = diasValidos.Min(d => d.Valor);
        var maior = diasValidos.Max(d => d.Valor);
        var diasAcimaMedia = diasValidos.Count(d => d.Valor > media);

        Console.WriteLine($"Menor faturamento: {menor:F2}");
        Console.WriteLine($"Maior faturamento: {maior:F2}");
        Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
    }

    static void PercentualEstados()
    {
        var estados = new Dictionary<string, double>
            {
                { "SP", 67836.43 },
                { "RJ", 36678.66 },
                { "MG", 29229.88 },
                { "ES", 27165.48 },
                { "Outros", 19849.53 }
            };

        double total = estados.Values.Sum();

        estados.ToList().ForEach(e =>
        {
            double percentual = (e.Value / total) * 100;
            Console.WriteLine($"{e.Key}: {percentual:F2}%");
        });
    }

    static void InverterString()
    {
        string texto = "Desafio";
        char[] invertido = new char[texto.Length];

        for (int i = 0; i < texto.Length; i++)
        {
            invertido[i] = texto[texto.Length - 1 - i];
        }

        Console.WriteLine("Invertido: " + new string(invertido));
    }

    public class Dados
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }
}