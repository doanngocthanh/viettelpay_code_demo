//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                          API NHẬN KẾT QUẢ GIAO DỊCH                                              //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Dữ liệu Viettel POST sang
    string billcode
    string cust_msisdn
    strỉng error_code
    string merchant_code
    string order_id
    string payment_status
    string trans_amount
    string vt_transaction_id
    string check_sum             // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                // access_code + error_code + merchant_code + order_id + version
    string value = access_code + billcode + cust_msisdn + error_code + merchant_code + order_id + payment_status + trans_amount + vt_transaction_id;
    check_sum = getCheck_sum(value);

// Hàm sử lý nhận kết quả giao dịch từ đối tác
        // Lấy dữ liệu đơn hàng từ mã đơn hàng Viettel truyền sang
        // Tạo check_sum theo check_sum Viettel truyền sang
                //Mã hoá SHA1 -> encode base64 -> utf8 của chuỗi: access_code + billcode + cust_msisdn + error_code + merchant_code + order_id + payment_status + trans_amount + vt_transaction_id
        // So sánh check_sum
        // Sử lý riêng của đối tác
        // xác định mã lỗi:
                // Mã lỗi: 00 (Thành công, đã lưu kết quả giao dịch)
                // Mã lỗi: 01 (Không thành công, không lưu được kết quả giao dịch)
//


    value = access_code + error_code + merchant_code + order_id;
    string check_sum_local = getCheck_sum(value);

    GetResult rs = new GetResult();
    rs.error_code = error_code;
    rs.merchant_code = merchant_code;
    rs.order_id = order_id;
    rs.return_url = return_url;
    rs.return_bill_code = return_bill_code;
    rs.return_other_info = return_other_info;
    rs.check_sum = check_sum_local;

// Dùng return Json(rs, JsonRequestBehavior.AllowGet) để return JSON cho Viettel


