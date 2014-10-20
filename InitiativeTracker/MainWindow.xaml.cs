using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using InitiativeTracker.Model;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Combatant> _combatants = new ObservableCollection<Combatant>();
        private int _turnIndicator = 0;

        public MainWindow()
        {
            InitializeComponent();
            CombatantDisplayList.ItemsSource = _combatants;
        }

        private void AddCombatant_Click(object sender, RoutedEventArgs e)
        {
            var addCombatantDialog = new AddCombatantDialog {Owner = this};

            if (addCombatantDialog.ShowDialog() == true)
                _combatants.Add(addCombatantDialog.Combatant);
        }

        private void AddCopy_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in CombatantDisplayList.SelectedItems.OfType<Combatant>())
            {
                AddCombatantCopy(selectedItem);
            }
        }

        private void AddCombatantCopy(Combatant original)
        {
            var copy = original.Clone();

            //Find highest combatant counter in list with same name
            var highestCombatant = _combatants.Where(combatant => combatant.Name == copy.Name).OrderByDescending(combatant => combatant.Counter).First();

            //if highest combatant is a counter of 0, make it one
            if (highestCombatant.Counter == 0)
                highestCombatant.Counter = 1;

            copy.Counter = highestCombatant.Counter + 1;
            _combatants.Add(copy);
        }

        private void RemoveCombatant_Click(object sender, RoutedEventArgs e)
        {
            var toRemove = CombatantDisplayList.SelectedItems.OfType<Combatant>().ToList();
            foreach (var item in toRemove)
            {
                _combatants.Remove(item);
            }
        }

        private void StartCombat_Click(object sender, RoutedEventArgs e)
        {
            if (_combatants.Count == 0) return;
            StartCombat.Visibility = Visibility.Hidden;
            EndCombat.Visibility = Visibility.Visible;
            StartCombatMenuItem.IsEnabled = false;
            EndCombatMenuItem.IsEnabled = true;

            var rollerDialog = new RollInitiativeDialog() {Owner =  this};
            #region Initiative Roller logic
            if (rollerDialog.ShowDialog() == false)
            {
                EndCombat.Visibility = Visibility.Hidden;
                StartCombat.Visibility = Visibility.Visible;
            }
            else if (rollerDialog.Monsters && rollerDialog.Players)
            {
                InitiativeToRoll(_combatants,'M');
                InitiativeToRoll(_combatants,'P');
            }
            else if (rollerDialog.Monsters)
            {
                InitiativeToRoll(_combatants,'M');
                InitiativeToSet(_combatants,'P');
            }
            else
            {
                InitiativeToRoll(_combatants,'P');
                InitiativeToSet(_combatants,'M');
            }
            #endregion

            var sorted = _combatants.OrderByDescending(combatant => combatant.Initiative).ToList();

            for (var i = 0; i < sorted.Count; i++)
            {
                _combatants[i] = sorted[i];
            }

            CombatantDisplayList.SelectedItem = _combatants[_turnIndicator];
            
        }

        private void InitiativeToSet(IEnumerable<Combatant> combatants, char toSet)
        {
            var initSetDialog = new SetInitiativeDialog { Owner = this, Combatants = new ObservableCollection<Combatant>() };
            foreach (var combatant in combatants.Where(combatant => combatant.Type == toSet))
            {
                initSetDialog.Combatants.Add(combatant);
            }
            initSetDialog.InitiativeDisplayListBox.ItemsSource = initSetDialog.Combatants;
            initSetDialog.ShowDialog();
        }

        private void InitiativeToRoll(IEnumerable<Combatant> combatants, char toRoll)
        {
            foreach (var combatant in combatants.Where(combatant => combatant.Type == toRoll))
            {
                combatant.Initiative = InitiativeRoller.RollInitiativeFor(combatant);
            }
        }

        private void EndCombat_Click(object sender, RoutedEventArgs e)
        {
            EndCombat.Visibility = Visibility.Hidden;
            StartCombat.Visibility = Visibility.Visible;
            StartCombatMenuItem.IsEnabled = true;
            EndCombatMenuItem.IsEnabled = false;

            CombatantDisplayList.SelectedItem = null;
            //Remove Monster Type Combatants if Yes is clicked.
            var removeMonsterDiag = new RemvoeCombatantDialog(){Owner = this};
            if (removeMonsterDiag.ShowDialog() == true)
            {
                var toRemove = _combatants.Where(combatant => combatant.Type == 'M');
                foreach (var item in toRemove)
                {
                    _combatants.Remove(item);
                }
            }
        }

        private void NextCombatant_Click(object sender, RoutedEventArgs e)
        {
            if (_turnIndicator == _combatants.Count - 1)
                _turnIndicator = 0;
            else
                _turnIndicator++;
            CombatantDisplayList.SelectedItem = _combatants[_turnIndicator];
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            _combatants.Clear();
        }
    }
}
