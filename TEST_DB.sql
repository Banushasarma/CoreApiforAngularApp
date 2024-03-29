USE [TEST_DB]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 2021-05-16 12:54:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2021-05-16 12:54:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[Age] [int] NOT NULL,
	[DOB] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 2021-05-16 12:54:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2021-05-16 12:54:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Description]) VALUES (1, N'SE')
INSERT [dbo].[Designation] ([Id], [Description]) VALUES (2, N'QA')
INSERT [dbo].[Designation] ([Id], [Description]) VALUES (3, N'Team Lead')
INSERT [dbo].[Designation] ([Id], [Description]) VALUES (4, N'Manager')
INSERT [dbo].[Designation] ([Id], [Description]) VALUES (5, N'Director')
INSERT [dbo].[Designation] ([Id], [Description]) VALUES (6, N'CEO')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [DesignationId], [LocationId], [Age], [DOB]) VALUES (1, N'Banu', 2, 2, 28, CAST(N'1993-11-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [DesignationId], [LocationId], [Age], [DOB]) VALUES (2, N'Virat', 3, 3, 32, CAST(N'1996-10-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [DesignationId], [LocationId], [Age], [DOB]) VALUES (3, N'Rohit', 4, 3, 35, CAST(N'1991-04-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Employee] ([Id], [Name], [DesignationId], [LocationId], [Age], [DOB]) VALUES (4, N'Test', 3, 2, 25, CAST(N'1995-10-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([Id], [Description]) VALUES (1, N'Jaffna')
INSERT [dbo].[Location] ([Id], [Description]) VALUES (2, N'Colombo')
INSERT [dbo].[Location] ([Id], [Description]) VALUES (3, N'Badulla')
INSERT [dbo].[Location] ([Id], [Description]) VALUES (4, N'Kandy')
INSERT [dbo].[Location] ([Id], [Description]) VALUES (5, N'Batticolo')
INSERT [dbo].[Location] ([Id], [Description]) VALUES (6, N'Trinco')
INSERT [dbo].[Location] ([Id], [Description]) VALUES (7, N'Vavuniya')
SET IDENTITY_INSERT [dbo].[Location] OFF
INSERT [dbo].[Login] ([UserName], [Password]) VALUES (N'admin', N'admin')
INSERT [dbo].[Login] ([UserName], [Password]) VALUES (N'abc', N'abc')
INSERT [dbo].[Login] ([UserName], [Password]) VALUES (N'1234', N'1234')
/****** Object:  StoredProcedure [dbo].[Employee_M_Save]    Script Date: 2021-05-16 12:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Banu
-- Create date: 2021-05-16
-- Description:	<Description,,>
-- =============================================
-- Employee_M_Save 0, 'Test', 2, 3, 25, '1995-10-12'
CREATE PROCEDURE [dbo].[Employee_M_Save]
	@Id				INT,
	@Name			VARCHAR(50),
	@LocationId		INT,
	@DesignationId	INT,
	@Age			INT,
	@DOB			DATETIME
AS
BEGIN
	IF EXISTS (SELECT * FROM Employee WHERE Id = @Id)
	BEGIN
		UPDATE Employee SET Name = @Name,
							LocationId = @LocationId,
							DesignationId = @DesignationId,
							Age = @Age,
							DOB = @DOB
		WHERE Id = @Id
	END
	ELSE
	BEGIN
		INSERT INTO Employee([Name], [DesignationId], [LocationId], [Age], [DOB])
		VALUES	(@Name, @DesignationId, @LocationId, @Age, @DOB)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Employee_M_Select]    Script Date: 2021-05-16 12:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Banu
-- Create date: 2021-05-16
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Employee_M_Select]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT E.*,
		L.Description AS 'LocationName',
		D.Description AS 'DesignationName'
	FROM Employee E
	INNER JOIN Location L ON E.LocationId = L.Id
	INNER JOIN Designation D ON E.DesignationId = D.Id
END
GO
/****** Object:  StoredProcedure [dbo].[Login_M_Select]    Script Date: 2021-05-16 12:54:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Banu	
-- Create date: 2021-05-16
-- Description:	<Description,,>
-- =============================================
----- Login_M_Select 'admin', 'admin'
CREATE PROCEDURE [dbo].[Login_M_Select] 
	@UserName	VARCHAR(50), 
	@Password	VARCHAR(50)
AS
BEGIN
	SELECT * FROM Login WHERE UserName = @UserName AND Password = @Password
END
GO
