using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;

namespace курсовой
{
    public class Tovar
    {
        public int nomer;
        public int artik;
        public string name;
        public string pol;
        public string[] razmer;
        public string[] sostav;
        public string[] protsent;
        public float cost;
        public Image img;
        public Tovar(int nomer, int artik,string name,string pol,string[] razmer,string[] sostav,string[] protsent, float cost,Image img)
        {
            this.nomer = nomer;
            this.artik=artik;
            this.name=name;
            this.pol=pol;
            this.razmer=razmer;
            this.sostav=sostav;
            this.protsent = protsent;
            this.cost=cost;
            this.img=img;
        }
        public Tovar()
        { }
        public static bool tovar(int id,ref VseTovari vsetovari)
        {
            string strconnect = "server=localhost;user=root;database=new_schema;password=9032040!!;";
            MySqlConnection conn = new MySqlConnection(strconnect);
            conn.Open();
            string sql = "SELECT номер,Артикул,Название,Пол,Размер,Составы,Проценты,Цена,Картинка FROM new_table WHERE номер=" + id;
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                conn.Close();
                return false;
            }
            reader.Read();
            byte[] img = reader[8] as byte[];
            Image img1=null;            
            if (img != null)
            {
                ImageConverter converter = new ImageConverter();
                img1 = (Image)converter.ConvertFrom(img);
            }
            string[] razmer=StrokaToMassiv(reader[4].ToString(),true);
            string[] sostav = StrokaToMassiv(reader[5].ToString(),false);
            string[] protsent = StrokaToMassiv(reader[6].ToString(),true);
            Tovar elem = new Tovar((int)reader[0], (int)reader[1], reader[2].ToString(), reader[3].ToString(), razmer, sostav,protsent,(float)reader[7], img1);
            vsetovari.addtovar(elem);
            reader.Close();
            conn.Close();
            return true;
        }
        public static string[] StrokaToMassiv(string str,bool th)
        {
            List<string> list = new List<string>();
            char[] simv = str.ToCharArray();
            string onstr=null;
            char razdelit;
            if (th)
                razdelit = ' ';
            else
                razdelit = '0';
            foreach(char elem in simv)
            {
                if(elem==razdelit)
                {
                    list.Add(onstr);
                    onstr = null;
                    continue;
                }
                onstr += elem;
            }
            string[] rez = list.ToArray();
            return rez;
        }
        public static string MassiToStroka(string[] str, bool th)
        {
            char razdelit;
            if (th)
                razdelit = ' ';
            else
                razdelit = '0';
            string rez="";
            foreach (string elem in str)
                rez += elem+razdelit;
            
            return rez;
        }
        public static void AddBasdata(Tovar elem)
        {
            string strconnect = "server=localhost;user=root;database=new_schema;password=9032040!!;";
            MySqlConnection conn = new MySqlConnection(strconnect);
            conn.Open();
            string razmer=MassiToStroka(elem.razmer, true);
            string sostav = MassiToStroka(elem.sostav, false);
            string prots = MassiToStroka(elem.protsent, true);
            string sql = "INSERT INTO new_table (`номер`,`Артикул`,`Название`,`Пол`,`Размер`,`Составы`,`Проценты`,`Цена`) VALUES(" + elem.nomer + "," + elem.artik + ",'" + elem.name + "','" + elem.pol + "','" + razmer + "','" + sostav + "','" + prots + "',"+elem.cost+")";//"INSERT INTO new_table ('номер') VALUES ('"+elem.nomer+"');"; 
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
        public static void DelBasdata(int nomertovar,int kolvotovarov)
        {
            string strconnect = "server=localhost;user=root;database=new_schema;password=9032040!!;";
            MySqlConnection conn = new MySqlConnection(strconnect);
            conn.Open();
            string sql = "DELETE FROM new_table WHERE номер="+ nomertovar; 
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            while (true)
            {
                sql = "UPDATE new_table SET номер=" + nomertovar + " WHERE номер=" + (nomertovar + 1);
                command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                if (nomertovar >= kolvotovarov - 1)
                    break;
                nomertovar++;
            }
            conn.Close();
        }
        public static void ChangeBasdata(int nomertovar,string pole,string str,Image Img)
        {
            string strconnect = "server=localhost;user=root;database=new_schema;password=9032040!!;";
            MySqlConnection conn = new MySqlConnection(strconnect);
            conn.Open();
            string sql="";
            switch (pole)
            {
                case "Артикул":
                case "Название":
                case "Пол":
                case "Размер":
                case "Составы":
                case "Проценты":
                case "Цена":
                    sql = "UPDATE new_table SET `" + pole + "`='" + str + "' WHERE номер=" + nomertovar;
                    break;
                case "Картинка":
                    byte[] binImage = null;
                    if (Img != null)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        Img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        binImage = memoryStream.ToArray();
                        memoryStream.Dispose();
                    }
                    sql = "UPDATE new_table SET "+pole+"=(?) WHERE номер=" + nomertovar;
                    MySqlParameter param = new MySqlParameter("image", MySqlDbType.VarBinary);
                    MySqlCommand com = new MySqlCommand(sql, conn);
                    param.Value = binImage;
                    com.Parameters.Add(param);
                    com.ExecuteNonQuery();
                    break;
            }
            if (pole != "Картинка")
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void maxpicturs()
        {
            string strconnect = "server=localhost;user=root;database=new_schema;password=9032040!!;";
            MySqlConnection conn = new MySqlConnection(strconnect);
            conn.Open();
            string sql = "SET GLOBAL max_allowed_packet=1073741824";
            MySqlCommand command = new MySqlCommand(sql, conn);
            int col = command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
