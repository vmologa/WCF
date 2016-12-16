using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTaskManager_Client.ServiceReference1;
using System.Diagnostics;

namespace NetTaskManager_Client
{
    public partial class Form1 : Form
    {
        TskMngClient client;
        public Form1()
        {
            InitializeComponent();
            client = new TskMngClient("wsEP1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] proclist = null;       
            try
            {
                proclist = client.GetProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }           
            listBox1.Items.AddRange(proclist);
            listBox1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tasktokill = listBox1.SelectedItem.ToString();
            try
            {
                if (client.KillTask(tasktokill) == 1)
                    MessageBox.Show("Процесс " + tasktokill + " завершен.");
                else
                    MessageBox.Show("Не удалось завершить процесс " + tasktokill);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
            button1_Click(this, EventArgs.Empty);
        }

        private void Run_Click(object sender, EventArgs e)
        {
            string taskrun = tasktorun.Text;
            try
            {
                if (client.RunTask(taskrun) == 1)
                MessageBox.Show("Процесс " + taskrun + " запущен.");
            else
                MessageBox.Show("Не удалось запустить процесс " + taskrun);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1_Click(this, EventArgs.Empty);
        }
    }
}
