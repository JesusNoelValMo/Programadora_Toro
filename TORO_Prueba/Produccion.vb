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
        Me.Hide()
        Ini.Show()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        While 1
            While BackGroundFlag = True

                System.Threading.Thread.Sleep(1000)
                tiempo2 = tiempo2 + 1
            End While
        End While


    End Sub

   
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim Pathfm, pathcomando As String
        Dim b As Long
        Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
        Pathfm = Application.StartupPath & "\SDE\Flash_Magic\FM.exe"
        pathcomando = Application.StartupPath & "\SDE\BootLoader\BootConfig.fms"
        check_Bootloader = Programar_Boot(Pathfm, pathcomando)
        If check_Bootloader = True Then
            OvalShape1.FillColor = Color.Green
            Me.Refresh()
            'System.Threading.Thread.Sleep(50)
            Application.DoEvents()
            BackgroundWorker3.RunWorkerAsync()

        Else
            OvalShape1.FillColor = Color.Red
            RichTextBox1.AppendText("Error al Programar Bootloader" & vbCrLf)
            'Mensajes.RichMsgError(2)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Me.Refresh()
            Return

        End If
    End Sub

    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
       
        If Flash = "--" Then
            OvalShape2.FillColor = Color.Gray
            OvalShape2.Enabled = False
        Else
            '  Mensajes.RichMsgOK(2)
            RichTextBox1.AppendText("Iniciando Programacion de Flash..." & vbCrLf)
            Me.Refresh()
            check_Flash = Programar_Flash()
            If check_Flash = True Then
                OvalShape2.FillColor = Color.Green
                RichTextBox1.AppendText("Iniciando Programacion de Firmware..." & vbCrLf)
                Me.Refresh()

                Application.DoEvents()
                BackgroundWorker4.RunWorkerAsync()
                ' System.Threading.Thread.Sleep(50)
            Else
                OvalShape2.FillColor = Color.Red
                'Mensajes.RichMsgError(3)
                RichTextBox1.AppendText("Error al Programar Flash" & vbCrLf)
                Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
                Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
                Me.Refresh()
                Return
            End If
        End If
    End Sub

    Private Sub BackgroundWorker4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        Dim checkBD, check_Bootloader, check_Flash, check_firmware As Boolean
        BackgroundWorker3.WorkerSupportsCancellation = True
        BackgroundWorker3.CancelAsync()
        check_firmware = Programar_Firmware((USB - 1))
        If check_firmware = True Then
            OvalShape3.FillColor = Color.Green
            System.Threading.Thread.Sleep(7000)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, (USB - 1), MccDaq.DigitalLogicState.Low)
            RichTextBox1.AppendText("Programacion Finalizada..." & vbCrLf)
            Try
                Reset_Dio()
                ' Imprime Etiqueta
                PrintDocument1.Print()
                'If LastSerie = 65535 Then
                '    LastSerie = 0
                'Else
                '    LastSerie = LastSerie + 1
                'End If
                Up_Serie(Modelo, Hex(LastSerie))
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
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, (USB - 1), MccDaq.DigitalLogicState.Low)
            Reset_Dio()
            Me.Refresh()

            Return
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qr As Image
        Dim qr2 As Image
        Dim ancho, largo As Integer
        If LastSerie = 65535 Then
            LastSerie = 0
        Else
            LastSerie = LastSerie + 1
        End If
        Etiqueta_Info = Modelo & "_" & Today.ToString("MMddyyyy") & "_Rev." & Revision & "_" & Hex(LastSerie)
        qr = QR_Generator.Encode(Etiqueta_Info)
        ancho = Etiqueta_Ancho
        largo = Etiqueta_Largo
        For i As Integer = 0 To 1
            If i = 0 Then
                e.Graphics.DrawImage(qr, 5, 5, ancho, largo)
            Else
                'e.Graphics.DrawString(Modelo & vbCrLf & Hex(LastSerie), New Font("Arial", 12), Brushes.Black, 5 + 46, 5 + 5)
                e.Graphics.DrawString(Modelo & vbCrLf & Today.ToString("MMddyyyy"), New Font("Arial", 6), Brushes.Black, 5 + 23, 5 + 5)
            End If
        Next
    End Sub

    Private Sub OvalShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OvalShape1.Click

    End Sub
End Class
