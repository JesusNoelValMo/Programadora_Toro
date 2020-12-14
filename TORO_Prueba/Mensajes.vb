Module Mensajes
    Public Function RichMsgOK(ByVal msg As Integer)
        If msg = 1 Then
            Produccion.RichTextBox1.AppendText("Iniciando Programacion de Bootloader..." & vbCrLf)

        ElseIf msg = 2 Then
            Produccion.RichTextBox1.AppendText("Iniciando Programacion de Flash..." & vbCrLf)
        ElseIf msg = 3 Then
            Produccion.RichTextBox1.AppendText("Iniciando Programacion de Firmware..." & vbCrLf)
        ElseIf msg = 4 Then
            Produccion.RichTextBox1.AppendText("Programacion Finalizada..." & vbCrLf)
        ElseIf msg = 5 Then


        End If
    End Function
    Public Function RichMsgError(ByVal msg As Integer)
        If msg = 1 Then
            Produccion.RichTextBox1.AppendText("Modelo No Encontrado." & vbCrLf)
        ElseIf msg = 2 Then
            Produccion.RichTextBox1.AppendText("Error al Programar Bootloader" & vbCrLf)
        ElseIf msg = 3 Then
            Produccion.RichTextBox1.AppendText("Error al Programar Flash" & vbCrLf)
        ElseIf msg = 4 Then
            Produccion.RichTextBox1.AppendText("Error al Programar Firmware" & vbCrLf)
        ElseIf msg = 5 Then


        End If

    End Function

    Public Function RichMsgError_flash(ByVal msg As Integer)
        If msg = 1 Then
            Produccion.RichTextBox1.AppendText("Pieza mala, error en el indicador DS8" & vbCrLf)
        ElseIf msg = 2 Then
            Produccion.RichTextBox1.AppendText("Pieza mala, error en el indicador TX" & vbCrLf)
        ElseIf msg = 3 Then
            Produccion.RichTextBox1.AppendText("Time Out Error" & vbCrLf)
        ElseIf msg = 4 Then

        ElseIf msg = 5 Then


        End If

    End Function
End Module
