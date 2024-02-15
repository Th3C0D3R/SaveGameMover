using Microsoft.WindowsAPICodePack.Dialogs;
using SaveGameMoverData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SaveGameMoverData.Extensions;
using static SaveGameMoverUI.CustomControls.Prompt;

namespace SaveGameMoverUI
{
    public partial class FrmSaver : Form
    {

        #region "Properties" 

        bool SaveToExtern
        {
            get
            {
                return UserData.IsSaveMode;
            }
            set
            {
                UserData.IsSaveMode = value;
                lblCurrentMode.Text = lblCurrentMode.Tag.ToString().Replace("#Mode#", SaveToExtern ? "Save to Extern" : "Save to Local");
                cbSwitchMode.Text = cbSwitchMode.Tag.ToString().Replace("#Mode#", SaveToExtern ? "Save to Local" : "Save to Extern");
                (txbSource.Text, txbDestination.Text) = (txbDestination.Text, txbSource.Text);
            }
        }
        private Profile CurrentProfile = default;
        readonly ObservableCollection<string> log = new ObservableCollection<string>();
        readonly string BackupRootLocation = Path.GetDirectoryName(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath);

        #endregion

        public FrmSaver()
        {
            InitializeComponent();
        }

        #region Events
        private void Profiles_ListChanged(object sender, ListChangedEventArgs e)
        {
            UserData.SaveProfiles();
        }
        private void BtnSourceOFD_Click(object sender, EventArgs e)
        {
            string folderLocation = OpenFolderDialog(true);

            txbSource.Text = folderLocation;
            if (!string.IsNullOrWhiteSpace(CurrentProfile.Name))
            {
                if (SaveToExtern)
                {
                    CurrentProfile.LocalPath = folderLocation;
                }
                else
                {
                    CurrentProfile.RemotePath = folderLocation;
                }
            }
        }
        private void BtnCreateProfil_Click(object sender, EventArgs e)
        {
            CreateProfile();
        }
        private void CbProfile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CurrentProfile = (Profile)cbProfile.SelectedItem;
            if (SaveToExtern)
            {
                txbSource.Text = CurrentProfile.LocalPath;
                txbDestination.Text = CurrentProfile.RemotePath;
            }
            else
            {
                txbDestination.Text = CurrentProfile.LocalPath;
                txbSource.Text = CurrentProfile.RemotePath;
            }

