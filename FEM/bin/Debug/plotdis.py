import sys
import numpy as np
import math as m
import matplotlib.pyplot as plt
from matplotlib.patches import Polygon

# Vẽ chuyển vị của khung

def plotElements(elementNodes, nodeCoordinates, c, lt, lw, lg):
    import sys
    import numpy as np
    import math as m
    import matplotlib.pyplot as plt
    from matplotlib.patches import Polygon

    for i in range(np.size(elementNodes,0)):
        x1 = nodeCoordinates[elementNodes[i,0]-1,0]
        x2 = nodeCoordinates[elementNodes[i,1]-1,0]
        y1 = nodeCoordinates[elementNodes[i,0]-1,1]
        y2 = nodeCoordinates[elementNodes[i,1]-1,1]
        plt.plot([x1,x2],[y1,y2],color=c,linestyle=lt, linewidth=lw)
    
   
def plotDis(elementNodes, nodeCoordinates,displacements): # Hàm vẽ chuyển vị
    import sys
    import numpy as np
    import math as m
    import matplotlib.pyplot as plt
    from matplotlib.patches import Polygon
    import os

    elementNodes_1 = elementNodes
    n_rows = elementNodes_1.GetLength(0)
    n_cols = elementNodes_1.GetLength(1)
    elementNodes= np.zeros((n_rows,n_cols),dtype=int)
    for i in range(n_rows):
        for j in range(n_cols):
            elementNodes[i, j] = elementNodes_1[i, j]
    elementNodes = np.matrix(elementNodes)

    nodeCor_1 = nodeCoordinates
    n_rows_1 = nodeCor_1.GetLength(0)
    n_cols_1 = nodeCor_1.GetLength(1)
    nodeCoordinates = np.zeros((n_rows_1,n_cols_1),dtype=float)
    for i in range(n_rows_1):
        for j in range(n_cols_1):
            nodeCoordinates[i, j] = nodeCor_1[i, j]
    nodeCoordinates=np.matrix(nodeCoordinates)

    displacements_1=displacements
    n_rows_2=displacements_1.GetLength(0)
    n_cols_2=displacements_1.GetLength(0)
    displacements=np.zeros((n_rows_2,1),dtype=float)
    for i in range(n_rows_2):
        displacements[i]=displacements_1[i]

    for i in range(np.size(elementNodes,0)):
        x1 = nodeCoordinates[elementNodes[i,0]-1,0]
        x2 = nodeCoordinates[elementNodes[i,1]-1,0]
        y1 = nodeCoordinates[elementNodes[i,0]-1,1]
        y2 = nodeCoordinates[elementNodes[i,1]-1,1]
        plt.plot([x1,x2],[y1,y2],color='b',linestyle='--', linewidth=1)

    for i in range(np.size(elementNodes,0)):
        dx1= displacements[(elementNodes[i,0]-1)*2,0]#chuyển vi của điển đầu phần tử i+1 theo x
        # print((elementNodes[i,0]-1)*2)
        dx2= displacements[(elementNodes[i,1]-1)*2,0]
        # print((elementNodes[i,1]-1)*2)
        dy1= displacements[(elementNodes[i,0]-1)*2+1,0]
        # print((elementNodes[i,0]-1)*2+1)
        dy2= displacements[(elementNodes[i,1]-1)*2+1,0]
        # print((elementNodes[i,1]-1)*2+1)
        x1 = nodeCoordinates[elementNodes[i,0]-1,0] + dx1*5000
        x2 = nodeCoordinates[elementNodes[i,1]-1,0] + dx2*5000
        y1 = nodeCoordinates[elementNodes[i,0]-1,1] + dy1*5000
        y2 = nodeCoordinates[elementNodes[i,1]-1,1] + dy2*5000
        plt.plot([x1,x2],[y1,y2],color='r',linestyle='-', linewidth=2,marker="s")
    plt.savefig('E:/My file/Code/C#/FEM/FEM/bin/Debug/'+'dis.png')

    return os.path.abspath('E:/My file/Code/C#/FEM/FEM/bin/Debug/dis.png')

