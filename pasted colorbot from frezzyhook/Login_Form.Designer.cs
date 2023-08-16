namespace SkyCheats
{
    partial class Login_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Form));
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Top_Panel = new System.Windows.Forms.Panel();
            this.Label_Top_Panel = new System.Windows.Forms.Label();
            this.Button2_Top_Panel = new System.Windows.Forms.Button();
            this.Button_Top_Panel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lUserControl41 = new SkyCheats.LUserControls.LUserControl4();
            this.Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Top_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Panel
            // 
            this.Button_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.Button_Panel.Controls.Add(this.lUserControl41);
            this.Button_Panel.Controls.Add(this.pictureBox2);
            this.Button_Panel.Location = new System.Drawing.Point(370, 25);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(186, 515);
            this.Button_Panel.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::SkyCheats.Properties.Resources.Picture_Button_Panel;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 5);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Top_Panel
            // 
            this.Top_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.Top_Panel.Controls.Add(this.Label_Top_Panel);
            this.Top_Panel.Controls.Add(this.Button2_Top_Panel);
            this.Top_Panel.Controls.Add(this.Button_Top_Panel);
            this.Top_Panel.Location = new System.Drawing.Point(370, 0);
            this.Top_Panel.Name = "Top_Panel";
            this.Top_Panel.Size = new System.Drawing.Size(186, 25);
            this.Top_Panel.TabIndex = 7;
            this.Top_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Top_Panel_MouseDown);
            this.Top_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Top_Panel_MouseMove);
            this.Top_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Top_Panel_MouseUp);
            // 
            // Label_Top_Panel
            // 
            this.Label_Top_Panel.AutoSize = true;
            this.Label_Top_Panel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold);
            this.Label_Top_Panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Label_Top_Panel.Location = new System.Drawing.Point(4, 6);
            this.Label_Top_Panel.Name = "Label_Top_Panel";
            this.Label_Top_Panel.Size = new System.Drawing.Size(40, 12);
            this.Label_Top_Panel.TabIndex = 4;
            this.Label_Top_Panel.Text = "BETA 1.6";
            this.Label_Top_Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Top_Panel_MouseDown);
            this.Label_Top_Panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Top_Panel_MouseMove);
            this.Label_Top_Panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Top_Panel_MouseUp);
            // 
            // Button2_Top_Panel
            // 
            this.Button2_Top_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button2_Top_Panel.FlatAppearance.BorderSize = 0;
            this.Button2_Top_Panel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2_Top_Panel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button2_Top_Panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Button2_Top_Panel.Location = new System.Drawing.Point(136, 0);
            this.Button2_Top_Panel.Name = "Button2_Top_Panel";
            this.Button2_Top_Panel.Size = new System.Drawing.Size(25, 25);
            this.Button2_Top_Panel.TabIndex = 3;
            this.Button2_Top_Panel.Text = "_";
            this.Button2_Top_Panel.UseVisualStyleBackColor = true;
            this.Button2_Top_Panel.Click += new System.EventHandler(this.Button2_Top_Panel_Click);
            // 
            // Button_Top_Panel
            // 
            this.Button_Top_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button_Top_Panel.FlatAppearance.BorderSize = 0;
            this.Button_Top_Panel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Top_Panel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button_Top_Panel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Button_Top_Panel.Location = new System.Drawing.Point(161, 0);
            this.Button_Top_Panel.Name = "Button_Top_Panel";
            this.Button_Top_Panel.Size = new System.Drawing.Size(25, 25);
            this.Button_Top_Panel.TabIndex = 2;
            this.Button_Top_Panel.Text = "X";
            this.Button_Top_Panel.UseVisualStyleBackColor = true;
            this.Button_Top_Panel.Click += new System.EventHandler(this.Button_Top_Panel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::SkyCheats.Properties.Resources.WallPaper4;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 540);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lUserControl41
            // 
            this.lUserControl41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(34)))));
            this.lUserControl41.Location = new System.Drawing.Point(0, 5);
            this.lUserControl41.Name = "lUserControl41";
            this.lUserControl41.Size = new System.Drawing.Size(186, 510);
            this.lUserControl41.TabIndex = 9;
            this.lUserControl41.Load += new System.EventHandler(this.lUserControl41_Load);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(556, 540);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Button_Panel);
            this.Controls.Add(this.Top_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SkyCheat";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Top_Panel.ResumeLayout(false);
            this.Top_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Button_Panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Top_Panel;
        private System.Windows.Forms.Button Button2_Top_Panel;
        private System.Windows.Forms.Button Button_Top_Panel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Label_Top_Panel;
        private LUserControls.LUserControl4 lUserControl41;
    }
}