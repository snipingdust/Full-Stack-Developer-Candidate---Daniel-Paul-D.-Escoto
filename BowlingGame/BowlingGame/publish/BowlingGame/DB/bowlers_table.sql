USE [Bowling]
GO

/****** Object:  Table [dbo].[bowlers]    Script Date: 4/15/2022 7:27:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[bowlers](
	[bowler_id] [int] IDENTITY(1,1) NOT NULL,
	[bowler_name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[bowler_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


