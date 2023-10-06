using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverCityEditor
{
    public class GangMember
    {
        private int gangId;
        private string name;
        private int stamina;
        private int punch;
        private int kick;
        private int weapon;
        private int throwing;
        private int agility;
        private int defense;
        private int strength;
        private int willpower;
        private int cash;

        public int GangId { get => gangId; set => gangId = value; }
        public string Name { get => name; set => name = value; }
        public int Stamina { get => stamina; set => stamina = value; }
        public int Punch { get => punch; set => punch = value; }
        public int Kick { get => kick; set => kick = value; }
        public int Weapon { get => weapon; set => weapon = value; }
        public int Throwing { get => throwing; set => throwing = value; }
        public int Agility { get => agility; set => agility = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Willpower { get => willpower; set => willpower = value; }
        public int Cash { get => cash; set => cash = value; } //cents not dollars

        public List<GangMember> GetGangMembers(List<byte> romByes)
        {
            List<GangMember> currentGangMembers = new List<GangMember>();
            int currentMaxGangSize = 0;
            int.TryParse(RiverCityEditor.MaxGangSize, out currentMaxGangSize);

            int currentGangMemberRomLocation = 0;
            int.TryParse(RiverCityEditor.GangMembersRomLocation, out currentGangMemberRomLocation);
            if (currentMaxGangSize > 0)
            {
                for (int i = 0; i < currentMaxGangSize; i++)
                {
                    int recordSpacing = 0;
                    int.TryParse(RiverCityEditor.GangMemberRecordLength, out recordSpacing);
                    int GangMemberByteLocation = i * recordSpacing;
                    GangMember currentGangBanger = ReadGangMemberInfo(romByes, currentGangMemberRomLocation, i);
                    currentGangMembers.Add(currentGangBanger);
                }
            }
            return currentGangMembers;
        }

        private GangMember ReadGangMemberInfo(List<byte> romByes, int currentRomLocation, int currentGangMemberIndex)
        {
            GangMember currentGangBanger = new GangMember();
            currentGangBanger.GangId = currentGangMemberIndex;
            currentGangBanger.Name = GetGangMemberName(currentRomLocation); //romByes[currentRomLocation].ToString();

            currentGangBanger.Stamina = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length]);
            currentGangBanger.Punch = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 1]);
            currentGangBanger.Kick = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 2]);
            currentGangBanger.Weapon = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 3]);
            currentGangBanger.Throwing = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 4]);
            currentGangBanger.Agility = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 5]);
            currentGangBanger.Defense = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 6]);
            currentGangBanger.Strength = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 7]);
            currentGangBanger.Willpower = Convert.ToInt32(romByes[currentRomLocation + currentGangBanger.Name.Length + 8]);
            currentGangBanger.Cash = Convert.ToInt32(GetGangMemberCash(currentGangBanger.Name.Length + 9)); //romByes[currentRomLocation + 1];

            return currentGangBanger;
        }

        private string GetGangMemberName(int currentRomLocation)
        {
            string currentGangMemberName = string.Empty;
            //
            return currentGangMemberName;
        }

        private int GetGangMemberCash(int currentRomLocation)
        {
            //Not sure: [03 bytes] YZ WX 0V: item cost $VWX.YZ(digits are BCD)
            int currentGangMemberCash = 0; //cents again
            //
            
            return currentGangMemberCash;
        }


    }
}
