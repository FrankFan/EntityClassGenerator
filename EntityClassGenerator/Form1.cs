/*
 * Author:fanyong@gmail.com
 * Description: Winform code-behind
 * 
 */

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EntityClassGenerator
{
    public partial class Form1 : Form
    {
        //连接字符串，全局使用
        string connStr = string.Empty;
        
        public Form1()
        {
            InitializeComponent();
            //禁止最大化窗口
            this.MaximizeBox = false;
            //允许最小化窗口
            this.MinimizeBox = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //do nothing
        }
        
        /// <summary>
        /// 连接数据库事件
        /// </summary>
        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            
            string server = txtServer.Text.Trim();
            string uid = txtUid.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            connStr = "server=" + server + ";";
            connStr += "uid=" + uid + ";";
            connStr += "pwd=" + pwd + ";";


            SqlHelper helper = new SqlHelper(connStr);
            SqlConnection conn = helper.GetConn();
            
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    //get all tables in db
                    string sqlGetTable = "select name as 'name' from master..sysdatabases order by name";
                    DataTable dt = helper.ExecuteQuery(sqlGetTable, CommandType.Text);
                    cbChooseDB.DataSource = dt;
                    cbChooseDB.DisplayMember = "name";

                    MessageBox.Show("连接成功!");
                }
            }
            else
            {
                MessageBox.Show("连接失败!");
                return;
            }
        }
       
        /// <summary>
        /// cbChooseDB的触发事件
        /// </summary>
        private void cbChooseDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //第一次进来的时候cbChooseDB.Textd的值不对
            if (this.cbChooseDB.Text != "System.Data.DataRowView")
            {
                DataTable db = new DataTable();
                SqlHelper helper = new SqlHelper(connStr);
                string cmdText = string.Format("use {0}; Select   name   from   sysobjects   where   xtype= 'u '", this.cbChooseDB.Text);
                db = helper.ExecuteQuery(cmdText, CommandType.Text);
                this.cbChooseTable.DataSource = db;
                this.cbChooseTable.DisplayMember = "name";
            }
        }

        /// <summary>
        /// cbChooseTable的触发事件
        /// </summary>
        private void cbChooseTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get result table
            DataTable dt = GetTableContent();

            //convert db type to c# type
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][1] = ConvertType(dt.Rows[i][1].ToString());
            }

            //clear, in case of repeat
            this.dgvTableInfo.Columns.Clear();

            //bind coloume
            DisplayCol(dgvTableInfo, "ColumnName", "属性");
            DisplayCol(dgvTableInfo, "Type", "类别");
            DisplayCol(dgvTableInfo, "ColumnDesc", "说明");

            dgvTableInfo.DataSource = dt;
        }

        /// <summary>
        /// 根据执行db和table获取表中数据
        /// 属性，类型，说明
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable GetTableContent()
        {
            string sql = string.Format(@"use {0}; SELECT
    ColumnName=C.name,
    Type=T.name,
    ColumnDesc=ISNULL(PFD.[value],N'')
FROM sys.columns C
    INNER JOIN sys.objects O
        ON C.[object_id]=O.[object_id]
            AND O.type='U'
            AND O.is_ms_shipped=0
    INNER JOIN sys.types T
        ON C.user_type_id=T.user_type_id
    LEFT JOIN sys.default_constraints D
        ON C.[object_id]=D.parent_object_id
            AND C.column_id=D.parent_column_id
            AND C.default_object_id=D.[object_id]
    LEFT JOIN sys.extended_properties PFD
        ON PFD.class=1 
            AND C.[object_id]=PFD.major_id 
            AND C.column_id=PFD.minor_id
--             AND PFD.name='Caption' -- 字段说明对应的描述名称(一个字段可以添加多个不同name的描述)
    LEFT JOIN sys.extended_properties PTB
        ON PTB.class=1 
            AND PTB.minor_id=0 
            AND C.[object_id]=PTB.major_id
--             AND PFD.name='Caption' -- 表说明对应的描述名称(一个表可以添加多个不同name的描述)

    LEFT JOIN                       -- 索引及主键信息
    (
        SELECT 
            IDXC.[object_id],
            IDXC.column_id,
            Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending')
                WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END,
            PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END,
            IndexName=IDX.Name
        FROM sys.indexes IDX
        INNER JOIN sys.index_columns IDXC
            ON IDX.[object_id]=IDXC.[object_id]
                AND IDX.index_id=IDXC.index_id
        LEFT JOIN sys.key_constraints KC
            ON IDX.[object_id]=KC.[parent_object_id]
                AND IDX.index_id=KC.unique_index_id
        INNER JOIN -- 对于一个列包含多个索引的情况,只显示第1个索引信息
        (
            SELECT [object_id], Column_id, index_id=MIN(index_id)
            FROM sys.index_columns
            GROUP BY [object_id], Column_id
        ) IDXCUQ
            ON IDXC.[object_id]=IDXCUQ.[object_id]
                AND IDXC.Column_id=IDXCUQ.Column_id
                AND IDXC.index_id=IDXCUQ.index_id
    ) IDX
        ON C.[object_id]=IDX.[object_id]
            AND C.column_id=IDX.column_id

WHERE O.name=N'{1}'       -- 如果只查询指定表,加上此条件
ORDER BY O.name,C.column_id



", this.cbChooseDB.Text, this.cbChooseTable.Text);
            SqlHelper helper = new SqlHelper(connStr);
            DataTable dt = new DataTable();
            dt = helper.ExecuteQuery(sql, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 设置DataGridView的列的显示
        /// 类似前台的列编辑
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dataPropertyName">属性名称，对应数据库中字段名</param>
        /// <param name="headerText">显示的文字</param>
        private void DisplayCol(DataGridView dgv, string dataPropertyName, string headerText)
        {
            dgv.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn obj = new DataGridViewTextBoxColumn();
            obj.DataPropertyName = dataPropertyName;
            obj.HeaderText = headerText;
            obj.Name = dataPropertyName;
            obj.Resizable = DataGridViewTriState.True;
            dgv.Columns.AddRange(new DataGridViewColumn[] { obj });
        }

        /// <summary>
        /// 单选按钮,有,事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdYes_CheckedChanged(object sender, EventArgs e)
        {
            txtNamespace.Visible = true;
        }

        /// <summary>
        /// 单选按钮,无,事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdNo_CheckedChanged(object sender, EventArgs e)
        {
            txtNamespace.Visible = false;
        }

        /// <summary>
        /// 生成实体类事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string className = txtClassName.Text.Trim();
            string classDesc = txtClassDesc.Text.Trim();

            if (string.IsNullOrEmpty(className))
            {
                MessageBox.Show("请填写类名!");
                return;
            }

            //设置saveFileDialog
            saveFileDialog1.FileName = className;
            saveFileDialog1.Filter = "C#文件|*.cs";
            saveFileDialog1.Title = "保存实体类到……";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //写文件
                WriteFile(className, classDesc);
            }

            MessageBox.Show("实体类" + className + "创建完毕");

        }

        /// <summary>
        /// 创建实体类代码模板
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="classDesc">类说明</param>
        private void WriteFile(string className, string classDesc)
        {
            
            //文件引用
            FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
            //使用流写入文件
            StreamWriter writer = new StreamWriter(fs, Encoding.Default);

            //开始写入内容
            writer.WriteLine("/*");
            writer.WriteLine(" * Author:fanyong@gmail.com ");
            writer.WriteLine(" * CreateTime:" + DateTime.Now);
            writer.WriteLine(" */");
            writer.WriteLine("using System;");
            writer.WriteLine("using System.Collections;");
            writer.WriteLine("using System.Collections.Generic;");
            writer.WriteLine();

            if (rdYes.Checked && !string.IsNullOrEmpty(txtNamespace.Text.Trim()))
            {
                writer.WriteLine("namespace " + txtNamespace.Text.Trim());
                writer.WriteLine("{");
            }

            if (classDesc.Length != 0)
            {
                writer.WriteLine("    /// <summary>");
                writer.WriteLine("    /// " + classDesc);
                writer.WriteLine("    /// </summary>");
            }

            writer.WriteLine("    public class " + className);
            writer.WriteLine("    {");

            foreach (DataGridViewRow row in dgvTableInfo.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    //获取属性名
                    string propName = row.Cells[0].Value.ToString();
                    //获取属性类型
                    string propType = row.Cells[1].Value.ToString();
                    //设置变量名，格式 _personName
                    string variableName = SetVariableName(propName);
                    //设置属性名，格式 PersonName
                    string formatedPropName = SetPropName(propName);

                    writer.WriteLine("        private " + propType + " _" + variableName + ";");

                    if (row.Cells[2].Value != null)
                    {
                        //获取备注
                        string remark = row.Cells[2].Value.ToString();
                        writer.WriteLine("        /// <summary>");
                        writer.WriteLine("        /// " + remark);
                        writer.WriteLine("        /// </summary>");
                    }

                    writer.WriteLine("        public " + propType + " " + formatedPropName);
                    writer.WriteLine("        {");
                    writer.WriteLine("            get{ return _" + variableName + ";}");
                    writer.WriteLine("            set{ _" + variableName + " = value;}");
                    writer.WriteLine("        }");

                }
            }

            writer.WriteLine("    }");
            if (rdYes.Checked && !string.IsNullOrEmpty(txtNamespace.Text.Trim()))
            {
                writer.WriteLine("}");
            }
            //关闭
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// sql类型匹配C#类型
        /// </summary>
        /// <param name="sqlType"></param>
        /// <returns></returns>
        private string ConvertType(string sqlType)
        {
            string csType = string.Empty;

            switch (sqlType)
            {
                case "bigint":
                    csType = "Int64";
                    break;
                case "binary":
                    csType = "Byte[]";
                    break;
                case "bit":
                    csType = "bool";
                    break;
                case "char":
                    csType = "char";
                    break;
                case "datetime":
                    csType = "DateTime";
                    break;
                case "decimal":
                    csType = "Decimal";
                    break;
                case "float":
                    csType = "float";
                    break;
                case "image":
                    csType = "Byte[]";
                    break;
                case "int":                    
                    csType = "int";
                    break;
                case "money":
                    csType = "Decimal";
                    break;
                case "nchar":
                    csType = "string";
                    break;
                case "ntext":
                    csType = "string";
                    break;
                case "numeric":
                    csType = "Decimal";
                    break;
                case "nvarchar":
                    csType = "string";
                    break;
                case "real":
                    csType = "Single";
                    break;
                case "smalldatetime":
                    csType = "DateTime";
                    break;
                case "smallint":
                    csType = "Int16";
                    break;
                case "smallmoney":
                    csType = "Decimal";
                    break;
                case "sql_variant":
                    csType = "Object*";
                    break;
                case "text":
                    csType = "string";
                    break;
                case "time":
                    csType = "TimeSpan";
                    break;
                case "timestamp":
                    csType = "Byte[]";
                    break;
                case "tinyint":
                    csType = "Byte";
                    break;
                case "uniqueidentifier":
                    csType = "Guid";
                    break;
                case "varbinary":
                    csType = "Byte[]";
                    break;
                case "varchar":
                    csType = "string";
                    break;
                case "xml":
                    csType = "xml";
                    break;
                default:
                    csType = "unkown type";
                    break;
            }            
            return csType;
        }

        private string SetVariableName(string variableStr)
        {
            variableStr = variableStr.Substring(0, 1).ToLower() + variableStr.Substring(1);

            return variableStr;
        }

        private string SetPropName(string propStr)
        {
            propStr = propStr.Substring(0, 1).ToUpper() + propStr.Substring(1);

            return propStr;
        }

    }
}
