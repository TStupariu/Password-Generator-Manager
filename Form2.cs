using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;    
using System.Security.Cryptography;
using System.Security;

namespace PasswordGenerator
{
    public partial class Form2 : Form
    {

        //GLOBAL VARIABLES
        int CurrentID = 0;
        Identity CurrentIdentity = new Identity();
        PWDList _repo = new PWDList();
        string textFile;    
        //END GLOBAL VARIABLES



        public Form2()
        {
            InitializeComponent();
        }


        #region Encryption

        string passPhrase = "Pasword";        // can be any string
        string saltValue = "sALtValue";        // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 7;                  // can be any number
        string initVector = "~1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;                // can be 192 or 128

        private string Encrypt(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            byte[] rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }

        private string Decrypt(string data)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.initVector);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(this.saltValue);
            byte[] buffer = Convert.FromBase64String(data);
            byte[] rgbKey = new PasswordDeriveBytes(this.passPhrase, rgbSalt, this.hashAlgorithm, this.passwordIterations).GetBytes(this.keySize / 8);
            RijndaelManaged managed = new RijndaelManaged();
            managed.Mode = CipherMode.CBC;
            ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            byte[] buffer5 = new byte[buffer.Length];
            int count = stream2.Read(buffer5, 0, buffer5.Length);
            stream.Close();
            stream2.Close();
            return Encoding.UTF8.GetString(buffer5, 0, count);
        }
        #endregion



        private void saveToFile()
        {
            File.Decrypt(this.textFile);
            StreamWriter file = new StreamWriter(this.textFile);
            List<Identity> passwords = this._repo.getAll();   
            foreach (Identity id in passwords)
            {
                string line = "";                 
                line = line + id.getID().ToString() + ";" + id.getWebsite() + ";" + id.getUsername() + ";" + id.getPassword();
                line = this.Encrypt(line);
                file.WriteLine(line);
            }         
            file.Close();
            File.Encrypt(this.textFile);
        }
            

        public void DisplayAnIdentity(Identity DisplayIdentity)
        {
            //FUNCTION THAT DISPLAYS THE ELEMENTS OF AN IDENTITY IN THE REQUIRED TEXT BOXES

            textBoxID.Text = DisplayIdentity.getID().ToString();
            textBoxWebsite.Text = DisplayIdentity.getWebsite();
            textBoxUsername.Text = DisplayIdentity.getUsername();
            textBoxPassword.Text = DisplayIdentity.getPassword();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //
            //  LOAD FROM MEMORY
            //                    
            string[] identities;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
                this.textFile = "INPUT2.txt";
            File.Decrypt(this.textFile);
            StreamReader sr = new StreamReader("INPUT2.txt");
            string line = sr.ReadLine();
                while (line != null)
                {
                    line = this.Decrypt(line);
                    identities = line.Split(';');     
                    int ID = Convert.ToInt16(identities[0]);
                    string website = identities[1];
                    string username = identities[2];
                    string password = identities[3];
                    Identity NIdentity = new Identity();
                    NIdentity.Init_Identity(ID, website, username, password);
                    _repo.addElement(NIdentity);
                    //listBox1.Items.Add(_repo.addToListBox(NIdentity));
                    line = sr.ReadLine();
                }
                sr.Close();
            //}

            populateListBox();

            textBoxID.Enabled = false;
            File.Encrypt(this.textFile);
        }

        public void populateListBox()
        {
            listBox1.Items.Clear();
            List<Identity> temp = new List<Identity>();
            temp = _repo.getAll();            
            foreach (Identity element in temp)
            {
                listBox1.Items.Add(_repo.addToListBox(element));
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //int NID = Convert.ToInt32(textBoxID.Text);
                int NID = _repo.generateValidID();
                string NWebsite = textBoxWebsite.Text;
                string NUsername = textBoxUsername.Text;
                string NPassword = textBoxPassword.Text;
                Identity _identity = new Identity();
                _identity.Init_Identity(NID, NWebsite, NUsername, NPassword);
                _repo.addElement(_identity);
                string ListElement = NID.ToString() + ".  " + NWebsite;
                populateListBox();
            }
            catch
            {
                MessageBox.Show("The ID is not valid !");
            }
            Clear();
            this.saveToFile();
        }    
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            try
            {
                string SelectedWebsite = listBox1.SelectedItem.ToString();

                string s = "";
                foreach (char c in SelectedWebsite)
                {
                    if ("0123456789".Contains(c))
                        s = s + c;
                }

                int idx = Convert.ToInt16(s);

                Identity NewCurrentIdentity = new Identity();
                NewCurrentIdentity = _repo.getIdentityWithID(idx);
                CurrentID = NewCurrentIdentity.getID();
                DisplayAnIdentity(NewCurrentIdentity);
            }
            catch
            { }      
        }      

        private void bRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(textBoxID.Text);                                    
                _repo.removeElement(ID);
            }
            catch
            {
                MessageBox.Show("ID is not valid");
            }

            populateListBox();
            Clear();
            this.saveToFile();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            textBoxID.Text = "";
            textBoxUsername.Text = "";
            textBoxWebsite.Text = "";
            textBoxPassword.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }
    }
}