def plot_axial_force(elementNodes, nodeCoordinates, axial_internalforce ): #hàm vẽ viểu đồ nội lực
    import sys
    import numpy as np
    import math as m
    import matplotlib.pyplot as plt
    from matplotlib.patches import Polygon
    import os
    elementNodes_1 = elementNodes
    n_rows = elementNodes_1.GetLength(0)
    n_cols = elementNodes_1.GetLength(1)
    elementNodes= np.zeros((n_rows,n_cols),dtype=int)
    for i in range(n_rows):
        for j in range(n_cols):
            elementNodes[i, j] = elementNodes_1[i, j]
    elementNodes=np.matrix(elementNodes)

    nodeCor_1 = nodeCoordinates
    n_rows_1 = nodeCor_1.GetLength(0)
    n_cols_1 = nodeCor_1.GetLength(1)
    nodeCoordinates = np.zeros((n_rows_1,n_cols_1),dtype=float)
    for i in range(n_rows_1):
        for j in range(n_cols_1):
            nodeCoordinates[i, j] = nodeCor_1[i, j]
    nodeCoordinates=np.matrix(nodeCoordinates)

    internal_1 = axial_internalforce
    n_rows_2 = internal_1.GetLength(0)
    axial_internalforce = np.zeros((n_rows_2,1),dtype=float)
    for i in range(n_rows_2):
        axial_internalforce[i] = internal_1[i]
    
    zoom = 0.0001

    angle=np.zeros((np.size(elementNodes,0),1))
    for i in range(np.size(elementNodes,0)):
        # delta_x = point_2.x - point_1.x
        # delta_z = point_2.z - point_1.z 
        delta_x = nodeCoordinates[elementNodes[i,0]-1,0] - nodeCoordinates[elementNodes[i,1]-1,0]
        delta_y = nodeCoordinates[elementNodes[i,0]-1,1] - nodeCoordinates[elementNodes[i,1]-1,1]
        # dot product v_x = [1, 0] ; v = [delta_x, delta_z]
        # dot product = 1 * delta_x + 0 * delta_z -> delta_x

        ai = m.acos(delta_x / m.sqrt(delta_x**2 + delta_y**2))
        if delta_y < 0:
            ai = 2 * m.pi - ai
        angle[i] = ai

    Pos_of_axial_force = np.zeros((np.size(elementNodes,0),4))
    for i in range(np.size(elementNodes,0)):
        cos = m.cos(0.5 * m.pi + angle[i])
        sin = m.sin(0.5 * m.pi +angle[i])
        Pos_of_axial_force[i,0] = nodeCoordinates[elementNodes[i,0]-1,0] + axial_internalforce[i] * cos * zoom 
        Pos_of_axial_force[i,1] = nodeCoordinates[elementNodes[i,0]-1,1] + axial_internalforce[i] * sin * zoom 
        Pos_of_axial_force[i,2] = nodeCoordinates[elementNodes[i,1]-1,0] + axial_internalforce[i] * cos * zoom 
        Pos_of_axial_force[i,3] = nodeCoordinates[elementNodes[i,1]-1,1] + axial_internalforce[i] * sin * zoom

    zoom = 0.00001
    fig, ax = plt.subplots()
    plotElements(elementNodes, nodeCoordinates, c='b', lt='-', lw = 2, lg = 1)
    for i in range(np.size(elementNodes,0)):
        x1 = nodeCoordinates[elementNodes[i,0]-1,0] #Nút đầu
        y1 = nodeCoordinates[elementNodes[i,0]-1,1]
        x2 = nodeCoordinates[elementNodes[i,1]-1,0] # nút đuôi
        y2 = nodeCoordinates[elementNodes[i,1]-1,1]
        xf1 = Pos_of_axial_force[i,0]
        yf1 = Pos_of_axial_force[i,1]
        xf2 = Pos_of_axial_force[i,2]
        yf2 = Pos_of_axial_force[i,3]

        ax.plot([xf1,xf2],
                [yf1,yf2],
                 color='w',
                linestyle='-',
                linewidth=0.5)
        ax.plot([x1,xf1],
                [y1,yf1],
                 color='w',
                linestyle='-',
                linewidth=0.5)
        ax.plot([x2,xf2],
                [y2,yf2],
                 color='w',
                linestyle='-',
                linewidth=0.5)
        if axial_internalforce[i] > 0:
            p = plt.Polygon(np.array([[x2,y2],[x1, y1],[xf1,yf1],[xf2,yf2]]), color = 'g', alpha=0.3)
        else:
            p = plt.Polygon(np.array([[x2,y2],[x1, y1],[xf1,yf1],[xf2,yf2]]), color = 'r', alpha=0.3)
        ax.add_patch(p)

    # y = np.array([[1,1], [2,1], [2,2], [1,2], [0.5,1.5]])
    # p = Polygon(y, facecolor = 'b',alpha=0.3)
    # fig,ax = plt.subplots()
    
    plt.savefig('E:/My file/Code/C#/FEM/FEM/bin/Debug/'+'internal.png')

    return os.path.abspath('E:/My file/Code/C#/FEM/FEM/bin/Debug/internal.png')