Imports System.Timers
Module Prog_Flash_0582_4294
    Dim ULStat As MccDaq.ErrorInfo
    Dim BitValue As MccDaq.DigitalLogicState
    Dim PortType As MccDaq.DigitalPortType
    Dim BitNum As Integer
    Dim datavalue As Short
    Dim t1 As New Timer
    Public aTimer As System.Timers.Timer
    Dim estado_Nvo1 As Boolean
    Dim estado_Nvo2 As Boolean
    Dim Led1_Ok_cont, LED2_Error_cont2, Time_Out_Cont, Led1_Error_Cont As Integer
    Dim estado_Ant1 As Boolean
    Dim estado_Ant2 As Boolean
    Dim Timempo_Ant, Tiempo_Nvo As Date
    Dim Buzz As Boolean
    Dim timene, timeol As Date
    Public Function Programar_Flash_0582_4294() As Boolean
        ' SetTimer()
        ' tiempo = 0
        Dim Led_Encendido As Boolean
        For i As Integer = 0 To 10
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, i, MccDaq.DigitalLogicState.Low)
        Next
        For i As Integer = 12 To 47
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, i, MccDaq.DigitalLogicState.Low)
        Next
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
        ' Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash2, MccDaq.DigitalLogicState.Low)
        System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.High)
        System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch_Reset, MccDaq.DigitalLogicState.High)
        System.Threading.Thread.Sleep(50)
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Switch_Reset, MccDaq.DigitalLogicState.Low)



        'Revisar unicamente DS7(HOST) (PIN_LED_Flash1)


        ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
        ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
        estado_Ant1 = BitValue

        While (True)



            System.Threading.Thread.Sleep(100)
            If estado_Ant1 <> estado_Nvo1 Then
                Time_Out_Cont = Time_Out_Cont + 1
                ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
                ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
                estado_Ant1 = estado_Nvo1
                estado_Nvo1 = BitValue
                Led1_Ok_cont = 0
                Led1_Error_Cont = 0

            ElseIf (estado_Ant1 = estado_Nvo1) And estado_Ant1 = False Then
                Led1_Ok_cont = Led1_Ok_cont + 1

                ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
                ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
                estado_Ant1 = estado_Nvo1
                estado_Nvo1 = BitValue
                Time_Out_Cont = Time_Out_Cont + 1

            ElseIf (estado_Ant1 = estado_Nvo1) And estado_Ant1 = True Then
                Led1_Error_Cont = Led1_Error_Cont + 1
                '  System.Threading.Thread.Sleep(10)
                ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
                ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
                estado_Ant1 = estado_Nvo1
                estado_Nvo1 = BitValue
                Time_Out_Cont = Time_Out_Cont + 1
                Led1_Ok_cont = 0

            End If

            If Led1_Error_Cont > 20 Then

                Led1_Error_Cont = 0
                LED2_Error_cont2 = 0
                Time_Out_Cont = 0
                Led1_Ok_cont = 0
                Return False
                Exit While
            End If

            If Led1_Ok_cont > 20 Then
                Led1_Ok_cont = 0
                Led1_Error_Cont = 0
                LED2_Error_cont2 = 0
                Time_Out_Cont = 0


                Return True
                Exit While
            End If
            If tiempo2 > Timeout_Flash Then
                Produccion.RichTextBox1.AppendText("Time Out Error" & vbCrLf)
                Time_Out_Cont = 0
                Led1_Ok_cont = 0
                Led1_Error_Cont = 0
                LED2_Error_cont2 = 0
                Return False
                Exit While
            End If
        End While
        Led_Encendido = BitValue



    End Function
    
End Module
