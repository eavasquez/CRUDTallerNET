Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class DocumentosCls
    Dim DocumentoId As Integer
    Dim DocumentoNumero As String
    Dim DocumentoTipo As String
    Dim DocumentoDescripcion As String
    Dim DocumentoMonto As String
    Dim DocumentoPagado As String
    Dim ConnectionString As String
    Dim sql As String
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable

    Public Property DocumentosId() As Integer
        Get
            Return DocumentoId
        End Get
        Set(ByVal value As Integer)
            DocumentoId = value
        End Set
    End Property

    Public Property DocumentosNumero() As String
        Get
            Return DocumentoNumero
        End Get
        Set(ByVal value As String)
            DocumentoNumero = value
        End Set
    End Property

    Public Property DocumentosTipo() As String
        Get
            Return DocumentoTipo
        End Get
        Set(ByVal value As String)
            DocumentoTipo = value
        End Set
    End Property

    Public Property DocumentosDescripcion() As String
        Get
            Return DocumentoDescripcion
        End Get
        Set(ByVal value As String)
            DocumentoDescripcion = value
        End Set
    End Property

    Public Property DocumentosMonto() As String
        Get
            Return DocumentoMonto
        End Get
        Set(ByVal value As String)
            DocumentoMonto = value
        End Set
    End Property

    Public Property DocumentosPagado() As String
        Get
            Return DocumentoPagado

        End Get
        Set(ByVal value As String)
            DocumentoPagado = value
        End Set
    End Property

    'DAL Functions
    Public Sub New()
        ConnectionString = ConfigurationManager.AppSettings("ConnectionString").ToString()
    End Sub

    Public Sub InsertCustomer(ByVal NumeroDocumento As String, ByVal TipoDocumento As String, ByVal DescripcionDocumento As String, ByVal MontoDocumento As String,
                              ByVal PagadoDocumento As String)

        sql = "INSERT INTO Documentos (Numero, Tipo, Descripcion, Monto, Pagado) " &
                            "VALUES (@CustomerName, @CustomerGender, @CustomerCity, @CustomerState, @CustomerType)"

        conn = New SqlConnection(ConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = NumeroDocumento
        cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 50).Value = TipoDocumento
        cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = DescripcionDocumento
        cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = MontoDocumento
        cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = PagadoDocumento
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub UpdateCustomer(ByVal NumeroDocumento As String, ByVal TipoDocumento As String, ByVal DescripcionDocumento As String, ByVal MontoDocumento As String,
                              ByVal PagadoDocumento As String)

        sql = "Update Documentos Set Tipo=@CustomerGender, Descripcion=@CustomerCity, " &
                            " Monto=@CustomerState, Pagado=@CustomerType Where Numero=@CustomerName"
        conn = New SqlConnection(ConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = NumeroDocumento
        cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 50).Value = TipoDocumento
        cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = DescripcionDocumento
        cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = MontoDocumento
        cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = PagadoDocumento
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub DeleteCustomer(ByVal CustomerCode As Integer)
        conn = New SqlConnection(ConnectionString)
        sql = "Delete From Documentos Where Id=@CustomerCode"
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = CustomerCode
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function Fetch() As DataTable

        sql = "Select * from Documentos Order by Id"
        Dim da As New SqlDataAdapter(sql, ConnectionString)
        dt = New DataTable

        Try
            da.Fill(dt)
        Catch ex As Exception

        End Try

        Return dt
    End Function
End Class
