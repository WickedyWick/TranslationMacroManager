namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txbMain = new TextBox();
            btnHide = new Button();
            notifyIcon = new NotifyIcon(components);
            SuspendLayout();
            // 
            // txbMain
            // 
            txbMain.Location = new Point(12, 37);
            txbMain.Multiline = true;
            txbMain.Name = "txbMain";
            txbMain.ReadOnly = true;
            txbMain.ScrollBars = ScrollBars.Vertical;
            txbMain.Size = new Size(342, 371);
            txbMain.TabIndex = 0;
            // 
            // btnHide
            // 
            btnHide.Location = new Point(12, 8);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(342, 23);
            btnHide.TabIndex = 1;
            btnHide.Text = "Hide";
            btnHide.UseVisualStyleBackColor = true;
            btnHide.Click += btnHide_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "notifyIcon1";
            notifyIcon.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 420);
            Controls.Add(btnHide);
            Controls.Add(txbMain);
            Name = "Form1";
            Text = "Form1";
            TopMost = true;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbMain;
        private Button btnHide;
        private NotifyIcon notifyIcon;
    }
}