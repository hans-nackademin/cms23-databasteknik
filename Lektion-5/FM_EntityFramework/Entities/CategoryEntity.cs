namespace FM_EntityFramework.Entities
{
    internal class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }
}
