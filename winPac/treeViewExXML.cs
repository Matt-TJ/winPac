using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace winPac
{
    class treeViewExXML
    {
        private TreeView myTreeView;
        private string xmlFilePath;
        XmlNode xmlRoot;
        XmlDocument textDoc;


        public treeViewExXML(TreeView tr)
        {
            myTreeView = tr;
            textDoc = new XmlDocument();
        }

        public static void writeXml()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.Encoding = new UTF8Encoding(false);
                settings.NewLineChars = Environment.NewLine;

                using (XmlWriter xmlWriters = XmlWriter.Create(ms, settings))
                {
                    //写xml文件开始
                    xmlWriters.WriteStartDocument(false);
                    //写根节点
                    xmlWriters.WriteStartElement("ROOT");
                    //给节点添加属性
                    xmlWriters.WriteStartElement("CAT");
                    //添加属性
                    xmlWriters.WriteAttributeString("Percent", "100%");
                    xmlWriters.WriteString("Catty");
                    xmlWriters.WriteEndElement();

                    //添加一个节点
                    xmlWriters.WriteElementString("Panda", "Haha");
                    xmlWriters.WriteEndElement();
                    xmlWriters.WriteEndDocument();
                }

                //输出xml内容
                string xml = Encoding.UTF8.GetString(ms.ToArray());

                //输出文件
                FileStream fs = new FileStream("tree.xml", FileMode.Create);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(xml);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区，关闭流
                fs.Flush();
                fs.Close();


            }
                
        }

        public void trExXml()
        {
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.Encoding = new UTF8Encoding(false);
            settings.NewLineChars = Environment.NewLine;
            XmlWriter xmlWriters = XmlWriter.Create("E:\\Alex\\treeXml.xml");
            xmlWriters.WriteStartDocument(false);
            //写根节点
            xmlWriters.WriteStartElement("TheRoot");
            xmlWriters.WriteEndElement();

            xmlWriters.WriteEndDocument();
            xmlWriters.Flush();
            xmlWriters.Close();



            //创建XMLDocument对象
//            textDoc = new XmlDocument();
            textDoc.Load("E:\\Alex\\treeXml.xml");
                //选中根节点
            XmlElement xmlNode = textDoc.CreateElement(myTreeView.Nodes[0].Text);
            xmlRoot = textDoc.SelectSingleNode("TheRoot");

                //遍历treeView，并生成XML
            TransXml(myTreeView.Nodes, (XmlElement)xmlRoot);

            

        }

        private int TransXml(TreeNodeCollection nodes,XmlElement parXmlNode)
        {
            XmlElement xmlNode;
            xmlRoot = textDoc.SelectSingleNode("TheRoot");

            foreach(TreeNode node in nodes)
            {
                xmlNode = textDoc.CreateElement(node.Text);
                parXmlNode.AppendChild(xmlNode);

                if(node.Nodes.Count>0)
                {
                    TransXml(node.Nodes, xmlNode);
                }
            }
            textDoc.Save("E:\\Alex\\treeXml.xml");
            return 0;
        }

        public int XMLToTree(TreeView tree)
        {
            myTreeView = tree;
            xmlFilePath = "E:\\Alex\\treeXml.xml";

            //载入xml文档
            textDoc.Load(xmlFilePath);
            XmlNode root = textDoc.SelectSingleNode("TheRoot");

            foreach(XmlNode subXmlNode in root.ChildNodes)
            {
                TreeNode trNod = new TreeNode();
                trNod.Text = subXmlNode.Name;
                myTreeView.Nodes.Add(trNod);
                TransXML(subXmlNode.ChildNodes, trNod);
            }

            return 0;

        }
        //遍历xml节点
        private int TransXML(XmlNodeList xmlNodes,TreeNode trNode)
        {
            foreach (XmlNode xmlNode in xmlNodes)
            {
                TreeNode subTrNode = new TreeNode();
                subTrNode.Text = xmlNode.Name;
                trNode.Nodes.Add(subTrNode);

                if(xmlNode.ChildNodes.Count>0)
                {
                    TransXML(xmlNode.ChildNodes, subTrNode);
                }
            }

            return 0;
        }

    }
}
