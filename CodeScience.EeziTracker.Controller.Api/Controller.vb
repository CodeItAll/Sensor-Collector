
Imports CodeScience.DataModel.Generic
Imports System.Configuration
Public Class Controller

    Private MOD_CODESCIENCE_DATA_MODEL As New MOD_CODESCIENCE_DATA_MODEL
    Private CODESCIENCE_DATA_MODEL As New AX_GENERIC_MODULE_CONTROLLER
    Sub New(ByVal inConnectionString As String)
        CODESCIENCE_DATA_MODEL = MOD_CODESCIENCE_DATA_MODEL.INITILISE_DATA_MODELS(inConnectionString)
    End Sub

    Public Sub InsertDeviceData(ByVal inDeviceKey As String, ByVal inDeviceDataValue As Decimal, ByVal inControllerKey As String, inTransactionTimestamp As DateTime)

        Try

   

        Dim DeviceData As New clsDEVICE_DATA(CODESCIENCE_DATA_MODEL)
        DeviceData = DeviceData.Insert()

        Dim DeviceDataDetails As New clsDEVICE_DATA_DETAILS(CODESCIENCE_DATA_MODEL)
        DeviceDataDetails.DEVICE_DATA_KEY = DeviceData.DEVICE_DATA_KEY
        DeviceDataDetails.DEVICE_KEY = inDeviceKey
        DeviceDataDetails.TEMPERATURE_VALUE_01 = inDeviceDataValue
        DeviceDataDetails.CREATED_DATE = Date.Now
        DeviceDataDetails.TRANSACTION_TIMESTAMP = inTransactionTimestamp
        DeviceDataDetails.TRANSACTION_KEY = System.Guid.NewGuid.ToString()
        DeviceDataDetails.CONTROLLER_KEY = inControllerKey
        DeviceDataDetails.CREATED_BY = 0
        DeviceDataDetails.STATUS_ID = 0
        DeviceDataDetails.Insert()

        Catch ex As Exception
           ' Throw(ex)
        End Try

    End Sub

End Class
