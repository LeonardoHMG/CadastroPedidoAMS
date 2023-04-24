using Sistema_Pedidos.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System;

namespace Sistema_Pedidos.Dados
{
    public class Arquivo
    {
        public void SalvarArquivo(PedidoModel dados)
        {
            List<PedidoModel> array;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                array = JsonSerializer.Deserialize<List<PedidoModel>>(meusDados);
                array.Add(dados);


            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(array));
        }

        public List<PedidoModel> ListaPedidos()
        {
            List<PedidoModel> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<PedidoModel>>(meusDados);
                return retorno;

            }
        }

        public void ExcluirArquivo(int id)
        {
            List<PedidoModel> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<PedidoModel>>(meusDados);
                PedidoModel item = retorno.Find(a => a.Id == id);
                if (item != null)
                {
                    retorno.Remove(item);
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(retorno));
        }

        public void EditarArquivo(PedidoModel dados)
        {
            List<PedidoModel> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<PedidoModel>>(meusDados);
                int item = retorno.FindIndex(a => a.Id == dados.Id);
                if (item != null)
                {
                    retorno[item] = dados;
                }

            }
            File.WriteAllText(@"data.json", JsonSerializer.Serialize(retorno));
        }

        public PedidoModel LocalizarArquivo(int Id)
        {
            List<PedidoModel> retorno;
            using (StreamReader r = new StreamReader(@"data.json"))
            {
                string meusDados = r.ReadToEnd();
                retorno = JsonSerializer.Deserialize<List<PedidoModel>>(meusDados);
                PedidoModel item = retorno.Find(a => a.Id == Id);
                if (item != null)
                {
                    return item;
                }
                else
                {
                    return new PedidoModel();
                }

            }
        }
    }
}
