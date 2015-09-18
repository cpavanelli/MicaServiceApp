CREATE TABLE [Restaurante](
[ID]                 INT IDENTITY(1,1) PRIMARY KEY,
[Nome]               VARCHAR(100),
[Cozinha]            VARCHAR(100),
[Bairro]             VARCHAR(100),
[Link]               VARCHAR(100),
[Localizacao]		 VARCHAR(100),
[Nota]               INT,
[Visto1]             BIT,
[Visto2]             BIT
);
 
--ALTER TABLE restaurante
--ADD CONSTRAINT pk_restaurante PRIMARY KEY(Id)

CREATE TABLE [Media](
[ID]          INT IDENTITY(1,1) PRIMARY KEY,
[Nome]        VARCHAR(100),
[Tipo]        VARCHAR(100),
[Nota]        INT,
[Visto1]      BIT,
[Visto2]      BIT
);
 
 
CREATE TABLE [Evento](
[ID]                 INT IDENTITY(1,1) PRIMARY KEY,
[Nome]               VARCHAR(100),
[Inicio]             DATETIME,
[Fim]                DATETIME,
[Link]               VARCHAR(100),
[Localizacao] VARCHAR(100),
[Nota]               INT,
[Visto1]             BIT,
[Visto2]             BIT
);



ALTER TABLE [Restaurante] ADD [Registrado] DATETIME 
ALTER TABLE [Restaurante] ADD [VistoEm] DATETIME

ALTER TABLE [Media] ADD [Registrado] DATETIME 
ALTER TABLE [Media] ADD [VistoEm] DATETIME

ALTER TABLE [Evento] ADD [Registrado] DATETIME 
ALTER TABLE [Evento] ADD [VistoEm] DATETIME


UPDATE [Restaurante] SET [Nota]=0 WHERE [Nota] IS NULL
 UPDATE [Restaurante] SET [Visto1]=0 WHERE [Visto1] IS NULL
 UPDATE [Restaurante] SET [Visto2]=0 WHERE [Visto2] IS NULL


 ALTER TABLE [Restaurante] ALTER COLUMN [Nota] INTEGER NOT NULL
 ALTER TABLE [Restaurante] ALTER COLUMN [Visto1] BIT NOT NULL
 ALTER TABLE [Restaurante] ALTER COLUMN [Visto2] BIT NOT NULL

 ALTER TABLE [Media] ALTER COLUMN [Nota] INTEGER NOT NULL
 ALTER TABLE [Media] ALTER COLUMN [Visto1] BIT NOT NULL
 ALTER TABLE [Media] ALTER COLUMN [Visto2] BIT NOT NULL

 ALTER TABLE [Evento] ALTER COLUMN [Nota] INTEGER NOT NULL
 ALTER TABLE [Evento] ALTER COLUMN [Visto1] BIT NOT NULL
 ALTER TABLE [Evento] ALTER COLUMN [Visto2] BIT NOT NULL

ALTER TABLE [Restaurante] ADD [Detalhes] VARCHAR(MAX) 
ALTER TABLE [Media] ADD [Detalhes] VARCHAR(MAX)
ALTER TABLE [Evento] ADD [Detalhes] VARCHAR(MAX)