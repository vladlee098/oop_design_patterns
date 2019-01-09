namespace design_patterns.Core
{
    public interface IProduct
    {
        string Name { get; }
    }

    public class ProductA : IProduct
    {
        private string _name = "ProductA";
        public virtual string Name
        {
            get
            {
                return _name;
            }
        }
    }

    public class ProductB : IProduct
    {
        private string _name = "ProductB";
        public virtual string Name
        {
            get
            {
                return _name;
            }
        }
    }

}