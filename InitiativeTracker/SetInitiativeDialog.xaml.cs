using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using InitiativeTracker.Model;

namespace InitiativeTracker
{
	/// <summary>
	/// Interaction logic for SetInitiativeDialog.xaml
	/// </summary>
	public partial class SetInitiativeDialog : Window
	{
        public ObservableCollection<Combatant> Combatants { get; set; }
        public SetInitiativeDialog(ObservableCollection<Combatant> combatants)
		{
			InitializeComponent();
            Combatants = combatants;
		    InitiativeDisplayListBox.ItemsSource = combatants;
		}

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (var combatant in Combatants)
            {
                combatant.Initiative = 0;
            }
            DialogResult = false;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
	}
}