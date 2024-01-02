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
            ddlFrom = new ComboBox();
            label1 = new Label();
            ddlTo = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // txbMain
            // 
            txbMain.Location = new Point(12, 120);
            txbMain.Multiline = true;
            txbMain.Name = "txbMain";
            txbMain.ReadOnly = true;
            txbMain.ScrollBars = ScrollBars.Vertical;
            txbMain.Size = new Size(342, 288);
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
            // ddlFrom
            // 
            ddlFrom.FormattingEnabled = true;
            ddlFrom.Location = new Point(12, 53);
            ddlFrom.Name = "ddlFrom";
            ddlFrom.Size = new Size(131, 23);
            ddlFrom.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 3;
            label1.Text = "From :";
            // 
            // ddlTo
            // 
            ddlTo.FormattingEnabled = true;
            ddlTo.Location = new Point(223, 53);
            ddlTo.Name = "ddlTo";
            ddlTo.Size = new Size(131, 23);
            ddlTo.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 35);
            label2.Name = "label2";
            label2.Size = new Size(25, 15);
            label2.TabIndex = 5;
            label2.Text = "To :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 420);
            Controls.Add(label2);
            Controls.Add(ddlTo);
            Controls.Add(label1);
            Controls.Add(ddlFrom);
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
        private ComboBox ddlFrom;
        private Label label1;
        private ComboBox ddlTo;
        private Label label2;
    }
}