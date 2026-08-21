using System;
using System.Data;
using System.Windows.Forms;

namespace Better_than_previous_Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void AppendToCalculationString(object sender, EventArgs e)
        {
            Button InvokedBtn = sender as Button;
            if (InvokedBtn != null)
            {
                TextBox.Text += InvokedBtn.Text;
            }
        }

        private void ClearEntry(object sender, EventArgs e)
        {
            TextBox.Text = String.Empty;
        }

        private void EvaluateCalculation(object sender, EventArgs e)
        {
            string expression = TextBox.Text;
            var result = new DataTable();
            try
            {
                double EvaluatedResult = Convert.ToDouble(result.Compute(expression, null));
                if (double.IsInfinity(EvaluatedResult) || double.IsNaN(EvaluatedResult))
                {
                    MessageBox.Show("Invalid calculation. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                TextBox.Text = EvaluatedResult.ToString();
            }
            catch
            {
                TextBox.Text = "Error, something was wrong with the calculation";
            }
        }

        private void ButBack_Click(object sender, EventArgs e)
        {
            if (TextBox.Text != "")
            {
                int Length = TextBox.Text.Length;
                string ResultSubstring = TextBox.Text.Substring(0, Length - 1);
                TextBox.Text = ResultSubstring;
            }
        }

        private void StringSquare(object sender, EventArgs e)
        {
            if(TextBox.Text != "")
            {
                try{
                    double Numbers = Convert.ToDouble(TextBox.Text);
                    double Result = Numbers * Numbers;
                    TextBox.Text = Result.ToString();
                }
                catch
                {
                    TextBox.Text = "Error, Please don't write whole calculation when typing X2, only one number at a time";
                }
            }
        }
    }
}
