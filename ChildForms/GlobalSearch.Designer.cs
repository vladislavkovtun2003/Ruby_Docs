
namespace Ruby_Docs
{
    partial class GlobalSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxExpressions = new System.Windows.Forms.CheckBox();
            this.checkBoxMethods = new System.Windows.Forms.CheckBox();
            this.checkBoxDataTypes = new System.Windows.Forms.CheckBox();
            this.labelSearchTop = new System.Windows.Forms.Label();
            this.panelSearchTop = new System.Windows.Forms.Panel();
            this.splitSearchAndOptions = new System.Windows.Forms.SplitContainer();
            this.labelSearchOptions = new System.Windows.Forms.Label();
            this.checkBoxExamples = new System.Windows.Forms.CheckBox();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSearchTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSearchAndOptions)).BeginInit();
            this.splitSearchAndOptions.Panel1.SuspendLayout();
            this.splitSearchAndOptions.Panel2.SuspendLayout();
            this.splitSearchAndOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSearch.Location = new System.Drawing.Point(83, 72);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(500, 29);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxAll.Location = new System.Drawing.Point(85, 38);
            this.checkBoxAll.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(79, 24);
            this.checkBoxAll.TabIndex = 2;
            this.checkBoxAll.Text = "Всюди";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // checkBoxExpressions
            // 
            this.checkBoxExpressions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxExpressions.AutoSize = true;
            this.checkBoxExpressions.Checked = true;
            this.checkBoxExpressions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExpressions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxExpressions.Location = new System.Drawing.Point(105, 67);
            this.checkBoxExpressions.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxExpressions.Name = "checkBoxExpressions";
            this.checkBoxExpressions.Size = new System.Drawing.Size(83, 24);
            this.checkBoxExpressions.TabIndex = 3;
            this.checkBoxExpressions.Text = "Вирази";
            this.checkBoxExpressions.UseVisualStyleBackColor = true;
            // 
            // checkBoxMethods
            // 
            this.checkBoxMethods.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxMethods.AutoSize = true;
            this.checkBoxMethods.Checked = true;
            this.checkBoxMethods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxMethods.Location = new System.Drawing.Point(105, 96);
            this.checkBoxMethods.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxMethods.Name = "checkBoxMethods";
            this.checkBoxMethods.Size = new System.Drawing.Size(160, 24);
            this.checkBoxMethods.TabIndex = 3;
            this.checkBoxMethods.Text = "Класи та Методи";
            this.checkBoxMethods.UseVisualStyleBackColor = true;
            // 
            // checkBoxDataTypes
            // 
            this.checkBoxDataTypes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxDataTypes.AutoSize = true;
            this.checkBoxDataTypes.Checked = true;
            this.checkBoxDataTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDataTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxDataTypes.Location = new System.Drawing.Point(105, 125);
            this.checkBoxDataTypes.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxDataTypes.Name = "checkBoxDataTypes";
            this.checkBoxDataTypes.Size = new System.Drawing.Size(114, 24);
            this.checkBoxDataTypes.TabIndex = 3;
            this.checkBoxDataTypes.Text = "Типи Даних";
            this.checkBoxDataTypes.UseVisualStyleBackColor = true;
            // 
            // labelSearchTop
            // 
            this.labelSearchTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSearchTop.AutoSize = true;
            this.labelSearchTop.Location = new System.Drawing.Point(250, 42);
            this.labelSearchTop.Name = "labelSearchTop";
            this.labelSearchTop.Size = new System.Drawing.Size(170, 24);
            this.labelSearchTop.TabIndex = 4;
            this.labelSearchTop.Text = "Пошуковий Запит";
            // 
            // panelSearchTop
            // 
            this.panelSearchTop.BackColor = System.Drawing.SystemColors.Window;
            this.panelSearchTop.Controls.Add(this.splitSearchAndOptions);
            this.panelSearchTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchTop.Location = new System.Drawing.Point(0, 0);
            this.panelSearchTop.Name = "panelSearchTop";
            this.panelSearchTop.Size = new System.Drawing.Size(984, 190);
            this.panelSearchTop.TabIndex = 5;
            // 
            // splitSearchAndOptions
            // 
            this.splitSearchAndOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSearchAndOptions.IsSplitterFixed = true;
            this.splitSearchAndOptions.Location = new System.Drawing.Point(0, 0);
            this.splitSearchAndOptions.Name = "splitSearchAndOptions";
            // 
            // splitSearchAndOptions.Panel1
            // 
            this.splitSearchAndOptions.Panel1.Controls.Add(this.textBoxSearch);
            this.splitSearchAndOptions.Panel1.Controls.Add(this.labelSearchTop);
            // 
            // splitSearchAndOptions.Panel2
            // 
            this.splitSearchAndOptions.Panel2.Controls.Add(this.labelSearchOptions);
            this.splitSearchAndOptions.Panel2.Controls.Add(this.checkBoxAll);
            this.splitSearchAndOptions.Panel2.Controls.Add(this.checkBoxExamples);
            this.splitSearchAndOptions.Panel2.Controls.Add(this.checkBoxDataTypes);
            this.splitSearchAndOptions.Panel2.Controls.Add(this.checkBoxExpressions);
            this.splitSearchAndOptions.Panel2.Controls.Add(this.checkBoxMethods);
            this.splitSearchAndOptions.Size = new System.Drawing.Size(984, 190);
            this.splitSearchAndOptions.SplitterDistance = 650;
            this.splitSearchAndOptions.SplitterWidth = 5;
            this.splitSearchAndOptions.TabIndex = 5;
            // 
            // labelSearchOptions
            // 
            this.labelSearchOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSearchOptions.AutoSize = true;
            this.labelSearchOptions.Location = new System.Drawing.Point(81, 9);
            this.labelSearchOptions.Name = "labelSearchOptions";
            this.labelSearchOptions.Size = new System.Drawing.Size(189, 24);
            this.labelSearchOptions.TabIndex = 4;
            this.labelSearchOptions.Text = "Параметри фільтру:";
            // 
            // checkBoxExamples
            // 
            this.checkBoxExamples.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxExamples.AutoSize = true;
            this.checkBoxExamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxExamples.Location = new System.Drawing.Point(105, 154);
            this.checkBoxExamples.Margin = new System.Windows.Forms.Padding(6);
            this.checkBoxExamples.Name = "checkBoxExamples";
            this.checkBoxExamples.Size = new System.Drawing.Size(105, 24);
            this.checkBoxExamples.TabIndex = 3;
            this.checkBoxExamples.Text = "Приклади";
            this.checkBoxExamples.UseVisualStyleBackColor = true;
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            this.dataGridResults.AllowUserToResizeRows = false;
            this.dataGridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Item,
            this.ItemType,
            this.Description});
            this.dataGridResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridResults.EnableHeadersVisualStyles = false;
            this.dataGridResults.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridResults.Location = new System.Drawing.Point(0, 190);
            this.dataGridResults.MultiSelect = false;
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridResults.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridResults.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridResults.ShowEditingIcon = false;
            this.dataGridResults.Size = new System.Drawing.Size(984, 371);
            this.dataGridResults.TabIndex = 6;
            this.dataGridResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellDoubleClick);
            // 
            // Key
            // 
            this.Key.HeaderText = "Ключ";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            this.Key.Visible = false;
            // 
            // Item
            // 
            this.Item.FillWeight = 140F;
            this.Item.HeaderText = "Результат";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // ItemType
            // 
            this.ItemType.FillWeight = 80F;
            this.ItemType.HeaderText = "Тип";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 180F;
            this.Description.HeaderText = "Опис";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // GlobalSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.panelSearchTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GlobalSearch";
            this.Text = "Global Search";
            this.Load += new System.EventHandler(this.GlobalSearch_Load);
            this.panelSearchTop.ResumeLayout(false);
            this.splitSearchAndOptions.Panel1.ResumeLayout(false);
            this.splitSearchAndOptions.Panel1.PerformLayout();
            this.splitSearchAndOptions.Panel2.ResumeLayout(false);
            this.splitSearchAndOptions.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSearchAndOptions)).EndInit();
            this.splitSearchAndOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.CheckBox checkBoxExpressions;
        private System.Windows.Forms.CheckBox checkBoxMethods;
        private System.Windows.Forms.CheckBox checkBoxDataTypes;
        private System.Windows.Forms.Label labelSearchTop;
        private System.Windows.Forms.Panel panelSearchTop;
        private System.Windows.Forms.Label labelSearchOptions;
        private System.Windows.Forms.SplitContainer splitSearchAndOptions;
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.CheckBox checkBoxExamples;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}