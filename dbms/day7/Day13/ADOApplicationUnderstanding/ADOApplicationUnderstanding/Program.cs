using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOApplicationUnderstanding
{
    class Program
    {
        SqlConnection conn;
        public Program()
        {
            conn = new SqlConnection(@"Data Source=KANINI-LTP-476\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=dbCompany06Sep21");
            //conn.Open();
            //Console.WriteLine("connection opened");
        }

        void GetEmployeeDataFromDatabase()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Employees";
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Employee ID "+dr[0]);
                Console.WriteLine("Employee Name " + dr[1]);
                Console.WriteLine("Employee Age " + dr[2]);
                Console.WriteLine("-------------------------------------------");
            }
            conn.Close();
        }
        void GetEmployeeDataFromDatabaseDiscon()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Employees";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds); //connect-fetchdata-put in dataset-disconnect
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("Employee ID " + dr[0]);
                Console.WriteLine("Employee Name " + dr[1]);
                Console.WriteLine("Employee Age " + dr[2]);
                Console.WriteLine("-------------------------------------------");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.GetEmployeeDataFromDatabase();
            //program.InsertEmployee();
            //program.UpdateEmployee();
            program.DeleteEmployee();
            program.GetEmployeeDataFromDatabaseDiscon();
            Console.ReadKey();
        }

        private void InsertEmployee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Employees(name,age) values(@ename,@eage)";
            Console.WriteLine("please enter the employee name");
            string name = Console.ReadLine();
            Console.WriteLine("please enter the employee age");
            int age = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@ename", name);
            cmd.Parameters.AddWithValue("@eage", age);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            if(result>0)
                Console.WriteLine("employee added");
            else
                Console.WriteLine("not added");
        }
        private void UpdateEmployee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Employees set name=@ename where id=@eid";
            Console.WriteLine("please enter the employee id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter the employee name");
            string name = Console.ReadLine();
            cmd.Parameters.AddWithValue("@eid", id);
            cmd.Parameters.AddWithValue("@ename", name);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("employee added");
            else
                Console.WriteLine("not added");
        }
        private void DeleteEmployee()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete from Employees where id=@eid";
            Console.WriteLine("please enter the employee id");
            int id = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@eid", id);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("employee added");
            else
                Console.WriteLine("not added");
        }
    }
}
