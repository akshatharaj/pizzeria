using System;
using System.Collections;
using System.Text;


public partial class Pages_Pizza : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       FillPage();
    }

   private void FillPage()
   {
       ArrayList pizzaList = new ArrayList();

       if(!IsPostBack)
       {
           pizzaList = ConnectionClass.GetPizzaByType("%");
       }
       else
       {
           pizzaList = ConnectionClass.GetPizzaByType(DropDownList1.SelectedValue);
       }
       
       StringBuilder sb = new StringBuilder();

       foreach (Pizza pizza in pizzaList)
       {
           sb.Append(
               string.Format(
                   @"<table class='pizzaTable'>
            <tr>
                <th rowspan='6' width='150px'><img runat='server' src='{6}' /></th>
                <th width='50px'>Name: </td>
                <td>{0}</td>
            </tr>

            <tr>
                <th>Type: </th>
                <td>{1}</td>
            </tr>

            <tr>
                <th>Price: </th>
                <td>{2} $</td>
            </tr>

            <tr>
                <th>Crust: </th>
                <td>{3}</td>
            </tr>

            <tr>
                <th>Sause: </th>
                <td>{4}</td>
            </tr>

            <tr>
                <td colspan='2'>{5}</td>
            </tr>           
            
           </table>",
                   pizza.Name, pizza.Type, pizza.Price, pizza.Crust, pizza.Sause, pizza.Review, pizza.Image));

           lblOuput.Text = sb.ToString();

       }

       
   }
   protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
   {
       FillPage();
   }
}