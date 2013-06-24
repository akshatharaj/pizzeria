using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using Entities;

namespace Pages
{
    public partial class Pages_OrdersDetailed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckIfAdministrator();
            lblTitle.Text = string.Format("<h2>Client: {0}<br />Date: {1}</h2>", Request.QueryString["client"], Request.QueryString["date"]);
        }

        protected void btnShip_Click(object sender, EventArgs e)
        {
            //Get variables from Url
            string client = Request.QueryString["client"];
            DateTime date = Convert.ToDateTime(Request.QueryString["date"]);

            //Get user info + user's placed orders
            User user = ConnectionClass.GetUserDetails(client);
            ArrayList orderList = ConnectionClass.GetDetailedOrders(client, date);

            //Update database and send confirmation e-mail. Afterwards send user back to 'Orders' Page
            ConnectionClass.UpdateOrders(client, date);
            SendEmail(user.Name, user.Email, orderList);
            Response.Redirect("~/Pages/Orders.aspx");
        }

        private void CheckIfAdministrator()
        {
            if ((string)Session["type"] != "administrator")
            {
                Response.Redirect("~/Pages/Account/Login.aspx");
            }
        }

        private void SendEmail(string client, string email, ArrayList orderList)
        {
            MailMessage msg = new MailMessage();
            System.Net.Mail.SmtpClient mail_client = new System.Net.Mail.SmtpClient();
            MailAddress to = new MailAddress(email);			
			//TODO: Fill in your own e-mail here!
            MailAddress from = new MailAddress("akshatharaj31@gmail.com");
            string body = string.Format(
@"Dear {0},
We are happy to announce that your order placed on {1} has been completed and is ready for pickup.

Your ordered products:
{2}

You can come collect your order at your earliest convienence.

Kind regards
Akshatha", client, Request.QueryString["date"], GenerateOrderedItems(orderList));
                msg.Subject = "Pizzeria: Your order has been prepared";
                msg.Body = body;
                msg.From = from;
                msg.To.Add(to);
                mail_client.Host = "smtp.gmail.com";
                System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("akshatharaj31@gmail.com", "Maggeraj31");
                mail_client.Port = int.Parse("587");
                mail_client.EnableSsl = true;
                mail_client.UseDefaultCredentials = false;
                mail_client.Credentials = basicauthenticationinfo;
                mail_client.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail_client.Send(msg);
        }

        private string GenerateOrderedItems(ArrayList orderList)
        {
            string result = "";
            double totalAmount = 0;

            foreach (Order order in orderList)
            {
                result += string.Format(@"
- {0} ({1} $)           X {2}                 = {3} $",
                    order.Product, order.Price, order.Amount, (order.Amount * order.Price));
                totalAmount += (order.Amount * order.Price);
            }

            result += string.Format(@"

Total Amount: {0} $", totalAmount);
            return result;
        }
        protected void sds_DetailedOrder_Selecting(object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
        {

        }
}
}