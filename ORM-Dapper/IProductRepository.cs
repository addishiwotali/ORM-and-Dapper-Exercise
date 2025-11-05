namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void CreateProduct(string name , double price , int categoryId , bool onSale , int stockLevel);
    public void DeleteProduct(int productId);
    public void UpdateProduct(string name, double price, int categoryId, bool onSale, int stockLevel , int productId);
}