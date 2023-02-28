Public Class CuteCat
    Implements ICuteCat

    Public Property _id As String Implements ICuteCat._id
    Public Property tags As String() Implements ICuteCat.tags
    Public Property owner As String Implements ICuteCat.owner
    Public Property createdAt As String Implements ICuteCat.createdAt
    Public Property updatedAt As String Implements ICuteCat.updatedAt
    Public Property imageUrl As String Implements ICuteCat.imageUrl
End Class