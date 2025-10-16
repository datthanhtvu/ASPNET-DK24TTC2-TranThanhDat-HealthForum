using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Data;
using MyWebSite.Business;
using MyWebSite.Common;

namespace MyWebSite.Admins
{

    public partial class CommentCheck : System.Web.UI.Page
    {
        static string Id = "";
        static string Enquiry_Id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnUpdate.Visible = false;
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                //LoadFilterDrop();
                //LoadDrop();
                //PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                View();
            }
        }
        private void View()
        {
            grdComment.DataSource = CommentService.Comment_GetByTop("", "", "[Active] ASC,[Date]");
            grdComment.DataBind();
            if (grdComment.PageCount <= 1)
            {
                grdComment.PagerStyle.Visible = false;
            }
        }
        //void LoadFilterDrop()
        //{
        //    ddlFilterEnquiry.Items.Clear();
        //    ddlFilterEnquiry.Items.Add(new ListItem("--Tất cả--", ""));
        //    List<MyWebSite.Data.Enquiry> list = EnquiryService.Enquiryt_GetByTop("", "", "");
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        ddlFilterEnquiry.Items.Add(list[i].Name);
        //    }
        //    ddlFilterEnquiry.DataBind();
        //}
        //void LoadDrop()
        //{
        //    ddlGroupNews.Items.Clear();
        //    ddlGroupNews.Items.Add(new ListItem("-Chọn nhóm tin-", ""));
        //    List<MyWebSite.Data.GroupNews> list = GroupNewsService.GroupNews_GetByTop("", "", "  [Level], Ord, Id ");
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        ddlGroupNews.Items.Add(new ListItem(StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
        //    }
        //    ddlGroupNews.DataBind();

        //}
        //protected void Filter_Click(object sender, EventArgs e)
        //{
        //    string strWhere = " 1=1 ";
        //    if (StringClass.Check(ddlFilterEnquiry.SelectedValue))
        //    {
        //        strWhere += " and GroupNewsId = '" + ddlFilterEnquiry.SelectedValue + "'";
        //    }
        //    if (StringClass.Check(txtFilterName.Text))
        //    {
        //        strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
        //    }
        //    if (StringClass.Check(txtFilterDateF.Text) && StringClass.Check(txtFilterDateT.Text) == false)
        //    {
        //        txtFilterDateF.Text = txtFilterDateT.Text;
        //    }
        //    if (StringClass.Check(txtFilterDateF.Text) == false && StringClass.Check(txtFilterDateT.Text))
        //    {
        //        txtFilterDateF.Text = txtFilterDateT.Text;
        //    }
        //    if (StringClass.Check(txtFilterDateF.Text) && StringClass.Check(txtFilterDateT.Text))
        //    {
        //        strWhere += " and convert(nvarchar(10), Date, 21) between '" + DateTimeClass.ConvertDate(txtFilterDateF.Text, "yyyy-MM-dd") + "' and '" + DateTimeClass.ConvertDate(txtFilterDateT.Text, "yyyy-MM-dd") + "' ";
        //    }
        //    if (StringClass.Check(ddlFilterActive.SelectedValue))
        //    {
        //        strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "'";
        //    }
        //    grdNews.DataSource = NewsService.News_GetByTop("", strWhere, "Date desc, Id desc");
        //    grdNews.DataBind();
        //    if (grdNews.PageCount <= 1)
        //    {
        //        grdNews.PagerStyle.Visible = false;
        //    }
        //}

        //protected void UnFilter_Click(object sender, EventArgs e)
        //{
        //    ControlClass.ResetControlValues(pnUpdate);
        //    LoadDrop();
        //    LoadFilterDrop();
        //    PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
        //    View();
        //}
       

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdComment.Items.Count; i++)
            {
                item = grdComment.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        CommentService.Comment_Delete(strId);
                    }
                }
            }
            grdComment.CurrentPageIndex = 0;
            View();
        }
        protected void ActiveAll_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdComment.Items.Count; i++)
            {
                item = grdComment.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                         //
                        SqlDataProvider sql = new SqlDataProvider();
                        sql.ExecuteNonQuery("Update Comment set Active = 1 Where Id='" + strId + "'");
                    }
                }
            }
            grdComment.CurrentPageIndex = 0;
            View();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            View();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Comment obj = new Data.Comment();
                obj.Id = Id;
                obj.EnquiryId = Enquiry_Id;
                obj.FullName = txtName.Text;
                obj.Email = txtEmail.Text;
                obj.Detail = txtDetail.Text;
                obj.Point = "0";
                obj.Date = DateTimeClass.ConvertDateTime(txtDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.Active = chkActive.Checked ? "1" : "0";
                
                    
                    CommentService.Comment_Update(obj);
                }
                View();
                pnView.Visible = true;
                pnUpdate.Visible = false;
              
            }
        

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
          
        }

        protected void grdComment_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdComment.CurrentPageIndex = e.NewPageIndex;
            View();
        }

        protected void grdComment_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grdComment.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
                    }
                }
            }
        }

        protected void grdComment_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
               
                    Id = strCA;
                    List<MyWebSite.Data.Comment> listE = Business.CommentService.Comment_GetByTop("", "[Id] = " + strCA, "");
                    Enquiry_Id = listE[0].EnquiryId;
                    txtName.Text = listE[0].FullName;
                    txtEmail.Text = listE[0].Email;
                    txtDetail.Text = listE[0].Detail;
                    txtDate.Text = DateTimeClass.ConvertDateTime(listE[0].Date);
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    
                    //LoadDrop();
                    pnUpdate.Visible = true;
                    pnView.Visible = false;
                    break;
                case "Delete":
                    CommentService.Comment_Delete(strCA);
                    View();
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update Comment set Active =" + strA + " Where Id='" + strCA + "'");
                    View();
                    break;
            }
        }
    }
}