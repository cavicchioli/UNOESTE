CREATE TABLE Equipes
(
	equ_codigo  int  IDENTITY (1,1) ,
	equ_nome  varchar(30)  NULL ,
	equ_bandeira  image  NULL ,
	gru_codigo  int  NULL 
)
go


ALTER TABLE Equipes
	ADD CONSTRAINT  XPKEquipes PRIMARY KEY (equ_codigo  ASC)
go


CREATE TABLE Fases
(
	fas_codigo  int  IDENTITY (1,1) ,
	fas_descricao  varchar(30)  NULL 
)
go


ALTER TABLE Fases
	ADD CONSTRAINT  XPKFases PRIMARY KEY (fas_codigo  ASC)
go


CREATE TABLE Grupos
(
	gru_codigo  int  IDENTITY (1,1) ,
	gru_descricao  varchar(20)  NOT NULL 
)
go


ALTER TABLE Grupos
	ADD CONSTRAINT  XPKGrupos PRIMARY KEY (gru_codigo  ASC)
go


CREATE TABLE Jogadores
(
	jog_codigo  int  IDENTITY (1,1) ,
	jog_nome  varchar(30)  NOT NULL ,
	jog_dtnascimento  datetime  NULL ,
	jog_posicao  char(1)  NULL ,
	jog_foto  image  NULL ,
	equ_codigo  int  NULL 
)
go


ALTER TABLE Jogadores
	ADD CONSTRAINT  XPKJogadores PRIMARY KEY (jog_codigo  ASC)
go


CREATE TABLE Jogos
(
	jog_codigo  int  IDENTITY (1,1) ,
	jog_data  datetime  NULL ,
	jog_hora  varchar(5)  NULL ,
	jog_local  varchar(30)  NULL ,
	jog_goltime1  int  NULL ,
	jog_goltime2  int  NULL ,
	equ_codigo2  int  NULL ,
	equ_codigo1  int  NULL ,
	fas_codigo  int  NULL 
)
go


ALTER TABLE Jogos
	ADD CONSTRAINT  XPKJogos PRIMARY KEY (jog_codigo  ASC)
go



ALTER TABLE Equipes
	ADD CONSTRAINT  R_1 FOREIGN KEY (gru_codigo) REFERENCES Grupos(gru_codigo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Jogadores
	ADD CONSTRAINT  R_5 FOREIGN KEY (equ_codigo) REFERENCES Equipes(equ_codigo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go



ALTER TABLE Jogos
	ADD CONSTRAINT  R_2 FOREIGN KEY (equ_codigo2) REFERENCES Equipes(equ_codigo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE Jogos
	ADD CONSTRAINT  R_3 FOREIGN KEY (equ_codigo1) REFERENCES Equipes(equ_codigo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


ALTER TABLE Jogos
	ADD CONSTRAINT  R_4 FOREIGN KEY (fas_codigo) REFERENCES Fases(fas_codigo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go


