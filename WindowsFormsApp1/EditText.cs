using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
        public partial class EditText : Form
        {
                public object textEdited;
                public string updatedText;

                public EditText()
                {
                        InitializeComponent();
                }

                private void EditText_Load(object sender, EventArgs e)
                {

                }

                private void EditText_Shown(object sender, EventArgs e)
                {

                }

                private bool isNaN(string text)
                {
                        for (int i = 0; i < text.Length; i++)
                        {
                                char letter = text[i];  //get the current character
                                int test = letter - '0';        //remove the 

                                if (test > 9)
                                {
                                        return true;
                                }
                        }

                        return false;
                }

                private void ConfirmText_Button_Click(object sender, EventArgs e)
                {
                        //check whether or not the textbox has only numbers
                        if (isNaN(NewText_TextBox.Text))
                        {
                                MessageBox.Show("Numbers only");
                                return;
                        }
                        else if (NewText_TextBox.Text == "")
                        {
                                updatedText = "-1";     //if empty, then the user wanted to remove the data
                                this.Close();
                        }
                        else if (NewText_TextBox.Text[0] == '-')
                        {
                                MessageBox.Show("Sugar and Units can never be a negative value");
                                return;
                        }
                        else
                        {
                                updatedText = NewText_TextBox.Text;
                                this.Close();
                        }
                }

                private void NewText_TextBox_TextChanged(object sender, EventArgs e)
                {       
                        //do ntohing for v2.0, will check if text is valid on confirm
                        return;

                        string theText = NewText_TextBox.Text;

                        //if the textbox is empty
                        if (theText.Length == 0)
                        {
                                return;
                        }
                        
                        //if the user entered more than 4 digits, then dont add it. More than 9,999 sugar is impossible
                        if (theText.Length > 4)
                        {
                                NewText_TextBox.Text = theText.Remove(4, 1);
                        }

                        //else if there is only one character
                        else if (theText.Length == 1)
                        {
                                //if that character is not a number, remove it
                                if (theText[0] < '0' || theText[0] > '9')
                                {
                                        NewText_TextBox.Text = theText.Remove(theText.Length - 1, 1);
                                }
                        }

                        //else if the newest character is not a number, remove it
                        else if (theText[theText.Length - 1] < '0' || theText[theText.Length - 1] > '9')
                        {
                                NewText_TextBox.Text = theText.Remove(theText.Length - 1, 1);
                        }

                        //update the textbox
                        NewText_TextBox.Select(NewText_TextBox.Text.Length, 0);
                }

                private void EditText_FormClosing(object sender, FormClosingEventArgs e)
                {
                        if (updatedText != "")
                        {
                                ((Label)textEdited).Text = "a";
                                ((Label)textEdited).Text = updatedText;
                        }
                        else
                        {
                                ((Label)textEdited).Text = "a";
                                ((Label)textEdited).Text = "-1";
                        }
                }

                private void NewText_TextBox_KeyDown(object sender, KeyEventArgs e)
                {
                        //if the escape key was pressed, then close the form
                        if (e.KeyCode == Keys.Escape)
                        {
                                this.Close();
                        }
                }

                private void EditText_KeyDown(object sender, KeyEventArgs e)
                {

                }
        }
}
