using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADO.net.APP_CODE.DAC;


namespace ADO.net.APP_CODE.DAC
{
    public partial class ado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProductBind();
        }
        public void ProductBind()
        {

#pragma warning disable CS0436 // Type conflicts with imported type
            ProductDAC ado = new ProductDAC();
#pragma warning restore CS0436 // Type conflicts with imported type
            DataSet ds = ado.GetAllProducts();
            if (ds.Tables[0].Rows.Count > 0) {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {             //no records returned. 

            }

        }

    }
    }
