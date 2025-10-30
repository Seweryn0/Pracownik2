using System;
using System.Linq;
using System.Windows.Forms;

namespace Pracownik
{
    public partial class Form1 : Form
    {
        private string wygenerowaneHaslo = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGeneruj_Click(object sender, EventArgs e)
        {
            int dlugosc;
            if (!int.TryParse(txtDlugosc.Text, out dlugosc))
            {
                return;
            }

            string male = "abcdefghijklmnopqrstuvwxyz";
            string duze = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfry = "0123456789";
            string specjalne = "!@#$%^&*()_+-=";

            string zestaw = male;

            if (chkLitery.Checked)
                zestaw += duze;
            if (chkCyfry.Checked)
                zestaw += cyfry;
            if (chkSpecjalne.Checked)
                zestaw += specjalne;

            Random rnd = new Random();
            wygenerowaneHaslo = new string(Enumerable.Repeat(zestaw, dlugosc)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            MessageBox.Show("Wygenerowane hasło: " + wygenerowaneHaslo, "Hasło");
        }

        private void btnZatwierdz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImie.Text) ||
                string.IsNullOrWhiteSpace(txtNazwisko.Text) ||
                cmbStanowisko.SelectedIndex < 0)
            {
                MessageBox.Show("Uzupełnij wszystkie dane pracownika!");
                return;
            }

            string dane = $"Imię: {txtImie.Text}\n" +
                          $"Nazwisko: {txtNazwisko.Text}\n" +
                          $"Stanowisko: {cmbStanowisko.SelectedItem}\n" +
                          $"Hasło: {wygenerowaneHaslo}";
            MessageBox.Show(dane, "Dane pracownika");
        }
    }
}
