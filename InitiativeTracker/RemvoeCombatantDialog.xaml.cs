using System.Windows;

namespace InitiativeTracker
{
	/// <summary>
	/// Interaction logic for RemvoeCombatantDialog.xaml
	/// </summary>
	public partial class RemvoeCombatantDialog : Window
	{
		public RemvoeCombatantDialog()
		{
			InitializeComponent();
		}

        private void RemoveMonsters_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void KeepMonsters_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
	}
}