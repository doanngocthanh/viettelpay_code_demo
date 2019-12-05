const helper = require('./Helper')
const VT = require('./VIETTEL.data')

// Function Mẫu khi Khách hàng Click thanh toán bằng VTP
function onSubmitPayment(request, respone) {
    // Các trường dữ liệu thay đổi theo logic hệ thống...
    var billcode = 'BILL123' // Trường hợp k có billcode, truyền tham số order_id vào
    var command = 'PAYMENT'
    var desc = 'Thanh Toan BILL123'
    var locale = 'Vi'
    var merchant_code = VT.SecrectInfo.MERCHANT_CODE
    var order_id = 'ORDER123456'
    var other_info = {
        type: 'No VAT',
        desc: 'Thanh Toan BILL123'
    }
    var customer_bill_info = {
        bill_to_forename: 'NGUYEN VAN',
        bill_to_surname: 'AN',
        bill_to_email: 'annv@cybersource.com',
        bill_to_address_line1: 'So 15',
        bill_to_address_city: 'Ha Noi',
        bill_to_address_state: 'Unknown',
        bill_to_address_country: 'vi',
        bill_to_address_postal_code: '94043'
    }
    var return_url = 'http://mywebsite/payment/paymentResult'
    var login_msisdn = '0123456789'
    var cancel_url = null
    var trans_amount = 560000
    var version = '2.0'

    // Tạo chuỗi Mã hóa theo đúng thứ tự trong tài liệu
    const toHashCheckSum = VT.SecrectInfo.ACCESS_KEY + billcode + command + merchant_code + order_id + trans_amount + version
    const check_sum = helper.HashValue(VT.SecrectInfo.HASH_KEY, toHashCheckSum)

    // Redirect đến VTP
    const endPointUrl = helper.urlRedirectToVTP(billcode, command, desc, locale, merchant_code, order_id,
        other_info, customer_bill_info, return_url, login_msisdn, cancel_url, trans_amount, version, check_sum)

    respone.redirect(endPointUrl)
}

