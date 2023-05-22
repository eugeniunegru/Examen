using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
     class Manipulator : Imanipulator
    {
        Dictionary<string, string> text;
        int inputtype;
        int outputtype;
        int inputFormat;
        int outputFormat;
        public Manipulator(int inputtype,  int inputFormat, int outputtype, int outputFormat)
        {
            this.inputtype = inputtype;
            this.outputtype = outputtype;
            this.inputFormat = inputFormat;
            this.outputFormat = outputFormat;
        }
            
        void WriteInConsole()
        {
            foreach (var txt in text)
                Console.Write(txt.Value + " " + txt.Key);
        }
        void Readdata()
        {
             Parser parser = new Parser();
            Getdata getdata = new Getdata();

            switch (inputtype)
            {               

                case 1:
                    {
                        switch (inputFormat)
                        {
                            case 1 : this.text = parser.ConvertToDictionary(getdata.Text); break;
                            case 2: this.text = parser.ConvertToDictionary(getdata.ReadStringFromFile()); break;
                            case 3: { Task<string> str=getdata.ReadContentFromHttp(); this.text = parser.ConvertToDictionary(str.Result.ToString()); } break;
                        }
                    }break;
                case 2:
                    {
                        switch (inputFormat)
                        {
                            case 1: this.text = parser.ParseJsonToDictionary(getdata.ReadStringFromFile()); break;
                            case 2: this.text = parser.ParseJsonToDictionary(getdata.ReadStringFromFile()); break;
                            case 3: { Task<string> str = getdata.ReadContentFromHttp(); this.text = parser.ParseJsonToDictionary(str.Result.ToString()); } break;
                        }
                    }
                    break;
                case 3:
                    {
                        switch (inputFormat)
                        {
                            case 1: this.text = parser.ParseXmlToDictionary(getdata.ReadStringFromFile()); break;
                            case 2: this.text = parser.ParseXmlToDictionary(getdata.ReadStringFromFile()); break;
                            case 3: { Task<string> str = getdata.ReadContentFromHttp(); this.text = parser.ParseXmlToDictionary(str.Result.ToString()); } break;
                        }
                    }
                    break;

            }
           
        }

        private void WriteData()
        {
            Outdata outdata = new Outdata();
            Convert convert = new Convert();
            
            switch (outputtype)
            {
                
                case 1:
                    {
                        switch (outputFormat)
                        {
                            case 1: WriteInConsole();  break;
                            case 2: Console.WriteLine(convert.ConvertDictionaryToJson(this.text)); break;
                            case 3: Console.WriteLine(convert.ConvertDictionaryToXml(this.text)); break;
                        }
                    }
                    break;
                case 2:
                    {
                        switch (outputFormat)
                        {
                            case 1: outdata.WriteStringToFile(convert.ConvertDictionaryToString(this.text)); break;
                            case 2: outdata.WriteStringToFile(convert.ConvertDictionaryToJson(this.text)); break;
                            case 3: outdata.WriteStringToFile(convert.ConvertDictionaryToXml(this.text)); break;
                        }
                    }
                    break;
            }
        }
        public void Show()
        {
            this.Readdata();
            this.WriteData();
        }

        void Imanipulator.Readdata()
        {
            throw new NotImplementedException();
        }

        void Imanipulator.WriteData()
        {
            throw new NotImplementedException();
        }
    }
}
