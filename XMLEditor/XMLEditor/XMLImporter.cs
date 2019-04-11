using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XMLEditor
{
    class XMLImporter
    {

        public string OutputString;
        public Stack<string> OutputStack;

        public XMLImporter()
        {
            OutputStack = new Stack<string>();
            OutputString = "";
        }

        public string[] ImportXMLData(string locationFile)
        {
            string input = System.IO.File.ReadAllText(@locationFile);
            string[] sections = input.Split('[');
            return sections;
        }

        public string FormatText(string text, string type, string number, string newString)
        {
            string returnString = text.Replace(type + number, newString);
            return returnString;
        }

        public void AddString(string add)
        {
            OutputStack.Push(add);
        }

        public void RemoveString(string remove)
        {
            OutputStack.Pop();
        }

        public void ImportXML(XmlDocument myxml)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            myxml.WriteTo(tx);

            string str = sw.ToString();
            OutputStack.Push(str);
        }


        public void WriteToFile()
        {
            string[] array = OutputStack.ToArray();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                OutputString = OutputString + array[i];
            }

            XmlTextWriter writer = new XmlTextWriter("data.xml", null);
            writer.WriteRaw(OutputString);
            writer.Close();
            
        }
    }
}
