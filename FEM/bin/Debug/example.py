def displacements(GDof,prescribedDof,stiffness,force) :
    import numpy as np
    GDof=int(GDof)

    force_1 = force
    force= np.zeros((GDof,1),dtype=float)
    for i in range(GDof):
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

    GDofMatrix=[]
    for i in range (0,GDof) :
        GDofMatrix.append([i])

    activeDof=np.setdiff1d(GDofMatrix,prescribedDof-1)+1
    
    idx1=np.ix_(activeDof-1,activeDof-1)
    stiffness=np.asmatrix(stiffness[idx1])
    

    U=np.matmul(np.linalg.inv(stiffness),force[activeDof-1])
    displacement=np.zeros((GDof,1))
    displacement[activeDof-1]=U
    return displacement