            UserData.LastUsedProfile = CurrentProfile.Guid;
        }
        private void BtnDestOFD_Click(object sender, EventArgs e)
        {
            string folderLocation = OpenFolderDialog(true);

            txbDestination.Text = folderLocation;
            if (!string.IsNullOrWhiteSpace(CurrentProfile.Name))
            {
                if (SaveToExtern)
                {
                    CurrentProfile.RemotePath = folderLocation;
                }
                else
                {
                    CurrentProfile.LocalPath = folderLocation;
                }
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmSaver_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveProfiles();
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {

            bool genLog = cbGenerateLog.Checked;
            bool makeBackup = cbCreateBackup.Checked;
            bool error = false;
            List<string> sourceFiles, destinationFiles;
            string sourcePath, destinationPath;
            log.CollectionChanged -= Log_CollectionChanged;
            log.CollectionChanged += Log_CollectionChanged;

            if (string.IsNullOrWhiteSpace(CurrentProfile.LocalPath))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(CurrentProfile.RemotePath))
            {
                return;
            }

            log.Clear();
            lbOutput.Items.Clear();

            Application.DoEvents();
            (sourcePath, destinationPath) = GetPathOrdered();
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }
            Application.DoEvents();
            (sourceFiles, destinationFiles) = GetFilesByPath();
            Application.DoEvents();

            var parentDest = Directory.GetParent(destinationPath);
            var parentSrc = Directory.GetParent(sourcePath);

            log.Add($"========== Process started ==========");
            log.Add($"");
            log.Add($"Source Location File Count: {sourceFiles.Count}");
            log.Add($"Local Directory: {CurrentProfile.LocalPath}");
            log.Add($"Remote Directory: {CurrentProfile.RemotePath}");
            Application.DoEvents();

            log.Add($"Create Backup: {cbCreateBackup.Checked}");
            log.Add($"Delete Destination: {cbDeleteDest.Checked}");
            log.Add($"Generate Log: {cbGenerateLog.Checked}");
            log.Add($"Dry Run: {cbDryRun.Checked}");
            Application.DoEvents();

            log.Add($"");
            log.Add($"");
            if (cbCreateBackup.Checked)
            {
                Application.DoEvents();
                DoBackup(destinationPath, destinationFiles, parentDest);
                Application.DoEvents();
            }

            if (cbDeleteDest.Checked)
            {
                Application.DoEvents();
                DeleteDest(destinationPath);
                Application.DoEvents();
            }

            Application.DoEvents();
            CopyFiles(sourceFiles, sourcePath, destinationPath, parentSrc, parentDest, ref error);
            Application.DoEvents();

            if (error)
            {
                Application.DoEvents();
                Rollback(destinationPath);
                Application.DoEvents();
            }

            if (cbGenerateLog.Checked)
            {
                Application.DoEvents();
                GenerateLog();
                Application.DoEvents();
            }
        }
        private void CbDeleteDest_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeleteDest.Checked)
            {
                cbCreateBackup.Checked = cbDeleteDest.Checked;
            }
            cbCreateBackup.Enabled = !cbDeleteDest.Checked;

            CheckedChanged(sender, e);
        }
        private void Log_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (string line in e.NewItems)
                {
                    lbOutput.Items.Add(line);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                lbOutput.Items[e.OldStartingIndex] = e.NewItems[0];
            }
            lbOutput.TopIndex = lbOutput.Items.Count - 1;
        }
        private void CurrentProfile_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (SaveToExtern)
            {
                txbSource.Text = CurrentProfile.LocalPath;
                txbDestination.Text = CurrentProfile.RemotePath;
            }
            else
            {
                txbSource.Text = CurrentProfile.RemotePath;
                txbDestination.Text = CurrentProfile.LocalPath;
            }
            SaveProfiles();
        }
        private void FrmSaver_Load(object sender, EventArgs e)
        {
            lblCurrentMode.Text = lblCurrentMode.Tag.ToString().Replace("#Mode#", SaveToExtern ? "Save to Extern" : "Save to Local");
            cbSwitchMode.Text = cbSwitchMode.Tag.ToString().Replace("#Mode#", SaveToExtern ? "Save to Local" : "Save to Extern");

            UserData.LoadProfiles();

            if (UserData.Profiles.Count == 0)
            {
                if (CreateProfile())
                {
                    CurrentProfile = UserData.Profiles.Last();
                }
                else
                {
                    return;
                }

                UserData.SaveProfiles();
            }

            UserData.Profiles.ListChanged -= Profiles_ListChanged;

            UserData.Profiles.ListChanged += Profiles_ListChanged;

            var bsProfiles = new BindingSource
            {
                DataSource = UserData.Profiles
            };
            cbProfile.DataSource = bsProfiles.DataSource;
            cbProfile.DisplayMember = "Name";
            cbProfile.ValueMember = "Guid";
            cbProfile.Refresh();
            cbProfile.Update();

            if (UserData.Profiles.Any(p => p.Guid == UserData.LastUsedProfile))
            {
                Profile lastProf = UserData.Profiles.First(p => p.Guid == UserData.LastUsedProfile);
                cbProfile.SelectedItem = lastProf;
                CurrentProfile = lastProf;
                CurrentProfile_PropertyChanged(null, null);
            }

            CurrentProfile.PropertyChanged -= CurrentProfile_PropertyChanged;
            CurrentProfile.PropertyChanged += CurrentProfile_PropertyChanged;

        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            UserData.SetProperty(cb.Name, cb.Checked);
        }
        private void Checkbox_Paint(object sender, PaintEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.Checked = UserData.GetProperty<bool>(cb.Name);
        }
        #endregion

        #region Methods
        private (List<string>, List<string>) GetFilesByPath()
        {
            if (SaveToExtern)
            {
                return (Directory.GetFiles(CurrentProfile.LocalPath, "*.*", SearchOption.AllDirectories).ToList(), Directory.GetFiles(CurrentProfile.RemotePath, "*.*", SearchOption.AllDirectories).ToList());
            }
            else
            {
                return (Directory.GetFiles(CurrentProfile.RemotePath, "*.*", SearchOption.AllDirectories).ToList(), Directory.GetFiles(CurrentProfile.LocalPath, "*.*", SearchOption.AllDirectories).ToList());
            }
        }
        private (string, string) GetPathOrdered()
        {
            if (SaveToExtern)
            {
                return (CurrentProfile.LocalPath, CurrentProfile.RemotePath);
            }
            else
            {
                return (CurrentProfile.RemotePath, CurrentProfile.LocalPath);
            }
        }
        bool CreateProfile()
        {
            string name = ShowInputDialog(this, "Enter new Profilename", "Create new Profile");
            if (!string.IsNullOrWhiteSpace(name))
            {
                Profile p = new Profile()
                {
                    Name = name,
                    Guid = Guid.NewGuid()
                };
                UserData.Profiles.Add(p);
                cbProfile.Refresh();
                cbProfile.Update();

                cbProfile.SelectedItem = p;
                ClearControls();
                return true;
            }
            return false;
        }
        string OpenFolderDialog(bool Source)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                ShowHiddenItems = true
            };

            if (SaveToExtern && !Source)
            {
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            }
            else
            {
                string PalSave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pal", "Saved", "SaveGames");
                dialog.InitialDirectory = Directory.Exists(PalSave) ? PalSave : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                return "";
            }

            return dialog.FileName;
        }
        private void SwitchMode(object sender, EventArgs e)
        {
            SaveToExtern = !SaveToExtern;
        }
        private void SaveProfiles()
        {
            if (SaveToExtern)
            {
                CurrentProfile.LocalPath = txbSource.Text;
                CurrentProfile.RemotePath = txbDestination.Text;
            }
            else
            {
                CurrentProfile.RemotePath = txbSource.Text;
                CurrentProfile.LocalPath = txbDestination.Text;
            }

            var found = UserData.Profiles.FirstOrDefault(p => p.Guid == CurrentProfile.Guid);
            if (found.Guid == CurrentProfile.Guid)
            {
                found = CurrentProfile;
            }
            UserData.LastUsedProfile = CurrentProfile.Guid;
            UserData.SaveProfiles();
        }
        private void Rollback(string destinationPath)
        {
            if (!cbCreateBackup.Checked)
            {
                return;
            }

            var parent = Directory.GetParent(destinationPath);
            var DictName = Path.GetFileName(destinationPath);
            var backupDir = Path.Combine(parent.FullName, "backup_sgm", DictName);
            var backupFiles = Directory.GetFiles(backupDir, "*.*", SearchOption.AllDirectories);
            var parentSrc = Directory.GetParent(backupDir);

            if (Directory.Exists(backupDir) && backupFiles.Length > 0)
            {
                foreach (var file in backupFiles)
                {
                    Application.DoEvents();
                    string sourceRootFile = file.Replace(backupDir, "");
                    string sourceRootFolder = Path.GetDirectoryName(sourceRootFile);
                    string destFile = Path.Combine(destinationPath, sourceRootFolder.Substring(1), Path.GetFileName(file));

                    if (!cbDryRun.Checked)
                    {
                        Directory.CreateDirectory(destFile);
                    }

                    try
                    {
                        log.Add($"[\u2720] Rollback File in progress: {file.Replace(parentSrc.FullName, "")}");
                        if (!cbDryRun.Checked)
                        {
                            File.Copy(file, destFile);
                        }

                        log.Change(log.Count - 1, $"[\u2713] Rollback File fnished: {destFile.Replace(parent.FullName, "")}");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        DialogResult dlg = MessageBox.Show(this, $"You are not authorized to:\n" +
                            $"- Copy the file {sourceRootFile}\n" +
                            $"- Access the destination Folder {Path.Combine(destinationPath, sourceRootFolder.Substring(1))}\n\n" +
                            $"Try run the Application as Administrator!\n\nContinue?", "Unauthorized Access Violation", MessageBoxButtons.YesNo);
                        log.Add($"Unable to copy {sourceRootFile} to {destFile.Replace(parent.FullName, "")}");

                        if (dlg != DialogResult.Yes)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        DialogResult dlg = MessageBox.Show(this, $"Exception catched:\n\n{ex}\n\nStopping Progress...", $"{ex.GetType()} - Oopsie", MessageBoxButtons.OK);

                        if (dlg == DialogResult.OK)
                        {
                            break;
                        }
                    }
                    Application.DoEvents();
                }
                log.Add($"Rollback finished!");
            }
        }
        private void DoBackup(string destinationPath, List<string> destinationFiles, DirectoryInfo parentDest)
        {
            if (destinationFiles.Count > 0)
            {
                log.Add($"Creating Backup...");
                var backupDir = Path.Combine(GetBackupDir(parentDest.FullName), Path.GetFileName(destinationPath));
                if (Directory.Exists(backupDir))
                {
                    try
                    {
                        if (!cbDryRun.Checked)
                        {
                            Directory.Delete(backupDir, true);
                        }
                    }
                    catch (Exception) { }
                }
                if (!cbDryRun.Checked)
                {
                    Directory.CreateDirectory(backupDir);
                }

                foreach (var dst in destinationFiles)
                {
                    Application.DoEvents();
                    string destRootFile = dst.Replace(destinationPath, "");
                    string destRootFolder = Path.GetDirectoryName(destRootFile);
                    string destFile = Path.Combine(backupDir, destRootFolder.Substring(1), Path.GetFileName(dst));

                    if (!cbDryRun.Checked)
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                    }

                    log.Add($"[\u2720] Backup in progress: {dst.Replace(BackupRootLocation, "")}");
                    if (!cbDryRun.Checked)
                    {
                        File.Copy(dst, destFile, true);
                    }

                    log.Change(log.Count - 1, $"[\u2713] Backup finished: {destFile.Replace(BackupRootLocation, "")}");
                    Application.DoEvents();
                }
                log.Add($"Backup created at: {backupDir}");
                log.Add($"");
                log.Add($"");
            }
        }
        private void DeleteDest(string destinationPath)
        {
            log.Add($"Deleting Destination Path {destinationPath}");
            try
            {
                if (!cbDryRun.Checked)
                {
                    Directory.Delete(destinationPath, true);
                }

                log.Change(log.Count - 1, $"Deleting Destination Path {destinationPath} => Success");
            }
            catch (Exception)
            {
                log.Change(log.Count - 1, $"Deleting Destination Path {destinationPath} => Failed");
            }
            log.Add($"");
            log.Add($"");
        }
        private void CopyFiles(List<string> sourceFiles, string sourcePath, string destinationPath, DirectoryInfo parentSrc, DirectoryInfo parentDest, ref bool error)
        {
            foreach (var file in sourceFiles)
            {
                Application.DoEvents();
                string sourceRootFile = file.Replace(sourcePath, "");
                string sourceRootFolder = Path.GetDirectoryName(sourceRootFile);
                string destFile = Path.Combine(destinationPath, sourceRootFolder.Substring(1), Path.GetFileName(file));

                if (!cbDryRun.Checked)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                }

                try
                {
                    log.Add($"[\u2720] Copy in progress: {file.Replace(parentSrc.FullName, "")}");
                    if (!cbDryRun.Checked)
                    {
                        File.Copy(file, destFile);
                    }

                    log.Change(log.Count - 1, $"[\u2713] Copy fnished: {destFile.Replace(parentDest.FullName, "")}");
                }
                catch (UnauthorizedAccessException)
                {
                    DialogResult dlg = MessageBox.Show(this, $"You are not authorized to:\n" +
                        $"- Copy the file {sourceRootFile}\n" +
                        $"- Access the destination Folder {Path.Combine(destinationPath, sourceRootFolder.Substring(1))}\n\n" +
                        $"Try run the Application as Administrator!\n\nContinue?", "Unauthorized Access Violation", MessageBoxButtons.YesNo);
                    log.Add($"Unable to copy {sourceRootFile} to {destFile.Replace(parentDest.FullName, "")}");

                    if (dlg != DialogResult.Yes) { error = true; break; }
                }
                catch (Exception ex)
                {
                    DialogResult dlg = MessageBox.Show(this, $"Exception catched:\n\n{ex}\n\nStopping Progress...", $"{ex.GetType()} - Oopsie", MessageBoxButtons.OK);

                    if (dlg == DialogResult.OK)
                    {
                        error = true;
                        break;
                    }
                }
                Application.DoEvents();
            }
        }
        private void GenerateLog()
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string logDir = Path.Combine(exeDir, "logs");
            string logFile = Path.Combine(logDir, "log.txt");
            var logDirInfo = Directory.CreateDirectory(logDir);
            if (File.Exists(logFile))
            {
                FileInfo logFileInfo = new FileInfo(logFile);
                var dirInfo = Directory.CreateDirectory(Path.Combine(logDir, $"log_backup"));
                try { File.Move(logFile, Path.Combine(dirInfo.FullName, $"log_{logFileInfo.CreationTime.ToString().Replace(".", "-").Replace("_", "")}.txt")); }
                catch (Exception) { }
            }

            try { File.WriteAllLines(logFile, log.ToArray()); }
            catch (Exception) { }

            log.Add($"Log generated at: {logDirInfo.Parent.Parent.FullName}");
        }
        private string GetBackupDir(string parentDirName)
        {
            return Path.Combine(BackupRootLocation, "backup_sgm", SaveToExtern ? "extern" : "local", Path.GetFileName(parentDirName));
        }
        private void ClearControls()
        {
            txbDestination.Clear();
            txbSource.Clear();
            cbCreateBackup.Checked = false;
            cbDeleteDest.Checked = false;
            cbDryRun.Checked = false;
            cbGenerateLog.Checked = false;

        }
        #endregion

    }
}