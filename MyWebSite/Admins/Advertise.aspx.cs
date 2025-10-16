﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.Data;
using MyWebSite.Business;
using MyWebSite.Common;
//ấn nút sửa gặp lỗi MenuID =null
namespace MyWebSite.Admins
{
	public partial class Advertise : System.Web.UI.Page
	{
		static string Id = "";
		static bool Insert = false;
		static private string Lang = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			Lang = Global.GetLang();
            if (!IsPostBack)
            {
                PageHelper.LoadDropDownListPosition(drlvitriquangcao);
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
				lbtDeleteB.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtClick);
				BindGrid();
			}
		}

		private void BindGrid()
		{
            List<Data.Advertise> list = Business.AdvertiseService.Advertise_GetByTop("20", " Position="+ drlvitriquangcao.SelectedValue +"", " Ord");
			grdAdvertise.DataSource = list;
			grdAdvertise.DataBind();
            if (grdAdvertise.PageCount <= 1)
            {
                grdAdvertise.PagerStyle.Visible = false;
            }
            else
            {
                grdAdvertise.PagerStyle.Visible = true;
            }
            list.Clear();
            list = null;
		}

		private void LoadPageDropDownList()
		{
			ddlPage.Items.Clear();
			ddlPage.Items.Add(new ListItem("", ""));
			List<Data.Menu> list = MenuService.Menu_GetByTop("","[Active]=1","[Level], Ord");
			for (int i = 0; i < list.Count; i++)
			{
				ddlPage.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[i].Name, list[i].Level), list[i].Id));
			}
			ddlPage.DataBind();
		}

		protected void grdAdvertise_ItemDataBound(object sender, DataGridItemEventArgs e)
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
					string tableRowId = grdAdvertise.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

		protected void grdAdvertise_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			grdAdvertise.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}

		protected void grdAdvertise_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string strCA = e.CommandArgument.ToString();
			switch (e.CommandName)
			{
				case "Edit":
					Insert = false;
					Id = strCA;
                    lblImg.Text = "";
					List<Data.Advertise> listE = AdvertiseService.Advertise_GetById(Id);
					txtName.Text = listE[0].Name;
					imgImage.ImageUrl = listE[0].Image.Length > 0 ? listE[0].Image : "";
                    lblImg.Text = listE[0].Image;
					txtLink.Text = listE[0].Link;
                    PageHelper.LoadDropDownListPageType(ddlType);
                    PageHelper.LoadDropDownListPosition(ddlPosition);
                    ddlPosition.Text = listE[0].Position;
                    PageHelper.LoadDropDownListTarget(ddlTarget);
                    ddlTarget.Text = listE[0].Target;
					fckContent.Value = listE[0].Content;
                    if (listE[0].Content.Length > 5)
                    {
                        ddlType.Text = "2";
                    }
					txtClick.Text = listE[0].Click;
					txtOrd.Text = listE[0].Ord;
					chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
					LoadPageDropDownList();
				
					pnView.Visible = false;
					pnUpdate.Visible = true;
					break;
				case "Active":
					string strA = "";
					string str = e.Item.Cells[2].Text;
					strA = str == "1" ? "0" : "1";
					SqlDataProvider sql = new SqlDataProvider();
					sql.ExecuteNonQuery("Update Advertise set Active=" + strA + "  Where Id='" + strCA + "'");
					BindGrid();
					break;
				case "Delete":
					AdvertiseService.Advertise_Delete(strCA);
					BindGrid();
					break;
			}
		}

		protected void AddButton_Click(object sender, EventArgs e)
		{
			pnUpdate.Visible = true;
			 ControlClass.ResetControlValues(pnUpdate);
			LoadPageDropDownList();
            PageHelper.LoadDropDownListPageType(ddlType);
            PageHelper.LoadDropDownListTarget(ddlTarget);
            PageHelper.LoadDropDownListPosition(ddlPosition);
            lblImg.Text = "";
			pnView.Visible = false;
			Insert = true;
		}

		protected void DeleteButton_Click(object sender, EventArgs e)
		{
			DataGridItem item = default(DataGridItem);
			for (int i = 0; i < grdAdvertise.Items.Count; i++)
			{
				item = grdAdvertise.Items[i];
				if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
				{
					if (((CheckBox)item.FindControl("ChkSelect")).Checked)
					{
						string strId = item.Cells[1].Text;
						AdvertiseService.Advertise_Delete(strId);
					}
				}
			}
			grdAdvertise.CurrentPageIndex = 0;
			BindGrid();
		}

		protected void RefreshButton_Click(object sender, EventArgs e)
		{
			BindGrid();
		}

		protected void Update_Click(object sender, EventArgs e)
		{
			if (Page.IsValid){
                string img_path = "";
                if (file_Image.Value.Trim().Length > 0 && file_Image.PostedFile != null && file_Image.PostedFile.ContentLength > 0)
                {
                    img_path = System.IO.Path.GetFileName(file_Image.PostedFile.FileName);
                    file_Image.PostedFile.SaveAs(Server.MapPath("/Upload/advertise/") + img_path.ToString().Trim());
                    img_path = "/Upload/advertise/" + img_path.ToString().Trim();
                    img_path = Common.StringClass.Checkpath(img_path);
                    if (img_path.Length == 0) { Common.WebMsgBox.Show("Đuôi file ảnh bạn cần đăng lên không đúng !!"); return; }
                }
                else { img_path = lblImg.Text; }
				Data.Advertise obj = new Data.Advertise();
				obj.Id = Id;
				obj.Name = txtName.Text;
                obj.Image = img_path;
				obj.Link = txtLink.Text;
                obj.Target = ddlTarget.SelectedValue;
				obj.Content = fckContent.Value;
                obj.Position = ddlPosition.SelectedValue;
				obj.Click = txtClick.Text;
				obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
				obj.Active = chkActive.Checked ? "1" : "0";
				obj.Lang = Lang;
				obj.MenuID = ddlPage.SelectedValue;
				if (Insert == true){
					AdvertiseService.Advertise_Insert(obj);
				}
				else{
					AdvertiseService.Advertise_Update(obj);
				}
				BindGrid();
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

        protected void drlvitriquangcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
	}
}