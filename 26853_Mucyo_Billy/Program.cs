using System;
using System.Drawing;
using System.Windows.Forms;

namespace _26853_Mucyo_Billy
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }

    // ================= 1. LOGIN FORM =================
    public class LoginForm : Form
    {
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;

        public LoginForm()
        {
            this.Text = "Login";
            this.Size = new Size(300, 200);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblUser = new Label() { Text = "Username:", Location = new Point(20, 20), AutoSize = true };
            txtUser = new TextBox() { Location = new Point(100, 17), Width = 150 };

            Label lblPass = new Label() { Text = "Password:", Location = new Point(20, 50), AutoSize = true };
            txtPass = new TextBox() { Location = new Point(100, 47), Width = 150, PasswordChar = '*' };

            btnLogin = new Button() { Text = "Login", Location = new Point(100, 80), Width = 80 };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.AddRange(new Control[] { lblUser, txtUser, lblPass, txtPass, btnLogin });
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUser.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                this.Hide();
                new MenuForm().Show();
            }
            else
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ================= 2. MAIN MENU FORM =================
    public class MenuForm : Form
    {
        public MenuForm()
        {
            this.Text = "Main Menu - Choose";
            this.Size = new Size(300, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitle = new Label() { Text = "Choose an option:", Location = new Point(80, 20), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold) };

            Button btnBicycle = new Button() { Text = "Bicycle Rental", Location = new Point(80, 60), Width = 120, Height = 40 };
            btnBicycle.Click += (s, e) => { this.Hide(); new BicycleForm().Show(); };

            Button btnMash = new Button() { Text = "Mushroom ID", Location = new Point(80, 110), Width = 120, Height = 40 };
            btnMash.Click += (s, e) => { this.Hide(); new MushroomForm().Show(); };

            Button btnLogout = new Button() { Text = "Logout", Location = new Point(80, 160), Width = 120, Height = 40, BackColor = Color.LightCoral };
            btnLogout.Click += (s, e) => { Application.Exit(); };

            this.Controls.AddRange(new Control[] { lblTitle, btnBicycle, btnMash, btnLogout });
        }
    }

    // ================= 3. BICYCLE RENTAL FORM =================
    public class BicycleForm : Form
    {
        private TextBox txtStart;
        private TextBox txtEnd;
        private Label lblResult;

        public BicycleForm()
        {
            this.Text = "Bicycle Rental";
            this.Size = new Size(350, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblStart = new Label() { Text = "Start Time (0-23):", Location = new Point(20, 20), AutoSize = true };
            txtStart = new TextBox() { Location = new Point(150, 17), Width = 150 };

            Label lblEnd = new Label() { Text = "End Time (1-24):", Location = new Point(20, 50), AutoSize = true };
            txtEnd = new TextBox() { Location = new Point(150, 47), Width = 150 };

            Button btnCalc = new Button() { Text = "Calculate Total", Location = new Point(100, 80), Width = 120 };
            btnCalc.Click += BtnCalc_Click;

            lblResult = new Label() { Text = "Total: 0 RWF", Location = new Point(20, 120), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };

            Button btnBack = new Button() { Text = "Back to Menu", Location = new Point(100, 200), Width = 120 };
            btnBack.Click += (s, e) => { this.Close(); new MenuForm().Show(); };

            this.Controls.AddRange(new Control[] { lblStart, txtStart, lblEnd, txtEnd, btnCalc, lblResult, btnBack });
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtStart.Text, out int start) && int.TryParse(txtEnd.Text, out int end))
            {
                if (start >= 0 && start <= 23 && end >= 1 && end <= 24 && start < end)
                {
                    int total = 0;
                    for (int h = start; h < end; h++) total += GetRate(h);
                    lblResult.Text = $"Total Hours: {end - start}\nTotal Cost: {total} RWF";
                }
                else
                {
                    MessageBox.Show("Invalid times. Start must be < End.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numbers.", "Error");
            }
        }

        private int GetRate(int h)
        {
            if ((h >= 0 && h < 7) || (h >= 21 && h < 24)) return 500;
            if ((h >= 7 && h < 14) || (h >= 19 && h < 21)) return 1000;
            if (h >= 14 && h < 19) return 1500;
            return 0;
        }
    }

    // ================= 4. MUSHROOM IDENTIFIER FORM =================
    public class MushroomForm : Form
    {
        private Label lblQuestion;
        private Label lblResult;
        private bool[] possible = { true, true, true, true, true, true };
        private string[] names = { "Agaric Jaunissant", "Amanite tue-mouche", "Cepe de bordeau", "Coprin chevelu", "Girolle", "Pied bleu" };
        private int step = 0;

        public MushroomForm()
        {
            this.Text = "Mushroom Identifier";
            this.Size = new Size(350, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblQuestion = new Label() { Text = "Does your mushroom have gills?", Location = new Point(20, 20), AutoSize = true, Font = new Font("Arial", 11) };
            
            Button btnYes = new Button() { Text = "Yes", Location = new Point(80, 60), Width = 80 };
            btnYes.Click += (s, e) => ProcessAnswer(true);

            Button btnNo = new Button() { Text = "No", Location = new Point(180, 60), Width = 80 };
            btnNo.Click += (s, e) => ProcessAnswer(false);

            lblResult = new Label() { Text = "", Location = new Point(20, 100), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.DarkGreen };

            Button btnBack = new Button() { Text = "Back to Menu", Location = new Point(100, 160), Width = 120 };
            btnBack.Click += (s, e) => { this.Close(); new MenuForm().Show(); };

            this.Controls.AddRange(new Control[] { lblQuestion, btnYes, btnNo, lblResult, btnBack });
        }

        private void ProcessAnswer(bool yes)
        {
            if (step == 0)
            {
                if (!yes) { possible[0]=false; possible[1]=false; possible[3]=false; possible[4]=false; possible[5]=false; }
                else { possible[2]=false; }
                step++; lblQuestion.Text = "Does your mushroom grow in a forest?";
            }
            else if (step == 1)
            {
                if (yes) { possible[0]=false; possible[3]=false; }
                else { possible[1]=false; possible[4]=false; possible[5]=false; }
                step++; lblQuestion.Text = "Does your mushroom have a ring?";
            }
            else if (step == 2)
            {
                if (yes) { possible[4]=false; possible[5]=false; possible[2]=false; }
                else { possible[0]=false; possible[1]=false; possible[3]=false; }
                step++; lblQuestion.Text = "Does your mushroom have a convex cup?";
            }
            else if (step == 3)
            {
                if (yes) { possible[2]=false; possible[3]=false; possible[4]=false; }
                else { possible[0]=false; possible[1]=false; possible[5]=false; }
                ShowResult();
                return;
            }

            if (CountPossible() == 1) ShowResult();
        }

        private int CountPossible()
        {
            int c = 0; foreach (bool b in possible) if (b) c++; return c;
        }

        private void ShowResult()
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (possible[i]) { lblResult.Text = "Your mushroom is: " + names[i]; break; }
            }
            lblQuestion.Text = "Done!";
        }
    }
}
