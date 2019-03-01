Imports System
Imports System.Threading
Imports System.IO.Ports
Public Class Form1
    Dim FormConfig As Configuracio
    Dim Conectat As Boolean = False 'Variable que indica si estem conectat amb l'altre programa
    Dim Configurat As Boolean = False
    Dim pasword As Boolean = False
    Dim SeguimConectats As Boolean = False
    Public BPS, BDD, BStop, PSW As Integer
    Public Parity, CFlux, PortName As String

    Dim Terreno(9, 9) As Integer    'Es la matriz que guarda el estado del terreno , es de 10x10
    Dim agvx As Integer             'Posición del AGV en el eje X e Y
    Dim agvy As Integer
    Dim temps As Integer = 0
    Dim tempsDesconectador As Integer = 0
    Dim contador As Integer = 0
    'Carga del formulario
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Inicializa_terreno()        'Inicializa el estado del terreno con todo ceros.
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub ReiniciarVariable() ' Posa les variables en l'estat inicial
        Conectat = False
        Configurat = False
        pasword = False
        contador = 0
        temps = 0
        SeguimConectats = False
        Timer1.Stop()
        Timer1.Enabled = False
        tempsDesconectador = 0
        btn_Connect.Text = "CONECTAR"

    End Sub

    'Esta Función verifica la proximidad de obstáculos, bloquea los botones de dirección para impedir el movimiento 
    Private Sub Comprueba_sensores()

        'sensor izquierda
        If agvx = 0 Then
            ButtonI.FlatStyle = FlatStyle.Standard
            ButtonI.BackColor = Color.Red
        ElseIf Terreno(agvx - 1, agvy) = 0 Then
            ButtonI.FlatStyle = FlatStyle.Standard
            ButtonI.BackColor = Color.Red
        Else
            ButtonI.FlatStyle = FlatStyle.System
            ButtonI.BackColor = SystemColors.Control

        End If
        'sensor derecha
        If agvx = 9 Then
            ButtonD.FlatStyle = FlatStyle.Standard
            ButtonD.BackColor = Color.Red
        ElseIf Terreno(agvx + 1, agvy) = 0 Then
            ButtonD.FlatStyle = FlatStyle.Standard
            ButtonD.BackColor = Color.Red
        Else
            ButtonD.FlatStyle = FlatStyle.System
            ButtonD.BackColor = SystemColors.Control
        End If
        'sensor arriba
        If agvy = 0 Then
            ButtonS.FlatStyle = FlatStyle.Standard
            ButtonS.BackColor = Color.Red
        ElseIf Terreno(agvx, agvy - 1) = 0 Then
            ButtonS.FlatStyle = FlatStyle.Standard
            ButtonS.BackColor = Color.Red
        Else
            ButtonS.FlatStyle = FlatStyle.System
            ButtonS.BackColor = SystemColors.Control
        End If
        'sensor abajo
        If agvy = 9 Then
            ButtonB.FlatStyle = FlatStyle.Standard
            ButtonB.BackColor = Color.Red
        ElseIf Terreno(agvx, agvy + 1) = 0 Then
            ButtonB.FlatStyle = FlatStyle.Standard
            ButtonB.BackColor = Color.Red
        Else
            ButtonB.FlatStyle = FlatStyle.System
            ButtonB.BackColor = SystemColors.Control
        End If

    End Sub


    'Este bucle recorre la matriz de 10x10 y la llena de 0
    Private Sub Inicializa_terreno()

        For idy = 0 To 9
            For idx = 0 To 9
                Terreno(idx, idy) = 0
            Next idx
        Next idy
    End Sub


    'Esta función lee la matriz de terreno y dibuja su represtentación en el PictureBox
    Private Sub Redibuja_terreno()

        'Inicializa el area de trabajo
        Dim p1, p2, p3, p4 As Point
        'Dim Grid As Graphics
        'Grid = PictureBox1.CreateGraphics
        'Grid.Clear(Color.Gray)

        'Dibuja la rejilla de 10x10
        'For idx = 1 To 9
        'Grid.DrawLine(Pens.PowderBlue, idx * 40, 0, idx * 40, 400)
        'Grid.DrawLine(Pens.PowderBlue, 0, idx * 40, 400, idx * 40)
        ' Next idx

        'Escanea la matriz del terreno y pone una caja roja en cada casilla marcada como 0 y una caja blanca en la que está marcada con un 2
        For idy = 0 To 9
            For idx = 0 To 9
                If Terreno(idx, idy) = 0 Then
                    p1.X = (idx * 40) + 5
                    p1.Y = (idy * 40) + 5
                    p2.X = (idx * 40) + 35
                    p2.Y = (idy * 40) + 5
                    p3.X = (idx * 40) + 35
                    p3.Y = (idy * 40) + 35
                    p4.X = (idx * 40) + 5
                    p4.Y = (idy * 40) + 35
                    Dim caja As Point() = {p1, p2, p3, p4}
                    'Grid.FillPolygon(Brushes.DarkRed, caja)
                ElseIf Terreno(idx, idy) = 2 Then
                    p1.X = (idx * 40) + 5
                    p1.Y = (idy * 40) + 5
                    p2.X = (idx * 40) + 35
                    p2.Y = (idy * 40) + 5
                    p3.X = (idx * 40) + 35
                    p3.Y = (idy * 40) + 35
                    p4.X = (idx * 40) + 5
                    p4.Y = (idy * 40) + 35
                    Dim caja As Point() = {p1, p2, p3, p4}
                    'Grid.FillPolygon(Brushes.Azure, caja)


                End If
            Next idx
        Next idy

    End Sub
    

    'Botón que genera el area de trabajo
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If Conectat = True And SerialPort1.IsOpen Then
            SerialPort1.WriteLine("G")
        End If
    End Sub

    'Subir
    Private Sub ButtonS_Click(sender As System.Object, e As System.EventArgs) Handles ButtonS.Click
        If Conectat = True Then
            'If PuedoMovermeA("S") Then
            SerialPort1.WriteLine("S")
            'End If
        End If
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación


    End Sub

    'Derecha
    Private Sub ButtonD_Click(sender As System.Object, e As System.EventArgs) Handles ButtonD.Click
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación     
        If Conectat = True Then
            'If PuedoMovermeA("D") Then
            SerialPort1.WriteLine("D")
            'End If
        End If

    End Sub

    'Bajar
    Private Sub ButtonB_Click(sender As System.Object, e As System.EventArgs) Handles ButtonB.Click
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación     
        If Conectat = True Then
            'If PuedoMovermeA("B") Then
            SerialPort1.WriteLine("B")
            'End If
        End If

    End Sub

    'Izquierda
    Private Sub ButtonI_Click(sender As System.Object, e As System.EventArgs) Handles ButtonI.Click
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación      
        If Conectat = True Then
            'If PuedoMovermeA("I") Then
            SerialPort1.WriteLine("I")
            'End If
        End If

    End Sub

    'Esta función verifica si el movimento que se quiere hacer está permitido (retorna True si se puede mover y False si no)
    'La notación es     'I'--> Izquierda
    '                   'D'--> Derecha
    '                   'S'--> Subir
    '                   'B'--> Bajar
    Private Function PuedoMovermeA(direccion As String) As Boolean
        Dim puedo As Boolean
        puedo = False


        Select Case direccion
            Case "I"
                'sensor izquierda
                If agvx = 0 Then
                    puedo = False
                ElseIf Terreno(agvx - 1, agvy) = 0 Then
                    puedo = False
                Else
                    puedo = True
                End If
            Case "D"
                'sensor derecha
                If agvx = 9 Then
                    puedo = False
                ElseIf Terreno(agvx + 1, agvy) = 0 Then
                    puedo = False
                Else
                    puedo = True
                End If
            Case "S"
                'sensor arriba
                If agvy = 0 Then
                    puedo = False
                ElseIf Terreno(agvx, agvy - 1) = 0 Then
                    puedo = False
                Else
                    puedo = True
                End If
            Case "B"
                'sensor abajo
                If agvy = 9 Then
                    puedo = False
                ElseIf Terreno(agvx, agvy + 1) = 0 Then
                    puedo = False
                Else
                    puedo = True
                End If
            Case Else
                puedo = False
        End Select

        PuedoMovermeA = puedo

    End Function


    Private Sub btn_Config_Click(sender As System.Object, e As System.EventArgs) Handles btn_Config.Click
        Dim config As New Configuracio
        config.ShowDialog()
        Configurat = True
        'SerialPort1.BaudRate = FormConfig.BPS
    End Sub
    Sub sendSerialData(ByVal data As String) 'envia les dades que es necessitin fent servir la variable data
        Using com1 As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort("COM1")
            com1.WriteLine(data)
        End Using
    End Sub
    Private Sub Conectar()
        'pasem totes les dades agafades al form de configuració al form1
        SerialPort1.BaudRate = BPS
        SerialPort1.DataBits = BDD
        SerialPort1.Parity = Parity
        SerialPort1.StopBits = BStop
        SerialPort1.Handshake = CFlux
        SerialPort1.PortName = PortName

        If Conectat = False Then 'preparem tot per a fer la conexió
            SerialPort1.Open()
            Timer1.Start()
            ButtonS.Visible = False
            ButtonB.Visible = False
            ButtonD.Visible = False
            ButtonI.Visible = False
            lbl_Informacio.Text = "Conectando..."
            lbl_Informacio.Visible = True
            btn_Config.Enabled = False
        End If
    End Sub
    Private Sub btn_LocRem_Click(sender As System.Object, e As System.EventArgs) Handles btn_Connect.Click
     
        Try

            If Not SerialPort1.IsOpen() Then
                If Configurat = True Then ' si ja s'ha configurat previament pel boto configurar
                    Conectar() ' Cridem la funció que conecta
                    Conectat = False
                Else
                    Dim config As New Configuracio ' obrim la configuració, ja que es necessaria
                    config.ShowDialog()
                    Configurat = True
                    Conectar()
                    Conectat = False
                End If
                Timer1.Start() ' comença a contar el timer que ens desconectara en cas de que es talli la conexió
                Panel1.Visible = False ' imposibilitem que l'usuari interactui amb el panell
                lbl_Informacio.Visible = True
                btn_Connect.Text = "DESCONECTAR"
            Else
                SerialPort1.WriteLine("9") ' el 9 sempre es fa servir per comunicar desconexió
                SerialPort1.Close()
                ReiniciarVariable()

                btn_Connect.Text = "CONECTAR"
                lbl_Informacio.Text = "Desconectado"
                Timer1.Stop()
                btn_Config.Enabled = True
                Panel1.Visible = True
                ButtonS.Visible = True
                ButtonB.Visible = True
                ButtonD.Visible = True
                ButtonI.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SerialPort1.Close()
            ReiniciarVariable()

        Finally
            'If com1 IsNot Nothing Then com1.Close()

        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'Dim numero As String
        Try
            SeguimConectats = True
            tempsDesconectador = 0
            If SerialPort1.IsOpen Then
                Dim dada As String
                dada = CStr(SerialPort1.ReadLine())
                'dada = Chr(dada)
                If pasword = False Then
                    Select Case dada
                        Case "1" 'comprobador de que hi ha conexió, responem amb un 1
                            SerialPort1.WriteLine("1")
                        Case "C" ' rep una C solicitant la contrasenya
                            SerialPort1.WriteLine(CStr(PSW)) 'enviem contrasenya
                            pasword = True
                        Case "9" ' enviem 9 per indicar desconexió
                            SerialPort1.Close()
                            lbl_Informacio.Text = "Contrasenña erronea."
                            Conectat = False
                            pasword = False

                        Case Else
                            SerialPort1.Close()

                    End Select
                Else
                    Dim botons As Boolean = False 'variable que ens indica si la comunicació es per indicar l'estat dels botons(per tant te una longitud de 4 caracters) o si es per a una desconexió
                    Panel1.Visible = True  'habilitem tots els botons i el panell
                    ButtonS.Visible = True
                    ButtonD.Visible = True
                    ButtonB.Visible = True
                    ButtonI.Visible = True
                    Select Case dada(0) 'la dada amb l'estat dels botons s'envia en forma de string de 4 caracters (Pujar,Dreta,Baixar,Esquerra)
                        'els valors poden ser:
                        '   - 0->botó en vermell
                        '   - 1->botó en color gris
                        '   - 2->botó en desabilitat (no s'ha generat l'array)
                        Case "0" 'botó de pujar
                            ButtonS.Enabled = True
                            ButtonS.BackColor = Color.Red
                            botons = True
                        Case "1"
                            ButtonS.Enabled = True
                            ButtonS.BackColor = Color.Gainsboro
                            botons = True
                        Case "2"

                            ButtonS.BackColor = Color.Transparent
                            ButtonS.Enabled = False
                            botons = True
                        Case "9" 'si s'envia un 9 es desconecta per tant no seguim llegint
                            botons = False
                            SerialPort1.Close()
                            lbl_Informacio.Text = "Desconectat"
                            Conectat = False
                            pasword = False
                            btn_Connect.Text = "DESCONECTAR"
                            ReiniciarVariable()
                        Case Else
                            btn_Connect.Text = "CONECTAR"
                            lbl_Informacio.Text = "Desconectat"
                            ReiniciarVariable()
                            SerialPort1.Close()
                    End Select
                    If botons = True Then 'seguim llegint 


                        Select Case dada(1) 'botó de anar a la dreta
                            Case "0"
                                ButtonD.Enabled = True
                                ButtonD.BackColor = Color.Red
                            Case "1"
                                ButtonD.Enabled = True
                                ButtonD.BackColor = Color.Gainsboro
                            Case "2"

                                ButtonD.BackColor = Color.Transparent
                                ButtonD.Enabled = False

                            Case Else
                                btn_Connect.Text = "DESCONECTAR"
                                ReiniciarVariable()

                        End Select
                        Select Case dada(2) 'boto de baixar
                            Case "0"
                                ButtonB.Enabled = True
                                ButtonB.BackColor = Color.Red
                            Case "1"
                                ButtonB.Enabled = True
                                ButtonB.BackColor = Color.Gainsboro
                            Case "2"

                                ButtonB.BackColor = Color.Transparent
                                ButtonB.Enabled = False

                            Case Else
                                btn_Connect.Text = "DESCONECTAR"
                                ReiniciarVariable()

                        End Select
                        Select Case dada(3) ' botó d'anar a l'esquerra
                            Case "0"
                                ButtonI.Enabled = True
                                ButtonI.BackColor = Color.Red
                                SeguimConectats = True
                            Case "1"
                                ButtonI.Enabled = True
                                ButtonI.BackColor = Color.Gainsboro
                                SeguimConectats = True
                            Case "2"

                                ButtonI.BackColor = Color.Transparent
                                ButtonI.Enabled = False
                                SeguimConectats = True
                            Case Else
                                btn_Connect.Text = "DESCONECTAR"
                                ReiniciarVariable()

                        End Select

                    End If

                    SerialPort1.WriteLine("OK")
                    Conectat = True
                    lbl_Informacio.Text = "Conectado"
                    SeguimConectats = True

                End If


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SerialPort1.Close()
            ReiniciarVariable()

        End Try

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim temps As Integer = 0
        If Not SerialPort1.IsOpen Then
            SerialPort1.Open()
        End If
        If Conectat = False Then ' si no estem conectats ens variarà l'estat del label informació
            Select Case temps
                Case Is = 1
                    lbl_Informacio.Text = "Conectando"

                Case Is = 2
                    lbl_Informacio.Text = "Conectando."

                Case Is = 3
                    lbl_Informacio.Text = "Conectando.."

                Case Else
                    lbl_Informacio.Text = "Conectando..."
                    temps = 0
            End Select
            temps = temps + 1
        Else
            tempsDesconectador = tempsDesconectador + 1 ' quan estem conectats fem servir aquesta variable per saber si s'ha trencat la conexió
            If tempsDesconectador = 20 Then 'si la variable arriba a 20 (5 segons) es senyal de que no hi ha conexió amb l'altre programa i desconectem i ho indiquem degudament
                ReiniciarVariable()
                SerialPort1.Close()
                lbl_Informacio.Text = "L'altre Usuaria S'ha desconectat"
            End If

        End If


    End Sub
End Class
