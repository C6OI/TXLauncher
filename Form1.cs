using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TX_Launcher.Properties;

namespace TX_Launcher {
    public partial class Launcher : Form {

        ServerConnection connect = new ServerConnection();

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

        void PlayButton_Click(object sender, EventArgs e) {
            MessageBox.Show("InDev", "Play", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            connect.Connect(GamePath.Text);
        }

        void PlayButton_MouseEnter(object sender, EventArgs e) {
            PlayButton.Image = new Bitmap(Resources.sprite_play_ru_light);
        }

        void PlayButton_MouseLeave(object sender, EventArgs e) {
            PlayButton.Image = new Bitmap(Resources.sprite_play_ru);
        }

        void GamePath_MouseDown(object sender, MouseEventArgs e) {
            GamePath.Text = "";
        }

        void Launcher_MouseDown(object sender, MouseEventArgs e) {
            if (GamePath.Text.Trim() == "") {
                GamePath.Text = "Введите путь до игры, например: C:/Games/TankiX";
            }
        }
    }
}
