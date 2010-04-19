using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BookShop.AcceptanceTests.Manual.Support
{
    public partial class ManualStepForm : Form
    {
        public string ManualStepText { get; set; }
        public int CurrentLine { get; set; }

        public ManualStepForm()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void CancelButon_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ManualStepForm_Load(object sender, EventArgs e)
        {
            RichTextBox.Text = ManualStepText;

            string[] lines = ManualStepText.Split('\n');

            var firstCharacterIndex = lines.Take(CurrentLine).Sum(s => s.Length);
            var count = lines[CurrentLine].Length;

            RichTextBox.Select(firstCharacterIndex, count);
            //RichTextBox.SelectionFont = new Font(RichTextBox.Font, FontStyle.Bold); 
            RichTextBox.SelectionBackColor = Color.Yellow;

            RichTextBox.Select(firstCharacterIndex, 0);
        }
    }
}