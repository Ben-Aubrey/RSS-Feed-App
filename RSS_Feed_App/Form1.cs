using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.ServiceModel.Syndication;

namespace RSS_Feed_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create XML reader
                XmlReader FD_readXml = XmlReader.Create(textBox1.Text);
                SyndicationFeed FD_feed = SyndicationFeed.Load(FD_readXml);  // Load it with the feed

                // Create TabPage with feed title
                TabPage FD_tab = new TabPage(FD_feed.Title.Text);

                // Add TabPage to TabContol
                tabControl1.TabPages.Add(FD_tab);

                // Create new ListBox Object
                ListBox FD_list = new ListBox();

                // Add ListBox(Feed) to control
                FD_tab.Controls.Add( FD_list );

                // Change the docking appearance - Make it fill the screen
                FD_list.Dock = DockStyle.Fill;

                // Add Horizontal Scrollbar to Feed List
                FD_list.HorizontalScrollbar = true;

                // Add items in ListBox
                foreach (SyndicationItem FD_item in FD_feed.Items)
                {
                    // Summarise Feed
                    string summary = FD_item.Summary.Text;
                    bool running = true;

                    string fix_summary = "";
                    foreach (char feedCharacter in summary)
                    {
                        if (feedCharacter != '<' && running)
                        {
                            fix_summary = fix_summary + feedCharacter;
                        }
                        else
                        {
                            running = false;
                        }
                    }

                    // Loops through each character



                    FD_list.Items.Add(FD_item.Title.Text);
                    FD_list.Items.Add(fix_summary);
                    FD_list.Items.Add("------------");
                }
            }
            catch
            {

            }
        }
    }
}
