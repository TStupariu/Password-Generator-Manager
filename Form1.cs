using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
        Segment for initializing different global variables
        Variables initialised:
        *** the string for the final password
        *** the alphabet
        *** the modified alphabet will all its equivalences
        */
        string FinalPassword = "";
        string Alphabet = "ieuaoctvdbgsrnlpxmfjhkqywz";
        string MyAlphabet="oaueigbdvtclnrsxpfmjkhyqzw";
        
      
        private void bEXIT_Click(object sender, EventArgs e)
        //function used for exiting the application
        {
            this.Close();
        }

        int FindIndexOfCharInAlphabet(char c,string alphabet)
        /*
        function that returns the index in the alphabet string of a specified character
        Input - a character c,a string alphabet
        Output - the ID in the alphabet string of a character
        */
        {
            int index = -1;     // if the character is not found the function returns the value -1
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    index = i;
                }
                  
            }
            return index;
        }

        string ConvertToMy(string orig_text)
        /*
        function that converts a string to the modified alphabet
        Input - a string
        Output - the conversion of the string
        */
        {
            string end_text = "";
            int i = 0;
            Boolean ConvertKey = false;
            while (i < orig_text.Length)
            {
                if (orig_text[i] == '*')    // * marks the start or end of a conversion
                {
                    ConvertKey = !ConvertKey;
                    i++;
                }
                else
                {
                    if (ConvertKey == true)
                    {
                        int ind = FindIndexOfCharInAlphabet(orig_text[i], MyAlphabet);
                        if (ind == -1)
                        {
                            char letter = char.ToLower(orig_text[i]);
                            ind = FindIndexOfCharInAlphabet(letter, MyAlphabet);    //check if both upper case or lowercase are convertable
                            if (ind == -1)
                            {
                                end_text = end_text + orig_text[i];
                            }
                            else
                            {
                                letter = char.ToUpper(Alphabet[ind]);
                                end_text = end_text + letter;
                            }
                        }
                        else
                        {
                            end_text = end_text + Alphabet[ind];
                        }
                    }
                    else
                    {
                        end_text = end_text + orig_text[i];
                    }
                    i++;
                }
            }
            return end_text;
        }

        string ConvertFromMy(string orig_text)
        /*
        function that converts a string to the modified alphabet
        Input - a string
        Output - the conversion of the string
        */
        {
            string end_text = "";
            int i = 0;
            Boolean ConvertKey = false;
            while (i < orig_text.Length)
            {
                if (orig_text[i] == '*')    // * marks the start or end of a conversion
                {
                    ConvertKey = !ConvertKey;
                    i++;
                }
                else
                {
                    if (ConvertKey == true)
                    {
                        int ind = FindIndexOfCharInAlphabet(orig_text[i], Alphabet);
                        if (ind == -1)
                        {
                            char letter = char.ToLower(orig_text[i]);
                            ind = FindIndexOfCharInAlphabet(letter, Alphabet);    //check if both upper case or lowercase are convertable
                            if (ind == -1)
                            {
                                end_text = end_text + orig_text[i];
                            }
                            else
                            {
                                letter = char.ToUpper(MyAlphabet[ind]);
                                end_text = end_text + letter;
                            }
                        }
                        else
                        {
                            end_text = end_text + MyAlphabet[ind];
                        }
                    }
                    else
                    {
                        end_text = end_text + orig_text[i];
                    }
                    i++;
                }
            }
            return end_text;
        }

        private void bGenerate_Click(object sender, EventArgs e)
        /*
        CLICK BUTTON : GENERATE
        */
        {
            string string_1 = textBox.Text;
            FinalPassword = ConvertToMy(string_1);
            labelResult.Text = FinalPassword;
        }

        private void bClipboard_Click(object sender, EventArgs e)
            /*
            function that copies the generated password to the clipboard
            it also displays a message of confirmation that the user has to click OK
            */
        {
            if (FinalPassword != "")
            {
                Clipboard.SetText(FinalPassword);
                MessageBox.Show("Your password has been succesfully copied.\nPress CTRL + V to paste it");
            }
            else
                MessageBox.Show("Can not copy an empty field of text");
        }

        private void bManager_Click(object sender, EventArgs e)
        {
            LogIN FormManager = new LogIN();
            FormManager.Show();
        }
    }
}
