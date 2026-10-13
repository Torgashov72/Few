using System;
using System.IO;
using System.Windows.Forms;

namespace P32_Torgashov_few.NeuroNet
{
    abstract class Layer
    {
        protected string name_Layer;
        string pathDirWeights;
        string pathFileWeights;
        protected int numofneurons;
        protected int numofprevneurons;
        protected const double learningrate= 0.087;
        protected const double momentum = 0.07;
        protected double[,] lastdeltaweights;
        protected Neuron[] neurons;

        public double[] Data
        {
            set
            {
                for (int i = 0;i< numofneurons; i++)
                {
                    neurons[i].Activator(value);
                }
            }
        }
        protected Layer (int non,int nopn, NeuronType nt,string nm_Layer)
        {
            numofneurons=non;
            numofprevneurons = nopn;
            neurons = new Neuron[non];
            name_Layer = nm_Layer;
            pathDirWeights = AppDomain.CurrentDomain.BaseDirectory + "";
            pathFileWeights = pathDirWeights + name_Layer + "";

            lastdeltaweights = new double[non, nopn + 1];
            double[,] Weights;

            if (File.Exists(pathFileWeights))
                Weights=WeightInitilize(MemoryMode.GET,pathFileWeights);
            else
            {
                Directory.CreateDirectory(pathDirWeights);
                Weights = WeightInitilize(MemoryMode.INIT, pathFileWeights);
            }
            for(int i=0;i< non; i++)
            {
                double[] tmp_weights = new double[nopn + 1];
                for ( int j = 0; j < nopn + 1; j++)
                {
                    tmp_weights[j] = Weights[i, j];
                }
                neurons[i] = new Neuron(tmp_weights, nt);
            }

        }
        public double[,] WeightInitilize(MemoryMode mm,string path)
        {
            char[] delim = new char[] { ' ', ';' }; //разделитель
            string tmpStr;
            string[] tmpStrWeights;
            double[,] weights = new double[numofneurons, numofprevneurons + 1];
            switch (mm)
            {
                case MemoryMode.GET:
                    tmpStrWeights = File.ReadAllLines(path);
                    string[] memmory_element;
                    for(int i = 0; i < numofneurons; i++)
                    {
                        memmory_element = tmpStrWeights[i].Split(delim);
                        for(int j = 0;j < numofprevneurons; j++)
                        {
                            weights[i,j]=double.Parse(memmory_element[j].Replace(',','.'),
                                System.Globalization.CultureInfo.InvariantCulture);
                        }
                    }
                    break;



                case MemoryMode.SET:
                    tmpStrWeights = new string[numofneurons];
                    if (!File.Exists(path))
                    {
                        MessageBox.Show("Внимание файле нет\n"+ MessageBoxButtons.OK + MessageBoxIcon.Exclamation);
                    }
                    for(int i = 0;i<numofneurons;i++)
                    {
                        tmpStr = neurons[i].Weights[0].ToString();
                        for(int j = 0; j < numofprevneurons; j++)
                        {
                            tmpStr += delim[0] + neurons[i].Weights[j].ToString();
                        }
                        tmpStrWeights[i] = tmpStr;
                    }
                    File.WriteAllLines(path, tmpStrWeights);
                    break;



                case MemoryMode.INIT:
                    break;
                default:
                    break;
            }


            return new double[1, 1];
        }
    }
}
