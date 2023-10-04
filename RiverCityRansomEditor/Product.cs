using System;
using System.Collections.Generic;

namespace RiverCityEditor
{
    public class Product
    {
        private int itemId;
        private string itemName;
        private int itemCost;
        private int itemPrice;

        private int punchBonus;
        private int kickBonus;
        private int weaponBonus;
        private int throwBonus;
        private int agilityBonus;
        private int defenseBonus;
        private int strengthBonus;
        private int willpowerBonus;

        private int staminaBonus;

        public int ItemId { get => itemId; set => itemId = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public int ItemCost { get => itemCost; set => itemCost = value; }
        public int ItemPrice { get => itemPrice; set => itemPrice = value; }
        public int PunchBonus { get => punchBonus; set => punchBonus = value; }
        public int KickBonus { get => kickBonus; set => kickBonus = value; }
        public int WeaponBonus { get => weaponBonus; set => weaponBonus = value; }
        public int ThrowBonus { get => throwBonus; set => throwBonus = value; }
        public int AgilityBonus { get => agilityBonus; set => agilityBonus = value; }
        public int DefenseBonus { get => defenseBonus; set => defenseBonus = value; }
        public int StrengthBonus { get => strengthBonus; set => strengthBonus = value; }
        public int WillpowerBonus { get => willpowerBonus; set => willpowerBonus = value; }
        public int StaminaBonus { get => staminaBonus; set => staminaBonus = value; }

        //0x0000A611 Start of items

        //Each item record:
        //* [variable] item name terminated by 05
        //* [03 bytes] YZ WX 0V: item cost $VWX.YZ(digits are BCD)
        //* [03 bytes] ?? ?? ??: unknown
        //* [01 byte] Abilities enhanced bitmask:
        //    * 7 = punch
        //    * 6 = kick
        //    * 5 = weapon
        //    * 4 = throw
        //    * 3 = agility
        //    * 2 = defense
        //    * 1 = strength
        //    * 0 = will power
        //* [01 byte] Status enhanced bitmask:
        //    * 7 = stamina
        //*[variable] Variable length array of ability values, in the order above.
        // Array element is present only if corresponding bit is set above.

        public List<Product> GetProductList(List<byte> romByes)
        {
            List<Product> currentProducts = new List<Product>();
            int MaxProductCount = 0;
            int.TryParse(RiverCityEditor.MaxProductCount, out MaxProductCount);

            int currentProductRomLocation = 0;
            int.TryParse(RiverCityEditor.ProductsRomLocation, out currentProductRomLocation);
            if (MaxProductCount > 0)
            {
                for (int i = 0; i < MaxProductCount; i++)
                {
                    int recordSpacing = 0;
                    int.TryParse(RiverCityEditor.ProductRecordLength, out recordSpacing);
                    int ProductByteLocation = i * recordSpacing;
                    Product currentProduct = ReadProductInfo(romByes, ProductByteLocation, i);
                    currentProducts.Add(currentProduct);
                }
            }
            return currentProducts;
        }

        public Product ReadProductInfo(List<byte> romByes, int currentRomLocation, int currentProductIndex)
        {
            Product currentProduct = new Product();
            currentProduct.ItemId = currentProductIndex;
            currentProduct.ItemPrice = GetProductPrice(currentRomLocation); //romByes[currentRomLocation].ToString();
            currentRomLocation = +3;
            currentProduct.ItemName = GetProductName(currentRomLocation, romByes); //romByes[currentRomLocation].ToString();
            currentRomLocation = +currentProduct.ItemName.Length;
            
            currentProduct.StaminaBonus = romByes[currentRomLocation];
            currentProduct.PunchBonus = romByes[currentRomLocation + 1];
            currentProduct.KickBonus = romByes[currentRomLocation + 2];
            currentProduct.WeaponBonus = romByes[currentRomLocation  + 3];
            currentProduct.ThrowBonus = romByes[currentRomLocation + 4];
            currentProduct.AgilityBonus = romByes[currentRomLocation +  5];
            currentProduct.DefenseBonus = romByes[currentRomLocation +  6];
            currentProduct.StrengthBonus = romByes[currentRomLocation +  7];
            currentProduct.WillpowerBonus = romByes[currentRomLocation +  8];

            return currentProduct;
        }

        private string GetProductName(int currentRomLocation, List<byte> romByes)
        {
            //List<byte> currentProductName = new List<byte>();
            string currentProductName = string.Empty;
            byte currentByteValue = byte.MinValue;
            byte stopByte = Convert.ToByte(RiverCityEditor.StopByte);
            currentByteValue = romByes[currentRomLocation];
            while(currentByteValue != stopByte)
            {
                currentProductName = currentProductName + (HexToAsciiTranslator.GetTranslatedValue(currentByteValue));
                currentRomLocation++;
            }
            return currentProductName;
        }

        private int GetProductPrice(int currentRomLocation)
        {
            throw new NotImplementedException();
        }
    }
}