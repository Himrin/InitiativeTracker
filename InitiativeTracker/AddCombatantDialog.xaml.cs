using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InitiativeTracker.Annotations;
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
