using System;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RFIDReaderApp
{
    public partial class Form1 : Form
    {
        SerialPort serial = new SerialPort();

        public Form1()
        {
            InitializeComponent();
            

            serial.PortName = "COM4";  // CHANGE THIS
            serial.BaudRate = 9600;
            serial.DataReceived += Serial_DataReceived;

            try
            {
                serial.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening port: " + ex.Message);
            }
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serial.ReadLine().Trim();

            //Cross-thread safe update
            this.Invoke(new Action(() =>
            {
                textBox1.Text = data; // Display RFID tag in a textbox
            }));
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
