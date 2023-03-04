# Strings

## Zadanie 
Utwórz usługę REST API do pobierania kursu wybranej tabeli i waluty z NBP API (http://api.nbp.pl) i ogranicz ilość zapytań do bramki NBP za pomocą REDIS

Wskazówka: Kursy zmieniane są raz dziennie
Endoint powinien wyglądać w ten sposób:

~~~
GET /rates/{table}/{code}
Accept: application/json
~~~

Skorzystaj:
GET https://api.nbp.pl/api/exchangerates/rates/{table}/{code}/today?format=json

