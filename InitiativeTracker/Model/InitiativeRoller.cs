using System;

namespace InitiativeTracker.Model
{
    static class InitiativeRoller
    {
        static Random icosahedron = new Random();

        public static int RollInitiativeFor(Combatant combatant)
        {
            return icosahedron.Next(1, 21) + combatant.DexModifier;
        }
    }
}
