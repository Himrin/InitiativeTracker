using System.ComponentModel;
using System.Runtime.CompilerServices;
using InitiativeTracker.Annotations;

namespace InitiativeTracker.Model
{
    public class Combatant: INotifyPropertyChanged
    {
        //Combatant attributes
        private int _initiative;
        private string _name;
        private int _counter;
        private string _displayName;

        public int Initiative
        {
            get { return _initiative; }
            set
            {
                if (_initiative != value)
                {
                    _initiative = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DexModifier { get; set; }

        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                UpdateDisplayName();
            }
        }

        public char Type { get; set; }

        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
                UpdateDisplayName();
            }
        }

        #region Constructors

        public Combatant(){}

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
        private void UpdateDisplayName()
        {
            DisplayName = Name + (Counter > 0
                ? " " + Counter
                : "");
        }

        //Clone combatant
        public Combatant Clone()
        {
            var dupe = new Combatant(this);
            //Return Clone
            return dupe;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}