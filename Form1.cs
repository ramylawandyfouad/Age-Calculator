using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int move, movx, movy;
        public Form1()
        {
            InitializeComponent();
            lblTodayResult.Text = DateTime.Now.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlTop_DoubleClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBirthday.Value > DateTime.Now)
            {
                MessageBox.Show("Error !! Cant Select After Today");
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
           string rDays= dateTimeBirthday(dtpBirthday.Value).Item1;
            string rMonths =   dateTimeBirthday(dtpBirthday.Value).Item2;
            string rYears =  dateTimeBirthday(dtpBirthday.Value).Item3;

            lblResult.Text = $"Hello {txtName.Text} \n  Age is \n {rYears} years\n {rMonths} months\n {rDays} days";


        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X-movx, MousePosition.Y-movy);
            }
        }
        public (string , string ,string) dateTimeBirthday (DateTime birthday)
        {
            birthday= dtpBirthday.Value;
            DateTime today = DateTime.Today;
            int months = today.Month - birthday.Month;
            int years = today.Year - birthday.Year;
            if (today.Day < birthday.Day)
            {
                months--;

            }
            if (today.Month < birthday.Month)
            {
                years--;
                months  += 12;
            }
            
            int days = (today - birthday.AddMonths((years * 12 )+ months)).Days;
            
            return (days.ToString(),months.ToString(),years.ToString());
        }
    }
}
