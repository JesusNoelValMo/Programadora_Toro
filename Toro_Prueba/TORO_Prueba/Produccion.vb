Public Class Produccion
    Dim QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim init, reset As Boolean
        LeerConfigDIO()

        init = DIO_Ini()
        If init = False Then
            MsgBox("Error al Iniciar DIO")
            Application.Exit()

        End If
        reset = Reset_Dio()
        If init = False Then
            MsgBox("Error al Resetear DIO")
            Application.Exit()
        End If

        CheckForIllegalCrossThreadCalls = False
        BackgroundWorker1.RunWorkerAsync()
        '  Out_toggle(MccDaq.DigitalPortType.FirstPortA, 0, MccDaq.DigitalLogicState.High)
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        If TextBox1.Text.Length = 8 Then

            RichTextBox1.Clear()
            Mensajes.RichMsgOK(1)
            Dim Pathfm, pathcomando As String
            Dim b As Long
            Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
            'RichTextBox1.Clear()
            OvalShape1.FillColor = System.Drawing.SystemColors.Control
            OvalShape2.FillColor = System.Drawing.SystemColors.Control

            OvalShape3.FillColor = System.Drawing.SystemColors.Control
            Me.Refresh()

            ' OvalShape1.FillColor = 
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)
            'Se busca en la base de datos 
            ' System.Threading.Thread.Sleep(1500)
            checkBD = LeerConfig(TextBox1.Text)

            If checkBD = False Then
                RichMsgError(1)
                Return
            Else
                Label2.Text = Bootloader
                Label4.Text = Flash
                Label6.Text = Firmware
                Label7.Text = ""
                Label7.Text = "Rev. " + Revision
                ' Write_Reg(TextBox1.Text, Label2.Text, Label4.Text, Label6.Text, TimeOfDay, Today, Hex(LastSerie), Revision, Nombre_Usuario)
                Pathfm = Application.StartupPath & "\SDE\Flash_Magic\FM.exe"
                pathcomando = Application.StartupPath & "\SDE\BootLoader\BootConfig.fms"
                BackgroundWorker2.RunWorkerAsync()

            End If
        Else

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Ini.Show()
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        While 1
            ' While BackGroundFlag = True
            tiempo2 = tiempo2 + 1
            System.Threading.Thread.Sleep(100)

            'End While
        End While
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim Pathfm, pathcomando As String
        Dim b As Long
        Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
        Pathfm = Application.StartupPath & "\SDE\Flash_Magic\FM.exe"
        pathcomando = Application.StartupPath & "\SDE\BootLoader\BootConfig.fms"
        ' Timer1.Stop()
        'Timer1.Start()
        tiempo2 = 0
        check_Bootloader = Programar_Boot(Pathfm, pathcomando)
        If check_Bootloader = True Then
            OvalShape1.FillColor = Color.Green
            Me.Refresh()
            'System.Threading.Thread.Sleep(50)
            Timer1.Stop()
            tiempo2 = 0
            Application.DoEvents()
            BackgroundWorker3.RunWorkerAsync()
        Else
            OvalShape1.FillColor = Color.Red
            RichTextBox1.AppendText("Error al Programar Bootloader" & vbCrLf)
            Timer1.Stop()
            tiempo2 = 0

            'Mensajes.RichMsgError(2)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            TextBox1.Text = ""
            Me.Refresh()
            Return

        End If
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
       
        If Flash = "--" Then
            OvalShape2.FillColor = Color.Gray
            OvalShape2.Enabled = False
            RichTextBox1.AppendText("Iniciando Programacion de Firmware..." & vbCrLf)
            Timer1.Stop()
            tiempo2 = 0
            Me.Refresh()

            Application.DoEvents()
            BackgroundWorker4.RunWorkerAsync()
        Else
            '  Mensajes.RichMsgOK(2)
            RichTextBox1.AppendText("Iniciando Programacion de Flash..." & vbCrLf)
            Me.Refresh()
            ' Timer1.Stop()
            'Timer1.Start()
            tiempo2 = 0
            If Modelo = "118-4294" Or Modelo = "118-0582" Then
                check_Flash = Programar_Flash_0582_4294()

            Else
                check_Flash = Programar_Flash()
            End If

            If check_Flash = True Then
                OvalShape2.FillColor = Color.Green
                RichTextBox1.AppendText("Iniciando Programacion de Firmware..." & vbCrLf)
                Timer1.Stop()
                tiempo2 = 0
                Me.Refresh()

                Application.DoEvents()
                BackgroundWorker4.RunWorkerAsync()
                ' System.Threading.Thread.Sleep(50)
            Else
                Timer1.Stop()
                tiempo2 = 0
                OvalShape2.FillColor = Color.Red
                'Mensajes.RichMsgError(3)
                RichTextBox1.AppendText("Error al Programar Flash" & vbCrLf)
                Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
                Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
                TextBox1.Text = ""
                Me.Refresh()
                Return
            End If
        End If
    End Sub

    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
        BackgroundWorker3.WorkerSupportsCancellation = True
        BackgroundWorker3.CancelAsync()
        '   Timer1.Stop()
        '   Timer1.Start()
        tiempo2 = 0
        If Modelo = "118-4294" Or Modelo = "118-0582" Then
            check_firmware = Programar_Firmware_0582_4294((USB - 1))
        ElseIf Modelo = "118-3378" Or Modelo = "118-2919" Then
            check_firmware = Programar_Firmware_118_3378((USB - 1))


        Else
            check_firmware = Programar_Firmware((USB - 1))

        End If

        If check_firmware = True Then
            System.Threading.Thread.Sleep(8000)
            Timer1.Stop()
            tiempo2 = 0
            OvalShape3.FillColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, (USB - 1), MccDaq.DigitalLogicState.Low)
            RichTextBox1.AppendText("Programacion Finalizada..." & vbCrLf)
            Timer1.Stop()
            tiempo2 = 0
            Try
                Reset_Dio()

                PrintDocument1.Print()
         
                Up_Serie(Modelo, LastSerie)
                Write_Reg(TextBox1.Text, Label2.Text, Label4.Text, Label6.Text, TimeOfDay, Today, Hex(LastSerie), Revision, Nombre_Usuario)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Me.Refresh()
            System.Threading.Thread.Sleep(50)
        Else
            OvalShape3.FillColor = Color.Red
            '  Mensajes.RichMsgError(4)
            RichTextBox1.AppendText("Error al Programar Firmware" & vbCrLf)
            Timer1.Stop()
            tiempo2 = 0
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, (USB - 1), MccDaq.DigitalLogicState.Low)
            TextBox1.Text = ""
            Reset_Dio()
            Me.Refresh()
            Return
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qr As Image
        Dim Ancho, Largo As Integer
        Dim Str_Constructor As String

        qr = QR_Generator.Encode("XXX-XXXX_" & Today.ToString("ddMMMyyyy") & "_Rev.XX" & "_FFFF")
        Ancho = Etiqueta_Ancho
        Largo = Etiqueta_Largo
        If Print_Bootloader = True Then
            Str_Constructor = Str_Constructor & "B" & Label2.Text
        End If
        If Print_Flash = True Then
            Str_Constructor = Str_Constructor & "F" & Label4.Text
        End If

        If Print_Firmware = True Then
            Str_Constructor = Str_Constructor & "F" & Label6.Text
        End If
        'If Print_Bootloader = True Then
        '    Str_Constructor = Str_Constructor & "BX.XX"
        'End If
        'If Print_Flash = True Then
        '    Str_Constructor = Str_Constructor & "FX.XX"
        'End If

        'If Print_Firmware = True Then
        '    Str_Constructor = Str_Constructor & "FX.XX"
        'End If
        If Print_Bootloader = False And Print_Flash = False And Print_Firmware = False Then
            Str_Constructor = "N/A"
        End If
        e.Graphics.DrawString(Str_Constructor, New Font("Arial", Tamaño_Fuente_Print), Brushes.Black, Ancho, Largo)
        Dim qr2 As Image

        If LastSerie = 65535 Then
            LastSerie = 0
        Else
            LastSerie = LastSerie + 1
        End If
        'Etiqueta_Info = Modelo & "_" & Today.ToString("MMddyyyy") & "_Rev." & Revision & "_" & Hex(LastSerie)
        'qr = QR_Generator.Encode(Etiqueta_Info)


        'e.Graphics.DrawString(LastSerie & "-B" & Bootloader & "-F" & Flash & "-F" & Firmware, New Font("Arial", 7), Brushes.Black, 20, 5)
        '   End If 

        '  Next

    End Sub

    Private Sub OvalShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvalShape1.Click

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tiempo2 = tiempo2 + 1

    End Sub
End Class
