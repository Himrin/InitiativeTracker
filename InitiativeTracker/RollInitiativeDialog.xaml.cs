using System.Windows;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for RollInitiativeDialog.xaml
    /// </summary>
    public partial class RollInitiativeDialog : Window
    {
        public bool monsters = true;
        public bool players = false;
        public RollInitiativeDialog()
        {
            InitializeComponent();
        }
    }
}
