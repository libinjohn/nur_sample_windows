#region License
/*
MIT License
Copyright � 2015 Nordic ID

All rights reserved.

Authors
 * Mikko L�hteenm�ki

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NurApiDotNet;

namespace NurTagTrackingGate 
{
    public partial class EthSearchForm : Form
    {
        NurApi mApi = null;

        public DeviceList.DeviceArgs ConnArgs { get; set; }

        public EthSearchForm()
        {
            InitializeComponent();
        }

        public EthSearchForm(NurApi api)
        {
            mApi = api;

            InitializeComponent();

            deviceList.Api = api;
            deviceList.RefreshList();
            deviceList.ConnectToDevice += deviceList_ConnectToDevice;

            ConnArgs = new DeviceList.DeviceArgs("n/a", 1000);
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void deviceList_ConnectToDevice(object sender, DeviceList.DeviceArgs e)
        {
            ConnArgs = e;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}