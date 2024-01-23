# M03UF2_PR1

(Aparece más de un autor del repositorio, pero es por problemas con la cuenta de GitHub cuando hubo cambio de ordenadores)

## InRange:
Dominio: números enteros
<br>
Clases de equivalencia: 2 dentro de [0, 5], 5 dentro de [0, 2], 4 dentro de [3, 1]
<br>
Tipo: válida, válida, inválida
<br>
Salida: TRUE, FALSE, ERROR
<br>
Límite inferior = variable min, límite superior = variable max, que debe ser mayor a min.

## NameCheck:
Dominio: alfabeto
<br>
Clases de equivalencia: nº de comas >= 3, nº de comas < 3
<br>
Tipo: válida, válida
<br>
Salida: TRUE, FALSE
<br>
Límite inferior = 3 comas, límite superior no hay, puedes poner tantas como quieras y deja

## Random
Dominio: números reales
<br>
Clases de equivalencia: [1, 100], [20, 1]
<br>
Tipo: válida, inválida
<br>
Salida: aleatorio entre 1 y 100, error
<br>
Límite inferior = variable min, límite superior = variable max, que debe ser mayor a min.

## Turns
Dominio: array de enteros
<br>
Clases de equivalencia: {0, 1, 2, 3}, {5, 12, -4, 3}, {5, 6, 7, 8}
<br>
Tipo: válida, inválida, inválida
<br>
Salida: la misma array pero desordenada, error, error
<br>
Límite inferior = 0, límite superior = 3

## Attack
Dominio: números reales
<br>
Clases de equivalencia: (120, 3000, 15), (-100, -1300, -20)
<br>
Tipo: válida, inválida (por el filtro de stats de InRange, no pueden haber negativas en ese punto)
<br>
Salida: número natural resultado de la operación.
<br>
Límite inferior = 0, límite superior = 7000 (la vida máxima del monstruo)

## Heal
Dominio: array de números reales
<br>
Clases de equivalencia: { 1000, 2000, 3000, 4000, 5000 }, { -1000, -2000, -3000, -4000, -5000 }
<br>
Tipo: válida, inválida (en ningún momento pueden ser negativas)
<br>
Salida: números reales positivos. Devuelve las stats +500 o hasta el máximo posible. En caso de estar muerto (vida igual a cero), se queda en cero.
<br>
Límite inferior = 0, límite superior la cantidad máxima de cada estadística por jugador

## BubbleSort
Dominio: array de números reales
<br>
Clases de equivalencia: { 1000, 2000, 3000, 4000, 5000 }, { -1000, -2000, -3000, -4000, -5000 }
<br>
Tipo: válida, inválida (en ningún momento pueden ser negativas)
<br>
Salida: la array ordenada de forma descendente.
<br>
Límite inferior = 0, límite superior es la stat más grande.

## NameSort
Dominio: una array de strings y dos arrays de reales (la primera de estas es la segunda pero ordenada de forma descendente)
<br>
Clases de equivalencia: { "Adolfo", "Juan", "Pedro", "Luis", } { 1000, 2000, 3000, 1500 } { 3000, 2000, 1500, 1000 }
<br>
Tipo: válida
<br>
Salida: array de strings. Cada nombre correspondiente a la array de reales desordenada pasa a ordenarse. Estos siguen el mismo "orden de índices" que la array ordenada, por lo que los nombres y números corresponden.
<br>
Límite inferior: de la array de strings es que tenga 3 comas, de las reales es 0. Límite superior: en la array de strings no hay, en la de de reales es el máximo de vida que haya.
