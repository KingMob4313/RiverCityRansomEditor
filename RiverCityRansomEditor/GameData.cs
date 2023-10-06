namespace RiverCityEditor
{
    public class GameData
    {
        private Gang gangInfo;
        private Store storeInfo;

        public Gang GangInfo { get => gangInfo; set => gangInfo = value; }
        public Store StoreInfo { get => storeInfo; set => storeInfo = value; }

        public GameData(RomFile currentRomFile)
        {
            GangInfo = new Gang(currentRomFile);
            StoreInfo = new Store(currentRomFile);
        }


    }
}
