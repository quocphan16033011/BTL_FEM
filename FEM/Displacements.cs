using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using System.IO;

namespace FEM
{
    class Solver
    {
        public static float[] Displacement(int GDof, int[] prescribedDof, float[,] stiffness, float[] force)
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
                dynamic dd = Py.Import("example");
                //dynamic stiffness1Module = PythonEngine.Exec(contents);
                //// Call the Python function
                dynamic displacementsPy = dd.displacements(GDof, prescribedDof, stiffness, force);
                dynamic listPy = displacementsPy.tolist();

                //// get the dimensions of the NumPy array
                int numRows = GDof;

                //// create a C# array with the same dimensions as the NumPy array
                float[] arrCs = new float[GDof];

                //// copy the values from the nested list to the C# array
                for (int i = 0; i < numRows; i++)
                {
                    arrCs[i] = displacementsPy[i].As<float>();
                }

                return arrCs;

            }
        }
        public static float [] Reaction(float[] displacements,float[,] stiffness,int GDof, int[] prescribedDof, float[] force)
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
            dynamic dd = Py.Import("outputDisplacementReactions");
            //dynamic stiffness1Module = PythonEngine.Exec(contents);
            //// Call the Python function
            dynamic displacementsPy = dd.outputDisplacementReactions(displacements,stiffness,GDof,prescribedDof,force);
            dynamic listPy = displacementsPy.tolist();

            //// get the dimensions of the NumPy array
            int numRows = prescribedDof.Length;

            //// create a C# array with the same dimensions as the NumPy array
            float[] arrCs = new float[GDof];

            //// copy the values from the nested list to the C# array
            for (int i = 0; i < numRows; i++)
            {
                arrCs[i] = displacementsPy[i].As<float>();
            }

            return arrCs;
        }
        
    }
}
