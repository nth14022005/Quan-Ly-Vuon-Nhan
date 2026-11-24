# Hệ thống quản lý vườn Nhãn

Dự án cá nhân ứng dụng quản lý vườn nhãn trên Windows Forms (C# / .NET Framework) và Microsoft SQL Server. **Phát triển có AI hỗ trợ viết và chỉnh sửa mã nguồn**; tác giả tự cài đặt môi trường, chạy và kiểm tra chức năng trong quá trình học tập.

## Chức năng thể hiện trong mã nguồn
- Quản lý cây nhãn, lô vườn, giống nhãn, công việc chăm sóc, vật tư và thu hoạch.
- Đăng nhập, tài khoản người dùng và vai trò.
- Các màn hình Windows Forms và lớp truy cập dữ liệu SQL Server.

## Cách chạy (tham khảo)
1. Dùng máy Windows có Visual Studio hỗ trợ .NET Framework và SQL Server.
2. Mở `QLVuonNhan.slnx` hoặc `QLVuonNhan.csproj` trong Visual Studio.
3. Tạo cơ sở dữ liệu tên `QLVuonNhan`, sau đó chạy `database/schema.sql`. Đây là **schema-only**, đã lược bỏ các bản ghi mẫu/tài khoản trong bản sao lưu gốc vì an toàn dữ liệu; có thể cần tạo dữ liệu/tài khoản demo riêng để trải nghiệm đầy đủ.
4. Sửa chuỗi kết nối trong `App.config` thành SQL Server phù hợp với máy của bạn; không đăng thông tin xác thực thật lên GitHub.
5. Build và chạy project. Chưa có xác nhận build/run độc lập trên môi trường khác.

Không đăng bản `.bak`, dữ liệu người dùng, các thư mục `bin`, `obj` hoặc báo cáo chứa thông tin cá nhân.
