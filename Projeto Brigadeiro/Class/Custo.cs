using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projeto_Brigadeiro
{
    public class Custo
    {
        [JsonIgnore]
        public Custo CustoCadastro { get; private set; }
        public decimal CustoEnergia { get; private set; }
        public decimal CustoAgua { get; private set; }
        public decimal CustoGas { get; private set; }
        public decimal CustoSalario { get; private set; }
        public int Dias { get; private set; }
        public DateTime Horas { get; private set; }
        public decimal CustoGeral { get; private set; }
        public decimal Lucro { get; private set; }

        public Custo( decimal custoEnergia, decimal custoAgua, decimal custoGas, decimal custoSalario, int dias, DateTime horas, decimal custoGeral, decimal lucro )
        {
            CustoEnergia = custoEnergia;
            CustoAgua = custoAgua;
            CustoGas = custoGas;
            CustoSalario = custoSalario;
            Dias = dias;
            Horas = horas;
            CustoGeral = custoGeral;
            Lucro = lucro;
        }

        public static decimal CalcularCustoEnergia( decimal custoEnergia )
        {
            return 300m / 1000m * custoEnergia;
        }

        public static decimal CalcularCustoAgua( decimal custoAgua )
        {
            return 50m / 1000m * custoAgua;
        }

        public static decimal CalcularCustoGas( decimal custoGas )
        {
            return 0.25m * custoGas / 13m;
        }

        public static decimal CalcularCustoSalario( int dias, int horas, decimal salario )
        {
            return salario / dias / horas;
        }

        public static decimal CalcularCustoGeral( decimal custoGeral )
        {
            return 1m + (custoGeral / 100m);
        }

        public static decimal CalcularLucro( decimal lucro )
        {
            return 1m + (lucro / 100m);
        }

        public static void SalvarCusto( Custo custo )
        {
            if ( File.Exists("Custo.json") )
            {
                string nomeArquivo = "Custo.json";
                string salvar = JsonSerializer.Serialize(custo);
                File.WriteAllText(nomeArquivo, salvar);
            }
            else
            {
                CriarCusto();
            }
        }

        public static void CriarCusto()
        {
            if ( File.Exists("Custo.json") )
            {
                string nomeArquivo = "Custo.json";
                string carregar = File.ReadAllText(nomeArquivo);
                Custo custo = JsonSerializer.Deserialize<Custo>(carregar);
                custo.CustoCadastro = custo;
            }
            else
            {
                File.Create(@".\Custo.json").Close();
                PrimeiroCusto form1 = new PrimeiroCusto();
                form1.ShowDialog();
            }
        }

        public static Custo CarregarCusto()
        {
            string nomeArquivo = "Custo.json";
            string carregar = File.ReadAllText(nomeArquivo);
            Custo custo = JsonSerializer.Deserialize<Custo>(carregar);
            custo.CustoCadastro = custo;
            return custo;
        }
    }
}
