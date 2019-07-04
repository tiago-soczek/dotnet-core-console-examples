namespace Contoso.JustConfig
{
    public class ContosoOptions
    {
        public string Name { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}; {nameof(Order)}: {Order}; {nameof(Active)}: {Active};";
        }
    }
}
