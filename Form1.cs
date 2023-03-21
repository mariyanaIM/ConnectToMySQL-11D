using MySqlConnector;

namespace ConnectToMySQL_11D
{
    public partial class Form1 : Form
    {
        string connstr = "server =192.168.1.235;" +
            "port = 3306" +
            "user = REMOTE" +
            "pasword=123456@" +
            "database=minions";
        MySqlConnection connect;
        MySqlCommand query;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect = new MySqlConnection(connstr);
            if(connect.State==0) connect.Open();
            MessageBox.Show("Conections NOW opened");
            string sql = "Select minions.id, minions.Name, mimions.Age" + "From minions";
            query = new MySqlCommand(sql, connect);
            MySqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add($"{reader[0]} --> {reader[1]} age: {reader[2]}");
            }
            reader.Close();

        }
    }
}