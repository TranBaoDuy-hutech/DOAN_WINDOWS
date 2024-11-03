USE [DOAN_WINDOWS]
GO
/****** Object:  Database [DOAN_WINDOWS]    Script Date: 03/11/2024 8:18:07 CH ******/
CREATE DATABASE [DOAN_WINDOWS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DOAN_WINDOWS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLLL\MSSQL\DATA\DOAN_WINDOWS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DOAN_WINDOWS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLLL\MSSQL\DATA\DOAN_WINDOWS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DOAN_WINDOWS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DOAN_WINDOWS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DOAN_WINDOWS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET ARITHABORT OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DOAN_WINDOWS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DOAN_WINDOWS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DOAN_WINDOWS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DOAN_WINDOWS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DOAN_WINDOWS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DOAN_WINDOWS] SET  MULTI_USER 
GO
ALTER DATABASE [DOAN_WINDOWS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DOAN_WINDOWS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DOAN_WINDOWS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DOAN_WINDOWS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DOAN_WINDOWS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DOAN_WINDOWS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DOAN_WINDOWS] SET QUERY_STORE = ON
GO
ALTER DATABASE [DOAN_WINDOWS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DOAN_WINDOWS]
GO
/****** Object:  Table [dbo].[CT_HOADON]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_HOADON](
	[MAHD] [int] NOT NULL,
	[MASACH] [int] NOT NULL,
	[NGAYLAP] [date] NULL,
	[SOLUONG] [int] NULL,
	[TONGTIEN] [int] NULL,
	[TIENNHAN] [int] NULL,
	[TIENTHUA] [int] NULL,
 CONSTRAINT [PK__CT_HOADO__B3C3682A40B18213] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MASACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_PHIEUNHAP]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEUNHAP](
	[MAPHIEUNHAP] [int] NOT NULL,
	[MASACH] [int] NOT NULL,
	[SOLUONG] [int] NULL,
	[NGAYNHAP] [date] NULL,
 CONSTRAINT [PK__CT_PHIEU__DCDE3D4FAB59542C] PRIMARY KEY CLUSTERED 
(
	[MAPHIEUNHAP] ASC,
	[MASACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [int] NOT NULL,
	[NGAYLAPHD] [date] NULL,
	[TENKH] [varchar](255) NULL,
	[SDTKH] [varchar](15) NULL,
	[MANV] [int] NULL,
	[TONGTIEN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LUONG]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LUONG](
	[MALUONG] [int] NOT NULL,
	[MANV] [int] NULL,
	[THANG] [int] NULL,
	[NAM] [int] NULL,
	[LUONGTHANG] [float] NULL,
	[TENNV] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MALUONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [int] NOT NULL,
	[TENNV] [varchar](255) NULL,
	[NGAYSINH] [date] NULL,
	[DIACHI] [varchar](255) NULL,
	[SDT] [varchar](15) NULL,
	[EMAIL] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MAPHIEUNHAP] [int] NOT NULL,
	[NGAYNHAP] [date] NULL,
	[NCC] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAPHIEUNHAP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SACH](
	[MASACH] [int] NOT NULL,
	[TENSACH] [nvarchar](255) NULL,
	[TACGIA] [varchar](255) NULL,
	[TENTHELOAI] [nvarchar](50) NULL,
	[SL] [int] NULL,
	[GIA] [decimal](10, 0) NULL,
	[MATHELOAISACH] [int] NULL,
 CONSTRAINT [PK__SACH__3FC48E4C80D06D4F] PRIMARY KEY CLUSTERED 
(
	[MASACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THELOAISACH]    Script Date: 03/11/2024 8:18:07 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAISACH](
	[MATHELOAISACH] [int] NOT NULL,
	[TENTHELOAISACH] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MATHELOAISACH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CT_PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK__CT_PHIEUN__MAPHI__5441852A] FOREIGN KEY([MAPHIEUNHAP])
REFERENCES [dbo].[PHIEUNHAP] ([MAPHIEUNHAP])
GO
ALTER TABLE [dbo].[CT_PHIEUNHAP] CHECK CONSTRAINT [FK__CT_PHIEUN__MAPHI__5441852A]
GO
ALTER TABLE [dbo].[CT_PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK__CT_PHIEUN__MASAC__5535A963] FOREIGN KEY([MASACH])
REFERENCES [dbo].[SACH] ([MASACH])
GO
ALTER TABLE [dbo].[CT_PHIEUNHAP] CHECK CONSTRAINT [FK__CT_PHIEUN__MASAC__5535A963]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[LUONG]  WITH CHECK ADD FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK__SACH__MATHELOAIS__4F7CD00D] FOREIGN KEY([MATHELOAISACH])
REFERENCES [dbo].[THELOAISACH] ([MATHELOAISACH])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK__SACH__MATHELOAIS__4F7CD00D]
GO
USE [master]
GO
ALTER DATABASE [DOAN_WINDOWS] SET  READ_WRITE 
GO
select *from SACH