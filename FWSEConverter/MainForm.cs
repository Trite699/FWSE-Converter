using System;
using System.Windows.Forms;

namespace FWSEConverter
{
    public class MainForm : Form
    {
        private TextBox inputBox;
        private TextBox outputBox;
        private Button browseInputBtn;
        private Button browseOutputBtn;
        private Button convertBtn;
        private Label statusLabel;

        public MainForm()
        {
            Text = "FWSE Converter";
            Width = 600;
            Height = 250;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            InitializeUI();
        }

        private void InitializeUI()
        {
            inputBox = new TextBox { Left = 20, Top = 20, Width = 400 };
            browseInputBtn = new Button { Text = "Input", Left = 430, Top = 18, Width = 100 };

            outputBox = new TextBox { Left = 20, Top = 60, Width = 400 };
            browseOutputBtn = new Button { Text = "Output", Left = 430, Top = 58, Width = 100 };

            convertBtn = new Button { Text = "Convert", Left = 20, Top = 100, Width = 510, Height = 40 };

            statusLabel = new Label { Left = 20, Top = 150, Width = 500, Text = "Ready" };

            browseInputBtn.Click += BrowseInput;
            browseOutputBtn.Click += BrowseOutput;
            convertBtn.Click += ConvertFile;

            Controls.Add(inputBox);
            Controls.Add(browseInputBtn);
            Controls.Add(outputBox);
            Controls.Add(browseOutputBtn);
            Controls.Add(convertBtn);
            Controls.Add(statusLabel);
        }

        private void BrowseInput(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                inputBox.Text = dlg.FileName;
        }

        private void BrowseOutput(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "WAV Files|*.wav|All Files|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
                outputBox.Text = dlg.FileName;
        }

        private void ConvertFile(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Converting...";

                string input = inputBox.Text;
                string output = outputBox.Text;

                //  CALLS EXISTING LOGIC HERE
                ConvertingManager.Convert(input, output);

                statusLabel.Text = "Done!";
                MessageBox.Show("Conversion complete!");
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error";
                MessageBox.Show(ex.Message);
            }
        }
    }
}
