
Imports System.Xml
Imports CodeScience.DataModel.Generic
Imports System.Configuration

Public Class MOD_CODESCIENCE_DATA_MODEL

    Public Function INITILISE_DATA_MODELS(Optional connectionKey As String = "") As AX_GENERIC_MODULE_CONTROLLER

        Dim CODESCIENCE_DATA_MODEL As AX_GENERIC_MODULE_CONTROLLER

        If connectionKey = "" Then
            Console.WriteLine("Error: Connection String NULL")
            CODESCIENCE_DATA_MODEL = New AX_GENERIC_MODULE_CONTROLLER(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        Else
            CODESCIENCE_DATA_MODEL = New AX_GENERIC_MODULE_CONTROLLER(ConfigurationManager.ConnectionStrings(connectionKey).ConnectionString)
            Console.WriteLine("Initilising Local Database Connection String")
            Console.WriteLine(ConfigurationManager.ConnectionStrings(connectionKey).ConnectionString)
        End If

        If connectionKey = "EvolveConnectionString" Then
            CODESCIENCE_DATA_MODEL.SYSTEM_KEY = "1"
        Else
            CODESCIENCE_DATA_MODEL.SYSTEM_KEY = " "
        End If

        Return CODESCIENCE_DATA_MODEL

    End Function

End Class

