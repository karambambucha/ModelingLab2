using System;
using System.Windows.Forms;

namespace ModelingLab2
{
    public struct Params
    {
        public int ModelingTime { get; set; }
        public int ClientIntervalTime { get; set; }
        public int TimeToWarehouse { get; set; }
        public int TimeFromWarehouse { get; set; }
        public int CalcTime { get; set; }
        public int MaxClients { get; set; }
        public int Clerks { get; set; }
    }
    public partial class ModelingForm : Form
    {
        public ModelingForm()
        {
            InitializeComponent();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8)
                e.Handled = true;
        }
        private WholesaleStoreModel model;
        public void UpdateRichTextBox(object sender, EventArgs e)
        {
            richTextBox1.Text = model.GetJournal();
        }
        public void CheckStopCondition(object sender, EventArgs e)
        {
            if (model.CurrentTime >= modelingTime.Value && PlusMinute.Enabled)
            {
                PlusMinute.Stop();
                PlusMinute.Tick -= new EventHandler(model.UpdateSystem);
                PlusMinute.Tick -= new EventHandler(UpdateRichTextBox);
                PlusMinute.Tick -= new EventHandler(CheckStopCondition);
                richTextBox1.Text += model.GetStatisitcs();
                MessageBox.Show(model.GetStatisitcs());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "";
                
                Params parameters = new Params();
                parameters.ModelingTime = (int)modelingTime.Value;
                parameters.ClientIntervalTime = (int)clientIntervalTime.Value;
                parameters.TimeToWarehouse = (int)timeToWarehouse.Value;
                parameters.TimeFromWarehouse = (int)timeFromWarehouse.Value;
                parameters.CalcTime = (int)calcTime.Value;
                parameters.MaxClients = (int)maxClients.Value;
                parameters.Clerks = (int)clerkNum.Value;
                model = new WholesaleStoreModel(parameters);
                PlusMinute.Tick += new EventHandler(model.UpdateSystem);
                PlusMinute.Tick += new EventHandler(UpdateRichTextBox);
                PlusMinute.Tick += new EventHandler(CheckStopCondition);
                PlusMinute.Interval = (int)milliseconds.Value;
                PlusMinute.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
