using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayisalLoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] cekilis = new int[6];
        Random rnd = new Random();
        int i = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                if (txtBir.Text == string.Empty || txtIki.Text == string.Empty || txtUc.Text == string.Empty || txtDort.Text == string.Empty || txtBes.Text == string.Empty || txtAlti.Text == string.Empty)
                {
                    lblUyari.Text = "(*) Oynamak istediğiniz kolonda altı sayı olmalıdır.";
                }
                else if (Convert.ToInt32(txtBir.Text) > 49 || Convert.ToInt32(txtIki.Text) > 49 || Convert.ToInt32(txtUc.Text) > 49 || Convert.ToInt32(txtDort.Text) > 49 || Convert.ToInt32(txtBes.Text) > 49 || Convert.ToInt32(txtAlti.Text) > 49)
                {
                    lblUyari.Text = "(**) Oyunu başlatabilmeniz için 1-49 aralığında sayılar girmelisiniz.";
                }
                else if (txtBir.Text==txtIki.Text || txtBir.Text==txtUc.Text || txtBir.Text==txtDort.Text || txtBir.Text==txtBes.Text || txtBir.Text==txtAlti.Text || txtIki.Text==txtUc.Text || txtIki.Text==txtDort.Text || txtIki.Text==txtBes.Text || txtIki.Text==txtAlti.Text || txtUc.Text==txtDort.Text || txtUc.Text==txtBes.Text || txtUc.Text==txtAlti.Text || txtDort.Text==txtBes.Text || txtDort.Text==txtAlti.Text || txtBes.Text==txtAlti.Text)
                {
                    lblUyari.Text = "(***) Oynadığınız kolondaki sayılar birbirinden farklı olmalıdır.";
                }
                else
                {
                    timer1.Start();
                    txtBir.Enabled = false;
                    txtIki.Enabled = false;
                    txtUc.Enabled = false;
                    txtDort.Enabled = false;
                    txtBes.Enabled = false;
                    txtAlti.Enabled = false;
                    lblUyari.Text = "";
                }
            }
            else
            {
                MessageBox.Show($"Çekiliş devam ediyor. Sonlandırmak için \"{btnCekilisiSonlandir.Text}\" butonuna basınız.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < 50; i++)
            {
                btnBir.Text = Convert.ToString(rnd.Next(1, 50));
                btnIki.Text = Convert.ToString(rnd.Next(1, 50));
                btnUc.Text = Convert.ToString(rnd.Next(1, 50));
                btnDort.Text = Convert.ToString(rnd.Next(1, 50));
                btnBes.Text = Convert.ToString(rnd.Next(1, 50));
                btnAlti.Text = Convert.ToString(rnd.Next(1, 50));
            }
        }

        private void btnCekilisiSonlandir_Click(object sender, EventArgs e)
        {
            
            if (timer1.Enabled==true)
            {
                timer1.Stop();
                if (btnBir.Text == btnIki.Text || btnBir.Text == btnUc.Text || btnBir.Text == btnDort.Text || btnBir.Text == btnBes.Text || btnBir.Text == btnAlti.Text || btnIki.Text == btnUc.Text || btnIki.Text == btnDort.Text || btnIki.Text == btnBes.Text || btnIki.Text == btnAlti.Text || btnUc.Text == btnDort.Text || btnUc.Text == btnBes.Text || btnUc.Text == btnAlti.Text || btnDort.Text == btnBes.Text || btnDort.Text == btnAlti.Text || btnBes.Text == btnAlti.Text)
                {
                    timer1.Start();
                }
            }
            
        }

        private void btnSayilariSirala_Click(object sender, EventArgs e)
        {
            cekilis[0] = int.Parse(btnBir.Text);
            cekilis[1] = int.Parse(btnIki.Text);
            cekilis[2] = int.Parse(btnUc.Text);
            cekilis[3] = int.Parse(btnDort.Text);
            cekilis[4] = int.Parse(btnBes.Text);
            cekilis[5] = int.Parse(btnAlti.Text);

            Array.Sort(cekilis);

            btnBir.Text = Convert.ToString(cekilis[0]);
            btnIki.Text = Convert.ToString(cekilis[1]);
            btnUc.Text = Convert.ToString(cekilis[2]);
            btnDort.Text = Convert.ToString(cekilis[3]);
            btnBes.Text = Convert.ToString(cekilis[4]);
            btnAlti.Text = Convert.ToString(cekilis[5]);
        }

        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKolonEkle_Click(object sender, EventArgs e)
        {
            lstKolonlar.Items.Add($"{txtBir.Text} - {txtIki.Text} - {txtUc.Text} - {txtDort.Text} - {txtBes.Text} - {txtAlti.Text}");
            txtBir.Text = string.Empty;
            txtIki.Text = string.Empty;
            txtUc.Text = string.Empty;
            txtDort.Text = string.Empty;
            txtBes.Text = string.Empty;
            txtAlti.Text = string.Empty;
            txtBir.Focus();
        }

        private void btnKolonSil_Click(object sender, EventArgs e)
        {
            lstKolonlar.Items.Remove(lstKolonlar.SelectedItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bişey
        }
    }
}
