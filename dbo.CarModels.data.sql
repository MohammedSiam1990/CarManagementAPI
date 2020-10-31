/* Turn Identity Insert ON so records can be inserted in the Identity Column  */
SET IDENTITY_INSERT [dbo].[CarModels] ON
GO

INSERT [dbo].[CarModels] ([ID], [CarTypeID], [ModelName]) VALUES (3, 3, N'دراجة تويوتا')  
GO 

/* Turn Identity Insert OFF  */
SET IDENTITY_INSERT [dbo].[CarModels] OFF
GO