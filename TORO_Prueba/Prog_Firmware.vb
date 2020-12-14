Module Prog_Firmware
    Dim ULStat As MccDaq.ErrorInfo
    Dim BitValue As MccDaq.DigitalLogicState
    Dim PortType As MccDaq.DigitalPortType
    Dim BitNum As Integer
    Dim Encendido As Integer
    'Private DaqBoard As MccDaq.MccBoard
    Public Function Programar_Firmware(ByVal Firmware_Bit As Integer) As Boolean
        tiempo = 0
        Dim Led_Encendido As Boolean = True
        Dim Buzz As Boolean = True

        For i As Integer = 0 To 10
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, i, MccDaq.DigitalLogicState.Low)
        Next

        For i As Integer = 12 To 42
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, i, MccDaq.DigitalLogicState.Low)
        Next
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
        ' Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash2, MccDaq.DigitalLogicState.Low)
        System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, Firmware_Bit, MccDaq.DigitalLogicState.High)
        System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch_Reset, MccDaq.DigitalLogicState.High)
        System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch_Reset, MccDaq.DigitalLogicState.Low)
        PortType = MccDaq.DigitalPortType.FirstPortA
        ''  While (Led_Encendido <> False Or (tiempo < 30 And Led_Encendido = True)) And (Encendido < 2)
        While (1)
            System.Threading.Thread.Sleep(500)
            ULStat = DaqBoard.DBitIn(PortType, PIN_BOCINA, BitValue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            Buzz = BitValue

            If tiempo < 60 And Buzz = False Then
                ' MsgBox("Falla Firmware")
                Return False

                Exit While
            End If

            ULStat = DaqBoard.DBitIn(PortType, PIN_LED_FIRMWARE, BitValue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            Led_Encendido = BitValue
            tiempo = tiempo + 1

            If Led_Encendido = False Then
                Encendido = Encendido + 1
            Else
                Encendido = 0
            End If

            If tiempo > 60 Then
                ' MsgBox("Falla Firmware")
                Out_toggle(MccDaq.DigitalPortType.FirstPortA, Firmware_Bit, MccDaq.DigitalLogicState.Low)
                Return False
                Exit While
            ElseIf tiempo < 60 And Encendido > 2 Then
                Return True
                Exit While


            End If

        End While
        'If tiempo >= 30 Then
        '    MsgBox("Falla Firmware")
        'Else
        '    MsgBox("OK Firmware")
        'End If
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, Firmware_Bit, MccDaq.DigitalLogicState.Low)
    End Function
End Module
