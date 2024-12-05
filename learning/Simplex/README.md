# Simplex

## Introducción

Es un algoritmo para resolver problemas de programación lineal. Estos consisten en maximizar o en minimizar en base a una función objetivo linear que está sujeta a un conjunto de restricciones lineales.

Un problema de programación lineal siempre tiene la siguiente forma:

Maximizar / minimizar:

$$
Z = c_1x_1 + c_2x_2 + \ldots + c_n + x_n
$$

Con ciertas restricciones:

$$
a_{11}x_1 + a_{12}x_2 + \ldots + a_{1n}x_n \leq b_1 \\
a_{21}x_1 + a_{22}x_2 + \ldots + a_{2n}x_n \leq b_2 \\
\vdots \\
a_{m1}x_1 + a_{m2}x_2 + \ldots + a_{mn}x_n \leq b_m \\
x_1, x_2, \ldots, x_n \geq 0
$$

