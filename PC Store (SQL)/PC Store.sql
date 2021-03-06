USE [master]
GO
/****** Object:  Database [Computer Store]    Script Date: 02.07.2022 23:55:07 ******/
CREATE DATABASE [Computer Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Computer Store', FILENAME = N'D:\UserDataBases\Computer Store.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Computer Store_log', FILENAME = N'D:\UserDataBases\Computer Store_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Computer Store] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Computer Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Computer Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Computer Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Computer Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Computer Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Computer Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [Computer Store] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Computer Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Computer Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Computer Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Computer Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Computer Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Computer Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Computer Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Computer Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Computer Store] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Computer Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Computer Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Computer Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Computer Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Computer Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Computer Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Computer Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Computer Store] SET RECOVERY FULL 
GO
ALTER DATABASE [Computer Store] SET  MULTI_USER 
GO
ALTER DATABASE [Computer Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Computer Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Computer Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Computer Store] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Computer Store] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Computer Store] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Computer Store', N'ON'
GO
ALTER DATABASE [Computer Store] SET QUERY_STORE = OFF
GO
USE [Computer Store]
GO
/****** Object:  Table [dbo].[Заказ]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказ](
	[ID Пользователя] [int] NOT NULL,
	[Дата] [varchar](50) NULL,
	[Код Товары заказов] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Код Товары заказов] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователи]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователи](
	[ID Пользователя] [int] IDENTITY(1,1) NOT NULL,
	[Логин] [varchar](50) NOT NULL,
	[Пароль] [varchar](50) NOT NULL,
	[Заказ] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID Пользователя] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары](
	[Код товара] [varchar](50) NOT NULL,
	[Название] [varchar](50) NULL,
	[Производитель] [varchar](50) NULL,
	[Категория] [varchar](50) NULL,
	[Цена] [money] NULL,
	[Количество] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Код товара] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары заказов]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары заказов](
	[Код товара] [varchar](50) NOT NULL,
	[Код Товары заказов] [varchar](50) NOT NULL,
	[Количество] [int] NULL,
	[Название] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Код товара] ASC,
	[Код Товары заказов] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Чек]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Чек](
	[Логин] [varchar](50) NULL,
	[Название товара] [varchar](50) NULL,
	[Сумма] [money] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Пользователи] FOREIGN KEY([ID Пользователя])
REFERENCES [dbo].[Пользователи] ([ID Пользователя])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Пользователи]
GO
ALTER TABLE [dbo].[Товары заказов]  WITH CHECK ADD  CONSTRAINT [FK_Товары заказов_Заказ] FOREIGN KEY([Код Товары заказов])
REFERENCES [dbo].[Заказ] ([Код Товары заказов])
GO
ALTER TABLE [dbo].[Товары заказов] CHECK CONSTRAINT [FK_Товары заказов_Заказ]
GO
ALTER TABLE [dbo].[Товары заказов]  WITH CHECK ADD  CONSTRAINT [FK_Товары заказов_Товары] FOREIGN KEY([Код товара])
REFERENCES [dbo].[Товары] ([Код товара])
GO
ALTER TABLE [dbo].[Товары заказов] CHECK CONSTRAINT [FK_Товары заказов_Товары]
GO
/****** Object:  StoredProcedure [dbo].[insP]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[insP]  
  @Логин varchar(50),    
  @Пароль vARCHAR(50)
as
BEGIN     
     INSERT INTO Пользователи(Логин,Пароль)
     VALUES(@Логин, @Пароль);      
END
GO
/****** Object:  StoredProcedure [dbo].[selUser]    Script Date: 02.07.2022 23:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[selUser]

@Логин varchar(50),
@Пароль varchar(50)
as
begin
Select * From Пользователи Where Логин = @Логин AND Пароль = @Пароль
end
GO
USE [master]
GO
ALTER DATABASE [Computer Store] SET  READ_WRITE 
GO
