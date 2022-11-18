using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruby_Docs
{
    public partial class MainForm : Form
    {
        #region Main Form Fields

        //Active Main Form
        public static MainForm selfRef { get; private set; }
        //Active Child Form
        private Form activeChildForm = null;
        //Theme Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        //Sql Fields
        private string serverName = "DESKTOP-BADMVBV";
        private string database = "Kursova";
        private string username;
        private string pass;
        private static SqlConnection conn = null;
        private static bool isAdmin = false;

        #endregion

        #region Main Form

        public MainForm(string Username, string Pass, bool IsAdmin) //Main Form Constructor
        {
            selfRef = this;
            InitializeComponent();
            //Received Fields
            username = Username;
            pass = Pass;
            isAdmin = IsAdmin;
            //Form Prepare
            random = new Random();
            btnCloseChildForm.Visible = false;
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //Database Connection
            string connetionStr = @"Data Source= " + this.serverName + ";Initial Catalog= " + this.database + ";User ID=" + this.username + ";Password= " + this.pass + ";";
            conn = new SqlConnection(connetionStr);
            try
            {
                conn.Open();
                MessageBox.Show("Успішне з'єднання з базою даних");
                this.Show();
                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Помилка, неправильний логін або пароль");
                Auth Auth = new Auth();
                Auth.Show();
            }
        }

        private Color MainFormThemeColor() //Main Theme
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void btnGlobalSearch_Click(object sender, EventArgs e) //Global Search Button
        {
            OpenChildForm(new GlobalSearch(isAdmin, conn), sender);
            labelTop.Text = "Глобальний Пошук";
        }

        private void MainForm_FormClosing(object sender, EventArgs e) //When Close
        {
            Application.Exit();
        }

        #endregion

        #region Child Form

        private void OpenChildForm(Form childForm, object btnSender) //Open Form In Main Panel
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
            }
            ActivateButton(btnSender);
            btnGlobalSearch.BackColor = panelTop.BackColor;
            activeChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelOpenChildForm.Controls.Add(childForm);
            this.panelOpenChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void OpenExpressionsFromChild(string selection) //Open Expression Form From Any Place With Item Selection
        {
            selfRef.OpenChildForm(new Expressions(isAdmin, conn, selection), btnExpression);
        }

        public void OpenClassesFromChild(string selection) //Open Class Form From Any Place With Item Selection
        {
            selfRef.OpenChildForm(new Classes(isAdmin, conn, selection), btnClass);
        }

        public void OpenDataTypesFromChild(string selection) //Open Data Type Form From Any Place With Item Selection
        {
            selfRef.OpenChildForm(new DataTypes(isAdmin, conn, selection), btnType);
        }

        public void OpenExamplesFromChild(string selection) //Open Examples Form From Any Place With Item Selection
        {
            selfRef.OpenChildForm(new Examples(isAdmin, conn, selection), btnExample);
        }

        public void OpenExamplesFromChild() //Open Example Form From Any Place
        {
            selfRef.OpenChildForm(new Examples(isAdmin, conn), btnExample);
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e) //Close Child Form
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
            }
            ResetForm();
            btnGlobalSearch.BackColor = Color.FromArgb(50, 50, 80);
        }

        private void ResetForm() //Reset Main Form
        {
            DisableButton();
            labelTop.Text = "ГОЛОВНА";
            panelTop.BackColor = Color.FromArgb(50, 50, 80);
            panelLogo.BackColor = Color.FromArgb(30, 30, 60);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        #endregion

        #region Buttons Hover

        private void ActivateButton(object btnSender) //Side Panel Button Click
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = MainFormThemeColor();
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.DarkerColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, -0.3);
                    ThemeColor.LighterColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, 0.7);

                    currentButton = (Button)btnSender;
                    currentButton.BackColor = ThemeColor.PrimaryColor;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTop.BackColor = ThemeColor.PrimaryColor;
                    panelLogo.BackColor = ThemeColor.DarkerColor;
                    btnCloseChildForm.Visible = true;
                    labelTop.Text = currentButton.Text;
                }
            }
        }
        private void DisableButton() //Disable Other Buttons
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(50, 50, 80);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        #endregion

        #region Side Panel

        private void btnExpression_Click(object sender, EventArgs e) //Click "Вирази"
        {
            OpenChildForm(new Expressions(isAdmin, conn), sender);
        }

        private void btnClass_Click(object sender, EventArgs e) //Click "Класи"
        {
            OpenChildForm(new Classes(isAdmin, conn), sender);
        }

        private void btnType_Click(object sender, EventArgs e) //Click "Типи Даних"
        {
            OpenChildForm(new DataTypes(isAdmin, conn), sender);
        }

        private void btnExample_Click(object sender, EventArgs e) //Click "Приклади"
        {
            OpenChildForm(new Examples(isAdmin, conn), sender);
        }

        #endregion

    }
}