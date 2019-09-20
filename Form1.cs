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

namespace Class5
{
    public partial class Form1 : Form
    {
        
        List<string> studentid = new List<string> {};
        List<string> name = new List<string> { };
        List<string> mobile = new List<string> { };
        List<int> age = new List<int> { };
        List<string> address = new List<string> { };
        List<double> gpapoint = new List<double> { };



    public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!studentid.Contains(idTextBox1.Text) && idTextBox1.TextLength == 4 && !String.IsNullOrEmpty (idTextBox1.Text)) 
            {
                if (!String.IsNullOrEmpty(nameTextBox2.Text) && nameTextBox2.Text.Length <= 30)

                {

                    if (!String.IsNullOrEmpty(mobileTextBox3.Text) && mobileTextBox3.Text.Length == 11) 
                    {

                        if (!String.IsNullOrEmpty(ageTextBox4.Text) && !Regex.IsMatch(ageTextBox4.Text,"^0-9"))
                        {
                            
                            if (!String.IsNullOrEmpty(gpaTextBox6.Text) && !Regex.IsMatch(gpaTextBox6.Text, "/^[0-9]+(\\.[0-9]+)?$") && Convert.ToDouble(gpaTextBox6.Text) >= 0 && Convert.ToDouble(gpaTextBox6.Text) <= 4)
                            {
                                studentid.Add(idTextBox1.Text);
                                name.Add(nameTextBox2.Text);
                                mobile.Add(mobileTextBox3.Text);
                                age.Add (Convert.ToInt32(ageTextBox4.Text));
                                address.Add(addressTextBox5.Text);
                                gpapoint.Add(Convert.ToDouble(gpaTextBox6.Text));
                                displayRichTextBox.Text = "Student Information: " + "\n" + "\n Id: " + idTextBox1.Text + "\n Name: " + nameTextBox2.Text + "\n Contact No: " + mobileTextBox3.Text + "\n Age: " + ageTextBox4.Text + "\n Address: " +
                                addressTextBox5.Text + "\n GPA: " + gpaTextBox6.Text + "\n \n";

                            }

                            else
                            {
                                MessageBox.Show("Please Input Your GPA Properly");
                                return;
                            }

                        }

                        else
                        {
                            MessageBox.Show("Please Input Your Age Properly");
                            return;
                        }

                    }

                    else
                    {
                        MessageBox.Show("Please Input Your Mobile Number Properly");
                        return;
                    }

                }

                else
                {
                    MessageBox.Show("Please Input Your Name Properly");
                    return;
                }

            }

            else
            {
                MessageBox.Show("Please Input Your Id Properly");
                return;
            }


        }


        


        private void Search(int i)
        {
            if (!i.Equals(-1))
            {
                displayRichTextBox.Clear();
                displayRichTextBox.Text += "Student Information: " +  "\n \n Id: " + studentid[i] + "\n Name: " + name[i] + "\n Mobile: " + mobile[i] + "\n Age: " + age[i] + "\n Address: " + address[i] + "\n GPA: " + gpapoint[i] + "\n \n";
            }
            else
            {
                MessageBox.Show("Nothing found !!!");
                return;
            }
        }


        private void showButton_Click(object sender, EventArgs e)
        {
            displayRichTextBox.Clear();

            for (int i = 0; i < studentid.Count(); i++)
            {
                displayRichTextBox.Text += "Id: " + studentid[i] + " \n Name: " + name[i] + "\n Mobile: " + mobile[i] + "\n Age: " + age[i] + "\n Address: " + address[i] + "\n GPA: " + gpapoint[i] + "\n \n";

            }

            maxTextBox7.Text= gpapoint.Max().ToString();
            minTextBox10.Text= gpapoint.Min().ToString();
            avgTextBox12.Text= gpapoint.Average().ToString();
            int maxIndex = gpapoint.IndexOf(gpapoint.Max());
            int minIndex = gpapoint.IndexOf(gpapoint.Min());
            maxNameTextBox8.Text = name[maxIndex].ToString();
            minNameTextBox11.Text = name[minIndex].ToString();
            totalTextBox13.Text = gpapoint.Sum().ToString();







        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            int searchIndex;
            displayRichTextBox.Clear();
            if (idRadioButton.Checked)
            {
                searchIndex = studentid.IndexOf(studentid.Find(x => x.Equals(idTextBox1.Text)));
                Search(searchIndex);
            }
            else if (nameRadioButton.Checked)
            {
                searchIndex = name.IndexOf(name.Find(x => x.Equals(nameTextBox2.Text)));
                Search(searchIndex);
            }
            else if (mobileRadioButton.Checked)
            {
                searchIndex = mobile.IndexOf(mobile.Find(x => x.Equals(mobileTextBox3.Text)));
                Search(searchIndex);
            }
            else
            {
                MessageBox.Show(text: "Check Any Option !!!");
                return;
            }

        }
    }
}
