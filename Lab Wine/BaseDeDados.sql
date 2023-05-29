USE master
GO

CREATE DATABASE Projeto
GO

USE Projeto
GO

CREATE TABLE Utilizador(
	ID_Utilizador INT IDENTITY(1,1) NOT NULL,
	Email VARCHAR(MAX) NOT NULL,
	Username VARCHAR(MAX) NOT NULL,
	Pass VARCHAR(MAX) NOT NULL,
	Estado_Conta INT NOT NULL,
	PRIMARY KEY (ID_Utilizador)
)

CREATE TABLE Administrador(
	ID_Administrador INT NOT NULL REFERENCES Utilizador(ID_Utilizador),
	PRIMARY KEY (ID_Administrador)
)

CREATE TABLE Cliente(
	ID_Cliente INT NOT NULL REFERENCES Utilizador(ID_Utilizador),
	PRIMARY KEY (ID_Cliente)
)

CREATE TABLE Garrafeira(
	ID_Garrafeira INT NOT NULL REFERENCES Utilizador(ID_Utilizador),
	Endereco_Codigo VARCHAR(MAX) NOT NULL,
	Endereco_Morada VARCHAR(MAX) NOT NULL,
	Endereco_Localidade VARCHAR(MAX) NOT NULL,
	PRIMARY KEY(ID_Garrafeira)
)

CREATE TABLE Vinho(
	ID_Vinho INT IDENTITY(1,1) NOT NULL,
	Nome_Vinho VARCHAR(MAX) NOT NULL,
	Capacidade FLOAT NOT NULL,
	Foto_Frente VARCHAR(MAX) NOT NULL,
	Foto_Tras VARCHAR(MAX) NOT NULL,
	Foto_Rotulo VARCHAR(MAX) NOT NULL,
	Teor_Alcoolico FLOAT NOT NULL,
	Castas VARCHAR(MAX) NOT NULL,
	Ano_Producao INT NOT NULL,
	PRIMARY KEY (ID_Vinho)
)

CREATE TABLE Gerir(
	ID_Utilizador INT NOT NULL,
	ID_Administrador INT NOT NULL,
	Motivo VARCHAR(MAX) NOT NULL,
	Data_Registo SMALLDATETIME NOT NULL,
	Data_Suspensao SMALLDATETIME,
	PRIMARY KEY (ID_Utilizador),
	FOREIGN KEY (ID_Utilizador) REFERENCES Utilizador(ID_Utilizador),
	FOREIGN KEY (ID_Administrador) REFERENCES Administrador(ID_Administrador)
)

CREATE TABLE Comentar(
	ID_Cliente INT NOT NULL,
	ID_Vinho INT NOT NULL,
	Rating INT NOT NULL,
	Texto_Opiniao VARCHAR(MAX) NOT NULL,
	Data_Comentario SMALLDATETIME NOT NULL,
	PRIMARY KEY (ID_Cliente,ID_Vinho),
	FOREIGN KEY (ID_Cliente) REFERENCES Cliente (ID_Cliente),
	FOREIGN KEY (ID_Vinho) REFERENCES Vinho (ID_Vinho)
)

CREATE TABLE Inserir(
	ID_Garrafeira INT NOT NULL,
	ID_Vinho INT NOT NULL,
	Preco FLOAT NOT NULL,
	Stock INT NOT NULL,
	Data_Insercao SMALLDATETIME NOT NULL,
	PRIMARY KEY (ID_Garrafeira,ID_Vinho),
	FOREIGN KEY (ID_Garrafeira) REFERENCES Garrafeira (ID_Garrafeira),
	FOREIGN KEY (ID_Vinho) REFERENCES Vinho (ID_Vinho)
)


CREATE TABLE Regiao(
	ID_Regiao INT IDENTITY(1,1) NOT NULL,
	Nome_Regiao VARCHAR(MAX) NOT NULL,
	PRIMARY KEY (ID_Regiao)
)

CREATE TABLE Produtor(
	ID_Produtor INT IDENTITY(1,1) NOT NULL,
	Nome_Produtor VARCHAR(MAX) NOT NULL,
	PRIMARY KEY (ID_Produtor)
)

CREATE TABLE Tipo(
	ID_Tipo INT IDENTITY(1,1) NOT NULL,
	Nome_Tipo VARCHAR(MAX) NOT NULL,
	PRIMARY KEY (ID_Tipo)
)

CREATE TABLE Possuir(
	ID_Vinho INT NOT NULL,
	ID_Tipo INT NOT NULL,
	ID_Produtor INT NOT NULL,
	ID_Regiao INT NOT NULL,
	PRIMARY KEY (ID_Vinho),
	FOREIGN KEY (ID_Vinho) REFERENCES Vinho (ID_Vinho),
	FOREIGN KEY (ID_Tipo) REFERENCES Tipo(ID_Tipo),
	FOREIGN KEY (ID_Produtor) REFERENCES Produtor(ID_Produtor),
	FOREIGN KEY (ID_Regiao) REFERENCES Regiao(ID_Regiao)
)

CREATE TABLE Sugerir(
	ID_Cliente_Envia INT NOT NULL,
	ID_Cliente_Recebe INT NOT NULL,
	ID_Vinho INT NOT NULL,
	Estado_Notificacao BIT,
	Data_Sugestao SMALLDATETIME NOT NULL,
	Texto_Sugestao VARCHAR(MAX) NOT NULL,
	PRIMARY KEY (ID_Cliente_Envia,ID_Cliente_Recebe,ID_Vinho),
	FOREIGN KEY (ID_Cliente_Envia) REFERENCES Cliente (ID_Cliente),
	FOREIGN KEY (ID_Cliente_Recebe) REFERENCES Cliente (ID_Cliente),
	FOREIGN KEY (ID_Vinho) REFERENCES Vinho (ID_Vinho)
)