namespace HomeInc.Models
{
    public class Products
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ProductCategories Category { get; set; } = ProductCategories.Linea_Blanca;
        public string Warranty { get; set; } = "2 meses";
        public string User { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
