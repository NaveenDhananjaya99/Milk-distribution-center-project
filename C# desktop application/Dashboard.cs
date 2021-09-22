using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectZ
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
          

            
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
            MySqlConnection con = new MySqlConnection(ConnectDB.ConnectionString);
            con.Open();

            string sql = @"SELECT CUSTOMER_NAME , ADDRESS , O_VOLUME , PRICE  FROM `orders` WHERE DELEVERY_DATE  = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql,con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvOrders.DataSource = dt;
            if (dgvOrders.Rows.Count>0)
            {

                lblNoOfOrders.Text = dt.Rows.Count.ToString() + " Orders";
                lblValue.Text = "Rs : " + dt.Compute("SUM(PRICE)", string.Empty).ToString();
                lblVolume.Text = dt.Compute("SUM(O_VOLUME)", string.Empty).ToString() + " L";
            }
     
            con.Close();
            timerAutoPlay.Start();
        }

        
        int i = 0;
        private void timerAutoPlay_Tick(object sender, EventArgs e)
        {
            if(dgvOrders.RowCount>i)
            {
                dgvOrders.FirstDisplayedScrollingRowIndex = i;
                i++;
                if(dgvOrders.RowCount == i)
                {
                    i = 0;
                }
            }
           
        }


    }
}
