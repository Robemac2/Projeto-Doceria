using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Projeto_Brigadeiro.Class
{
    internal static class BaseDados
    {
        public static string LocalBaseDados()
        {
            return Application.StartupPath + @"\db\brigadeiro.db";
        }

        public static string StrConnection(string baseDados)
        {
            return @"Data Source = " + baseDados + "; Version = 3";
        }

        public static string PrecoIngrediente(string nomeIngrediente, string quantidadeAdicionada, string unidadeAdicionada)
        {
            string baseDados = LocalBaseDados();
            string strConection = StrConnection(baseDados);
            string quantidadeIngrediente, unidadeIngrediente, precoIngrediente, precoAdicionado;

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM ingredientes WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", nomeIngrediente);

                var reader = command.ExecuteReader();
                reader.Read();

                quantidadeIngrediente = reader["quantidade"].ToString();
                unidadeIngrediente = reader["unidade"].ToString();
                precoIngrediente = reader["preco"].ToString();

                command.Dispose();
                reader.Close();

                if (unidadeAdicionada == "gramas")
                {
                    switch (unidadeIngrediente)
                    {
                        case "gramas":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                        case "Kilogramas":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / (float.Parse(quantidadeIngrediente) * 1000)).ToString("N2"));
                            return precoAdicionado;
                        case "mililitros":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "Litros":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "unidades":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                    }
                }
                else if (unidadeAdicionada == "Kilogramas")
                {
                    switch (unidadeIngrediente)
                    {
                        case "gramas":
                            precoAdicionado = "R$ " + (((float.Parse(quantidadeAdicionada) * 1000) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                        case "Kilogramas":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                        case "mililitros":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "Litros":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "unidades":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                    }
                }
                else if (unidadeAdicionada == "mililitros")
                {
                    switch (unidadeIngrediente)
                    {
                        case "gramas":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "Kilogramas":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "mililitros":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                        case "Litros":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / (float.Parse(quantidadeIngrediente) * 1000)).ToString("N2"));
                            return precoAdicionado;
                        case "unidades":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                    }
                }
                else if (unidadeAdicionada == "Litros")
                {
                    switch (unidadeIngrediente)
                    {
                        case "gramas":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "Kilogramas":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "mililitros":
                            precoAdicionado = "R$ " + (((float.Parse(quantidadeAdicionada) * 1000) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                        case "Litros":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                        case "unidades":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                    }
                }
                else
                {
                    switch (unidadeIngrediente)
                    {
                        case "gramas":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "Kilogramas":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "mililitros":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "Litros":
                            precoAdicionado = "Conversão Indevida";
                            return precoAdicionado;
                        case "unidades":
                            precoAdicionado = "R$ " + ((float.Parse(quantidadeAdicionada) * float.Parse(precoIngrediente.Remove(0, 3)) / float.Parse(quantidadeIngrediente)).ToString("N2"));
                            return precoAdicionado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
            return "Conversão Indevida";
        }

        public static string PrecoProduto(string produto, string quantidade)
        {
            string baseDados = LocalBaseDados();
            string strConection = StrConnection(baseDados);
            int receitaRendimento;
            double receitaPreco, precoUnidadeReceita, precoProduto;

            SQLiteConnection con = new SQLiteConnection(strConection);

            try
            {
                con.Open();

                SQLiteCommand command = new SQLiteCommand();
                command.Connection = con;
                command.CommandText = "SELECT * FROM receitas WHERE nome LIKE @nome";
                command.Parameters.AddWithValue("@nome", produto);

                var reader = command.ExecuteReader();
                reader.Read();

                receitaRendimento = int.Parse(reader["rendimento"].ToString());
                receitaPreco = double.Parse(reader["preco"].ToString().Remove(0,3));

                command.Dispose();
                reader.Close();

                precoUnidadeReceita = receitaPreco / receitaRendimento;

                precoProduto = precoUnidadeReceita * int.Parse(quantidade);

                return "R$ " + precoProduto.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados\n" + ex, "SQLite", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                con.Close();
            }
            return "Erro para calcular o preço do produto.";
        }
    }
}
