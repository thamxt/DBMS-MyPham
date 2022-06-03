--TAO CSDL (DATABASE)------------------------------------------------------------------------------------------------------------------------------
create database QuanLyCuaHangMyPham2
go

use QuanLyCuaHangMyPham2
go




--TAO CAC BANG (TABLE)------------------------------------------------------------------------------------------------------------------------------

------------QUY DINH KICH THUOC CAC BIEN-------------------
--UseID:		20									-------						
--Ten : 		50									-------
--Mat khau : 	20									-------
--Ma :			10									-------
--S?T :			11									-------
--?ia chi :		100									-------
--Chuc vu :		30									-------
--image :		2GB									-------
-----------------------------------------------------------

	

--1.Table [dbo].[TAIKHOAN]---------------------------------

CREATE TABLE [dbo].[TAIKHOAN](
	[useID] [varchar](20) NOT NULL, 
	[password] [varchar](20) NULL,
	[role] [int] NULL,
)

--2.Table [dbo].[LOHANG]------------------------------------
CREATE TABLE [dbo].[LOHANG](
	[MaLo] [int] NOT NULL, 
	[NgayLap] [DATE] NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[MaCT] [nvarchar](10) NOT NULL, 
)

--3.Table [dbo].[LOHANGCHITIET]------------------------------
CREATE TABLE [dbo].[LOHANGCHITIET](
	[MaLo_CT] [int] NOT NULL, 
	[MaSP] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NULL,
	[Gia] [int] NULL,
	[MucGiamGia] [int] NULL,
)
--4.Table [dbo].[SANPHAM]-------------------------------------
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [nvarchar](10) NOT NULL,
	[TenSP] [nvarchar](50) NULL,
	[Gia] [int] NULL,
	[NSX] [date] NULL,
	[HSD] [date] NULL,
	[MaDM] [nvarchar](10) NOT NULL,
	[HinhSP] [varchar](max) NULL,
)

--5.Table [dbo].[DANHMUC]-------------------------------------
CREATE TABLE [dbo].[DANHMUC](
	[MaDM] [nvarchar](10) NOT NULL, 
	[TenDM] [nvarchar](50) NULL unique, ------------------Ten danh muc la duy nhat
)
--6.Table [dbo].[KHACHHANG]-----------------------------------
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [nvarchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT_KH] [nchar](11) NULL,
)
--7.Table [dbo].[HOADON]--------------------------------------
CREATE TABLE [dbo].[HOADON](
	[MaHD] [int] NOT NULL,
	[NgayLapHD] [date] NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[MaKH] [nvarchar](10) NOT NULL,
)
--8.Table [dbo].[CHITIETHD]-----------------------------------
CREATE TABLE [dbo].[CHITIETHD](
	[MaSP] [nvarchar](10) NOT NULL,
	[MaHD] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[Gia] [int] NULL,
	[MucGiamGia] [int] NULL,
)
--9.Table [dbo].[NHANVIEN]------------------------------------
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [nvarchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](30) NULL,
	[SDT_NV] [nchar](11) NULL,
	[NgayLam] [date] NULL,
	[Luong] [int] NULL,
	
	[NgaySinh] [date] Null
)
--10.Table [dbo].[CONGTY]------------------------------------
CREATE TABLE [dbo].[CONGTY](
	[MaCT] [nvarchar](10) NOT NULL,
	[TenCT] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT_CT] [nchar](11) NULL,
	[NgayHopTac] [date] NULL,
	[GiayPhep] [nvarchar](100) NULL,
	
)


--TAO RANG BUOC (CONSTRAINT) CHO CAC BANG (TABLE)----------------------------------------------------------------------------------------------------------
--1.RANG BUOC NOT NULL VA UNIQUE-------------------------------------------------
		--tao cung voi table 
--2.RANG BUOC KHOA CHINH (PRIMARY KEY)--------------------------------------------------
----------------------------1.TAIKHOAN
alter table TAIKHOAN
add  CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY
(
	[useID]
)
----------------------------2.LOHANG
alter table LOHANG
add  CONSTRAINT [PK_LOHANG] PRIMARY KEY 
(
	[MaLo]
)
----------------------------3.SANPHAM
alter table SANPHAM
add CONSTRAINT [PK_SANPHAM] PRIMARY KEY  
(
	[MaSP]
)
----------------------------4.DANHMUC
alter table DANHMUC
add CONSTRAINT [PK_DANHMUC] PRIMARY KEY 
(
	[MaDM] 
)
----------------------------5.KHACHHANG
alter table KHACHHANG
add  CONSTRAINT [PK_KHACHHANG] PRIMARY KEY
(
	[MaKH]
)
----------------------------6.HOADON
alter table HOADON
add  CONSTRAINT [PK_HOADON] PRIMARY KEY 
(
	[MaHD] 
)

----------------------------7.NHANVIEN
alter table NHANVIEN
add CONSTRAINT [PK_NHANVIEN] PRIMARY KEY 
(
	[MaNV] 
)
----------------------------8.LOHANGCHITIET
alter table LOHANGCHITIET
add  CONSTRAINT [PK_LOHANGCHITIET] PRIMARY KEY 
(
	[MaLo_CT],
	[MaSP]
)
---------------------------9.CHITIETHD
alter table CHITIETHD
add  CONSTRAINT [PK_CHITIETHD] PRIMARY KEY 
(
	[MaHD],
	[MaSP]
)
---------------------------10.CONGTY
alter table CONGTY
add  CONSTRAINT [PK_CONGTY] PRIMARY KEY 
(
	[MaCT]
)
-------------------------------------

