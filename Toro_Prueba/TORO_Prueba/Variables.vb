Module Variables
    Public Modelo As String
    Public Bootloader As String
    Public Flash As String
    Public Firmware As String
    Public Nombre_Usuario As String
    Public Nivel_Usuario As Integer
    Public Contraseña_Usuario As String
    Public Sigue As Boolean
    Public USB As String
    Public LastSerie As Integer
    Public Revision As String


    Public PIN_Flash1 As Integer = 10
    ' Public PIN_Flash2 As Integer = 46
    Public PIN_24Volts As Integer = 45

    Public PIN_Switch_Reset As Integer = 13 'En diagrama S2
    Public PIN_Switch2 As Integer = 12 ' en diagrama S3



    Public PIN_LED_Flash2 As Integer = 49 ' TX
    Public PIN_LED_Flash1 As Integer = 48 'Hst LED (IZQ)
    Public PIN_LED_FIRMWARE As Integer = 52 'Diagnostic
    Public PIN_BOCINA As Integer = 53 'BOCINA


    Public tiempo2 As Integer = 0
    Public tiempo As Integer = 0
    Public BackGroundFlag As Boolean = False

    Public Name_Modelos(50) As Array
    Public isInit_sesion As Boolean


    Public Board_Num As String
    Public Etiqueta_Info, Etiqueta_Ancho, Etiqueta_Largo As String

    Public TypeVal As String

    Public Timeout_Bootloader, Timeout_Flash, Timeout_Firmware As Integer
    Public Print_Bootloader, Print_Flash, Print_Firmware As Boolean

    Public Label_String As String
    Public Tamaño_Fuente_Print As Integer

    
End Module
