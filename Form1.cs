using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate("www.google.com");
        }

        private void textBox1_TextChanged(object sender,EventArgs e)
        {
            
            
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer s = new SpeechSynthesizer();
            Choices list = new Choices();
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            list.Add(new String[] { "google.com", "yahoo.com","vtop.vit.ac.in","youtube.com" });
            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += button5_Click;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }
      
        private void button5_Click(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            webBrowser.Navigate(r);
        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            webBrowser.Navigate(e.Result.Text);
            textBox1.Text = e.Result.Text;
           

        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(textBox1.Text);
            btnDisable.Enabled = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.webBrowser.Navigate("http://www.google.com/search?q=" + searchBox.Text);
        }
    }
}
