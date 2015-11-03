Public Class DEVICE_DATA_DETAILS_MODEL

    Public Property SYSTEM_KEY() As String
        Get
            Return m_SYSTEM_KEY
        End Get
        Set(value As String)
            m_SYSTEM_KEY = Value
        End Set
    End Property
    Private m_SYSTEM_KEY As String


    Public Property TRANSACTION_KEY() As String
        Get
            Return m_TRANSACTION_KEY
        End Get
        Set(value As String)
            m_TRANSACTION_KEY = Value
        End Set
    End Property
    Private m_TRANSACTION_KEY As String

    Public Property TRANSACTION_TIMESTAMP() As DateTime
        Get
            Return m_TRANSACTION_TIMESTAMP
        End Get
        Set(value As DateTime)
            m_TRANSACTION_TIMESTAMP = Value
        End Set
    End Property
    Private m_TRANSACTION_TIMESTAMP As DateTime

    Public Property CREATED_DATE() As DateTime
        Get
            Return m_CREATED_DATE
        End Get
        Set(value As DateTime)
            m_CREATED_DATE = Value
        End Set
    End Property
    Private m_CREATED_DATE As DateTime

    Public Property DEVICE_KEY() As String
        Get
            Return m_DEVICE_KEY
        End Get
        Set(value As String)
            m_DEVICE_KEY = Value
        End Set
    End Property
    Private m_DEVICE_KEY As String

    Public Property CONTROLLER_KEY() As String
        Get
            Return m_CONTROLLER_KEY
        End Get
        Set(value As String)
            m_CONTROLLER_KEY = Value
        End Set
    End Property
    Private m_CONTROLLER_KEY As String

    Public Property DEACTIVATED_BY() As String
        Get
            Return m_DEACTIVATED_BY
        End Get
        Set(value As String)
            m_DEACTIVATED_BY = Value
        End Set
    End Property
    Private m_DEACTIVATED_BY As String

    Public Property RECORD_INDEX() As Integer
        Get
            Return m_RECORD_INDEX
        End Get
        Set(value As Integer)
            m_RECORD_INDEX = Value
        End Set
    End Property
    Private m_RECORD_INDEX As Integer

    Public Property STATUS_ID() As Integer
        Get
            Return m_STATUS_ID
        End Get
        Set(value As Integer)
            m_STATUS_ID = Value
        End Set
    End Property
    Private m_STATUS_ID As Integer

    Public Property CREATED_BY() As String
        Get
            Return m_CREATED_BY
        End Get
        Set(value As String)
            m_CREATED_BY = Value
        End Set
    End Property
    Private m_CREATED_BY As String

    Public Property DEACTIVATED_DATE() As DateTime
        Get
            Return m_DEACTIVATED_DATE
        End Get
        Set(value As DateTime)
            m_DEACTIVATED_DATE = Value
        End Set
    End Property
    Private m_DEACTIVATED_DATE As DateTime

    Public Property DEVICE_DATA_KEY() As String
        Get
            Return m_DEVICE_DATA_KEY
        End Get
        Set(value As String)
            m_DEVICE_DATA_KEY = Value
        End Set
    End Property
    Private m_DEVICE_DATA_KEY As String

    Public Property DEVICE_DATA_DETAILS_KEY() As String
        Get
            Return m_DEVICE_DATA_DETAILS_KEY
        End Get
        Set(value As String)
            m_DEVICE_DATA_DETAILS_KEY = Value
        End Set
    End Property
    Private m_DEVICE_DATA_DETAILS_KEY As String

    Public Property IS_ACTIVE_RECORD() As Boolean
        Get
            Return m_IS_ACTIVE_RECORD
        End Get
        Set(value As Boolean)
            m_IS_ACTIVE_RECORD = Value
        End Set
    End Property
    Private m_IS_ACTIVE_RECORD As Boolean

    Public Property TEMPERATURE_VALUE_01() As Decimal
        Get
            Return m_TEMPERATURE_VALUE_01
        End Get
        Set(value As Decimal)
            m_TEMPERATURE_VALUE_01 = Value
        End Set
    End Property
    Private m_TEMPERATURE_VALUE_01 As Decimal

End Class