--3.RANG BUOC KHOA NGOAI (FOREIGN) KEY)-------------------------------------------------


------------------------------------1 . LOHANG--->CONGTY
alter table LOHANG
add constraint FK_LOHANG_CONGTY
foreign key (MaCT)
references CONGTY(MaCT)
------------------------------------2 . LOHANG--->NHANVIEN
alter table LOHANG
add constraint FK_LOHANG_NHANVIEN
foreign key (MaNV)
references NHANVIEN(MaNV)
------------------------------------3 .LOHANGCHITIET--->SANPHAM
alter table LOHANGCHITIET
add constraint FK_LOHANGCHITIET_SANPHAM
foreign key (MaSP)
references SANPHAM(MaSP)
------------------------------------4 . LOHANGCHITIET--->LOHANG
alter table LOHANGCHITIET
add constraint FK_LOHANGCHITIET_LOHANG
foreign key (MaLo_CT)
references LOHANG(MaLo)
------------------------------------5 . SANPHAM =--> DANHMUC
alter table SANPHAM
add constraint FK_SANPHAM_DANHMUC
foreign key (MaDM)
references DANHMUC(MaDM)
------------------------------------6 .CHITIETHD=---> SANPHAM
alter table CHITIETHD
add constraint FK_CHITIETHD_SANPHAM
foreign key (MaSP)
references SANPHAM(MaSP)
------------------------------------7 . CHITIETHD =---> HOADON
alter table CHITIETHD
add constraint FK_CHITIETHD_HOADON
foreign key (MaHD)
references HOADON(MaHD)
------------------------------------8 . HOADON -> KHACHHANG
alter table HOADON
add constraint FK_HOADON_KHACHHANG
foreign key (MaKH)
references KHACHHANG(MaKH)
------------------------------------9 . HOADON -> NHANVIEN
alter table HOADON
add constraint FK_HOADON_NHANVIEN
foreign key (MaNV)
references NHANVIEN(MaNV)
------------------------------------

--4.RANG BUOC CHECK: dam bao cac gia tri trong mot cot thoa man mot so dieu kien--------

-------------------------Luong nhan vien be hon 8000000 tranh truong hop danh may sai
ALTER TABLE NHANVIEN
ADD CHECK (Luong >= 8000000);
-------------------------gia san pham lon hon 1000
ALTER TABLE SANPHAM
ADD CHECK (Gia > 1000);
-------------------------so luong san pham hoa don thanh toan cua khach hang lon hon 0
ALTER TABLE CHITIETHD
ADD CHECK (SoLuong > 0);
-------------------------so luong lon hon 0 va gia lon hon 1000 trong bang phan phoi
ALTER TABLE LOHANGCHITIET
ADD CONSTRAINT CHK_LOHANGCHITIET CHECK (Gia > 1000 AND SoLuong > 0);


