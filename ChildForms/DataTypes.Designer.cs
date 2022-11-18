
namespace Ruby_Docs
{
    partial class DataTypes
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
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.panelAdminForms = new System.Windows.Forms.Panel();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSubmitEdit = new System.Windows.Forms.Button();
            this.btnSubmitAdd = new System.Windows.Forms.Button();
            this.labelInputDescription = new System.Windows.Forms.Label();
            this.labelInputName = new System.Windows.Forms.Label();
            this.textBoxInputName = new System.Windows.Forms.TextBox();
            this.textBoxInputDescription = new System.Windows.Forms.TextBox();
            this.panelAdminButtons = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelDataTypeTop = new System.Windows.Forms.Panel();
            this.labelDataTypeTop = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.panelDescriptionTop = new System.Windows.Forms.Panel();
            this.labelDescriptionTop = new System.Windows.Forms.Label();
            this.panelExampleTop = new System.Windows.Forms.Panel();
            this.labelExampleTop = new System.Windows.Forms.Label();
            this.btnNewExample = new System.Windows.Forms.Button();
            this.splitBody = new System.Windows.Forms.SplitContainer();
            this.splitDataTypesAndDescriptions = new System.Windows.Forms.SplitContainer();
            this.listBoxDataTypes = new System.Windows.Forms.ListBox();
            this.splitSearch = new System.Windows.Forms.SplitContainer();
            this.labelSearch = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridExamples = new System.Windows.Forms.DataGridView();
            this.ExampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExampleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExampleResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelAdmin.SuspendLayout();
            this.panelAdminForms.SuspendLayout();
            this.panelAdminButtons.SuspendLayout();
            this.panelDataTypeTop.SuspendLayout();
            this.panelDescriptionTop.SuspendLayout();
            this.panelExampleTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).BeginInit();
            this.splitBody.Panel1.SuspendLayout();
            this.splitBody.Panel2.SuspendLayout();
            this.splitBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDataTypesAndDescriptions)).BeginInit();
            this.splitDataTypesAndDescriptions.Panel1.SuspendLayout();
            this.splitDataTypesAndDescriptions.Panel2.SuspendLayout();
            this.splitDataTypesAndDescriptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSearch)).BeginInit();
            this.splitSearch.Panel1.SuspendLayout();
            this.splitSearch.Panel2.SuspendLayout();
            this.splitSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExamples)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelAdmin.Controls.Add(this.panelAdminForms);
            this.panelAdmin.Controls.Add(this.panelAdminButtons);
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelAdmin.Location = new System.Drawing.Point(784, 0);
            this.panelAdmin.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(300, 561);
            this.panelAdmin.TabIndex = 0;
            // 
            // panelAdminForms
            // 
            this.panelAdminForms.Controls.Add(this.btnCancelEdit);
            this.panelAdminForms.Controls.Add(this.btnSubmitEdit);
            this.panelAdminForms.Controls.Add(this.btnSubmitAdd);
            this.panelAdminForms.Controls.Add(this.labelInputDescription);
            this.panelAdminForms.Controls.Add(this.labelInputName);
            this.panelAdminForms.Controls.Add(this.textBoxInputName);
            this.panelAdminForms.Controls.Add(this.textBoxInputDescription);
            this.panelAdminForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdminForms.Location = new System.Drawing.Point(0, 30);
            this.panelAdminForms.Name = "panelAdminForms";
            this.panelAdminForms.Size = new System.Drawing.Size(300, 531);
            this.panelAdminForms.TabIndex = 7;
            this.panelAdminForms.Visible = false;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.FlatAppearance.BorderSize = 0;
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.Location = new System.Drawing.Point(81, 354);
            this.btnCancelEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(137, 32);
            this.btnCancelEdit.TabIndex = 0;
            this.btnCancelEdit.Text = "Скасувати";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnSubmitEdit
            // 
            this.btnSubmitEdit.FlatAppearance.BorderSize = 0;
            this.btnSubmitEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitEdit.Location = new System.Drawing.Point(81, 314);
            this.btnSubmitEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitEdit.Name = "btnSubmitEdit";
            this.btnSubmitEdit.Size = new System.Drawing.Size(137, 32);
            this.btnSubmitEdit.TabIndex = 0;
            this.btnSubmitEdit.Text = "Підтвердити";
            this.btnSubmitEdit.UseVisualStyleBackColor = true;
            this.btnSubmitEdit.Visible = false;
            this.btnSubmitEdit.Click += new System.EventHandler(this.btnSubmitEdit_Click);
            // 
            // btnSubmitAdd
            // 
            this.btnSubmitAdd.FlatAppearance.BorderSize = 0;
            this.btnSubmitAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitAdd.Location = new System.Drawing.Point(81, 314);
            this.btnSubmitAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSubmitAdd.Name = "btnSubmitAdd";
            this.btnSubmitAdd.Size = new System.Drawing.Size(137, 32);
            this.btnSubmitAdd.TabIndex = 0;
            this.btnSubmitAdd.Text = "Підтвердити";
            this.btnSubmitAdd.UseVisualStyleBackColor = true;
            this.btnSubmitAdd.Visible = false;
            this.btnSubmitAdd.Click += new System.EventHandler(this.btnSubmitAdd_Click);
            // 
            // labelInputDescription
            // 
            this.labelInputDescription.AutoSize = true;
            this.labelInputDescription.Location = new System.Drawing.Point(22, 81);
            this.labelInputDescription.Name = "labelInputDescription";
            this.labelInputDescription.Size = new System.Drawing.Size(57, 24);
            this.labelInputDescription.TabIndex = 5;
            this.labelInputDescription.Text = "Опис";
            // 
            // labelInputName
            // 
            this.labelInputName.AutoSize = true;
            this.labelInputName.Location = new System.Drawing.Point(22, 22);
            this.labelInputName.Name = "labelInputName";
            this.labelInputName.Size = new System.Drawing.Size(76, 24);
            this.labelInputName.TabIndex = 5;
            this.labelInputName.Text = "Назва *";
            // 
            // textBoxInputName
            // 
            this.textBoxInputName.Location = new System.Drawing.Point(26, 49);
            this.textBoxInputName.Name = "textBoxInputName";
            this.textBoxInputName.Size = new System.Drawing.Size(250, 29);
            this.textBoxInputName.TabIndex = 2;
            // 
            // textBoxInputDescription
            // 
            this.textBoxInputDescription.AcceptsTab = true;
            this.textBoxInputDescription.Location = new System.Drawing.Point(26, 108);
            this.textBoxInputDescription.Multiline = true;
            this.textBoxInputDescription.Name = "textBoxInputDescription";
            this.textBoxInputDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInputDescription.Size = new System.Drawing.Size(250, 200);
            this.textBoxInputDescription.TabIndex = 3;
            // 
            // panelAdminButtons
            // 
            this.panelAdminButtons.Controls.Add(this.btnEdit);
            this.panelAdminButtons.Controls.Add(this.btnDelete);
            this.panelAdminButtons.Controls.Add(this.btnAdd);
            this.panelAdminButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAdminButtons.Location = new System.Drawing.Point(0, 0);
            this.panelAdminButtons.Name = "panelAdminButtons";
            this.panelAdminButtons.Size = new System.Drawing.Size(300, 30);
            this.panelAdminButtons.TabIndex = 6;
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEdit.Location = new System.Drawing.Point(100, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Змінити";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.Location = new System.Drawing.Point(200, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panelDataTypeTop
            // 
            this.panelDataTypeTop.Controls.Add(this.labelDataTypeTop);
            this.panelDataTypeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDataTypeTop.Location = new System.Drawing.Point(0, 0);
            this.panelDataTypeTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelDataTypeTop.Name = "panelDataTypeTop";
            this.panelDataTypeTop.Size = new System.Drawing.Size(300, 30);
            this.panelDataTypeTop.TabIndex = 6;
            // 
            // labelDataTypeTop
            // 
            this.labelDataTypeTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDataTypeTop.AutoSize = true;
            this.labelDataTypeTop.Location = new System.Drawing.Point(86, 2);
            this.labelDataTypeTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataTypeTop.Name = "labelDataTypeTop";
            this.labelDataTypeTop.Size = new System.Drawing.Size(116, 24);
            this.labelDataTypeTop.TabIndex = 0;
            this.labelDataTypeTop.Text = "Типи Даних";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 30);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(479, 229);
            this.textBoxDescription.TabIndex = 7;
            // 
            // panelDescriptionTop
            // 
            this.panelDescriptionTop.Controls.Add(this.labelDescriptionTop);
            this.panelDescriptionTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDescriptionTop.Location = new System.Drawing.Point(0, 0);
            this.panelDescriptionTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelDescriptionTop.Name = "panelDescriptionTop";
            this.panelDescriptionTop.Size = new System.Drawing.Size(479, 30);
            this.panelDescriptionTop.TabIndex = 6;
            // 
            // labelDescriptionTop
            // 
            this.labelDescriptionTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDescriptionTop.AutoSize = true;
            this.labelDescriptionTop.Location = new System.Drawing.Point(155, 2);
            this.labelDescriptionTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescriptionTop.Name = "labelDescriptionTop";
            this.labelDescriptionTop.Size = new System.Drawing.Size(166, 24);
            this.labelDescriptionTop.TabIndex = 0;
            this.labelDescriptionTop.Text = "Опис Типу Даних";
            // 
            // panelExampleTop
            // 
            this.panelExampleTop.Controls.Add(this.labelExampleTop);
            this.panelExampleTop.Controls.Add(this.btnNewExample);
            this.panelExampleTop.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelExampleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExampleTop.Location = new System.Drawing.Point(0, 0);
            this.panelExampleTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelExampleTop.Name = "panelExampleTop";
            this.panelExampleTop.Size = new System.Drawing.Size(784, 30);
            this.panelExampleTop.TabIndex = 2;
            // 
            // labelExampleTop
            // 
            this.labelExampleTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelExampleTop.AutoSize = true;
            this.labelExampleTop.Location = new System.Drawing.Point(289, 3);
            this.labelExampleTop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelExampleTop.Name = "labelExampleTop";
            this.labelExampleTop.Size = new System.Drawing.Size(230, 24);
            this.labelExampleTop.TabIndex = 0;
            this.labelExampleTop.Text = "Відобразити приклади ∨";
            this.labelExampleTop.Click += new System.EventHandler(this.labelExampleTop_Click);
            // 
            // btnNewExample
            // 
            this.btnNewExample.AutoSize = true;
            this.btnNewExample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNewExample.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNewExample.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNewExample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewExample.Location = new System.Drawing.Point(630, 0);
            this.btnNewExample.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewExample.Name = "btnNewExample";
            this.btnNewExample.Size = new System.Drawing.Size(154, 30);
            this.btnNewExample.TabIndex = 0;
            this.btnNewExample.Text = "Новий Приклад";
            this.btnNewExample.UseVisualStyleBackColor = true;
            this.btnNewExample.Click += new System.EventHandler(this.btnNewExample_Click);
            // 
            // splitBody
            // 
            this.splitBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBody.IsSplitterFixed = true;
            this.splitBody.Location = new System.Drawing.Point(0, 0);
            this.splitBody.Margin = new System.Windows.Forms.Padding(4);
            this.splitBody.Name = "splitBody";
            this.splitBody.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitBody.Panel1
            // 
            this.splitBody.Panel1.Controls.Add(this.splitDataTypesAndDescriptions);
            // 
            // splitBody.Panel2
            // 
            this.splitBody.Panel2.Controls.Add(this.splitSearch);
            this.splitBody.Panel2.Controls.Add(this.dataGridExamples);
            this.splitBody.Panel2.Controls.Add(this.panelExampleTop);
            this.splitBody.Size = new System.Drawing.Size(784, 561);
            this.splitBody.SplitterDistance = 259;
            this.splitBody.SplitterWidth = 1;
            this.splitBody.TabIndex = 1;
            // 
            // splitDataTypesAndDescriptions
            // 
            this.splitDataTypesAndDescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDataTypesAndDescriptions.IsSplitterFixed = true;
            this.splitDataTypesAndDescriptions.Location = new System.Drawing.Point(0, 0);
            this.splitDataTypesAndDescriptions.Margin = new System.Windows.Forms.Padding(4);
            this.splitDataTypesAndDescriptions.Name = "splitDataTypesAndDescriptions";
            // 
            // splitDataTypesAndDescriptions.Panel1
            // 
            this.splitDataTypesAndDescriptions.Panel1.Controls.Add(this.listBoxDataTypes);
            this.splitDataTypesAndDescriptions.Panel1.Controls.Add(this.panelDataTypeTop);
            // 
            // splitDataTypesAndDescriptions.Panel2
            // 
            this.splitDataTypesAndDescriptions.Panel2.Controls.Add(this.textBoxDescription);
            this.splitDataTypesAndDescriptions.Panel2.Controls.Add(this.panelDescriptionTop);
            this.splitDataTypesAndDescriptions.Size = new System.Drawing.Size(784, 259);
            this.splitDataTypesAndDescriptions.SplitterDistance = 300;
            this.splitDataTypesAndDescriptions.SplitterWidth = 5;
            this.splitDataTypesAndDescriptions.TabIndex = 0;
            // 
            // listBoxDataTypes
            // 
            this.listBoxDataTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxDataTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDataTypes.FormattingEnabled = true;
            this.listBoxDataTypes.IntegralHeight = false;
            this.listBoxDataTypes.ItemHeight = 24;
            this.listBoxDataTypes.Location = new System.Drawing.Point(0, 30);
            this.listBoxDataTypes.Name = "listBoxDataTypes";
            this.listBoxDataTypes.Size = new System.Drawing.Size(300, 229);
            this.listBoxDataTypes.Sorted = true;
            this.listBoxDataTypes.TabIndex = 7;
            this.listBoxDataTypes.SelectedIndexChanged += new System.EventHandler(this.listBoxDataTypes_SelectedIndexChanged);
            // 
            // splitSearch
            // 
            this.splitSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitSearch.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitSearch.IsSplitterFixed = true;
            this.splitSearch.Location = new System.Drawing.Point(0, 271);
            this.splitSearch.Name = "splitSearch";
            // 
            // splitSearch.Panel1
            // 
            this.splitSearch.Panel1.Controls.Add(this.labelSearch);
            // 
            // splitSearch.Panel2
            // 
            this.splitSearch.Panel2.Controls.Add(this.textBoxSearch);
            this.splitSearch.Size = new System.Drawing.Size(784, 30);
            this.splitSearch.SplitterDistance = 100;
            this.splitSearch.SplitterWidth = 1;
            this.splitSearch.TabIndex = 5;
            // 
            // labelSearch
            // 
            this.labelSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSearch.Location = new System.Drawing.Point(0, 0);
            this.labelSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(98, 28);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Text = "Пошук";
            this.labelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(681, 22);
            this.textBoxSearch.TabIndex = 4;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // dataGridExamples
            // 
            this.dataGridExamples.AllowUserToAddRows = false;
            this.dataGridExamples.AllowUserToDeleteRows = false;
            this.dataGridExamples.AllowUserToResizeRows = false;
            this.dataGridExamples.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridExamples.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridExamples.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridExamples.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridExamples.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridExamples.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridExamples.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExampleID,
            this.ExampleCode,
            this.ExampleResult});
            this.dataGridExamples.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridExamples.EnableHeadersVisualStyles = false;
            this.dataGridExamples.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridExamples.Location = new System.Drawing.Point(0, 30);
            this.dataGridExamples.MultiSelect = false;
            this.dataGridExamples.Name = "dataGridExamples";
            this.dataGridExamples.ReadOnly = true;
            this.dataGridExamples.RowHeadersVisible = false;
            this.dataGridExamples.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridExamples.ShowEditingIcon = false;
            this.dataGridExamples.Size = new System.Drawing.Size(784, 271);
            this.dataGridExamples.TabIndex = 3;
            this.dataGridExamples.Visible = false;
            // 
            // ExampleID
            // 
            this.ExampleID.HeaderText = "ID";
            this.ExampleID.Name = "ExampleID";
            this.ExampleID.ReadOnly = true;
            this.ExampleID.Visible = false;
            // 
            // ExampleCode
            // 
            this.ExampleCode.FillWeight = 200F;
            this.ExampleCode.HeaderText = "Код";
            this.ExampleCode.Name = "ExampleCode";
            this.ExampleCode.ReadOnly = true;
            // 
            // ExampleResult
            // 
            this.ExampleResult.HeaderText = "Результат";
            this.ExampleResult.Name = "ExampleResult";
            this.ExampleResult.ReadOnly = true;
            // 
            // DataTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.ControlBox = false;
            this.Controls.Add(this.splitBody);
            this.Controls.Add(this.panelAdmin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "DataTypes";
            this.Text = "Data Types";
            this.Load += new System.EventHandler(this.DataTypes_Load);
            this.panelAdmin.ResumeLayout(false);
            this.panelAdminForms.ResumeLayout(false);
            this.panelAdminForms.PerformLayout();
            this.panelAdminButtons.ResumeLayout(false);
            this.panelDataTypeTop.ResumeLayout(false);
            this.panelDataTypeTop.PerformLayout();
            this.panelDescriptionTop.ResumeLayout(false);
            this.panelDescriptionTop.PerformLayout();
            this.panelExampleTop.ResumeLayout(false);
            this.panelExampleTop.PerformLayout();
            this.splitBody.Panel1.ResumeLayout(false);
            this.splitBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).EndInit();
            this.splitBody.ResumeLayout(false);
            this.splitDataTypesAndDescriptions.Panel1.ResumeLayout(false);
            this.splitDataTypesAndDescriptions.Panel2.ResumeLayout(false);
            this.splitDataTypesAndDescriptions.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDataTypesAndDescriptions)).EndInit();
            this.splitDataTypesAndDescriptions.ResumeLayout(false);
            this.splitSearch.Panel1.ResumeLayout(false);
            this.splitSearch.Panel2.ResumeLayout(false);
            this.splitSearch.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSearch)).EndInit();
            this.splitSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridExamples)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Panel panelDataTypeTop;
        private System.Windows.Forms.Label labelDataTypeTop;
        private System.Windows.Forms.Button btnSubmitAdd;
        private System.Windows.Forms.Panel panelDescriptionTop;
        private System.Windows.Forms.Label labelDescriptionTop;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Panel panelExampleTop;
        private System.Windows.Forms.Label labelExampleTop;
        private System.Windows.Forms.SplitContainer splitBody;
        private System.Windows.Forms.SplitContainer splitDataTypesAndDescriptions;
        private System.Windows.Forms.DataGridView dataGridExamples;
        private System.Windows.Forms.TextBox textBoxInputDescription;
        private System.Windows.Forms.TextBox textBoxInputName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label labelInputDescription;
        private System.Windows.Forms.Label labelInputName;
        private System.Windows.Forms.Panel panelAdminForms;
        private System.Windows.Forms.Panel panelAdminButtons;
        private System.Windows.Forms.Button btnSubmitEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnNewExample;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExampleResult;
        private System.Windows.Forms.ListBox listBoxDataTypes;
        private System.Windows.Forms.SplitContainer splitSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}