public interface IDBService
{
    public IEnumerable<Product> GetProduct();
    public IEnumerable<Warehouse> GetWarehouse();
    public IEnumerable<Order> GetOrder();
    public IEnumerable<Product_Warehouse> GetProduct_Warehouse();
    public bool ProductExists(int idProduct, IEnumerable<Product> enumerable);
    public bool WarehouseExists(int idWarehouse, IEnumerable<Warehouse> enumerable);
    public bool CheckOrder(int idProduct, int Amount, IEnumerable<Order> enumerable);
    public bool CheckCreatedAt(DateTime createdAt, IEnumerable<Order> enumerable);
    public bool CheckCompleted(int idOrder, IEnumerable<Order> enumerable);
    public void UpdateFulfilledAt(int idOrder, IEnumerable<Order> enumerable);
    public int AddProduct_Warehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt);
    public int AddByStoredProcedureProduct_Warehouse(Order order);
    
}
