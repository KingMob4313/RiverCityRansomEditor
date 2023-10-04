using System.Collections.Generic;

namespace RiverCityEditor
{
    public class Gang
    {
        private readonly int gangId;
        private readonly string gangName;
        private readonly List<GangMember> gangMembers;

        public int GangId => gangId;
        public string GangName => gangName;
        public List<GangMember> GangMembers => gangMembers;
    }
}