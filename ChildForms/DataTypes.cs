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
    public partial class DataTypes : Form
    {

        #region DataTypes Fields

        private static SqlConnection conn = null;
        private static bool isAdmin;
        private static string selectItem = string.Empty;
        private static string tempDataTypeName = string.Empty;

        #endregion

        #region DataTypes Form

        public DataTypes(bool isAdmin, SqlConnection connection) //Form Constructor
        {
            InitializeComponent();
            DataTypes.isAdmin = isAdmin;
            DataTypes.conn = connection;
        }

        public DataTypes(bool isAdmin, SqlConnection connection, string selection) //Form Constructor
        {
            InitializeComponent();
            DataTypes.isAdmin = isAdmin;
            DataTypes.conn = connection;
            DataTypes.selectItem = selection;
        }

        private void DataTypes_Load(object sender, EventArgs e) //Form On Load
        {
            panelAdmin.Visible = isAdmin;
            btnNewExample.Visible = isAdmin;
            DataLoad();
            SetTheme();
            if (selectItem.Trim() != string.Empty)
            {
                listBoxDataTypes.SelectedItem = selectItem;
            }
            selectItem = string.Empty;
        }

        private void DataLoad() //Reset And Fill Data
        {
            //Clear Data Type List
            listBoxDataTypes.Items.Clear();
            //Clear Text Boxes
            textBoxDescription.Clear();
            dataGridExamples.Rows.Clear();
            //Fill Data Type List
            conn.Open();
            //Get Data Type Names
            string query = "SELECT data_type " +
                           "FROM DataTypes";
            SqlDataReader readerDataType = SelectQuery(query, conn);
            while (readerDataType.Read())
            {
                //Fill Data Type List
                listBoxDataTypes.Items.Add($"{readerDataType["data_type"]}");
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
            panelDataTypeTop.ForeColor = Color.Gainsboro;
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

        private void listBoxDataTypes_SelectedIndexChanged(object sender, EventArgs e) //When Select Data Type
        {
            try {
                //Text Boxes Prepare
                textBoxDescription.Clear();
                dataGridExamples.Rows.Clear();

                conn.Open();
                //Get Data Type Description
                string query = $"SELECT data_description " +
                               $"FROM DataTypes WHERE data_type = '{listBoxDataTypes.SelectedItem.ToString()}'";
                SqlDataReader readerDesc = SelectQuery(query, conn);
                //Fill Description
                readerDesc.Read();
                textBoxDescription.Text = $"{readerDesc["data_description"]}";
                if (readerDesc != null) { readerDesc.Close(); }
                //Get Examples By Data Type
                query = $"SELECT ED.example_id, E.example, E.example_result " +
                        $"FROM Examples2DataTypes ED " +
                        $"JOIN Examples E ON ED.example_id = E.example_id " +
                        $"WHERE ED.data_type = '{listBoxDataTypes.SelectedItem.ToString()}'";
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
                listBoxDataTypes.SelectedItem = null;
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

        private void textBoxSearch_TextChanged(object sender, EventArgs e) //Search
        {
            if (textBoxSearch.Text.Trim() != string.Empty)
            {
                listBoxDataTypes.Items.Clear();
                conn.Open();
                //Search By Data Types
                string query = $"SELECT data_type " +
                               $"FROM DataTypes " +
                               $"WHERE data_type LIKE '{textBoxSearch.Text.Trim()}%'";
                SqlDataReader readerSearch = SelectQuery(query, conn);
                while (readerSearch.Read())
                {
                    //Fill Data Type List
                    listBoxDataTypes.Items.Add($"{readerSearch["data_type"]}");
                }
                if (readerSearch != null) { readerSearch.Close(); }
                conn.Close();
            }
            else
            {
                listBoxDataTypes.Items.Clear();
                conn.Open();
                string query = $"SELECT data_type " +
                                $"FROM DataTypes";
                SqlDataReader readerSearch = SelectQuery(query, conn);
                while (readerSearch.Read())
                {
                    //Fill Data Type List
                    listBoxDataTypes.Items.Add($"{readerSearch["data_type"]}");
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
                //Get Data Type Name And Desc To Forms
                textBoxInputName.Text = listBoxDataTypes.SelectedItem.ToString();
                textBoxInputDescription.Text = textBoxDescription.Text;
                //Saves Name Of Updating Data Type
                tempDataTypeName = listBoxDataTypes.SelectedItem.ToString();
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
                    //Delete Data Type By Name
                    string query = $"DELETE FROM DataTypes " +
                                   $"WHERE data_type = '{listBoxDataTypes.SelectedItem.ToString()}'";
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
                foreach (object Item in listBoxDataTypes.Items)
                {
                    if (Item.ToString() == textBoxInputName.Text.Trim())
                    {
                        throw new DuplicateNameException();
                    }
                }
                conn.Open();
                //Add new Data Type
                string query = @"INSERT INTO DataTypes (data_type, data_description) " +
                               @"VALUES (@Type, @Desc);";
                SqlCommand sqlInsert = new SqlCommand(query, conn);
                //Input Parameters
                SqlParameter Type = new SqlParameter("@Type", textBoxInputName.Text.Trim());
                SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                //Add Parameters
                sqlInsert.Parameters.Add(Type);
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
                MessageBox.Show("Тип даних з таким іменем уже додано!");
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
                foreach (object Item in listBoxDataTypes.Items)
                {
                    if (Item.ToString() == textBoxInputName.Text.Trim() && listBoxDataTypes.SelectedItem.ToString() != textBoxInputName.Text.Trim())
                    {
                        throw new DuplicateNameException();
                    }
                }
                conn.Open();
                //Submit Edit Data Type
                string query = @"UPDATE DataTypes SET data_type = @Type, data_description = @Desc " +
                               @"WHERE data_type = @OldType;";
                SqlCommand sqlInsert = new SqlCommand(query, conn);
                //Input Parameters
                SqlParameter OldType = new SqlParameter("@OldType", tempDataTypeName);
                SqlParameter Type = new SqlParameter("@Type", textBoxInputName.Text.Trim());
                SqlParameter Desc = new SqlParameter("@Desc", textBoxInputDescription.Text.Trim());
                //Add Parameters
                sqlInsert.Parameters.Add(OldType);
                sqlInsert.Parameters.Add(Type);
                sqlInsert.Parameters.Add(Desc);
                //If Fields Empty
                if (textBoxInputDescription.Text == string.Empty) { Desc.Value = DBNull.Value; }
                sqlInsert.ExecuteNonQuery();
                conn.Close();
                //Form Reload
                DataLoad();
                //Reset Node Select And Admin Form
                listBoxDataTypes.SelectedItem = null;
                panelAdmin_Clear();
                panelAdminForms.Visible = false;
            }
            catch (DuplicateNameException)
            {
                MessageBox.Show("Тип даних з таким іменем уже додано!");
            }
            catch (DataException)
            {
                MessageBox.Show("Одне або декілька обов'язкових полів не заповнено!");
            }
        }
        
        private void btnCancelEdit_Click(object sender, EventArgs e) //Click Button "Скасувати" After "Змінити"
        {
            //Reset Node Select And Admin Form
            listBoxDataTypes.SelectedItem = null;
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
