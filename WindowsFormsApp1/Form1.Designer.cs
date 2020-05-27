namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_log = new System.Windows.Forms.TextBox();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.txt_ShipMode = new System.Windows.Forms.TextBox();
            this.btn_Setup = new System.Windows.Forms.Button();
            this.pan_main = new System.Windows.Forms.Panel();
            this.Pan_Phone_Setup = new System.Windows.Forms.Panel();
            this.Label_FileName = new System.Windows.Forms.Label();
            this.btn_Reminder = new System.Windows.Forms.Button();
            this.txt_DirPath = new System.Windows.Forms.TextBox();
            this.txt_dirPathPhone = new System.Windows.Forms.TextBox();
            this.Label_phoneName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_Copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.BackColor = System.Drawing.Color.LightGreen;
            this.txt_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log.Location = new System.Drawing.Point(369, 326);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_log.Size = new System.Drawing.Size(323, 129);
            this.txt_log.TabIndex = 0;
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.Yellow;
            this.btn_Reload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reload.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reload.ForeColor = System.Drawing.Color.Green;
            this.btn_Reload.Location = new System.Drawing.Point(518, 29);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(85, 26);
            this.btn_Reload.TabIndex = 1;
            this.btn_Reload.Text = "Reload";
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // txt_ShipMode
            // 
            this.txt_ShipMode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ShipMode.BackColor = System.Drawing.Color.LightGreen;
            this.txt_ShipMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ShipMode.Location = new System.Drawing.Point(286, 58);
            this.txt_ShipMode.Multiline = true;
            this.txt_ShipMode.Name = "txt_ShipMode";
            this.txt_ShipMode.ReadOnly = true;
            this.txt_ShipMode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_ShipMode.Size = new System.Drawing.Size(406, 239);
            this.txt_ShipMode.TabIndex = 3;
            // 
            // btn_Setup
            // 
            this.btn_Setup.BackColor = System.Drawing.Color.Yellow;
            this.btn_Setup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Setup.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_Setup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Setup.ForeColor = System.Drawing.Color.Green;
            this.btn_Setup.Location = new System.Drawing.Point(609, 29);
            this.btn_Setup.Name = "btn_Setup";
            this.btn_Setup.Size = new System.Drawing.Size(83, 26);
            this.btn_Setup.TabIndex = 4;
            this.btn_Setup.Text = "Directory";
            this.btn_Setup.UseVisualStyleBackColor = false;
            this.btn_Setup.Click += new System.EventHandler(this.btn_Setup_Click);
            // 
            // pan_main
            // 
            this.pan_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pan_main.AutoScroll = true;
            this.pan_main.BackColor = System.Drawing.Color.Transparent;
            this.pan_main.ForeColor = System.Drawing.Color.Green;
            this.pan_main.Location = new System.Drawing.Point(12, 58);
            this.pan_main.Name = "pan_main";
            this.pan_main.Size = new System.Drawing.Size(268, 239);
            this.pan_main.TabIndex = 6;
            // 
            // Pan_Phone_Setup
            // 
            this.Pan_Phone_Setup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Pan_Phone_Setup.AutoScroll = true;
            this.Pan_Phone_Setup.BackColor = System.Drawing.Color.Transparent;
            this.Pan_Phone_Setup.ForeColor = System.Drawing.Color.Green;
            this.Pan_Phone_Setup.Location = new System.Drawing.Point(12, 329);
            this.Pan_Phone_Setup.Name = "Pan_Phone_Setup";
            this.Pan_Phone_Setup.Size = new System.Drawing.Size(351, 126);
            this.Pan_Phone_Setup.TabIndex = 7;
            // 
            // Label_FileName
            // 
            this.Label_FileName.BackColor = System.Drawing.Color.Transparent;
            this.Label_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_FileName.ForeColor = System.Drawing.Color.Green;
            this.Label_FileName.Location = new System.Drawing.Point(283, 35);
            this.Label_FileName.Name = "Label_FileName";
            this.Label_FileName.Size = new System.Drawing.Size(228, 20);
            this.Label_FileName.TabIndex = 8;
            this.Label_FileName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btn_Reminder
            // 
            this.btn_Reminder.BackColor = System.Drawing.Color.Yellow;
            this.btn_Reminder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reminder.ForeColor = System.Drawing.Color.Red;
            this.btn_Reminder.Location = new System.Drawing.Point(12, 3);
            this.btn_Reminder.Name = "btn_Reminder";
            this.btn_Reminder.Size = new System.Drawing.Size(97, 29);
            this.btn_Reminder.TabIndex = 9;
            this.btn_Reminder.Text = "Reminder";
            this.btn_Reminder.UseVisualStyleBackColor = false;
            this.btn_Reminder.Visible = false;
            this.btn_Reminder.Click += new System.EventHandler(this.btn_Click);
            // 
            // txt_DirPath
            // 
            this.txt_DirPath.BackColor = System.Drawing.Color.LightGreen;
            this.txt_DirPath.ForeColor = System.Drawing.Color.Green;
            this.txt_DirPath.Location = new System.Drawing.Point(12, 35);
            this.txt_DirPath.Name = "txt_DirPath";
            this.txt_DirPath.Size = new System.Drawing.Size(265, 20);
            this.txt_DirPath.TabIndex = 10;
            // 
            // txt_dirPathPhone
            // 
            this.txt_dirPathPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_dirPathPhone.BackColor = System.Drawing.Color.LightGreen;
            this.txt_dirPathPhone.ForeColor = System.Drawing.Color.Green;
            this.txt_dirPathPhone.Location = new System.Drawing.Point(12, 303);
            this.txt_dirPathPhone.Name = "txt_dirPathPhone";
            this.txt_dirPathPhone.Size = new System.Drawing.Size(347, 20);
            this.txt_dirPathPhone.TabIndex = 11;
            // 
            // Label_phoneName
            // 
            this.Label_phoneName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_phoneName.BackColor = System.Drawing.Color.Transparent;
            this.Label_phoneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_phoneName.ForeColor = System.Drawing.Color.Green;
            this.Label_phoneName.Location = new System.Drawing.Point(365, 303);
            this.Label_phoneName.Name = "Label_phoneName";
            this.Label_phoneName.Size = new System.Drawing.Size(228, 20);
            this.Label_phoneName.TabIndex = 12;
            this.Label_phoneName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Copy.BackColor = System.Drawing.Color.Yellow;
            this.btn_Copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Copy.ForeColor = System.Drawing.Color.Green;
            this.btn_Copy.Location = new System.Drawing.Point(600, 300);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(92, 27);
            this.btn_Copy.TabIndex = 13;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.yoshi_BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(712, 467);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.Label_phoneName);
            this.Controls.Add(this.txt_dirPathPhone);
            this.Controls.Add(this.txt_DirPath);
            this.Controls.Add(this.btn_Reminder);
            this.Controls.Add(this.Label_FileName);
            this.Controls.Add(this.Pan_Phone_Setup);
            this.Controls.Add(this.pan_main);
            this.Controls.Add(this.btn_Setup);
            this.Controls.Add(this.txt_ShipMode);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.txt_log);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.TextBox txt_ShipMode;
        private System.Windows.Forms.Button btn_Setup;
        private System.Windows.Forms.Panel pan_main;
        private System.Windows.Forms.Panel Pan_Phone_Setup;
        private System.Windows.Forms.Label Label_FileName;
        private System.Windows.Forms.Button btn_Reminder;
        private System.Windows.Forms.TextBox txt_DirPath;
        private System.Windows.Forms.TextBox txt_dirPathPhone;
        private System.Windows.Forms.Label Label_phoneName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Copy;
    }
}

