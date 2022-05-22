Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Public Class Form3

    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter
    Dim sqlQuery As String

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "Malav108020"
    Dim database As String = "myconnector"

    Private bitmap As Bitmap
    Private Sub updateTableReg()
        sqlConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" + "password =" + password + ";" + "database =" + database
        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        sqlCmd.CommandText = "SELECT * FROM myconnector.user_reg"
        sqlRd = sqlCmd.ExecuteReader
        sqlDt.Load(sqlRd)
        sqlRd.Close()
        sqlConn.Close()
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlConn.ConnectionString = "server =" + server + ";" + "user id =" + username + ";" + "password =" + password + ";" + "database =" + database
        Try
            sqlConn.Open()
            sqlQuery = "Insert into myconnector.user_reg(username, password, con_password) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            If TextBox2.Text = TextBox3.Text Then
                sqlCmd = New MySqlCommand(sqlQuery, sqlConn)
                Try
                    sqlRd = sqlCmd.ExecuteReader
                Catch ex As Exception
                    MessageBox.Show("Create Unique Account")
                End Try
                sqlConn.Close()
            Else
                MessageBox.Show("Password does not matched.!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "MySql Connector", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            sqlConn.Dispose()
        End Try
        If TextBox2.Text = TextBox3.Text Then
            Me.Close()
        End If
        updateTableReg()
    End Sub
End Class