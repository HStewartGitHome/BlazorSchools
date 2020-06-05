using BlazorSchools.Shared;
using System.Collections.Generic;
using System.Net.Http;
using WpfSchools.Client.Models;

namespace WpfSchools.Client.Support
{
    public class PageContentSupport
    {


        public List<IFieldModel> Fields { get; set; }

        public void AddField(string title, int len)
        {
            if (Fields == null)
                Fields = new List<IFieldModel>();

            IFieldModel field = new FieldModel();
            field.Title = title;
            field.Size = len;
            Fields.Add(field);
        }

        public string MakeHeader()
        {
            if (Fields == null)
                return "";
            else
            {
                List<string> strings = new List<string>();
                foreach (IFieldModel field in Fields)
                    strings.Add(field.Title);
                return MakeContent(strings);
            }
        }

        public string MakeContent(List<string> strings)
        {
            string str = "";
            string strCurrent, strNew;

            int count = Fields.Count;
            int stringCount = strings.Count;
            int fieldSize;

            for (int Index = 0; Index < count; Index++)
            {
                fieldSize = Fields[Index].Size;
                if (Index >= stringCount)
                    strCurrent = "";
                else if (strings[Index] == null)
                    strCurrent = "";
                else
                    strCurrent = strings[Index];
                if (strCurrent.Length > fieldSize)
                    strNew = strCurrent.Substring(0, fieldSize);
                else
                    strNew = strCurrent.PadRight(fieldSize);
                str += strNew;
                str += "  ";
            }

            return str;
        }

        public HttpClient GetHttplClient(string str)
        {
            HttpClient client = null;
            ClientFactory factory = new ClientFactory();
            client = factory.GetHttplClient(str);
            return client;

        }


        public string GetSettingValue(string setting)
        {
            string value = "";




            return value;
        }



    }
}
