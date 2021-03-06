﻿using System;
using System.Collections;
using System.IO;

public partial class Pages_Pizza_Add : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthenticateAdministrator();
        string selectedValue = ddlImage.SelectedValue;
        ShowImages();
        ddlImage.SelectedValue = selectedValue;
    }

    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/Images/Pizza/") + filename);
            lblResult.Text = "Image " + filename + " succesfully uploaded!";
            Page_Load(sender, e);
        }
        catch (Exception)
        {
            lblResult.Text = "Upload failed!";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string name = txtName.Text;
            string type = txtType.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            price = price / 100;
            string crust = txtCrust.Text;
            string sause = txtSause.Text;
            string image = "../Images/Pizza/" + ddlImage.SelectedValue;
            string review = txtReview.Text;

            Pizza pizza = new Pizza(name, type, price, crust, sause, image, review);
            ConnectionClass.AddPizza(pizza);
            lblResult.Text = "Upload succesful!";
            ClearTextFields();
        }
        catch (Exception)
        {
            lblResult.Text = "Upload Failed!";
        }
    }
    #endregion

    #region Methods
    private void ShowImages()
    {
        //Get all filepaths
        string[] images = Directory.GetFiles(Server.MapPath("~/Images/Pizza/"));

        //Get all filenames and add them to an arraylist
        ArrayList imageList = new ArrayList();

        foreach (string image in images)
        {
            string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
            imageList.Add(imageName);
        }

        //Set the arrayList as the dropdownview's datasource and refresh
        ddlImage.DataSource = imageList;
        ddlImage.DataBind();
    }

    private void ClearTextFields()
    {
        txtSause.Text = "";
        txtName.Text = "";
        txtPrice.Text = "";
        txtReview.Text = "";
        txtCrust.Text = "";
        txtType.Text = "";
    }

    private void AuthenticateAdministrator()
    {
        if ((string)Session["type"] != "administrator")
        {
            Response.Redirect("~/Pages/Account/Login.aspx");
        }
    }
    #endregion
}