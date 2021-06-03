using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_9
{
    public partial class Form1 : Form
    {
        double[] Stat = new double[5]; 
        public Form1()
        {
            InitializeComponent();
            chart1.Legends.Clear();
            Prob5.Enabled = false;
        }

        private void startB_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Stat[0] = (double)Prob1.Value;
            Stat[1] = (double)Prob2.Value;
            Stat[2] = (double)Prob3.Value;
            Stat[3] = (double)Prob4.Value;
            Stat[4] = 1 - Stat[0] - Stat[1] - Stat[2] - Stat[3];

            if (Stat[4] <= 0 || Stat[4] > 1) return;

            Prob5.Value = (decimal)Stat[4];            
            Random random = new Random();

            int[] Count = new int[5];
            var N = (int)NExp.Value;

            for (int i = 0; i < N; i++)
            {
                double k = (double)random.NextDouble();
                for (int j = 0; j < 5; j++)
                {
                    k -= Stat[j];
                    if (k <= 0)
                    {
                        Count[j]++;
                        break;
                    }                    
                }
            }
            for (var i = 0; i < 5; i++)
            {
                chart1.Series[0].Points.AddXY(i + 1, (float)Count[i] / N);
            }

        }
    }
}
