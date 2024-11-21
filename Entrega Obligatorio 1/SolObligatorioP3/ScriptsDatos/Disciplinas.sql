SET IDENTITY_INSERT [dbo].[Disciplinas] ON
INSERT INTO [dbo].[Disciplinas] ([Id], [Nombre_Valor], [AnioIntegracion]) 
VALUES 
(1, N'Natacion Olimpica', 1999),
(2, N'Atletismo de Larga Distancia', 2005),
(3, N'Triatlón Internacional Competitivo', 2012),
(4, N'Escalada en Roca para Competencias', 2016),
(5, N'Ciclismo de Montaña Extremo', 2009),
(6, N'Danza Deportiva Internacional', 2014),
(7, N'Levantamiento de Pesas Olímpico', 2001),
(8, N'Esgrima de Alto Rendimiento', 2003),
(9, N'Remando en Competencias Internacionales', 2010),
(10, N'Tenis de Mesa Profesional', 2007);
SET IDENTITY_INSERT [dbo].[Disciplinas] OFF
