Module Prog_Bootloader
    Public Function Programar_Boot(ByVal pathexe As String, ByVal pathfms As String) As Boolean
        ' Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_24Volts, MccDaq.DigitalLogicState.High)
        ' System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch_Reset, MccDaq.DigitalLogicState.High)
        System.Threading.Thread.Sleep(100)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch2, MccDaq.DigitalLogicState.High)
        System.Threading.Thread.Sleep(200)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch_Reset, MccDaq.DigitalLogicState.Low)
        System.Threading.Thread.Sleep(100)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch2, MccDaq.DigitalLogicState.Low)
        'System.Threading.Thread.Sleep(200)
        For i As Integer = 0 To 10
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, i, MccDaq.DigitalLogicState.Low)
        Next

        For i As Integer = 12 To 42
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, i, MccDaq.DigitalLogicState.Low)
        Next

       
        Dim a As String
        a = """" & pathexe & """ " & "@" & pathfms & ""
        Try

            tiempo2 = 0
            BackGroundFlag = True
            Shell(a, vbNormalFocus, True)
            BackGroundFlag = False
            ' MsgBox(tiempo2)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If (tiempo2 > ((Timeout_Bootloader * 10) - 60)) And (tiempo2 < ((Timeout_Bootloader * 10) + 60)) Then
            'If (tiempo2 > Timeout_Bootloader - 5) And (tiempo2 < Timeout_Bootloader + 30) Then
            ' MsgBox("Falla Bootloader")
            Return True
        Else
            Return False
            ' MsgBox("OK Bootloader")

        End If
        '  Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_24Volts, MccDaq.DigitalLogicState.Low)
        'MsgBox("ASD")
    End Function
End Module
