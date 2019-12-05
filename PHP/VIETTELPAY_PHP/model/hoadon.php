<?php
include_once("model/database.php");
class HoaDon extends DB {
  function get(){
      //0 chua thanh toan, 1 da thanh toan, 2 huy thanh toan
    return $this->select("SELECT * FROM `hoadon` where trangThai=0");
  }
  function getid($id){
    return $this->select("SELECT * FROM `hoadon` WHERE maHoaDon='$id' and trangThai=0");
  }
  function insertHoaDon($mahd,$ngayhd,$tongtien,$trangthai,$username){
    return $this->select("INSERT INTO `hoadon` (`maHoaDon`, `ngayHoaDon`, `tongTien`, `trangThai`,`username`) VALUES ('$mahd','$ngayhd','$tongtien','$trangthai','$username')"); 
  }
}
?>