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
    public partial class Expressions : Form
    {

        #region Expressions Fields

        private static SqlConnection conn = null;
        private static bool isAdmin;
        private static string selectItem = string.Empty;
        private static string tempExpressionName = string.Empty;

        #endregion

        #region Expressions Form

        public Expressions(bool isAdmin, SqlConnection connection) //Form Constructor
        {
            InitializeComponent();
            Expressions.isAdmin = isAdmin;
            Expressions.conn = connection;
        }

        public Expressions(bool isAdmin, SqlConnection connection, string selection) //Form Constructor
        {
            InitializeComponent();
            Expressions.isAdmin = isAdmin;
            Expressions.conn = connection;
            Expressions.selectItem = selection;
        }

        private void Expressions_Load(object sender, EventArgs e) //Form On Load
        {
            panelAdmin.Visible = isAdmin;
            btnNewExample.Visible = isAdmin;
            DataLoad();
            SetTheme();
            if (selectItem.Trim() != string.Empty)
            {
                listBoxExpressions.SelectedItem = selectItem;
            }
            selectItem = string.Empty;
        }

        private void DataLoad() //Reset And Fill Data
        {
            //Clear Expressions List
            listBoxExpressions.Items.Clear();
            //Clear Text Boxes
            textBoxDescription.Clear();
            dataGridExamples.Rows.Clear();
            //Fill Expressions List
            conn.Open();
            //Get Expressions Names
            string query = "SELECT expression_name " +
                           "FROM Expressions";
            SqlDataReader readerExpression = SelectQuery(query, conn);
            while (readerExpression.Read())
            {
                //Fill Expressions List
                listBoxExpressions.Items.Add($"{readerExpression["expression_name"]}");
            }
            if (readerExpression != null) { readerExpression.Close(); }
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

        private void listBoxDataTypes_SelectedIndexChanged(object sender, EventArgs e) //When Select Expression
        {
            try {
                //Text Boxes Prepare
                textBoxDescription.Clear();
                dataGridExamples.Rows.Clear();

                conn.Open();
                //Get Expressions Description
                string query = $"SELECT expression_description " +
                               $"FROM Expressions WHERE expression_name = '{listBoxExpressions.SelectedItem.ToString()}'";
                SqlDataReader readerDesc = SelectQuery(query, conn);
                //Fill Description
                readerDesc.Read();
                textBoxDescription.Text = $"{readerDesc["expression_description"]}";
                if (readerDesc != null) { readerDesc.Close(); }
                //Get Examples By Expressions
                query = $"SELECT EE.example_id, E.example, E.example_result " +
                        $"FROM Examples2Expressions EE " +
                        $"JOIN Examples E ON EE.example_id = E.example_id " +
                        $"WHERE EE.expression_name = '{listBoxExpressions.SelectedItem.ToString()}'";
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
                conn.Close();
                dataGridExamples.ClearSelection();
            }
            catch (Exception)
            {
                conn.Close();
                listBoxExpressions.SelectedItem = null;
            }
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

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Trim() != string.Empty)
            {
                listBoxExpressions.Items.Clear();
                conn.Open();
                //Search By Expressions
                string query = $"SELECT expression_name " +
                               $"FROM Expressions " +
                               $"WHERE expression_name LIKE '{textBoxSearch.Text.Trim()}%'";
                SqlDataReader readerSearch = SelectQuery(query, conn);
                while (readerSearch.Read())
                {
                    //Fill Expressions List
                    listBoxExpressions.Items.Add($"{readerSearch["expression_name"]}");
                }
                if (readerSearch != null) { readerSearch.Close(); }
                conn.Close();
            }
            else
            {
                listBoxExpressions.Items.Clear();
                conn.Open();
                string query = "SELECT expression_name " +
                               "FROM Expressions";
                SqlDataReader readerSearch = SelectQuery(query, conn);
                while (readerSearch.Read())
                {
                    //Fill Expressions List
                    listBoxExpressions.Items.Add($"{readerSearch["expression_name"]}");
                }
                if (readerSearch != null) { readerSearch.Close(); }
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
            //Clear Input Forms
            textBoxInputName.Clear();
            textBoxInputDescription.Clear();
        }

        #region Top Buttons
        
        private void btnAdd_Click(object sender, EventArgs e) //Click Button "Додати"
        {
            panelAdmin_Clear();
            //Admin Panel Prepare To Add
            panelAdminForms.Visible = true;
            //swap buttons
            btnSubmitAdd.Visible = true;
            btnSubmitEdit.Visible = false;
        }
        
        private void btnEdit_Click(object sender, EventArgs e) //Click Button "Змінити"
        {
            panelAdmin_Clear();
            //Admin Panel Prepare To Edit
            panelAdminForms.Visible = true;
            //Hide Add Submit Button
            btnSubmitAdd.Visible = false;

            try
            {
                //Get Expression Name And Desc To Forms
                textBoxInputName.Text = listBoxExpressions.SelectedItem.ToString();
                textBoxInputDescription.Text = textBoxDescription.Text;
                //Saves Name Of Updating Expression
                tempExpressionName = listBoxExpressions.SelectedItem.ToString();
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
                    //Delete Expression By Name
                    string query = $"DELETE FROM Expressions " +
                               $"WHERE expression_name = '{listBoxExpressions.SelectedItem.ToString()}'";
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
                if (textBoxInputName.Text.Trim() == string.Empty)
                {
                    throw new DataException();
                }
                //Check Duplicate Names
                foreach (object Item in listBoxExpressions.Items)
                {
                    if (Item.ToString() == textBoxInputName.Text.Trim())
                    {
                        throw new DuplicateNameException();
                    }
                }
                conn.Open();
                //Add new Expression
                string query = @"INSERT INTO Expressions (expression_name, expression_description) " +
                               @"VALUES (@Name, @Desc);";
                SqlCommand sqlInsert = new SqlCommand(query, conn);
                //Input Parameters
                SqlParameter Name = new SqlParameter("@Name", textBoxInputName.Text.Trim());
                SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                //Add Parameters
                sqlInsert.Parameters.Add(Name);
                sqlInsert.Parameters.Add(Desc);
                //If Fields Empty
                if (textBoxInputDescription.Text.Trim() == string.Empty) { Desc.Value = DBNull.Value; }
                sqlInsert.ExecuteNonQuery();
                conn.Close();
                //Form Reload
                DataLoad();
                //Reset Admin Form
                panelAdmin_Clear();
                panelAdminForms.Visible = false;
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("Вираз з таким іменем уже додано!");
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
                if (textBoxInputName.Text.Trim() == string.Empty)
                {
                    throw new DataException();
                }
                //Check Duplicate Names
                foreach (object Item in listBoxExpressions.Items)
                {
                    if (Item.ToString() == textBoxInputName.Text.Trim() && listBoxExpressions.SelectedItem.ToString() != textBoxInputName.Text.Trim())
                    {
                        throw new DuplicateNameException();
                    }
                }
                conn.Open();
                //Submit Edit Expression
                string query = @"UPDATE Expressions SET expression_name = @Name, expression_description = @Desc " +
                               @"WHERE expression_name = @OldName;";
                SqlCommand sqlInsert = new SqlCommand(query, conn);
                //Input Parameters
                SqlParameter OldName = new SqlParameter("@OldName", tempExpressionName);
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
                //Reset Node Select And Admin Form
                listBoxExpressions.SelectedItem = null;
                panelAdmin_Clear();
                panelAdminForms.Visible = false;
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("Вираз з таким іменем уже додано!");
            }
            catch (DataException)
            {
                MessageBox.Show("Одне або декілька обов'язкових полів не заповнено!");
            }
        }
        
        private void btnCancelEdit_Click(object sender, EventArgs e) //Click Button "Скасувати" After "Змінити"
        {
            //Reset Node Select And Admin Form
            listBoxExpressions.SelectedItem = null;
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

        #endregion

        #endregion

    }
}
