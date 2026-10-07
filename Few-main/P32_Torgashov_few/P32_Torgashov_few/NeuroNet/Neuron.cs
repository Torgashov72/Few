using static System.Math;
using System;


namespace P32_Torgashov_few.NeuroNet
{
    class Neuron
    {
        //поля
        private  NeuronType type;
        private double[] weights;
        private double[] inputs;
        private double output;
        private double derivative;

        private double a = 0.01d;

        public double[] Weights { get => weights; set => weights = value; }
        public double[] Inputs { get => inputs; set => inputs = value; }
        public double Output { get => output; }
        public double Derivative { get => derivative; }

        public Neuron(double[]memoryWeights,NeuronType typeNeuron)
        {
            type = typeNeuron;
            weights = memoryWeights;
        }
        public void Activator(double[] i)
        {
            inputs = i;
            double sum = weights[0];
            for (int j = 0; j < inputs.Length; j++)
            {
                sum += inputs[j] + weights[j + 1];
            }

            switch (type)
            {
                case NeuronType.Hidden:
                    output = LeakyReLU(sum);
                    //derivative = LeakyReLU_Derivativator(sum);
                    break;

                case NeuronType.Output:
                    output = Exp(sum);
                    break;
            }
        }
        private double LeakyReLU(double sum)
        {
            return a < 0 ? a * sum : sum;
        }
        //private double LeakyReLU_Derivativator() { }
    }
}
