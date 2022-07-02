namespace TXLauncher {
    partial class Launcher {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.PlayButton = new System.Windows.Forms.Button();
            this.GameSearchOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.GameSearch = new System.Windows.Forms.Button();
            this.ConsoleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.Transparent;
            this.PlayButton.BackgroundImage = global::TXLauncher.Properties.Resources.sprite_play_ru;
            this.PlayButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.PlayButton.FlatAppearance.BorderSize = 0;
            this.PlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.ForeColor = System.Drawing.Color.Transparent;
            this.PlayButton.Location = new System.Drawing.Point(434, 514);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(182, 35);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            this.PlayButton.MouseEnter += new System.EventHandler(this.PlayButton_MouseEnter);
            this.PlayButton.MouseLeave += new System.EventHandler(this.PlayButton_MouseLeave);
            // 
            // GameSearchOpenDialog
            // 
            this.GameSearchOpenDialog.DefaultExt = "exe";
            this.GameSearchOpenDialog.FileName = "tankix.exe";
            this.GameSearchOpenDialog.Filter = "tankix|*.exe";
            this.GameSearchOpenDialog.Title = "Выберите файл с игрой";
            // 
            // GameSearch
            // 
            this.GameSearch.BackColor = System.Drawing.Color.Transparent;
            this.GameSearch.BackgroundImage = global::TXLauncher.Properties.Resources.find;
            this.GameSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GameSearch.FlatAppearance.BorderSize = 0;
            this.GameSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.GameSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.GameSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameSearch.ForeColor = System.Drawing.Color.Transparent;
            this.GameSearch.Location = new System.Drawing.Point(12, 506);
            this.GameSearch.Name = "GameSearch";
            this.GameSearch.Size = new System.Drawing.Size(50, 50);
            this.GameSearch.TabIndex = 3;
            this.GameSearch.UseVisualStyleBackColor = false;
            this.GameSearch.Click += new System.EventHandler(this.GameSearch_Click);
            this.GameSearch.MouseEnter += new System.EventHandler(this.GameSearch_MouseEnter);
            this.GameSearch.MouseLeave += new System.EventHandler(this.GameSearch_MouseLeave);
            // 
            // ConsoleLabel
            // 
            this.ConsoleLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConsoleLabel.Font = new System.Drawing.Font("QuadratGroteskNew", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConsoleLabel.ForeColor = System.Drawing.Color.Black;
            this.ConsoleLabel.Location = new System.Drawing.Point(12, 9);
            this.ConsoleLabel.Name = "ConsoleLabel";
            this.ConsoleLabel.Size = new System.Drawing.Size(1027, 100);
            this.ConsoleLabel.TabIndex = 4;
            this.ConsoleLabel.Text = "Вывод с консоли";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::TXLauncher.Properties.Resources.Site_BD17_1920x8402;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1051, 561);
            this.Controls.Add(this.ConsoleLabel);
            this.Controls.Add(this.GameSearch);
            this.Controls.Add(this.PlayButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.OpenFileDialog GameSearchOpenDialog;
        private System.Windows.Forms.Button GameSearch;
        private Label ConsoleLabel;
    }
}

