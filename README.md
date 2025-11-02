# ASP.NET HealthForum

**Đề tài:** Xây dựng website diễn đàn sức khỏe  
**Môn học:** ASP.NET Web Forms  
**Sinh viên thực hiện:** Trần Đạt Thành – Lớp DK24TTC2  

---

## 🧠 Giới thiệu

Website **HealthForum** là một diễn đàn sức khỏe trực tuyến, nơi người dùng có thể:
- Đăng bài viết chia sẻ về sức khỏe.
- Trao đổi, bình luận, và thảo luận với cộng đồng.
- Quản lý tài khoản cá nhân và thông tin đăng bài.
- Hỗ trợ quản trị viên quản lý bài viết, danh mục, người dùng, v.v.

---

## 🗂 Cấu trúc thư mục

HealthForum/
- ├── setup/ # Chứa hướng dẫn cài đặt & dữ liệu mẫu
- ├── src/ # Chứa toàn bộ mã nguồn ASP.NET
- ├── progress-report/ # Báo cáo tiến độ từng tuần
- └── thesis/ # Báo cáo chính thức của đồ án
- ├── doc/ # File Word (.docx)
- ├── pdf/ # File PDF
- ├── abs/ # File trình bày (PowerPoint, video)
- └── refs/ # Tài liệu tham khảo

---

## ⚙️ Hướng dẫn cài đặt & chạy dự án

### 1️⃣ Cài đặt môi trường
- Visual Studio 2022 hoặc mới hơn  
- .NET Framework 4.8  
- SQL Server 2019 + SSMS  
- IIS Express  

### 2️⃣ Tạo cơ sở dữ liệu
1. Mở SSMS và tạo database mới: `HealthForumDB`  
2. Chạy script SQL trong `setup/data_sample.sql` (nếu có)  
3. Kiểm tra các bảng: `Users`, `Posts`, `Comments`, `Categories`, ...

### 3️⃣ Cấu hình kết nối database
Trong file `src/MyWebSite/Web.config`, 
```xml
<connectionStrings>
  <add name="HealthForumConnectionString"
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=HealthForumDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
