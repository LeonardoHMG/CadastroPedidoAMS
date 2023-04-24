using Microsoft.AspNetCore.Mvc;
using Sistema_Pedidos.Dados;
using Sistema_Pedidos.Models;

namespace Sistema_Pedidos.Controllers
{
    public class PedidoController : Controller
    {

        public static List<PedidoModel> db = new List<PedidoModel>();

        public IActionResult SalvarDados(PedidoModel dados)
        {
            if (dados.Id > 0)
            {
                Arquivo arquivo = new Arquivo();
                arquivo.EditarArquivo(dados);
                //int index = db.FindIndex(a => a.Id == dados.Id);
                //db[index] = dados;
            }
            else
            {
                dados.Id = db.Count + 1;
                db.Add(dados);
                Arquivo arquivo = new Arquivo();
                arquivo.SalvarArquivo(dados);
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Lista()
        {
            Arquivo arquivo = new Arquivo();
            return View(arquivo.ListaPedidos());
        }

        public IActionResult Excluir(int id)
        {
            Arquivo arquivo = new Arquivo();
            arquivo.ExcluirArquivo(id);
            return RedirectToAction("Lista");
        }

        public IActionResult Editar(int id)
        {
            //ClientesModelView cliente = db.Find(obj => obj.Id == id);
            //if (cliente != null)
            //{
            //    return View(cliente);
            //}
            //else
            //{
            //    return RedirectToAction("Lista");
            //}
            Arquivo arquivo = new Arquivo();

            return View(arquivo.LocalizarArquivo(id));
        }

        public IActionResult Novo()
        {

            return View();

        }

    }
}
