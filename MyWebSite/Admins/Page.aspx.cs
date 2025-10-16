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
	public partial class Page : System.Web.UI.Page
	{
		static bool Insert = false;
		static string Level = "";
		private string Lang = "";
        SqlDataProvider sql = new SqlDataProvider();
		protected void Page_Load(object sender, EventArgs e)
		{
			Lang = Global.GetLang();
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				NumberClass.OnlyInputNumber(txtOrd);
				BindGrid();
			}
		}

        private void LoadDropDownListPageLinkType()
        {
            string[] myArr = new string[] { "1,Nhập liên kết", "2,Liên kết module" };
            Common.PageHelper.LoadDropDownList(ddlLinkType, myArr, true);
        }

        private void LoadDropDownListPageLink()
        {
            ddlLink.Items.Clear();
            ddlLink.Items.Add(new ListItem("-Chọn liên kết-", "-1"));
            ddlLink.Items.Add(new ListItem("Trang chủ", "/"));
            List<Data.GroupNews> GroupNews = new List<Data.GroupNews>();
            GroupNews = GroupNewsService.GroupNews_GetByTop("", "", " [Level], Ord, Id ");
            if (GroupNews.Count > 0)
            {
                ddlLink.Items.Add(new ListItem("Tin tức", "/tin-tuc.htm"));
                for (int i = 0; i < GroupNews.Count; i++)
                {
                    ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(GroupNews[i].Name, GroupNews[i].Level), "/tin-tuc/" + GroupNews[i].Tag + ".htm"));
                }
            }
           
            //List<Data.GroupLibrary> GroupLibrary = new List<Data.GroupLibrary>();
            //GroupLibrary = GroupLibraryService.GroupLibrary_GetByAll(Lang);
            //for (int i = 0; i < GroupLibrary.Count; i++)
            //{
            //    ddlLink.Items.Add(new ListItem(StringClass.ShowNameLevel(GroupLibrary[i].Name, GroupLibrary[i].Level), "/library/" + GroupLibrary[i].Id + ".aspx"));
            //}

            ddlLink.Items.Add(new ListItem("Liên hệ", "/lien-he.htm"));
        }

		private void BindGrid()
		{
			grdPage.DataSource = MenuService.Menu_GetByTop("","","[Level],Ord,Id");
			grdPage.DataBind();
            if (grdPage.PageCount <= 1)
            {
                grdPage.PagerStyle.Visible = false;
            }
            else
            {
                grdPage.PagerStyle.Visible = true;
            }
		}

		protected void grdPage_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdPage.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdPage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdPage.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdPage_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "AddSub":
					Level = strCA;
					AddButton_Click(source, e);
					break;
				case "Edit":
					Insert = false;
					txtId.Value = strCA;
                    List<Data.Menu> listE = MenuService.Menu_GetById(strCA);
					Level = listE[0].Level.Substring(0, listE[0].Level.Length - 5);
					txtName.Text = listE[0].Name;
                    fckContent.Value = listE[0].Content;
					fckDetail.Value = listE[0].Detail;
					txtTitle.Text = listE[0].Title;
					txtDescription.Text = listE[0].Description;
					txtKeyword.Text = listE[0].KeyWord;
                    try
                    {
                        PageHelper.LoadDropDownListPagePosition(ddlPosition);
                    }
                    catch
                    { }
                    PageHelper.LoadDropDownListTarget(ddlTarget);
                    PageHelper.LoadDropDownListPageType(ddlType);
                    LoadDropDownListPageLinkType();
                    LoadDropDownListPageLink();
                    ddlType.Text = listE[0].Type;
                    txtLink.Text = listE[0].Link;
                    txtLink.Visible = true;
                    ddlLink.Visible = false;
                    try
                    {
                        ddlLink.Text = listE[0].Link;
                        ddlLinkType.Text = "2";
                    }
                    catch
                    {
                        ddlLinkType.Text = "1";
                    }
                    ddlTarget.Text = listE[0].Target;
                    ddlPosition.Text = listE[0].Position;
                    txtOrd.Text = listE[0].Ord;
                    chkIndex.Checked = listE[0].Index == "1" || listE[0].Index == "True";
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					sql.ExecuteNonQuery("Update Page set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					MenuService.Menu_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
            PageHelper.LoadDropDownListPagePosition(ddlPosition);
            PageHelper.LoadDropDownListTarget(ddlTarget);
            PageHelper.LoadDropDownListPageType(ddlType);
            LoadDropDownListPageLinkType();
            LoadDropDownListPageLink();
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdPage.Items.Count; i++)
			{
				item = grdPage.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						MenuService.Menu_Delete(strId);
					}
				}
			}
			grdPage.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
            {
                if (ddlLinkType.SelectedValue == "2" && ddlLink.SelectedValue == "-1")
                {
                    Common.WebMsgBox.Show("Chọn liên kết !");
                    return;
                }
                if (ddlLinkType.SelectedValue == "1" && txtLink.Text == "") 
                {
                    Common.WebMsgBox.Show("Nhập link liên kết !"); return;
                }
                string Link = "";
                if (ddlLink.SelectedValue != "-1") { Link = ddlLink.SelectedValue; } else { Link = txtLink.Text; }
                string Id = txtId.Value;
                string Tag = "";
				Data.Menu obj = new Data.Menu();
                obj.Id = Id;
				obj.Name = txtName.Text;
				obj.Tag = Common.StringClass.NameToTag(txtName.Text);
                Tag = Common.StringClass.NameToTag(txtName.Text);
                obj.Content = fckContent.Value;
                obj.Detail = fckDetail.Value;
				obj.Level = Level + "00000";
				obj.Title = txtTitle.Text;
				obj.Description = txtDescription.Text;
				obj.KeyWord = txtKeyword.Text;
                obj.Type = ddlType.SelectedValue;
                obj.Link = Link;
                obj.Target = ddlTarget.SelectedValue;
                obj.Position = ddlPosition.SelectedValue;
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Index = chkIndex.Checked ? "1" : "0";
                obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
				if (Insert == true){
					MenuService.Menu_Insert(obj);
				}
				else{
					MenuService.Menu_Update(obj);
				}
                if (ddlType.SelectedValue == "2")
                {
                    Link = "/noi-dung/" + Tag + ".htm";
                    sql.ExecuteNonQuery("Update Page set Link='" + Link + "'  Where Id='" + Id + "'");
                }
				BindGrid();
				pnView.Visible = true;
				pnUpdate.Visible = false;
				Level= "";
				Insert = false;
			}
		}

		protected void Back_Click(object sender, EventArgs e)
		{
			pnView.Visible = true;
			pnUpdate.Visible = false;
			Level= "";
			Insert = false;
		}

        protected void ddlLinkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLinkType.SelectedValue == "2") { ddlLink.Visible = true; txtLink.Visible = false; } else { ddlLink.Visible = false; txtLink.Visible = true; }
        }
	}
}