using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Python.Runtime;
using System.IO;

namespace FEM
{
    public partial class Form2 : Form
    {

        public Form2()
        {

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numRows = int.Parse(textBox3.Text);
            int numRows1 = int.Parse(textBox4.Text);
            int numRows2 = int.Parse(textBox5.Text);
            int numCols = 2;

            // Create a new DataTable with the specified number of columns
            DataTable table = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table.Columns.Add("Coordinate X", typeof(string));

                }
                else
                {
                    table.Columns.Add("Coordinate Y", typeof(string));
                }
            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows; i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    row[j] = string.Format("Node {0}", i + 1);
                }
                table.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView1.DataSource = table;


            // Create a new DataTable with the specified number of columns
            DataTable table1 = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table1.Columns.Add("Node 1", typeof(string));

                }
                else
                {
                    table1.Columns.Add("Node 2", typeof(string));
                }
            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows1; i++)
            {
                DataRow row = table1.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    row[j] = string.Format("Element {0}", i + 1);
                }
                table1.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView2.DataSource = table1;


            // Create a new DataTable with the specified number of columns
            DataTable table2 = new DataTable();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    table2.Columns.Add("Dof", typeof(string));

                }
                else
                {
                    table2.Columns.Add("Force in Dof", typeof(string));
                }
            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows * 2; i++)
            {
                DataRow row = table2.NewRow();
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Dof {0}", i + 1);
                    }
                    else
                    {
                        row[j] = string.Format("Force in Dof {0}", i + 1);
                    }
                }
                table2.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView3.DataSource = table2;


            // Create a new DataTable with the specified number of columns
            DataTable table3 = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table3.Columns.Add("Element", typeof(string));

                }
                else
                {
                    table3.Columns.Add("Axial Force", typeof(string));
                }

            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows1; i++)
            {
                DataRow row = table3.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    if (j == 0)
                    {
                        row[j] = i + 1;
                    }
                    else
                    {
                        row[j] = string.Format("Axial Force {0}", i + 1);
                    }
                }
                table3.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView4.DataSource = table3;


            // Create a new DataTable with the specified number of columns
            DataTable table4 = new DataTable();
            for (int i = 0; i < 1; i++)
            {
                table4.Columns.Add("Prescribed Dof", typeof(string));

            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows2; i++)
            {
                DataRow row = table4.NewRow();
                for (int j = 0; j < 1; j++)
                {
                    row[j] = string.Format("Prescribed Dof ");
                }
                table4.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView9.DataSource = table4;


            // Create a new DataTable with the specified number of columns
            DataTable table5 = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table5.Columns.Add("Dof", typeof(string));

                }
                else
                {
                    table5.Columns.Add("Value", typeof(string));
                }

            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows * 2; i++)
            {
                DataRow row = table5.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Dof {0}", i + 1);
                    }
                    else
                    {
                        row[j] = string.Format("Value {0}", i + 1);
                    }
                }
                table5.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView5.DataSource = table5;


            // Create a new DataTable with the specified number of columns
            DataTable table6 = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table6.Columns.Add("Dof", typeof(string));

                }
                else
                {
                    table6.Columns.Add("Value", typeof(string));
                }

            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows2; i++)
            {
                DataRow row = table6.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Dof ");
                    }
                    else
                    {
                        row[j] = string.Format("Value {0}", i + 1);
                    }
                }
                table6.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView6.DataSource = table6;


            // Create a new DataTable with the specified number of columns
            DataTable table7 = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table7.Columns.Add("Element", typeof(string));

                }
                else
                {
                    table7.Columns.Add("Value", typeof(string));
                }

            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows1; i++)
            {
                DataRow row = table7.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Element {0}", i + 1);
                    }
                    else
                    {
                        row[j] = string.Format("Value {0}", i + 1);
                    }
                }
                table7.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView7.DataSource = table7;

            // Create a new DataTable with the specified number of columns
            DataTable table8 = new DataTable();
            for (int i = 0; i < numCols; i++)
            {
                if (i == 0)
                {
                    table8.Columns.Add("Element", typeof(string));

                }
                else
                {
                    table8.Columns.Add("Value", typeof(string));
                }

            }
            // Add rows to the DataTable with the specified number of rows, and fill them with sample data
            for (int i = 0; i < numRows1; i++)
            {
                DataRow row = table8.NewRow();
                for (int j = 0; j < numCols; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Element {0}", i + 1);
                    }
                    else
                    {
                        row[j] = string.Format("Value {0}", i + 1);
                    }
                }
                table8.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView8.DataSource = table8;

        }


        float[] XX = new float[0];
        float[] YY = new float[0];
        int[,] ElementNodes = new int[0, 0];

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            float E = Convert.ToSingle(textBox1.Text);
            float A = Convert.ToSingle(textBox2.Text);
            int numberNodes = Convert.ToInt32(textBox3.Text);
            int numberElements = Convert.ToInt32(textBox4.Text);
            int GDof = numberNodes * 2;
            int numberPrescribedDof = Convert.ToInt32(textBox5.Text);

            // Define the dimensions of the array
            int rows1 = dataGridView2.Rows.Count;
            int cols1 = dataGridView2.Columns.Count;

            // Create the n-dimensional array
            int[,] ElementNodes = new int[rows1 - 1, cols1];

            // Iterate through the grid data
            for (int i = 0; i < rows1 - 1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    // Get the value from the grid data
                    int elementNodes = Convert.ToInt32(dataGridView2.Rows[i].Cells[j].Value);
                    // Assign the value to the corresponding position in the array
                    ElementNodes[i, j] = elementNodes;
                }
            }

            // Define the dimensions of the array
            int rows = dataGridView1.Rows.Count;
            int cols = dataGridView1.Columns.Count;

            // Create the n-dimensional array
            float[] XX = new float[rows - 1];
            float[] YY = new float[rows - 1];
            float[,] cordinate = new float[rows-1,cols];
            // Iterate through the grid data
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Get the value from the grid data
                    float xx = Convert.ToSingle(dataGridView1.Rows[i].Cells[0].Value);
                    float yy = Convert.ToSingle(dataGridView1.Rows[i].Cells[1].Value);
                    float value = Convert.ToSingle(dataGridView1.Rows[i].Cells[j].Value);
                    // Assign the value to the corresponding position in the array
                    XX[i] = xx;
                    YY[i] = yy;
                    cordinate[i, j] = value;
                }
            }

            // Define the dimensions of the array
            int rows2 = dataGridView3.Rows.Count;
            int cols2 = dataGridView3.Columns.Count;

            // Create the n-dimensional array
            float[] Force = new float[rows2 - 1];

            // Iterate through the grid data
            for (int i = 0; i < rows2 - 1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    // Get the value from the grid data
                    float value = Convert.ToSingle(dataGridView3.Rows[i].Cells[1].Value);
                    // Assign the value to the corresponding position in the array
                    Force[i] = value;
                }
            }

            // Define the dimensions of the array
            int rows3 = dataGridView4.Rows.Count;
            int cols3 = dataGridView4.Columns.Count;

            // Create the n-dimensional array
            float[] Force_axial = new float[rows3 - 1];
            float[] Index = new float[rows3 - 1];

            // Iterate through the grid data
            for (int i = 0; i < rows3 - 1; i++)
            {
                for (int j = 0; j < cols3; j++)
                {
                    // Get the value from the grid data
                    float index = Convert.ToSingle(dataGridView4.Rows[i].Cells[0].Value);
                    float value = Convert.ToSingle(dataGridView4.Rows[i].Cells[1].Value);
                    // Assign the value to the corresponding position in the array
                    Force_axial[i] = value;
                    Index[i] = index;
                }
            }

            // Define the dimensions of the array
            int rows4 = dataGridView9.Rows.Count;

            // Create the n-dimensional array
            int[] prescribedDof = new int[rows4 - 1];

            // Iterate through the grid data
            for (int i = 0; i < rows4 - 1; i++)
            {
                int index = Convert.ToInt32(dataGridView9.Rows[i].Cells[0].Value);
                // Assign the value to the corresponding position in the array
                prescribedDof[i] = index;
                Console.Write(prescribedDof[i]);
                Console.WriteLine();
            }


            float[,] stiffness = TrussSolver.FormStiffnessMatrix(GDof, numberElements, ElementNodes, XX, YY, E, A);
            //float[] force = TrussSolver.ForceMatrix(Force,Force_axial,Index,GDof,numberElements,ElementNodes,XX,YY);
            for (int j = 0; j < numberElements; j++)
            {
                int[,] elementDof = new int[1, 4];
                float xa, ya, c, s;
                float length;
                elementDof[0, 0] = ElementNodes[j, 0] * 2 - 2;
                elementDof[0, 1] = ElementNodes[j, 0] * 2 - 1;
                elementDof[0, 2] = ElementNodes[j, 1] * 2 - 2;
                elementDof[0, 3] = ElementNodes[j, 1] * 2 - 1;
                xa = XX[ElementNodes[j, 1] - 1] - XX[ElementNodes[j, 0] - 1];
                ya = YY[ElementNodes[j, 1] - 1] - YY[ElementNodes[j, 0] - 1];
                length = (float)Math.Sqrt(xa * xa + ya * ya);
                c = xa / length;
                s = ya / length;
                Force[ElementNodes[j, 0] * 2 - 2] = Force[ElementNodes[j, 0] * 2 - 2] + Force_axial[j] * length / 2 * c;
                Force[ElementNodes[j, 0] * 2 - 1] = Force[ElementNodes[j, 0] * 2 - 1] + Force_axial[j] * length / 2 * s;
                Force[ElementNodes[j, 1] * 2 - 2] = Force[ElementNodes[j, 1] * 2 - 2] + Force_axial[j] * length / 2 * c;
                Force[ElementNodes[j, 1] * 2 - 1] = Force[ElementNodes[j, 1] * 2 - 1] + Force_axial[j] * length / 2 * s;
            }

            for (int i = 0; i < rows2 - 1; i++)
            {
                Console.Write(Force[i]);
                Console.WriteLine();
            }

            float[] displacements = Solver.Displacement(GDof, prescribedDof, stiffness, Force);
            for (int i = 0; i < GDof; i++)
            {
                Console.Write(displacements[i]);
                Console.WriteLine();
            }

            DataTable table5 = new DataTable();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    table5.Columns.Add("Dof", typeof(string));

                }
                else
                {
                    table5.Columns.Add("Value", typeof(string));
                }

            }
            for (int i = 0; i < GDof; i++)
            {
                DataRow row = table5.NewRow();
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Dof {0}", i + 1);
                    }
                    else
                    {
                        row[j] = displacements[i];
                    }
                }
                table5.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView5.DataSource = table5;

            float[] Reactions = Solver.Reaction(displacements, stiffness,GDof, prescribedDof, Force);
            for (int i = 0; i < GDof; i++)
            {
                Console.Write(displacements[i]);
                Console.WriteLine();
            }

            DataTable table6 = new DataTable();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    table6.Columns.Add("Dof", typeof(string));

                }
                else
                {
                    table6.Columns.Add("Value", typeof(string));
                }

            }
            for (int i = 0; i < numberPrescribedDof; i++)
            {
                DataRow row = table6.NewRow();
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Dof {0}", prescribedDof[i]);
                    }
                    else
                    {
                        row[j] = Reactions[i];
                    }
                }
                table6.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView6.DataSource = table6;

            float[] Internalforce = new float[numberElements];
            float[] Stress = new float[numberElements];
            for (int j = 0; j < numberElements; j++)
            {
                int[,] elementDof = new int[1, 4];
                float xa, ya, c, s,a1;
                float length;
                elementDof[0, 0] = ElementNodes[j, 0] * 2 - 2;
                elementDof[0, 1] = ElementNodes[j, 0] * 2 - 1;
                elementDof[0, 2] = ElementNodes[j, 1] * 2 - 2;
                elementDof[0, 3] = ElementNodes[j, 1] * 2 - 1;
                xa = XX[ElementNodes[j, 1] - 1] - XX[ElementNodes[j, 0] - 1];
                ya = YY[ElementNodes[j, 1] - 1] - YY[ElementNodes[j, 0] - 1];
                length = (float)Math.Sqrt(xa * xa + ya * ya);
                c = xa / length;
                s = ya / length;
                a1 = -c * displacements[ElementNodes[j, 0] * 2 - 2] - s * displacements[ElementNodes[j, 0] * 2 - 1] + c * displacements[ElementNodes[j, 1] * 2 - 2] + s * displacements[ElementNodes[j, 1] * 2 - 1];
                Internalforce[j] = E*A*a1/length;
                Stress[j] = E * a1 / length;
            }

            DataTable table7 = new DataTable();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    table7.Columns.Add("Element", typeof(string));

                }
                else
                {
                    table7.Columns.Add("Value", typeof(string));
                }

            }
            for (int i = 0; i < numberElements; i++)
            {
                DataRow row = table7.NewRow();
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Element {0}", i+1);
                    }
                    else
                    {
                        row[j] = Internalforce[i];
                    }
                }
                table7.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView7.DataSource = table7;

            DataTable table8 = new DataTable();
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    table8.Columns.Add("Element", typeof(string));

                }
                else
                {
                    table8.Columns.Add("Value", typeof(string));
                }

            }
            for (int i = 0; i < numberElements; i++)
            {
                DataRow row = table8.NewRow();
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        row[j] = string.Format("Element {0}", i+1);
                    }
                    else
                    {
                        row[j] = Stress[i];
                    }
                }
                table8.Rows.Add(row);
            }

            // Set the DataTable as the data source for the DataGridView control
            dataGridView8.DataSource = table8;

            string imagePath = Plot.plotdis(ElementNodes, cordinate, displacements);
            string image2Path = Plot.plotinternal(ElementNodes, cordinate, Internalforce);
            pictureBox1.Image = Image.FromFile(@"E:\My file\Code\C#\FEM\FEM\bin\Debug\dis.png");
            pictureBox2.Image = Image.FromFile(@"E:\My file\Code\C#\FEM\FEM\bin\Debug\internal.png");
   
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
     
        }
    }
}
