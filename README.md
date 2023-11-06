# Gerenciamento de heróis
 Aplicação para cadastro de todos os super-heróis

1. Camada de aplicação(Heroi.Api): controladores e serviços da API.
2. Camada de domínio: responsável pela implementação de classes/modelos, as quais serão mapeadas para o banco de dados, além de obter as declarações de interfaces e enums.
3. Camada de infraestrutura: persistência com o banco de dados, utilizando Entity Framework com MySql.

## 🛠️ Construído com

Frontend: 
- Angular
- Angular Material
- SCSS

Backend:
- .NET 6.0
- ASP.NET
- EF Core
- MySql

## ⚙️ Como rodar o projeto

### Backend
 
- abra o diretório 'LembretesApi' pelo Visual Studio.
- substituir string de conexão  nos arquivos appsettings.json e \Infrastructure\Configuracao\ContextDb.cs
- clique no arquivo "LembretesApi.sln"

Abra o terminal e acesse o diretório 'LembretesApi', execute o seguinte comando:

```
dotnet ef database update
```

E para executar o projeto:

```
dotnet run
```

### Frontend

Abra o terminal e acesse o diretório 'frontend', depois execute os seguintes comandos:

```
npm i
```
```
npm start
```


### script do banco
```
create database super_herois;
use super_herois;

 create table Herois (
  Id int auto_increment not null primary key,
  Nome nvarchar(120) not null,
  NomeHeroi varchar(120) not null,
  DataNascimento datetime,
  Altura float not null,
  Peso float not null
);

create table Superpoderes (
  Id int auto_increment not null primary key,
  Superpoder nvarchar(50) not null,
  Descricao nvarchar(250)
); 

CREATE TABLE HeroisSuperpoderes (
    HeroiId INTEGER NOT NULL,
    SuperpoderId INTEGER NOT NULL,
    CONSTRAINT HeroisSuperpoderes PRIMARY KEY (HeroiId, SuperpoderId),
    CONSTRAINT HeroiId FOREIGN KEY (HeroiId) REFERENCES Herois (Id) ON DELETE CASCADE,
    CONSTRAINT SuperpoderId FOREIGN KEY (SuperpoderId) REFERENCES Superpoderes (Id) ON DELETE CASCADE);
    
insert into Superpoderes (Superpoder, Descricao) values 
("Controlar o Tempo", "Poder ir para o futuro ou passado"),
("Magnetismo", "Controle de Metais"),
("Poderes de gelo", "congelar coisas, raio congelante"),
("Psiquismo", "Controlar seres com vida através da mente"),
("Tecnopata", "Controlar aparelhos eletrônicos com a mente"),
("Ultrapassar Objetos", "atravessar paredes"),
("Multiplicar", "voce pode fazer X copias de voce mesmo "),
("Necromântico", "Cria zumbis com criaturas mortas"),
("Manipulação de sombras", "Você poder controlar a escuridão/Sombra ao seu favor"),
("Clarividência", "se comunicar e ver espiritos"),
("Espinhos", ""),
("Controle do Vento", "");
```
