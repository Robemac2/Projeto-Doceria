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
        public float CustoEnergia { get; private set; }
        public float CustoAgua { get; private set; }
        public float CustoGas { get; private set; }
        public float CustoSalario { get; private set; }
        public int Dias { get; private set; }
        public DateTime Horas { get; private set; }
        public float CustoGeral {  get; private set; }
        public float Lucro { get; private set; }

        public Custo(float custoEnergia, float custoAgua, float custoGas, float custoSalario, int dias, DateTime horas, float custoGeral, float lucro)
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

        public static float CalcularCustoEnergia(float custoEnergia)
        {
            return 300f / 1000f * custoEnergia;
        }

        public static float CalcularCustoAgua(float custoAgua)
        {
            return 50f / 1000f * custoAgua;
        }

        public static float CalcularCustoGas(float custoGas)
        {
            return 0.25f * custoGas / 13f;
        }

        public static float CalcularCustoSalario(int dias, int horas, float salario)
        {
            return salario / dias / horas;
        }

        public static float CalcularCustoGeral(float custoGeral)
        {
            return 1 + (custoGeral / 100);
        }

        public static float CalcularLucro(float lucro)
        {
            return 1 + (lucro / 100);
        }

        public static void SalvarCusto(Custo custo)
        {
            if (File.Exists("Custo.json"))
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
            if (File.Exists("Custo.json"))
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
