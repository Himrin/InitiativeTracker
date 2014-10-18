using System.Windows;
using InitiativeTracker.Model;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for AddCombatantDialog.xaml
    /// </summary>
    public partial class AddCombatantDialog : Window
    {
        public Combatant Combatant { get; set; }
        public AddCombatantDialog()
        {

            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = CombatantName.Text;
            var type = PlayerRadio.IsChecked == true ? 'P' : 'M';
            var dexMod = (int) DexModSlider.Value;
            Combatant = new Combatant(name,type,dexMod);
            DialogResult = true;
        }
    }
}
