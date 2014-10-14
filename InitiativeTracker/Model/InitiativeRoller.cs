using System;

namespace InitiativeTracker.Model
{
    static class InitiativeRoller
    {
        Random icosahedron = new Random();

        public int RollInitiativeFor(Combatant combatant)
        {
            return icosahedron.Next(1, 21) + combatant.DexModifier;
        }
    }
}
