# Escenario 1 autoridad en el servidor sin interpolacion

El input del cliente tarda unos milisegundos en llegar lo que hace que sea incomodo moverse, ademas como no hay interpolacion se ve como se refresca el movimiento de los jugadores 30 veces for segundo y se ve que va a saltos, el host si va a una velocidad normal.

# Escenario 2 autoridad en el cliente con interpolacion y con una conexion de mobile 3G

En sete caso, se ve como el input del host y del cliente reaccionan al momento, sin embargo cuando se mueven los personajes van a saltos asi que en este caso ni la interpolacion hace que el movimiento se vea mas suave en red por culpa de que la red va extremadamente mal

# Escenario 3 autoridad en el servidor con interpolacion

El cliente tiene un pequeño delay en el input pero al estar la interpolacion ya no va saltos.