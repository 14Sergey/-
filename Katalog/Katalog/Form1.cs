using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using xNet;
using Newtonsoft.Json.Linq;

namespace курсовой
{
    public partial class Form1 : Form
    {
        int regim = 0;
        int nomertovar;
        bool pol = false;
        bool razmer = false;
        bool sostav = false;
        bool sortirovat = false;
        bool AddDeltovar = false;
        static int page = 1;
        static int tekpage = 1;
        public VseTovari vsetovari = new VseTovari();
        public VseTovari sorttovari = new VseTovari();
        bool[] sixtovar = new bool[6];
        bool[] sortirovka = new bool[3];
        bool[] vidchekedlistbox = new bool[3] {false,false,false };
        public Form1()
        {
            Tovar.maxpicturs();
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            int id = 1;
            while (true)
            {
                if (!Tovar.tovar(id, ref vsetovari))
                    break;
                id++;
            }
            SortRazmer();
            SortSostav();
            page = (vsetovari.tovari.Count - 1) / 6 + 1;
            vivod(vsetovari);
        }
        public void SortRazmer()
        {
            checkedListBox2.Items.Clear();
            List<string> list = new List<string>();
            int key = 0;
            foreach (Tovar tov in vsetovari.tovari)
            {
                foreach (string razm in tov.razmer)
                {
                    foreach (string elem in list)
                    {
                        if (razm == elem)
                            key = 1;
                    }
                    if (key == 0)
                        list.Add(razm);
                    key = 0;
                }
            }
            list.Sort();
            foreach (string elem in list)
                checkedListBox2.Items.Add(elem);
        }
        public void SortSostav()
        {
            checkedListBox3.Items.Clear();
            List<string> list = new List<string>();
            int key = 0;
            foreach (Tovar tov in vsetovari.tovari)
            {
                foreach (string sost in tov.sostav)
                {
                    foreach (string elem in list)
                    {
                        if (sost == elem)
                            key = 1;
                    }
                    if (key == 0)
                        list.Add(sost);
                    key = 0;
                }
            }
            list.Sort();
            foreach (string elem in list)
                checkedListBox3.Items.Add(elem);
        }
        public void vivod(VseTovari vsetov)
        {
            int id = 1;
            if (tekpage == 1)
            {
                button7.Enabled = false;
                button8.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
                button8.Enabled = true;
            }
            if (tekpage == page)
            {
                button10.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                button10.Enabled = true;
                button9.Enabled = true;
            }
            if (page < 10)
                label8.Text = "    " + tekpage + "/" + page;
            if (page >= 10 && page < 100)
                label8.Text = "  " + tekpage + "/" + page;
            if (page >= 100)
                label8.Text = tekpage + "/" + page;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            label13.Visible = false;
            pictureBox1.Visible = false;
            button1.Visible = false;
            label14.Visible = false;
            pictureBox2.Visible = false;
            button2.Visible = false;
            label15.Visible = false;
            pictureBox3.Visible = false;
            button3.Visible = false;
            label16.Visible = false;
            pictureBox4.Visible = false;
            button4.Visible = false;
            label17.Visible = false;
            pictureBox5.Visible = false;
            button5.Visible = false;
            label18.Visible = false;
            pictureBox6.Visible = false;
            button6.Visible = false;
            foreach (var tov in vsetov.tovari)
            {
                if (tekpage * 6 - 5 == id)
                {
                    label13.Visible = true;
                    pictureBox1.Visible = true;
                    button1.Visible = true;
                    label13.Text = tov.name + "\n" + rublcost(tov.cost) + "p. " + kopcost(tov.cost) + "коп.";
                    if (tov.img != null)
                        pictureBox1.Image = tov.img;
                }
                if (tekpage * 6 - 4 == id)
                {
                    label14.Visible = true;
                    pictureBox2.Visible = true;
                    button2.Visible = true;
                    label14.Text = tov.name + "\n" + rublcost(tov.cost) + "p. " + kopcost(tov.cost) + "коп.";
                    if (tov.img != null)
                        pictureBox2.Image = tov.img;
                }
                if (tekpage * 6 - 3 == id)
                {
                    label15.Visible = true;
                    pictureBox3.Visible = true;
                    button3.Visible = true;
                    label15.Text = tov.name + "\n" + rublcost(tov.cost) + "p. " + kopcost(tov.cost) + "коп.";
                    if (tov.img != null)
                        pictureBox3.Image = tov.img;
                }
                if (tekpage * 6 - 2 == id)
                {
                    label16.Visible = true;
                    pictureBox4.Visible = true;
                    button4.Visible = true;
                    label16.Text = tov.name + "\n" + rublcost(tov.cost) + "p. " + kopcost(tov.cost) + "коп.";
                    if (tov.img != null)
                        pictureBox4.Image = tov.img;
                }
                if (tekpage * 6 - 1 == id)
                {
                    label17.Visible = true;
                    pictureBox5.Visible = true;
                    button5.Visible = true;
                    label17.Text = tov.name + "\n" + rublcost(tov.cost) + "p. " + kopcost(tov.cost) + "коп.";
                    if (tov.img != null)
                        pictureBox5.Image = tov.img;
                }
                if (tekpage * 6 == id)
                {
                    label18.Visible = true;
                    pictureBox6.Visible = true;
                    button6.Visible = true;
                    label18.Text = tov.name + "\n" + rublcost(tov.cost) + "p. " + kopcost(tov.cost) + "коп.";
                    if (tov.img != null)
                        pictureBox6.Image = tov.img;
                    break;
                }
                id++;
            }
        }
        public void biginf(int pozitsia, VseTovari vsetov)
        {
            int id = 1;
            int tekpagedop;
            if (pozitsia == 6)
            {
                tekpagedop = 0;
                pozitsia = -1;
            }
            else
                tekpagedop = tekpage;
            foreach (var tov in vsetov.tovari)
            {
                if (id == tekpagedop * 6 - pozitsia)
                {
                    nomertovar = tov.nomer;
                    button20.Enabled = false;
                    button12.Enabled = false;
                    sixtovar[0] = pictureBox1.Visible;
                    sixtovar[1] = pictureBox2.Visible;
                    sixtovar[2] = pictureBox3.Visible;
                    sixtovar[3] = pictureBox4.Visible;
                    sixtovar[4] = pictureBox5.Visible;
                    sixtovar[5] = pictureBox6.Visible;
                    label13.Visible = false;
                    pictureBox1.Visible = false;
                    button1.Visible = false;
                    label14.Visible = false;
                    pictureBox2.Visible = false;
                    button2.Visible = false;
                    label15.Visible = false;
                    pictureBox3.Visible = false;
                    button3.Visible = false;
                    label16.Visible = false;
                    pictureBox4.Visible = false;
                    button4.Visible = false;
                    label17.Visible = false;
                    pictureBox5.Visible = false;
                    button5.Visible = false;
                    label18.Visible = false;
                    pictureBox6.Visible = false;
                    button6.Visible = false;
                    label8.Visible = false;
                    button7.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    pictureBox7.Visible = true;
                    button13.Visible = true;
                    label19.Visible = true;
                    label20.Visible = true;
                    label21.Visible = true;
                    label23.Visible = true;
                    linkLabel1.Visible = false;
                    linkLabel2.Visible = false;
                    linkLabel3.Visible = false;
                    sortirovka[0] = checkedListBox1.Visible;
                    sortirovka[1] = checkedListBox2.Visible;
                    sortirovka[2] = checkedListBox3.Visible;
                    checkedListBox1.Visible = false;
                    checkedListBox2.Visible = false;
                    checkedListBox3.Visible = false;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label12.Visible = false;
                    pictureBox7.Image = tov.img;
                    if(regim==2)
                    {
                        label2.Visible = false;
                        label3.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label20.Visible = false;
                        label16.Visible = false;
                        textBox4.Visible = true;
                        textBox5.Visible = true;
                        textBox6.Visible = true;
                        textBox17.Visible = true;
                        comboBox1.Visible = true;
                        textBox4.Text = tov.name;
                        textBox5.Text = tov.artik.ToString();
                        foreach (string elem in tov.razmer)
                            textBox6.Text += elem+" ";
                        textBox17.Text = tov.cost.ToString();
                        comboBox1.SelectedItem = tov.pol;
                        int j = 0;
                        foreach(string elem in tov.sostav)
                        {
                            switch(j)
                            {
                                case 0: textBox8.Visible = true; textBox7.Visible = true; textBox10.Visible = true; textBox9.Visible = true; textBox8.Text = elem; textBox7.Text = tov.protsent[j]; break;
                                case 1: textBox10.Visible = true; textBox9.Visible = true; textBox12.Visible = true; textBox11.Visible = true; textBox10.Text = elem; textBox9.Text = tov.protsent[j]; break;
                                case 2: textBox12.Visible = true; textBox11.Visible = true; textBox14.Visible = true; textBox13.Visible = true; textBox12.Text = elem; textBox11.Text = tov.protsent[j]; break;
                                case 3: textBox14.Visible = true; textBox13.Visible = true; textBox16.Visible = true; textBox15.Visible = true; textBox14.Text = elem; textBox13.Text = tov.protsent[j]; break;
                                case 4: textBox16.Visible = true; textBox15.Visible = true; textBox16.Text = elem; textBox15.Text = tov.protsent[j]; break;
                            }
                            j++;
                        }
                        button21.Visible = true;
                        button14.Visible = true;
                        button15.Visible = true;
                    }
                    label2.Text = tov.name;
                    label20.Text = rublcost(tov.cost) + "р. " + kopcost(tov.cost) + "коп.";
                    label21.Text = "Артикул:\nПол:\nРазмеры:";
                    label3.Text = "" + tov.artik;
                    label4.Text = "" + tov.pol;
                    label5.Text = "";
                    int i = 0;
                    foreach (string elem in tov.razmer)
                    {
                        if (i % 10 == 0 && i != 0)
                        {
                            label5.Text += "\n";
                        }
                        label5.Text += elem + " ";
                        i++;
                    }
                    label6.Text = "";
                    for (i = 0; i < tov.sostav.Length; i++)
                        label6.Text += tov.sostav[i] + " " + tov.protsent[i] + "%\n";
                    break;
                }
                id++;
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            NonBigInf();
        }
        public int rublcost(float cost)
        {
            int rubl = (int)cost;
            return rubl;
        }
        public string kopcost(float cost)
        {
            string th = Convert.ToString(cost);
            char[] thchar = th.ToCharArray();
            bool key = false;
            string kop="";
            foreach(char elem in thchar)
            {
                if(elem==',')
                {
                    key = true;
                    continue;
                }
                if(key)
                    kop += elem;
            }
            if (!key)
                kop = "0";
            return kop;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (sortirovat)
                biginf(5, sorttovari);
            else
                biginf(5, vsetovari);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (sortirovat)
                biginf(4, sorttovari);
            else
                biginf(4, vsetovari);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (sortirovat)
                biginf(3, sorttovari);
            else
                biginf(3, vsetovari);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sortirovat)
                biginf(2, sorttovari);
            else
                biginf(2, vsetovari);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (sortirovat)
                biginf(1, sorttovari);
            else
                biginf(1, vsetovari);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sortirovat)
                biginf(0, sorttovari);
            else
                biginf(0, vsetovari);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pol)
            {
                linkLabel1.Text = "Пол >";
                checkedListBox1.Visible = false;
                pol = false;
                if (razmer)
                {
                    linkLabel2.Top = 245;
                    checkedListBox2.Top = 265;
                    linkLabel3.Top = 390;
                    checkedListBox3.Top = 410;
                }
                else
                {
                    linkLabel2.Top = 245;
                    checkedListBox2.Top = 265;
                    linkLabel3.Top = 265;
                    checkedListBox3.Top = 285;
                }

            }
            else
            {
                linkLabel1.Text = "Пол ~";
                checkedListBox1.Visible = true;
                pol = true;
                if (razmer)
                {
                    linkLabel2.Top = 370;
                    checkedListBox2.Top = 390;
                    linkLabel3.Top = 515;
                    checkedListBox3.Top = 535;
                }
                else
                {
                    linkLabel2.Top = 370;
                    checkedListBox2.Top = 390;
                    linkLabel3.Top = 390;
                    checkedListBox3.Top = 410;
                }

            }

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (razmer)
            {
                linkLabel2.Text = "Размер >";
                checkedListBox2.Visible = false;
                razmer = false;
                if (pol)
                {
                    linkLabel3.Top = 390;
                    checkedListBox3.Top = 410;
                }
                else
                {
                    linkLabel3.Top = 265;
                    checkedListBox3.Top = 285;
                }

            }
            else
            {
                linkLabel2.Text = "Размер ~";
                checkedListBox2.Visible = true;
                razmer = true;
                if (pol)
                {
                    linkLabel3.Top = 515;
                    checkedListBox3.Top = 535;
                }
                else
                {
                    linkLabel3.Top = 390;
                    checkedListBox3.Top = 410;
                }

            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sostav)
            {
                linkLabel3.Text = "Состав >";
                checkedListBox3.Visible = false;
                sostav = false;
            }
            else
            {
                linkLabel3.Text = "Состав ~";
                checkedListBox3.Visible = true;
                sostav = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tekpage--;
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tekpage++;
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tekpage = 1;
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tekpage = page;
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tekpage = 1;
            SortVse();
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tekpage = 1;
            SortVse();
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            tekpage = 1;
            SortVse();
            if (sortirovat)
                vivod(sorttovari);
            else
                vivod(vsetovari);
        }
        private void SortVse()
        {
            if (checkedListBox1.CheckedItems.Count != 0 || checkedListBox2.CheckedItems.Count != 0 || checkedListBox3.CheckedItems.Count != 0)
            {
                sorttovari.tovari.Clear();
                sortirovat = true;
                string[] kriterii = new string[checkedListBox1.CheckedItems.Count + checkedListBox2.CheckedItems.Count + checkedListBox3.CheckedItems.Count];
                int i = 0;
                foreach (string elem in checkedListBox1.CheckedItems)
                {
                    kriterii[i] = elem;
                    i++;
                }
                foreach (string elem in checkedListBox2.CheckedItems)
                {
                    kriterii[i] = elem;
                    i++;
                }
                foreach (string elem in checkedListBox3.CheckedItems)
                {
                    kriterii[i] = elem;
                    i++;
                }
                bool key = false;
                foreach (Tovar tov in vsetovari.tovari)
                {
                    foreach (string elem in kriterii)
                    {
                        if (elem == tov.pol)
                        {
                            sorttovari.tovari.Add(tov);
                            break;
                        }
                        foreach (string razm in tov.razmer)
                            if (elem == razm)
                            {
                                sorttovari.tovari.Add(tov);
                                key = true;
                                break;
                            }
                        if (key)
                            break;
                        foreach (string sost in tov.sostav)
                            if (elem == sost)
                            {
                                sorttovari.tovari.Add(tov);
                                key = true;
                                break;
                            }
                        if (key)
                            break;
                    }
                    key = false;
                }
                page = (sorttovari.tovari.Count - 1) / 6 + 1;
                return;
            }
            sortirovat = false;
            page = (vsetovari.tovari.Count - 1) / 6 + 1;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            var sait = new HttpRequest();
            try
            {
                string response = sait.Get("https://oauth.vk.com/token?grant_type=password&client_id=2274003&client_secret=hHbZxrka2uZ6jB1inYsH&username=" + textBox2.Text + "&password=" + textBox3.Text).ToString();
                dynamic json = JObject.Parse(response);
                if (response.Contains("user_id"))
                {
                    textBox3.Text = "";
                    string strconnect = "server=localhost;user=root;database=new_schema;password=9032040!!;";
                    MySqlConnection conn = new MySqlConnection(strconnect);
                    conn.Open();
                    string sql = "SELECT admin FROM table_admin";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    conn.Clone();
                    if (textBox2.Text == command.ExecuteScalar().ToString())
                        regim = 2;
                    else
                        regim = 1;
                    Activition();
                    button11.Visible = false;
                    button20.Visible = true;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label12.Visible = true;
                    linkLabel1.Visible = true;
                    linkLabel2.Visible = true;
                    linkLabel3.Visible = true;
                    checkedListBox1.Visible = vidchekedlistbox[0];
                    checkedListBox2.Visible = vidchekedlistbox[1];
                    checkedListBox3.Visible = vidchekedlistbox[2];
                    tekpage = 1;
                    vivod(vsetovari);
                }
            }
            catch
            {
                MessageBox.Show("Авторизироваться не удалось!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Activition()
        {
            switch (regim)
            {
                case 0:
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    label12.Visible = false;
                    linkLabel1.Visible = false;
                    linkLabel2.Visible = false;
                    linkLabel3.Visible = false;
                    vidchekedlistbox[0] = checkedListBox1.Visible;
                    vidchekedlistbox[1] = checkedListBox2.Visible;
                    vidchekedlistbox[2] = checkedListBox3.Visible;
                    checkedListBox1.Visible = false;
                    checkedListBox2.Visible = false;
                    checkedListBox3.Visible = false;
                    label11.Visible = false;
                    button11.Visible = true;
                    button12.Visible = false;
                    label9.Visible = true;
                    label10.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    button20.Visible = false;
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        checkedListBox1.SetItemChecked(i, false);
                    for (int i = 0; i < checkedListBox2.Items.Count; i++)
                        checkedListBox2.SetItemChecked(i, false);
                    for (int i = 0; i < checkedListBox3.Items.Count; i++)
                        checkedListBox3.SetItemChecked(i, false);
                    tekpage = 1;
                    page = (vsetovari.tovari.Count - 1) / 6 + 1;
                    sortirovat = false;
                    vivod(vsetovari);
                    break;
                case 1:
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;             
                    break;
                case 2:
                    label11.Visible = true;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button12.Visible = true;
                    break;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox2.Text == "")
                button11.Enabled = false;
            else
                button11.Enabled = true;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
                button11.Enabled = false;
            else
                button11.Enabled = true;
        }
        private void button12_Click(object sender, EventArgs e)
        {    
            int artik = 0;
            bool key;
            while (true)
            {
                key = true;
                foreach (Tovar tov in vsetovari.tovari)
                {
                    if (artik == tov.artik)
                    {
                        artik++;
                        key = false;
                        break;
                    }
                }
                if (key)
                    break;
            }
            string[] razmer = { "8" };
            string[] sostav = { "натуральная кожа" };
            string[] prot = { "100" };
            Tovar elem = new Tovar(vsetovari.tovari.Count + 1, artik, "Название", "мужские", razmer,sostav,prot, 0, null);
            vsetovari.addtovar(elem);
            Tovar.AddBasdata(elem);
            AddDeltovar = true;
            biginf(6,vsetovari);
        }      
        private void button20_Click(object sender, EventArgs e)
        {
            regim = 0;
            Activition();
        }
        public void NonBigInf()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button12.Enabled = true;
            button20.Enabled = true;
            label13.Visible = sixtovar[0];
            pictureBox1.Visible = sixtovar[0];
            button1.Visible = sixtovar[0];
            label14.Visible = sixtovar[1];
            pictureBox2.Visible = sixtovar[1];
            button2.Visible = sixtovar[1];
            label15.Visible = sixtovar[2];
            pictureBox3.Visible = sixtovar[2];
            button3.Visible = sixtovar[2];
            label16.Visible = sixtovar[3];
            pictureBox4.Visible = sixtovar[3];
            button4.Visible = sixtovar[3];
            label17.Visible = sixtovar[4];
            pictureBox5.Visible = sixtovar[4];
            button5.Visible = sixtovar[4];
            label18.Visible = sixtovar[5];
            pictureBox6.Visible = sixtovar[5];
            button6.Visible = sixtovar[5];
            if (regim == 2)
            {
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                comboBox1.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button21.Visible = false;
                comboBox1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox13.Visible = false;
                textBox14.Visible = false;
                textBox15.Visible = false;
                textBox16.Visible = false;
                textBox17.Visible = false;
                label6.Visible = false;
                SaveTovar();
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox6.Text = "";
                if (AddDeltovar)
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        checkedListBox1.SetItemChecked(i, false);
                    for (int i = 0; i < checkedListBox2.Items.Count; i++)
                        checkedListBox2.SetItemChecked(i, false);
                    for (int i = 0; i < checkedListBox3.Items.Count; i++)
                        checkedListBox3.SetItemChecked(i, false);
                    SortRazmer();
                    SortSostav();
                    sortirovat = false;
                    AddDeltovar = false;
                    tekpage = 1;
                }
                if (sortirovat)
                {
                    page = (sorttovari.tovari.Count - 1) / 6 + 1;
                    vivod(sorttovari);
                }
                else
                {
                    page = (vsetovari.tovari.Count - 1) / 6 + 1;
                    vivod(vsetovari);
                }
            }
            label8.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            pictureBox7.Visible = false;
            button13.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label23.Visible = false;
            linkLabel1.Visible = true;
            linkLabel2.Visible = true;
            linkLabel3.Visible = true;
            checkedListBox1.Visible = sortirovka[0];
            checkedListBox2.Visible = sortirovka[1];
            checkedListBox3.Visible = sortirovka[2];
            label12.Visible = true;
            label4.Visible = false;
        }
        private void button21_Click(object sender, EventArgs e)
        {
            AddDeltovar = true;
            Tovar.DelBasdata(nomertovar,vsetovari.tovari.Count);
            Tovar tovdel = new Tovar();
            foreach(Tovar tov in vsetovari.tovari)
            {
                if (tov.nomer == nomertovar)
                {
                    tovdel = tov;
                    break;
                }
                else
                    tov.nomer--;
            }
            vsetovari.tovari.Remove(tovdel);
            NonBigInf();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Tovar.ChangeBasdata(nomertovar,"Картинка","",null);
            pictureBox7.Image = null;
            foreach(Tovar tov in vsetovari.tovari)
                if (tov.nomer == nomertovar)
                {
                    tov.img = null;
                    break;
                }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.JPG;*.PNG)|*.JPG;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox7.Image = new Bitmap(ofd.FileName);
                    Tovar.ChangeBasdata(nomertovar, "Картинка","", pictureBox7.Image);
                    foreach (Tovar tov in vsetovari.tovari)
                        if (tov.nomer == nomertovar)
                        {
                            tov.img = pictureBox7.Image;
                            break;
                        }
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть файл!", "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            char[] str = textBox17.Text.ToCharArray();
            foreach (char ch in str)
            {
                if (ch == ',')
                    if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                        return;
                    }

            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 44)
                e.Handled = true;
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            char[] str = textBox6.Text.ToCharArray();
            int dlina = 0;
            foreach(char ch in str)
            {
                if (ch != ' ')
                    dlina++;
                else
                    dlina = 0;
            }
            if (dlina == 2)
                if (e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                    return;
                }
            if(dlina==0)
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                    {
                        e.Handled = true;
                        return;
                    }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                e.Handled = true;
        }
        public void SaveTovar()
        {
            string str = (string)comboBox1.SelectedItem;
            foreach (Tovar tov in vsetovari.tovari)
                if (tov.nomer == nomertovar)
                {
                    if (tov.pol != str)
                    {
                        tov.pol = str;
                        Tovar.ChangeBasdata(nomertovar, "Пол", str, null);
                    }
                    str = textBox4.Text;
                    tov.name = str;
                    Tovar.ChangeBasdata(nomertovar, "Название", str, null);
                    str = textBox5.Text;
                    if (str != "")
                    {
                        tov.artik = Convert.ToInt32(str);
                        Tovar.ChangeBasdata(nomertovar, "Артикул", str, null);
                    }
                    else
                    {
                        tov.artik = 0;
                        Tovar.ChangeBasdata(nomertovar, "Артикул", "0", null);
                    }
                    str = textBox17.Text;
                    if (str != "")
                    {
                        tov.cost = Convert.ToSingle(str);
                        char[] strchar = str.ToCharArray();
                        int i = 0;
                        str = "";
                        while (i < strchar.Length)
                        {
                            if (strchar[i] == ',')
                                strchar[i] = '.';
                            str += strchar[i];
                            i++;
                        }
                        Tovar.ChangeBasdata(nomertovar, "Цена", str, null);
                    }
                    else
                    {
                        tov.cost = 0;
                        Tovar.ChangeBasdata(nomertovar, "Цена", "0", null);
                    }
                    str = textBox6.Text;
                    List<string> coll = new List<string>();
                    if (str != "")
                    {
                        char[] strrazm = str.ToCharArray();
                        if(strrazm[strrazm.Length-1]!=' ')
                        {
                            str += ' ';
                            strrazm = str.ToCharArray();
                        }
                        str = "";
                        int th = 0;
                        foreach (char ch in strrazm)
                        {
                            if (ch != ' ')
                                th = th * 10 + Convert.ToInt32(Convert.ToString(ch));
                            else
                            {
                                coll.Add(Convert.ToString(th));
                                th = 0;
                            }
                        }
                        string[] newrazmer=coll.ToArray();
                        tov.razmer = newrazmer;
                        foreach (string elem in tov.razmer)
                            str += elem + " ";
                        Tovar.ChangeBasdata(nomertovar, "Размер", str, null);
                    }
                    else
                    {
                        tov.razmer = new string[] {"8"};
                        Tovar.ChangeBasdata(nomertovar, "Размер", "8 ", null);
                    }
                    coll.Clear();
                    List<string> coll2 = new List<string>();
                    if (textBox8.Text != "" && textBox7.Text != "")
                    {
                        coll.Add(textBox7.Text);
                        coll2.Add(textBox8.Text);
                    }
                    if (textBox10.Text != "" && textBox9.Text != "")
                    {
                        coll.Add(textBox9.Text);
                        coll2.Add(textBox10.Text);
                    }
                    if (textBox12.Text != "" && textBox11.Text != "")
                    {
                        coll.Add(textBox11.Text);
                        coll2.Add(textBox12.Text);
                    }
                    if (textBox14.Text != "" && textBox13.Text != "")
                    {
                        coll.Add(textBox13.Text);
                        coll2.Add(textBox14.Text);
                    }
                    if (textBox16.Text != "" && textBox15.Text != "")
                    {
                        coll.Add(textBox15.Text);
                        coll2.Add(textBox16.Text);
                    }
                    if (coll.Count != 0)
                    {
                        string[] newprot = coll.ToArray();
                        tov.protsent = newprot;
                        string[] newsort = coll2.ToArray();
                        tov.sostav = newsort;
                    }
                    else
                    {
                        tov.sostav = new string[] { "натуральная кожа" };
                        tov.protsent = new string[] { "100" };
                    }
                    str = "";
                    foreach(string elem in tov.sostav)
                        str += elem + "0";
                    Tovar.ChangeBasdata(nomertovar, "Составы", str, null);
                    str = "";
                    foreach (string elem in tov.protsent)
                        str += elem + " ";
                    Tovar.ChangeBasdata(nomertovar, "Проценты", str, null);
                    break;
                }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
        }
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
        }
        private void comboBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
        }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddDeltovar = true;
        }
    }
}
