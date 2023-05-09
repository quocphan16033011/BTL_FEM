def formStiffness2Dframe(GDof,numberElements,elementNodes,numberNodes,xx,yy,E,A,I):
	import numpy as np
	import math as m	
	
	GDof=int(GDof)
	numberElements=int(numberElements)
	numberNodes=int(numberNodes)
	E=float(E)
	A=float(A)
	I=float(I)
	EA=E*A
	EI=E*I

	elementNodes_1 = elementNodes
	n_rows = elementNodes_1.GetLength(0)
	n_cols = elementNodes_1.GetLength(1)
	elementNodes= np.zeros((n_rows,n_cols),dtype=int)
	for i in range(n_rows):
		for j in range(n_cols):
			elementNodes[i, j] = elementNodes_1[i, j]
	xx_1 = xx
	yy_1 = yy
	n_rows_1 = xx_1.GetLength(0)
	xx=np.zeros((n_rows_1,1),dtype=float)
	yy=np.zeros((n_rows_1,1),dtype=float)
	for i in range(n_rows_1):
		xx[i]=xx_1[i]
		yy[i]=yy_1[i]

	elementNodes = np.matrix(elementNodes)

	stiffness=np.zeros((GDof,GDof))
	for i in range(0,numberElements):
		indice=elementNodes[i]
		elementDof=[indice[0,0]-1,indice[0,1]-1,indice[0,0]+numberNodes-1,indice[0,1]+numberNodes-1,indice[0,0]+2*numberNodes-1,indice[0,1]+2*numberNodes-1]
		nn=len(indice)
		xa=xx[indice[0,1]-1]-xx[indice[0,0]-1]
		ya=yy[indice[0,1]-1]-yy[indice[0,0]-1]
		length_element=m.sqrt(xa**2+ya**2)
		cosa=xa/length_element
		sina=ya/length_element
		L=np.vstack((np.hstack((cosa*np.eye(2),sina*np.eye(2),np.zeros((2,2)))),np.hstack((-sina*np.eye(2),cosa*np.eye(2),np.zeros((2,2)))),np.hstack((np.zeros((2,4)),np.eye(2)))))
		oneu=np.matrix([[1,-1],[-1,1]])
		oneu2=np.matrix([[1,-1],[1,-1]])
		oneu3=np.matrix([[1,1],[-1,-1]])
		oneu4=np.matrix([[4,2],[2,4]])
		k1=np.vstack((np.hstack((EA/length_element*oneu,np.zeros((2,4)))),np.hstack((np.zeros((2,2)),12*EI/length_element**3*oneu,6*EI/length_element**2*oneu3)),np.hstack((np.zeros((2,2)),6*EI/length_element**2*oneu2,EI/length_element*oneu4))))
		idx=np.ix_(elementDof,elementDof)
		stiffness[idx]=stiffness[idx]+np.dot(np.dot(L.T,k1),L)

	return stiffness