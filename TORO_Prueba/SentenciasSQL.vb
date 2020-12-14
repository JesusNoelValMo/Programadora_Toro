Imports System
Imports System.IO
Imports System.Text
Module SentenciasSQL
    Public conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\DB\ModelosProd.accdb;Mode= ReadWrite; Persist Security Info=False")
    Public cmd As New OleDb.OleDbCommand
    Public dr As OleDb.OleDbDataReader
    Public sql As String
    Public Function LeerUsuarios(ByVal User As String)
        conn.Close()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT Nombre, Contra, Nivel FROM Usuarios where Nombre='" & User & "'"
        Try
            conn.Open()
            Try
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Nombre_Usuario = dr(0).ToString
                        Contraseña_Usuario = dr(1).ToString
                        Nivel_Usuario = dr(2).ToString
                        Sigue = True
                    End While
                Else
                    If isInit_sesion = True Then
                        MsgBox("Usuario Invalido")
                        Sigue = False
                    Else

                    End If
                  
                End If

            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        dr.Close()
        conn.Close()
    End Function
    Public Function LeerConfig(ByVal Model As String) As Boolean

        conn.Close()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT Modelo, Bootloader, Flash, Firmware, USB, Revision, Serie FROM Config where Modelo='" & Model & "'"
        Try
            conn.Open()
            Try
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Modelo = dr(0).ToString
                        Bootloader = dr(1).ToString
                        Flash = dr(2).ToString
                        Firmware = dr(3).ToString
                        USB = dr(4).ToString
                        LastSerie = dr(6).ToString
                        Revision = dr(5).ToString
                    End While
                    dr.Close()
                    conn.Close()
                    Return True
                Else
                    dr.Close()
                    conn.Close()
                    Return False
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        dr.Close()
        conn.Close()
    End Function
    Public Function Write_New_Modelo(ByVal Model As String, ByVal Boot As String, ByVal Flash As String, ByVal Firmware As String, ByVal Usb_N As String, ByVal rev As String)
        If (IsNumeric(Usb_N) = True) And (Usb_N > 0) And (Usb_N < 11) Then
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            sql = "INSERT INTO Config (Modelo, Bootloader, Flash, Firmware, USB, Revision)"
            sql += "VALUES('" & Model & "','" & Boot & "','" & Flash & "','" & Firmware & "','" & Usb_N & "','" & rev & "')"
            cmd.CommandText = sql
            Try
                cmd.ExecuteNonQuery()
                Fill_CB_Mant(Mant.ComboBox1, "Modelo", "Config")

                'Fill_CB_Modelos_Mant()
            Catch ex As Exception
                If ex.ToString.Contains("0x80004005") Then
                    MsgBox("Modelo Existente")
                Else
                    MsgBox(ex.ToString)
                End If

            End Try
            conn.Close()

        Else
            MsgBox("Numero de USB Invalido")
        End If

    End Function
    Public Function Write_New_User(ByVal User_N As String, ByVal Pass_N As String, ByVal Lev_N As String)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        sql = "INSERT INTO usuarios (Nombre, Contra, Nivel)"
        sql += "VALUES('" & User_N & "','" & Pass_N & "','" & Lev_N & "')"
        cmd.CommandText = sql
        Try
            cmd.ExecuteNonQuery()
            Fill_CB_Mant(Mant.ComboBox2, "Nombre", "Usuarios")

        Catch ex As Exception
            If ex.ToString.Contains("0x80004005") Then
                MsgBox("Usuario Existente")
            Else
                MsgBox(ex.ToString)
            End If

        End Try
        conn.Close()
    End Function
    Public Function Up(ByVal Model As String, ByVal Boot As String, ByVal Flash As String, ByVal Firmware As String, ByVal usb_N As String, ByVal rev As String)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        sql = "Update Config set Bootloader='" & Boot & "', Flash='" & Flash & "', Firmware='" & Firmware & "', USB='" & usb_N & "', Revision='" & rev & "' where Modelo='" & Model & "'"
        cmd.CommandText = sql
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
    End Function
    Public Function Up_Serie(ByVal Modelo As String, ByVal Serie As String)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        sql = "Update Config set Serie='" & Serie & "'where modelo='" & Modelo & "'"
        cmd.CommandText = sql
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
    End Function
    Public Function Up_User(ByVal User_N As String, ByVal Pass_N As String, ByVal Lev_N As String)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        sql = "Update usuarios set Contra='" & Pass_N & "', Nivel='" & Lev_N & "' where Nombre='" & User_N & "'"
        cmd.CommandText = sql
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
    End Function
    'Public Sub Write_Reg()
    Public Sub Write_Reg(ByVal Model As String, ByVal Boot As String, ByVal Flash As String, ByVal Firmware As String, ByVal Hora As String, ByVal Fecha As String, ByVal Serial As String, ByVal Rev As String, ByVal User As String)
        Dim path As String = Application.StartupPath & "\DB\Log-" & Format(Today, "MM-dd-yyyy") & ".csv"
        If Not File.Exists(path) Then
            ' Create a file to write to. 
            Using sw As StreamWriter = File.CreateText(path)
                sw.WriteLine("Modelo,Bootloader,Flash,Firmware,Hora,Fecha,Rev,Serie,Usuario")
                'sw.WriteLine("12, 10, 1, 1, 2, 3" & "FFF" & "," & "Produccion")
                sw.WriteLine(Model & "," & Boot & "," & Flash & "," & Firmware & "," & Hora & "," & Fecha & "," & Rev & "," & Serial & "," & User)
                sw.Close()
            End Using
        Else
            Dim sw As System.IO.StreamWriter
            sw = My.Computer.FileSystem.OpenTextFileWriter(path, True)
            'sw.WriteLine("12, 10, 1, 1, 2, 3" & "FFF" & "," & "Produccion")
            sw.WriteLine(Model & "," & Boot & "," & Flash & "," & Firmware & "," & Hora & "," & Fecha & "," & Rev & "," & Serial & "," & User)
            sw.Close()
            '  Using sw As FileStream = File.OpenWrite(path)
            'sw.WriteLine(Model & "," & Boot & "," & Flash & "," & FrameWork & "," & Hora & "," & Fecha & ",")
            '  End Using
        End If
    End Sub
    Public Function Fill_CB_Mant(ByRef CB1 As ComboBox, ByVal column_N As String, ByVal table_N As String)
        CB1.Items.Clear()
        conn.Close()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT " & column_N & " from " & table_N & ""
        Try
            conn.Open()
            Try
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Modelo = dr(0).ToString
                        ' Mant.ComboBox2.Items.Add(dr(0).ToString)
                        CB1.Items.Add(dr(0).ToString)
                    End While
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        dr.Close()
    End Function
   
    Public Function Delete_Modelo(ByRef Model As String)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Delete from config where Modelo='" & Model & "'"
        Try
            cmd.ExecuteNonQuery()
            Fill_CB_Mant(Mant.ComboBox1, "Modelo", "Config")

        Catch ex As Exception
                MsgBox(ex.ToString)
        End Try
        conn.Close()

    End Function

    Public Function Delete_User(ByRef User_N As String)
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Delete from Usuarios where Nombre='" & User_N & "'"
        Try
            cmd.ExecuteNonQuery()

            Fill_CB_Mant(Mant.ComboBox2, "Nombre", "Usuarios")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
    End Function
End Module
