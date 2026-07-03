# Hệ thống IoT Quản lý Tài sản dựa trên Chuẩn GS1 GIAI

Dự án nghiên cứu, thiết kế thiết bị nhúng Edge Client và phần mềm quản trị mặt đất phục vụ kiểm kê thiết bị điện tử theo tiêu chuẩn định danh quốc tế.

## Công nghệ sử dụng
- **Hardware:** ESP32 DevKit, RFID MFRC522 (13.56MHz), OLED SSD1306, Active Buzzer, Battery Shield V3.
- **Backend:** PHP / MySQL Database.
- **Desktop App:** C# WinForms (.NET Framework).

## Tính năng cốt lõi
- Tự động bóc tách UID RFID thô và đóng gói chuỗi cấu trúc chuẩn GS1 GIAI (`8933615...`).
- Cơ chế bắt mạng thông minh không chặn qua cổng `WiFiManager` (Access Point luôn phát).
- Đồng bộ mốc thời gian thực (`scan_time`) khi tái quét thiết bị cũ để tối ưu hóa không gian lưu trữ cơ sở dữ liệu.

## Hướng dẫn cấu hình Web Server (Backend)
1. Upload file `rfid_handler.php` trong thư mục `web_server_backend` lên Hosting hoặc Local Server (Apache).
2. Cấu hình lại các thông số kết nối Database (`$servername`, `$username`, `$password`, `$dbname`) ở đầu file PHP cho trùng khớp với cơ sở dữ liệu MySQL của bạn.
