Imports Owin
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Owin.Logging

Partial Public Class Startup
    Public Sub Configuration(app As IAppBuilder)
        ConfigureAuth(app)
    End Sub
End Class
