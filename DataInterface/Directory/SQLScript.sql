USE [master]
GO
/****** Object:  Database [FreeTrak]    Script Date: 11/5/2017 10:45:06 PM ******/
CREATE DATABASE [FreeTrak]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FreeTrak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FreeTrak.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FreeTrak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\FreeTrak_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FreeTrak] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FreeTrak].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FreeTrak] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FreeTrak] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FreeTrak] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FreeTrak] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FreeTrak] SET ARITHABORT OFF 
GO
ALTER DATABASE [FreeTrak] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FreeTrak] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FreeTrak] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FreeTrak] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FreeTrak] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FreeTrak] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FreeTrak] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FreeTrak] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FreeTrak] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FreeTrak] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FreeTrak] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FreeTrak] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FreeTrak] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FreeTrak] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FreeTrak] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FreeTrak] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FreeTrak] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FreeTrak] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FreeTrak] SET  MULTI_USER 
GO
ALTER DATABASE [FreeTrak] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FreeTrak] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FreeTrak] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FreeTrak] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [FreeTrak] SET DELAYED_DURABILITY = DISABLED 
GO
USE [FreeTrak]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchID] [varchar](50) NULL,
	[u_Branchname] [varchar](50) NULL,
	[u_Branchcode] [varchar](50) NULL,
	[r_ParentBranch] [varchar](50) NULL,
	[f_Address] [varchar](250) NULL,
	[s_flag] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SystemCertificates]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemCertificates](
	[CertificateID] [int] IDENTITY(1,1) NOT NULL,
	[CertificateAuthority] [varchar](50) NULL,
	[CertificateOwner] [varchar](50) NULL,
	[CertificateKey] [varchar](50) NULL,
	[CertificateStatus] [int] NULL,
	[CertificationDate] [datetime] NULL,
	[RevokeDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SystemNotice]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SystemNotice](
	[NoticeID] [int] NULL,
	[NoticeBy] [varchar](50) NULL,
	[Message] [varchar](150) NULL,
	[CreatedOn] [datetime] NULL,
	[ExpireOn] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserID] [varchar](50) NOT NULL,
	[u_username] [varchar](50) NULL,
	[u_password] [varchar](50) NULL,
	[r_userstatus] [varchar](50) NULL,
	[r_userlevel] [varchar](50) NULL,
	[r_Designation] [varchar](50) NULL,
	[f_firstname] [varchar](50) NULL,
	[f_lastname] [varchar](50) NULL,
	[f_middlename] [varchar](50) NULL,
	[f_gender] [varchar](50) NULL,
	[f_email] [varchar](50) NULL,
	[f_contactno] [varchar](50) NULL,
	[f_photo] [varchar](150) NULL,
	[f_address] [varchar](250) NULL,
	[r_branch] [varchar](50) NULL,
	[f_employeeid] [varchar](50) NULL,
	[f_TIN] [varchar](50) NULL,
	[f_SSS] [varchar](50) NULL,
	[s_flag] [int] NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDesignation]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDesignation](
	[UserDesignationID] [int] IDENTITY(1,1) NOT NULL,
	[u_UserDesignationCode] [varchar](50) NULL,
	[f_Description] [nchar](10) NULL,
	[r_isAir] [int] NULL,
	[r_isSea] [int] NULL,
	[s_flag] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserLevel]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserLevel](
	[UserLevelID] [int] IDENTITY(1,1) NOT NULL,
	[u_UserLevelCode] [varchar](50) NULL,
	[f_Description] [varchar](150) NULL,
	[s_flag] [nchar](10) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserStatus](
	[UserStatusID] [int] IDENTITY(1,1) NOT NULL,
	[UserStatusCode] [varchar](50) NULL,
	[f_Description] [varchar](50) NULL,
	[r_isActiveLogin] [varchar](50) NULL,
	[s_flag] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[pr_CreateCertificate]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec pr_CreateCertificate 'Admin','Admin','Nathan PC'
CREATE PROCEDURE [dbo].[pr_CreateCertificate]
	-- Add the parameters for the stored procedure here
	@certificateAuthority varchar(50),
	@certificatePassword varchar(5),
	@certificateOwner varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		DECLARE @Userid as varchar(50);
		DECLARE @issuer as varchar(50);
		DECLARE @cert as varchar(50);

		select  @Userid = UserId,@issuer= f_lastname+', '+f_firstname from dbo.UserAccount where u_username=@certificateAuthority AND u_password=@certificatePassword and r_userlevel=5;
		set @cert = NEWID();
		if(@Userid is not null)
		begin
				insert into dbo.SystemCertificates([CertificateAuthority],[CertificateOwner],[CertificateKey],[CertificateStatus],[CertificationDate])
				SELECT @Userid,@certificateOwner,@cert,1,GETDATE();

				select 'Certicate Issued By '+@issuer +' on  '+CONVERT(varchar,getdate()) as 'Details', @cert as 'Certificate'
		end
		else
		begin
				select 'Unable to create certificate. User Account may not have sufficient privileges or Username/Password maybe wrong' as 'Details'
		end
		
	
END

GO
/****** Object:  StoredProcedure [dbo].[pr_Login]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--exec pr_Login 'ADE449BC-1F5F-4516-A9B1-5F65F87E76F4','Admin','@dmin'
CREATE PROCEDURE [dbo].[pr_Login]
	@Certifcate varchar(50),
	@username varchar(50),
	@password varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @isValid as int;
	set @isValid =0;
	select @isValid = count([CertificateID]) FROM [dbo].[SystemCertificates] where [CertificateKey]= @Certifcate and [CertificateStatus] =1

    -- Insert statements for procedure here
	if(@isValid > 0)
	begin
		SELECT UserID
			  ,u_username
			  ,r_userstatus
			  ,r_userlevel
			  ,f_firstname
			  ,f_lastname
			  ,f_middlename
			  ,f_email
			  ,f_gender
			  ,f_contactno
			  ,ISNULL(f_photo,'None') as f_photo
			  ,ua.f_address
			  ,r_branch
			  ,f_employeeid
			  ,f_TIN
			  ,f_SSS
			  ,r_Designation
			  ,ud.u_UserDesignationCode as vw_desgination
			  ,us.UserStatusCode  as vw_userstatus
			  ,ul.u_UserLevelCode as vw_userlevel
			  ,ud.r_isAir
			  ,ud.r_isSea
			  ,br.u_Branchname as vw_Branch
		  FROM [dbo].[UserAccount] ua
		  left join dbo.UserLevel ul on ul.UserLevelID=ua.r_userlevel
		  left join dbo.UserDesignation ud on ud.UserDesignationID = ua.r_Designation
		  left join dbo.UserStatus us on us.UserStatusID=ua.r_userstatus
		  left join dbo.Branches br on ua.r_branch = br.BranchID
		  where u_username=@username and u_password=@password and ua.s_flag =1;
	end
	else
	begin
		if(LTRIM(RTRIM(@Certifcate)) !='')
		begin
			select 'Invalid Browser Certificate. Contact System Administrator'
		end
		else
		begin
			select 'No Certificate has been installed for this browser. Contact System Administrator'
		end
		
	end
END

GO
/****** Object:  StoredProcedure [dbo].[vw_getSystemNotices]    Script Date: 11/5/2017 10:45:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[vw_getSystemNotices]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT NoticeID,'<u>'+ua.f_lastname+', '+ua.f_firstname+'</u> <br/> ['+br.u_Branchname+' - '+dg.u_UserDesignationCode+']' as NoticeBy,[Message] 
	from SystemNotice sn 
	inner join dbo.UserAccount ua on sn.NoticeBy = ua.UserID 
	inner join dbo.Branches br on ua.r_branch = br.BranchID
	inner join dbo.UserDesignation dg on ua.r_Designation = dg.UserDesignationID
	order by NoticeID desc
END

GO
USE [master]
GO
ALTER DATABASE [FreeTrak] SET  READ_WRITE 
GO
