Imports System.Configuration
Module Module1

    Sub Main()

        Console.WriteLine("Select Option:")
        Console.WriteLine("1) Test Create Device Data Record")
        Console.WriteLine("2) Test Send to Server")

        Dim ConsoleKeyInfo As ConsoleKeyInfo = Console.ReadKey

        If ConsoleKeyInfo.Key = ConsoleKey.D1 Then
            Console.WriteLine("Test Create Device Data Record Started")
            Dim EeziTrackerApi As Api.Controller = New Api.Controller("ConnectionString")
            EeziTrackerApi.InsertDeviceData(ConfigurationManager.AppSettings("TestDeviceKey"), 12.23, ConfigurationManager.AppSettings("ConrollerKey"), DateTime.Now)
            Console.WriteLine("Completed")
        End If

        If ConsoleKeyInfo.Key = ConsoleKey.D2 Then
            Console.WriteLine("Test Send to Server Started")
            Dim EeziTrackerApi As Api.Server = New Api.Server("ConnectionString")
            Dim ServiceBaseAddress As String = ConfigurationManager.AppSettings("ServiceBaseAddress")
            EeziTrackerApi.SendToServer(ServiceBaseAddress)
            Console.WriteLine("Completed")
        End If

        Console.ReadKey()

    End Sub


End Module
