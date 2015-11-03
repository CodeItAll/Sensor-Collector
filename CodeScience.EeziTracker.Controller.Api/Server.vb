Imports System.Linq.Expressions
Imports CodeScience.DataModel.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports Newtonsoft
Public Class Server

    Private MOD_CODESCIENCE_DATA_MODEL As New MOD_CODESCIENCE_DATA_MODEL
    Private CODESCIENCE_DATA_MODEL As New AX_GENERIC_MODULE_CONTROLLER

    Sub New(ByVal inConnectionString As String)
        CODESCIENCE_DATA_MODEL = MOD_CODESCIENCE_DATA_MODEL.INITILISE_DATA_MODELS(inConnectionString)
    End Sub


    Public Async Sub SendToServer(ByVal inServiceBaseAddress As String)

        Try

            Dim UnSentItems As List(Of clsDEVICE_DATA_DETAILS) = CODESCIENCE_DATA_MODEL.DEVICE_DATA_DETAILS.LOAD_LIST_BY_STATUS_ID(0)

            For Each Item In UnSentItems

                ' Dim authenticationBytes = Encoding.ASCII.GetBytes("34AED150-2B39-4FD3-BE80-4B7E84ED12D4")
                Using confClient As New HttpClient()
                    confClient.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Basic", "34AED150-2B39-4FD3-BE80-4B7E84ED12D4")
                    confClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

                    Dim DEVICE_DATA_DETAILS_MODEL As DEVICE_DATA_DETAILS_MODEL = Item.SerialiseTo(New DEVICE_DATA_DETAILS_MODEL)

                    Dim message As HttpResponseMessage = Await confClient.PostAsJsonAsync(inServiceBaseAddress & "csapi/Device_data/receive", DEVICE_DATA_DETAILS_MODEL)

                    If message.IsSuccessStatusCode Then
                        Dim result = message.Content.ReadAsStringAsync()
                        Dim returnedKey As String = result.Result.ToString()
                        If returnedKey.ToUpper.Contains(Item.TRANSACTION_KEY.ToUpper()) Then
                            Item.STATUS_ID = 1
                            Item.Update()
                        End If
                    End If

                End Using

            Next

        Catch ex As Exception
            'Throw(ex)
        End Try

    End Sub


End Class
