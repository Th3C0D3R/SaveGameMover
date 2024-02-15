using System.Windows.Forms;

namespace SaveGameMoverUI.CustomControls
{
    public static class Prompt
    {
        public static string ShowInputDialog(string text, string caption)
        {
            return ShowInputDialog(null, text, caption);
        }
        public static string ShowInputDialog(Form parent, string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                Owner = parent,
                StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };
            TextBox textBox = new TextBox() { Left = 50, Top = 40, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}