using System;
using System.Collections.ObjectModel;
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
            foreach (Combatant selectedItem in CombatantDisplayList.SelectedItems)
            {
                var copy = selectedItem.Clone();
                foreach (var combatant in _combatants)
                {
                    if (copy.Name == combatant.Name && copy.Counter < combatant.Counter)
                    {
                        copy.Counter = combatant.Counter;
                    }
                }
                copy.Counter++;
                _combatants.Add(copy);
            }
        }
    }
}
