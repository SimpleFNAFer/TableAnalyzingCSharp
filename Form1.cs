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

        private string[] req = {"SELECT * FROM [INFORMATICS].[dbo].[Students]",
        "CREATE TABLE Results (ID int, ФИО nvarchar(100), Лагерь nvarchar(100), Статус nchar(10))"};

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader red = null;

            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                con = new SqlConnection("Data Source=DNSNASY\\NASYSERVER;Initial Catalog=INFORMATICS;Integrated Security=True");
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
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader red = null;
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                
                con = new SqlConnection("Data Source=DNSNASY\\NASYSERVER;Initial Catalog=INFORMATICS;Integrated Security=True");
                /*cmd = new SqlCommand(req[1], con);
                con.Open();
                cmd.ExecuteScalar();
                con.Close();*/

                cmd = new SqlCommand(req[0], con);
                con.Open();
                red = cmd.ExecuteReader();

                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("ФИО", "ФИО");
                dataGridView1.Columns.Add("Лагерь", "Лагерь");
                dataGridView1.Columns.Add("Статус", "Статус");
                int i = 1;

                while (red.Read())
                {
                    string[] temp = { red[0].ToString(), red[1].ToString(), red[2].ToString(), red[3].ToString(), red[4].ToString() };
                    string[] temp2 = {"", "", "", ""};

                    if (red[2].ToString() == "+")
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
                    }
                    dataGridView1.Rows.Add(temp2);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
    }
}
