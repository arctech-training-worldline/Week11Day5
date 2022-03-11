using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebServiceDemo
{
    public partial class DemoWebsite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonClickMe_Click(object sender, EventArgs e)
        {
            LabelWelcomeMessage.Text = $"Welcome Dear {TextBoxName.Text}";
        }
    }
}