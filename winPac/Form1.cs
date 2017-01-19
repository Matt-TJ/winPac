using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace winPac
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.LabelEdit = true;
            TreeNode node = new TreeNode();
            node.Text = "001";
            treeView1.Nodes.Add(node);
            TreeNode node1 = new TreeNode();
            node1.Text = "001-1";
            node.Nodes.Add(node1);

            //Treeview 展开
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Parent != null && e.Node.Parent.Index == 0)
                {
                    rtbDet.Text = e.Node.Text;
                }
                else
                    rtbDet.Text = "";
            }
        }
        //右键菜单
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
                if (tn != null)
                {
                    treeView1.SelectedNode = tn;
                }

                cmsNode.Show(this,e.X+8,e.Y+20);
                
            }
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                treeView1.SelectedNode.BeginEdit();
            }
        }

        private void 在此新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                TreeNode tr = new TreeNode();
                tr.Text = "NewNode";
                if (treeView1.SelectedNode.Parent!=null)
                {
                    treeView1.SelectedNode.Parent.Nodes.Add(tr);
                    treeView1.SelectedNode = tr;
                    tr.BeginEdit();
                }
                
            }
        }
        //双击事件，更改标签
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                // treeView1.SelectedNode.BeginEdit();
                //treeView1.ExpandAll();
                //Form2 fm2 = new Form2();
               // fm2.StartPosition = FormStartPosition.Manual;
               // fm2.Location = new Point(100,100);
               // fm2.ShowDialog();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                treeView1.SelectedNode.Remove();
            }
        }

        private void 创建子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                TreeNode tr = new TreeNode();
                tr.Text = "NewNode";
                treeView1.SelectedNode.Nodes.Add(tr);
                treeView1.ExpandAll();
                treeView1.SelectedNode = tr;
                
            }
        }
/// <summary>
/// 双击事件
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(treeView1.SelectedNode!=null)
            {
                Form2 fm2 = new Form2(treeView1.SelectedNode.Text);
                fm2.TextBoxChanged += new EventHandler((sender1, e1) => { treeView1.SelectedNode.Text = fm2.TextBoxValue; });
                fm2.indexPercent += new Form2.indexPercentEventHandler(ChangeRtb);
                

                fm2.StartPosition = FormStartPosition.Manual;
                fm2.Location = new Point(e.X + this.Location.X, e.Y + this.Location.Y-5);
                // fm2.ShowDialog();
                fm2.Show(this);
            }
            treeView1.ExpandAll();
        }
        public void ChangeRtb(object sender,IndexPercentArgs e)
        {
            rtbDet.Text = e.indexName + e.percent;
            //treeView1.SelectedNode.Text = e.indexName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // treeViewExXML.writeXml();
            treeViewExXML ex = new treeViewExXML(treeView1);
            ex.trExXml();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            treeViewExXML ex = new treeViewExXML(treeView1);
            ex.XMLToTree(treeView1);   
        }
    }
}
