# RFID Reader C# WinForms App
Simple Windows desktop application that displays RFID tag IDs from Arduino via serial communication.

[![MIT License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET Framework](https://img.shields.io/badge/.NET-Framework-blue.svg)]()

---

## Description
A minimal C# WinForms application that connects to an Arduino Uno via serial port and displays RFID tag IDs in real-time. Designed to work with [Arduino-based RFID reader systems](https://github.com/your-username/Arduino-RFID-RC522), this app provides a clean interface for reading and displaying RFID card/tag identification numbers.

## Features
- Real-time RFID tag display
- Simple single-textbox interface
- Cross-thread safe UI updates

## Requirements

### Hardware
- Windows PC/Laptop
- [Arduino Uno with RFID sensor](https://github.com/your-username/Arduino-RFID-RC522)

### Software
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- Windows Forms App template

## Installation
1. Clone this repository
2. Open the solution file in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. Configure COM port in Form1.cs if needed
5. Run the application (F5)

## Usage
1. Connect your [Arduino RFID reader](https://github.com/your-username/Arduino-RFID-RC522) to PC via USB
2. Launch the application
3. Scan RFID cards/tags near the reader
4. Tag IDs will appear in the textbox instantly

## Code

### Main Form (Form1.cs)
```csharp
using System;
using System.IO.Ports;
using System.Windows.Forms;

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

            this.Invoke(new Action(() =&gt;
            {
                textBox1.Text = data;
            }));
        }
    }
}
