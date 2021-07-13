По домашке на второй урок нужно будет сделать rest сервис. 
В сервис нужно будет подключить DI/EF (Postgre)/Swagger. 
Сервис должен иметь два ендпойнта для чтения данных из базы и создания этих данных. 
В EF нужно будет сделать миграцию для создания структуры в которой будут хранится данные. 
Приложение должно быть правильно структурировано. 
Разбито на зоны ответственности - слои (Cleint Layer (API) / Business Layer / Data Access Layer) 
Сами данные не представляют какую то ценность или значение просто будем хранить и выводить котиков. 
Структура котика 
- кличка nickname
- вес weigth
- цвет color
- наличии прививочного сертификата hasCirtificate
- названием корма feed
Api создания
POST /kittens
{ json body goes here }
Api чтения
GET /kittens
Возвращает массив котиков 
аля [{}]


Володя Смит, [24.06.21 13:55]
version: '3.1'

services:

  db:
    image: postgres
    restart: always
    environment:
      POSTGRES_PASSWORD: root
      POSTGRES_USER: root
    ports:
    - 5432:5432
    volumes:
    - ./pgdata:/var/lib/postgresql/data

  adminer:
    image: adminer
    restart: always
    ports:
      - 8888:8080

volumes:
  pgdata:

Володя Смит, [24.06.21 13:56]
Сохраните себе в docker-cmpose.yaml и запустите docker-compose up -d

