namespace LivingDoc.Demo.Support.Database
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceBooks = new ReferenceBookList();
        }

        public ReferenceBookList ReferenceBooks { get; set; }
    }
}
