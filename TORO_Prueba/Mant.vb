Public Class Mant
    Dim QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Dim flag As Boolean = False


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
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
        confirm_Boot = (Programar_Boot(Pathfm, pathcomando))
        If confirm_Boot = True Then
            Button4.BackColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)

        Else
            Button4.BackColor = Color.Red
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)



        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Delete_Modelo(ComboBox1.SelectedItem)
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox8.Text = ""
            ComboBox1.Text = ""
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Up(ComboBox1.SelectedItem, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox8.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Write_New_Modelo(ComboBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox8.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Mant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Dim Init, Reset As Boolean
        LeerConfigDIO()
        TextBox7.Text = Board_Num
        TextBox9.Text = Etiqueta_Ancho
        TextBox10.Text = Etiqueta_Largo

        LeerConfigDIO()

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
        '  Init = DIO_Ini()
        'If Init = False Then
        '    MsgBox("Error al Iniciar DIO")
        '    End
        'End If
        'Reset = Reset_Dio()
        'If Reset = False Then
        '    MsgBox("Error al Resetear DIO")
        '    End
        'End If

        'Fill_CB_Modelos_Mant()
        'Fill_CB_Usuarios_Mant()
        Fill_CB_Mant(ComboBox1, "Modelo", "Config")
        Fill_CB_Mant(ComboBox2, "Nombre", "Usuarios")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        LeerConfig(ComboBox1.SelectedItem)
        TextBox2.Text = Bootloader
        TextBox3.Text = Flash
        TextBox4.Text = Firmware
        TextBox1.Text = USB
        TextBox8.Text = Revision
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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim check_flash As Boolean = False
        Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Refresh()
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)
        check_flash = Programar_Flash()
        If check_flash = True Then
            Button6.BackColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
        Else
            Button6.BackColor = Color.Red
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, PIN_Flash1, MccDaq.DigitalLogicState.Low)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim check_firmware As Boolean = False
        Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Refresh()
        Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.High)
        check_firmware = Programar_Firmware((TextBox1.Text - 1))
        If check_firmware = True Then
            Button7.BackColor = Color.Green
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, TextBox1.Text - 1, MccDaq.DigitalLogicState.Low)
        Else
            Button7.BackColor = Color.Red
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, 11, MccDaq.DigitalLogicState.Low)
            Out_toggle(MccDaq.DigitalPortType.FirstPortA, TextBox1.Text - 1, MccDaq.DigitalLogicState.Low)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then


            If (IsNumeric(TextBox1.Text) = True) And (TextBox1.Text > 0) And (TextBox1.Text < 11) Then
                Button7.Enabled = True
            Else
                Button7.Enabled = False
                MsgBox("Numero de USB Invalido")
            End If
        End If
    End Sub

    


    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Guardar_Label_Lab(TextBox9.Text, TextBox10.Text)
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
        qr = QR_Generator.Encode("XXX-XXXX_" & Today.ToString("ddMMMyyyy") & "_Rev.XX" & "_FFFF")
        Ancho = TextBox9.Text
        Largo = TextBox10.Text

        For i As Integer = 0 To 1
            If i = 0 Then
                e.Graphics.DrawImage(qr, 5, 5, Ancho, Largo)
            Else

                e.Graphics.DrawString("XXX-XXXX" & vbCrLf & "FFFF", New Font("Arial", 12), Brushes.Black, 5 + Ancho, 5 + 5)
            End If

        Next
        '   e.Graphics.DrawImage(qr, 5, 5, Ancho, Largo)

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            PrintDocument1.Print()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try


    End Sub

    Private Sub GroupBox4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox4.Enter

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
End Class