Imports AxELABELINFOLib
Imports AxELABELOCXLib

Public Class Ini
    Dim QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Dim BarCode_Gen As New IDAutomation.NetAssembly.FontEncoder
    Dim axe As AxELABELINFOLib.AxELabelInfo

 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LeerUsuarios(TextBox1.Text)
        If Sigue = True Then
            If Contraseña_Usuario = TextBox2.Text Then
                If Nivel_Usuario > 1 Then
                    If Nivel_Usuario > 2 Then
                        Mant.GroupBox2.Enabled = True
                        Mant.GroupBox2.Visible = True
                        Mant.GroupBox3.Enabled = True
                        Mant.GroupBox3.Visible = True
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                    Else
                        Mant.GroupBox2.Enabled = False
                        Mant.GroupBox2.Visible = False
                        Mant.GroupBox3.Enabled = False
                        Mant.GroupBox3.Visible = False
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                    End If
                    Me.Hide()
                    Mant.Show()
                Else
                    MsgBox("No cuenta con permisos para elegir esta opcion")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                End If
            Else
                MsgBox("Contraseña Incorrecta")
                TextBox1.Text = ""
                TextBox2.Text = ""
            End If
        End If



    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        isInit_sesion = True

        LeerUsuarios(TextBox1.Text)
        If Sigue = True Then
            If Contraseña_Usuario = TextBox2.Text Then
                If Nivel_Usuario > 0 Then
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    Produccion.Show()
                    Me.Close()
                Else
                    MsgBox("No cuenta con permisos para elegir esta opcion")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                End If
            Else
                MsgBox("Contraseña Incorrecta")
                TextBox1.Text = ""
                TextBox2.Text = ""
            End If
        End If




    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Dim qr(2) As Image

        'Dim an, lar, Posx, Posy As Integer
        'Etiqueta_Info = Today.ToString("ddMMyyyy") & "_102-9739_" & Hex(1500)

        'qr(0) = QR_Generator.Encode(Etiqueta_Info)
        'qr(1) = QR_Generator.Encode(Etiqueta_Info)
        'an = TextBox5.Text
        'lar = TextBox6.Text
        'Posx = TextBox3.Text
        'Posy = TextBox4.Text
        'For i As Integer = 0 To 1
        '    If i = 0 Then
        '        e.Graphics.DrawImage(qr(i), Posx, Posy, an, lar)
        '    Else
        '        e.Graphics.DrawString("102-9739" & vbCrLf & "FFFF", New Font("Arial", 12), Brushes.Black, Posx + 46, Posy + 5)
        '    End If

        'Next
        Dim fileName As String
        'fileName = ("C:\Users\User\Documents\SDE_APPS\TORO_APP\Toro_Programadora\TORO_Prueba\TORO_Prueba\bin\Debug\Etiquetas\ol120.doc")
        fileName = ("C:\Users\User\Documents\SDE_APPS\TORO_APP\Toro_Programadora\TORO_Prueba\TORO_Prueba\bin\Debug\Etiquetas\ol175.qdf")
        PrintDocument1.PrinterSettings.PrintFileName = fileName
     
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintDocument1.Print()
        '  Up_Serie("102-9739", 1500)

    End Sub

    Private Sub Ini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LeerConfigDIO()

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim process As System.Diagnostics.Process = New Process()
        'Dim startInfo As New ProcessStartInfo()
        'startInfo.FileName = "C:\Users\User\Documents\SDE_APPS\TORO_APP\Toro_Programadora\TORO_Prueba\TORO_Prueba\bin\Debug\Etiquetas\ol175.qdf"
        'startInfo.Verb = "Print" 'prints to default printer
        'startInfo.UseShellExecute = True
        'startInfo.WindowStyle = ProcessWindowStyle.Hidden
        'startInfo.CreateNoWindow = True
        'process.StartInfo = startInfo
        'process.Start()
        PrintDocument1.Print()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim barco As String
        Dim barcode As KeepAutomation.Barcode.Bean.BarCode = New KeepAutomation.Barcode.Bean.BarCode
        barcode.Symbology = KeepAutomation.Barcode.Symbology.Code128Auto
        barcode.CodeToEncode = "PDF-417"
        barcode.PDF417DataMode = KeepAutomation.Barcode.PDF417DataMode.Auto
        barcode.X = 2
        barcode.Y = 5
        barcode.PDF417XtoYRatio = 0.3
        barcode.PDF417ColumnCount = 3
        barcode.PDF417ColumnCount = 5
        barcode.PDF417Truncated = False
        barcode.BarCodeWidth = 330
        barcode.BarCodeHeight = 70
        barcode.BottomMargin = 10
        barcode.LeftMargin = 10
        barcode.RightMargin = 10
        barcode.Orientation = KeepAutomation.Barcode.Orientation.Degree0
        barcode.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel
        barcode.DPI = 72
        barcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png

        barcode.generateBarcodeToImageFile("C://barcode-pdf417-vb.png")


    End Sub
End Class