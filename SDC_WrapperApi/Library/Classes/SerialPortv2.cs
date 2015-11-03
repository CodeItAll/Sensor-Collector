/*
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Xml;

public class Sender
{

    private string UserName;
    private string Password;
    private string IP;
    private string Port;
    public Sender(string in_Username, string in_Password, string in_IP, string in_Port)
    {
        UserName = in_Username;
        Password = in_Password;
        IP = in_IP;
        Port = in_Port;
    }

    public Response SendCommand(string in_A_Party, string in_B_Party, string in_Value, string in_Function, TcpClient server)
    {

        string stringData = null;
        Response Response = new Response();

        string command = "<ppfe-request><username>" + UserName + "</username><password>" + Password + "</password></ppfe-request>";

        string input = "";





        byte[] myReadBuffer1 = new byte[1025];
        int numberOfBytesRead = 0;

        server.NoDelay = true;
        NetworkStream ns = server.GetStream();



        input = "POST /ppfe/login HTTP/1.1" + Constants.vbCr + Constants.vbLf;
        input += "Host: 127.0.0.1" + Constants.vbCr + Constants.vbLf;
        input += "Connection: keep-alive" + Constants.vbCr + Constants.vbLf;
        input += "Content-Type: text/xml" + Constants.vbCr + Constants.vbLf;
        input += "Content-Length: 92" + Constants.vbCr + Constants.vbLf;
        input += "" + Constants.vbCr + Constants.vbLf;
        input += "<ppfe-request><username>" + this.UserName + "</username><password>" + this.Password + "</password></ppfe-request>" + Constants.vbCr + Constants.vbLf;

        byte[] data = Encoding.ASCII.GetBytes(input);
        // data = Encoding.ASCII.GetBytes(input)
        //   While ns.DataAvailable <> True
        //Thread.Sleep(50)

        ns.Write(data, 0, data.Length);
        //  End While

        // Incoming message may be larger than the buffer size. 
        if (ns.CanRead)
        {
            do
            {
                numberOfBytesRead = ns.Read(data, 0, data.Length);
                stringData += Encoding.ASCII.GetString(data, 0, numberOfBytesRead);
            } while (ns.DataAvailable);
        }

        int posInStream = stringData.Length();
        stringData = "";
        byte[] myReadBuffer2 = new byte[1025];
        numberOfBytesRead = 0;
        ns.Flush();


        //   PauseForMilliSeconds(10000)
        ns.Flush();
        server.GetStream().Flush();

        ns = server.GetStream();

        command = "<ppfe-request><msisdn>" + in_A_Party + "</msisdn><b-party>" + in_B_Party + "</b-party><value>" + in_Value + "</value></ppfe-request>";
        input = "POST /ppfe/vodafasta/direct-wallet-transfer HTTP/1.1" + Constants.vbCr + Constants.vbLf;
        input += "Host: 127.0.0.1" + Constants.vbCr + Constants.vbLf;
        input += "Connection: keep-alive" + Constants.vbCr + Constants.vbLf;
        input += "Content-Type: text/xml" + Constants.vbCr + Constants.vbLf;
        input += "Content-Length: " + command.Length + Constants.vbCr + Constants.vbLf;
        input += Constants.vbCr + Constants.vbLf;
        input += command + Constants.vbCr + Constants.vbLf;

        data = Encoding.ASCII.GetBytes(input);
        // data = Encoding.ASCII.GetBytes(input)

        PauseForMilliSeconds(200);
        //    server.GetStream().Flush()
        //While ns.DataAvailable <> False
        //    PauseForMilliSeconds(4000)
        //    server.GetStream().Flush()
        //    ns = server.GetStream()

        //End While
        //   server.GetStream().Flush()

        //  ns = server.GetStream()

        //     While ns.DataAvailable <> True
        // PauseForMilliSeconds(2000)
        //    server.GetStream().Flush()

        ns.Write(data, 0, data.Length);
        //  ns.EndWrite(System.IAsyncResult.)
        PauseForMilliSeconds(800);
        //    server.GetStream().Flush()
        //  ns.Write(data, 0, data.Length)
        //  End While

        // Incoming message may be larger than the buffer size. 
        if (ns.CanRead)
        {
            do
            {
                numberOfBytesRead = ns.Read(data, 0, data.Length);
                stringData += Encoding.ASCII.GetString(data, 0, numberOfBytesRead);
            } while (ns.DataAvailable);
        }


        //ns.Close()
        //server.Close()

        string result = null;

        //  Response.Message = stringData
        //  Return Response
        result = stringData.Substring(stringData.IndexOf(Constants.vbLf) + 1, stringData.Length - stringData.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);

        System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
        xmldoc.LoadXml(result);

        switch (true)
        {

            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("200"):

                XmlNodeList child_nodes = xmldoc.GetElementsByTagName("ppfe-response");

                foreach (XmlNode child in child_nodes.Item(0).ChildNodes)
                {
                    if (child.Name == "status")
                    {
                        Response.Status = child.InnerText;
                    }
                    if (child.Name == "message")
                    {
                        Response.Message = child.InnerText;
                    }
                }



                return Response;
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("400"):
                return UndesirableRequest(result, "400");
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("401"):
                return UndesirableRequest(result, "401");
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("500"):
                return UndesirableRequest(result, "500");
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("501"):

                return UndesirableRequest(result, "501");
            default:
                return Response;
        }
    }

    public Response Login()
    {

        string stringData = null;
        Response Response = new Response();

        string command = "<ppfe-request><username>" + this.UserName + "</username><password>" + this.Password + "</password></ppfe-request>";

        string input = "";
        input += "POST /ppfe/login HTTP/1.1" + Constants.vbCr + Constants.vbLf;
        input += "Host: 127.0.0.1 " + Constants.vbCr + Constants.vbLf;
        input += "Connection: keep-alive " + Constants.vbCr + Constants.vbLf;
        input += "Content-Type: text/xml " + Constants.vbCr + Constants.vbLf;
        input += "Content-Length: " + command.Length + " " + Constants.vbCr + Constants.vbLf;
        input += Constants.vbCr + Constants.vbLf;
        input += command + Constants.vbCr + Constants.vbLf;
        //  input += "                                                                          "

        byte[] data = Encoding.ASCII.GetBytes(input);

        TcpClient server = default(TcpClient);



        try
        {
            server = new TcpClient();

            server.Connect(IP, Port);

        }
        catch (SocketException generatedExceptionName)
        {
            Response.Status = -1;
            Response.Message = generatedExceptionName.Message.ToString;
            return Response;
        }


        byte[] myReadBuffer1 = new byte[1025];
        int numberOfBytesRead = 0;

        server.NoDelay = true;
        server.Client.NoDelay = true;
        NetworkStream ns = server.GetStream();

        ns.Write(data, 0, data.Length);

        ns.WriteTimeout = 50;
        ns.ReadTimeout = 50;

        while (ns.DataAvailable != true)
        {
            Thread.Sleep(50);
            //keeping sending fucking command til it fucking replies !!!!!!!!!!!!!!!!!!!!!!!
            ns.Write(data, 0, data.Length);
        }
        // Incoming message may be larger than the buffer size. 
        if (ns.CanRead)
        {
            do
            {
                numberOfBytesRead = ns.Read(data, 0, data.Length);
                stringData += Encoding.ASCII.GetString(data, 0, numberOfBytesRead);
            } while (ns.DataAvailable);
        }
        ns.Close();
        server.Close();

        string result = null;


        result = stringData.Substring(stringData.IndexOf(Constants.vbLf) + 1, stringData.Length - stringData.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);
        result = result.Substring(result.IndexOf(Constants.vbLf) + 1, result.Length - result.IndexOf(Constants.vbLf) - 1);

        System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
        xmldoc.LoadXml(result);

        switch (true)
        {

            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("200"):

                XmlNodeList child_nodes = xmldoc.GetElementsByTagName("ppfe-response");

                foreach (XmlNode child in child_nodes.Item(0).ChildNodes)
                {
                    if (child.Name == "status")
                    {
                        Response.Status = child.InnerText;
                    }
                    if (child.Name == "message")
                    {
                        Response.Message = child.InnerText;
                    }
                }



                return Response;
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("400"):
                return UndesirableRequest(result, "400");
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("401"):
                return UndesirableRequest(result, "401");
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("500"):
                return UndesirableRequest(result, "500");
            case stringData.Substring(0, stringData.IndexOf(Constants.vbLf)).Contains("501"):

                return UndesirableRequest(result, "501");
            default:
                return Response;
        }






    }

    public static DateTime PauseForMilliSeconds(int MilliSecondsToPauseFor)
    {
        System.DateTime ThisMoment = System.DateTime.Now;
        System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, MilliSecondsToPauseFor);
        System.DateTime AfterWards = ThisMoment.Add(duration);

        while (AfterWards >= ThisMoment)
        {
            //  System.Windows.Forms.Application.DoEvents()
            ThisMoment = System.DateTime.Now;
        }

        return System.DateTime.Now;
    }
    public Response UndesirableRequest(string in_Result, string in_Status)
    {
        Response Response = new Response();

        System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
        xmldoc.LoadXml(in_Result);

        //  Dim child_nodes As XmlNodeList = xmldoc.GetElementsByTagName("body bgcolor=#505050")
        XmlNodeList child_nodes = xmldoc.GetElementsByTagName("html");
        Response.Status = in_Status;
        Response.Message = child_nodes.Item(0).LastChild.InnerText;


        return Response;
    }

    public class Response
    {

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

    }


}
*/