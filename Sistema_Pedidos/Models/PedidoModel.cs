namespace Sistema_Pedidos.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string Produto { get; set;}
        public int Quantidade { get; set;}
        public double ValorTotal { get; set;}
    }
}
