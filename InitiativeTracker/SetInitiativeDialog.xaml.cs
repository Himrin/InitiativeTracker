using System.Windows;
using Assisticant.Collections;
using InitiativeTracker.Model;

namespace InitiativeTracker
{
	/// <summary>
	/// Interaction logic for SetInitiativeDialog.xaml
	/// </summary>
	public partial class SetInitiativeDialog : Window
	{
		public SetInitiativeDialog(ObservableList<Combatant> combatants )
		{
			InitializeComponent();
		    InitiativeDisplayListBox.ItemsSource = combatants;
		}
	}
}