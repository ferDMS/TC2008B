import numpy as np
import math

vector1 = np.array([0, 1, 0])
vector2 = np.array([1, 0, 0])

magn1 = math.sqrt(vector1[0]*vector1[0]+vector1[1]*vector1[1]+vector1[2]*vector1[2])
magn2 = math.sqrt(vector2[0]*vector2[0]+vector2[1]*vector2[1]+vector2[2]*vector2[2])

dotprod = np.dot(vector1,vector2)

print(dotprod)

thetarad=math.acos(dotprod/)
thetadeg = thetarad * 180 / math.pi