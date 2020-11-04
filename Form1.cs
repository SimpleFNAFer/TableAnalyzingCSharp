using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TableAnalizing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string keycon = "Data Source=DNSNASY\\NASYSERVER;Initial Catalog=INFORMATICS;Integrated Security=True";

        private string[] req = {"SELECT * FROM [INFORMATICS].[dbo].[Students]",
        "CREATE TABLE [INFORMATICS].[dbo].[Results] (ID int, ФИО nvarchar(100), Лагерь nvarchar(100), Статус nchar(10))",
        "INSERT INTO [INFORMATICS].[dbo].[Students] (ФИО, СданныеПрофвзносы, Месяц, Сумма) VALUES (@TEXT1, @TEXT2, @TEXT3, @TEXT4);",
        "INSERT INTO [INFORMATICS].[dbo].[Results] (ID, ФИО, Лагерь, Статус) VALUES (@TEXT1, @TEXT2, @TEXT3, @TEXT4);",
        "SELECT * FROM [INFORMATICS].[dbo].[Results]"};

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlConnection con2 = null;
            SqlCommand cmd = null;
            SqlCommand cmd2 = null;
            SqlDataReader red = null;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                con = new SqlConnection(keycon);
                
                
                
                cmd = new SqlCommand(req[1], con);
                con.Open();
                cmd.ExecuteScalar();
                con.Close();                

                cmd = new SqlCommand(req[0], con);
                con.Open();
                red = cmd.ExecuteReader();

                while(red.Read())
                {
                    string[] temp = { red[0].ToString(), red[1].ToString(), red[2].ToString(), red[3].ToString(), red[4].ToString() };
                    string[] temp2 = { "", "", "", "" };
                    temp2[0] = red[0].ToString();
                    temp2[1] = red[1].ToString();
                    switch (red[3].ToString())
                    {
                        case "январь    ":
                            temp2[2] = "Ступино";
                            break;

                        case "февраль   ":
                            temp2[2] = "Петушки";
                            break;

                        case "март      ":
                            temp2[2] = "Азимут";
                            break;

                        case "апрель    ":
                            temp2[2] = "Совёнок";
                            break;

                        case "май       ":
                            temp2[2] = "Сириус";
                            break;

                        case "июнь      ":
                            temp2[2] = "Созвездие";
                            break;

                        case "июль      ":
                            temp2[2] = "Артек";
                            break;

                        case "август    ":
                            temp2[2] = "Гулаг";
                            break;

                        case "сентябрь  ":
                            temp2[2] = "Океан";
                            break;

                        case "октябрь   ":
                            temp2[2] = "Вудсток";
                            break;

                        case "ноябрь    ":
                            temp2[2] = "Измайлово";
                            break;

                        case "декабрь   ":
                            temp2[2] = "Омск";
                            break;
                    }
                    if (red[2].ToString() == "+")
                    {
                        temp2[3] = "Едет";
                    }
                    else
                    {
                        temp2[3] = "Не едет";
                    }

                    con2 = new SqlConnection(keycon);
                    cmd2 = new SqlCommand(req[3], con2);

                    cmd2.Parameters.AddWithValue("@TEXT1", temp2[0]);
                    cmd2.Parameters.AddWithValue("@TEXT2", temp2[1]);
                    cmd2.Parameters.AddWithValue("@TEXT3", temp2[2]);
                    cmd2.Parameters.AddWithValue("@TEXT4", temp2[3]);
                    con2.Open();
                    cmd2.ExecuteScalar();
                    con2.Close();
                }

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("ФИО", "ФИО");
                dataGridView1.Columns.Add("Лагерь", "Лагерь");
                dataGridView1.Columns.Add("Статус", "Статус");

                red.Close();
                cmd = new SqlCommand(req[4], con);
                red = cmd.ExecuteReader();

                while (red.Read())
                {
                    string[] temp = { red[0].ToString(), red[1].ToString(), red[2].ToString(), red[3].ToString() };
                    /*string[] temp2 = {"", "", "", ""};

                    if (red[2].ToString() == "+")
                    {
                        temp2[0] = red[0].ToString();
                        temp2[1] = red[1].ToString();
                        switch (red[3].ToString())
                        {
                            case "январь    ":
                                temp2[2] = "Ступино";
                                break;

                            case "февраль   ":
                                temp2[2] = "Петушки";
                                break;

                            case "март      ":
                                temp2[2] = "Азимут";
                                break;

                            case "апрель    ":
                                temp2[2] = "Совёнок";
                                break;

                            case "май       ":
                                temp2[2] = "Сириус";
                                break;

                            case "июнь      ":
                                temp2[2] = "Созвездие";
                                break;

                            case "июль      ":
                                temp2[2] = "Артек";
                                break;

                            case "август    ":
                                temp2[2] = "Гулаг";
                                break;

                            case "сентябрь  ":
                                temp2[2] = "Океан";
                                break;

                            case "октябрь   ":
                                temp2[2] = "Вудсток";
                                break;

                            case "ноябрь    ":
                                temp2[2] = "Измайлово";
                                break;

                            case "декабрь   ":
                                temp2[2] = "Омск";
                                break;
                        }
                        temp2[3] = "Едет";
                    }
                    else
                    {
                        temp2[0] = i.ToString();
                        temp2[1] = red[1].ToString();
                        switch (red[3].ToString())
                        {
                            case "январь    ":
                                temp2[2] = "Ступино";
                                break;

                            case "февраль   ":
                                temp2[2] = "Петушки";
                                break;

                            case "март      ":
                                temp2[2] = "Азимут";
                                break;

                            case "апрель    ":
                                temp2[2] = "Совёнок";
                                break;

                            case "май       ":
                                temp2[2] = "Сириус";
                                break;

                            case "июнь      ":
                                temp2[2] = "Созвездие";
                                break;

                            case "июль      ":
                                temp2[2] = "Артек";
                                break;

                            case "август    ":
                                temp2[2] = "Гулаг";
                                break;

                            case "сентябрь  ":
                                temp2[2] = "Океан";
                                break;

                            case "октябрь   ":
                                temp2[2] = "Вудсток";
                                break;

                            case "ноябрь    ":
                                temp2[2] = "Измайлово";
                                break;

                            case "декабрь   ":
                                temp2[2] = "Омск";
                                break;
                        }
                        temp2[3] = "Не едет";
                    }*/
                    dataGridView1.Rows.Add(temp);
                }

                red.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd = new SqlCommand("DROP TABLE [INFORMATICS].[dbo].[Results]", con);
                cmd.ExecuteScalar();
                if ((con.State != ConnectionState.Closed) || (con != null))
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source = DNSNASY\\NASYSERVER; Initial Catalog = INFORMATICS; Integrated Security = True");
                cmd = new SqlCommand(req[2], con);
                if((textBox1.Text != string.Empty)&& (textBox2.Text != string.Empty)&& (textBox3.Text != string.Empty)&& (textBox4.Text != string.Empty))
                {
                    cmd.Parameters.AddWithValue("@TEXT1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@TEXT2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@TEXT3", textBox3.Text);
                    cmd.Parameters.AddWithValue("@TEXT4", textBox4.Text);

                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();

                    refresh();
                }
                else
                {
                    MessageBox.Show("Убедитесь, что все поля заполнены.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if ((con.State != ConnectionState.Closed)||(con != null))
                {
                    con.Close();
                }
            }
        }


        public void refresh()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader red = null;

            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                con = new SqlConnection(keycon);
                cmd = new SqlCommand(req[0], con);
                con.Open();
                red = cmd.ExecuteReader();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("ФИО", "ФИО");
                dataGridView1.Columns.Add("СданныеПрофвзносы", "СданныеПрофвзносы");
                dataGridView1.Columns.Add("Месяц", "Месяц");
                dataGridView1.Columns.Add("Сумма", "Сумма");
                while (red.Read())
                {
                    string[] temp = { red[0].ToString(), red[1].ToString(), red[2].ToString(), red[3].ToString(), red[4].ToString() };

                    dataGridView1.Rows.Add(temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if ((con.State != ConnectionState.Closed) || (con != null))
                {
                    con.Close();
                }
            }
        }
    }
}
