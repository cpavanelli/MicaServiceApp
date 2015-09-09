CREATE TABLE [Restaurante](
[ID]                 INT IDENTITY(1,1) PRIMARY KEY,
[Nome]               VARCHAR(100),
[Cozinha]            VARCHAR(100),
[Bairro]             VARCHAR(100),
[Link]               VARCHAR(100),
[Localizacao] VARCHAR(100),
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