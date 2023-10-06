 using System.Collections.Generic;

namespace RiverCityEditor
{
    public class Gang
    {
        private readonly int gangId;
        private readonly string gangName;
        //private readonly List<GangMember> gangMembers;
        private RomFile currentRomFile;

        public int GangId => gangId;
        public string GangName => gangName;
        //public List<GangMember> GangMembers => gangMembers;

        public Gang(List<byte> currentRomFile)
        {
            List<GangMember> currentGangMembers = new List<GangMember>();
            GangMember gangMember = new GangMember();

            currentGangMembers = gangMember.GetGangMembers(currentRomFile);
        }

        private string GetGangName(List<byte> currentRomFile)
        {
            return string.Empty;

        }

        private int GetGangIds(List<byte> currentRomFile)
        {
            return 0;

        }

    }
}