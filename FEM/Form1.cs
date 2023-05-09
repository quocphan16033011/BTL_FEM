using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "2D Truss")
            {
                // Create a new instance of Form2
                Form2 form2 = new Form2();

                // Show Form2
                form2.Show();

                // Hide the current form
                this.Hide();

                // Handle the FormClosed event of Form2
                form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);

            }
            else if (comboBox1.SelectedItem.ToString() == "2D Frame")
            {
                // Create a new instance of Form2
                Form3 form3 = new Form3();

                // Show Form2
                form3.Show();

                // Hide the current form
                this.Hide();

                // Handle the FormClosed event of Form2
                form3.FormClosed += new FormClosedEventHandler(form3_FormClosed);
            }
            else if (comboBox1.SelectedItem.ToString() == null)
            {
                // Create a new instance of Form2
                Form2 form2 = new Form2();

                // Show Form2
                form2.Show();

                // Hide the current form
                this.Hide();

                // Handle the FormClosed event of Form2
                form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            }
        }
        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show Form1 again when Form2 is closed
            this.Show();
        }

        private void form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show Form1 again when Form2 is closed
            this.Show();
        }

        private void form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show Form1 again when Form2 is closed
            this.Show();
        }

        private void form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show Form1 again when Form2 is closed
            this.Show();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
