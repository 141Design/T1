using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//回路図の信号や電源から、エラー対象の部品を抽出する
/*
 *  CADの回路データなどを、"回路構造ファイルCSF"に変換する

    データをクラスに格納する
    信号リストを作る
        電源、GNDへの移動はストップ
        行き先がないポートはストップ
        
    ポートに入出力を登録する。
    デバイス内、ポート間の接続は、別ファイルで定義し、呼び出す際は、グループで指定する。

     
*/


namespace ErrorPartsListMaker
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            ObjectList objlist = new ObjectList();

            

            /*
            string NetListData = "";

            while (true)
            {
                OpenFileDialog ofDialog = new OpenFileDialog();
                ofDialog.InitialDirectory = @"C:";
                ofDialog.Title = "Import net list file";

                if (ofDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofDialog.FileName, Encoding.GetEncoding("UTF-8"));
                    NetListData = sr.ReadToEnd();
                    sr.Close();

                    NetListData = Regex.Replace(NetListData, @"\s", "");
                    NetListData = Regex.Replace(NetListData, @";", "\n");
                    Console.WriteLine(NetListData);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Cancelled");
                }
                ofDialog.Dispose();

            }
            */

        }
    }

    public class ObjectList
    {
        public List<ObjectBase> Objects;

        public ObjectList()
        {
            Objects = new List<ObjectBase>();
        }

        public ObjectBase GetObject(string propertyKey, string value)
        {
            ObjectBase retObject = new ObjectBase();
            foreach (ObjectBase obj in Objects)
            {
                if (obj.Property.ContainsKey(propertyKey))
                {
                    if(obj.Property[propertyKey] == value)
                    {
                        retObject = obj;
                    }
                }
            }
            return retObject;
        }


    }
    
    public class ObjectBase {
        public Dictionary<string, string> Property;
        public ObjectBase(){
            Property = new Dictionary<string, string>();
        }
    }


}