
using SaveGameMover.CustomControls;
using SaveGameMover.DataControl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CopyEX = CopiEx.CopiEx;
using static SaveGameMoverUI.CustomControls.Prompt;
using System.Threading.Tasks;
using static CopiEx.CopiEx;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Markup;


namespace SaveGameMover
{
	public partial class SGM2 : Form
	{
		private readonly SaveDataManager sdm = new();
		private CopyEX copiEx;
		private SaveData currentSaveData = default;
		private List<KeyValuePair<string, DiffReason>> DiffList = [];
		private bool SourceToDest = true;
		private string password = "";
		private bool Debug
		{
			get
			{
				return true;
				//return false;
			}
		}

		public SGM2()
		{
			InitializeComponent();
			btnCopy.Enabled = false;
			btnLoadSave.Enabled = false;
			btnSwitch.Enabled = false;

			pbCurrentFileIndex.DisplayStyle = ProgressBarDisplayText.CustomText;
			pbCurrentFileIndex.Color = Brushes.Black;

		}

		private void SGM2_Load(object sender, EventArgs e)
		{
			bool firstRun = sdm.IsFirstRun();
		loopNoPw:
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
				goto loopNoPw;
			}

			if (firstRun)
			{
				sdm.SaveAllToFile(password);
			}
			else
			{
				sdm.ReadAllFromFile(password);
			}

