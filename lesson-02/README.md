�� ������� �� ������ ���� ����� ����� ������� rest ������. 
� ������ ����� ����� ���������� DI/EF (Postgre)/Swagger. 
������ ������ ����� ��� ��������� ��� ������ ������ �� ���� � �������� ���� ������. 
� EF ����� ����� ������� �������� ��� �������� ��������� � ������� ����� �������� ������. 
���������� ������ ���� ��������� ���������������. 
������� �� ���� ��������������� - ���� (Cleint Layer (API) / Business Layer / Data Access Layer) 
���� ������ �� ������������ ����� �� �������� ��� �������� ������ ����� ������� � �������� �������. 
��������� ������ 
- ������ nickname
- ��� weigth
- ���� color
- ������� ������������ ����������� hasCirtificate
- ��������� ����� feed
Api ��������
POST /kittens
{ json body goes here }
Api ������
GET /kittens
���������� ������ ������� 
��� [{}]


������ ����, [24.06.21 13:55]
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

������ ����, [24.06.21 13:56]
��������� ���� � docker-cmpose.yaml � ��������� docker-compose up -d

