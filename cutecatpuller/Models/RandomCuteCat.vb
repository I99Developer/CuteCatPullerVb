Public Class RandomCuteCat
    Implements IRandomCuteCat

    Public Property tags As String() Implements IRandomCuteCat.tags
    Public Property createdAt As DateTime Implements IRandomCuteCat.createdAt
    Public Property updatedAt As DateTime Implements IRandomCuteCat.updatedAt
    Public Property validated As Boolean Implements IRandomCuteCat.validated
    Public Property owner As Object Implements IRandomCuteCat.owner
    Public Property file As String Implements IRandomCuteCat.file
    Public Property mimetype As String Implements IRandomCuteCat.mimetype
    Public Property size As Integer Implements IRandomCuteCat.size
    Public Property _id As String Implements IRandomCuteCat._id
    Public Property url As String Implements IRandomCuteCat.url
End Class