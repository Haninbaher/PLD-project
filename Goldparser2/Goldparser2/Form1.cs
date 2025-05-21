using com.calitha.goldparser;
using System.Windows.Forms;


namespace Goldparser2
{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p = new MyParser("Haninbaher.cgt", Syntac, Lexical);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Syntac.Items.Clear();
            Lexical.Items.Clear();
            p.Parse(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Syntac.Items.Clear();
            Lexical.Items.Clear();
            try
            {
                p.Parse(textBox1.Text);
                Syntac.Items.Add(" Parsing completed successfully.");

            }
            catch (Exception ex)
            {
                Syntac.Items.Add("❌ Exception during parsing: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.TextChanged += textBox1_TextChanged;
        }
    }
}
