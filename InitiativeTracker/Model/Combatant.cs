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

        #region Constructors
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

        //copy
        private Combatant(Combatant combatant)
        {
            Name = combatant.Name;
            Counter = combatant.Counter;
            DexModifier = combatant.DexModifier;
            Initiative = combatant.Initiative;
            Type = combatant.Type;
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
        public Combatant Clone ()
        {
            var dupe = new Combatant(this);
            //increment counter
            dupe.Counter = Counter + 1;
            //Return Clone
            return dupe;
        }
    }
}
