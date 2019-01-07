using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newwf
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!(textId.Text == string.Empty))
                {
                    if (!(textName.Text == string.Empty))
                    {
                        String str = "Data Source=DESKTOP-KFQPSKO;Initial Catalog=Baitap;Integrated Security=True";
                        String query = "SELECT * FROM Login where Id = '" + textId.Text + "'and NameId = '" + this.textName.Text + "'";
                        SqlConnection con = new SqlConnection(str);
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader db;
                        con.Open();
                        db = cmd.ExecuteReader();
                        int count = 0;
                        while (db.Read())
                        {
                            count = count + 1;
                        }

                        if (count == 1)
                        {
                            MessageBox.Show("username and password is correct");
                        }

                        else if (count > 1)
                        {
                            MessageBox.Show("Duplicate username and password", "login page");
                        }

                        else
                        {
                            MessageBox.Show(" username and password incorrect", "login page");
                        }

                    }
                    else MessageBox.Show("plesse fill in Name");
                }
                else MessageBox.Show("Pleses fill in Id");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
