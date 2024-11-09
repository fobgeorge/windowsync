namespace WindowSync
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnIgroneClear = new Button();
            btnAddIgrone = new Button();
            btnStart = new Button();
            btnClear = new Button();
            lstWindows = new ListView();
            colHandle = new ColumnHeader();
            colTitle = new ColumnHeader();
            colOperation = new ColumnHeader();
            btnGetHandle = new Button();
            txtIgroneKeys = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(59, 17);
            label1.TabIndex = 40;
            label1.Text = "游戏窗口:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(12, 308);
            label7.Name = "label7";
            label7.Size = new Size(83, 17);
            label7.TabIndex = 38;
            label7.Text = "鼠标点击同步:";
            label7.Visible = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(12, 275);
            label6.Name = "label6";
            label6.Size = new Size(59, 17);
            label6.TabIndex = 37;
            label6.Text = "忽略按键:";
            // 
            // btnIgroneClear
            // 
            btnIgroneClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIgroneClear.Location = new Point(473, 270);
            btnIgroneClear.Name = "btnIgroneClear";
            btnIgroneClear.Size = new Size(64, 25);
            btnIgroneClear.TabIndex = 30;
            btnIgroneClear.Text = "清除";
            btnIgroneClear.UseVisualStyleBackColor = true;
            btnIgroneClear.Click += btnIgroneClear_Click;
            // 
            // btnAddIgrone
            // 
            btnAddIgrone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddIgrone.Location = new Point(403, 271);
            btnAddIgrone.Name = "btnAddIgrone";
            btnAddIgrone.Size = new Size(64, 25);
            btnAddIgrone.TabIndex = 29;
            btnAddIgrone.Text = "添加";
            btnAddIgrone.UseVisualStyleBackColor = true;
            btnAddIgrone.Click += btnAddIgrone_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStart.Location = new Point(403, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(64, 25);
            btnStart.TabIndex = 27;
            btnStart.Text = "运行";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(473, 13);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 25);
            btnClear.TabIndex = 26;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lstWindows
            // 
            lstWindows.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstWindows.Columns.AddRange(new ColumnHeader[] { colHandle, colTitle, colOperation });
            lstWindows.FullRowSelect = true;
            lstWindows.GridLines = true;
            lstWindows.Location = new Point(12, 44);
            lstWindows.MultiSelect = false;
            lstWindows.Name = "lstWindows";
            lstWindows.Size = new Size(525, 215);
            lstWindows.TabIndex = 25;
            lstWindows.UseCompatibleStateImageBehavior = false;
            lstWindows.View = View.Details;
            lstWindows.DoubleClick += lstWindows_DoubleClick;
            // 
            // colHandle
            // 
            colHandle.Text = "句柄";
            colHandle.Width = 100;
            // 
            // colTitle
            // 
            colTitle.Text = "标题";
            colTitle.Width = 355;
            // 
            // colOperation
            // 
            colOperation.Text = "主控";
            colOperation.TextAlign = HorizontalAlignment.Center;
            colOperation.Width = 40;
            // 
            // btnGetHandle
            // 
            btnGetHandle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGetHandle.Location = new Point(311, 13);
            btnGetHandle.Name = "btnGetHandle";
            btnGetHandle.Size = new Size(86, 25);
            btnGetHandle.TabIndex = 24;
            btnGetHandle.Text = "拖动到窗口";
            btnGetHandle.UseVisualStyleBackColor = true;
            btnGetHandle.MouseDown += btnGetHandle_MouseDown;
            btnGetHandle.MouseUp += btnGetHandle_MouseUp;
            // 
            // txtIgroneKeys
            // 
            txtIgroneKeys.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtIgroneKeys.Location = new Point(75, 272);
            txtIgroneKeys.Name = "txtIgroneKeys";
            txtIgroneKeys.ReadOnly = true;
            txtIgroneKeys.Size = new Size(322, 23);
            txtIgroneKeys.TabIndex = 41;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(101, 307);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(51, 21);
            checkBox1.TabIndex = 42;
            checkBox1.Text = "左键";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(158, 307);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(51, 21);
            checkBox2.TabIndex = 43;
            checkBox2.Text = "中键";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            checkBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(215, 307);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(51, 21);
            checkBox3.TabIndex = 44;
            checkBox3.Text = "右键";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            checkBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(272, 307);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(58, 21);
            checkBox4.TabIndex = 45;
            checkBox4.Text = "第4键";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.Visible = false;
            // 
            // checkBox5
            // 
            checkBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(336, 307);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(58, 21);
            checkBox5.TabIndex = 46;
            checkBox5.Text = "第5键";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.Visible = false;
            // 
            // checkBox6
            // 
            checkBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(400, 307);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(58, 21);
            checkBox6.TabIndex = 47;
            checkBox6.Text = "第6键";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 340);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(txtIgroneKeys);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnIgroneClear);
            Controls.Add(btnAddIgrone);
            Controls.Add(btnStart);
            Controls.Add(btnClear);
            Controls.Add(lstWindows);
            Controls.Add(btnGetHandle);
            Name = "MainForm";
            Text = "窗口多开同步器";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private Label label6;
        private Button btnIgroneClear;
        private Button btnAddIgrone;
        private Button btnStart;
        private Button btnClear;
        private ListView lstWindows;
        private ColumnHeader colHandle;
        private ColumnHeader colTitle;
        private ColumnHeader colOperation;
        private Button btnGetHandle;
        private TextBox txtIgroneKeys;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
    }
}
