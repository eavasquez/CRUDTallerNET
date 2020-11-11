Option Explicit On
Option Infer On
Option Strict On

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class CustomerCls

    Dim ClienteId As Integer
    Dim ClienteRUT As String
    Dim ClienteNombre As String
    Dim ClienteApellido As String
    Dim ClienteCargo As String
    Dim ClienteActivo As String
    Dim ConnectionString As String
    Dim sql As String
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim dt As DataTable

    Public Property ClientesId() As Integer
        Get
            Return ClienteId
        End Get
        Set(ByVal value As Integer)
            ClienteId = value
        End Set
    End Property

    Public Property ClientesRUT() As String
        Get
            Return ClienteRUT
        End Get
        Set(ByVal value As String)
            ClienteRUT = value
        End Set
    End Property

    Public Property ClientesTipo() As String
        Get
            Return ClienteNombre
        End Get
        Set(ByVal value As String)
            ClienteNombre = value
        End Set
    End Property

    Public Property ClientesNombre() As String
        Get
            Return ClienteApellido
        End Get
        Set(ByVal value As String)
            ClienteApellido = value
        End Set
    End Property

    Public Property ClientesGiro() As String
        Get
            Return ClienteCargo
        End Get
        Set(ByVal value As String)
            ClienteCargo = value
        End Set
    End Property

    Public Property ClientesActivo() As String
        Get
            Return ClienteActivo

        End Get
        Set(ByVal value As String)
            ClienteActivo = value
        End Set
    End Property

    'DAL Functions
    Public Sub New()
        ConnectionString = ConfigurationManager.AppSettings("ConnectionString").ToString()
    End Sub

    Public Sub InsertCustomer(ByVal RUTCliente As String, ByVal NombreCliente As String, ByVal ApellidoCliente As String, ByVal CargoCliente As String,
                              ByVal ActivoCliente As String)

        sql = "INSERT INTO Cliente(RUT, Nombre, Apellido, Cargo, Activo) " &
                            "VALUES (@CustomerName, @CustomerGender, @CustomerCity, @CustomerState, @CustomerType)"

        conn = New SqlConnection(ConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = RUTCliente
        cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 50).Value = NombreCliente
        cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = ApellidoCliente
        cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = CargoCliente
        cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = ActivoCliente
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub UpdateCustomer(ByVal RUTCliente As String, ByVal NombreCliente As String, ByVal ApellidoCliente As String, ByVal CargoCliente As String,
                              ByVal ActivoCliente As String)

        sql = "Update Cliente Set RUT=@CustomerName, Nombre=@CustomerGender, Apellido=@CustomerCity, " &
                            " Cargo=@CustomerState, Activo=@CustomerType Where RUT=@CustomerName"
        conn = New SqlConnection(ConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 50).Value = RUTCliente
        cmd.Parameters.Add("@CustomerGender", SqlDbType.VarChar, 50).Value = NombreCliente
        cmd.Parameters.Add("@CustomerCity", SqlDbType.VarChar, 50).Value = ApellidoCliente
        cmd.Parameters.Add("@CustomerState", SqlDbType.VarChar, 50).Value = CargoCliente
        cmd.Parameters.Add("@CustomerType", SqlDbType.VarChar, 50).Value = ActivoCliente
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Sub DeleteCustomer(ByVal CustomerCode As Integer)
        conn = New SqlConnection(ConnectionString)
        sql = "Delete From Cliente Where Id=@CustomerCode"
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        cmd.Parameters.Add("@CustomerCode", SqlDbType.Int).Value = CustomerCode
        cmd.Prepare()
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Function Fetch() As DataTable

        sql = "Select * from Cliente Order by Id"
        Dim da As New SqlDataAdapter(sql, ConnectionString)
        dt = New DataTable

        Try
            da.Fill(dt)
        Catch ex As Exception

        End Try

        Return dt
    End Function

End Class
