using System.Collections.Generic;
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
    }
}
