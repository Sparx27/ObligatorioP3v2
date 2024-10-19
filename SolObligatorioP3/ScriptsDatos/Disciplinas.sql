SET IDENTITY_INSERT [dbo].[Disciplinas] ON
INSERT INTO [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioIntegracion]) 
VALUES 
(1, N'Natacion Olimpica', 1999),
(2, N'Atletismo de Larga Distancia', 2005),
(3, N'Triatlón Internacional Competitivo', 2012),
(4, N'Triatlón Internacional', 2012),
(5, N'Atletismo de Corta Distancia', 2012),
(6, N'Natación Olímpica', 2018),
(7, N'Tira al Blanco Olímpico', 1990),
(8, N'Salto Largo con Barra', 1996),
(9, N'Carrera de Obstáculos', 1985),
(10, N'Carrera de Bicicletas', 1980);
SET IDENTITY_INSERT [dbo].[Disciplinas] OFF
