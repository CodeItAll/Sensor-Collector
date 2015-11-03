Imports System.Threading
Imports System.Net.Sockets
Imports System.Text
Imports System.Xml

Public Class Sender

    Private UserName As String
    Private Password As String
    Private IP As String
    Private Port As String
    Public Sub New(ByVal in_Username As String, ByVal in_Password As String, ByVal in_IP As String, ByVal in_Port As String)
        UserName = in_Username
        Password = in_Password
        IP = in_IP
        Port = in_Port
    End Sub

    Public Function SendCommand(ByVal in_A_Party As String, ByVal in_B_Party As String, ByVal in_Value As String, ByVal in_Function As String, ByVal server As TcpClient) As Response

        Dim stringData As String
        Dim Response As New Response()

        Dim command As String = "<ppfe-request><username>" & UserName & "</username><password>" & Password & "</password></ppfe-request>"

        Dim input As String = ""





        Dim myReadBuffer1(1024) As Byte
        Dim numberOfBytesRead As Integer = 0

        server.NoDelay = True
        Dim ns As NetworkStream = server.GetStream()



        input = "POST /ppfe/login HTTP/1.1" & vbCr & vbLf
        input += "Host: 127.0.0.1" & vbCr & vbLf
        input += "Connection: keep-alive" & vbCr & vbLf
        input += "Content-Type: text/xml" & vbCr & vbLf
        input += "Content-Length: 92" & vbCr & vbLf
        input += "" & vbCr & vbLf
        input += "<ppfe-request><username>" & Me.UserName & "</username><password>" & Me.Password & "</password></ppfe-request>" & vbCr & vbLf

        Dim data As Byte() = Encoding.ASCII.GetBytes(input)
        ' data = Encoding.ASCII.GetBytes(input)
        '   While ns.DataAvailable <> True
        'Thread.Sleep(50)

        ns.Write(data, 0, data.Length)
        '  End While

        ' Incoming message may be larger than the buffer size. 
        If ns.CanRead Then
            Do
                numberOfBytesRead = ns.Read(data, 0, data.Length)
                stringData &= Encoding.ASCII.GetString(data, 0, numberOfBytesRead)
            Loop While ns.DataAvailable
        End If

        Dim posInStream As Integer = stringData.Length()
        stringData = ""
        Dim myReadBuffer2(1024) As Byte
        numberOfBytesRead = 0
        ns.Flush()


        '   PauseForMilliSeconds(10000)
        ns.Flush()
        server.GetStream().Flush()

        ns = server.GetStream()

        command = "<ppfe-request><msisdn>" & in_A_Party & "</msisdn><b-party>" & in_B_Party & "</b-party><value>" & in_Value & "</value></ppfe-request>"
        input = "POST /ppfe/vodafasta/direct-wallet-transfer HTTP/1.1" & vbCr & vbLf
        input += "Host: 127.0.0.1" & vbCr & vbLf
        input += "Connection: keep-alive" & vbCr & vbLf
        input += "Content-Type: text/xml" & vbCr & vbLf
        input += "Content-Length: " & command.Length & vbCr & vbLf
        input += vbCr & vbLf
        input += command & vbCr & vbLf

        data = Encoding.ASCII.GetBytes(input)
        ' data = Encoding.ASCII.GetBytes(input)

        PauseForMilliSeconds(200)
        '    server.GetStream().Flush()
        'While ns.DataAvailable <> False
        '    PauseForMilliSeconds(4000)
        '    server.GetStream().Flush()
        '    ns = server.GetStream()

        'End While
        '   server.GetStream().Flush()

        '  ns = server.GetStream()

        '     While ns.DataAvailable <> True
        ' PauseForMilliSeconds(2000)
        '    server.GetStream().Flush()

        ns.Write(data, 0, data.Length)
        '  ns.EndWrite(System.IAsyncResult.)
        PauseForMilliSeconds(800)
        '    server.GetStream().Flush()
        '  ns.Write(data, 0, data.Length)
        '  End While

        ' Incoming message may be larger than the buffer size. 
        If ns.CanRead Then
            Do
                numberOfBytesRead = ns.Read(data, 0, data.Length)
                stringData &= Encoding.ASCII.GetString(data, 0, numberOfBytesRead)
            Loop While ns.DataAvailable
        End If


        'ns.Close()
        'server.Close()

        Dim result As String

        '  Response.Message = stringData
        '  Return Response
        result = stringData.Substring(stringData.IndexOf(vbLf) + 1, stringData.Length - stringData.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)

        Dim xmldoc As New System.Xml.XmlDocument
        xmldoc.LoadXml(result)

        Select Case True

            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("200")

                Dim child_nodes As XmlNodeList = xmldoc.GetElementsByTagName("ppfe-response")

                For Each child As XmlNode In child_nodes.Item(0).ChildNodes
                    If child.Name = "status" Then
                        Response.Status = child.InnerText
                    End If
                    If child.Name = "message" Then
                        Response.Message = child.InnerText
                    End If
                Next child

                Return Response

            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("400")
                Return UndesirableRequest(result, "400")
            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("401")
                Return UndesirableRequest(result, "401")
            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("500")
                Return UndesirableRequest(result, "500")
            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("501")
                Return UndesirableRequest(result, "501")

            Case Else
                Return Response
        End Select
    End Function

    Public Function Login() As Response

        Dim stringData As String
        Dim Response As New Response()

        Dim command As String = "<ppfe-request><username>" & Me.UserName & "</username><password>" & Me.Password & "</password></ppfe-request>"

        Dim input As String = ""
        input += "POST /ppfe/login HTTP/1.1" & vbCr & vbLf
        input += "Host: 127.0.0.1 " & vbCr & vbLf
        input += "Connection: keep-alive " & vbCr & vbLf
        input += "Content-Type: text/xml " & vbCr & vbLf
        input += "Content-Length: " & command.Length & " " & vbCr & vbLf
        input += vbCr & vbLf
        input += command & vbCr & vbLf
        '  input += "                                                                          "

        Dim data As Byte() = Encoding.ASCII.GetBytes(input)

        Dim server As TcpClient


        Try

            server = New TcpClient()

            server.Connect(IP, Port)

        Catch generatedExceptionName As SocketException
            Response.Status = -1
            Response.Message = generatedExceptionName.Message.ToString
            Return Response
        End Try


        Dim myReadBuffer1(1024) As Byte
        Dim numberOfBytesRead As Integer = 0

        server.NoDelay = True
        server.Client.NoDelay = True
        Dim ns As NetworkStream = server.GetStream()

        ns.Write(data, 0, data.Length)

        ns.WriteTimeout = 50
        ns.ReadTimeout = 50

        While ns.DataAvailable <> True
            Thread.Sleep(50)
            'keeping sending fucking command til it fucking replies !!!!!!!!!!!!!!!!!!!!!!!
            ns.Write(data, 0, data.Length)
        End While
        ' Incoming message may be larger than the buffer size. 
        If ns.CanRead Then
            Do
                numberOfBytesRead = ns.Read(data, 0, data.Length)
                stringData &= Encoding.ASCII.GetString(data, 0, numberOfBytesRead)
            Loop While ns.DataAvailable
        End If
        ns.Close()
        server.Close()

        Dim result As String


        result = stringData.Substring(stringData.IndexOf(vbLf) + 1, stringData.Length - stringData.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)
        result = result.Substring(result.IndexOf(vbLf) + 1, result.Length - result.IndexOf(vbLf) - 1)

        Dim xmldoc As New System.Xml.XmlDocument
        xmldoc.LoadXml(result)

        Select Case True

            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("200")

                Dim child_nodes As XmlNodeList = xmldoc.GetElementsByTagName("ppfe-response")

                For Each child As XmlNode In child_nodes.Item(0).ChildNodes
                    If child.Name = "status" Then
                        Response.Status = child.InnerText
                    End If
                    If child.Name = "message" Then
                        Response.Message = child.InnerText
                    End If
                Next child

                Return Response

            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("400")
                Return UndesirableRequest(result, "400")
            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("401")
                Return UndesirableRequest(result, "401")
            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("500")
                Return UndesirableRequest(result, "500")
            Case stringData.Substring(0, stringData.IndexOf(vbLf)).Contains("501")
                Return UndesirableRequest(result, "501")

            Case Else
                Return Response
        End Select






    End Function

    Public Shared Function PauseForMilliSeconds(ByVal MilliSecondsToPauseFor As Integer) As DateTime
        Dim ThisMoment As System.DateTime = System.DateTime.Now
        Dim duration As New System.TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor)
        Dim AfterWards As System.DateTime = ThisMoment.Add(duration)

        While AfterWards >= ThisMoment
            '  System.Windows.Forms.Application.DoEvents()
            ThisMoment = System.DateTime.Now
        End While

        Return System.DateTime.Now
    End Function
    Public Function UndesirableRequest(ByVal in_Result As String, ByVal in_Status As String) As Response
        Dim Response As New Response

        Dim xmldoc As New System.Xml.XmlDocument
        xmldoc.LoadXml(in_Result)

        '  Dim child_nodes As XmlNodeList = xmldoc.GetElementsByTagName("body bgcolor=#505050")
        Dim child_nodes As XmlNodeList = xmldoc.GetElementsByTagName("html")
        Response.Status = in_Status
        Response.Message = child_nodes.Item(0).LastChild.InnerText


        Return Response
    End Function

    Public Class Response

        Private _Status As String
        Public Property Status() As String
            Get
                Return _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property

        Private _Message As String
        Public Property Message() As String
            Get
                Return _Message
            End Get
            Set(ByVal value As String)
                _Message = value
            End Set
        End Property

    End Class


End Class