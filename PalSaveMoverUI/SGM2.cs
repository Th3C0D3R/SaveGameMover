using SaveGameMover.CustomControls;
using SaveGameMover.DataControl;
using System;
using System.Windows.Forms;
using static SaveGameMoverUI.CustomControls.Prompt;

namespace SaveGameMover
{
    public partial class SGM2 : Form
    {
        private readonly SaveDataManager sdm = new SaveDataManager();
        private readonly SaveData currentSaveData;
        private bool SourceToDest = true;
        private string password = "";

        public SGM2()
        {
            InitializeComponent();
        }

        private void SGM2_Load(object sender, EventArgs e)
        {
            bool firstRun = sdm.IsFirstRun();
            if (firstRun)
            {
                password = ShowInputDialog("Enter the password to encrypt your data ins the future.\n\nDO NOT LOOSE IT!\nLoosing your password = loosing the data!", "Enter Password");
            }
            else
            {
                password = ShowInputDialog("Enter the password to decrypt your data\nIf you lost it, there is no way in recovering your data!", "Enter Password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            if (firstRun)
            {
                sdm.SaveAllToFile(password);
            }
            else
            {
                sdm.ReadAllFromFile(password);
            }

            if(sdm.SaveData.Count > 0)
            {
                btnLoadSave.Enabled = true;
            }
        }

        private void BtnSwitch_Click(object sender, EventArgs e)
        {
            if(currentSaveData.SourcePath.Length > 0 && currentSaveData.DestinationPath.Length > 0)
            {
                SourceToDest = !SourceToDest;
            }
        }

        private void BtnCreateSave_Click(object sender, EventArgs e)
        {
            FrmCreateSave dialog = new FrmCreateSave();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sdm.AddSaveData(dialog.source, dialog.destination, dialog.gamename);
                sdm.SaveAllToFile(password);
            }
        }
    }
}
