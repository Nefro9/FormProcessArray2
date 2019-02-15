using System;
using System.Windows.Forms;

namespace NamuDarbaiForm1
{
	public partial class MainForm : Form
	{
		ArrayManager ArrayM;
		FileManager  FileM;
		OrderHelper  OrderH;
		
		public MainForm()
		{
			InitializeComponent();
			
			ArrayM = new ArrayManager();
			FileM  = new FileManager();
			OrderH = new OrderHelper();
			
			label4.Hide();
		}
		
		void IlgisTextEnter(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				try {
					ArrayM.addArrayLength(ilgis.Text);
					
					masyvasElement.Enabled = true;
					ilgis.Enabled = false;
					updateCounter();
				}
				catch {
					MessageBox.Show("Prasome ivesti skaiciu nuo 1 iki 20");
				}
				
				ilgis.Text = "";
				
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
		
		void MasyvasElementTextEnter(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if(!ArrayM.isFull()) {
					
					try {
						ArrayM.addArrayElement(masyvasElement.Text);
						
						updateCounter();
					}
					catch {
						MessageBox.Show("Prasome ivesti skaiciu");
					}
					
					
				} else {
					masyvasElement.Enabled = false;
					MessageBox.Show("Masyvas pilnas");
				}
				
				masyvasElement.Text = "";
				
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}
		
		void PakartotiToolStripMenuItemClick(object sender, EventArgs e)
		{
			ArrayM = new ArrayManager();
			
			ilgis.Text = "";
			ilgis.Enabled = true;
			
			masyvasElement.Text = "";
			masyvasElement.Enabled = false;
			
			richTextBox1.Text = "";
			label3.Text = "";
			
			groupBox1.Height = 90;
			
			label4.Hide();
		}
		
		void PabaigaToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Windows.Forms.Application.Exit();
		}
		
		void updateCounter()
		{
			groupBox1.Height = 110;
			label3.Text = "Ivesta elementu: "+ArrayM.arrayFilled+"/"+ArrayM.arrayTotalLength;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			richTextBox1.Text = ArrayM.getArrayList();
		}
		
		
		void AtidarytiToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				richTextBox1.Text = FileM.readFile();
			}
			catch {
				MessageBox.Show("File "+FileM.getFileName()+" not exist");
			}
		}
		
		void ApieToolStripMenuItemClick(object sender, EventArgs e)
		{
			AboutForm About = new AboutForm();
			About.FormClosed += new FormClosedEventHandler(Other_FormClosed);
			
			this.Hide();
			About.Show();
		}
		
		void IssaugotiToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveFileForm SaveFileF = new SaveFileForm(richTextBox1.Text);
			SaveFileF.FormClosed += new FormClosedEventHandler(Other_FormClosed);
			
			this.Hide();
			SaveFileF.Show();
		}
		
		void Other_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Show();
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			DataProcess ArrayProcess = new DataProcess(ArrayM.getArray());
			
			label4.Show();
			
			if(ArrayProcess.isItemsFound()) {
				label4.Text = "Kartojantys elementai: "+ ArrayProcess.getDublicatedList();
			} else {
				label4.Text = "Kartojantys elementai: nerasta";
			}
		}
		
		void Button4Click(object sender, EventArgs e)
		{
			int[] sortedArray = OrderH.RikiuokD(ArrayM.getArray());
			ArrayM.setArray(sortedArray);
		}
		
		void Button5Click(object sender, EventArgs e)
		{
			int[] sortedArray = OrderH.RikiuokM(ArrayM.getArray());
			ArrayM.setArray(sortedArray);
		}
	}
}
