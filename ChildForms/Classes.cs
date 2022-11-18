using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Docs
{
    public partial class Classes : Form
    {

        #region Classes Fields

        private static SqlConnection conn = null;
        private static bool isAdmin;
        private static string selectItem = string.Empty;
        private static string tempClassName = string.Empty;
        private static string tempMethodName = string.Empty;

        #endregion

        #region Classes Form

        public Classes(bool isAdmin, SqlConnection connection) //Form Constructor
        {
            InitializeComponent();
            Classes.isAdmin = isAdmin;
            Classes.conn = connection;
        }

        public Classes(bool isAdmin, SqlConnection connection, string selection) //Form Constructor
        {
            InitializeComponent();
            Classes.isAdmin = isAdmin;
            Classes.conn = connection;
            Classes.selectItem = selection;
        }

        private void Classes_Load(object sender, EventArgs e) //Form On Load
        {
            panelAdmin.Visible = isAdmin;
            btnNewExample.Visible = isAdmin;
            DataLoad();
            SetTheme();
            if (selectItem.Trim() != string.Empty)
            {
                string[] selectArr = selectItem.Split(' ');
                //If Need To Select Class
                if (selectArr.Length == 1)
                {
                    //For Each Class
                    foreach (TreeNode node in treeClass.Nodes)
                    {
                        if (node.Text == selectArr[0])
                        {
                            node.Expand();
                            treeClass.SelectedNode = node;
                        }
                    }
                }
                //If Need To Select Method
                if (selectArr.Length == 2)
                {
                    //For Each Class
                    foreach (TreeNode node in treeClass.Nodes)
                    {
                        //For Each Method In Class Node
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            if (childNode.Text == selectArr[0] && childNode.Parent.Text == selectArr[1])
                            {

                                treeClass.SelectedNode = childNode;
                            }
                        }
                    }
                }
                ActiveControl = treeClass;
            }
            selectItem = string.Empty;
        }

        private void DataLoad() //Reset And Fill Data
        {
            //Clear Class Tree
            treeClass.Nodes.Clear();
            //Clear Lists
            comboBoxClassSelect.Items.Clear();
            comboBoxDataTypeSelect.Items.Clear();
            //Clear Text Boxes
            textBoxDescription.Clear();
            dataGridExamples.Rows.Clear();
            labelDataType.Text = string.Empty;

            //Fill Class Tree
            conn.Open();
            //Get Class Names
            string query = "SELECT class_name " +
                           "FROM Classes";
            SqlDataReader readerClass = SelectQuery(query, conn);
            while (readerClass.Read())
            {
                //Add Class Node
                treeClass.Nodes.Add($"{readerClass["class_name"]}");
                //Fill Class List
                comboBoxClassSelect.Items.Add($"{readerClass["class_name"]}");
            }
            if (readerClass != null) { readerClass.Close(); }
            //Get Data Type
            query = "SELECT data_type " +
                    "FROM DataTypes";
            SqlDataReader readerDataType = SelectQuery(query, conn);
            while (readerDataType.Read())
            {
                //Fill Data Type List
                comboBoxDataTypeSelect.Items.Add($"{readerDataType["data_type"]}");
            }
            if (readerDataType != null) { readerDataType.Close(); }
            //Add Methods To Each Class
            foreach (TreeNode node in treeClass.Nodes)
            {
                //Get Method Names
                query = $"SELECT method_name " +
                        $"FROM Methods WHERE Methods.class_name = '{node.Text}'";
                SqlDataReader readerMethod = SelectQuery(query, conn);
                while (readerMethod.Read())
                {
                    //Fill Methods For Class Node
                    node.Nodes.Add(new TreeNode($"{readerMethod["method_name"]}"));
                }
                if (readerMethod != null) { readerMethod.Close(); }
            }
            conn.Close();
        }

        private void SetTheme() //Child Theme
        {
            //Body Back Color
            splitBody.BackColor = ThemeColor.DarkerColor;
            splitBody.Panel2.BackColor = Color.White;
            //Headers Back Color
            panelExampleTop.BackColor = ThemeColor.DarkerColor;
            dataGridExamples.GridColor = ThemeColor.DarkerColor;
            //Headers Text Color
            panelClassTop.ForeColor = Color.Gainsboro;
            panelDescriptionTop.ForeColor = Color.Gainsboro;
            panelExampleTop.ForeColor = Color.Gainsboro;
            //Admin Panel Theme
            panelAdmin.BackColor = ThemeColor.LighterColor;
            //Top Buttons
            btnAdd.FlatAppearance.BorderColor = ThemeColor.DarkerColor;
            btnEdit.FlatAppearance.BorderColor = ThemeColor.DarkerColor;
            btnDelete.FlatAppearance.BorderColor = ThemeColor.DarkerColor;
            //Bottom Buttons
            btnSubmitAdd.BackColor = ThemeColor.DarkerColor;
            btnSubmitAdd.ForeColor = Color.Gainsboro;
            btnSubmitEdit.BackColor = ThemeColor.DarkerColor;
            btnSubmitEdit.ForeColor = Color.Gainsboro;
            btnCancelEdit.BackColor = ThemeColor.DarkerColor;
            btnCancelEdit.ForeColor = Color.Gainsboro;
            btnNewExample.BackColor = ThemeColor.LighterColor;
            btnNewExample.ForeColor = Color.Black;
            btnNewExample.FlatAppearance.BorderColor = ThemeColor.DarkerColor;
            //Table Theme
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            this.dataGridExamples.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = ThemeColor.LighterColor;
        }

        private void treeClass_AfterSelect(object sender, TreeViewEventArgs e) //Tree Item Select
        {
            //Text Boxes Prepare
            textBoxDescription.Clear();
            dataGridExamples.Rows.Clear();
            labelDataType.Text = string.Empty;

            conn.Open();
            //If Selected Class
            if (e.Node.Parent == null)
            {
                //Change Label
                labelDescriptionTop.Text = "Опис Класу";
                //Get Class Description
                string query = $"SELECT class_description " +
                               $"FROM Classes WHERE class_name = '{e.Node.Text}'";
                SqlDataReader readerDesc = SelectQuery(query, conn);
                //Fill Description
                readerDesc.Read();
                textBoxDescription.Text = $"{readerDesc["class_description"]}";
                if (readerDesc != null) { readerDesc.Close(); }
            }
            //If Selected Method
            else if (e.Node.Parent != null)
            {
                //Change Label
                labelDescriptionTop.Text = "Опис Методу";
                //Get Method Description
                string query = $"SELECT method_description, data_type " +
                               $"FROM Methods " +
                               $"WHERE method_name = '{e.Node.Text}' AND class_name = '{e.Node.Parent.Text}'";
                SqlDataReader readerDescAndType = SelectQuery(query, conn);
                readerDescAndType.Read();
                textBoxDescription.Text = $"{readerDescAndType["method_description"]}";
                labelDataType.Text = $"{readerDescAndType["data_type"]}";
                if (readerDescAndType != null) { readerDescAndType.Close(); }
                //Get Examples By Method
                query = $"SELECT EM.example_id, E.example, E.example_result " +
                        $"FROM Examples2Methods EM " +
                        $"JOIN Examples E ON EM.example_id = E.example_id " +
                        $"WHERE EM.method_id = (SELECT method_id FROM Methods WHERE method_name = '{e.Node.Text}' AND class_name = '{e.Node.Parent.Text}')";
                SqlDataReader readerExample = SelectQuery(query, conn);
                //Fill Example Table
                while (readerExample.Read())
                {
                    if (readerExample.HasRows == true)
                    {
                        dataGridExamples.Rows.Add($"{readerExample["example_id"]}",
                                                       $"{readerExample["example"]}",
                                                       $"{readerExample["example_result"]}");
                    }
                }
                if (readerExample != null) { readerExample.Close(); }
                dataGridExamples.ClearSelection();
            }
            conn.Close();
        }

        private void labelExampleTop_Click(object sender, EventArgs e) //Show Or Hide Examples
        {
            if (dataGridExamples.Visible)
            {
                labelExampleTop.Text = "Відобразити приклади ∨";
                dataGridExamples.Visible = false;
                dataGridExamples.ClearSelection();
            }
            else
            {
                labelExampleTop.Text = "Приховати приклади ∧";
                dataGridExamples.Visible = true;
                dataGridExamples.ClearSelection();
            }

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e) //Search
        {
            if (textBoxSearch.Text.Trim() != string.Empty)
            {
                treeClass.Nodes.Clear();
                conn.Open();
                //Search By Methods
                string query = $"SELECT method_name, class_name " +
                               $"FROM Methods " +
                               $"WHERE method_name LIKE '{textBoxSearch.Text.Trim()}%'";
                SqlDataReader readerSearch = SelectQuery(query, conn);
                while (readerSearch.Read())
                {

                    if (!treeClass.Nodes.Contains(new TreeNode(readerSearch["class_name"].ToString())))
                    {
                        //Add Class Node
                        treeClass.Nodes.Add($"{readerSearch["class_name"]}");
                    }
                    //Add Methods To Each Class
                    foreach (TreeNode node in treeClass.Nodes)
                    {
                        if (readerSearch["class_name"].ToString() == node.Text)
                        {
                            //Fill Methods For Class Node
                            node.Nodes.Add(new TreeNode($"{readerSearch["method_name"]}"));
                            node.Expand();
                        }
                    }
                }
                if (readerSearch != null) { readerSearch.Close(); }
                conn.Close();
            }
            else
            {
                treeClass.Nodes.Clear();
                conn.Open();
                //Get Class Names
                string query = "SELECT class_name " +
                               "FROM Classes";
                SqlDataReader readerClass = SelectQuery(query, conn);
                while (readerClass.Read())
                {
                    //Add Class Node
                    treeClass.Nodes.Add($"{readerClass["class_name"]}");
                }
                if (readerClass != null) { readerClass.Close(); }
                //Add Methods To Each Class
                foreach (TreeNode node in treeClass.Nodes)
                {
                    //Get Method Names
                    query = $"SELECT method_name " +
                            $"FROM Methods WHERE Methods.class_name = '{node.Text}'";
                    SqlDataReader readerMethod = SelectQuery(query, conn);
                    while (readerMethod.Read())
                    {
                        //Fill Methods For Class Node
                        node.Nodes.Add(new TreeNode($"{readerMethod["method_name"]}"));
                    }
                    if (readerMethod != null) { readerMethod.Close(); }
                }
                conn.Close();
            }
        }

        #endregion

        #region Sql Queries

        private SqlDataReader SelectQuery(string query, SqlConnection connection) //Sql Select Query (Return Data Reader)
        {
            SqlCommand sqlReturn = new SqlCommand(query, connection);
            SqlDataReader reader = sqlReturn.ExecuteReader();
            return reader;
        }

        private void DeleteQuery(string query, SqlConnection connection) //Sql Delete Query
        {
            conn.Open();
            SqlCommand sqlDelete = new SqlCommand(query, connection);
            sqlDelete.ExecuteNonQuery();
            conn.Close();
        }

        #endregion

        #region Admin Panel

        private void panelAdmin_Clear() //Clear Admin Forms
        {
            //Clear Lists Select
            comboBoxClassOrMethod.SelectedItem = null;
            comboBoxClassSelect.SelectedItem = null;
            comboBoxDataTypeSelect.SelectedItem = null;
            btnDataTypeCancel.Visible = false;
            //Clear Input Forms
            textBoxInputName.Clear();
            textBoxInputDescription.Clear();
        }

        private void comboBoxClassOrMethod_SelectedIndexChanged(object sender, EventArgs e) //When Class Or Method Select
        {
            //if Class Selected
            if (comboBoxClassOrMethod.Text == "Клас")
            {
                comboBoxClassSelect.SelectedItem = null;
                comboBoxDataTypeSelect.SelectedItem = null;

                comboBoxClassSelect.Enabled = false;
                textBoxInputName.Enabled = true;
                comboBoxDataTypeSelect.Enabled = false;
                btnDataTypeCancel.Visible = false;
                textBoxInputDescription.Enabled = true;
                btnSubmitAdd.Enabled = true;
            }
            //if Method Selected
            if (comboBoxClassOrMethod.Text == "Метод")
            {
                //If Any Class Exists
                if (comboBoxClassSelect.Items.Count > 0)
                {
                    comboBoxClassSelect.Enabled = true;
                    textBoxInputName.Enabled = true;
                    comboBoxDataTypeSelect.Enabled = true;
                    textBoxInputDescription.Enabled = true;
                    btnSubmitAdd.Enabled = true;
                }
                //If Class Not Exists
                else
                {
                    comboBoxClassSelect.Enabled = false;
                    textBoxInputName.Enabled = false;
                    comboBoxDataTypeSelect.Enabled = false;
                    textBoxInputDescription.Enabled = false;
                    btnSubmitAdd.Enabled = false;
                }
            }
        }

        private void comboBoxDataTypeSelect_SelectedIndexChanged(object sender, EventArgs e) //When Select Data Type
        {
            btnDataTypeCancel.Visible = true;
        }

        #region Top Buttons

        private void btnAdd_Click(object sender, EventArgs e) //Click Button "Додати"
        {
            panelAdmin_Clear();
            //Admin Panel Prepare To Add
            panelAdminForms.Visible = true;
            //Show New Elem Field
            labelClassOrMethod.Visible = true;
            comboBoxClassOrMethod.Visible = true;
            //Disable Class And Type Select
            comboBoxClassSelect.Enabled = false;
            comboBoxDataTypeSelect.Enabled = false;
            //swap buttons
            btnSubmitAdd.Visible = true;
            btnSubmitEdit.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e) //Click Button "Змінити"
        {
            panelAdmin_Clear();
            //Admin Panel Prepare To Edit
            panelAdminForms.Visible = true;
            //Hide New Elem Field
            labelClassOrMethod.Visible = false;
            comboBoxClassOrMethod.Visible = false;
            //Hide Add Submit Button
            btnSubmitAdd.Visible = false;

            try
            {
                //If Selected Class
                if (treeClass.SelectedNode.Parent == null)
                {
                    //Disable Class And Type Select
                    comboBoxClassSelect.Enabled = false;
                    comboBoxDataTypeSelect.Enabled = false;
                    //Get Name And Desc To Forms
                    textBoxInputName.Text = treeClass.SelectedNode.Text;
                    textBoxInputDescription.Text = textBoxDescription.Text;
                    //Saves Name Of Updating Elem
                    tempClassName = treeClass.SelectedNode.Text;
                }
                //If Selected Method
                else if (treeClass.SelectedNode.Parent != null)
                {
                    //Enable Class And Type Select
                    comboBoxClassSelect.Enabled = true;
                    comboBoxDataTypeSelect.Enabled = true;
                    //Get Class, Name, Type And Desc To Forms
                    comboBoxClassSelect.SelectedItem = treeClass.SelectedNode.Parent.Text;
                    textBoxInputName.Text = treeClass.SelectedNode.Text;
                    comboBoxDataTypeSelect.SelectedItem = labelDataType.Text;
                    textBoxInputDescription.Text = textBoxDescription.Text;
                    //Saves Name Of Updated Elem
                    tempClassName = treeClass.SelectedNode.Parent.Text;
                    tempMethodName = treeClass.SelectedNode.Text;
                }
                //Show Edit Submit Button
                btnSubmitEdit.Visible = true;
            }
            catch (Exception)
            {
                panelAdminForms.Visible = false;
                MessageBox.Show("Оберіть елемент для редагування!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) //Click Button "Видалити"
        {
            try
            {
                //Delete Confirm
                DialogResult dialogResult = MessageBox.Show("Дійсно видалити обраний елемент?", "Підтвердження видалення", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    //If Selected Class
                    if (treeClass.SelectedNode.Parent == null)
                    {
                        //Delete Class By Name
                        string query = $"DELETE FROM Classes " +
                                       $"WHERE class_name = '{treeClass.SelectedNode.Text}'";
                        DeleteQuery(query, conn);
                        DataLoad();
                    }
                    //If Selected Method
                    else if (treeClass.SelectedNode.Parent != null)
                    {
                        //Delete Method By Name
                        string query = $"DELETE FROM Methods " +
                                       $"WHERE method_name = '{treeClass.SelectedNode.Text}' " +
                                       $"AND class_name = '{treeClass.SelectedNode.Parent.Text}'";
                        DeleteQuery(query, conn);
                        DataLoad();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть елемент для видалення!");
            }
        }

        #endregion

        #region Bottom Buttons

        private void btnSubmitAdd_Click(object sender, EventArgs e) //Click Button "Підтвердити" After "Додати"
        {
            try
            {
                //If Add Class
                if (comboBoxClassOrMethod.Text == "Клас")
                {
                    //If Required Fields Empty
                    if (textBoxInputName.Text.Trim() == string.Empty)
                    {
                        throw new DataException();
                    }
                    //Check Duplicate Names
                    foreach (TreeNode Node in treeClass.Nodes)
                    {
                        if (Node.Text == textBoxInputName.Text.Trim())
                        {
                            throw new DuplicateNameException();
                        }
                    }
                    conn.Open();
                    //Add new Class
                    string query = @"INSERT INTO Classes (class_name, class_description) " +
                                   @"VALUES (@Name, @Desc);";
                    SqlCommand sqlInsert = new SqlCommand(query, conn);
                    //Input Parameters
                    SqlParameter Name = new SqlParameter("@Name", textBoxInputName.Text.Trim());
                    SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                    //Add Parameters
                    sqlInsert.Parameters.Add(Name);
                    sqlInsert.Parameters.Add(Desc);
                    ////If Fields Empty
                    if (textBoxInputDescription.Text.Trim() == string.Empty) { Desc.Value = DBNull.Value; }
                    sqlInsert.ExecuteNonQuery();
                    conn.Close();
                    //Form Reload
                    DataLoad();
                }
                //If Add Method
                else if (comboBoxClassOrMethod.Text == "Метод")
                {
                    //If Required Fields Empty
                    if (comboBoxClassOrMethod.SelectedItem == null || comboBoxClassSelect.SelectedItem == null || textBoxInputName.Text.Trim() == string.Empty)
                    {
                        throw new DataException();
                    }
                    //Check Duplicate Names
                    foreach (TreeNode Node in treeClass.Nodes[comboBoxClassSelect.SelectedIndex].Nodes)
                    {
                        if (Node.Text == textBoxInputName.Text)
                        {
                            throw new DuplicateNameException();
                        }
                    }
                    conn.Open();
                    //Add new Method
                    string query = @"INSERT INTO Methods (method_name, method_description, data_type, class_name) " +
                                   @"VALUES (@Name, @Desc, @Type, @Class);";
                    SqlCommand sqlInsert = new SqlCommand(query, conn);
                    //Input Parameters
                    SqlParameter Name = new SqlParameter("@Name", textBoxInputName.Text.Trim());
                    SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                    SqlParameter Type = new SqlParameter("@Type", comboBoxDataTypeSelect.Text.Trim());
                    SqlParameter Class = new SqlParameter("@Class", comboBoxClassSelect.Text.Trim());
                    //Add Parameters
                    sqlInsert.Parameters.Add(Name);
                    sqlInsert.Parameters.Add(Desc);
                    sqlInsert.Parameters.Add(Type);
                    sqlInsert.Parameters.Add(Class);
                    //If Fields Empty
                    if (textBoxInputDescription.Text.Trim() == string.Empty) { Desc.Value = DBNull.Value; }
                    if (comboBoxDataTypeSelect.Text.Trim() == string.Empty) { Type.Value = DBNull.Value; }
                    sqlInsert.ExecuteNonQuery();
                    conn.Close();
                    //Form Reload
                    DataLoad();
                }
                //Reset Admin Form
                panelAdmin_Clear();
                panelAdminForms.Visible = false;
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("Метод з таким іменем уже додано!");
            }
            catch (DataException)
            {
                MessageBox.Show("Одне або декілька обов'язкових полів не заповнено!");
            }
        }

        private void btnSubmitEdit_Click(object sender, EventArgs e) //Click Button "Підтвердити" After "Змінити"
        {
            try
            {
                //If Edit Class
                if (treeClass.SelectedNode.Parent == null)
                {
                    //If Required Fields Empty
                    if (textBoxInputName.Text.Trim() == string.Empty)
                    {
                        throw new DataException();
                    }
                    conn.Open();
                    //Submit Edit Class
                    string query = @"UPDATE Classes SET class_name = @Name, class_description = @Desc " +
                                   @"WHERE class_name = @OldName;";
                    SqlCommand sqlInsert = new SqlCommand(query, conn);
                    //Input Parameters
                    SqlParameter OldName = new SqlParameter("@OldName", tempClassName);
                    SqlParameter Name = new SqlParameter("@Name", textBoxInputName.Text.Trim());
                    SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                    //Add Parameters
                    sqlInsert.Parameters.Add(OldName);
                    sqlInsert.Parameters.Add(Name);
                    sqlInsert.Parameters.Add(Desc);
                    //If Fields Empty
                    if (textBoxInputDescription.Text == string.Empty) { Desc.Value = DBNull.Value; }
                    sqlInsert.ExecuteNonQuery();
                    conn.Close();
                    //Form Reload
                    DataLoad();
                }
                //If Edit Method
                else if (treeClass.SelectedNode.Parent != null)
                {
                    //If Required Fields Empty
                    if (comboBoxClassSelect.SelectedItem == null || textBoxInputName.Text.Trim() == string.Empty)
                    {
                        throw new DataException();
                    }
                    if (tempClassName != comboBoxClassSelect.Text)
                    {
                        //Check Duplicate Names
                        foreach (TreeNode Node in treeClass.Nodes[comboBoxClassSelect.SelectedIndex].Nodes)
                        {
                            if (Node.Text == textBoxInputName.Text)
                            {
                                throw new DuplicateNameException();
                            }
                        }
                    }
                    conn.Open();
                    //Submit Edit Method
                    string query = @"UPDATE Methods SET method_name = @Name, method_description = @Desc, data_type = @Type, class_name = @Class " +
                                   @"WHERE method_name = @OldName AND class_name = @OldClassName;";
                    SqlCommand sqlInsert = new SqlCommand(query, conn);
                    //Input Parameters
                    SqlParameter OldClassName = new SqlParameter("@OldClassName", tempClassName);
                    SqlParameter OldName = new SqlParameter("@OldName", tempMethodName);
                    SqlParameter Name = new SqlParameter("@Name", textBoxInputName.Text.Trim());
                    SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                    SqlParameter Type = new SqlParameter("@Type", comboBoxDataTypeSelect.Text.Trim());
                    SqlParameter Class = new SqlParameter("@Class", comboBoxClassSelect.Text.Trim());
                    //Add Parameters
                    sqlInsert.Parameters.Add(OldClassName);
                    sqlInsert.Parameters.Add(OldName);
                    sqlInsert.Parameters.Add(Name);
                    sqlInsert.Parameters.Add(Desc);
                    sqlInsert.Parameters.Add(Type);
                    sqlInsert.Parameters.Add(Class);
                    //If Fields Empty
                    if (textBoxInputDescription.Text.Trim() == string.Empty) { Desc.Value = DBNull.Value; }
                    if (comboBoxDataTypeSelect.Text.Trim() == string.Empty) { Type.Value = DBNull.Value; }
                    sqlInsert.ExecuteNonQuery();
                    conn.Close();
                    //Form Reload
                    DataLoad();
                }
                //Reset Node Select And Admin Form
                treeClass.SelectedNode = null;
                panelAdmin_Clear();
                panelAdminForms.Visible = false;
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("Метод з таким іменем уже додано!");
            }
            catch (DataException)
            {
                MessageBox.Show("Одне або декілька обов'язкових полів не заповнено!");
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e) //Click Button "Скасувати" After "Змінити"
        {
            //Reset Node Select And Admin Form
            treeClass.SelectedNode = null;
            panelAdmin_Clear();
            panelAdminForms.Visible = false;
        }

        private void btnNewExample_Click(object sender, EventArgs e) //Click Button "Новий Приклад"
        {
            if (MainForm.selfRef != null)
            {
                MainForm.selfRef.OpenExamplesFromChild();
            }
        }

        private void btnDataTypeCancel_Click(object sender, EventArgs e) //Clear Data Type
        {
            comboBoxDataTypeSelect.SelectedItem = null;
            btnDataTypeCancel.Visible = false;
        }

        #endregion

        #endregion

    }
}