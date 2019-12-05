//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                      API TRUY VẤN THÔNG TIN TRẢ VỀ TỪ ĐỐI TÁC                                    //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Dữ liệu Viettel POST sang
string merchant_code
string order_id
string check_sum                // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                // access_code + merchant_code + order_id


// Hàm sử lý nhận kết quả giao dịch từ đối tác
        // Lấy dữ liệu đơn hàng từ mã đơn hàng Viettel truyền sang
        // Tạo check_sum theo check_sum Viettel truyền sang
                //Mã hoá SHA1 -> encode base64 -> utf8 của chuỗi: access_code + merchant_code + order_id
        // So sánh check_sum
        // Sử lý riêng của đối tác
        // xác định mã lỗi:
                // Mã lỗi: 00 (Thành công, đã lưu kết quả giao dịch)
                // Mã lỗi: 01 (Không thành công, không lưu được kết quả giao dịch)
//



// Dữ liệu đôi stác trả về dạng JSON

    value = access_code + error_code + merchant_code + order_id;
    string check_sum_local = getCheck_sum(value);

    QueryTrans qt = new QueryTrans();
    qt.error_code = error_code;
    qt.merchant_code = merchant_code;
    qt.order_id = order_id;
    qt.return_url = return_url;
    qt.return_bill_code = return_bill_code;
    qt.return_other_info = return_other_info;
    qt.check_sum = check_sum_local;

    // Dùng return Json(qt, JsonRequestBehavior.AllowGet) để return JSON cho Viettel