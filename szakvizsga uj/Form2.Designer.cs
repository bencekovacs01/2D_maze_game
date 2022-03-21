namespace szakvizsga_uj
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.jatekos = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.jatekos)).BeginInit();
            this.SuspendLayout();
            // 
            // jatekos
            // 
            this.jatekos.BackgroundImage = global::szakvizsga_uj.Properties.Resources.karakter;
            this.jatekos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.jatekos.Location = new System.Drawing.Point(0, 0);
            this.jatekos.Margin = new System.Windows.Forms.Padding(4);
            this.jatekos.Name = "jatekos";
            this.jatekos.Size = new System.Drawing.Size(67, 62);
            this.jatekos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jatekos.TabIndex = 0;
            this.jatekos.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 569);
            this.Controls.Add(this.jatekos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Labirintus ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.jatekos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox jatekos;
    }
}