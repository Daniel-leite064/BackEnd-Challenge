# BackEnd-Challenge

(On root)
docker-compose up -d

WEB API disponível na porta 3333 (alterar compose caso queira)
Para acessar: http://localhost:3333/swagger/index.html

(On Infra)
dotnet ef --startup-project ../BackEnd.api/ database update

O Projeto utiliza Localstack para instanciar serviços como S3 e SQS (localmente)
https://www.localstack.cloud/

Caso queira, utilize AWS Cli para se comunicar com o container.
Trocar network do compose caso queira.
Exemplo: Listagem de buckets do s3 

aws --endpoint-url=http://10.0.2.20:4566 s3 ls

Para entrar no container localstack e gerenciar serviços (AWS CLI inclusa): 
docker exec -it localstack bash


## Requisitos a desenvolver:

- Eu como entregador quero alugar uma moto por um período.

- Eu como entregador quero informar a data que irei devolver a moto e consultar o valor total da locação.

- Eu como admin quero cadastrar um pedido na plataforma e disponibilizar para os entregadores aptos efetuarem a entrega.

- Eu como admin quero consultar todos entregadoeres que foram notificados de um pedido.

- Eu como entregador quero aceitar um pedido.

- Eu como entregador quero efetuar a entrega do pedido.


## Diferenciais a desenvolver:

- Testes unitários

- Testes de integração

- Logs bem estruturados
