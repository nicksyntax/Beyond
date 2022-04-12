using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Beyond.Entities
{
    public class ProductsDao
    {
        public static List<ProductEntity> GetAll()
        {
            Database database;
            DbCommand dbCommand;
            List<ProductEntity> ProductList = null;
            ProductList = new List<ProductEntity>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            database = factory.Create("Data Source=.;Initial Catalog=BeyondDB;Integrated Security=True");
            dbCommand = database.GetSqlStringCommand("Select * from products");
            DataTable prods = new DataTable();
            prods = database.ExecuteDataSet(dbCommand).Tables[0];
            return ProductList;
        }
    }
}
