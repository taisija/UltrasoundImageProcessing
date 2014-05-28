using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication
{
    class NodesFactory
    {
        public static NodesFactory INSTANCE = new NodesFactory();
        // some variables to store data from file

        private bool initialized;

        private NodesFactory()
        {
            random = new Random();
            histogram = new double[256];
            /*double eta = 0.3460035898429516;
            double gamma = 0;
            double epsilon = 1;
            double lambda = 256;
            //double alpha = 0.05;
            for (int x = 0; x < 256; x++)
            {
                histogram[x] = (eta / Math.Sqrt(2 * Math.PI)) * (lambda / ((x - epsilon) * (lambda - x + epsilon))) * Math.Exp((-0.5) * (gamma + eta * Math.Log((x - epsilon) / (lambda - x + epsilon), Math.E)) * (gamma + eta * Math.Log((x - epsilon) / (lambda - x + epsilon), Math.E)));
            }*/
        }

        public Node NewNode(int ind)
        {
            if (!initialized)
            {
                // load data from file
                try
                {
                    using (TextReader reader = File.OpenText("john.txt"))
                    {
                        const int n = 256;
                        histogram = new double[n];

                        string text = reader.ReadLine();
                        histogram[0] = double.Parse(text);

                        for (int x = 1; x < n; x++)
                        {
                            text = reader.ReadLine();
                            histogram[x] = double.Parse(text) + histogram[x - 1];
                        }
                    }
                    using (TextReader reader = File.OpenText("filter.txt"))
                    {
                        filters = new double[numOfFilters][,];
                        filtersSizes = new int[numOfFilters];
                        filtersDenom = new int[numOfFilters];
                        for (int n = 0; n < numOfFilters; n++)
                        {
                            string text = reader.ReadLine();
                            string[] bits = text.Split(' ');
                            filtersSizes[n] = int.Parse(bits[0]);
                            filtersDenom[n] = int.Parse(bits[1]);
                            filters[n] = new double[filtersSizes[n], filtersSizes[n]];
                            for (int i = 0; i < filtersSizes[n]; i++)
                            {
                                text = reader.ReadLine();
                                string[] nbits = text.Split(' ');
                                for (int j = 0; j < filtersSizes[n]; j++)
                                {
                                    filters[n][i, j] = double.Parse(nbits[j]);
                                }
                            }
                            for (int i = filtersSizes[n]; i < maxFilterLen; i++)
                                reader.ReadLine();
                        }
                    }
                    initialized = true;
                }
                catch (Exception ex)
                {
                    Debug.Assert(false, ex.ToString());
                    MessageBox.Show("filter.txt or john.txt not found in current directory");
                    return null;
                }
            }
            if (ind < numOfSimpleFilters)
                return new Node(filters, ind, filtersSizes, filtersDenom);
            else
                return new NodeFunction(filters, ind, filtersSizes, filtersDenom, numOfSimpleFilters, histogram);
        }
        private Random random;
        private double[][,] filters;
        private double[] histogram;
        private int numOfFilters = 35;
        private int numOfSimpleFilters = 20;
        private int[] filtersSizes;
        private int[] filtersDenom;
        private int maxFilterLen = 5;
    }
}

