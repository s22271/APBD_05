using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data.Common;
using System.Data.SqlClient;
public class DBService : IDBService
{
    private IConfiguration _configuration;

    public DBService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<Product_Warehouse> GetProduct_Warehouse()
    {
        using var con = new SqlConnection("eee");
        using var com = new SqlCommand("eee", con);
        con.Open();
        var reader = com.ExecuteReader();
        var resultList = new List<Product_Warehouse>();
        while (reader.Read())
        {
            resultList.Add(new Product_Warehouse()
            {
                IdProductWarehouse = (int)reader["IdProductWarehouse"],
                IdWarehouse = (int)reader["IdWarehouse"],
                IdProduct = (int)reader["IdProduct"],
                IdOrder = (int)reader["IdOrder"],
                Amount = (int)reader["Amount"],
                Price = (decimal)reader["Price"],
                CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString())
            });
        }
        return resultList;
    }
    public bool ProductExists(int idProduct, IEnumerable<Product> enumerable)
    {
        foreach(Product p in enumerable)
        {
            if(p.IdProduct == idProduct)
                return true;
        }
        return false;
    }
    public bool WarehouseExists(int idWarehouse, IEnumerable<Warehouse> enumerable)
    {
        foreach (Warehouse p in enumerable)
        {
            if (p.IdWarehouse == idWarehouse)
                return true;
        }
        return false;
    }

    public bool CheckOrder(int idProduct, int Amount, IEnumerable<Order> enumerable)
    {
        foreach (Order o in enumerable)
        {
            if((o.IdProduct == idProduct)&&(o.Amount == Amount))
                return true;
        }
        return false;
    }
    public bool CheckCreatedAt(DateTime createdAt, IEnumerable<Order> enumerable)
    {
        foreach (Order o in enumerable)
        {
            if(o.CreatedAt < createdAt)
                return true;
        }
        return false;
    }
    public bool CheckCompleted(int idOrder, IEnumerable<Product_Warehouse> enumerable)
    {
        foreach (Product_Warehouse p in enumerable)
        {
            if(p.IdOrder == idOrder)
                return true;
        }
        return false;
    }
    
    public void UpdateFulfilledAt(int idOrder, IEnumerable<Order> enumerable)
    {
        foreach (Order o in enumerable)
        {
            if (o.IdOrder == idOrder)
                o.FulfilledAt = DateTime.Now;
        }
    }

    public int AddProduct_Warehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt)
    {
        throw new NotImplementedException();
    }
    public int AddByStoredProcedureProduct_Warehouse(Order order)
    {
        throw new NotImplementedException();
    }

    /* public int AddProduct(int IdProduct, int IdWarehouse, int Amount)
{
    using var con = new SqlConnection(_configuration.GetConnectionString("jakiś string")){
        using var com = new SqlCommand("insert", con);
    {
        con.Open();
        DbTransaction tran = con.BeginTransaction();
        com.Transaction = (SqlTransaction) tran;
        try
        {

            using (var dr = com.ExecuteReader())
            {
                while(dr.Read())
                {
                    com.Parameters.Add(new Product
                    {
                        IdProduct = (int)dr["IdProduct"],
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Price = (decimal)dr["Price"]
                    });
                }
            }
            com.Parameters.Clear();
            com.CommandText = "INSERT INTO Product VALUES (@IdProduct, @Name, @Description, @Value);";
            com.Parameters.AddWithValue("@IdAnimal", );
        }
        catch
        {

        }



    }
    }
   }*/
}
