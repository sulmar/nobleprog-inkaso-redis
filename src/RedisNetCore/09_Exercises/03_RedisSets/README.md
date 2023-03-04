# Hash

## Zadanie 

Utwórz usługę do wiekowania płatności.

Należności przeterminowane

| kontrahent | 1-60 dni  | 62-180 dni | 181-360 dni | > 361 dni |
|------------|-----------|------------|-------------|-----------|
| c:1        | fv:1,fv:2 |            | fv:7        | fv:9      |
| c:2        | fv:3      | fv:4,fv:5  | fv:8        |           |
| c:3        |           | fv:6       |             | fv:10     |
|            |           |            |             |           |
|            | ...       | ...        | ...         | ...       |


- Pobranie należności przeterminowanych z danego przedziału dla kontrahenta
~~~
GET /customers/{id}/overdue/{range}
Accept: application/json
~~~

- Pobranie wszystkich należności przeterminowanych dla kontrahenta
~~~
GET /customers/{id}/overdue/all
Accept: application/json
~~~

