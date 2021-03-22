<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mant
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mant))
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_Firmware_Mant = New System.Windows.Forms.TextBox()
        Me.TextBox_Flash_Mant = New System.Windows.Forms.TextBox()
        Me.Textbox_Boot_Mant = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_Prog_Flash_Mant = New System.Windows.Forms.Button()
        Me.Button_Prog_Firm_Mant = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Chk_Print_Firm = New System.Windows.Forms.CheckBox()
        Me.Chk_Print_Flash = New System.Windows.Forms.CheckBox()
        Me.Chk_Print_Boot = New System.Windows.Forms.CheckBox()
        Me.TextBox_TimeOut_Firmware_Mant = New System.Windows.Forms.TextBox()
        Me.TextBox_TimeOut_Flash_Mant = New System.Windows.Forms.TextBox()
        Me.TextBox_TimeOut_Boot_mant = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox_Rev_mant = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox_USB_Mant = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Modelo_Mant = New System.Windows.Forms.ComboBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Font_Size = New System.Windows.Forms.TextBox()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(167, 693)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(149, 103)
        Me.Button4.TabIndex = 24
        Me.Button4.Text = "Bootloader"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 276)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 37)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Firmware"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 37)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Flash"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 37)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Bootloader"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 37)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Modelo"
        '
        'TextBox_Firmware_Mant
        '
        Me.TextBox_Firmware_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Firmware_Mant.Location = New System.Drawing.Point(195, 269)
        Me.TextBox_Firmware_Mant.Name = "TextBox_Firmware_Mant"
        Me.TextBox_Firmware_Mant.Size = New System.Drawing.Size(391, 44)
        Me.TextBox_Firmware_Mant.TabIndex = 18
        '
        'TextBox_Flash_Mant
        '
        Me.TextBox_Flash_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Flash_Mant.Location = New System.Drawing.Point(195, 190)
        Me.TextBox_Flash_Mant.Name = "TextBox_Flash_Mant"
        Me.TextBox_Flash_Mant.Size = New System.Drawing.Size(391, 44)
        Me.TextBox_Flash_Mant.TabIndex = 17
        '
        'Textbox_Boot_Mant
        '
        Me.Textbox_Boot_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Textbox_Boot_Mant.Location = New System.Drawing.Point(195, 110)
        Me.Textbox_Boot_Mant.Name = "Textbox_Boot_Mant"
        Me.Textbox_Boot_Mant.Size = New System.Drawing.Size(391, 44)
        Me.Textbox_Boot_Mant.TabIndex = 16
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(12, 693)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(149, 103)
        Me.Button5.TabIndex = 26
        Me.Button5.Text = "Volver"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(1128, 668)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(221, 138)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Button_Prog_Flash_Mant
        '
        Me.Button_Prog_Flash_Mant.Enabled = False
        Me.Button_Prog_Flash_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Prog_Flash_Mant.Location = New System.Drawing.Point(322, 694)
        Me.Button_Prog_Flash_Mant.Name = "Button_Prog_Flash_Mant"
        Me.Button_Prog_Flash_Mant.Size = New System.Drawing.Size(149, 103)
        Me.Button_Prog_Flash_Mant.TabIndex = 27
        Me.Button_Prog_Flash_Mant.Text = "Flash"
        Me.Button_Prog_Flash_Mant.UseVisualStyleBackColor = True
        '
        'Button_Prog_Firm_Mant
        '
        Me.Button_Prog_Firm_Mant.Enabled = False
        Me.Button_Prog_Firm_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Prog_Firm_Mant.Location = New System.Drawing.Point(477, 693)
        Me.Button_Prog_Firm_Mant.Name = "Button_Prog_Firm_Mant"
        Me.Button_Prog_Firm_Mant.Size = New System.Drawing.Size(149, 103)
        Me.Button_Prog_Firm_Mant.TabIndex = 28
        Me.Button_Prog_Firm_Mant.Text = "Firmware"
        Me.Button_Prog_Firm_Mant.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Button8)
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Controls.Add(Me.Button10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.TextBox6)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 424)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(729, 263)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Usuarios"
        Me.GroupBox2.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(204, 48)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(291, 32)
        Me.ComboBox2.TabIndex = 35
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(530, 43)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(137, 34)
        Me.Button8.TabIndex = 30
        Me.Button8.Text = "Agregar"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(530, 83)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(137, 34)
        Me.Button9.TabIndex = 29
        Me.Button9.Text = "Modificar"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(530, 123)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(137, 34)
        Me.Button10.TabIndex = 28
        Me.Button10.Text = "Borrar"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(37, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 29)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Rango"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(37, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 29)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Contraseña"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 29)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Nombre"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(204, 112)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(291, 35)
        Me.TextBox5.TabIndex = 24
        '
        'TextBox6
        '
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(204, 186)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(38, 35)
        Me.TextBox6.TabIndex = 23
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(887, 63)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(170, 78)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "Agregar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(887, 146)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(170, 78)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Modificar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Chk_Print_Firm)
        Me.GroupBox1.Controls.Add(Me.Chk_Print_Flash)
        Me.GroupBox1.Controls.Add(Me.Chk_Print_Boot)
        Me.GroupBox1.Controls.Add(Me.TextBox_TimeOut_Firmware_Mant)
        Me.GroupBox1.Controls.Add(Me.TextBox_TimeOut_Flash_Mant)
        Me.GroupBox1.Controls.Add(Me.TextBox_TimeOut_Boot_mant)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextBox_Rev_mant)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TextBox_USB_Mant)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Modelo_Mant)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Textbox_Boot_Mant)
        Me.GroupBox1.Controls.Add(Me.TextBox_Flash_Mant)
        Me.GroupBox1.Controls.Add(Me.TextBox_Firmware_Mant)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1068, 406)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modelos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(741, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 20)
        Me.Label15.TabIndex = 46
        Me.Label15.Text = "Imprimir"
        '
        'Chk_Print_Firm
        '
        Me.Chk_Print_Firm.AutoSize = True
        Me.Chk_Print_Firm.Location = New System.Drawing.Point(772, 288)
        Me.Chk_Print_Firm.Name = "Chk_Print_Firm"
        Me.Chk_Print_Firm.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Print_Firm.TabIndex = 45
        Me.Chk_Print_Firm.UseVisualStyleBackColor = True
        '
        'Chk_Print_Flash
        '
        Me.Chk_Print_Flash.AutoSize = True
        Me.Chk_Print_Flash.Location = New System.Drawing.Point(772, 203)
        Me.Chk_Print_Flash.Name = "Chk_Print_Flash"
        Me.Chk_Print_Flash.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Print_Flash.TabIndex = 44
        Me.Chk_Print_Flash.UseVisualStyleBackColor = True
        '
        'Chk_Print_Boot
        '
        Me.Chk_Print_Boot.AutoSize = True
        Me.Chk_Print_Boot.Location = New System.Drawing.Point(772, 117)
        Me.Chk_Print_Boot.Name = "Chk_Print_Boot"
        Me.Chk_Print_Boot.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Print_Boot.TabIndex = 43
        Me.Chk_Print_Boot.UseVisualStyleBackColor = True
        '
        'TextBox_TimeOut_Firmware_Mant
        '
        Me.TextBox_TimeOut_Firmware_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_TimeOut_Firmware_Mant.Location = New System.Drawing.Point(592, 269)
        Me.TextBox_TimeOut_Firmware_Mant.Name = "TextBox_TimeOut_Firmware_Mant"
        Me.TextBox_TimeOut_Firmware_Mant.Size = New System.Drawing.Size(102, 44)
        Me.TextBox_TimeOut_Firmware_Mant.TabIndex = 42
        '
        'TextBox_TimeOut_Flash_Mant
        '
        Me.TextBox_TimeOut_Flash_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_TimeOut_Flash_Mant.Location = New System.Drawing.Point(592, 190)
        Me.TextBox_TimeOut_Flash_Mant.Name = "TextBox_TimeOut_Flash_Mant"
        Me.TextBox_TimeOut_Flash_Mant.Size = New System.Drawing.Size(102, 44)
        Me.TextBox_TimeOut_Flash_Mant.TabIndex = 41
        '
        'TextBox_TimeOut_Boot_mant
        '
        Me.TextBox_TimeOut_Boot_mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_TimeOut_Boot_mant.Location = New System.Drawing.Point(592, 110)
        Me.TextBox_TimeOut_Boot_mant.Name = "TextBox_TimeOut_Boot_mant"
        Me.TextBox_TimeOut_Boot_mant.Size = New System.Drawing.Size(102, 44)
        Me.TextBox_TimeOut_Boot_mant.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(592, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 20)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "TimeOut(Seg)"
        '
        'TextBox_Rev_mant
        '
        Me.TextBox_Rev_mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_Rev_mant.Location = New System.Drawing.Point(379, 342)
        Me.TextBox_Rev_mant.Name = "TextBox_Rev_mant"
        Me.TextBox_Rev_mant.Size = New System.Drawing.Size(98, 44)
        Me.TextBox_Rev_mant.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(289, 342)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 37)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Rev."
        '
        'TextBox_USB_Mant
        '
        Me.TextBox_USB_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_USB_Mant.Location = New System.Drawing.Point(195, 342)
        Me.TextBox_USB_Mant.Name = "TextBox_USB_Mant"
        Me.TextBox_USB_Mant.Size = New System.Drawing.Size(47, 44)
        Me.TextBox_USB_Mant.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 342)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 37)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "USB"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(887, 230)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(170, 78)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Borrar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Modelo_Mant
        '
        Me.Modelo_Mant.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Modelo_Mant.FormattingEnabled = True
        Me.Modelo_Mant.Location = New System.Drawing.Point(195, 44)
        Me.Modelo_Mant.Name = "Modelo_Mant"
        Me.Modelo_Mant.Size = New System.Drawing.Size(391, 45)
        Me.Modelo_Mant.TabIndex = 34
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Button11.Location = New System.Drawing.Point(63, 132)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(130, 47)
        Me.Button11.TabIndex = 34
        Me.Button11.Text = "Guadar"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox7.Location = New System.Drawing.Point(80, 77)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(99, 35)
        Me.TextBox7.TabIndex = 35
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(58, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 29)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Board Num"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Button11)
        Me.GroupBox3.Controls.Add(Me.TextBox7)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(819, 439)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(261, 196)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DIO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.Font_Size)
        Me.GroupBox4.Controls.Add(Me.Button12)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.TextBox10)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Button13)
        Me.GroupBox4.Controls.Add(Me.TextBox9)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(1088, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(261, 410)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Etiqueta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 214)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 24)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Tamaño de Letra"
        '
        'Font_Size
        '
        Me.Font_Size.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Font_Size.Location = New System.Drawing.Point(6, 241)
        Me.Font_Size.Name = "Font_Size"
        Me.Font_Size.Size = New System.Drawing.Size(145, 29)
        Me.Font_Size.TabIndex = 44
        Me.Font_Size.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.Location = New System.Drawing.Point(6, 354)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(141, 47)
        Me.Button12.TabIndex = 43
        Me.Button12.Text = "Prueba"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 24)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Largo(Px)"
        '
        'TextBox10
        '
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(6, 155)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(145, 29)
        Me.TextBox10.TabIndex = 41
        Me.TextBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(109, 24)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Ancho(Px)"
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Location = New System.Drawing.Point(6, 301)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(141, 47)
        Me.Button13.TabIndex = 38
        Me.Button13.Text = "Guadar"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(6, 75)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(145, 29)
        Me.TextBox9.TabIndex = 39
        Me.TextBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PrintDocument1
        '
        '
        'Button14
        '
        Me.Button14.Enabled = False
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button14.Location = New System.Drawing.Point(632, 694)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(149, 103)
        Me.Button14.TabIndex = 40
        Me.Button14.Text = "Encendido"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'BackgroundWorker1
        '
        '
        'Mant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1361, 788)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button_Prog_Firm_Mant)
        Me.Controls.Add(Me.Button_Prog_Flash_Mant)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Mant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox_Firmware_Mant As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_Flash_Mant As System.Windows.Forms.TextBox
    Friend WithEvents Textbox_Boot_Mant As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button_Prog_Flash_Mant As System.Windows.Forms.Button
    Friend WithEvents Button_Prog_Firm_Mant As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Modelo_Mant As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox_USB_Mant As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents TextBox_Rev_mant As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TextBox_TimeOut_Firmware_Mant As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_TimeOut_Flash_Mant As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_TimeOut_Boot_mant As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Font_Size As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Chk_Print_Firm As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Print_Flash As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_Print_Boot As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
