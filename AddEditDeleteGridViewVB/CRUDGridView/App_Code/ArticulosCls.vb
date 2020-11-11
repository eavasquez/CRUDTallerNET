Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class ArticulosCls
    Dim ArticuloId As Integer
    Dim ArticuloCodigo As String
    Dim ArticuloTipo As String
    Dim ArticuloDescripcion As String
    Dim ArticuloPrecioVenta As String
    Dim ArticuloActivo As String
    Dim ConnectionString As String
    Dim sql As String
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable

    Public Property ArticulosId() As Integer
        Get
            Return ArticuloId
        End Get
        Set(ByVal value As Integer)
            ArticuloId = value
        End Set
    End Property

    Public Property ArticulosCodigo() As String
        Get
            Return ArticuloCodigo
        End Get
        Set(ByVal value As String)
            ArticuloCodigo = value
        End Set
    End Property

    Public Property ArticulosTipo() As String
        Get
            Return ArticuloCodigo
        End Get
        Set(ByVal value As String)
            ArticuloCodigo = value
        End Set
    End Property

    Public Property ArticulosDescripcion() As String
        Get
            Return ArticuloDescripcion
        End Get
        Set(ByVal value As String)
            ArticuloDescripcion = value
        End Set
    End Property

    Public Property ArticulosPrecioVenta() As String
        Get
            Return ArticuloPrecioVenta
        End Get
        Set(ByVal value As String)
            ArticuloPrecioVenta = value
        End Set
    End Property

    Public Property ArticulosActivo() As String
        Get
            Return ArticuloActivo

        End Get
        Set(ByVal value As String)
            ArticuloActivo = value
        End Set
    End Property

    'DAL Functions
    Public Sub New()
        ConnectionString = ConfigurationManager.AppSettings("ConnectionString").ToString()
    End Sub

    Public Sub InsertCustomer(ByVal CodigoArticulo As String, ByVal TipoArticulo As String, ByVal DescripcionArticulo As String, ByVal PrecioVentaArticulo As String,
                              ByVal ActivoArticulo As String)

        sql = "INSERT INTO Articulos(Codigo, Tipo, Descripcion, PrecioVenta, Activo) " &
                            "VALUES (@CustomerName, @CustomerGender, @CustomerCity, @CustomerState, @CustomerType)"

        conn = New SqlConnection(ConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = CodigoArticulo
        cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 50).Value = TipoArticulo
        cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = DescripcionArticulo
        cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = PrecioVentaArticulo
        cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = ActivoArticulo
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub UpdateCustomer(ByVal CodigoArticulo As String, ByVal TipoArticulo As String, ByVal DescripcionArticulo As String, ByVal PrecioVentaArticulo As String,
                              ByVal ActivoArticulo As String)

        sql = "Update Articulos Set Codigo=@CustomerName, Tipo=@CustomerGender, Descripcion=@CustomerCity, " &
                            " PrecioVenta=@CustomerState, Activo=@CustomerType Where Codigo=@CustomerName"
        conn = New SqlConnection(ConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = CodigoArticulo
        cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 50).Value = TipoArticulo
        cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = DescripcionArticulo
        cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = PrecioVentaArticulo
        cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = ActivoArticulo
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub DeleteCustomer(ByVal CustomerCode As Integer)
        conn = New SqlConnection(ConnectionString)
        sql = "Delete From Articulos Where Id=@CustomerCode"
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = CustomerCode
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function Fetch() As DataTable

        sql = "Select * from Articulos Order by Id"
        Dim da As New SqlDataAdapter(sql, ConnectionString)
        dt = New DataTable

        Try
            da.Fill(dt)
        Catch ex As Exception

        End Try

        Return dt
    End Function
End Class
