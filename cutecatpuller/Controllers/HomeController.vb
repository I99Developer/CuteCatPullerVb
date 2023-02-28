Imports System.Threading.Tasks
Imports Microsoft.Ajax.Utilities

<Authorize>
Public Class HomeController
    Inherits Controller
    Private ReadOnly _cuteCatService As ICuteCatService

    Public Sub New()
        _cuteCatService = New CuteCatService()
    End Sub
    Public Function Index() As ActionResult
        Return View()
    End Function

    Public Async Function GetCuteCats() As Task(Of ActionResult)
        Dim cats = Await Task.Run((Function() _cuteCatService.GetCuteCats()))
        Return Json(cats, JsonRequestBehavior.AllowGet)
    End Function
End Class
