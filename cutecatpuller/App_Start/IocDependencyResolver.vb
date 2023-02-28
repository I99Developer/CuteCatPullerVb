Imports Microsoft.Ajax.Utilities
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Owin.Logging

Public Class IocDependencyResolver
    Public Shared Sub RegisterDependencies()
        Dim services As New ServiceCollection()
        services.AddSingleton(Of ICuteCatService, CuteCatService)()
        DependencyResolver.SetResolver(New DependencyResolverInstance(services.BuildServiceProvider()))
    End Sub
End Class

Public Class DependencyResolverInstance
    Implements IDependencyResolver
    Private ReadOnly _provider As IServiceProvider

    Public Sub New(provider As IServiceProvider)
        _provider = provider
    End Sub

    Public Function GetService(serviceType As Type) As Object Implements IDependencyResolver.GetService
        Return _provider.GetService(serviceType)
    End Function

    Public Function GetServices(serviceType As Type) As IEnumerable(Of Object) Implements IDependencyResolver.GetServices
        Return _provider.GetServices(serviceType)
    End Function
End Class
