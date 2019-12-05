<?php
function hash_password($data, $hash_key) //hàm mã hóa chuỗi để lấy check_sum
{
 return base64_encode(hash_hmac("sha1", $data, $hash_key, $raw_output=TRUE));
}
        $access_code    =$_POST['access_code'];
        $hash_key       =$_POST['hash_key'];
        $cancel_url     =$_POST['cancel_url'];
        $return_url     =$_POST['return_url'];
        $billcode       =$_POST['billcode'];
        $command        =$_POST['command']; 
        $desc           =$_POST['desc']; 
        $locale         =$_POST['locale']; 
        $merchant_code  =$_POST['merchant_code']; 
        $order_id       =$_POST['order_id']; 
        $other_info     =$_POST['other_info']; 
        $trans_amount   =$_POST['trans_amount'];
        $version        =$_POST['version'];
        $customer_bill_info= $_POST['customer_bill_info'];
        $login_msisdn   =$_POST['login_msisdn'];
        $data= $access_code.$billcode.$command.$merchant_code.$order_id.$trans_amount.$version;
        //mã hóa dữ liệu check_sum theo đúng thứ tự access_code,billcode,command,merchant_code,order_id,trans_amount,version
        $check_sum = hash_password($data, $hash_key);
        $redirect= "http://sandbox.viettel.vn/PaymentGateway/payment?"."billcode=".$billcode."&command=".$command."&desc=".$desc."&locale=".$locale."&merchant_code=".$merchant_code."&order_id=".$order_id."&return_url=".$return_url."&trans_amount=".$trans_amount."&version=".$version."&login_msisdn=".$login_msisdn."&check_sum=".$check_sum;
        //Chuyển hướng tới trang thanh toán của viettel pay.
        header('Location: '.$redirect);
?>
