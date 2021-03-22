Module Prog_Firmware_0582_4294
    Dim ULStat As MccDaq.ErrorInfo
    Dim BitValue As MccDaq.DigitalLogicState
    Dim PortType As MccDaq.DigitalPortType
    Dim BitNum As Integer
    Dim Encendido As Integer
    Dim DS6_Status As Boolean
    'Private DaqBoard As MccDaq.MccBoard
    Public Function Programar_Firmware_0582_4294(ByVal Firmware_Bit As Integer) As Boolean
        tiempo = 0
        Dim Led_Encendido As Boolean = True


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
            System.Threading.Thread.Sleep(100)
            
            'Para este modelo se va a revisar el Led "HOST" y el DS6(PIN_LED_FIRMWARE) ya que la tablilla no tiene otro led para indicar que la programacion del 
            'firmware ha terminado.
            ULStat = DaqBoard.DBitIn(PortType, PIN_LED_Flash1, BitValue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            Led_Encendido = BitValue
            ' tiempo = tiempo + 1

            If Led_Encendido = False Then
                Encendido = Encendido + 1
            Else
                Encendido = 0
            End If

            If tiempo2 > (Timeout_Firmware * 10) + 20 Then
                ' MsgBox("Falla Firmware")
                Encendido = 0
                Out_toggle(MccDaq.DigitalPortType.FirstPortA, Firmware_Bit, MccDaq.DigitalLogicState.Low)
                Return False
                Exit While
            ElseIf (tiempo2 < (Timeout_Firmware * 10) + 20) And (tiempo2 > (Timeout_Firmware * 10) - 20) And (Encendido > 20) Then
                Encendido = 0
                'ULStat = DaqBoard.DBitIn(PortType, PIN_LED_FIRMWARE, BitValue)
                '  If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
                '  DS6_Status = BitValue
                ' System.Threading.Thread.Sleep(300)
                ''If DS6_Status = True Then
                Return True
                Exit While
                ''Else
                ''    Encendido = 0
                ''    Out_toggle(MccDaq.DigitalPortType.FirstPortA, Firmware_Bit, MccDaq.DigitalLogicState.Low)
                ''    Return False
                ''    Exit While
                ''End If

            End If

        End While

        Encendido = 0
        'If tiempo >= 30 Then
        '    MsgBox("Falla Firmware")
        'Else
        '    MsgBox("OK Firmware")
        'End If
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, Firmware_Bit, MccDaq.DigitalLogicState.Low)
    End Function
End Module
