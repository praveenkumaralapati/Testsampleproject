using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ADO.net.APP_CODE.DAC
{
    public class ProductDAC
    {
        public DataSet GetAllProducts()
        {
            //#1.creating sql connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = northwind; Integrated Security = True";
            //#2.sql Datacommand
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "SELECT [ProductID], [ProductName], UnitsInStock,SupplierID, [CategoryID], [UnitPrice], [Discontinued] FROM [Products] ";
            cmd.Connection = con;
            //#3.sql DataApater
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            //#4.Data set
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public bool InsertProduct(string pname, int catid, int disc)
        {
        //#1.Sql connection
        SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = northwind; Integrated Security = True";
            //#2.sql command
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO[Northwind].[dbo].[Products]([ProductName],[CategoryID] ,[Discontinued])VALUES('"+pname+"',"+catid+","+disc+")";
            cmd.Connection = con;
            con.Open();
            int roweffected = cmd.ExecuteNonQuery();
            con.Close();
            if(roweffected>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateProduct(int prodid, string pname, int catid, int disc)
        {
            // 1 Create SqlConnection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = northwind; Integrated Security = True";
            //2 create command object  
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Products set productname = '" + pname + "', CategoryID = " + catid + ", discontinued = " + disc + " where productid = " + prodid;
            cmd.Connection = con;

            //open connection         con.Open(); 

            int rowseffected = cmd.ExecuteNonQuery();

            con.Close();

            if (rowseffected > 0) { return true; }
            else
            {
                return false;

            }

        }
        public bool DeleteProduct(int prodid)
        {
            // 1 Create SqlConnection       
                SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = northwind; Integrated Security = True";
                //2 create command object        
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text; cmd.CommandText = "DELETE FROM [Northwind].[dbo].[Products]WHERE ProductID= " + prodid; cmd.Connection = con;


            //open connection         con.Open(); 

            int rowseffect = cmd.ExecuteNonQuery();


            con.Close();

            if (rowseffect > 0) { return true; }
            else
            {
                return false;

            }

        }


    }
}

