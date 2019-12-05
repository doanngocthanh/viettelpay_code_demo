//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//                                       URL TRANG THÔNG BÁO KẾT QUẢ GIAO DỊCH                                      //
//                                                                                                                  //
//                                                                                                                  //
//                                                                                                                  //
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Dữ liệu kèm theo

string billcode
string cust_msisdn  
string error_code
string merchant_code
string order_id
number payment_status
number trans_amount
string vt_transaction_id
string check_sum                // Chuỗi mã hoá SHA1 -> encode base64 -> utf8 từ dữ liệu của:
                                // access_code + billcode + cust_msisdn + error_code + merchant_code + order_id + payment_status + trans_amount + vt_transaction_id