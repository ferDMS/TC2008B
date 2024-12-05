from pulp import LpMaximize, LpProblem, LpVariable, lpSum, LpStatus, value
import matplotlib.pyplot as plt

# Datos adicionales del problema
capacidad = [3, 2]  # Capacidad máxima de monedas que cada equipo puede recolectar

# Datos del problema
num_equipos = 2
num_monedas = 5  # Número total de monedas
valor = [10, 20, 5, 15, 25]  # Valores de las monedas
posiciones = [(1, 2), (2, 3), (3, 1), (4, 2), (5, 3)]  # Coordenadas (x, y) para cada moneda

# Crear el problema de maximización
prob = LpProblem("Coin_Collection", LpMaximize)

# Definir variables de decisión
x = LpVariable.dicts("x", [(i, j) for i in range(num_equipos) for j in range(num_monedas)], 
                     cat='Binary')

# Función objetivo
prob += lpSum([valor[j] * x[(i, j)] for i in range(num_equipos) for j in range(num_monedas)])

# Restricciones
# Cada moneda es recolectada máximo por un equipo
for j in range(num_monedas):
    prob += lpSum([x[(i, j)] for i in range(num_equipos)]) <= 1

# Añadir restricciones de capacidad para cada equipo
for i in range(num_equipos):
    prob += lpSum([x[(i, j)] for j in range(num_monedas)]) <= capacidad[i]

# Resolver el problema
prob.solve()

# Mostrar resultados detallados
print("Estado:", LpStatus[prob.status])

for v in prob.variables():
    if v.varValue > 0:
        print(f"{v.name} = {v.varValue}")

# Mostrar qué monedas recolecta cada equipo
for i in range(num_equipos):
    monedas_recolectadas = [j for j in range(num_monedas) if x[(i, j)].varValue == 1]
    print(f"Equipo {i} recolecta las monedas: {monedas_recolectadas}")

print("Valor total recolectado:", value(prob.objective))

# Crear una lista de colores para cada equipo
colores_equipos = ['red', 'blue']

# Crear una lista para almacenar el color asignado a cada moneda
colores_monedas = ['gray'] * num_monedas

# Asignar colores a las monedas según el equipo que las recolecta
for i in range(num_equipos):
    for j in range(num_monedas):
        if x[(i, j)].varValue == 1:
            colores_monedas[j] = colores_equipos[i]

# Extraer las posiciones x e y de las monedas
x_coords = [pos[0] for pos in posiciones]
y_coords = [pos[1] for pos in posiciones]

# Crear el gráfico de dispersión
plt.scatter(x_coords, y_coords, c=colores_monedas, s=100)

# Añadir etiquetas a las monedas
for idx, (x, y) in enumerate(posiciones):
    plt.text(x + 0.1, y + 0.1, f'Moneda {idx}', fontsize=9)

# Añadir leyenda
from matplotlib.lines import Line2D
legend_elements = [
    Line2D([0], [0], marker='o', color='w', label='Equipo 0',
           markerfacecolor='red', markersize=10),
    Line2D([0], [0], marker='o', color='w', label='Equipo 1',
           markerfacecolor='blue', markersize=10),
    Line2D([0], [0], marker='o', color='w', label='No recolectada',
           markerfacecolor='gray', markersize=10)
]
plt.legend(handles=legend_elements)

# Configurar el gráfico
plt.xlabel('Posición X')
plt.ylabel('Posición Y')
plt.title('Asignación de Monedas a Equipos')
plt.grid(True)
plt.show()
