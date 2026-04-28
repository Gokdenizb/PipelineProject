namespace PipelineProject.Model
{
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;} = String.Empty;
        public string Supplier {get; set;} = String.Empty;
        public Decimal Price {get; set;}
    }
}