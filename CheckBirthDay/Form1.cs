using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CheckBirthDay
{
    public partial class Form1 : Form
    {
        PersonService personService;
        public Form1()
        {
            InitializeComponent();
            personService = new PersonService();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            String kisiler = "";

            List<Person> todayBorn = personService.GetBirthDays();
            if (todayBorn.Count > 0)
            {
                foreach (var item in todayBorn)
                {
                    kisiler += item.Name + " " + item.LastName + "-" + item.BirthDate.ToString("dd MMMM yyyy") + "\n";
                }
                MessageBox.Show(
                    $"Bugün {todayBorn.Count} kişinin doğum günü var.\nListe aşağıdaki gibidir.\n\n{kisiler}",
                    "Doğum Günleri",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            this.Close();
        }
    }
}
