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

        private void MonsterRoll_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BothRoll_Click(object sender, RoutedEventArgs e)
        {
            players = true;
            DialogResult = true;
        }

        private void PlayerRoll_Click(object sender, RoutedEventArgs e)
        {
            monsters = false;
            players = true;
            DialogResult = true;
        }
    }
}