----------------------------TRIGGER-----------------------------------------------------------
go
create trigger [dbo].[trig_PhanQuyen] on [dbo].[TAIKHOAN]
after insert
as
begin
	declare @user varchar(20)
	set @user=(select useID from inserted)

	declare @pass varchar(20)
	set @pass=(select password from inserted)

	declare @role int
	set @role=(select role from inserted)
	DECLARE @t nvarchar(4000)

	SET @t = N'CREATE LOGIN ' + QUOTENAME(@user) + ' WITH PASSWORD = ' + QUOTENAME(@pass, '''')
	EXEC(@t)
	SET @t = N'CREATE USER ' + QUOTENAME(@user) + ' FOR LOGIN ' + QUOTENAME(@user)
	EXEC(@t)
	if( @role = 1)
		begin
			SET @t = N'Grant all on ' + 'SANPHAM' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.addSANPHAM' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.deleteSANPHAM' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.updateSANPHAM' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'DANHMUC' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.addDanhMuc' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.deleteDanhMuc' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.updateDanhMuc' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'HOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.addHOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.deleteHOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.updateHOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.xoaHOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.taoHOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.suaHOADON' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'KHACHHANG' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.addKhachHang' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.deleteKhachHang' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
			SET @t = N'Grant all on ' + 'dbo.updateKhachHang' + ' to ' + QUOTENAME(@user)
			EXEC(@t)
		end
 else if ( @role = 0)
		begin
			SET @t = N'ALTER SERVER ROLE [sysadmin] ADD MEMBER' + QUOTENAME(@user)
			EXEC(@t)
		end
		end
go

------------------------------------------
Create TRIGGER [dbo].[CHECK_USERS] --Tên Trigger check tai khoan
ON [dbo].[TAIKHOAN]
FOR UPDATE,INSERT
AS
	BEGIN
		declare @userID nchar(20) , @temp int 
		select @userID = inserted.useID from inserted
		select @temp=count(*) from dbo.TAIKHOAN
		where useID=@userID
		if (@temp>1)
	begin
		PRINT N'TÀI KHO?N ?ã T?n T?i'
		ROLLBACK TRANSACTION		
	end
END
go

-----------------------
create trigger [dbo].[CHECK_SP] ----- trigger check ten san phaaem
on [dbo].[SANPHAM]
for update,insert 
as 
	begin
		declare @TenSP nvarchar(50), @temp int
		SELECT @TenSP=inserted.TenSP FROM inserted
		SELECT @TEMP=COUNT(*) FROM dbo.SANPHAM
		WHERE TenSP=@TenSP
		IF (@TEMP>1)
	BEGIN
		PRINT N'SP ?ã T?n T?i'
		ROLLBACK TRANSACTION
	END
	end
	go
	------------------------------------------------------------
GO
Create TRIGGER [dbo].[CHECK_SDT] --Tên Trigger check so dien thoai
ON [dbo].[NHANVIEN]
FOR UPDATE,INSERT
AS
	BEGIN
		declare @SDT_NV nchar(11) , @temp int
		select @SDT_NV=inserted.SDT_NV from inserted
		select @temp =count(*) from dbo.NHANVIEN
		WHERE SDT_NV=@SDT_NV
		if (@temp>1)
	begin
		PRINT N' SDT BI TRUNG ROI'
		ROLLBACK TRANSACTION		
	end
END

-------------------------------------------------------------------
create trigger Check_Soluong on LOHANGCHITIET
after insert, update
as
	begin 
		declare @soluong as int 
		select @soluong=inserted.SoLuong from inserted
		if (@soluong<0)
			begin
				rollback transaction
			end
	end
go
create trigger Check_HSD on SANPHAM
after insert ,update
as
begin
declare  @hsd date

select @hsd=inserted.HSD from inserted
if (@hsd < getdate())
begin
rollback transaction
end
end

------------------------------------------------------------------

create Trigger [dbo].[check_Tuoi] 
On [dbo].[NHANVIEN]
after insert ,update
As
	BEGIN		
			Declare @NgaySinh date
			Declare @age int
			select @NgaySinh= inserted.NgaySinh from inserted
			  

			If (datediff(year,@NgaySinh,getdate()) <18  )   
		BEGIN
			PRINT N'kHONG DU TUOI LAO DONG'
			Rollback TRANSACTION
		END

End


--------------------------------------------------------------
go
-----View-----
------------ bao coa doanh thu---------------
create View [BAOCAODOANHTHU] as
select SANPHAM.TenSP,CHITIETHD.SoLuong,CHITIETHD.Gia,HOADON.NgayLapHD
from SANPHAM,HOADON,CHITIETHD
where CHITIETHD.MaHD=HOADON.MaHD and CHITIETHD.MaSP=SANPHAM.MaSP
go
------------- thong tin nhan vien---------------------
create View [THONGTINNHANVIEN] AS
SELECT TenNV,NgaySinh,ChucVu,SDT_NV,Luong
from NHANVIEN
go
---- chi tiet nhap hang------------
create view [CHITIETNHAPHANG]
AS
SELECT SANPHAM.MaSP,SANPHAM.TenSP,LOHANGCHITIET.SoLuong,LOHANGCHITIET.Gia,LOHANG.NgayLap
FROM LOHANG,CONGTY,LOHANGCHITIET,SANPHAM
where (LOHANG.MaCT=CONGTY.MaCT and LOHANG.MaLo=LOHANGCHITIET.MaLo_CT and LOHANGCHITIET.MaSP=SANPHAM.MaSP)
go

--tao view nhap hang
CREATE VIEW THONGKENHAPHANG AS
 SELECT LOHANG.MaLo,LOHANG.MaCT,LOHANG.MaNV,LOHANG.NgayLap,LOHANGCHITIET.MaSP,LOHANGCHITIET.Gia,LOHANGCHITIET.SoLuong,LOHANGCHITIET.MucGiamGia,LOHANGCHITIET.Gia*LOHANGCHITIET.SoLuong - LOHANGCHITIET.MucGiamGia AS ThanhTien 
 FROM LOHANG
 INNER JOIN LOHANGCHITIET
 ON LOHANG.MaLo = LOHANGCHITIET.MaLo_CT;
 go
--tao view ban hang
CREATE VIEW THONGKEBANHANG AS
 SELECT HOADON.MaHD,HOADON.NgayLapHD,HOADON.MaKH,HOADON.MaNV,CHITIETHD.MaSP,CHITIETHD.SoLuong,CHITIETHD.Gia,CHITIETHD.MucGiamGia,CHITIETHD.Gia*CHITIETHD.SoLuong - CHITIETHD.MucGiamGia AS ThanhTien
 FROM HOADON
 INNER JOIN CHITIETHD
 ON HOADON.MaHD = CHITIETHD.MaHD;
 go

 ------------------------Nhap du lieu-----------------------------------------------------------------------------------------------------------------
 -- 1 . Danh muc
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM01',N'N??c hoa');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM02',N'Kem d??ng da');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM03',N'M?t n?');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM04',N'Ph?n trang ?i?m');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM05',N'Nhu?m và t?y tóc');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM06',N'Xà phòng t?m , xà phòng kh? mùi');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM07',N'Ch?t kh? mùi và ch?ng mùi');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM08',N'S?n ph?m t?y lông');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM09',N'S?n ph?m dùng c?o râu');
INSERT INTO DANHMUC (MaDM,TenDM) VALUES ('DM010',N'Các s?n ph?m ?? ch?m sóc r?ng và mi?ng');

-- 2 . Cong ty
INSERT INTO CONGTY(MaCT,TenCT,DiaChi,SDT_CT,NgayHopTac,GiayPhep) 
VALUES ('CT01',N'Công ty m? ph?m Vi?t Nam Bách Th?o D??c',N'BT 06-23, Khu Ngo?i giao ?oàn, B?c T? Liêm, Hà N?i','0888846969','2018-06-09',N'Mã s? thu?: 0201880876');

INSERT INTO CONGTY(MaCT,TenCT,DiaChi,SDT_CT,NgayHopTac,GiayPhep) 
VALUES ('CT02',N'Công ty m? ph?m Vi?t Nam Vedette',N'???ng s? 1, Khu dân c? Ph??c Ki?n A, xã Ph??c Ki?n, Huy?n Nhà Bè, TP H? Chí Minh','1800585876','2019-05-05',N'Gi?y phép ?KKD s? 0312057925 do S? K? Ho?ch và ??u T? TP.HCM c?p');

INSERT INTO CONGTY(MaCT,TenCT,DiaChi,SDT_CT,NgayHopTac,GiayPhep) 
VALUES ('CT03',N'Công ty m? ph?m Vi?t Nam Naunau',N'14A1 H?i V?, Hàng Bông','0938427834','2020-12-01',N'GPKD s? : 0311485660 c?p ngày 21/05/2016');

INSERT INTO CONGTY(MaCT,TenCT,DiaChi,SDT_CT,NgayHopTac,GiayPhep) 
VALUES ('CT04',N'Công ty m? ph?m Vi?t Nam Skina',N' 529/94 Hu?nh V?n Bánh, Ph??ng 14, Phú Nhu?n, Thành ph? H? Chí Minh','1900 6065','2020-05-05',N'GPKD s? : 0311485684 ');

-- 3. Khach hang
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH01',N'Tr?n V?n Tâm',N'Qu?n 9 , TPHCM','0356485987');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH02',N'Tr?n V?n Tâm',N'Qu?n 2 , TPHCM','0323658475');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH03',N'Tr?n V?n Tâm',N'Qu?n 3 , TPHCM','0365985247');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH04',N'Tr?n V?n Tâm',N'Qu?n 5 , TPHCM','0331545648');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH05',N'Tr?n V?n Tâm',N'Qu?n 4 , TPHCM','0314548921');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH06',N'Tr?n V?n Tâm',N'Qu?n 8 , TPHCM','0301231545');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH07',N'Tr?n V?n Tâm',N'Qu?n 7 , TPHCM','0302123154');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH08',N'Tr?n V?n Tâm',N'Qu?n 6 , TPHCM','0302115453');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH09',N'Tr?n V?n Tâm',N'Qu?n 1 , TPHCM','0302132151');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH010',N'Tr?n V?n Tâm',N'Qu?n 10 , TPHCM','0313144415');
INSERT INTO KHACHHANG(MaKH,TenKH,DiaChi,SDT_KH) VALUES (N'KH011',N'Tr?n V?n Tâm',N'Qu?n 9 , TPHCM','0356485984');

-- 4. Nhan vien
INSERT INTO NHANVIEN(MaNV,TenNV,ChucVu,SDT_NV,NgayLam,Luong,NgaySinh) 
VALUES (N'NV01',N'Hoàng Ng?c Trâm',N'Nhân viên','0344646445','2017-05-06',7000000,'1995-05-06');

INSERT INTO NHANVIEN(MaNV,TenNV,ChucVu,SDT_NV,NgayLam,Luong,NgaySinh) 
VALUES (N'NV02',N'Nguy?n ?ình Tùng',N'Nhân viên','0352648569','2018-06-09',6000000,'1993-02-01');

INSERT INTO NHANVIEN(MaNV,TenNV,ChucVu,SDT_NV,NgayLam,Luong,NgaySinh) 
VALUES (N'NV03',N'Võ Hoàng Tam',N'Nhân viên','0356987584','2016-02-06',7500000,'1990-03-01');

INSERT INTO NHANVIEN(MaNV,TenNV,ChucVu,SDT_NV,NgayLam,Luong,NgaySinh) 
VALUES (N'NV04',N'Nguy?n Th? Ki?u Linh',N'Nhân viên','0302365847','2020-02-06',6000000,'1997-06-08');

INSERT INTO NHANVIEN(MaNV,TenNV,ChucVu,SDT_NV,NgayLam,Luong,NgaySinh) 
VALUES (N'NV05',N'Nguy?n V?n ??c',N'Qu?n Lý','0302121145','2015-02-03',7500000,'1990-06-01');

-- 5. San pham

INSERT INTO SANPHAM(MaSP,TenSP,Gia,NSX,HSD,MaDM,HinhSP) 
VALUES (N'SP01',N'Kem D??ng La Roche-Posay Làm D?u',222000,'2020-03-06','2025-03-06','DM02','https://media.hasaki.vn/catalog/product/1/0/100170024-1310_1_img_380x380_64adc6_fit_center.jpg');

INSERT INTO SANPHAM(MaSP,TenSP,Gia,NSX,HSD,MaDM,HinhSP) 
VALUES (N'SP02',N'N??c Hoa Nam HUGO BOSS Just Different EDT 40ml',1520000,'2020-05-06','2025-05-06','DM01','https://media.hasaki.vn/catalog/product/c/h/chung-nhan-dai-ly-phan-phoi-nuoc-hoa-chinh-hang-luxasia_9_img_300x300_b798dd_fit_center.jpg');

INSERT INTO SANPHAM(MaSP,TenSP,Gia,NSX,HSD,MaDM,HinhSP) 
VALUES (N'SP03',N'M?t N? Ng? Môi Laneige H??ng Táo 20g',330000,'2021-03-06','2026-03-06','DM03','https://media.hasaki.vn/catalog/product/g/o/google-shopping-mat-na-ngu-moi-laneige-huong-tao-20g_img_300x300_b798dd_fit_center.jpg');

INSERT INTO SANPHAM(MaSP,TenSP,Gia,NSX,HSD,MaDM,HinhSP) 
VALUES (N'SP04',N'D?u T?y Trang Naris Cosmetic Dành Cho Da M?n 100ml',222000,'2020-03-03','2022-03-03','DM04','https://media.hasaki.vn/catalog/product/d/a/dau-tay-trang-danh-cho-da-mun-naris-100ml_img_300x300_b798dd_fit_center.jpg');

INSERT INTO SANPHAM(MaSP,TenSP,Gia,NSX,HSD,MaDM,HinhSP) 
VALUES (N'SP05',N'Kem Nhu?m Tóc Beautylabo Vanity Color Màu ?en Khói',500000,'2021-03-06','2027-03-06','DM05','https://media.hasaki.vn/catalog/product/g/o/google-shopping-kem-nhuom-toc-beautylabo-vanity-color-mau-den-khoi_img_300x300_b798dd_fit_center.jpg');

-- 7. Lo hang
INSERT INTO LOHANG(MaLo,NgayLap,MaNV,MaCT) VALUES (12,'2021-05-20','NV01','CT01');
INSERT INTO LOHANG(MaLo,NgayLap,MaNV,MaCT) VALUES (13,'2021-06-20','NV02','CT02');
INSERT INTO LOHANG(MaLo,NgayLap,MaNV,MaCT) VALUES (14,'2021-07-20','NV03','CT03');
INSERT INTO LOHANG(MaLo,NgayLap,MaNV,MaCT) VALUES (15,'2021-08-20','NV04','CT04');
-- 8. Lo hang chi tiet
INSERT INTO LOHANGCHITIET(MaLo_CT,MaSP,SoLuong,Gia,MucGiamGia) VALUES (12,N'SP01',50,150000,5000);
INSERT INTO LOHANGCHITIET(MaLo_CT,MaSP,SoLuong,Gia,MucGiamGia) VALUES (13,N'SP02',100,120000,3000);
INSERT INTO LOHANGCHITIET(MaLo_CT,MaSP,SoLuong,Gia,MucGiamGia) VALUES (14,N'SP03',200,230000,10000);
INSERT INTO LOHANGCHITIET(MaLo_CT,MaSP,SoLuong,Gia,MucGiamGia) VALUES (15,N'SP04',50,150000,5000);
-- 9. Hoa don
INSERT INTO HOADON(MaHD,NgayLapHD,MaNV,MaKH) VALUES (01,'2021-07-20',N'NV01',N'KH01');
INSERT INTO HOADON(MaHD,NgayLapHD,MaNV,MaKH) VALUES (02,'2021-08-25',N'NV02',N'KH01');
INSERT INTO HOADON(MaHD,NgayLapHD,MaNV,MaKH) VALUES (03,'2021-06-26',N'NV03',N'KH02');
INSERT INTO HOADON(MaHD,NgayLapHD,MaNV,MaKH) VALUES (04,'2021-07-15',N'NV01',N'KH02');
INSERT INTO HOADON(MaHD,NgayLapHD,MaNV,MaKH) VALUES (05,'2021-06-24',N'NV03',N'KH03');
INSERT INTO HOADON(MaHD,NgayLapHD,MaNV,MaKH) VALUES (06,'2021-08-26',N'NV04',N'KH04');
-- 10. Hoa don chi tiet
INSERT INTO CHITIETHD(MaSP,MaHD,SoLuong,Gia,MucGiamGia) VALUES (N'SP01',01,5,222000,20000);
INSERT INTO CHITIETHD(MaSP,MaHD,SoLuong,Gia,MucGiamGia) VALUES (N'SP02',02,3,1520000,100000);
INSERT INTO CHITIETHD(MaSP,MaHD,SoLuong,Gia,MucGiamGia) VALUES (N'SP03',03,2,330000,20000);
INSERT INTO CHITIETHD(MaSP,MaHD,SoLuong,Gia,MucGiamGia) VALUES (N'SP02',04,4,1520000,100000);
INSERT INTO CHITIETHD(MaSP,MaHD,SoLuong,Gia,MucGiamGia) VALUES (N'SP01',05,6,222000,20000);
INSERT INTO CHITIETHD(MaSP,MaHD,SoLuong,Gia,MucGiamGia) VALUES (N'SP03',06,10,330000,20000);


-----------------------------HAM VA THU TUC-----------------------------------------------------------------------------------------------------------------------


---------------------DUOI GOC DO NHAN VIEN------------------------------
-----1) Danh muc
--them
create proc addDanhMuc(@MaDM nvarchar(10), @TenDM nvarchar(50))
as
begin
	insert into DANHMUC	(MaDM, TenDM) values (@MaDM, @TenDM)
end

-- xoa
create proc deleteDanhMuc(@MaDM nvarchar(10))
as
begin 
	delete from DANHMUC
	where MaDM=@MaDM
end 
-----update
create proc updateDanhMuc(@MaDM nvarchar(10), @TenDM nvarchar(50))
as
begin 
	update DANHMUC
	set TenDM=@TenDM
	where MaDM=@MaDM
end 

-----------2) Khach hang
-- hien thi khach hang
create proc showKHACHHANG
as
begin
	select *from dbo.KHACHHANG
end
--them khach hang
CREATE proc addKhachHang(@MaKH nvarchar(10), @TenKH nvarchar(50), @DiaChi nvarchar(50), @SDT_KH nchar(11))
as
begin
	insert into KHACHHANG (MaKH, TenKH, DiaChi, SDT_KH) values (@MaKH, @TenKH, @DiaChi, @SDT_KH)
end
--xoa
CREATE proc deleteKhachHang(@MaKH nvarchar(10))
as
begin
	delete KHACHHANG
	
	where MaKH=@MaKH
end
--update 
CREATE proc updateKhachHang(@MaKH nvarchar(10), @TenKH nvarchar(50), @DiaChi nvarchar(50), @SDT_KH nchar(11))
as
begin
	update KHACHHANG
	set TenKH=@TenKH, DiaChi=@DiaChi, SDT_KH=@SDT_KH
	where MaKH=@MaKH
end
----------3) chi tiet hoa don
--them (tao ra maHD)
create proc addCHITIETHD(@MaSP nvarchar(10), @SoLuong int, @Gia int, @MucGiamGia int)
as
begin
	declare @MaPhieu int
	set @MaPhieu = (select MAX(MaHD) from CHITIETHD) + 1
	insert into CHITIETHD(MaSP, MaHD, SoLuong,Gia, MucGiamGia) values (@MaSP,@MaPhieu, @SoLuong, @Gia, @MucGiamGia)
end
-- Kiem tra:
--exec addCHITIETHD N'SP01',5, 500000, 50000

--them (them san pham theo MaHD)
create proc addCHITIETHD_ID(@MaSP nvarchar(10),@MaHD int, @SoLuong int, @Gia int, @MucGiamGia int)
as
begin
	declare @MaPhieu int
	set @MaPhieu = @MaHD 
	insert into CHITIETHD(MaSP, MaHD, SoLuong,Gia, MucGiamGia) values (@MaSP,@MaPhieu, @SoLuong, @Gia, @MucGiamGia)
end
-- Kiem tra:
--exec addCHITIETHD N'SP01',9,5, 500000, 50000

--xoa
CREATE proc deleteCHITIETHD(@MaHD int) 
as
begin
	delete CHITIETHD
	
	where MaHD=@MaHD
end
-- xoa san pham khoi hoa don chi tiet
CREATE proc deleteCHITIETHD_SANPHAM(@MaHD int,@MaSP nvarchar(10)) 
as
begin
	delete CHITIETHD
	
	where MaHD=@MaHD and MaSP=@MaSP
end
--update
create proc updateCHITIETHD(@MaSP nvarchar(10), @MaHD int, @SoLuong int, @Gia int, @MucGiamGia int)
as
begin
	update CHITIETHD
	set SoLuong=@SoLuong, Gia=@Gia, MucGiamGia=@MucGiamGia
	where MaHD=@MaHD and MaSP=@MaSP
end
-----------4) cong ty
-- hien thi toan bo du lieu cong ty
create proc showCONGTY
as
begin
	select *from dbo.CONGTY
end
EXEC showCONGTY
--them
create proc addCONGTY(@MaCT nvarchar(10), @TenCT nvarchar(50), @DiaChi nvarchar(50), @SDT_CT nchar(11),
@NgayHopTac date, @GiayPhep nvarchar(100))
as
begin
	insert into CONGTY(MaCT, TenCT, DiaChi, SDT_CT, NgayHopTac, GiayPhep) 
	values (@MaCT, @TenCT, @DiaChi,@SDT_CT, @NgayHopTac, @GiayPhep)
end
--xoa
CREATE proc deleteCONGTY(@MaCT nvarchar(10) )
as
begin
	delete CONGTY
	where MaCT=@MaCT
end
---update
create proc updateCONGTY(@MaCT nvarchar(10), @TenCT nvarchar(50), @DiaChi nvarchar(50), @SDT_CT nchar(11),
@NgayHopTac date, @GiayPhep nvarchar(100))
as
begin
	update CONGTY
	set TenCT=@TenCT, DiaChi=@DiaChi, SDT_CT=@SDT_CT, NgayHopTac=@NgayHopTac, GiayPhep=@GiayPhep
	where MaCT=@MaCT
end
-----------5 HOA DON
--them
create proc addHOADON( @NgayLapHD date, @MaNV nvarchar(10), @MaKH nvarchar(10) )
as
	declare @MaPhieu int
	set @MaPhieu = (select MAX(MaHD) from HOADON) + 1

	insert HOADON
	values (@MaPhieu, @NgayLapHD, @MaNV, @MaKH)

	print N'?ã t?o cho b?n m?t mã hóa ??n '
-- Kiem tra:
--exec addHOADON '2020-03-04', N'NV01', N'KH01'

--xoa
CREATE proc deleteHOADON(@MaHD int )
as
begin
	delete HOADON
	
	where MaHD=@MaHD
end
--sua
create proc updateHOADON(@MaHD int, @NgayLapHD date, @MaNV nvarchar(10), @MaKH nvarchar(10))
as
begin
	update HOADON
	set NgayLapHD=@NgayLapHD, MaNV=@MaNV, MaKH=@MaKH
	where MaHD=@MaHD
end

-- 6) SAN PHAM
--them
create proc addSANPHAM(@MaSP nvarchar(10), @TenSP nvarchar(50) , @Gia int , @NSX date , @HSD date , @MaDM nvarchar(10) , @hinhSP varchar(MAX))
as
begin
	insert into SANPHAM(MaSP, TenSP, Gia ,NSX  , HSD , MaDM, hinhSP ) 
	values (@MaSP , @TenSP  , @Gia  , @NSX  , @HSD  , @MaDM  , @hinhSP)
end
--exec addSANPHAM 'SP06', 'Kem ngh?', 80000 ,'2021-03-06', '2027-03-06','DM02','https://cdn.youmed.vn/tin-tuc/wp-content/uploads/2020/06/img-9441-jpg.jpg.webp'

--xoa
CREATE proc deleteSANPHAM(@MaSP nvarchar(10))
as
begin
	delete SANPHAM
	
	where MaSP=@MaSP
end
--sua
create proc updateSANPHAM(@MaSP nvarchar(10), @TenSP nvarchar(50) , @Gia int , @NSX date , @HSD date , @MaDM nvarchar(10) , @hinhSP varchar(MAX))
as
begin
	update SANPHAM
	set MaSP=@MaSP , TenSP=@TenSP   , Gia=@Gia  , NSX=@NSX   , HSD=@HSD  , MaDM=@MaDM  , HinhSP=@hinhSP  
	where MaSP=@MaSP
end


---------------DUOI GOC DO NHA QUAN LY-----------------------------------------------

-- 7 . Tai Khoan
--them
create proc addTAIKHOAN(@useID varchar(20) , @password varchar(20) , @role int)
as
begin
	insert into TAIKHOAN(useID,password,role ) values (@useID , @password , @role )
end
--exec addTAIKHOAN 'aafjfj' , '123456' , 1 

-- xoa
create proc deleteTAIKHOAN(@useID varchar(20))
as
begin 
	delete from TAIKHOAN
	where useID=@useID
end 
-----update
create proc updateTAIKHOAN(@useID varchar(20) , @password varchar(20) , @role int)
as
begin 
	update TAIKHOAN
	set password=@password ,role=@role
	where useID=@useID
end 

---- view bao cao danh thu-------------
create proc baoCao
as
begin
select * from BAOCAODOANHTHU
end
-----------------------------------------

-- 8 . Lo Hang

-- Them

create procedure [dbo].[addLOHANG] @MaLo int, @NgayLap date , @MaNV nvarchar(10), @MaCT nvarchar(10)
as
	
	insert LOHANG
	values (@MaLo,@NgayLap, @MaNV, @MaCT)

	print N'?ã t?o cho b?n m?t mã ??n nh?p hàng'
-- Ki?m tra:
--exec addLOHANG '2020-03-04', N'NV01', N'CT01'

--xoa
CREATE proc deleteLOHANG(@MaLo int )
as
begin
	delete LOHANG
	
	where MaLo=@MaLo
end
--sua
create proc updateLOHANG(@MaLo int, @NgayLap date, @MaNV nvarchar(10), @MaCT nvarchar(10))
as
begin
	update LOHANG
	set NgayLap=@NgayLap, MaNV=@MaNV, MaCT=@MaCT
	where MaLo=@MaLo
end


-- 9 . Lo Hang chi tiet

-- Them
create procedure [dbo].[addLOHANGCHITIET] @MaLo_CT int, @MaSP nvarchar(10), @SoLuong int, @Gia int , @MucGiamGia int
as
	
	insert LOHANGCHITIET
	values (@MaLo_CT, @MaSP, @SoLuong, @Gia,@MucGiamGia)

	print N'?ã t?o cho b?n m?t mã ??n nh?p hàng chi tiet'

-- Kiem tra:


--xoa
CREATE proc deleteLOHANGCHITIET(@MaLo_CT int)
as
begin
	delete LOHANGCHITIET
	
	where MaLo_CT=@MaLo_CT
end
--update
create proc updateLOHANGCHIIET(@MaLo_CT int, @MaSP nvarchar(10), @SoLuong int, @Gia int , @MucGiamGia int)
as
begin
	update LOHANGCHITIET
	set  SoLuong=@SoLuong, Gia=@Gia, MucGiamGia=@MucGiamGia
	where MaSP=@MaSP and MaLo_CT=@MaLo_CT
end

-- 10 . Nhan vien
-- hien thi nhan vien
create proc showNHANVIEN
as
begin
	select *from dbo.NHANVIEN
end
--them Nhan Vien
CREATE proc addNHANVIEN(@MaNV nvarchar(10), @TenNV nvarchar(50), @ChucVu nvarchar(30), @SDT_NV nchar(11), @NgayLam date, @Luong int, @NgaySinh date)
as
begin
	insert into NHANVIEN(MaNV,TenNV,ChucVu,SDT_NV,NgayLam,Luong,NgaySinh) 
	values (@MaNV,@TenNV,@ChucVu,@SDT_NV,@NgayLam,@Luong,@NgaySinh)
end
--xoa
CREATE proc deleteNHANVIEN(@MaNV nvarchar(10))
as
begin
	delete NHANVIEN
	where MaNV=@MaNV
end
--update 
CREATE proc updateNHANVIEN(@MaNV nvarchar(10), @TenNV nvarchar(50), @ChucVu nvarchar(30), @SDT_NV nchar(11), @NgayLam date, @Luong int, @NgaySinh date)
as
begin
	update NHANVIEN
	set TenNV=@TenNV, ChucVu=@ChucVu , SDT_NV=@SDT_NV , NgayLam=@NgayLam,Luong=@Luong, NgaySinh = @NgaySinh
	where MaNV=@MaNV
end



------------------------------------------------------------------------------------------




-----------------------------------TRANSACTION----------------------------------------------------------------------------------------------------------

-- 1. Them HOADON , CHITIETHD

create proc taoHOADON ( @NgayLapHD date, @MaNV nvarchar(10), @MaKH nvarchar(10) , @MaSP nvarchar(10), @SoLuong int, @Gia int, @MucGiamGia int)
as
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRAN
		BEGIN TRY
		   exec addHOADON @NgayLapHD, @MaNV, @MaKH
		   exec addCHITIETHD @MaSP,@SoLuong, @Gia, @MucGiamGia
		COMMIT
		END TRY
		BEGIN CATCH
		   ROLLBACK
		   DECLARE @ErrorMessage VARCHAR(2000)
		   SELECT @ErrorMessage = 'L?i: ' + ERROR_MESSAGE()
		   RAISERROR(@ErrorMessage, 16, 1)
		END CATCH

		print N'?ã t?o cho b?n m?t hóa ??n '
	END
-- Kiem tra:
-- exec taoHOADON '2021-8-21', N'NV01', N'KH01' , N'SP02', 3, 1520000, 100000

-- 2. Xoa HOADON , CHITIETHD
create proc xoaHOADON ( @MaHD int )
as
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRAN
		BEGIN TRY
		   exec deleteCHITIETHD @MaHD
		   exec deleteHOADON @MaHD
		COMMIT
		END TRY
		BEGIN CATCH
		   ROLLBACK
		   DECLARE @ErrorMessage VARCHAR(2000)
		   SELECT @ErrorMessage = 'L?i: ' + ERROR_MESSAGE()
		   RAISERROR(@ErrorMessage, 16, 1)
		END CATCH

		print N'?ã xóa cho b?n m?t hóa ??n '
	END
-- Kiem tra
--exec xoaHOADON 8

-- 3. Sua HOADON , CHITIETHD
create proc suaHOADON ( @MaHD int, @NgayLapHD date, @MaNV nvarchar(10), @MaKH nvarchar(10) , @MaSP nvarchar(10), @SoLuong int, @Gia int, @MucGiamGia int)
as
	BEGIN
		SET XACT_ABORT ON
		BEGIN TRAN
		BEGIN TRY
		   exec updateHOADON  @MaHD , @NgayLapHD , @MaNV , @MaKH 
		   exec updateCHITIETHD @MaSP , @MaHD , @SoLuong , @Gia , @MucGiamGia
		COMMIT
		END TRY
		BEGIN CATCH
		   ROLLBACK
		   DECLARE @ErrorMessage VARCHAR(2000)
		   SELECT @ErrorMessage = 'L?i: ' + ERROR_MESSAGE()
		   RAISERROR(@ErrorMessage, 16, 1)
		END CATCH

		print N'?ã s?a cho b?n m?t hóa ??n '
	END
-- Kiem tra:
--exec suaHOADON 8,'2021-8-21', N'NV02', N'KH01' , N'SP02', 4, 1520000, 100000 
--------------------------------
----------------------------------------------- store m?i dùng ??
create proc allLoHangChiTiet
as
begin
	select * from LOHANGCHITIET
end

-- exec allLoHangChiTiet
-----------------------------------------------store m?i dùng ??
create proc allSanPham
as
begin
select * from SANPHAM
end

--exec allSanPham
-----------------------------------------------store m?i dùng ??
create proc allLoHang
as
begin
select MaSP,TenSP, Gia, NSX, HSD, MaDM from SANPHAM
end

------------------------------------------------------------------------------------------------

-- 6. Tai khoan
INSERT INTO TAIKHOAN(useID,password,role) VALUES ('phuoc','111222',1);
INSERT INTO TAIKHOAN(useID,password,role) VALUES ('tien','111222',1);
INSERT INTO TAIKHOAN(useID,password,role) VALUES ('tham','111222',0);
INSERT INTO TAIKHOAN(useID,password,role)values ('nhat','123456',1);



-------------------------------------------------------------THEM PHAN THONG KE BAO CAO O DAY---------------------------------------------------------------------

create View [BAOCAOTONKHO] as
select daBan, SL, DANHAP.MaSP, TenSP, (SL- daBan) as conlai
		from SANPHAM, (select sum(SoLuong) as daBan, MaSP
			from CHITIETHD
			group by MaSP) as DABAN,
			(select sum(SoLuong)as SL, MaSP
			from LOHANGCHITIET
			group by MaSP) as DANHAP
where DABAN.MaSP=DANHAP.MaSP and SANPHAM.MaSP=DANHAP.MaSP
go

------------------------------------------------------------------------------------------------------------------------------------------------------------------




