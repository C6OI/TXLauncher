using System;
using System.Drawing;
using System.Windows.Forms;
using TX_Launcher.Properties;

namespace TX_Launcher {
    public partial class Launcher : Form {
        public Launcher() {
            InitializeComponent();
        }

        readonly ServerConnection connect = new ServerConnection();

        void PlayButton_MouseEnter(object sender, EventArgs e) {
            PlayButton.Image = new Bitmap(Resources.sprite_play_ru_light);
        }

        void PlayButton_MouseLeave(object sender, EventArgs e) {
            PlayButton.Image = new Bitmap(Resources.sprite_play_ru);
        }

        void PlayButton_Click(object sender, EventArgs e) {
            MessageBox.Show("InDev", "Play", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            connect.Connect(GamePath.Text);
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
