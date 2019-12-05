-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 09, 2019 at 09:01 AM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.1.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `shop`
--
CREATE DATABASE IF NOT EXISTS `shop` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `shop`;

-- --------------------------------------------------------

--
-- Table structure for table `hdct`
--

CREATE TABLE `hdct` (
  `id` int(11) NOT NULL,
  `maSanPham` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `soLuong` int(11) NOT NULL,
  `donGia` float NOT NULL,
  `maHoaDon` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `hdct`
--

INSERT INTO `hdct` (`id`, `maSanPham`, `soLuong`, `donGia`, `maHoaDon`) VALUES
(52, 'ST', 1, 10000, 'HD21633792019'),
(53, 'ST', 1, 10000, 'HD22035792019'),
(54, 'ST', 1, 10000, 'HD22451792019'),
(55, 'ST', 1, 10000, 'HD2268792019'),
(56, 'ST', 1, 10000, 'HD22649792019'),
(57, 'ST', 1, 10000, 'HD22819792019'),
(58, 'ST', 1, 10000, 'HD22937792019'),
(59, 'ST', 1, 10000, 'HD23124792019'),
(60, 'ST', 3, 30000, 'HD23258792019'),
(61, 'ST', 1, 10000, 'HD23529792019'),
(62, 'ST', 3, 30000, 'HD31511792019'),
(63, 'ST', 2, 20000, 'HD403792019'),
(64, 'ST', 2, 20000, 'HD411792019'),
(65, 'ST', 4, 40000, 'HD4726792019'),
(66, 'NB', 5, 50000, 'HD4726792019'),
(67, 'ST', 3, 30000, 'HD93253792019'),
(68, 'ST', 11, 110000, 'HD153920792019'),
(69, 'NB', 18, 180000, 'HD153920792019'),
(70, 'ST', 11, 110000, 'HD154027792019'),
(71, 'NB', 18, 180000, 'HD154027792019'),
(72, 'ST', 4, 40000, 'HD73620992019'),
(73, 'ST', 1, 10000, 'HD83250992019'),
(74, 'ST', 1, 10000, 'HD8393992019'),
(75, 'ST', 1, 10000, 'HD83933992019');

-- --------------------------------------------------------

--
-- Table structure for table `hoadon`
--

CREATE TABLE `hoadon` (
  `id` int(11) NOT NULL,
  `maHoaDon` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `ngayHoaDon` date NOT NULL,
  `tongTien` float NOT NULL,
  `trangThai` int(11) NOT NULL,
  `username` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `hoadon`
--

INSERT INTO `hoadon` (`id`, `maHoaDon`, `ngayHoaDon`, `tongTien`, `trangThai`, `username`) VALUES
(71, 'HD21633792019', '2019-09-07', 10000, 0, 'thanhdn'),
(72, 'HD22035792019', '2019-09-07', 10000, 0, 'thanhdn'),
(73, 'HD22451792019', '2019-09-07', 10000, 0, 'thanhdn'),
(74, 'HD2268792019', '2019-09-07', 10000, 0, 'thanhdn'),
(75, 'HD22649792019', '2019-09-07', 10000, 0, 'thanhdn'),
(76, 'HD22819792019', '2019-09-07', 10000, 0, 'thanhdn'),
(77, 'HD22937792019', '2019-09-07', 10000, 0, 'thanhdn'),
(78, 'HD23124792019', '2019-09-07', 10000, 0, 'thanhdn'),
(79, 'HD23258792019', '2019-09-07', 30000, 0, 'thanhdn'),
(80, 'HD23529792019', '2019-09-07', 10000, 0, 'thanhdn'),
(81, 'HD31511792019', '2019-09-07', 30000, 0, 'thanhdn'),
(82, 'HD403792019', '2019-09-07', 20000, 0, 'thanhdn'),
(83, 'HD411792019', '2019-09-07', 20000, 0, 'thanhdn'),
(84, 'HD4726792019', '2019-09-07', 90000, 0, 'thanhdn'),
(85, 'HD93253792019', '2019-09-07', 30000, 0, 'thanhdn'),
(86, 'HD153920792019', '2019-09-07', 290000, 0, 'thanhdn'),
(87, 'HD154027792019', '2019-09-07', 290000, 0, 'thanhdn'),
(88, 'HD73620992019', '2019-09-09', 40000, 0, 'thanhdn'),
(89, 'HD83250992019', '2019-09-09', 10000, 0, 'thanhdn'),
(90, 'HD8393992019', '2019-09-09', 10000, 0, 'thanhdn'),
(91, 'HD83933992019', '2019-09-09', 10000, 0, 'thanhdn');

-- --------------------------------------------------------

--
-- Table structure for table `loaisanpham`
--

CREATE TABLE `loaisanpham` (
  `id` int(11) NOT NULL,
  `maLoai` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `tenLoai` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `loaisanpham`
--

INSERT INTO `loaisanpham` (`id`, `maLoai`, `tenLoai`) VALUES
(1, 'L01', 'Nước Giải Khát');

-- --------------------------------------------------------

--
-- Table structure for table `sanpham`
--

CREATE TABLE `sanpham` (
  `id` int(11) NOT NULL,
  `maSanPham` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `tenSanPham` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `giaTien` float NOT NULL,
  `hinh` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `maLoai` varchar(50) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `sanpham`
--

INSERT INTO `sanpham` (`id`, `maSanPham`, `tenSanPham`, `giaTien`, `hinh`, `maLoai`) VALUES
(1, 'ST', 'String', 10000, 'sting.jpg', 'L01'),
(2, 'NB', 'Number 1', 10000, 'number1.jpg', 'L01');

-- --------------------------------------------------------

--
-- Table structure for table `taikhoan`
--

CREATE TABLE `taikhoan` (
  `username` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `phone` varchar(10) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `taikhoan`
--

INSERT INTO `taikhoan` (`username`, `password`, `phone`) VALUES
('thanhdn', '1', '000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hdct`
--
ALTER TABLE `hdct`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `loaisanpham`
--
ALTER TABLE `loaisanpham`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hdct`
--
ALTER TABLE `hdct`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=76;

--
-- AUTO_INCREMENT for table `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=92;

--
-- AUTO_INCREMENT for table `loaisanpham`
--
ALTER TABLE `loaisanpham`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
