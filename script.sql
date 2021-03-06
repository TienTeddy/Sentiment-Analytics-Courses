CREATE DATABASE [sentiment-analytics]
GO

USE [sentiment-analytics]
GO
/****** Object:  Table [dbo].[Sentiment]    Script Date: 4/21/2021 10:47:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sentiment](
	[sentiment] [nvarchar](20) NULL,
	[sentimentText] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Tích Cực', N'tôi sẽ học bài cho kỳ thi tới')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Trung Tính', N'tôi thích ca hát nhưng tôi không thích tập hát')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Tiêu Cực', N'nhìn tôi rất xấu trai')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Rất Tiêu Cực', N'nhìn tôi như thằng nghiện')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Hạnh Phúc', N'tôi rất vui')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Phẫn Nộ', N'tôi đang bực mình')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Hạnh Phúc', N'tôi thường nắm tay cô ấy khi xem phim')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Phẫn Nộ', N'tôi ghét bài hát này')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Trung Tính', N'tôi đói bụng nhưng tôi lại lười')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Tiêu Cực', N'mọi thứ quá kinh khủng với tôi')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Rất Tiêu Cực', N'tôi là kẻ nghiện rượu')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Phẫn Nộ', N'người hàng xóm luôn ồn ào')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Hạnh Phúc', N'cô ấy là tất cả đối với tôi')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Hạnh Phúc', N'bài hát này thật hay')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Trung Tính', N'hình như là cô ấy thì phải')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Hạnh Phúc', N'tôi yêu bạn')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Hạnh Phúc', N'yêu')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Tích Cực', N'đẹp')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) VALUES (N'Tiêu Cực', N'xấu')
INSERT [dbo].[Sentiment] ([sentiment], [sentimentText]) 
VALUES
(N'Trung Tính', N'nhưng'), 
(N'Trung Tính', N'mặc dù'), 
(N'Hạnh Phúc', N'thích'),  
(N'Tiêu Cực', N'tôi ghét'),  
(N'Hạnh Phúc', N'tôi thích'),
(N'Tích Cực', N'tôi thích đọc sách'),
(N'Hạnh Phúc',N'hôm nay trời thật đẹp'),
(N'Tích Cực',N'tôi sẽ đậu đại học'),
(N'Hạnh Phúc',N'tôi thật đẹp trai'),
(N'Tích Cực',N'tôi sẽ giúp mọi người'),
(N'Tích Cực',N'giúp đỡ'),
(N'Tiêu Cực',N'la mắng'),
(N'Tiêu Cực',N'chửi bới'),
(N'Hạnh Phúc',N'vui'),
(N'Hạnh Phúc',N'sung sướng'),
(N'Tiêu Cực',N'buồn')
