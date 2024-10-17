SET IDENTITY_INSERT [dbo].[Disciplinas] ON
INSERT INTO [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioIntegracion]) 
VALUES 
(1, N'Natacion Olimpica', 1999),
(2, N'Atletismo de Larga Distancia', 2005),
(3, N'Triatlón Internacional Competitivo', 2012);
SET IDENTITY_INSERT [dbo].[Disciplinas] OFF
