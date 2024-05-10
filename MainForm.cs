using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MedSQL_Reader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection($"Data Source={filePath};Version=3;"))
                    {
                        connection.Open();

                        string tableName = "ZKARTEIEINTRAG";
                        string query = $"SELECT [ZADDITIONALTEXT], [ZTEXT] FROM [{tableName}]";

                        SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView.DataSource = dataTable;
                        dataGridView.Columns["ZTEXT"].Width = 271;
                        dataGridView.Columns["ZADDITIONALTEXT"].Width = 271;
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"SQLite Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGridView.Columns[e.ColumnIndex].Name;
                string content = dataGridView.Rows[e.RowIndex].Cells[columnName].Value.ToString();
                panelTextFile.Controls.Clear();

                if (IsRtf(content))
                {
                    RichTextBox richTextBox = new RichTextBox();
                    richTextBox.Dock = DockStyle.Fill;
                    richTextBox.Rtf = content;
                    panelTextFile.Controls.Add(richTextBox);
                }
                else if (IsCsv(content))
                {
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;
                    textBox.Multiline = true;
                    textBox.ScrollBars = ScrollBars.Vertical;
                    textBox.ReadOnly = true;

                    // Check if the content is in ZTX format (ZTX is normally a unity thing, but I couldn't think of a different name.)
                    ZTXFormat ztxFormat = new ZTXFormat();
                    if (ztxFormat.IsValidZTX(content))
                    {
                        List<Dictionary<string, string>> entries = ztxFormat.ParseLines(content);
                        string formattedContent = ztxFormat.FormatContent(entries);
                        textBox.Text = formattedContent;
                    }
                    else
                    {
                        textBox.Text = content;
                    }

                    panelTextFile.Controls.Add(textBox);
                }
                else
                {
                    TextBox textBox = new TextBox();
                    textBox.Dock = DockStyle.Fill;
                    textBox.Multiline = true;
                    textBox.ScrollBars = ScrollBars.Vertical;
                    textBox.ReadOnly = true;
                    textBox.Text = content;
                    panelTextFile.Controls.Add(textBox);
                }
            }
        }

        private bool IsRtf(string text)
        {
            return text.StartsWith("{\\rtf");
        }

        private bool IsCsv(string text)
        {
            return text.Contains(",") || text.Contains("\t");
        }

    }
}
