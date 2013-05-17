namespace EntityClassGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConnectDB = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.lblUID = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbChooseTable = new System.Windows.Forms.ComboBox();
            this.cbChooseDB = new System.Windows.Forms.ComboBox();
            this.lblChooseTable = new System.Windows.Forms.Label();
            this.lblChooseDB = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTableInfo = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.rdNo = new System.Windows.Forms.RadioButton();
            this.rdYes = new System.Windows.Forms.RadioButton();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.txtClassDesc = new System.Windows.Forms.TextBox();
            this.lblClassDesc = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnectDB);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.lblPwd);
            this.groupBox1.Controls.Add(this.txtUid);
            this.groupBox1.Controls.Add(this.lblUID);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.lblServer);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登陆信息";
            // 
            // btnConnectDB
            // 
            this.btnConnectDB.Location = new System.Drawing.Point(58, 102);
            this.btnConnectDB.Name = "btnConnectDB";
            this.btnConnectDB.Size = new System.Drawing.Size(75, 23);
            this.btnConnectDB.TabIndex = 6;
            this.btnConnectDB.Text = "连接DB";
            this.btnConnectDB.UseVisualStyleBackColor = true;
            this.btnConnectDB.Click += new System.EventHandler(this.btnConnectDB_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(81, 75);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(111, 21);
            this.txtPwd.TabIndex = 5;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(20, 84);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(29, 12);
            this.lblPwd.TabIndex = 4;
            this.lblPwd.Text = "pwd:";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(81, 46);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(111, 21);
            this.txtUid.TabIndex = 3;
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(20, 55);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(29, 12);
            this.lblUID.TabIndex = 2;
            this.lblUID.Text = "uid:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(81, 17);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(111, 21);
            this.txtServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(20, 26);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(47, 12);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbChooseTable);
            this.groupBox2.Controls.Add(this.cbChooseDB);
            this.groupBox2.Controls.Add(this.lblChooseTable);
            this.groupBox2.Controls.Add(this.lblChooseDB);
            this.groupBox2.Location = new System.Drawing.Point(280, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 127);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库信息";
            // 
            // cbChooseTable
            // 
            this.cbChooseTable.FormattingEnabled = true;
            this.cbChooseTable.Location = new System.Drawing.Point(103, 75);
            this.cbChooseTable.Name = "cbChooseTable";
            this.cbChooseTable.Size = new System.Drawing.Size(121, 20);
            this.cbChooseTable.TabIndex = 3;
            this.cbChooseTable.SelectedIndexChanged += new System.EventHandler(this.cbChooseTable_SelectedIndexChanged);
            // 
            // cbChooseDB
            // 
            this.cbChooseDB.FormattingEnabled = true;
            this.cbChooseDB.Location = new System.Drawing.Point(101, 26);
            this.cbChooseDB.Name = "cbChooseDB";
            this.cbChooseDB.Size = new System.Drawing.Size(121, 20);
            this.cbChooseDB.TabIndex = 2;
            this.cbChooseDB.SelectedIndexChanged += new System.EventHandler(this.cbChooseDB_SelectedIndexChanged);
            // 
            // lblChooseTable
            // 
            this.lblChooseTable.AutoSize = true;
            this.lblChooseTable.Location = new System.Drawing.Point(25, 83);
            this.lblChooseTable.Name = "lblChooseTable";
            this.lblChooseTable.Size = new System.Drawing.Size(71, 12);
            this.lblChooseTable.TabIndex = 1;
            this.lblChooseTable.Text = "选择数据表:";
            // 
            // lblChooseDB
            // 
            this.lblChooseDB.AutoSize = true;
            this.lblChooseDB.Location = new System.Drawing.Point(23, 26);
            this.lblChooseDB.Name = "lblChooseDB";
            this.lblChooseDB.Size = new System.Drawing.Size(71, 12);
            this.lblChooseDB.TabIndex = 0;
            this.lblChooseDB.Text = "选择数据库:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvTableInfo);
            this.groupBox3.Location = new System.Drawing.Point(12, 286);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(529, 232);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "数据表预览";
            // 
            // dgvTableInfo
            // 
            this.dgvTableInfo.AllowUserToAddRows = false;
            this.dgvTableInfo.AllowUserToDeleteRows = false;
            this.dgvTableInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableInfo.Location = new System.Drawing.Point(7, 18);
            this.dgvTableInfo.Name = "dgvTableInfo";
            this.dgvTableInfo.ReadOnly = true;
            this.dgvTableInfo.RowTemplate.Height = 23;
            this.dgvTableInfo.Size = new System.Drawing.Size(516, 205);
            this.dgvTableInfo.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGenerate);
            this.groupBox4.Controls.Add(this.txtNamespace);
            this.groupBox4.Controls.Add(this.rdNo);
            this.groupBox4.Controls.Add(this.rdYes);
            this.groupBox4.Controls.Add(this.lblNamespace);
            this.groupBox4.Controls.Add(this.txtClassDesc);
            this.groupBox4.Controls.Add(this.lblClassDesc);
            this.groupBox4.Controls.Add(this.txtClassName);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(12, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(516, 112);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "创建实体类";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(129, 77);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(159, 22);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "生成实体类";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(249, 48);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(173, 21);
            this.txtNamespace.TabIndex = 7;
            // 
            // rdNo
            // 
            this.rdNo.AutoSize = true;
            this.rdNo.Location = new System.Drawing.Point(157, 53);
            this.rdNo.Name = "rdNo";
            this.rdNo.Size = new System.Drawing.Size(35, 16);
            this.rdNo.TabIndex = 6;
            this.rdNo.TabStop = true;
            this.rdNo.Text = "无";
            this.rdNo.UseVisualStyleBackColor = true;
            this.rdNo.CheckedChanged += new System.EventHandler(this.rdNo_CheckedChanged);
            // 
            // rdYes
            // 
            this.rdYes.AutoSize = true;
            this.rdYes.Location = new System.Drawing.Point(85, 53);
            this.rdYes.Name = "rdYes";
            this.rdYes.Size = new System.Drawing.Size(35, 16);
            this.rdYes.TabIndex = 5;
            this.rdYes.TabStop = true;
            this.rdYes.Text = "有";
            this.rdYes.UseVisualStyleBackColor = true;
            this.rdYes.CheckedChanged += new System.EventHandler(this.rdYes_CheckedChanged);
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(20, 57);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(59, 12);
            this.lblNamespace.TabIndex = 4;
            this.lblNamespace.Text = "命名空间:";
            // 
            // txtClassDesc
            // 
            this.txtClassDesc.Location = new System.Drawing.Point(295, 14);
            this.txtClassDesc.Name = "txtClassDesc";
            this.txtClassDesc.Size = new System.Drawing.Size(127, 21);
            this.txtClassDesc.TabIndex = 3;
            // 
            // lblClassDesc
            // 
            this.lblClassDesc.AutoSize = true;
            this.lblClassDesc.Location = new System.Drawing.Point(247, 23);
            this.lblClassDesc.Name = "lblClassDesc";
            this.lblClassDesc.Size = new System.Drawing.Size(41, 12);
            this.lblClassDesc.TabIndex = 2;
            this.lblClassDesc.Text = "说明：";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(81, 14);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(111, 21);
            this.txtClassName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类名:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 528);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "实体类生成器 V1.0   Designed by fanyong@gmail.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableInfo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvTableInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnConnectDB;
        private System.Windows.Forms.Label lblChooseTable;
        private System.Windows.Forms.Label lblChooseDB;
        private System.Windows.Forms.ComboBox cbChooseTable;
        private System.Windows.Forms.ComboBox cbChooseDB;
        private System.Windows.Forms.TextBox txtClassDesc;
        private System.Windows.Forms.Label lblClassDesc;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.RadioButton rdNo;
        private System.Windows.Forms.RadioButton rdYes;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}

