USE [master]
GO

/****** Object:  Database [ProjekatBioskop5]    Script Date: 30-Aug-20 12:05:32 ******/
CREATE DATABASE [ProjekatBioskop5]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjekatBioskop5', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjekatBioskop5.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjekatBioskop5_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjekatBioskop5_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjekatBioskop5].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ProjekatBioskop5] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET ARITHABORT OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ProjekatBioskop5] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ProjekatBioskop5] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ProjekatBioskop5] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ProjekatBioskop5] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ProjekatBioskop5] SET  MULTI_USER 
GO

ALTER DATABASE [ProjekatBioskop5] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ProjekatBioskop5] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ProjekatBioskop5] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ProjekatBioskop5] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ProjekatBioskop5] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ProjekatBioskop5] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ProjekatBioskop5] SET  READ_WRITE 
GO

