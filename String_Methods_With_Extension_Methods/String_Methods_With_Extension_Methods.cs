using String_Methods_With_Extension_Methods.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace String_Methods_With_Extension_Methods
{
    public partial class String_Methods_With_Extension_Methods : Form
    {
        public String_Methods_With_Extension_Methods()
        {
            InitializeComponent();
        }

        string[] ıslemler = { "ToCharArray", "Substring", "IndexOf", "EndsWith", "CompareTo", "StartWith", "Contains", "LastIndexOf","Remove" ,"Replace","Split","Insert","Trim"};


        private void String_Methods_With_Extension_Methods_Load(object sender, EventArgs e)
        {
            cmbIslemler.Items.Add("Yapılacak işlem...");
            cmbIslemler.SelectedIndex = 0;
            foreach (string item in ıslemler)
            {
                cmbIslemler.Items.Add(item);
            }
            checkBoxParametre1.Checked = false;
            checkBoxParametre2.Checked = false;
            txtParametre1.Enabled = false;
            txtParametre2.Enabled = false;
        }

        private void btnIslemiGerceklestir_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                string anaMetin = txtAnaMetin.Text;

                Int32.TryParse(txtParametre1.Text, out int intParametre1);
                Int32.TryParse(txtParametre2.Text, out int intParametre2);

                switch (cmbIslemler.SelectedIndex)
                {
                    
                    case 1:
                        {
                            if (checkBoxParametre1.Checked && checkBoxParametre2.Checked)
                            {
                                foreach (char item in anaMetin.ExToCharArray(intParametre1, intParametre2))
                                    listBox1.Items.Add(item);
                            }
                            else
                                foreach (char item in anaMetin.ExToCharArray())
                                    listBox1.Items.Add(item);

                            break;
                        }
                    case 2:
                        {
                            if (checkBoxParametre1.Checked && checkBoxParametre2.Checked)
                                listBox1.Items.Add(anaMetin.ExSubstring(intParametre1, intParametre2));
                            else if (checkBoxParametre1.Checked)
                                listBox1.Items.Add(anaMetin.ExSubstring(intParametre1));

                            break;
                        }
                    case 3:
                        {
                            if (txtParametre1.TextLength == 1 && txtParametre2.TextLength > 0)
                            {
                                listBox1.Items.Add(anaMetin.ExIndexOf(Convert.ToChar(txtParametre1.Text), intParametre2));
                            }
                            if (txtParametre1.TextLength == 1 && txtParametre2.TextLength == 0)
                            {
                                listBox1.Items.Add(anaMetin.ExIndexOf(Convert.ToChar(txtParametre1.Text)));
                            }
                            if (txtParametre1.TextLength > 1 && txtParametre2.TextLength == 0)
                            {
                                listBox1.Items.Add(anaMetin.ExIndexOf(txtParametre1.Text));
                            }
                            if (txtParametre1.TextLength > 1 && txtParametre2.TextLength > 0)
                            {
                                listBox1.Items.Add(anaMetin.ExIndexOf(txtParametre1.Text, intParametre2));
                            }
                            //MessageBox.Show(anaMetin.IndexOf("lih",2).ToString()); 

                            ClearControls();

                            break;
                        }
                    case 4:
                        {
                            listBox1.Items.Add(anaMetin.ExEndsWith(txtParametre1.Text));

                            ClearControls();

                            break;
                        }
                    case 5:
                        {
                            listBox1.Items.Add(anaMetin.ExCompareTo(txtParametre1.Text));

                            break;
                        }
                    case 6:
                        {
                            listBox1.Items.Add(anaMetin.ExStartWith(txtParametre1.Text));

                            break;
                        }
                    case 7:
                        {
                            listBox1.Items.Add(anaMetin.ExContains(txtParametre1.Text));

                            break;
                        }
                    case 8:
                        {
                            if (char.TryParse(txtParametre1.Text, out char chr) && checkBoxParametre2.Checked)
                                listBox1.Items.Add(anaMetin.ExLastIndexOf(chr, intParametre2));
                            if (!char.TryParse(txtParametre1.Text, out  chr) && checkBoxParametre2.Checked)
                                listBox1.Items.Add(anaMetin.ExLastIndexOf(txtParametre1.Text, intParametre2));
                            if (char.TryParse(txtParametre1.Text, out chr) && !checkBoxParametre2.Checked)
                                listBox1.Items.Add(anaMetin.ExLastIndexOf(chr));
                            if (!char.TryParse(txtParametre1.Text, out chr) && !checkBoxParametre2.Checked)
                                listBox1.Items.Add(anaMetin.ExLastIndexOf(txtParametre1.Text));

                            break;
                        }
                    case 9:
                        {
                            if (!checkBoxParametre2.Checked)
                                listBox1.Items.Add(anaMetin.ExRemove(intParametre1));
                            else
                                listBox1.Items.Add(anaMetin.ExRemove(intParametre1, intParametre2));
                            listBox1.Items.Add("sdf");
                            listBox1.Items.Add(anaMetin.Remove(intParametre1,intParametre2));

                            break;
                        }
                    case 10:
                        {
                            if (char.TryParse(txtParametre1.Text, out char oldChar) && char.TryParse(txtParametre2.Text, out char newChar))
                                listBox1.Items.Add(anaMetin.ExReplace(oldChar, newChar));
                            else
                                listBox1.Items.Add(anaMetin.ExReplace(txtParametre1.Text, txtParametre2.Text));

                            break;
                        }
                    case 11:
                        {
                            if (char.TryParse(txtParametre1.Text,out char chr))
                            {
                                foreach (var item in anaMetin.ExSplit(chr)) 
                                {
                                    listBox1.Items.Add(item);
                                }                               
                            }

                            break;
                        }
                    case 12:
                        {
                            if (Int32.TryParse(txtParametre1.Text, out int startIndex) && txtParametre2.Text != null)
                                listBox1.Items.Add(anaMetin.ExInsert(startIndex,txtParametre2.Text));

                            break;
                        }
                    case 13:
                        {
                            listBox1.Items.Add("Ana metin uzunluğu: "+anaMetin.Length.ToString()+"\n");
                            string donenDeger = anaMetin.ExTrim();
                            listBox1.Items.Add(donenDeger);
                            listBox1.Items.Add("trim sonrası uzunluk: "+donenDeger.Length.ToString()+"\n");
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ClearControls()
        {
            txtParametre1.Text = "";
            txtParametre2.Text = "";
            checkBoxParametre1.Checked = false;
            checkBoxParametre2.Checked = false;
        }

        private void checkBoxParametre1_CheckedChanged(object sender, EventArgs e)
        {
            txtParametre1.Enabled = !txtParametre1.Enabled;
        }

        private void checkBoxParametre2_CheckedChanged(object sender, EventArgs e)
        {
            txtParametre2.Enabled = !txtParametre2.Enabled;
        }

        private void cmbIslemler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControls();

            switch ((sender as ComboBox).SelectedIndex)
            {
                case 5:
                    {
                        ClearControls();
                        checkBoxParametre1.Checked = true;
                        checkBoxParametre2.Enabled = false;
                        break;
                    }
                case 6:
                    {
                        checkBoxParametre1.Checked = true;
                        checkBoxParametre2.Enabled = false;
                        break;
                    }
                case 7:
                    {
                        checkBoxParametre1.Checked = true;
                        checkBoxParametre2.Enabled = false;
                        break;
                    }
                case 9:
                    {
                        checkBoxParametre1.Checked = true;
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
