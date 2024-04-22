using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveGameMover.CustomControls
{
    public partial class FrmCreateSave : Form
    {
        public string source = "";
        public string destination = "";
        public string gamename = "";
        public FrmCreateSave()
        {
            InitializeComponent();
        }

        private void BtnSourceOFD_Click(object sender, EventArgs e)
        {
            source = OpenFileDialog();
            txbSource.Text = source;
        }

        private void BtnDestOFD_Click(object sender, EventArgs e)
        {
            destination = OpenFileDialog();
            txbDestination.Text = destination;
        }

        private string OpenFileDialog()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                ShowHiddenItems = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
            };

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                return "";
            }

            return dialog.FileName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        { 
            gamename = txbGamename.Text;
            DialogResult = DialogResult.OK;
            Close();

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
