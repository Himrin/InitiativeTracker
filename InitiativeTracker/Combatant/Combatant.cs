using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.Combatant
{
    class Combatant
    {
        //Combatant attributes
        public int Initiative {get;  set;}
        public int DexModifier {get;  set;}
        public string Name { get; private set; }
        public char Type { get;  set; }
        public int Counter { get; private set; }

        //Constructors
        public Combatant(string name)
        {
            Name = name;
            Type = 'P';
        }

        public Combatant(string name, char type)
        {
            Name = name;
            Type = type;
        }

        public Combatant(string name, char type, int modifier)
        {
            Name = name;
            Type = type;
            DexModifier = modifier;
        }
        
        #region Initative Functions
		 
	    public void SetInit (int val)
        {
            this.Initiative = val;
        }
        
        public void SetDexMod (int mod)
        {
            this.DexModifier = mod;
        }

        #endregion

        //Set Name
        public void SetName (string name)
        {
            Name = name;
        }


        //Set Type
        public void SetType (char identifier)
        {
            Type = identifier;
        }

        //Set Counter
        public void SetCounter(int counter)
        {
            Counter = counter;
        }

        //Clone combatant
        public Combatant Clone (Combatant original)
        {
            Combatant dupe = new Combatant("dupe");
            int newCount;
            dupe = original;
            //increment int
            newCount = original.Counter + 1;
            //set new append
            dupe.SetName(original.Name + " " + newCount.ToString());
            //Set new counter
            dupe.SetCounter(newCount);
            //Return Clone
            return dupe;
        }
    }
}
