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
            _combatants.Add(new Combatant("Test Combatant", 'P', 3));
            CombatantDisplayList.ItemsSource = _combatants;
        }

        private void AddCombatant_Click(object sender, RoutedEventArgs e)
        {
            var addCombatantDialog = new AddCombatantDialog {Owner = this};
            
            if (addCombatantDialog.ShowDialog() == true)
            {
                _combatants.Add(addCombatantDialog.Combatant);
            };

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
            StartCombat.Visibility = Visibility.Hidden;
            EndCombat.Visibility = Visibility.Visible;

            var sorted = _combatants.OrderByDescending(combatant => combatant.Initiative).ToList();
            for (var i = 0; i < sorted.Count; i++)
            {
                _combatants[i] = sorted[i];
            }
        }
    }
}
