<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);
header('Content-Type: application/json');

// --- CAU HINH DATABASE ---
$servername = "localhost";
$username   = "account";
$password   = "pass";  // Điền mật khẩu database của ông vào đây
$dbname     = "rmowigco_project_rfid";

$conn = new mysqli($servername, $username, $password, $dbname);
if ($conn->connect_error) {
    die(json_encode(["error" => "Ket noi that bai: " . $conn->connect_error]));
}

// Đón dữ liệu UID thô duy nhất từ ESP32 bắn về
$data = json_decode(file_get_contents('php://input'), true);
$uid = isset($data['uid']) ? strtoupper(trim($data['uid'])) : null;

if ($uid) {
    
    // TRA CỨU TRONG BẢNG GỐC (INVENTORY) XEM THẺ NÀY CÓ CHƯA
    $check = $conn->prepare("SELECT gs1_code, asset_name FROM asset_inventory WHERE rfid_uid = ?");
    $check->bind_param("s", $uid);
    $check->execute();
    $result = $check->get_result();

    if ($result->num_rows > 0) {
        // THẺ CŨ: Lôi thông tin danh mục gốc (gs1_code, asset_name) ra để tí ghi vào bảng scan
        $row = $result->fetch_assoc();
        $gs1 = $row['gs1_code']; 
        $name = $row['asset_name']; 
        $action_msg = "The cu, da dong bo ma GS1 tu bang Inventory sang.";
    } else {
        // THẺ MỚI TINH: Thêm mới vào danh mục gốc trước
        $default_name = "Tai san moi doi dat ten";
        
        $insert_inv = $conn->prepare("INSERT INTO asset_inventory (rfid_uid, asset_name) VALUES (?, ?)");
        $insert_inv->bind_param("ss", $uid, $default_name);
        $insert_inv->execute();

        // Sau khi thêm mới, Trigger của ông sẽ tự tạo ra mã `gs1_code`.
        // Mình chạy lại Query để lôi chính xác cái mã `gs1_code` mà Trigger vừa sinh ra trong bảng Inventory.
        $check->execute();
        $res_new = $check->get_result();
        $row_new = $res_new->fetch_assoc();
        
        $gs1 = $row_new['gs1_code'];
        $name = $row_new['asset_name'];
        $action_msg = "The moi, Trigger da gen ma gốc va cap nhat vao lich su quet.";
    }

    // LÔI THÔNG TIN VỪA LẤY ĐƯỢC Ở TRÊN ĐỂ ĐẬP VÀO BẢNG NHẬT KÝ QUÉT (ASSET_SCANS)
    $log = $conn->prepare("INSERT INTO asset_scans (rfid_uid, gs1_code, asset_name, device_id) 
                           VALUES (?, ?, ?, ?) 
                           ON DUPLICATE KEY UPDATE 
                           gs1_code = VALUES(gs1_code), 
                           asset_name = VALUES(asset_name),
                           device_id = VALUES(device_id), 
                           scan_time = CURRENT_TIMESTAMP");
                           
    $device = "ESP32_SANG";
    $log->bind_param("ssss", $uid, $gs1, $name, $device);
    
    if ($log->execute()) {
        // Trả dữ liệu JSON sạch về cho hệ thống hiển thị
        echo json_encode([
            "status" => "success", 
            "rfid_uid" => $uid,
            "gs1_code" => $gs1, 
            "asset_name" => $name, 
            "action" => $action_msg
        ]);
    } else {
        echo json_encode(["error" => "Loi ghi nhat ky scan: " . $conn->error]);
    }
} else {
    echo json_encode(["error" => "Khong nhan duoc thong tin UID tu thiet bi"]);
}

$conn->close();
?>