from numpy import matrix
from numpy import ix_
from numpy import zeros,float64,int32,array,sum,matrix
from math import sqrt

def formStiffness2Dtruss(GDof,numberElements,elementNodes,xx,yy,E,A) :
	GDof = int(GDof)
	numberElements = int(numberElements)
	stiffness=zeros((GDof,GDof),dtype=float)
	elementNodes_1 = elementNodes
	n_rows = elementNodes_1.GetLength(0)
	n_cols = elementNodes_1.GetLength(1)
	elementNodes= zeros((n_rows,n_cols),dtype=int)
	for i in range(n_rows):
		for j in range(n_cols):
			elementNodes[i, j] = elementNodes_1[i, j]
	xx_1 = xx
	yy_1 = yy
	n_rows_1 = xx_1.GetLength(0)
	xx=zeros((n_rows_1,1),dtype=float)
	yy=zeros((n_rows_1,1),dtype=float)
	for i in range(n_rows_1):
		xx[i]=xx_1[i]
		yy[i]=yy_1[i]

	elementNodes = matrix(elementNodes)
	for i in range(0,numberElements) :
		indice=elementNodes[i]
		elementDof=[indice[0,0]*2-2, indice[0,0]*2-1, indice[0,1]*2-2, indice[0,1]*2-1]
		xa=xx[indice[0,1]-1]-xx[indice[0,0]-1]
		ya=yy[indice[0,1]-1]-yy[indice[0,0]-1]
		length_element=sqrt(xa*xa+ya*ya)
		c=xa/length_element
		s=ya/length_element
		k1 = E*A/length_element * array([[c*c,c*s,-c*c,-c*s],[c*s,s*s,-c*s,-s*s],[-c*c,-c*s,c*c,c*s],[-c*s,-s*s,c*s,s*s]])
		k1 = matrix(k1)
		idx=ix_(elementDof,elementDof)
		stiffness[idx]=stiffness[idx]+k1
		
	return stiffness

def displacements(GDof,prescribedDof,stiffness,force) :
    GDof=int(GDof)

    force_1 = force
    n_rows = force_1.GetLength(0)
    force= zeros((n_rows,1),dtype=float)
    for i in range(n_rows):
        force[i] = force_1[i]

    stiffness_1=stiffness
    stiffness=zeros((GDof,GDof),dtype=float)
    for i in range(GDof):
        for j in range(GDof):
            stiffness[i,j]=stiffness_1[i,j]

    prescribedDof_1=prescribedDof
    n_rows_1 = prescribedDof_1.GetLength(0)
    prescribedDof=zeros((n_rows_1,1),dtype=int):
    for i in range(n_rows_1):
        prescribedDof[i]=prescribedDof_1[i]

    GDofMatrix=[]
    for i in range (0,GDof) :
        GDofMatrix.append([i])

    activeDof=setdiff1d(GDofMatrix,prescribedDof-1)+1
    
    idx1=ix_(activeDof-1,activeDof-1)
    U=dot(linalg.inv(stiffness[idx1]),force[activeDof-1])
    displacement=zeros((GDof,1))
    displacement[activeDof-1]=U
    
    return displacement