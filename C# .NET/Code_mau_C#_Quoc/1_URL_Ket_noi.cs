//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                          URL KẾT NỐI CỔNG THANH TOÁN                                             //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Dữ liệu cần thiết
string access_code                 // Mã truy cập. Viettel sẽ cấp cho đối tác
string hash_key                    // Mã bảo mật để mã hoá dữ liệu. Viettel sẽ cấp cho đối tác     
string app_key                     // Tương tự hash key nhưng dùng mã hoá url. Chỉ dùng cho đối tác TMĐT
string submit_url                  // (string) Đường dẫn cổng thanh toán VTP

// Dữ liệu bắt buộc
string billcode                    // Mã hoá đơn. Tiếng Việt không dấu
string command                     // Mã lệnh cố định là: PAYMENT
string merchant_code               // Mã nhà cung cấp Viettel cung cấp
string order_id                    // Mã giao dịch duy nhất phía đối tác. Tiếng Việt không dấu
string return_url                  // Địa chỉ chuyển về sau khi khách hàng thanh toán
number trans_amount                // Số tiền giao dịch
vstring ersion                     // Phiên bản kết nối. Giá trị cố định là: 2.0
string check_sum                   // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                   //access_code + billcode + command + merchant_code + order_id + trans_amount + version

// Lấy check_sum
value = access_code + billcode + command + merchant_code + order_id + trans_amount + version;
check_sum = getCheck_sum(value);    // Hàm lấy check_sum được dựng sẵn

// Dữ liệu không bắt buộc
string desc                        // Nội dung giao dịch, đơn hàng
string locale                      // Mã vị trí giá trị cố định là: Vi
string other_info                  // Thông tin bổ sung khác
JSON customer_bill_info            // Thông tin bổ sung về khách hàng sử dụng thanh toán quốc tế
number login_msisdn                // Số điện thoại khách hàng
string cancel_url                  // Địa chỉ chuyển về nếu khách hàng huỷ giao dịch

// URL gữi đi
url = submit_url + "billcode=" + billcode + "&command=" + command + "&desc=" + desc + "&locale=" + locale + "&merchant_code=" + merchant_code_local + "&order_id=" + order_id + "&cancel_url=" + cancel_url + "&return_url=" + return_url + "&trans_amount=" + trans_amount + "&version=" + version + "&login_msisdn=" + login_msisdn + "&check_sum=" + check_sum;