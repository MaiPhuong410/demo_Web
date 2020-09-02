create database QuanLyWebCoffee
go
use QuanLyWebCoffee

create table DanhMuc(
Id int not null identity primary key,
MaDM char(5) unique,
TenDM nvarchar(30))

create table SanPham(
Id int not null identity primary key,
MaDMId int ,
MaSP char(5) unique,
TenSP nvarchar(50),
HinhAnh nvarchar(max),
MoTa nvarchar(100),
GiaSP float,
foreign key (MaDMId)references DanhMuc(Id))

create table KhachHang(
MaKhachHang int not null identity primary key,
HoTenKH nvarchar(50),
DiaChi nvarchar(100),
SDT varchar(15))

create table HoaDon(
IdHD int not null identity primary key,
NgayLap datetime,
IdKH int,
foreign key (IdKH)references KhachHang(MaKhachHang))

create table CTHD(
IdHD int ,
MaSPId int ,
SoLuongBan int,
ThanhTien float,
foreign key (IdHD)references HoaDon(IdHD),
foreign key (MaSPId)references SanPham(Id),
primary key (IdHD, MaSPId))




--- NHAP LIEU
----NHAP BANG DANG MUC
insert into DanhMuc(MaDM, TenDM) values ('M1',N'COFFEE')
insert into DanhMuc(MaDM, TenDM) values ('M2',N'NƯỚC ÉP')
insert into DanhMuc(MaDM, TenDM) values ('M3',N'ĐÁ XAY')
insert into DanhMuc(MaDM, TenDM) values ('M4',N'SINH TỐ')
insert into DanhMuc(MaDM, TenDM) values ('M5',N'TRÀ SỮA')
insert into DanhMuc(MaDM, TenDM) values ('M6',N'BÁNH TRÁNG')
insert into DanhMuc(MaDM, TenDM) values ('M7',N'ĂN VẶT KHÁC')
--chè,mì,đồ chiên, đồ ăn, trà


-----NHAP BANG SAN PHAM
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(1,'SP1',N'CAFE SỮA','h1.jpg',N'Ngon ngon',2300)
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(2,'SP2',N'Nước ép cà chua','h2.jpg',N'Chua chua ngọt ngọt',25000)
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(3,'SP3',N'Matcha đá xay','h3.jpg',N'Thơm trà xanh mum mum',23000)
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP4',N'Sinh tố bơ','h4.jpg',N'Béo ngậy',24500)

insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP5',N'Sinh tố dâu tây','ST_DauTay.jpg',N'Từ những trái dâu tây chín đỏ, căng mọng để thưởng thức chắc chắn sẽ làm bạn thích',40000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP6',N'Sinh tố sapoche','ST_Sapoche.jpg',N'Hương thơm đặc biệt với vị ngọt lịm tự nhiên của sapoche cùng vị béo ngậy của sữa đặc',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP7',N'Sinh tố mãng cầu','ST_MangCau.jpg',N'Vị mãng cầu ngọt thanh cùng chút chua chua kích thích vị giác nên rất được ưa chuộng',35000);
---
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP8',N'Sinh tố dừa- thơm','ST_Dua.jpg',N'Sinh tố dừa thơm với vị béo của cùi dừa non và vị chua chua của trái thơm',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP9',N'Sinh tố xoài','ST_Xoai.jpg',N'Thức uống giải nhiệt ngày hè mang đến nhiều dưỡng chất cần thiết cho cơ thể',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP10',N'Sinh tố dưa gang','ST_DuaGang.jpg',N'Dưa gang rất mát và ngon, có công dụng chính là thanh lọc, giải nhiệt',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP11',N'Sinh tố chuối','ST_Chuoi.jpg',N'Sinh tố chuối có rất nhiều vitamin cùng khoáng chất giúp bạn có sức khỏe tốt hơn',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP12',N'Sinh tố mít sữa chua','ST_Mit.jpg',N'Sinh tố mít sữa chua mùi thơm dễ chịu, vị ngọt mát, béo béo lạ miệng',35000);
----
---Chưa insert
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP13',N'Sinh tố cà chua','ST_CaChua.jpg',N'sinh tố cà chua thơm ngon - thức uống giàu dinh dưỡng với nhiều tác dụng về sức khỏe',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(4,'SP14',N'Sinh tố dưa hấu','ST_DuaHau.jpg',N'Sinh tố dưa hấu vô cùng thơm ngon giúp bạn giải nhiệt nhanh chóng và vô cùng bổ dưỡng',35000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP15',N'Trà sữa trân châu','TS_TranChau.jpg',N'Vị trà sữa béo, trân châu dai, giòn, cùng đường đen ngọt – thơm hòa quyện tuyệt hảo',29000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP16',N'Trà sữa chocolate','TS_Chocolate.jpg',N'Trà sữa Socola có hương vị rất đậm và quyện',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP17',N'Trà sữa trà xanh','TS_TraXanh.jpg',N'Trà sữa trà xanh mang đến vị thơm mát, dễ uống',29000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP18',N'Trà sữa khoai môn','TS_KhoaiMon.jpg',N'Thức uống lạ mắt có màu tím đặc trưng cùng hương vị bùi bùi ngon đến khó tả.',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP19',N'Trà sữa bạc hà','TS_BacHa.jpg',N'Trà sữa bạc hà - một trong những vị trà sữa mát lạnh thơm ngon ',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP20',N'Trà sữa hạnh nhân','TS_HanhNhan.jpg',N'Mùi hương của hạnh nhân cùng vị của trà sẽ mang đến một cảm giác khác lạ, mới mẻ',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP21',N'Trà sữa mật ong','TS_MatOng.jpg',N'trà sữa mật ong đem đến cho bạn một thức uống mới mang hương vị tuyệt vời và rất tốt cho cơ thể.',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP22',N'Trà sữa đào','TS_Dao.jpg',N'Với hương vị thơm ngon, dễ uống trà sữa vẫn luôn là một thức uống chưa bao giờ “hạ nhiệt”',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP23',N'Trà sữa kiwi','TS_Kiwi.jpg',N'Trà sữa kiwi vừa thanh mát vừa bổ dưỡng giữ dáng đẹp da',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(5,'SP24',N'Trà sữa sen','TS_Sen.jpg',N'Hạt sen bùi, ngọt thanh vừa giúp món trà sữa không ngán vừa mang lại nhiều lợi ích cho sức khỏe',32000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP25',N'Bánh tráng sa tế','BT_Sate.jpg',N'Vị mặn cay (đã có sẵn sốt sate, rau xoài, hành phi xay nhuyễn)',15000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP26',N'Bánh tráng tỏi','BT_Toi.jpg',N'Miếng vuông, không cay, ruốc sấy',15000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP27',N'Bánh tráng tôm','BT_Tom.jpg',N'Vị ngọt ko cay (đã có sẵn sốt tôm, rau xoài, hành phi xay nhuyễn)',15000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP28',N'Bánh tráng sa tế tỏi','BT_SaTeToi.jpg',N'Thơm ngon đặc biệt, vị mặn cay',15000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP29',N'Bánh tráng cuốn Long An','BT_CuonLongAn.jpg',N'Thành phần: bánh tráng cuốn tỏi ruốc gia vị vừa ăn, tương ớt. HSD: để bên ngoài được 5-7 ngày',15000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP30',N'Bánh tráng cuốn bơ','BT_CuonBo.jpg',N'Bánh tráng cuộn vẫn với lớp nhân đầy đặn nào là trứng cút, mực khô, xoài xanh,… nhưng thêm lớp bơ dầu béo ngậy, bùi bùi cực hấp dẫn.',20000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP31',N'Bánh tráng cuốn trứng cút','BT_CuonTrungCut.jpg',N'thành phần như khô bò, tỏi chiên giòn, quả trứng cút và rau răm được cuốn thành từng cuộn bánh nhỏ, mỗi cuộn tầm to khoảng ngón tay cái, ăn kèm với chén nước chấm',20000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP32',N'Bánh tráng trộn','BT_Tron.jpg',N'Với vị chua chua của xoài, cay của sa tế, ngọt dai của bánh tráng, mực, thịt bò và trứng cút bánh tráng trộn chua cay được rất nhiều người yêu thích.',20000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP33',N'Bánh tráng nướng','BT_Nuong.jpg',N'Bánh tráng nướng hoàn thành cho thêm tương ớt và mayonaise lên trên rồi cắt miếng, thưởng thức ngay khi còn nóng. Cắn từng miếng bánh tráng thơm ngon, giòn rụm béo ngậy',20000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(6,'SP34',N'Bánh tráng mỡ hành','BT_MoHanh.jpg',N'nguyên liệu gồm bánh tráng, dầu ăn, hành tím, hành lá và muối tôm',20000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(7,'SP35',N'Xúc xích','XucXich.jpg',N'Xúc xích ngon lành và đảm bảo an toàn vệ sinh',15000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(7,'SP36',N'Đồ chiên','DoChien.jpg',N'Cá viên, bò viên, tôm viên, đậu bắp,...',25000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(7,'SP37',N'Gà rán','GaRan.jpg',N'Miếng gà giòn tan thơm ngon',25000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(7,'SP38',N'Tokbokki','Tokbokki.jpg',N'Tokbokki dai dai thơm ngon có vị cay tùy theo ý muốn của bạn',20000);
insert into SanPham(MaDMId, MaSP, TenSP, HinhAnh, MoTa, GiaSP) values(7,'SP39',N'KimBap','KimBap.jpg',N'Thành phần: Cà rốt, thanh cua, trứng, kim chi,...',20000);
--
