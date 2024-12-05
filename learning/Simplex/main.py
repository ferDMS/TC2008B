from scipy.optimize import linprog

"""
Ejemplo 1

Z = ingresos totales
x = productos
c = relacion de productos según condición
b = cantidad de productos que se pueden hacer totales

max Z = 3x_1 + 5x_2
s.t.: 
    2x_1 + x_2 <= 10
    x_1 + 3x_2 <= 15
    x_1, x_2 >= 0
"""
c = [-3, -5]
A = [[2,1], [1,3]]
b = [10, 15]
x_bounds = (0, None)
y_bounds = (0, None)
result = linprog(c, A_ub=A, b_ub=b, bounds=[x_bounds, y_bounds], method='simplex')
# Print result
print(result)


"""
Ejemplo 3

We have two factories, instead of just using two variables for each, like x_1 and x_2 for factory 1 and 2 respectively, because we have constraints involving more than one destination we must be able to produce a result where we can divide the total product accordingly to each destination.

Thus, we make x_factory1 = x_1 + x_2, and x_factory2 = x_3 + x_4. So, x_1 and x_3 will be produce taken from each factory into destination 1, and x_2 and x_3 will be produce taken from each factory into destination 2.

min Z = 4x_1 + 6x_2 + 3x_3 + 5x_4
s.t.:
    x_1 + x_2 = 20   # Factory 1's total produce
    x_3 + x_4 = 30   # Factory 2's total produce
    x_1 + x_3 >= 25  # Produce arriving at Destination 1
    x_2 + x_4 >= 25  # Produce arriving at Destination 2
"""
c = [4 , 6 , 3 , 5]
A_eq = [[1 , 1 , 0 , 0] , [0 , 0 , 1 , 1]]
b_eq = [20 , 30]
A_ub = [[1 , 0 , 1 , 0] , [0 , 1 , 0 , 1]]
b_ub = [25 , 25]
result = linprog (c , A_eq = A_eq , b_eq = b_eq , A_ub = A_ub , b_ub = b_ub,bounds =[ x_bounds ] * 4, method = "simplex")
print("Resultado: " , result)


"""
Ejemplo avanzado 1

Se busca minimizar el tiempo en que se obtienen recursos disponibles en diferentes posiciones (i, j), con cierta cantidad de recolectores. Cada recolector tiene un tiempo límite de recolección para cada posición y una capacidad máxima de recolección por 

"""