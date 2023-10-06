using System.Collections.Generic;
namespace RiverCityEditor
{
    public class Store
    {
        private readonly string storeName;
        readonly List<string> xxx;


        public Store(List<byte> currentRomFile)
        {
            List<Product> storeProducts = new List<Product>();
            List<StoreMenu> storeMenus = new List<StoreMenu>();

            Product productObject = new Product();

            storeProducts = productObject.GetProductList(currentRomFile);


        }
    }
}
