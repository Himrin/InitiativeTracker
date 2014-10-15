using System;

namespace InitiativeTracker.Model
{
    static class InitiativeRoller
    {
        readonly static Random Icosahedron = new Random();

        public static int RollInitiativeFor(Combatant combatant)
        {
            return Icosahedron.Next(1, 21) + combatant.DexModifier;
        }
    }
}
