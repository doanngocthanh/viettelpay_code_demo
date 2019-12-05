//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                          API TRUY VẤN KẾT QUẢ GIAO DỊCH                                          //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Dữ liệu đối tác POST sang
string cmd                         // Mã lệnh. Cố định là : TRANS_INQUIRY
string merchant_code
string order_id
string version                     // Giá trị mặc định là: 2.0. Nếu TMĐT là: TMDT 
string check sum                   // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                   // access_code + cmd + merchant_code + order_id + version
string value = access_code + cmd + merchant_code + order_id + version
check_sum = getCheck_sum(value);

// Khai báo model và gsn dữ liệu
    PaymentResultAPI paymrs = new PaymentResultAPI();
        paymrs.cmd = cmd;
        paymrs.merchant_code = merchant_code;
        paymrs.order_id = order_id;
        paymrs.version = version;
        paymrs.check_sum = check_sum;

// Chuyển model về định dạng JSON, loại bỏ các dấu không cân thiết
    JavaScriptSerializer js = new JavaScriptSerializer();
        string jsondata = js.Serialize(paymrs);
        jsondata = jsondata.Replace("\\", "").Replace(":", "=").Replace("\"", "").Replace(",", "&").Replace("{","").Replace("}", "");

// Post dữ liệu truy vấn sang VTP
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);    // url sẽ được VTP cấp
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";
        using (var streamWriter = new
            StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsondata);
            }

// Lấy dữ liệu trả về dạng JSON chuyển thành model
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();                
            }

            PaymentResultAPI2 rs2 = JsonConvert.DeserializeObject<PaymentResultAPI2>(result);

// Dữ liệu Viettel trả về dạng JSON có các dữ liệu sau
string merchant_code
string order_id
string error_code           // Thành công sẽ trả về dạng 00. Trường hợp khác kiểm tra trong tài liệu
string vt_transaction_id    // Mã giao dịch bên Viettel
string payment_status       // Trạng thái thanh toán: 
                            //      -1: Chưa phát sinh giao dịch
                            //       0: Giao dịch đang chờ sử lý
                            //       1: Giao dịch thành công
                            //       2: Giao dịch thất bại
                            //       3: Giao dịch chưa rõ kết quả
string version              // Phiên bản kết nối. Giá trị cố định là: 2.0
string check_sum            // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                            // access_code + merchant_code + order_id + payment_status + version
string value = access_code + merchant_code + order_id + payment_status + version;
check_sum = getCheck_sum(value);