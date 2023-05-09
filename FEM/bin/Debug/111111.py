from numpy import setdiff1d,linalg
from numpy import ix_,zeros,dot

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