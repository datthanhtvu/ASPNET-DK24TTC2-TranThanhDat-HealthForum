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

    public partial class News : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string Lang = "vi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnUpdate.Visible = false;
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                LoadFilterDrop();
                LoadDrop();
                PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                View();


            }
        }
        private void View()
        {
            if (Session["IsAdmin"] != null)
            {
                if (Session["IsAdmin"].ToString() == "3")
                {
                    grdNews.DataSource = NewsService.News_GetByTop("", "UserId=" + Session["UserId"].ToString() + "", " Id desc ");
                    grdNews.DataBind();
                    if (grdNews.PageCount <= 1)
                    {
                        grdNews.PagerStyle.Visible = false; 
                    }

                }

                else
                {
                    //grdNews.DataSource = NewsService.News_GetByTop("", "", " [Active] ASC,[Date] ");News_User
                    grdNews.DataSource = NewsService.News_User();
                    grdNews.DataBind();
                    if (grdNews.PageCount <= 1)
                    {
                        grdNews.PagerStyle.Visible = false;
                    }
                }
            }
        }
        void LoadFilterDrop()
        {
            ddlFilterGroupNews.Items.Clear();
            ddlFilterGroupNews.Items.Add(new ListItem("--Tất cả--", ""));
            List<MyWebSite.Data.GroupNews> list = GroupNewsService.GroupNews_GetByTop("", "", " [Level], Ord, Id  ");
            for (int i = 0; i < list.Count; i++)
            {
                ddlFilterGroupNews.Items.Add(new ListItem(StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlFilterGroupNews.DataBind();
        }
        void LoadDrop()
        {
            ddlGroupNews.Items.Clear();
            ddlGroupNews.Items.Add(new ListItem("-Chọn nhóm tin-", ""));
            List<MyWebSite.Data.GroupNews> list = GroupNewsService.GroupNews_GetByTop("", "", "  [Level], Ord, Id ");
            for (int i = 0; i < list.Count; i++)
            {
                ddlGroupNews.Items.Add(new ListItem(StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlGroupNews.DataBind();

        }
        protected void Filter_Click(object sender, EventArgs e)
        {
            string strWhere = " 1=1 ";
            if (StringClass.Check(ddlFilterGroupNews.SelectedValue))
            {
                strWhere += " and GroupNewsId = '" + ddlFilterGroupNews.SelectedValue + "'";
            }
            if (StringClass.Check(txtFilterName.Text))
            {
                strWhere += " and Name like N'%" + txtFilterName.Text + "%' ";
            }
            if (StringClass.Check(txtFilterDateF.Text) && StringClass.Check(txtFilterDateT.Text) == false)
            {
                txtFilterDateF.Text = txtFilterDateT.Text;
            }
            if (StringClass.Check(txtFilterDateF.Text) == false && StringClass.Check(txtFilterDateT.Text))
            {
                txtFilterDateF.Text = txtFilterDateT.Text;
            }
            if (StringClass.Check(txtFilterDateF.Text) && StringClass.Check(txtFilterDateT.Text))
            {
                strWhere += " and convert(nvarchar(10), Date, 21) between '" + DateTimeClass.ConvertDate(txtFilterDateF.Text, "yyyy-MM-dd") + "' and '" + DateTimeClass.ConvertDate(txtFilterDateT.Text, "yyyy-MM-dd") + "' ";
            }
            if (StringClass.Check(ddlFilterActive.SelectedValue))
            {
                strWhere += " and Active = '" + ddlFilterActive.SelectedValue + "'";
            }
            grdNews.DataSource = NewsService.News_GetByTop("", strWhere, "Date desc, Id desc");
            grdNews.DataBind();
            if (grdNews.PageCount <= 1)
            {
                grdNews.PagerStyle.Visible = false;
            }
        }

        protected void UnFilter_Click(object sender, EventArgs e)
        {
            ControlClass.ResetControlValues(pnUpdate);
            LoadDrop();
            LoadFilterDrop();
            PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
            View();
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(pnUpdate);
            LoadDrop();
            txtDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "dd/MM/yyyy hh:mm:ss tt");
            pnView.Visible = false;
            Insert = true;
            if (Session["IsAdmin"].ToString() == "3")
            {
                chkActive.Visible = false;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdNews.Items.Count; i++)
            {
                item = grdNews.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        NewsService.News_Delete(strId);
                    }
                }
            }
            grdNews.CurrentPageIndex = 0;
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
               
                Data.News obj = new Data.News();
                obj.Name = txtName.Text;
                obj.Tag = StringClass.NameToTag(txtName.Text)+"-"+StringClass.RandomString(10);
                obj.Image = txtimage.Text;
                obj.Content = txtContent.Text;
                obj.Detail = fckDetail.Value;
                obj.Date = DateTimeClass.ConvertDateTime(txtDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.Title = txtTitle.Text;
                obj.Description = txtDescription.Text;
                obj.Keyword = txtKeyword.Text;
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Priority = chkIndex.Checked ? "1" : "0";
                obj.Lang = Lang;
                obj.GroupNewsId = ddlGroupNews.SelectedValue;
                obj.Index = chkIndex.Checked ? "1" : "0";
                obj.UserId = Session["UserId"].ToString();
                if (Insert == true)
                {
                    NewsService.News_Insert(obj);
                }
                else
                {
                    obj.Id = Id;
                    NewsService.News_Update(obj);
                }
                View();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
        }

        protected void grdNews_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdNews.CurrentPageIndex = e.NewPageIndex;
            View();
        }

        protected void grdNews_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdNews.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdNews_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    if (Session["IsAdmin"].ToString() == "3")
                    {
                        chkActive.Visible = false;
                    }
                    Insert = false;
                    Id = strCA;
                    List<MyWebSite.Data.News> listE = Business.NewsService.News_GetByTop("", "[Id] = " + strCA, "");
                    txtName.Text = listE[0].Name;
                    txtimage.Text = listE[0].Image;
                    txtContent.Text = listE[0].Content;
                    fckDetail.Value = listE[0].Detail;
                    txtDate.Text = DateTimeClass.ConvertDateTime(listE[0].Date);
                    txtDescription.Text = listE[0].Description;
                    txtKeyword.Text = listE[0].Keyword;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    ddlGroupNews.Text = listE[0].GroupNewsId;
                    chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
                    LoadDrop();
                    pnUpdate.Visible = true;
                    pnView.Visible = false;

                    break;
                case "Delete":
                    NewsService.News_Delete(strCA);
                    View();
                    break;
                case "Active":
                    if (Session["IsAdmin"].ToString() == "3")
                    {
                        Common.WebMsgBox.Show("Bạn không  có quyền kiểm duyệt tin!");
                    }
                    else
                    {
                        string strA = "";
                        string str = e.Item.Cells[2].Text;
                        strA = str == "1" ? "0" : "1";
                        SqlDataProvider sql = new SqlDataProvider();
                        sql.ExecuteNonQuery("Update News set Active =" + strA + " Where Id='" + strCA + "'");
                        View();
                    }
                    break;
            }
        }
    }
}