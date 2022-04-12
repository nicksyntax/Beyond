using System;

namespace Beyond.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int Stock_available { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }
}