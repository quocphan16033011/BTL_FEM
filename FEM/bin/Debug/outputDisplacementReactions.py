# Hàm xuất ra kết quả chuyển vị và phản lực liên kết của thanh thẳng chịu kéo nén đúng tâm

def outputDisplacementReactions(displacements,stiffness,GDof,prescribedDof,force) :
	import numpy as np
	GDof=int(GDof)

	force_1 = force
	n_rows = force_1.GetLength(0)
	force= np.zeros((n_rows,1),dtype=float)
	for i in range(n_rows):
		force[i] = force_1[i]
	
	stiffness_1=stiffness
	stiffness=np.zeros((GDof,GDof),dtype=float)
	for i in range(GDof):
		for j in range(GDof):
			stiffness[i,j]=stiffness_1[i,j]

	prescribedDof_1=prescribedDof
	n_rows_1 = prescribedDof_1.GetLength(0)
	prescribedDof=np.zeros((n_rows_1,1),dtype=int)
	for i in range(n_rows_1):
		prescribedDof[i]=prescribedDof_1[i]

	displacements_1=displacements
	displacements=np.zeros((GDof,1),dtype=float)
	for i in range(GDof):
		displacements[i]=displacements_1[i]

	force_1=np.matmul(stiffness,displacements)
	reaction=force_1[prescribedDof-1]-force[prescribedDof-1]
	reaction=reaction.reshape((n_rows_1,1))
	return reaction