#include <Arduino.h>
#include <WiFi.h>
#include <HTTPClient.h> 
#include <SPI.h>              
#include <MFRC522.h>          
#include <Wire.h>             
#include <Adafruit_GFX.h>     
#include <Adafruit_SSD1306.h> 
#include <DNSServer.h>
#include <WebServer.h>
#include <WiFiManager.h>      

String serverName = "http://103.221.223.9/~rmowigco/rfid_handler.php";

// CẤU HÌNH CHÂN CÒI VÀ THÔNG SỐ GS1

#define BUZZER_PIN 16                 // ĐỊNH NGHĨA CHÂN CÒI (Nối vào D16)
const String GS1_COMPANY_PREFIX = "8933615"; 

#define RST_PIN 4  
#define SS_PIN  5  
MFRC522 mfrc522(SS_PIN, RST_PIN); 

#define SCREEN_WIDTH 128 
#define SCREEN_HEIGHT 64 
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, -1);

WiFiManager wm;

// Hàm tạo tiếng kêu tít ngắn gọn dứt khoát
void BeepCoi(int thoi_gian_keu) {
  digitalWrite(BUZZER_PIN, HIGH);
  delay(thoi_gian_keu);
  digitalWrite(BUZZER_PIN, LOW);
}

void saveConfigCallback() {
  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0, 20);
  display.println(" DA NHAN WIFI MOI!");
  display.display();
  
  // Kêu 2 tiếng tít tít dài để báo đã nhận cấu hình Wi-Fi mới thành công
  BeepCoi(200);
  delay(100);
  BeepCoi(200);
  
  delay(2000);
  ESP.restart(); 
}

void CapNhatGiaoDienOLED() {
  display.clearDisplay();
  display.setTextSize(1); 
  display.setTextColor(WHITE, BLACK); 
  
  display.setCursor(0, 4);
  display.print("Mang: ");
  if (WiFi.status() == WL_CONNECTED) {
    display.setTextColor(BLACK, WHITE);
    display.println(" OK ");
  } else {
    display.setTextColor(BLACK, WHITE);
    display.println(" LOI ");
  }
  
  display.setTextColor(WHITE, BLACK);
  display.setCursor(0, 22);
  display.println("Config: 192.168.4.1"); 
  
  display.drawFastHLine(0, 38, 128, WHITE);

  display.setCursor(0, 48);
  if (WiFi.status() == WL_CONNECTED) {
    display.println(">> GS1 GIAI READY <<"); 
  } else {
    display.setTextColor(BLACK, WHITE);
    display.println(">> DOI CAU HINH <<");
  }
  display.display();
}

void setup() {
  Serial.begin(115200);   
  SPI.begin();            
  mfrc522.PCD_Init();     

  // CẤU HÌNH CHÂN OUTPUT CHO CÒI BÁO
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW); // Ban đầu tắt còi đi

  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
    for(;;); 
  }

  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0, 25);
  display.println("  DANG KHOI DONG...");
  display.display();
  
  WiFi.mode(WIFI_AP_STA); 
  wm.setSaveConfigCallback(saveConfigCallback); 
  wm.setSaveConnect(true); 
  wm.setConfigPortalBlocking(false); 

  wm.startConfigPortal("HUST_RFID_CONFIG", "12345678");

  WiFi.begin(); 
  int counter = 0;
  while (WiFi.status() != WL_CONNECTED && counter < 8) {
    delay(500);
    counter++;
  }

  CapNhatGiaoDienOLED(); 
}

void loop() {
  wm.process();

  if ( ! mfrc522.PICC_IsNewCardPresent() || ! mfrc522.PICC_ReadCardSerial()) {
    static unsigned long lastCheck = 0;
    if (millis() - lastCheck > 3000) { 
      CapNhatGiaoDienOLED();
      lastCheck = millis();
    }
    return; 
  }

  // Đọc UID thô từ thẻ (Xóa khoảng trắng)
  String rfid_uid = "";
  for (byte i = 0; i < mfrc522.uid.size; i++) {
    rfid_uid += String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : "");
    rfid_uid += String(mfrc522.uid.uidByte[i], HEX);
  }
  rfid_uid.toUpperCase(); 

  // ĐỌC ĐƯỢC THẺ PHÁT LÀ CHO CÒI KÊU TÍT MỘT PHÁT ĐANH THÉP NGAY!
  BeepCoi(150); // Kêu trong 150 mili-giây

  // Đóng gói theo chuẩn cấu trúc GS1 GIAI Pure Identity URI
  String gs1_giai_uri = GS1_COMPANY_PREFIX + rfid_uid;

  Serial.println("-----------------------");
  Serial.println("Ma UID Tho: " + rfid_uid);
  Serial.println("Chuoi GS1 GIAI: " + gs1_giai_uri);

  // Hiển thị trạng thái quẹt thẻ lên OLED tinh gọn
  display.clearDisplay();
  display.setTextColor(WHITE, BLACK);
  display.setCursor(0, 4);
  display.println("DANG GUI GIAI DATA...");
  display.drawFastHLine(0, 16, 128, WHITE);
  
  display.setCursor(0, 24);
  display.print("UID: ");
  display.println(rfid_uid);
  
  display.setCursor(0, 44);
  display.print("GIAI Prefix: ");
  display.setTextColor(BLACK, WHITE); 
  display.println(GS1_COMPANY_PREFIX);
  display.setTextColor(WHITE, BLACK); 
  display.display();

  // GỬI HTTP POST DỮ LIỆU JSON CHUẨN GIAI
  if (WiFi.status() == WL_CONNECTED) {
    WiFiClient client; 
    HTTPClient http;
    if (http.begin(client, serverName)) { 
      http.addHeader("Content-Type", "application/json"); 
      
      String httpRequestData = "{\"uid\":\"" + rfid_uid + "\",\"gs1_giai\":\"" + gs1_giai_uri + "\"}";
      
      int httpResponseCode = http.POST(httpRequestData); 
      http.end(); 
    }
  }

  delay(2500); 
  CapNhatGiaoDienOLED(); 
}