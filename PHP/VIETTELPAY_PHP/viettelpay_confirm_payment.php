<?php
include_once("model/hoadon.php");
function hash_password($data, $hash_key) 
//hàm mã hóa chuỗi để lấy check_sum
{
 return base64_encode(hash_hmac("sha1", $data, $hash_key, $raw_output=TRUE));
}
$access_code = "d41d8cd98f00b204e9800998ecf8427e73d3f0a0ee85cb6b9a5866a527a242be";
$hash_key = "d41d8cd98f00b204e9800998ecf8427e0edb84da1e7942869f846dfb5403dbb6"; 
//khi gửi yêu cầu thanh toán phía viettel sẽ post 4 dữ liệu dưới này qua để check kết quả
$bill_code = $_REQUEST['billcode'];
$merchant_code = $_REQUEST['merchant_code'];
$order_id = $_REQUEST['order_id'];
$check_sum = $_REQUEST['check_sum']; //check_sum là mã hóa của access_code + billcode + merchant_code + order_id + trans_amount

$err = "00";
$value = "";
$trans_amount = 0;
$check_sum = str_replace("%3d","=",$check_sum);
$check_sum = str_replace("+"," ",$check_sum);
    $HoaDon=new HoaDon();
try{
    $hd= $HoaDon->getid($bill_code);
    
    if(!$hd)
    //kiểm tra trong db có tồn tại mã hóa đơn này không, nếu không $err='01'
    {
        $err = "01"; 
    }
    foreach ($hd as $l) {
    //tạo 1 check_sum so sánh với check_sum của viettel post sang check sum là mã hóa của access_code + billcode + merchant_code + order_id + trans_amount
        $value= $access_code.$l['maHoaDon']."SVFPTT4".$l['maHoaDon'].$l['tongTien'];
        $check_sum_ss = hash_password($value, $hash_key);
        $trans_amount=$l['tongTien'];
        $check_sum_ss = str_replace("%3d","=",$check_sum_ss);
        $check_sum_ss = str_replace("+"," ",$check_sum_ss);


 }

 if ($check_sum != $check_sum_ss)
 //nếu check_sum không giống nhau $err='02'
 {
    $err = "02";
}
}
catch(Exception $e)
//nếu xảy ra lỗi $err="03"
{
    $err = "03";
 }

 header('Content-Type: application/json');
 $data = $access_code.$bill_code.$err.$merchant_code.$order_id.(string)$trans_amount;
 $check_sum = hash_password($data, $hash_key);
//trả kết quả cho phía viettel, hoàn tất giao dịch
$jsons = array();
$jsons['billcode'] = $bill_code;
$jsons['error_code'] = $err;
$jsons['merchant_code'] = $merchant_code;
$jsons['order_id'] = $order_id;
$jsons['trans_amount'] = $trans_amount;
$jsons['check_sum'] = $check_sum;
return json_encode($jsons);
?>
