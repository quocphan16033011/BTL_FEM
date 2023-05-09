using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
namespace FEM
{
    class Plot
    {
        public static string plotdis(int[,] elementNodes, float[,] nodeCoordinates, float[] displacement)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                // Initialize the Python engine
                PythonEngine.Initialize();
                string scriptPath = @"E:\My file\Code\C#\FEM\FEM\bin\Debug";
                PythonEngine.PythonPath += ";" + scriptPath;

                // Add a directory to the Python system path
                //dynamic sys = Py.Import("sys");
                //sys.path.append(@"E:\My file\Source code\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\");
                //string contents = File.ReadAllText(@"E:\My file\Source code\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\displacements.py");
                // Import the Python module containing the function you want to call
                dynamic dd = Py.Import("plotdis");
                //dynamic stiffness1Module = PythonEngine.Exec(contents);
                //// Call the Python function
                dynamic displacementsPy = dd.plotDis(elementNodes, nodeCoordinates, displacement);

                string imgaePath = (string)displacementsPy;


                return imgaePath;

            }
        }

        public static string plotinternal(int[,] elementNodes, float[,] nodeCoordinates, float[] internalforce)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                // Initialize the Python engine
                PythonEngine.Initialize();
                string scriptPath = @"E:\My file\Code\C#\FEM\FEM\bin\Debug";
                PythonEngine.PythonPath += ";" + scriptPath;

                // Add a directory to the Python system path
                //dynamic sys = Py.Import("sys");
                //sys.path.append(@"E:\My file\Source code\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\");
                //string contents = File.ReadAllText(@"E:\My file\Source code\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\displacements.py");
                // Import the Python module containing the function you want to call
                dynamic dd = Py.Import("plotdis");
                //dynamic stiffness1Module = PythonEngine.Exec(contents);
                //// Call the Python function
                dynamic displacementsPy = dd.plot_axial_force(elementNodes, nodeCoordinates, internalforce);

                string imgaePath = (string)displacementsPy;


                return imgaePath;

            }
        }
    }
}
