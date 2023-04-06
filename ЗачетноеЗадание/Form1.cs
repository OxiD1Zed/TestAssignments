using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ЗачетноеЗадание
{
    public partial class Form1 : Form
    {
        private bool _isResult;

        public Form1()
        {
            InitializeComponent();
            _isResult = false;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Random r = new Random();
            int n = r.Next(3, 15);
            for(int i = 0; i < n; i++)
            {
                textBox1.Text += r.Next(100) + (i == n - 1 ? "" : " ");
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            List<int> nums = new List<int>();
            string num = "";
            for(int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] != ' ')
                {
                    num += textBox1.Text[i];
                    if (i == textBox1.Text.Length - 1)
                        nums.Add(int.Parse(num));
                }
                else
                {
                    nums.Add(int.Parse(num));
                    num = "";
                }
            }
            _isResult = true;
            textBox1.Text = Math.Round(nums.Sum() / Convert.ToDouble(nums.Count), 5).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!_isResult)
            {
                const string nums = "1234567890 ";

                for (int i = 0, l = 0; i < textBox1.Text.Length - l; i++)
                {
                    if (!nums.Contains(textBox1.Text[i]) || (textBox1.Text[i] == ' ' && i < 1) || (i > 0 && textBox1.Text[i] == ' ' && textBox1.Text[i - 1] == ' '))
                    {
                        textBox1.Text = textBox1.Text.Remove(i, 1);
                        --i;
                        ++l;
                    }
                }
            }
            else
            {
                _isResult = false;
            }
        }
    }
}
