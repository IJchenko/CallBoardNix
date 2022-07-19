namespace CallBoardNix.Models.Advert
{
    public class CategoryResult
    {
        public IQueryable<CategoryView> CategoryView { get; set; }
        public CategoryResult(IQueryable<CategoryView> categoryView)
        {
            CategoryView = categoryView;
        }
    }
}
