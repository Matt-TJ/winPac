using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace winPac
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string value)
        {
            InitializeComponent();
            TextBoxValue = value;
        }

        public string TextBoxValue
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }

        public event EventHandler TextBoxChanged;

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxChanged != null)
            {
                TextBoxChanged(this, e);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(tbName.Text!="" && tbPercent.Text!="")
            {
                IndexPercent myIndex = new IndexPercent(tbName.Text, int.Parse(tbPercent.Text));
                
            }
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public delegate void indexPercentEventHandler(object sender, IndexPercentArgs e);
        public event indexPercentEventHandler indexPercent;
        protected virtual void onIndexPercent(IndexPercentArgs e)
        {
            if(indexPercent!=null)
            {
                this.indexPercent(this, e);
            }
        }

        private void tbPercent_TextChanged(object sender, EventArgs e)
        {
             if(isInt100(tbPercent.Text) )
            {
                onIndexPercent(new IndexPercentArgs(tbName.Text, int.Parse(tbPercent.Text)));
            }

           
        }

        public static bool isInt100(string str)
        {
            string reg = @"^([1-9]\d?|100)$";
            Regex regex = new Regex(reg, RegexOptions.None);
            bool isT=regex.IsMatch(str.Trim());
            return isT;
        }
    }
}
