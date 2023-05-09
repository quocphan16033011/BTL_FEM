using System;
using Python.Runtime;
using System.Runtime.InteropServices;
using System.IO;

namespace FEM
{
    public class TrussSolver
    {
        public static float[,] FormStiffnessMatrix(int GDof, int numberElements, int[,] elementNodes, float[] xx, float[] yy, float E, float A)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                // Initialize the Python engine
                PythonEngine.Initialize();

                // Add a directory to the Python system path
                dynamic sys = Py.Import("sys");
                string scriptDir = @"E:\My file\Source code\Function\formStiffness2DTruss.py";
                sys.path.append(scriptDir);

                // Import the Python module containing the function you want to call
                dynamic stiffnessModule = Py.Import("formStiffness2Dtruss");

                // Call the Python function
                dynamic stiffnessPy = stiffnessModule.formStiffness2Dtruss(GDof, numberElements, elementNodes, xx, yy, E, A);
                dynamic listPy = stiffnessPy.tolist();

                // get the dimensions of the NumPy array
                int numRows = GDof;
                int numCols = GDof;

                // create a C# array with the same dimensions as the NumPy array
                float[,] arrCs = new float[numRows, numCols];

                // copy the values from the nested list to the C# array
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        arrCs[i, j] = (float)listPy[i][j];
                        //Console.Write(arrCs[i, 10]);
                    }
                }

                return arrCs;

            }
        }

        public static float[,] FormStiffnessBeamMatrix(int GDof, int numberElements, int[,] elementNodes,int numberNodes, float[] xx, float[] yy, float E, float A, float I)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("numpy");
                // Initialize the Python engine
                PythonEngine.Initialize();

                // Add a directory to the Python system path
                dynamic sys = Py.Import("sys");
                string scriptDir = @"E:\My file\Source code\Function\formStiffness2DTruss.py";
                sys.path.append(scriptDir);

                // Import the Python module containing the function you want to call
                dynamic stiffnessModule = Py.Import("formStiffness2Dframe");

                // Call the Python function
                dynamic stiffnessPy = stiffnessModule.formStiffness2Dframe(GDof, numberElements, elementNodes,numberNodes, xx, yy, E, A, I);
                dynamic listPy = stiffnessPy.tolist();

                // get the dimensions of the NumPy array
                int numRows = GDof;
                int numCols = GDof;

                // create a C# array with the same dimensions as the NumPy array
                float[,] arrCs = new float[numRows, numCols];

                // copy the values from the nested list to the C# array
                for (int i = 0; i < numRows; i++)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        arrCs[i, j] = (float)listPy[i][j];
                        //Console.Write(arrCs[i, 10]);
                    }
                }

                return arrCs;

            }
        }
    }
}