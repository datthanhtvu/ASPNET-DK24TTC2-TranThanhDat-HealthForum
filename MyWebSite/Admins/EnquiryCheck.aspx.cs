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

    public partial class EnquiryCheck : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string img_path = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnUpdate.Visible = false;
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa hết câu hỏi và bình luận liên quan?');");
                lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa câu hỏi và bình luận liên quan?');");
                LoadFilterDrop();
                LoadDrop();
                PageHelper.LoadDropDownListFilterActive(ddlFilterActive);
                View();
            }
        }
        private void View()
        {
            grdEnquiry.DataSource = EnquiryService.Enquiryt_GetByTop("", "", " [Active] ASC,[Date]  ");
            grdEnquiry.DataBind();
            if (grdEnquiry.PageCount <= 1)
            {
                grdEnquiry.PagerStyle.Visible = false;
            }
        }
        void LoadFilterDrop()
        {
            ddlGroupNews.Items.Clear();
            List<Data.GroupNews> list = Business.GroupNewsService.GroupNews_GetByTop("50", "left([Level],5)=00040", "[Level],Id");
            ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[0].Name + " chung", list[0].Level), list[0].Id));
            for (int i = 1; i < list.Count; i++)
            {
                ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
            }
            ddlGroupNews.DataBind();
        }
        void LoadDrop()
        {
            ddlGroupNews.Items.Clear();
            ddlGroupNews.Items.Add(new ListItem("-Chọn nhóm tin-", ""));
            List<Data.GroupNews> list = Business.GroupNewsService.GroupNews_GetByTop("50", "left([Level],5)=00040", "[Level],Id");
            ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[0].Name + " chung", list[0].Level), list[0].Id));
            for (int i = 1; i < list.Count; i++)
            {
                ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
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
            grdEnquiry.DataSource = EnquiryService.Enquiryt_GetByTop("", strWhere, "Date desc, Id desc");
            grdEnquiry.DataBind();
            if (grdEnquiry.PageCount <= 1)
            {
                grdEnquiry.PagerStyle.Visible = false;
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
        }
     
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdEnquiry.Items.Count; i++)
            {
                item = grdEnquiry.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        List<Data.Comment> listCom = Business.CommentService.Comment_GetByTop("", "EnquiryId=" + strId + "", "");
                        if (listCom.Count > 0)
                        {
                           
                          for (int j = 0; j < listCom.Count; j++)
                            {
                             
                                CommentService.Comment_Delete(listCom[j].Id);
                            }
                        }
                        EnquiryService.Enquiry_Delete(strId);
                    }
                }
            }
            grdEnquiry.CurrentPageIndex = 0;
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
                Data.Enquiry obj = new Data.Enquiry();
                if (file_Image.Value.Trim().Length > 0 && file_Image.PostedFile != null && file_Image.PostedFile.ContentLength > 0)
                {
                    img_path = System.IO.Path.GetFileName(file_Image.PostedFile.FileName);
                    file_Image.PostedFile.SaveAs(Server.MapPath("/Upload/Enquiry/") + img_path.ToString().Trim());
                    img_path = "/Upload/Enquiry/" + img_path.ToString().Trim();
                    img_path = Common.StringClass.Checkpath(img_path);
                    if (img_path.Length == 0)
                    {
                        Common.WebMsgBox.Show("Đuôi file ảnh bạn cần đăng lên không đúng !!"); return;
                    }
                }
                else
                {
                    img_path = "/Upload/Images/noPhoto.jpg";
                }
                obj.Name = txtFullName.Text;
                obj.NameEnquiry = txtNameEn.Text;
                obj.EMail = txtEmail.Text;//
                obj.Tag = StringClass.NameToTag(txtNameEn.Text)+"-"+StringClass.RandomString(10);
                obj.Image = img_path;
                obj.Content = txtContent.Text;
                obj.Detail = fckDetail.Value;
                obj.Date = DateTimeClass.ConvertDateTime(txtDate.Text, "MM/dd/yyyy HH:mm:ss");
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.GroupNewsId = ddlGroupNews.SelectedValue;
                obj.NumberView = "0";//
               
                //
                //
                if (Insert == true)
                {
                    EnquiryService.Enquiry_Insert(obj);
                }
                else
                {
                    obj.Id = Id;
                    EnquiryService.Enquiry_Update(obj);
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
            grdEnquiry.CurrentPageIndex = e.NewPageIndex;
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
                    string tableRowId = grdEnquiry.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
                    Insert = false;
                    Id = strCA;
                    List<Data.Enquiry> listE = Business.EnquiryService.Enquiryt_GetByTop("", "[Id] = " + strCA, "");
                    txtFullName.Text = listE[0].Name;
                    txtNameEn.Text = listE[0].NameEnquiry;
                    txtEmail.Text = listE[0].EMail;
                    imgImage.ImageUrl = listE[0].Image;
                    txtContent.Text = listE[0].Content;
                    fckDetail.Value = listE[0].Detail;
                    txtDate.Text = DateTimeClass.ConvertDateTime(listE[0].Date);
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    ddlGroupNews.Text = listE[0].GroupNewsId;
                    LoadDrop();
                    pnUpdate.Visible = true;
                    pnView.Visible = false;

                    break;
                    case "Delete":
                    EnquiryService.Enquiry_Delete(strCA);
                    View();
                    break;
                case "Active":

                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update Enquiry set Active =" + strA + " Where Id='" + strCA + "'");
                    View();
                    break;
            }
        }
    }
}