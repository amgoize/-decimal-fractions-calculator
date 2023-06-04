using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsRichTextBoxEmpty(richTextBox1) == false || IsRichTextBoxEmpty(richTextBox2) == false)
            {
                MessageBox.Show("Ввели неподходящие данные");

            }
            else
            {
                string s = new calculator(richTextBox1.Text, richTextBox2.Text).Summa().ToString();
                richTextBox3.Text = s;
                WriteToFile(@"C:\\Users\\Кирилл Владимирович\\Desktop\\ооп\\лр7-8\\Курсовая\\1.txt", richTextBox1.Text, richTextBox2.Text, "+", s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsRichTextBoxEmpty(richTextBox1) == false || IsRichTextBoxEmpty(richTextBox2) == false)
            {
                MessageBox.Show("Ввели неподходящие данные");

            }
            else
            {
                string s = new calculator(richTextBox1.Text, richTextBox2.Text).Minus().ToString();
                richTextBox3.Text = s;
                WriteToFile(@"C:\\Users\\Кирилл Владимирович\\Desktop\\ооп\\лр7-8\\Курсовая\\1.txt", richTextBox1.Text, richTextBox2.Text, "-", s);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IsRichTextBoxEmpty(richTextBox1) == false || IsRichTextBoxEmpty(richTextBox2) == false)
            {
                MessageBox.Show("Ввели неподходящие данные");

            }
            else
            {
                string s = new calculator(richTextBox1.Text, richTextBox2.Text).Multyply();
                richTextBox3.Text = s;
                WriteToFile(@"C:\\Users\\Кирилл Владимирович\\Desktop\\ооп\\лр7-8\\Курсовая\\1.txt", richTextBox1.Text, richTextBox2.Text, "*", s);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IsRichTextBoxEmpty(richTextBox1) == false || IsRichTextBoxEmpty(richTextBox2) == false)
            {
                MessageBox.Show("Ввели неподходящие данные");

            }
            else
            {
                string s = new calculator(richTextBox1.Text, richTextBox2.Text).Division().ToString();
                richTextBox3.Text = s;
                WriteToFile(@"C:\\Users\\Кирилл Владимирович\\Desktop\\ооп\\лр7-8\\Курсовая\\1.txt", richTextBox1.Text, richTextBox2.Text, "/", s);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReadFromFile(@"C:\\Users\\Кирилл Владимирович\\Desktop\\ооп\\лр7-8\\Курсовая\\1.txt", richTextBox4);
        }
        public class calculator
        {
            public string n1;
            public string n2;
            public int number1;
            public int number2;
            public int tenmax;
            public int ten1;
            public int ten2;
            private Drob a, b;
            public calculator(string _n1, string _n2)
            {
                n1 = _n1;
                n2 = _n2;
                string whole_part1 = "";
                string fract_part1 = "";
                string whole_part2 = "";
                string fract_part2 = "";
                int fl = 0;
                for (int i = 0; i < n1.Length; i++)
                {

                    if (n1[i] == ',')
                    {
                        fl = 1;
                        continue;
                    }
                    if (fl != 1)
                    {
                        whole_part1 += n1[i];
                    }
                    else if (fl == 1)
                    {
                        fract_part1 += n1[i];
                    }
                }
                fl = 0;
                for (int i = 0; i < n2.Length; i++)
                {

                    if (n2[i] == ',')
                    {
                        fl = 1;
                        continue;
                    }
                    if (fl != 1)
                    {
                        whole_part2 += n2[i];
                    }
                    else if (fl == 1)
                    {
                        fract_part2 += n2[i];
                    }
                }
                int leng1 = fract_part1.Length;
                int leng2 = fract_part2.Length;

                string zero1 = '1' + "".PadLeft(leng1, '0');//1000
                string zero2 = '1' + "".PadLeft(leng2, '0');

                ten1 = int.Parse(zero1);
                ten2 = int.Parse(zero2);
                tenmax = 10;
                int tenmin = 10;
                int fr1;
                int fr2;
                fr1 = int.Parse(fract_part1);
                fr2 = int.Parse(fract_part2);

                if (whole_part1[0] == '-' && whole_part2[0] == '-')
                {
                    fr1 = -1 * int.Parse(fract_part1);
                    fr2 = -1 * int.Parse(fract_part2);
                }
                else if (whole_part1[0] == '-')
                {
                    fr1 = -1 * int.Parse(fract_part1);
                }
                else if (whole_part2[0] == '-')
                {
                    fr2 = -1 * int.Parse(fract_part2);
                }


                int wh1 = int.Parse(whole_part1);
                int wh2 = int.Parse(whole_part2);
                number1 = wh1 * ten1 + fr1;
                number2 = wh2 * ten2 + fr2;
                if (ten1 > ten2)
                {
                    number2 = number2 * (ten1 / ten2);
                    tenmax = ten1;
                }
                else
                {
                    number1 = number1 * (ten2 / ten1);
                    tenmax = ten2;
                }
            }
            public double Summa()
            {
                a = new Drob(number1, tenmax);
                b = new Drob(number2, tenmax);
                Drob c = a + b;
                double result = (double)c.number / (double)c.ten;
                return result;
            }
            public double Minus()
            {
                a = new Drob(number1, tenmax);
                b = new Drob(number2, tenmax);
                Drob c = a - b;
                double result = (double)c.number / (double)c.ten;
                return result;
            }
            public string Multyply()
            {
                a = new Drob(number1, tenmax);
                b = new Drob(number2, tenmax);
                Drob c = a * b;
                string result = c.number.ToString() + ',' + c.ten.ToString();
                return result;
            }
            public double Division()
            {
                a = new Drob(number1, ten1);
                b = new Drob(number2, ten2);
                Drob c = a / b;
                double result = c.number / (double)c.ten;
                return result;
            }


        }
            class Drob
            {
            public long number;
            public long ten;
                public Drob(long number, long ten)
                {

                    this.number = number;
                    this.ten = ten;
                }
                public static Drob operator +(Drob a, Drob b)
                {
                    long number_new = a.number + b.number;
                    long ten_new = a.ten;
                    return new Drob(number_new, ten_new);
                }
                public static Drob operator -(Drob a, Drob b)
                {
                    long number_new = a.number - b.number;
                    long ten_new = a.ten;
                    return new Drob(number_new, ten_new);
                }

            public static Drob operator *(Drob a, Drob b)
            {
                long number_new = (long)(a.number * b.number / (a.ten * b.ten));
                long ten_new = (a.number * b.number % (a.ten * b.ten));
                if (ten_new < 0)
                {
                    ten_new = ten_new * -1;
                }
                return new Drob(number_new, ten_new);
            }
            public static Drob operator /(Drob a, Drob b)
            {
                long number_new = a.number * b.ten;
                long ten_new = b.number * a.ten;
                return new Drob(number_new, ten_new);
            }

        }
        public bool IsRichTextBoxEmpty(RichTextBox richTextBox)
        {
            int count = 0;
            if (richTextBox.Text.Contains(",") == false)
            {
                count++;
            }
            if (richTextBox.Text.Contains(".") == true)
            {
                count++;
            }
            if (string.IsNullOrEmpty(richTextBox.Text) == true)
            {
                count++;
            }
            if (count > 0)
            {
                return false;
            }
            else { return true; }
        }
        public void Clean()
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
        }
        public void WriteToFile(string path, string a, string b, string operation, string c)
        {
            File.AppendAllText(path, a + operation + b + '=' + c + Environment.NewLine);
        }
        public static void ReadFromFile(string path, RichTextBox richTextBox)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    richTextBox.AppendText(line + Environment.NewLine);
                }
            }
        }
        public static void ClearFile(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearFile(@"C:\\Users\\Кирилл Владимирович\\Desktop\\ооп\\лр7-8\\Курсовая\\1.txt");
        }
    }
}