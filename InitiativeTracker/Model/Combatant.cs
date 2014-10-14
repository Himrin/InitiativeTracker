namespace InitiativeTracker.Model
{
    class Combatant
    {
        //Combatant attributes
        public int Initiative {get;  set;}
        public int DexModifier {get;  set;}
        public string Name { get; set; }
        public char Type { get;  set; }
        public int Counter { get; set; }

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


        //Display Name
        public string DisplayName()
        {
            return Name + (Counter > 0
                            ? " " + Counter
                            : "");
        }

        //Clone combatant
        public Combatant Clone (Combatant original)
        {
            var dupe = new Combatant("Dupe");
            dupe = original;
            //increment int
            dupe.Counter = original.Counter + 1;
            //Return Clone
            return dupe;
        }
    }
}
