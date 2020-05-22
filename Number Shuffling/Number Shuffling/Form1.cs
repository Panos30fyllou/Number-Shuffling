using System;
using System.Collections;
using System.Windows.Forms;

namespace Number_Shuffling
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();                       //For some reason, this doesn't seem to work at all. Go to MouseDown function for a small fix
            richTextBox1.Clear();
            int.TryParse(textBox1.Text, out int n); //The number typed in the TextBox is parsed to an integer n
            textBox2.AppendText("Process Completed! Elapsed Time: " + process(DateTime.Now, n));
        }
        private TimeSpan process(DateTime st, int n)//This function calculates, shuffles and prints the numbers from 1 to n to the RichTextBox, and returns its elapsed time
        {
            ArrayList list = new ArrayList();       //In this ArrayList, the numbers from 1 to the number n given as a parameter will be stored            
            for (int i = 1; i <= n; i++)
                list.Add(i);
            while (list.Count > 0){                 //We access the ArrayList, until there are no numbers left in it
                int randi = r.Next(0, list.Count);  //A random index is generated. This index varies from 0 to the number of elements contained in the ArrayList
                richTextBox1.AppendText(list[randi].ToString() + "\n");//A String representation of the number stored in the ArrayList indexed by the number we randomly generated before, is appended to the RichTextBox
                list.RemoveAt(randi);               //Then, this number is removed from the ArrayList, to ensure that it will not show up again in our RichTextBox.
                list.TrimToSize();                  //The ArrayList is Trimmed so that there are no null elements
            }
            return DateTime.Now.Subtract(st);       //The elapsed time of the proccess is calculated using the start time given as a parameter and the current time
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Select();                      //Every time the Form is loaded, it focuses on the TextBox1 so that the user can enter an integer
        }
        private void button1_MouseDown(object sender, MouseEventArgs e) {   //The following function works well on cleaning textBox2's text when the button1 is clicked using the mouse
            textBox2.Clear();
        }

    }
}