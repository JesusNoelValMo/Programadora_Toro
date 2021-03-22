Public Class Mant
    Dim QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Dim flag As Boolean = False


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox_USB_Mant.Text = ""
        Textbox_Boot_Mant.Text = ""
        TextBox_Flash_Mant.Text = ""
        TextBox_Firmware_Mant.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        Modelo_Mant.Text = ""
        ComboBox2.Text = ""
        Application.DoEvents()

        Me.Close()
        Ini.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Pathfm, pathcomando As String
        Dim confirm_Boot As Boolean = False
        Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Refresh()
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)

        Pathfm = Application.StartupPath & "\SDE\Flash_Magic\FM.exe"
        pathcomando = Application.StartupPath & "\SDE\BootLoader\BootConfig.fms"
        Timer1.Stop()
        Timer1.Start()
        tiempo2 = 0
        confirm_Boot = (Programar_Boot(Pathfm, pathcomando))
        If confirm_Boot = True Then
            Button4.BackColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Timer1.Stop()
            tiempo2 = 0

        Else
            Button4.BackColor = Color.Red
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Timer1.Stop()
            tiempo2 = 0
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Delete_Modelo(Modelo_Mant.SelectedItem)
            TextBox_USB_Mant.Text = ""
            Textbox_Boot_Mant.Text = ""
            TextBox_Flash_Mant.Text = ""
            TextBox_Firmware_Mant.Text = ""
            TextBox_Rev_mant.Text = ""
            TextBox_TimeOut_Boot_mant.Text = ""
            TextBox_TimeOut_Flash_Mant.Text = ""
            TextBox_TimeOut_Firmware_Mant.Text = ""
            Modelo_Mant.Text = ""
            Chk_Print_Boot.Checked = False
            Chk_Print_Firm.Checked = False
            Chk_Print_Flash.Checked = False

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Up(Modelo_Mant.SelectedItem, Textbox_Boot_Mant.Text, TextBox_Flash_Mant.Text, TextBox_Firmware_Mant.Text, TextBox_USB_Mant.Text, TextBox_Rev_mant.Text, TextBox_TimeOut_Boot_mant.Text, TextBox_TimeOut_Flash_Mant.Text, TextBox_TimeOut_Firmware_Mant.Text, Chk_Print_Boot.Checked, Chk_Print_Flash.Checked, Chk_Print_Firm.Checked)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Textbox_Boot_Mant.Text.Trim <> "" And TextBox_Flash_Mant.Text.Trim <> "" And TextBox_Firmware_Mant.Text.Trim <> "" And TextBox_USB_Mant.Text.Trim <> "" And TextBox_Rev_mant.Text.Trim <> "" And TextBox_TimeOut_Boot_mant.Text.Trim <> "" And TextBox_TimeOut_Firmware_Mant.Text.Trim <> "" And TextBox_TimeOut_Flash_Mant.Text.Trim <> "" Then
            Try
                Write_New_Modelo(Modelo_Mant.Text, Textbox_Boot_Mant.Text, TextBox_Flash_Mant.Text, TextBox_Firmware_Mant.Text, TextBox_USB_Mant.Text, TextBox_Rev_mant.Text, TextBox_TimeOut_Boot_mant.Text, TextBox_TimeOut_Flash_Mant.Text, TextBox_TimeOut_Firmware_Mant.Text, Chk_Print_Boot.Checked, Chk_Print_Flash.Checked, Chk_Print_Firm.Checked)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("Información del Modelo No Válida")
        End If


    End Sub

    Private Sub Mant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()

        Dim Init, Reset As Boolean
        LeerConfigDIO()
        TextBox7.Text = Board_Num
        TextBox9.Text = Etiqueta_Ancho
        TextBox10.Text = Etiqueta_Largo
        Font_Size.Text = Tamaño_Fuente_Print
        ' LeerConfigDIO()

        Init = DIO_Ini()
        If Init = False Then
            MsgBox("Error al Iniciar DIO")
            Application.Exit()

        End If
        Reset = Reset_Dio()
        If Init = False Then
            MsgBox("Error al Resetear DIO")
            Application.Exit()
        End If




        Fill_CB_Mant(Modelo_Mant, "Modelo", "Config")
        Fill_CB_Mant(ComboBox2, "Nombre", "Usuarios")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modelo_Mant.SelectedIndexChanged
        LeerConfig(Modelo_Mant.SelectedItem)
        Textbox_Boot_Mant.Text = Bootloader
        TextBox_Flash_Mant.Text = Flash
        TextBox_Firmware_Mant.Text = Firmware
        TextBox_USB_Mant.Text = USB
        TextBox_Rev_mant.Text = Revision
        TextBox_TimeOut_Boot_mant.Text = Timeout_Bootloader
        TextBox_TimeOut_Flash_Mant.Text = Timeout_Flash
        TextBox_TimeOut_Firmware_Mant.Text = Timeout_Firmware
        Chk_Print_Boot.Checked = Print_Bootloader
        Chk_Print_Firm.Checked = Print_Firmware
        Chk_Print_Flash.Checked = Print_Flash
        Button4.Enabled = True
        Button_Prog_Firm_Mant.Enabled = True
        Button14.Enabled = True
        If IsNumeric(TextBox_Flash_Mant.Text) = False Then
            Button_Prog_Flash_Mant.Enabled = False
        Else
            Button_Prog_Flash_Mant.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        isInit_sesion = False
        LeerUsuarios(ComboBox2.SelectedItem)
        TextBox5.Text = Contraseña_Usuario
        TextBox6.Text = Nivel_Usuario
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Write_New_User(ComboBox2.Text, TextBox5.Text, TextBox6.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Up_User(ComboBox2.SelectedItem, TextBox5.Text, TextBox6.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            Delete_User(ComboBox2.SelectedItem)
            TextBox5.Text = ""
            TextBox6.Text = ""
            ComboBox2.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Prog_Flash_Mant.Click
        Dim check_flash As Boolean = False
        Button_Prog_Flash_Mant.BackColor = System.Drawing.SystemColors.Control
        Me.Refresh()
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)
        'Timer1.Stop()
        '  Timer1.Start()
        tiempo2 = 0
        If Modelo = "118-4294" Or Modelo = "118-0582" Then
            check_flash = Programar_Flash_0582_4294()

        Else
            check_flash = Programar_Flash()
        End If

        If check_flash = True Then
            Button_Prog_Flash_Mant.BackColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
            Timer1.Stop()
            tiempo2 = 0
        Else
            Button_Prog_Flash_Mant.BackColor = Color.Red
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
            Timer1.Stop()
            tiempo2 = 0
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Prog_Firm_Mant.Click
        Dim check_firmware As Boolean = False
        Button_Prog_Firm_Mant.BackColor = System.Drawing.SystemColors.Control
        Me.Refresh()
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)
        Timer1.Stop()
        Timer1.Start()
        tiempo2 = 0
        If Modelo = "118-4294" Or Modelo = "118-0582" Then
            check_firmware = Programar_Firmware_0582_4294((USB - 1))

        ElseIf Modelo = "118-3378" Or Modelo = "118-2919" Then
            check_firmware = Programar_Firmware_118_3378((USB - 1))

        Else
            check_firmware = Programar_Firmware((USB - 1))

        End If

        If check_firmware = True Then
            Button_Prog_Firm_Mant.BackColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, TextBox_USB_Mant.Text - 1, MccDaq.DigitalLogicState.Low)
            Timer1.Stop()
            tiempo2 = 0
        Else
            Button_Prog_Firm_Mant.BackColor = Color.Red
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, TextBox_USB_Mant.Text - 1, MccDaq.DigitalLogicState.Low)
            Timer1.Stop()
            tiempo2 = 0
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox_USB_Mant.TextChanged
        If TextBox_USB_Mant.Text <> "" Then
            If (IsNumeric(TextBox_USB_Mant.Text) = True) And (TextBox_USB_Mant.Text > 0) And (TextBox_USB_Mant.Text < 11) Then
                Button_Prog_Firm_Mant.Enabled = True
            Else
                Button_Prog_Firm_Mant.Enabled = False
                MsgBox("Numero de USB Invalido")
            End If
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Guardar_Label_Lab(TextBox9.Text, TextBox10.Text, Font_Size.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            Guardar_Board_Number(TextBox7.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim qr As Image
        Dim Ancho, Largo As Integer
        Dim Str_Constructor As String

        qr = QR_Generator.Encode("XXX-XXXX_" & Today.ToString("ddMMMyyyy") & "_Rev.XX" & "_FFFF")
        Ancho = TextBox9.Text
        Largo = TextBox10.Text

        ' For i As Integer = 0 To 1
        ' i = 0 Then
        'e.Graphics.DrawImage(qr, 5, 5, Ancho, Largo)
        '  Else
        'e.Graphics.DrawString("BX.XX-FX.XX-FX.XX", New Font("Arial", 7), Brushes.Black, 10, 15)
        If Chk_Print_Boot.Checked = True Then
            Str_Constructor = Str_Constructor & "BX.XX"
        End If
        If Chk_Print_Flash.Checked = True Then
            Str_Constructor = Str_Constructor & "FX.XX"
        End If

        If Chk_Print_Firm.Checked = True Then
            Str_Constructor = Str_Constructor & "FX.XX"
        End If
        If Chk_Print_Boot.Checked = False And Chk_Print_Flash.Checked = False And Chk_Print_Firm.Checked = False Then
            Str_Constructor = "N/A"
        End If
        e.Graphics.DrawString(Str_Constructor, New Font("Arial", Font_Size.Text), Brushes.Black, Ancho, Largo)
        '   End If
        '  Next
        ' e.Graphics.DrawImage(qr, 5, 5, Ancho, Largo)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If flag = False Then
            flag = True
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)
        Else
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            flag = False
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        tiempo2 = tiempo2 + 1

    End Sub


    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        While (1)
            tiempo2 = tiempo2 + 1
            System.Threading.Thread.Sleep(100)

        End While

    End Sub
End Class