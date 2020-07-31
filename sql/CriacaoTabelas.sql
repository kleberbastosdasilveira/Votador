
CREATE TABLE Funcionarios (
    Id uuid NOT NULL,
    Nome varchar(200) NOT NULL,
    Email varchar(50) NOT NULL,
    Senha varchar(50) NULL,
    CONSTRAINT PK_Funcionarios PRIMARY KEY (Id)
);

CREATE TABLE Recursos (
    Id uuid NOT NULL,
    TituloRecurso varchar(200) NULL,
    DescricaoRecurso varchar(999) NULL,
    NumeroVotacao integer NOT NULL,
    CONSTRAINT PK_Recursos PRIMARY KEY (Id)
);

CREATE TABLE RegistroVotacoes (
    FuncionarioId uuid NOT NULL,
    RecursoId uuid NOT NULL,
    ComentarioRecurso varchar(999) NOT NULL,
    DataVotacaoRecurso timestamp without time zone NOT NULL,
    CONSTRAINT PK_RegistroVotacoes PRIMARY KEY (FuncionarioId, RecursoId),
    CONSTRAINT FK_RegistroVotacoes_Funcionarios_FuncionarioId FOREIGN KEY (FuncionarioId) REFERENCES Funcionarios (Id) ON DELETE RESTRICT,
    CONSTRAINT FK_RegistroVotacoes_Recursos_RecursoId FOREIGN KEY (RecursoId) REFERENCES Recursos (Id) ON DELETE RESTRICT
);

CREATE INDEX IX_RegistroVotacoes_RecursoId ON RegistroVotacoes (RecursoId);
