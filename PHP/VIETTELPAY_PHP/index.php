<!doctype html>
<html lang="en">

<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>VIETTELPAY PHP</title>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"
    integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
</head>

<body>
  <main role="main">
    <div class="album py-5 bg-light">
      <div class="container">
        <div class="row">
          <div class="col-md-12">

            <form style="font-size: 13px;" id="create_form" action="viettelpay_create_payment.php" method="POST">
              <div class="row">
                <div class="col-md-6">
                  <label>access_code <em style="color: green">(sẽ được cấp sau khi đăng ký đối tác với viettel)</em></label>
                  <input type="text" name="access_code" value="d41d8cd98f00b204e9800998ecf8427e73d3f0a0ee85cb6b9a5866a527a242be" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>hash_key <em style="color: green">(sẽ được cấp sau khi đăng ký đối tác với viettel)</em></label>
                  <input type="text" name="hash_key" value="d41d8cd98f00b204e9800998ecf8427e0edb84da1e7942869f846dfb5403dbb6" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>cancel_url <em style="color: green">(chuyển đến trang thông báo hủy thanh toán)</em></label>
                  <input type="text" name="cancel_url" value="http://sandbox.viettel.vn/PaymentGateway/payment-result" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>return_url <em style="color: green">(chuyển đến trang cần trả kết quả về)</em></label>
                  <input type="text" name="return_url" value="http://sandbox.viettel.vn/PaymentGateway/payment-result" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>billcode <em style="color: green">(mã hóa đơn cần thanh toán)</em></label>
                  <input type="text" name="billcode" value="HD8393992019" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>command <em style="color: green">(mã thanh toán)</em></label>
                  <input type="text" name="command" value="PAYMENT" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>desc <em style="color: green">(nội dung thanh toán)</em></label>
                  <input type="text" name="desc" value="Thanh toán hóa đơn HD8393992019" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>locale <em style="color: green">(mặc định là Vi)</em></label>
                  <input type="text" name="locale" value="Vi" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>merchant_code <em style="color: green">(mã đối tác đăng ký với viettel)</em></label>
                  <input type="text" name="merchant_code" value="SVFPTT4" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>order_id <em style="color: green">(mã này sử dụng mã hóa đơn)</em></label>
                  <input type="text" name="order_id" value="HD8393992019" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>other_info <em style="color: green">(có thể để trống)</em></label>
                  <input type="text" name="other_info" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>trans_amount <em style="color: green">(tổng số tiền của hóa đơn)</em></label>
                  <input type="text" name="trans_amount" value="10000" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>version <em style="color: green">(mặc định là 2.0)</em></label>
                  <input type="text" name="version" value="2.0" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>customer_bill_info <em style="color: green">(có thể để trống)</em></label>
                  <input type="text" name="customer_bill_info" class="w-100">
                </div>
                <div class="col-md-6">
                  <label>login_msisdn <em style="color: green">(số điện thoại khách hàng viettel pay, có thể để trống)</em></label>
                  <input type="text" name="login_msisdn" value="0386472044" class="w-100">
                </div>
                <div class="col-md-6">
                <hr>
                <button type="submit" class="w-100 btn btn-outline-success btn-sm">Thanh Toán</button>
                </div>
              </div>
            </form>
          
            

          </div>

        </div>
      </div>
    </div>

  </main>

  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"
    integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN"
    crossorigin="anonymous"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"
    integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
    crossorigin="anonymous"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"
    integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
    crossorigin="anonymous"></script>
    <script type="text/javascript">
            $("#btnPopup").click(function () {
                var postData = $("#create_form").serialize();
                var submitUrl = $("#create_form").attr("action");
                $.ajax({
                    type: "POST",
                    url: submitUrl,
                    data: postData,
                    dataType: 'JSON',
                    success: function (x) {
                        if (x.code === '00') {
                            if (window.vnpay) {
                                vnpay.open({width: 768, height: 600, url: x.data});
                              
                            } else {
                                location.href = x.data;
                              
                            }
                            return false;
                        } else {
                            alert(x.Message);
                        }
                    }
                });
                return false;
            });
        </script>
</body>

</html>