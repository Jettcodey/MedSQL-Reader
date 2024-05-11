namespace MedSQL_Reader
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dataGridView = new DataGridView();
            openFileDialog = new OpenFileDialog();
            btnOpenFile = new Button();
            panelTextFile = new Panel();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(13, 45);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(602, 554);
            dataGridView.TabIndex = 0;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "SQLite files|*.db;*.sqlite;*.sqlite3|All files|*.*";
            // 
            // btnOpenFile
            // 
            btnOpenFile.Location = new Point(13, 12);
            btnOpenFile.Margin = new Padding(4, 3, 4, 3);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(180, 27);
            btnOpenFile.TabIndex = 1;
            btnOpenFile.Text = "Open Tomedo SQLite file";
            btnOpenFile.UseVisualStyleBackColor = true;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // panelTextFile
            // 
            panelTextFile.BackColor = Color.Silver;
            panelTextFile.BorderStyle = BorderStyle.FixedSingle;
            panelTextFile.Location = new Point(649, 45);
            panelTextFile.Margin = new Padding(4, 3, 4, 3);
            panelTextFile.Name = "panelTextFile";
            panelTextFile.Size = new Size(550, 554);
            panelTextFile.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(200, 24);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "SQL Table:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(649, 24);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 7;
            label2.Text = "Data/Content:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            ClientSize = new Size(1215, 613);
            Controls.Add(label2);
            Controls.Add(panelTextFile);
            Controls.Add(btnOpenFile);
            Controls.Add(dataGridView);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MedSQL Reader by Jettcodey";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Panel panelTextFile;
        private System.Windows.Forms.Label label1;
        private Label label2;
    }
}
