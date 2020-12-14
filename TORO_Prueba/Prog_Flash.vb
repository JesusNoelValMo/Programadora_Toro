Imports System.Timers

Module Prog_Flash
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
    Public Function Programar_Flash() As Boolean
        ' SetTimer()
        tiempo = 0
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



        'aTimer.Stop()
        'aTimer.Dispose()
        'checar los 2 leds para usb, el de la izq debe quedarse prendido despues e terminar de programar 
        'si uno de los 2 leds no parpadea esta mal



        ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
        ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
        estado_Ant1 = BitValue

        ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash2, BitValue)
        ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
        estado_Ant2 = BitValue


        ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_BOCINA, BitValue)
        ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
        Buzz = BitValue
        ' Produccion.Label9.Text = TimeOfDay
        timeol = TimeOfDay
        '   SetTimer()
        'aTimer.Stop()
        'aTimer.Dispose()
        While (True)
            'ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
            'ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
            'If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            'estado_Ant1 = BitValue


            System.Threading.Thread.Sleep(100)

            If Buzz = False Then
                ' Out_toggle(MccDaq.DigitalPortType.FirstPortA, 3, MccDaq.DigitalLogicState.High)
                Return False

                Exit While
            Else


                ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_BOCINA, BitValue)
                ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop

                Buzz = BitValue

            End If

            If estado_Ant2 = estado_Nvo2 Then
                LED2_Error_cont2 = LED2_Error_cont2 + 1
                ' System.Threading.Thread.Sleep(10)
                ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash2, BitValue)
                ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
                estado_Ant2 = estado_Nvo2
                estado_Nvo2 = BitValue

            Else
                '   System.Threading.Thread.Sleep(10)
                ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash2, BitValue)
                ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
                If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
                estado_Ant2 = estado_Nvo2
                estado_Nvo2 = BitValue

                LED2_Error_cont2 = 0
            End If

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

            If LED2_Error_cont2 > 20 Then
               
                LED2_Error_cont2 = 0
                Led1_Error_Cont = 0
                Time_Out_Cont = 0
                Led1_Ok_cont = 0
                Return False
                Exit While
            End If

            If Led1_Ok_cont > 20 Then
                'Produccion.Label10.Text = TimeOfDay

                ' MsgBox("Finish Flash")
                Led1_Ok_cont = 0
                Led1_Error_Cont = 0
                LED2_Error_cont2 = 0
                Time_Out_Cont = 0
                Return True
                ' MsgBox(Time_Out_Cont)
                Exit While
            End If
            If Time_Out_Cont > 200 Then
                'Produccion.Label10.Text = TimeOfDay
                ' Mensajes.RichMsgError_flash(3)
                Produccion.RichTextBox1.AppendText("Time Out Error" & vbCrLf)
                'MsgBox("Time Out Error")
                Time_Out_Cont = 0
                Led1_Ok_cont = 0
                Led1_Error_Cont = 0
                LED2_Error_cont2 = 0
                Return False
                Exit While
            End If

            '  System.Threading.Thread.Sleep(5)


        End While




        Led_Encendido = BitValue
        tiempo = tiempo + 1
        ' System.Threading.Thread.Sleep(10)


        'If tiempo >= 7 Then
        '    MsgBox("Falla Flash")
        'Else
        '    MsgBox("OK Flash")
        'End If
        tiempo = 0


    End Function
    Private Sub SetTimer()
        ' Create a timer with a two second interval.
        aTimer = New System.Timers.Timer(20)
        ' Hook up the Elapsed event for the timer. 
        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        aTimer.AutoReset = True
        aTimer.Enabled = True


    End Sub
    Private Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
       

        ' While (True)
        ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
        ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
        If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
        estado_Ant1 = BitValue


        ' System.Threading.Thread.Sleep(15)


        If estado_Ant2 = estado_Nvo2 Then
            LED2_Error_cont2 = LED2_Error_cont2 + 1
            ' System.Threading.Thread.Sleep(10)
            ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash2, BitValue)
            ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            estado_Ant2 = estado_Nvo2
            estado_Nvo2 = BitValue

        Else
            '   System.Threading.Thread.Sleep(10)
            ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash2, BitValue)
            ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            estado_Ant2 = estado_Nvo2
            estado_Nvo2 = BitValue

            LED2_Error_cont2 = 0
        End If

        If estado_Ant1 <> estado_Nvo1 Then
            Time_Out_Cont = Time_Out_Cont + 1
            '  System.Threading.Thread.Sleep(10)
            ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
            ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
            If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            estado_Ant1 = estado_Nvo1
            estado_Nvo1 = BitValue
            Led1_Ok_cont = 0
            Led1_Error_Cont = 0

        ElseIf (estado_Ant1 = estado_Nvo1) And estado_Ant1 = False Then
            Led1_Ok_cont = Led1_Ok_cont + 1
            'System.Threading.Thread.Sleep(10)
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
            'Else
            '    Time_Out_Cont = Time_Out_Cont + 1
            '    System.Threading.Thread.Sleep(10)
            '    ULStat = DaqBoard.DBitIn(MccDaq.DigitalPortType.FirstPortA, PIN_LED_Flash1, BitValue)
            '    ULStat = DaqBoard.DIn(MccDaq.DigitalPortType.FirstPortA, datavalue)
            '    If ULStat.Value <> MccDaq.ErrorInfo.ErrorCode.NoErrors Then Stop
            '    estado_Ant1 = estado_Nvo1
            '    estado_Nvo1 = BitValue

            '    Led1_Ok_cont = 0
            '    Led1_Error_Cont = 0
        End If

        If Led1_Error_Cont > 1500 Then
            timene = TimeOfDay

            MsgBox("De: " & timeol & "A: " & timene)
            MsgBox("pieza mala, 1er led flash")
            aTimer.Stop()
            aTimer.Dispose()
            Led1_Error_Cont = 0
            aTimer.EndInit()
            'Exit While
        End If

        'If LED2_Error_cont2 > 150 Then
        '    timene = TimeOfDay
        '    MsgBox("pieza mala, 2do led flash")
        '    MsgBox("De: " & timeol & "A: " & timene)

        '    aTimer.Stop()
        '    aTimer.Dispose()
        '    LED2_Error_cont2 = 0

        '    ' Exit While
        'End If

        'If Led1_Ok_cont > 200 Then
        '    timene = TimeOfDay
        '    MsgBox("Finish Flash")
        '    MsgBox("De: " & timeol & "A: " & timene)

        '    aTimer.Stop()
        '    aTimer.Dispose()
        '    Led1_Ok_cont = 0
        '    MsgBox(Time_Out_Cont)
        '    ' Exit While
        'End If
        'If Time_Out_Cont > 400 Then
        '    timene = TimeOfDay
        '    MsgBox("Time Out Error")
        '    MsgBox("De: " & timeol & "A: " & timene)

        '    aTimer.Stop()
        '    aTimer.Dispose()

        '    'Exit While
        'End If

        '  System.Threading.Thread.Sleep(5)

        '      aTimer.Stop()
        '        aTimer.Dispose()

        ' End While

    End Sub
End Module
