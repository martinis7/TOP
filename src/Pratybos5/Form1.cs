using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pratybos5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            inputText.Text = "Hello world";
        }

        private void inputText_Validating(object sender, CancelEventArgs e)
        {
            if (inputText.Text == "a")
                e.Cancel = true;
        }
    }
}
