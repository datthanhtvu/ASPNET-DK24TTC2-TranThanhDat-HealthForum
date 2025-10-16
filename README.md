# MyWebSite - Diễn đàn sức khỏe / Cổng tin tức

## Mục tiêu đồ án

Dự án là một website dạng cổng tin tức / hệ thống quản trị nội dung (CMS) nhỏ. Mục tiêu của đồ án là phát triển một ứng dụng cho phép:

- Đăng tải, chỉnh sửa, xóa và phân loại bài viết (news).
- Quản lý nhóm tin (category/group news).
- Hệ thống hỏi đáp (Enquiry) cho người dùng gửi câu hỏi và quản trị trả lời.
- Hệ thống quản trị (Admin) để quản lý nội dung, quảng cáo, bình luận, và thống kê.
- Hệ thống đăng ký/đăng nhập người dùng (Membership) và phân quyền cơ bản.
- Hỗ trợ SEO-friendly URLs (routing), đa ngôn ngữ (qua cookie), và chức năng thống kê lượt xem.

## Tính năng chính

- Quản lý bài viết: tạo/sửa/xóa, upload ảnh, thiết lập SEO (title, description, keyword), phân trang.
- Danh mục bài viết (Category / GroupNews).
- Hỏi đáp: gửi câu hỏi, danh sách câu hỏi, chi tiết và trả lời.
- Bình luận và kiểm duyệt bình luận.
- Trang liên hệ gửi thông tin liên hệ đến admin.
- Trang admin với các module: News, GroupNews, Enquiry, Comment, Advertise, Statistics, Export.

## Yêu cầu

- Microsoft Windows
- Visual Studio (2015/2017/2019/2022) với hỗ trợ .NET Framework 4.8 (project target là 4.8 trong `Web.config`).
- SQL Server (có thể là SQL Server Express / LocalDB) chứa cơ sở dữ liệu `MyDataBase` hoặc bạn tự đổi connection string.
- Enterprise Library (Data Access Application Block) được sử dụng (thông qua assemblies tham chiếu trong project).

## Cài đặt nhanh và chạy trên máy local

1. Mở Visual Studio, chọn `File -> Open -> Project/Solution` và mở `MyWebSite.sln`.
2. Cấu hình connection string trong `MyWebSite/Web.config`:

   - Mặc định dự án dùng tên connection string `SQLConnectionString` trỏ tới `Data Source=LAPTOP-OJVB1JL7\MSSQLSERVER02;Initial Catalog=MyDataBase;Integrated Security=True`.
   - Nếu bạn chạy trên máy khác, chỉnh `Data Source` và `Initial Catalog` hoặc đổi sang LocalDB.

3. Tạo/restore cơ sở dữ liệu:

   - Dự án gọi nhiều stored procedures (ví dụ `sp_News_GetByTop`, `sp_News_Insert`, `sp_News_Paging`, `thongke`, v.v.). Bạn cần có bộ script tạo schema và stored procedures. Nếu chưa có, yêu cầu người hướng dẫn hoặc tạo thủ công các bảng sau theo tên lớp `News`, `Member`, `Comment`, `Enquiry`, `Advertise`, `GroupNews`, `Config`, `Contact`, `Menu`.
   - Nếu có file SQL scripts trong repository, chạy chúng trên SQL Server để tạo DB.

4. Build solution (`Build -> Build Solution`).
5. Chạy (F5) hoặc chạy bằng IIS Express. Website sẽ mở trên trình duyệt.



