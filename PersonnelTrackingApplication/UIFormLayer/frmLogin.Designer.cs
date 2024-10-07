namespace PersonnelTrackingApplication.UIFormLayer
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelTools = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rdbSqlServer = new System.Windows.Forms.RadioButton();
            this.rdbSQLite = new System.Windows.Forms.RadioButton();
            this.panelTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 121);
            this.label1.TabIndex = 19;
            this.label1.Text = "PERSONNEL TRACKING APPLICATION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTools
            // 
            this.panelTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTools.Controls.Add(this.btnClose);
            this.panelTools.Controls.Add(this.btnLogin);
            this.panelTools.Controls.Add(this.rdbSqlServer);
            this.panelTools.Controls.Add(this.rdbSQLite);
            this.panelTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panelTools.Location = new System.Drawing.Point(31, 177);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(531, 337);
            this.panelTools.TabIndex = 20;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnClose.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Location = new System.Drawing.Point(83, 219);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(358, 51);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLogin.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(83, 146);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(358, 51);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // rdbSqlServer
            // 
            this.rdbSqlServer.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbSqlServer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbSqlServer.Location = new System.Drawing.Point(290, 54);
            this.rdbSqlServer.Name = "rdbSqlServer";
            this.rdbSqlServer.Size = new System.Drawing.Size(151, 38);
            this.rdbSqlServer.TabIndex = 2;
            this.rdbSqlServer.TabStop = true;
            this.rdbSqlServer.Text = "SQL SERVER";
            this.rdbSqlServer.UseVisualStyleBackColor = true;
            this.rdbSqlServer.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdbSQLite
            // 
            this.rdbSQLite.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbSQLite.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbSQLite.Location = new System.Drawing.Point(83, 54);
            this.rdbSQLite.Name = "rdbSQLite";
            this.rdbSQLite.Size = new System.Drawing.Size(153, 38);
            this.rdbSQLite.TabIndex = 1;
            this.rdbSQLite.TabStop = true;
            this.rdbSQLite.Text = "SQLITE";
            this.rdbSQLite.UseVisualStyleBackColor = true;
            this.rdbSQLite.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(597, 576);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEntrance";
            this.panelTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.RadioButton rdbSQLite;
        private System.Windows.Forms.RadioButton rdbSqlServer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLogin;
    }
}