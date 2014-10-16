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
                var cName = addCombatantDialog.CombatantName.Text;
                var cType = addCombatantDialog.PlayerRadio.IsChecked == true ? 'P' : 'M';
                var cDexMod = (int) addCombatantDialog.DexModSlider.Value;

                _combatants.Add(new Combatant(cName,cType,cDexMod));
            };

        }
    }
}
