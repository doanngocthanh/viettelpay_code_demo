//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                           API HOÀN HUỶ KHI THANH TOÁN                                            //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    string cmd                  // Mã lệnh. Giá trị cố định là: REFUND_PAYMENT
    string merchant_code
    string order_id
    string originalRequestId    // Mã giao dịch thanh toán tương ứng bên Viettel
    string refundType           // Hình thức hoàn tiền: 0 hoàn toàn phần, 1 hoàn một phần
                                // Hiện nay chỉ hỗ trợ hoàn toàn phần
    number trans_amount         // Số tiền hoàn = số tiền thanh toán
    string rans_content         // Lý do hoàn tiền
    string version              // Giá trị cố định 2.0
    string check sum            // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                // access_code + cmd + merchant_code + order_id + originalRequestId + refundType + trans_amount + version

// Khai báo model và gán dữ liệu
    RefundPayment rf = new RefundPayment();
        rf.cmd = cmd;
        rf.merchant_code = merchant_code_local;
        rf.order_id = order_id;
        rf.originalRequestId = od.originalRequestId;
        rf.refundType = "0";
        rf.trans_amount = od.priceTotal+"";
        rf.trans_content = trans_content;
        rf.version = "2.0";
        rf.check_sum = check_sum;

// Chuyển model về định dạng JSON, loại bỏ các dấu không cân thiết
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsondata = js.Serialize(rf);
        jsondata = jsondata.Replace("\\", "a").Replace(":", "=").Replace("\"", "").Replace(",", "&").Replace("{", "").Replace("}", "");

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

            RefundPayment2 rs = JsonConvert.DeserializeObject<RefundPayment2>(result);

// Dữ liệu Viettel trả về dạng JSON có các dữ liệu sau
    string merchant_code
    string order_id
    string error_code           // Thành công sẽ trả về dạng 00. Trường hợp khác kiểm tra trong tài liệu
    string error_msg            // Mô tả khái quát nội dung lỗi
    string merchant_request_id  // Mã giao dịch huỷ bên Viettel
    string refund_request_id    // Mã giao dịch hoàn tiền cho KH
    string version              // Phiên bản kết nối. Giá trị cố định là: 2.0
    string check_sum            // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                // access_code + error_code + merchant_code + order_id + version
    string value = access_code + error_code + merchant_code + order_id + version;
    check_sum = getCheck_sum(value);