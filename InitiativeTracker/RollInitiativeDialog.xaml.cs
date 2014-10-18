using System.Windows;

namespace InitiativeTracker
{
    /// <summary>
    /// Interaction logic for RollInitiativeDialog.xaml
    /// </summary>
    public partial class RollInitiativeDialog : Window
    {
        public bool Monsters { get; set; }
        public bool Players { get; set; }
        public RollInitiativeDialog()
        {
            InitializeComponent();
        }

        private void MonsterRoll_Click(object sender, RoutedEventArgs e)
        {
            Monsters = true;
            Players = false;
            DialogResult = true;
        }

        private void BothRoll_Click(object sender, RoutedEventArgs e)
        {
            Players = true;
            Monsters = true;
            DialogResult = true;
        }

        private void PlayerRoll_Click(object sender, RoutedEventArgs e)
        {
            Monsters = false;
            Players = true;
            DialogResult = true;
        }
    }
}
