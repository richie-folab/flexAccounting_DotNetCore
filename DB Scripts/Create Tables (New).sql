DROP TABLE Entries
GO
DROP TABLE Headers
GO
DROP TABLE Applications
GO
DROP TABLE TranCodes
go

CREATE TABLE TranCodes (
  TranCode			    VARCHAR(40) NOT NULL,
  CoreBankingTC	        VARCHAR(40) NOT NULL,
  CoreBankingRvslTC     VARCHAR(40) NULL,
  Status			    VARCHAR(10) NOT NULL,
  CreatedBy		        VARCHAR(80) NOT NULL,
  CreatedDate		    DATETIME DEFAULT GETDATE(),
  ModifiedBy		    VARCHAR(80)     NULL,
  ModifiedDate		    DATETIME NULL,
  PRIMARY KEY(TranCode)
);

CREATE TABLE Applications (
  Id				INTEGER  IdENTITY(1,1),
  Name				VARCHAR(80) NOT NULL,
  Status			VARCHAR(10) default 'ACTIVE',
  CreatedBy		    VARCHAR(80) NOT NULL,
  CreatedDate		DATETIME DEFAULT GETDATE(),
  ModifiedBy		VARCHAR(80) NULL,
  ModifiedDate		DATETIME NULL,
  PRIMARY KEY(Id)
);

CREATE UNIQUE NONCLUSTERED INDEX AK_Name
ON Applications(Name);

CREATE TABLE Headers (
  Id INTEGER NOT NULL IdENTITY(1,1),
  ApplicationId INTEGER  NOT NULL,
  AccountingId VARCHAR(80) NOT NULL,
  Narration VARCHAR(120) NOT NULL,
  ChannelId VARCHAR(40) NOT NULL,
  CoreBankingRef VARCHAR(80) NOT NULL,
  Status		VARCHAR(10) NOT NULL,
  CreatedBy VARCHAR(80) NOT NULL,
  CreatedDate DATETIME DEFAULT GETDATE(),
  PRIMARY KEY(Id),
  INDEX Header_FKIndex1(ApplicationId),
  FOREIGN KEY(ApplicationId)
    REFERENCES Applications(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Entries (
  Id            INTEGER  NOT NULL IdENTITY(1,1),
  HeaderId      INTEGER NOT NULL,
  AccountingId  VARCHAR(80) NOT NULL,
  AcctNo        VARCHAR(100) NOT NULL,
  TranCode      VARCHAR(40) NOT NULL,
  DrCr          VARCHAR(100) NOT NULL,
  Amount        VARCHAR(100) NOT NULL,
  Currency      VARCHAR(80) NOT NULL,
  Narration     VARCHAR(300) NOT NULL,
  IncludeIf     VARCHAR(300) NOT NULL,
  CreatedBy     VARCHAR(80) NOT NULL,
  CreatedDate   DATETIME DEFAULT GETDATE(),
  Remark        VARCHAR(100) NULL,
  PRIMARY KEY(Id),
  INDEX Entries_FKIndex1(HeaderId),
  INDEX Entries_FKIndex2(TranCode),
  FOREIGN KEY(HeaderId)
    REFERENCES Headers(Id)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(TranCode)
    REFERENCES TranCodes(TranCode)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

