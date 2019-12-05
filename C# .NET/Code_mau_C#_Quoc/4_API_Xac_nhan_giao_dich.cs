//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                              API XÁC NHẬN GIAO DỊCH                                              //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Bắt dữ liệu Viettel POST sang
    string bill_code = Request["billcode"];
    string merchant_code = Request["merchant_code"];
    string order_id = Request["order_id"];
    string check_sum = Request["check_sum"];
    check_sum = check_sum.Replace(" ", "+").Replace("=", "%3d");

// Hàm sử lý xác nhận thanh toán của đối tác
        // Lấy dữ liệu đơn hàng từ mã đơn hàng Viettel truyền sang
        // Tạo check_sum theo check_sum Viettel truyền sang
                //Mã hoá SHA1 -> encode base64 -> utf8 của chuỗi: access_code + billcode + merchant_code + order_id + trans_amount
        // So sánh check_sum
        // Sử lý riêng của đối tác
        // xác định mã lỗi:
                // Mã lỗi: 00 (Dữ liệu tồn tại, order_id chưa được thanh toán, số tiền khớp với mã giao dịch)
                // Mã lỗi: 01 (Không thành công, dữ liệu không chính xác)
                // Mã lỗi: 02 (check-sum gữi sang không đúng)
                // Mã lỗi: 03 (Lỗi tại hệ thống đối tác)
//


    value = access_code + billcode + error_code + merchant_code + order_id + trans_amount;
    string check_sum_local = getCheck_sum(value);  // check-sum trả về cho Viettel

    VerifyData vrdata = new VerifyData();
        vrdata.billcode = bill_code;
        vrdata.error_code = error_code;
        vrdata.merchant_code = merchant_code;
        vrdata.order_id = check_sum_ss;
        vrdata.trans_amount = trans_amount;
        vrdata.check_sum = check_sum_local;

// Dùng return Json(vrdata, JsonRequestBehavior.AllowGet) để return JSON cho Viettel