			if (sdm.SaveData.Count > 0)
			{
				btnLoadSave.Enabled = true;
				cbSave.Items.Clear();
				cbSave.Items.AddRange([.. sdm.SaveData]);
			}
			else if (!firstRun && (new FileInfo("data.dat")).Length > 0)
			{
				MessageBox.Show("It looks like you Password is wrong or it is a corrupt file!");
				goto loopNoPw;
			}
		}
		private void BtnSwitch_Click(object sender, EventArgs e)
		{
			if (currentSaveData.SourcePath.Length > 0 && currentSaveData.DestinationPath.Length > 0)
			{
				SourceToDest = !SourceToDest;
				copiEx.SwitchDirection();
				BtnLoadSave_Click(sender, e);
			}
		}
		private void BtnCreateSave_Click(object sender, EventArgs e)
		{
			FrmCreateSave dialog = new();
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				sdm.AddSaveData(dialog.source, dialog.destination, dialog.gamename);
				sdm.SaveAllToFile(password);
				LoadSaves();
			}
		}
		private void CbSave_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnLoadSave.Enabled = false;
			btnCopy.Enabled = false;
			btnSwitch.Enabled = false;

			if (cbSave.SelectedIndex >= 0)
			{
				if (cbSave.SelectedItem is SaveData data)
				{
					currentSaveData = data;
					copiEx = new(GetPath(true), GetPath(false));
					btnLoadSave.Enabled = true;
				}
			}
		}
		private async void BtnLoadSave_Click(object sender, EventArgs e)
		{
			if (currentSaveData != default(SaveData))
			{
				lblCurrentDirection.Text = SourceToDest ? "Source -> Destination" : "Destination -> Source";
				btnLoadSave.Enabled = false;
				tvFiles.Nodes.Clear();
				copiEx.CurrentFileIndexChanged += CopiEx_CurrentFileIndexChanged;
				DiffList = await copiEx.CompareFiles();
				pbCurrentFileIndex.Value = 0;

				tvFiles.Nodes.Add(await GetTreeNodes());

				btnLoadSave.Enabled = true;
				btnCopy.Enabled = true;
				btnSwitch.Enabled = true;
			}
		}
		private void CopiEx_CurrentFileIndexChanged(object sender, int e)
		{
			pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Maximum = copiEx.TotalFiles);
			pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Value = e);
			pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.CustomText = $"Comparing Files: {e}/{copiEx.TotalFiles}");
		}
		private async Task<TreeNode> GetTreeNodes()
		{
			string sPath = GetPath(true);
			DirectoryInfo directory = new(sPath);
			if (!directory.Exists)
			{
				throw new DirectoryNotFoundException("The specified directory does not exist.");
			}
			TreeNode rootNode = new(currentSaveData.Name)
			{
				Tag = directory.FullName
			};
			Task t = Task.Factory.StartNew(() =>
			{
				pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Value = 0);
				pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Maximum = 0);
				PopulateTreeNodesDir(directory, rootNode);
			});
			await t;
			pbCurrentFileIndex.Invoke(() =>
			{
				pbCurrentFileIndex.Value = 0;
				pbCurrentFileIndex.Maximum = 0;
				pbCurrentFileIndex.CustomText = $"Idle";
			});
			return rootNode;
		}
		private void PopulateTreeNodesDir(DirectoryInfo directory, TreeNode rootNode)
		{
			var dirs = directory.GetDirectories().ToList().OrderBy(dir => dir.FullName);
			var files = directory.GetFiles().ToList().OrderBy(f => f.FullName);

			pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.CustomText = $"Loading Tree: {pbCurrentFileIndex.Value}/{pbCurrentFileIndex.Maximum}");

			pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Maximum += dirs.Count());
			foreach (var dir in dirs)
			{
				TreeNode node = new(dir.Name)
				{
					Tag = dir.FullName
				};

				var idx = DiffList.FindIndex(kv => kv.Key.Contains(dir.FullName.Substring(GetPath(true).Length + 1)));

				if (idx >= 0)
				{
					node.BackColor = Color.IndianRed;
				}

				PopulateTreeNodesDir(dir, node);
				pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Value += 1);
				rootNode.Nodes.Add(node);
			}

			pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Maximum += files.Count());
			foreach (var file in files)
			{
				var idx = DiffList.FindIndex(kv => kv.Key == file.FullName.Substring(GetPath(true).Length + 1));
				TreeNode node = new(file.Name + (idx >= 0 ? $" - ({DiffList[idx].Value.GetDescription()})" : ""))
				{
					Tag = file.FullName
				};

				if (idx >= 0)
				{
					node.BackColor = Color.IndianRed;
				}

				pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Value += 1);
				rootNode.Nodes.Add(node);
			}
		}
		private void LoadSaves()
		{
			sdm.ReadAllFromFile(password);
			if (sdm.SaveData.Count > 0)
			{
				btnLoadSave.Enabled = true;
				cbSave.Items.Clear();
				cbSave.Items.AddRange([.. sdm.SaveData]);
			}
		}
		private void TvFiles_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Nodes.Count > 0)
			{
				foreach (TreeNode node in e.Node.Nodes)
				{
					node.Checked = e.Node.Checked;
				}
			}
		}
		private async void BtnCopy_Click(object sender, EventArgs e)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				CopyRecrusive(tvFiles.Nodes[0]);
			});
			await task;

			await Task.Factory.StartNew(() =>
			{
				SetNodeGreenIfAllChildrenGreen(tvFiles.Nodes[0]);
			});
		}
		private void CopyRecrusive(TreeNode node)
		{
			foreach (TreeNode childNode in node.Nodes)
			{
				FileInfo sFileP = new(childNode.Tag.ToString());
				if (childNode.Checked && !File.GetAttributes(sFileP.FullName).HasFlag(FileAttributes.Directory))
				{
					string relativePath = sFileP.FullName.Substring(GetPath(true).Length + 1);
					FileInfo destinationFile = new(Path.Combine(GetPath(false), relativePath));
					pbCurrentFileIndex.Invoke(() => pbCurrentFileIndex.Maximum += 1);
					if (!copiEx.CopySingleFile(sFileP, destinationFile, Debug))
					{
						childNode.BackColor = Color.Red;
					}
					else
					{
						childNode.BackColor = Color.Green;
					}
				}
				else
				{
					CopyRecrusive(childNode);
				}
			}
		}
		private void SetNodeGreenIfAllChildrenGreen(TreeNode node)
		{
			if (node.Nodes.Count == 0)
			{
				return;
			}

			foreach (TreeNode childNode in node.Nodes)
			{
				SetNodeGreenIfAllChildrenGreen(childNode);
			}

			if (node.Nodes.Cast<TreeNode>().All(n => n.BackColor == Color.Green))
			{
				node.BackColor = Color.Green;
			}
		}
		private string GetPath(bool source = true)
		{
			if (SourceToDest)
			{
				return source ? currentSaveData.SourcePath : currentSaveData.DestinationPath;
			}
			else
			{
				return source ? currentSaveData.DestinationPath : currentSaveData.SourcePath;
			}
		}
	}
}