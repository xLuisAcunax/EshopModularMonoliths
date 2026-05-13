namespace Catalog.Data.Seed
{
    public static class InitialData
    {
        public static IEnumerable<Product> Products =>
            new List<Product>
            {
                Product.Create(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"), "iPhone X", ["category1"], "Long description", "imagefile", 500)
            };
    }
}
