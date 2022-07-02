using System.Diagnostics;
using TXLauncher.Properties;

namespace TXLauncher {
    public partial class Launcher : Form {

        readonly ServerConnection Connect = new();

        public Launcher() {
            InitializeComponent();

            if (!CheckNetwork.CheckNetworkAvailable()) {
                DialogResult networkInaccesible = MessageBox.Show("Интернет недоступен. Проверьте подключение к интернету.",
                    "Интернет недоступен",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
                if (networkInaccesible == DialogResult.Retry) {
                    Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                } else {
                    Environment.Exit(0);
                }
            }
        }

        public void ConsoleLabelOutput(string output) {
            ConsoleLabel.Text += $"\n{output}";
        }

        void PlayButton_Click(object sender, EventArgs e) {
            MessageBox.Show("InDev", "Play", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        void PlayButton_MouseEnter(object sender, EventArgs e) {
            PlayButton.BackgroundImage = new Bitmap(Resources.sprite_play_ru_light);
        }

        void PlayButton_MouseLeave(object sender, EventArgs e) {
            PlayButton.BackgroundImage = new Bitmap(Resources.sprite_play_ru);
        }

        void GameSearch_MouseEnter(object sender, EventArgs e) {
            GameSearch.BackgroundImage = new Bitmap(Resources.find_light);
        }

        void GameSearch_MouseLeave(object sender, EventArgs e) {
            GameSearch.BackgroundImage = new Bitmap(Resources.find);
        }

        void GameSearch_Click(object sender, EventArgs e) {
            GameSearchOpenDialog.ShowDialog();

            Connect.gamePath = GameSearchOpenDialog.FileName;
        }
    }
}
