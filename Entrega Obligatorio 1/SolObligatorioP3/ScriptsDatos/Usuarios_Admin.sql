SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([Id], [Email_Valor], [RolUsuario], [FechaRegistro], [IdAdminRegistro], [Nombre], [Contrasena_Valor]) VALUES (1, N'hola@gmail.com', 0, N'2024-09-21 00:00:00', 0, NULL, N'Hola1234!')
INSERT INTO [dbo].[Usuarios] ([Id], [Email_Valor], [RolUsuario], [FechaRegistro], [IdAdminRegistro], [Nombre], [Contrasena_Valor]) VALUES (2, N'hola2@gmail.com', 1, N'2024-09-25 08:00:56', 3, NULL, N'Hola1234!')
INSERT INTO [dbo].[Usuarios] ([Id], [Email_Valor], [RolUsuario], [FechaRegistro], [IdAdminRegistro], [Nombre], [Contrasena_Valor]) VALUES (3, N'nicolas@gmail.com', 0, N'2024-09-25 00:00:00', 0, N'Nicolas Gimenez', N'Nico@Gimenez12')
INSERT INTO [dbo].[Usuarios] ([Id], [Email_Valor], [RolUsuario], [FechaRegistro], [IdAdminRegistro], [Nombre], [Contrasena_Valor]) VALUES (4, N'cristian@gmail.com', 0, N'2024-09-25 00:00:00', 0, N'Cristian Garcia', N'Cris@Garcia12')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
