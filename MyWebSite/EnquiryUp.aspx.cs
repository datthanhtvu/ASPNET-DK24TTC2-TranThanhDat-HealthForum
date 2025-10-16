using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using MyWebSite.Common;
using MyWebSite.Business;
namespace MyWebSite
{
    public partial class EnquiryUp : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
              
                lblResult.Visible = false;
              
            }
            LoadGroupNewsDropDownList();
            Page.Title = "Gửi bài hỏi đáp";
            lblResult.Visible = false;
        }
        private void LoadGroupNewsDropDownList()
        {
            ddlGroupNews.Items.Clear();
            List<Data.GroupNews> list = Business.GroupNewsService.GroupNews_GetByTop("50", "left([Level],5)=00040", "[Level],Id");
            ddlGroupNews.Items.Add(new ListItem(Common.StringClass.ShowNameLevel(list[0].Name + " chung", list[0].Level), list[0].Id));
            for (int i = 1; i < list.Count; i++)
            {
                ddlGroupNews.Items.Add(new ListItem(list[i].Name, list[i].Id));
            }
            ddlGroupNews.DataBind();
          
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string img_path = "";
            lblResult.Visible = true;
            lblResult.ForeColor = Color.Red;
            
                if (txtFullName.Text == "")
                {
                    lblResult.Text = "Tên không để trống!";
                }
                else
                {
                    if (txtEmail.Text == "")
                    {
                        lblResult.Text = "Tên Email không để trống!";
                    }
                    else
                        if (Common.StringClass.IsValidEmail(txtEmail.Text) == false)
                        {
                            lblResult.Text = "Địa chỉ Email không hợp lệ!";
                        }
                       else
                            if (ddlGroupNews.SelectedValue == "")
                            {
                                lblResult.Text = "Chưa chọn chuyên mục !";
                            }
                           else
                            if(txtNameE.Text=="")
                            {
                            lblResult.Text = "Tiêu đề câu hỏi  không để trống!";
                            }
                          else
                                //
                                
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
                           img_path ="/Upload/Images/noPhoto.jpg";
                        }
                                //
                                if (txtDetail.Text == "")
                                {
                                    lblResult.Text = "Nội dung câu hỏi  không để trống!";
                                }
                                else
                                    if (!recaptcha.IsValid)
                                     { 
                                         lblResult.Text = "Mã xác thực không đúng!";
                                     }
                                     else
                                       {
                                           if (Page.IsValid)
                                           {

                                               Data.Enquiry obj = new Data.Enquiry();

                                               obj.Image = img_path;

                                               if (txtDetail.Text.Count() < 400)
                                               {
                                                   obj.Content = txtDetail.Text;
                                               }
                                               if (txtDetail.Text.Count() >= 400)
                                               {
                                                   obj.Content = StringClass.CatChuoi(txtDetail.Text, 200);
                                               }
                                               obj.Name = txtFullName.Text;
                                               obj.GroupNewsId = ddlGroupNews.SelectedValue; ;
                                               obj.Tag = Common.StringClass.NameToTag(txtNameE.Text) + "-" + Common.StringClass.RandomString(7);
                                               obj.EMail = txtEmail.Text;
                                               obj.NameEnquiry = txtNameE.Text;
                                               obj.Detail = txtDetail.Text;
                                               obj.Date = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy HH:mm:ss");
                                               obj.NumberView = "0";
                                               obj.Active = "0";
                                               Business.EnquiryService.Enquiry_Insert(obj);
                                               Common.WebMsgBox.Show("Cảm ơn bạn đã gửi câu hỏi! Bài của bạn sẽ được đăng ngay sau khi chúng tôi kiểm duyệt!");
                                               Common.ControlClass.ResetControlValues(this);
                                               LoadGroupNewsDropDownList();
                                           }
                                        
                                       }
                              }

            }

    
      

       
      
        }
    }
