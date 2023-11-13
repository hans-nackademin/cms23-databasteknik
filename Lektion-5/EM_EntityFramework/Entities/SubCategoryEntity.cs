namespace EM_EntityFramework.Entities;

internal class SubCategoryEntity
{
    public int Id { get; set; }
    public string SubCategoryName { get; set; } = null!;
    public int PrimaryCategoryId { get; set; }
    public PrimaryCategoryEntity PrimaryCategory { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

}
