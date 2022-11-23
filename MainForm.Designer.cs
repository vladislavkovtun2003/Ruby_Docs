
namespace Ruby_Docs
{
    partial class MainForm
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

        #region Код, автоматично створений конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnExample = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btnClass = new System.Windows.Forms.Button();
            this.btnExpression = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelLogo = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnGlobalSearch = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.labelTop = new System.Windows.Forms.Label();
            this.panelOpenChildForm = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelOpenChildForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.btnExample);
            this.panelMenu.Controls.Add(this.btnType);
            this.panelMenu.Controls.Add(this.btnClass);
            this.panelMenu.Controls.Add(this.btnExpression);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 661);
            this.panelMenu.TabIndex = 0;
            // 
            // btnExample
            // 
            this.btnExample.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExample.FlatAppearance.BorderSize = 0;
            this.btnExample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExample.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExample.Location = new System.Drawing.Point(0, 300);
            this.btnExample.Name = "btnExample";
            this.btnExample.Size = new System.Drawing.Size(200, 75);
            this.btnExample.TabIndex = 1;
            this.btnExample.Text = "Приклади";
            this.btnExample.UseVisualStyleBackColor = true;
            this.btnExample.Click += new System.EventHandler(this.btnExample_Click);
            // 
            // btnType
            // 
            this.btnType.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnType.FlatAppearance.BorderSize = 0;
            this.btnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnType.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnType.Location = new System.Drawing.Point(0, 225);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(200, 75);
            this.btnType.TabIndex = 1;
            this.btnType.Text = "Типи Даних";
            this.btnType.UseVisualStyleBackColor = true;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnClass
            // 
            this.btnClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClass.FlatAppearance.BorderSize = 0;
            this.btnClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClass.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClass.Location = new System.Drawing.Point(0, 150);
            this.btnClass.Name = "btnClass";
            this.btnClass.Size = new System.Drawing.Size(200, 75);
            this.btnClass.TabIndex = 1;
            this.btnClass.Text = "Класи";
            this.btnClass.UseVisualStyleBackColor = true;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnExpression
            // 
            this.btnExpression.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.btnExpression.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExpression.FlatAppearance.BorderSize = 0;
            this.btnExpression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpression.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExpression.Location = new System.Drawing.Point(0, 75);
            this.btnExpression.Name = "btnExpression";
            this.btnExpression.Size = new System.Drawing.Size(200, 75);
            this.btnExpression.TabIndex = 1;
            this.btnExpression.Text = "Вирази";
            this.btnExpression.UseVisualStyleBackColor = false;
            this.btnExpression.Click += new System.EventHandler(this.btnExpression_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.panelLogo.Controls.Add(this.labelLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 75);
            this.panelLogo.TabIndex = 0;
            // 
            // labelLogo
            // 
            this.labelLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLogo.AutoSize = true;
            this.labelLogo.ForeColor = System.Drawing.Color.White;
            this.labelLogo.Location = new System.Drawing.Point(23, 27);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(154, 20);
            this.labelLogo.TabIndex = 0;
            this.labelLogo.Text = "Документація Ruby";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(80)))));
            this.panelTop.Controls.Add(this.btnGlobalSearch);
            this.panelTop.Controls.Add(this.btnCloseChildForm);
            this.panelTop.Controls.Add(this.labelTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(200, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 75);
            this.panelTop.TabIndex = 1;
            // 
            // btnGlobalSearch
            // 
            this.btnGlobalSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGlobalSearch.FlatAppearance.BorderSize = 0;
            this.btnGlobalSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGlobalSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnGlobalSearch.Image")));
            this.btnGlobalSearch.Location = new System.Drawing.Point(909, 0);
            this.btnGlobalSearch.Name = "btnGlobalSearch";
            this.btnGlobalSearch.Size = new System.Drawing.Size(75, 75);
            this.btnGlobalSearch.TabIndex = 2;
            this.btnGlobalSearch.UseVisualStyleBackColor = true;
            this.btnGlobalSearch.Click += new System.EventHandler(this.btnGlobalSearch_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseChildForm.Image")));
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(75, 75);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // labelTop
            // 
            this.labelTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTop.AutoSize = true;
            this.labelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTop.ForeColor = System.Drawing.Color.White;
            this.labelTop.Location = new System.Drawing.Point(431, 22);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(128, 29);
            this.labelTop.TabIndex = 0;
            this.labelTop.Text = "ГОЛОВНА";
            // 
            // panelOpenChildForm
            // 
            this.panelOpenChildForm.Controls.Add(this.richTextBox1);
            this.panelOpenChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpenChildForm.Location = new System.Drawing.Point(200, 75);
            this.panelOpenChildForm.Name = "panelOpenChildForm";
            this.panelOpenChildForm.Size = new System.Drawing.Size(984, 586);
            this.panelOpenChildForm.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(984, 586);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panelOpenChildForm);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Документація Ruby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelOpenChildForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btnClass;
        private System.Windows.Forms.Button btnExpression;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Panel panelOpenChildForm;
        private System.Windows.Forms.Button btnExample;
        private System.Windows.Forms.Button btnGlobalSearch;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}