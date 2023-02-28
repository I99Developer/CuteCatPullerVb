Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Microsoft.Owin.Logging
Imports Microsoft.Ajax.Utilities
Imports System.Net.Http.Headers

Public Class CuteCatService
    Implements ICuteCatService
    Public Sub New()

    End Sub

    Public Function GetCatImageUrl(ByVal retry As Integer) As String
        Try
            'Simple rest call to pull a random cat image from cataas
            Dim url As String = "https://cataas.com/cat?json=true"
            Dim baseImageUrl As String = "https://cataas.com"
            Dim req As HttpWebRequest = HttpWebRequest.Create(url)
            Dim imageUrl As String = ""
            req.Method = "GET"
            req.ContentType = "application/json"
            req.Accept = "application/json"
            Dim resp As HttpWebResponse = req.GetResponse()
            Using sReader As New StreamReader(resp.GetResponseStream)
                Dim jsonCats As String = sReader.ReadToEnd
                Dim randomCat As RandomCuteCat = JsonConvert.DeserializeObject(Of RandomCuteCat)(jsonCats)
                imageUrl = String.Format("{0}{1}", baseImageUrl, randomCat.url)
                Return imageUrl
            End Using
        Catch ex As Exception
            'the function is durable, this should not occur, but if it does
            'log the error and throw the exception up the stack for UI messaging
            'todo setup owin           
            '_logger.WriteError("Function Failed", ex)
            'api is a bit unreliable
            retry = retry + 1

            If retry >= 3 Then
                Return "https://wallpapercave.com/wp/wp2697128.jpg"
            End If

            Return GetCatImageUrl(retry)
        End Try

    End Function

    Public Function GetCuteCats() As List(Of CuteCat) Implements ICuteCatService.GetCuteCats
        Try
            'Simple rest call to pull cute cats from cataas
            Dim url As String = "https://cataas.com/api/cats?tags=cute"
            Dim req As HttpWebRequest = HttpWebRequest.Create(url)
            req.Method = "GET"
            req.ContentType = "application/json"
            req.Accept = "application/json"
            Dim resp As HttpWebResponse = req.GetResponse()
            Using sReader As New StreamReader(resp.GetResponseStream)
                Dim jsonCats As String = sReader.ReadToEnd
                Dim cuteCats As List(Of CuteCat) = JsonConvert.DeserializeObject(Of List(Of CuteCat))(jsonCats)
                For Each cuteCat As CuteCat In cuteCats
                    If String.IsNullOrEmpty(cuteCat.owner) Or cuteCat.owner.ToLower() = "null" Then
                        cuteCat.owner = "Available For Adoption"
                    End If
                    cuteCat.imageUrl = GetCatImageUrl(retry:=0)
                Next
                Return cuteCats
            End Using
        Catch ex As Exception
            'the function is durable, this should not occur, but if it does
            'log the error and throw the exception up the stack for UI messaging
            'todo setup owin           
            '_logger.WriteError("Function Failed", ex)
            Throw ex
        End Try

    End Function
End Class
