# TesteMicroService
Projeto WebAPI utilizando ASP.NET Core, banco MySQL no Docker, Postman para realizar os testes, envio de e-mail pelo sistema, testes de unidade, testes de integração e publicado no Azure.

## Prévia do Projeto
Deixei uma prévia do projeto hospedado no [Azure](https://testemicroservice.azurewebsites.net/CadastroPessoaFisicaSemBanco). Como estou usando a hospedagem grátis, essa WebAPI pode ser usada no máximo 1 hora por dia e não utilizando Banco de Dados. Mas pode ser usada como prévia do projeto.


## Testando o projeto
Nesse passo a passo, você terá 3 opções para testar o projeto:
* Teste de Integração e Unidade
* Teste utilizando PostMan
* Teste no Azure

## Antes de executar a opção 1 ou 2 dos testes. Será necessário configurar o Ambiente. 
A opção 3 que é o teste no Azure, não necessita de configuração do Ambiente. 

### 1 - Criando o Banco de Dados
Dentro da pasta Docker, existe um arquivo "docker-compose". Acesse o caminho do arquivo pelo Terminal e execute
```
"docker-compose up" 
```
Esse comando irá criar uma imagem no Docker, com o banco de dados MySQL pronto para realizar o teste do projeto.
Depois disso será necessário executar a imagem do Docker utilizando o Docker Desktop ou comandos Docker.

### 2 - Criando o Banco do projeto
Dentro da pasta TesteMicroServico abra o arquivo TesteMicroServico.sln pelo Visual Studio. 
No terminal do Visual Studio execute o comando
```
update-database
```
Esse comando irá criar o banco de dados do projeto na Imagem do Docker e criar todas as tabelas necessárias para os testes do projeto.

## 1 - Teste de Integração e Unidade
Acesse o Gerenciador de Testes do Visual Studio e execute todos ou testes ou o teste que você quiser acompanhar.

## 2 - Teste utilizando PostMan
Acesse a pasta "Postman" e importe o arquivo "Teste Micro Service.postman_collection" no Postman.
Utilizando o Visual Studio, execute o projeto no IIS Express e clique no teste que você quiser acompanhar pelo Postman.

## 3 - Teste no Azure
Acesse a pasta "Postman" e importe o arquivo "Teste Micro Service.postman_collection" no Postman. Clique no teste que você quiser acompanhar pelo Postman.
