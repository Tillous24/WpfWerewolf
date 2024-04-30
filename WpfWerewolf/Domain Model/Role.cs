using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_Companion.Domain_Model
{
    public class Role
    {
        public string name { get; set; }
        public string description { get; set; }
        public string ability { get; set; }
        public bool hasUsedAbility {  get; set; } 

        public Role(string name, string description, string ability)
        {
            this.name = name;
            this.description = description;
            this.ability = ability;
            hasUsedAbility = false;
        }

        public void ResetAbilityUsage()
        {
            // Reset the ability usage flag for the next round/game
            hasUsedAbility = false;
        }
    }

    public class Witch : Role
    {
        bool healPotionUsed;
        bool deathPotionUsed;
        public Witch() : base("Witch", "The witch has the ability to heal or kill another player once per game.", "Heal or Kill")
        {
            healPotionUsed = false;
            deathPotionUsed = false;
        }
    }

    public class Piper : Role
    {
        public Piper() : base("Piper", "The piper can Charm 2 players each night", "Charming")
        {
        }
    }

    public class Seer : Role
    {
        public Seer() : base("Seer", "The seer can detect the true identity of one player per night.", "Detect Identity")
        {
        }
    }

    public class Hunter : Role
    {
        public Hunter() : base("Hunter", "The hunter can kill another player if they are lynched during the day.", "Daytime Kill")
        {
        }
    }

    public class Thieve : Role
    {
        public Thieve() : base("Thieve", "The thieve can steal the ability of another player.", "Steal Ability")
        {
        }
    }

    public class Werewolf : Role
    {
        public Werewolf() : base("Werewolf", "The werewolves aim to eliminate all other players.", "Eliminate")
        {
        }
    }

    public class LittleGirl : Role
    {
        public LittleGirl() : base("Little Girl", "The little girl can secretly observe the werewolves.", "Secret Observation")
        {
        }
    }

    public class Knight : Role
    {
        public Knight() : base("Knight", "The knight can protect another player from werewolf attacks.", "Protection")
        {
        }
    }

    public class Villager : Role
    {
        public Villager() : base("Villager", "The villagers aim to identify and eliminate the werewolves.", "Identify Werewolves")
        {
        }
    }

    public class Cupid : Role
    {
        public Cupid() : base("Cupid", "Cupid can make 2 players fall madly in Love, if one of them dies the other one will join them in the afterlife.", "Linked by Love")
        {
        }
    }

    

}
