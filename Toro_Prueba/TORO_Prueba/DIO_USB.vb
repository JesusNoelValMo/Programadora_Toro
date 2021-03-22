Module DIO_USB

    Dim PortNum As MccDaq.DigitalPortType
    Dim Direction As MccDaq.DigitalPortDirection
    'Create a new MccBoard object for Board 0
    Public DaqBoard As MccDaq.MccBoard
    Public Function DIO_Ini() As Boolean

        Dim ULStat As MccDaq.ErrorInfo
        Dim BoardNum As Integer
        Dim typeVal As Integer
        Dim MyMessage As String
        Dim r As Microsoft.VisualBasic.MsgBoxResult

        DaqBoard = New MccDaq.MccBoard(Board_Num)   '<======this is the default board number
        ULStat = DaqBoard.BoardConfig.GetBoardType(typeVal)  ' Get the typeVal property from the MccBoard object
        If typeVal <> 146 Then
            MsgBox("DIO Incorrecto")
            End
        End If
        'InitPuertos

        'PUERTO 1 PARA USB (bit 0 to  23)
        'PULL DOWN
        PortNum = MccDaq.DigitalPortType.FirstPortA
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False


        'PULL DOWN
        PortNum = MccDaq.DigitalPortType.FirstPortB
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False

        PortNum = MccDaq.DigitalPortType.FirstPortCL
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.FirstPortCH
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False



        'PUERTO 2 PARA CONTROL DE SWITCH/Voltaje y Flash (bit 24 to 47, la memoria para programar la flash son los ultimos 2 pines(46 y 47))
        PortNum = MccDaq.DigitalPortType.SecondPortA
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.SecondPortB
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.SecondPortCL
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.SecondPortCH
        Direction = MccDaq.DigitalPortDirection.DigitalOut
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False

        'PUERTO 3 Para entradas (bit 48 to 71)
        PortNum = MccDaq.DigitalPortType.ThirdPortA
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.ThirdPortB
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.ThirdPortCL
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.ThirdPortCH
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False



        'PUERTO 4 Para entradas (bit 72 to 95)
        PortNum = MccDaq.DigitalPortType.FourthPortA
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.FourthPortB
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.FourthPortCL
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        PortNum = MccDaq.DigitalPortType.FourthPortCH
        Direction = MccDaq.DigitalPortDirection.DigitalIn
        ULStat = DaqBoard.DConfigPort(PortNum, Direction)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False

        Return True

    End Function
    Public Function Reset_Dio() As Boolean
        'To be safe, this turns all the digital bits off before the program ends.
        Dim ULStat As MccDaq.ErrorInfo
        Dim DataValue As MccDaq.DigitalLogicState
        Dim x As MccDaq.DigitalPortType
        For x = 10 To 17
            DataValue = MccDaq.DigitalLogicState.Low
            ULStat = DaqBoard.DOut(x, DataValue)
            ' ULStat = DaqBoard.DOut(mccda, DataValue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Return False
        Next x
        ' End
    End Function
    Public Function Out_toggle(ByVal Port As MccDaq.DigitalPortType, ByVal bitNum As Integer, ByVal BitValue As MccDaq.DigitalLogicState)
        Dim ULStat As MccDaq.ErrorInfo
        Dim PortType As MccDaq.DigitalPortType
        Dim direcr As MccDaq.DigitalPortDirection
        PortType = MccDaq.DigitalPortType.FirstPortA
        ' PortType = MccDaq.DigitalPortType.SecondPortA
        Try
            ULStat = DaqBoard.DBitOut(PortType, bitNum, BitValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
    End Function
    Public Function LeerConfigDIO() As Boolean

        conn.Close()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT Board_Num, Etiqueta_Ancho, Etiqueta_Largo, Etiqueta_Size FROM DIO_Config"
        Try
            conn.Open()
            Try
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        Board_Num = dr(0).ToString
                        Etiqueta_Ancho = dr(1).ToString
                        Etiqueta_Largo = dr(2).ToString
                        Tamaño_Fuente_Print = dr(3).ToString
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
    Public Function Guardar_Board_Number(ByVal Num As String) As Boolean
        conn.Close()
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        sql = "Update DIO_Config set Board_Num='" & Num & "'"
        cmd.CommandText = sql
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
    End Function
    Public Function Guardar_Label_Lab(ByVal Ancho As String, ByVal Largo As String, ByVal sz As String) As Boolean
        conn.Close()
        conn.Open()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text

        sql = "Update DIO_Config set Etiqueta_Ancho='" & Ancho & "' ,Etiqueta_Largo='" & Largo & "' ,Etiqueta_Size=" & sz.ToString
        cmd.CommandText = sql
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conn.Close()
    End Function
End Module
