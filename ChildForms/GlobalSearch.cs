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
    public partial class GlobalSearch : Form
    {
        #region Search Fields

        private static SqlConnection conn = null;
        private static bool isAdmin = false;
        private static string tempDesc = string.Empty;

        #endregion

        #region Search Form

        public GlobalSearch(bool isAdmin, SqlConnection connection) //Form Constructor
        {
            InitializeComponent();
            GlobalSearch.conn = connection;
            GlobalSearch.isAdmin = isAdmin;
        }

        private void GlobalSearch_Load(object sender, EventArgs e) //Form On Load
        {
            SetTheme();
        }

        private void SetTheme() //Child Theme
        {
            //Body Color
            ActiveForm.BackColor = ThemeColor.DarkerColor;
            ActiveForm.BackColor = Color.White;
            //Headers Back Color
            panelSearchTop.BackColor = ThemeColor.LighterColor;
            //Table Theme
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            this.dataGridResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
            dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle.BackColor = ThemeColor.LighterColor;
            dataGridResults.GridColor = ThemeColor.DarkerColor;
        }

        private SqlDataReader SelectQuery(string query, SqlConnection connection) //Sql Select Query (Return Data Reader)
        {
            SqlCommand sqlReturn = new SqlCommand(query, connection);
            SqlDataReader reader = sqlReturn.ExecuteReader();
            return reader;
        }

        #endregion

        #region Search Controls

        private void textBoxSearch_TextChanged(object sender, EventArgs e) //Dynamic Search
        {
            if (textBoxSearch.Text.Trim() != string.Empty)
            {
                conn.Open();
                dataGridResults.Rows.Clear();
                //Search By Expressions
                if (checkBoxExpressions.Checked)
                {
                    string query = $"SELECT expression_name, expression_description " +
                                   $"FROM Expressions " +
                                   $"WHERE expression_name LIKE '{textBoxSearch.Text.Trim()}%'";
                    SqlDataReader readerSearch = SelectQuery(query, conn);
                    while (readerSearch.Read())
                    {
                        tempDesc = readerSearch["expression_description"].ToString();
                        if (tempDesc.Length > 30)
                        {
                            tempDesc = tempDesc.Substring(0, 30).Trim() + " . . .";
                        }
                        if (readerSearch.HasRows == true)
                        {
                            dataGridResults.Rows.Add($"{readerSearch["expression_name"]}",
                                                     $"{readerSearch["expression_name"]}",
                                                      "Вираз",
                                                     $"{tempDesc}");
                        }
                    }
                    if (readerSearch != null) { readerSearch.Close(); }
                }
                //Search By Classes
                if (checkBoxMethods.Checked)
                {
                    string query = $"SELECT class_name, class_description " +
                                   $"FROM Classes " +
                                   $"WHERE class_name LIKE '{textBoxSearch.Text.Trim()}%'";
                    SqlDataReader readerSearch = SelectQuery(query, conn);
                    while (readerSearch.Read())
                    {
                        tempDesc = readerSearch["class_description"].ToString();
                        if (tempDesc.Length > 30)
                        {
                            tempDesc = tempDesc.Substring(0, 30).Trim() + " . . .";
                        }
                        if (readerSearch.HasRows == true)
                        {
                            dataGridResults.Rows.Add($"{readerSearch["class_name"]}",
                                                     $"{readerSearch["class_name"]}",
                                                      "Клас",
                                                     $"{tempDesc}");
                        }
                    }
                    if (readerSearch != null) { readerSearch.Close(); }
                }
                //Search By Methods
                if (checkBoxMethods.Checked)
                {
                    string query = $"SELECT method_name, class_name, method_description " +
                                   $"FROM Methods " +
                                   $"WHERE method_name LIKE '{textBoxSearch.Text.Trim()}%'";
                    SqlDataReader readerSearch = SelectQuery(query, conn);
                    while (readerSearch.Read())
                    {
                        tempDesc = readerSearch["method_description"].ToString();
                        if (tempDesc.Length > 30)
                        {
                            tempDesc = tempDesc.Substring(0, 30).Trim() + " . . .";
                        }
                        if (readerSearch.HasRows == true)
                        {
                            dataGridResults.Rows.Add($"{readerSearch["method_name"]} {readerSearch["class_name"]}",
                                                     $"{readerSearch["method_name"]}({readerSearch["class_name"]})",
                                                      "Метод",
                                                     $"{tempDesc}");
                        }
                    }
                    if (readerSearch != null) { readerSearch.Close(); }
                }
                //Search By Data Types
                if (checkBoxDataTypes.Checked)
                {
                    string query = $"SELECT data_type, data_description " +
                                   $"FROM DataTypes " +
                                   $"WHERE data_type LIKE '{textBoxSearch.Text.Trim()}%'";
                    SqlDataReader readerSearch = SelectQuery(query, conn);
                    while (readerSearch.Read())
                    {
                        tempDesc = readerSearch["data_description"].ToString();
                        if (tempDesc.Length > 30)
                        {
                            tempDesc = tempDesc.Substring(0, 30).Trim() + " . . .";
                        }
                        if (readerSearch.HasRows == true)
                        {
                            dataGridResults.Rows.Add($"{readerSearch["data_type"]}",
                                                     $"{readerSearch["data_type"]}",
                                                      "Тип Даних",
                                                     $"{tempDesc}");
                        }
                    }
                    if (readerSearch != null) { readerSearch.Close(); }
                }
                //Search By Examples
                if (checkBoxExamples.Checked)
                {
                    string query = $"SELECT example_id, example, example_result " +
                                   $"FROM Examples " +
                                   $"WHERE example LIKE '%{textBoxSearch.Text}%'";
                    SqlDataReader readerSearch = SelectQuery(query, conn);
                    while (readerSearch.Read())
                    {
                        tempDesc = readerSearch["example"].ToString();
                        if (tempDesc.Length > 30)
                        {
                            tempDesc = tempDesc.Substring(0, 30).Trim() + " . . .";
                        }
                        if (readerSearch.HasRows == true)
                        {
                            dataGridResults.Rows.Add($"{readerSearch["example_id"]}",
                                                     $"{tempDesc}",
                                                      "Приклад",
                                                     $"{readerSearch["example_result"]}");
                        }
                    }
                    if (readerSearch != null) { readerSearch.Close(); }
                }
                conn.Close();
            }
            else
            {
                dataGridResults.Rows.Clear();
            }
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e) //Search Filters - All
        {
            checkBoxExpressions.Checked = checkBoxAll.Checked;
            checkBoxMethods.Checked = checkBoxAll.Checked;
            checkBoxDataTypes.Checked = checkBoxAll.Checked;
            checkBoxExamples.Checked = checkBoxAll.Checked;
        }

        private void dataGridResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //Double Click On Search Result Cell
        {
            //Get Row Index By Selected Cell
            int selectedRowIndex = dataGridResults.SelectedCells[0].RowIndex;
            //Get Row By Index
            DataGridViewRow selectedRow = dataGridResults.Rows[selectedRowIndex];
            //Get Key From Selected Row
            //If Select Expression
            if (selectedRow.Cells["ItemType"].Value.ToString() == "Вираз")
            {
                MainForm.selfRef.OpenExpressionsFromChild(selectedRow.Cells["Key"].Value.ToString());
                return;
            }
            //If Select Class Or Method
            if (selectedRow.Cells["ItemType"].Value.ToString() == "Клас" || selectedRow.Cells["ItemType"].Value.ToString() == "Метод")
            {
                MainForm.selfRef.OpenClassesFromChild(selectedRow.Cells["Key"].Value.ToString());
                return;
            }
            //If Select Data Type
            if (selectedRow.Cells["ItemType"].Value.ToString() == "Тип Даних")
            {
                MainForm.selfRef.OpenDataTypesFromChild(selectedRow.Cells["Key"].Value.ToString());
                return;
            }
            //If Select Example
            if (selectedRow.Cells["ItemType"].Value.ToString() == "Приклад")
            {
                MainForm.selfRef.OpenExamplesFromChild(selectedRow.Cells["Key"].Value.ToString());
                return;
            }
        }

        #endregion

    }
}