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
    public partial class Examples : Form
    {

        #region Examples Fields

        private static SqlConnection conn = null;
        private static bool isAdmin;
        private static string selectItem = string.Empty;
        private static string tempExampleId = string.Empty;

        #endregion

        #region Examples Form

        public Examples(bool isAdmin, SqlConnection connection) //Form Constructor
        {
            InitializeComponent();
            Examples.isAdmin = isAdmin;
            Examples.conn = connection;
        }

        public Examples(bool isAdmin, SqlConnection connection, string selection) //Form Constructor
        {
            InitializeComponent();
            Examples.isAdmin = isAdmin;
            Examples.conn = connection;
            Examples.selectItem = selection;
        }

        private void Examples_Load(object sender, EventArgs e) //Form On Load
        {
            panelAdmin.Visible = isAdmin;
            DataLoad();
            SetTheme();
            splitBody.SplitterDistance = 0;
            if (selectItem.Trim() != string.Empty)
            {
                foreach (DataGridViewRow row in dataGridExamples.Rows)
                {
                    if (row.Cells[0].Value.ToString() == selectItem.Trim())
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            selectItem = string.Empty;
        }

        private void DataLoad() //Reset And Fill Data
        {
            //Clear Admin Panel
            panelAdmin_Clear();
            //Clear Lists And Table
            checkListBoxExpressions.Items.Clear();
            treeClass.Nodes.Clear();
            checkListBoxDataTypes.Items.Clear();
            dataGridExamples.Rows.Clear();
            //Fill Example Table
            conn.Open();
            //Get Examples
            string query = $"SELECT example_id, example, example_result " +
                           $"FROM Examples ";
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
        //Fill Expressions List
            query = "SELECT expression_name " +
               "FROM Expressions";
            SqlDataReader readerExpression = SelectQuery(query, conn);
            while (readerExpression.Read())
            {
                //Fill Expressions List
                checkListBoxExpressions.Items.Add($"{readerExpression["expression_name"]}");
            }
            if (readerExpression != null) { readerExpression.Close(); }
        //Fill Methods List
            query = "SELECT class_name " +
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
        //Fill Data Types List
            query = "SELECT data_type " +
                    "FROM DataTypes";
            SqlDataReader readerDataType = SelectQuery(query, conn);
            while (readerDataType.Read())
            {
                //Fill Data Type List
                checkListBoxDataTypes.Items.Add($"{readerDataType["data_type"]}");
            }
            if (readerDataType != null) { readerDataType.Close(); }
            conn.Close();
        }

        private void SetTheme() //Child Theme
        {
            //Body Color
            splitBody.BackColor = ThemeColor.DarkerColor;
            splitBody.Panel2.BackColor = Color.White;
            //Headers Back Color
            panelExampleTop.BackColor = ThemeColor.DarkerColor;
            dataGridExamples.GridColor = ThemeColor.DarkerColor;
            //Headers Text Color
            panelExpressionsTop.ForeColor = Color.Gainsboro;
            panelClassesTop.ForeColor = Color.Gainsboro;
            panelDataTypesTop.ForeColor = Color.Gainsboro;
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
            //Table Theme
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            this.dataGridExamples.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = ThemeColor.LighterColor;
        }

        private void treeClass_AfterCheck(object sender, TreeViewEventArgs e) //Checkbox Auto Select Childs
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                childNode.Checked = e.Node.Checked;
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
            //Clear Input Forms
            textBoxInputExample.Clear();
            textBoxInputResult.Clear();
        }

        #region Top Buttons

        private void btnAdd_Click(object sender, EventArgs e) //Click Button "Додати"
        {
            panelAdmin_Clear();
            //Admin Panel Prepare To Add
            splitBody.SplitterDistance = 300;
            panelAdminForms.Visible = true;
            //swap buttons
            btnSubmitAdd.Visible = true;
            btnSubmitEdit.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e) //Click Button "Змінити"
        {
            //Cleal All Checks
            foreach (int item in checkListBoxExpressions.CheckedIndices)
            {
                checkListBoxExpressions.SetItemChecked(item, false);
            }
            foreach (TreeNode node in treeClass.Nodes)
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                }
            }
            foreach (int item in checkListBoxDataTypes.CheckedIndices)
            {
                checkListBoxDataTypes.SetItemChecked(item, false);
            }
            //Admin Panel Reset
            panelAdmin_Clear();
            //Admin Panel Prepare To Edit
            panelAdminForms.Visible = true;
            //Hide Add Submit Button
            btnSubmitAdd.Visible = false;

            try
            {
                //Get Row Index By Selected Cell
                int selectedRowIndex = dataGridExamples.SelectedCells[0].RowIndex;
                //Get Row By Index
                DataGridViewRow selectedRow = dataGridExamples.Rows[selectedRowIndex];
                //Get Example Id From Selected Row
                tempExampleId = selectedRow.Cells["ExampleId"].Value.ToString();
                //Get Example Code And Result
                textBoxInputExample.Text = selectedRow.Cells["ExampleCode"].Value.ToString();
                textBoxInputResult.Text = selectedRow.Cells["ExampleResult"].Value.ToString();
                //Show Bindings
                splitBody.SplitterDistance = 300;
            //Get All Bindings
                conn.Open();
                //Get Expression Bindings
                string query = $"SELECT example_id, expression_name " +
                               $"FROM Examples2Expressions " +
                               $"WHERE example_id = {tempExampleId};";
                SqlDataReader readerBindings = SelectQuery(query, conn);
                //Fill Expression Bindings
                while (readerBindings.Read())
                {
                    checkListBoxExpressions.SetItemChecked(checkListBoxExpressions.Items.IndexOf(readerBindings["expression_name"].ToString()), true);
                }
                if (readerBindings != null) { readerBindings.Close(); }
                //Get Method Bindings
                query = $"SELECT EM.example_id, M.method_name, M.class_name " +
                        $"FROM Examples2Methods EM, Methods M " +
                        $"WHERE M.method_id = EM.method_id AND EM.example_id = {tempExampleId};";
                readerBindings = SelectQuery(query, conn);
                //Fill Data Type Bindings
                while (readerBindings.Read())
                {
                    foreach (TreeNode node in treeClass.Nodes)
                    {
                        if (readerBindings["class_name"].ToString() == node.Text)
                        {
                            foreach (TreeNode childNode in node.Nodes)
                            {
                                node.Expand();
                                if (readerBindings["method_name"].ToString() == childNode.Text)
                                {
                                    childNode.Checked = true;
                                }
                            }
                        }
                    }
                }
                if (readerBindings != null) { readerBindings.Close(); }
                //Get Expression Bindings
                query = $"SELECT example_id, data_type " +
                        $"FROM Examples2DataTypes " +
                        $"WHERE example_id = {tempExampleId};";
                readerBindings = SelectQuery(query, conn);
                //Fill Expression Bindings
                while (readerBindings.Read())
                {
                    checkListBoxDataTypes.SetItemChecked(checkListBoxDataTypes.Items.IndexOf(readerBindings["data_type"].ToString()), true);
                }
                if (readerBindings != null) { readerBindings.Close(); }
                conn.Close();
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
                //Get Row Index By Selected Cell
                int selectedRowIndex = dataGridExamples.SelectedCells[0].RowIndex;
                //Get Row By Index
                DataGridViewRow selectedRow = dataGridExamples.Rows[selectedRowIndex];
                //Get Value From Row By Header Name
                tempExampleId = selectedRow.Cells["ExampleId"].Value.ToString();
                //Delete Confirm
                DialogResult dialogResult = MessageBox.Show("Дійсно видалити обраний елемент?", "Підтвердження видалення", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    //Delete Example
                    string query = $"DELETE FROM Examples " +
                                   $"WHERE example_id = '{tempExampleId}'";
                    DeleteQuery(query, conn);
                    DataLoad();
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
                //If Required Fields Empty
                if (textBoxInputExample.Text.Trim() == string.Empty)
                {
                    throw new DataException();
                }
                conn.Open();
                //Add new Example
                string query = @"INSERT INTO Examples (example, example_result) " +
                               @"VALUES (@Code, @Result);";
                SqlCommand sqlInsert = new SqlCommand(query, conn);
                //Input Parameters
                SqlParameter Code = new SqlParameter("@Code", textBoxInputExample.Text.Trim());
                SqlParameter Result = new SqlParameter("@Result", textBoxInputResult.Text.Trim());
                //Add Parameters
                sqlInsert.Parameters.Add(Code);
                sqlInsert.Parameters.Add(Result);
                //If Fields Empty
                if (textBoxInputResult.Text.Trim() == string.Empty) { Result.Value = DBNull.Value; }
                sqlInsert.ExecuteNonQuery();
            //Binding Examples
                //If At Least One Expression Is Checked
                if (checkListBoxExpressions.CheckedItems.Count > 0)
                {
                    //For Each Checked
                    foreach (object item in checkListBoxExpressions.CheckedItems)
                    {
                        //Bind Example To Expressions
                        query = $"INSERT INTO Examples2Expressions " +
                                $"VALUES ((SELECT TOP 1 example_id FROM Examples ORDER BY example_id DESC), '{item.ToString()}');";
                        sqlInsert = new SqlCommand(query, conn);
                        sqlInsert.ExecuteNonQuery();
                    }
                }
                //For Each Class
                foreach (TreeNode node in treeClass.Nodes)
                {
                    //For Each Method In Class Node
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        //If Checked
                        if (childNode.Checked)
                        {
                            //Bind Example To Methods
                            query = $"INSERT INTO Examples2Methods " +
                                    $"VALUES ((SELECT TOP 1 example_id FROM Examples ORDER BY example_id DESC), (SELECT method_id FROM Methods WHERE method_name = '{childNode.Text}' AND class_name = '{childNode.Parent.Text}'));";
                            sqlInsert = new SqlCommand(query, conn);
                            sqlInsert.ExecuteNonQuery();
                        }
                    }
                }
                //If At Least One Data Type Is Checked
                if (checkListBoxDataTypes.CheckedItems.Count > 0)
                {
                    //For Each Checked
                    foreach (object item in checkListBoxDataTypes.CheckedItems)
                    {
                        //Bind Example To Data Types
                        query = $"INSERT INTO Examples2DataTypes " +
                                $"VALUES ((SELECT TOP 1 example_id FROM Examples ORDER BY example_id DESC), '{item.ToString()}');";
                        sqlInsert = new SqlCommand(query, conn);
                        sqlInsert.ExecuteNonQuery();
                    }
                }
                conn.Close();
                //Form Reload
                DataLoad();
                //Reset Admin Form
                panelAdmin_Clear();
                splitBody.SplitterDistance = 0;
                panelAdminForms.Visible = false;
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
                //If Required Fields Empty
                if (textBoxInputExample.Text.Trim() == string.Empty)
                {
                    throw new DataException();
                }
                conn.Open();
                //Submit Edit Example
                string query = @"UPDATE Examples SET example = @Code, example_result = @Result " +
                               @"WHERE example_id = @Id;";
                SqlCommand sqlInsert = new SqlCommand(query, conn);
                //Input Parameters
                SqlParameter Id = new SqlParameter("@Id", tempExampleId);
                SqlParameter Code = new SqlParameter("@Code", textBoxInputExample.Text.Trim());
                SqlParameter Result = new SqlParameter("@Result", textBoxInputResult.Text.Trim());
                //Add Parameters
                sqlInsert.Parameters.Add(Id);
                sqlInsert.Parameters.Add(Code);
                sqlInsert.Parameters.Add(Result);
                //If Fields Empty
                if (textBoxInputResult.Text.Trim() == string.Empty) { Result.Value = DBNull.Value; }
                sqlInsert.ExecuteNonQuery();
                conn.Close();
            //Delete All Bindings
                //Delete Expression Bindings
                query = $"DELETE FROM Examples2Expressions " +
                        $"WHERE example_id = '{tempExampleId}';";
                DeleteQuery(query, conn);
                //Delete Method Bindings
                query = $"DELETE FROM Examples2Methods " +
                        $"WHERE example_id = '{tempExampleId}';";
                DeleteQuery(query, conn);
                //Delete Data Type Bindings
                query = $"DELETE FROM Examples2DataTypes " +
                        $"WHERE example_id = '{tempExampleId}';";
                DeleteQuery(query, conn);
                conn.Open();
            //Binding Examples
                //If At Least One Expression Is Checked
                if (checkListBoxExpressions.CheckedItems.Count > 0)
                {
                    //For Each Checked
                    foreach (object item in checkListBoxExpressions.CheckedItems)
                    {
                        //Bind Example To Expressions
                        query = $"INSERT INTO Examples2Expressions " +
                                $"VALUES ('{tempExampleId}', '{item.ToString()}');";
                        sqlInsert = new SqlCommand(query, conn);
                        sqlInsert.ExecuteNonQuery();
                    }
                }
                //If At Least One Method Is Checked
                //For Each Class
                foreach (TreeNode node in treeClass.Nodes)
                {
                    //For Each Method In Class Node
                    foreach (TreeNode childNode in node.Nodes)
                    {
                        //If Checked
                        if (childNode.Checked)
                        {
                            //Bind Example To Methods
                            query = $"INSERT INTO Examples2Methods " +
                                    $"VALUES ('{tempExampleId}', (SELECT method_id FROM Methods WHERE method_name = '{childNode.Text}' AND class_name = '{childNode.Parent.Text}'));";
                            sqlInsert = new SqlCommand(query, conn);
                            sqlInsert.ExecuteNonQuery();
                        }
                    }
                }
                //If At Least One Data Type Is Checked
                if (checkListBoxDataTypes.CheckedItems.Count > 0)
                {
                    //For Each Checked
                    foreach (object item in checkListBoxDataTypes.CheckedItems)
                    {
                        //Bind Example To Data Types
                        query = $"INSERT INTO Examples2DataTypes " +
                                $"VALUES ('{tempExampleId}', '{item.ToString()}');";
                        sqlInsert = new SqlCommand(query, conn);
                        sqlInsert.ExecuteNonQuery();
                    }
                }
                conn.Close();
                //Form Reload
                DataLoad();
                //Reset Admin Form
                panelAdmin_Clear();
                splitBody.SplitterDistance = 0;
                panelAdminForms.Visible = false;
            }
            catch (DataException)
            {
                MessageBox.Show("Одне або декілька обов'язкових полів не заповнено!");
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e) //Click Button "Скасувати" After "Змінити"
        {
            //Form Reload
            DataLoad();
            //Reset Cell Select And Admin Form
            dataGridExamples.ClearSelection();
            panelAdmin_Clear();
            splitBody.SplitterDistance = 0;
            panelAdminForms.Visible = false;
        }

        #endregion

        #endregion

    }
}
