Imports System
Imports System.Threading
Imports System.IO.Ports
Public Class Form1
    Dim FormConfig As Configuracio
    Dim Conectat As Boolean = False
    Dim generat As Boolean = False
    Dim Configurat As Boolean = False
    Public BPS, BDD, BStop, PSW As Integer
    Public Parity, CFlux, PortName As String
    Dim esquerra, dreta, pujar, baixar As Boolean
    Dim temps As Integer = 0
    Dim tempsDesconectador As Integer = 0
    Dim pasword As Boolean = False
    Dim SeguimConectats As Boolean = False
    Dim contador As Integer = 0
    Dim Terreno(9, 9) As Integer    'Es la matriz que guarda el estado del terreno , es de 10x10
    Dim agvx As Integer             'Posición del AGV en el eje X e Y
    Dim agvy As Integer
    'Dim pas1, pas2, pas3, pas4 As String

    'Carga del formulario
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Inicializa_terreno()        'Inicializa el estado del terreno con todo ceros.
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Private Sub ReiniciarVariables() ' Posa les variables en l'estat inicial
        btn_Config.Enabled = True
        btn_Connect.Text = "CONECTAR"
        Conectat = False
        SeguimConectats = False
        generat = False
        Configurat = False
        Timer1.Stop()
        Timer1.Enabled = False
        pasword = False
        contador = 0
        temps = 0
        tempsDesconectador = 0
        Desconectador.Stop()
        Desconectador.Enabled = False


    End Sub


    'Esta Función verifica la proximidad de obstáculos, bloquea los botones de dirección para impedir el movimiento 
    Private Sub Comprueba_sensores()
        pujar = False
        baixar = False
        dreta = False
        esquerra = False
        If Conectat = False Then
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
        Else
            'sensor izquierda
            If agvx = 0 Then
                esquerra = False
            ElseIf Terreno(agvx - 1, agvy) = 0 Then
                esquerra = False
            Else
                esquerra = True

            End If
            'sensor derecha
            If agvx = 9 Then
                dreta = False
            ElseIf Terreno(agvx + 1, agvy) = 0 Then
                dreta = False
            Else
                dreta = True
            End If
            'sensor arriba
            If agvy = 0 Then
                pujar = False
            ElseIf Terreno(agvx, agvy - 1) = 0 Then
                pujar = False
            Else
                pujar = True
            End If
            'sensor abajo
            If agvy = 9 Then
                baixar = False
            ElseIf Terreno(agvx, agvy + 1) = 0 Then
                baixar = False
            Else
                baixar = True
            End If
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
        Dim Grid As Graphics
        Grid = PictureBox1.CreateGraphics
        Grid.Clear(Color.Gray)

        'Dibuja la rejilla de 10x10
        For idx = 1 To 9
            Grid.DrawLine(Pens.PowderBlue, idx * 40, 0, idx * 40, 400)
            Grid.DrawLine(Pens.PowderBlue, 0, idx * 40, 400, idx * 40)
        Next idx

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
                    Grid.FillPolygon(Brushes.DarkRed, caja)
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
                    Grid.FillPolygon(Brushes.Azure, caja)


                End If
            Next idx
        Next idy

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
            ButtonS.Visible = False
            ButtonB.Visible = False
            ButtonD.Visible = False
            ButtonI.Visible = False
            lbl_Informacio.Text = "Conectando..."
            lbl_Informacio.Visible = True
            Timer1.Enabled = True
            Timer1.Start()
            btn_Config.Enabled = False
        End If
    End Sub
    'Botón que genera el area de trabajo
    Private Sub GenerarTerreno()

        'Esta función se activa al pulsar 'GENERAR NUEVO TERRENO'
        Dim punterox, punteroy As Integer

        'Inicializa la matriz de terreno
        Inicializa_terreno()

        'Utiliza un algorismo de Excavación para perforar n espacios

        'Escoge el punto de inicio aleatoriamente
        Randomize()
        punterox = Int((Rnd() * 10))
        punteroy = Int((Rnd() * 10))

        Terreno(punterox, punteroy) = 1 'Le asigan el valor 1 (punto hueco)

        For n = 0 To 150 'Número de excavaciones

            'En este select sale la dirección de excavación aleatoriamente en cada iteración (ARRIBA, ABAJO, IZQUIERA O DERECHA)
            Select Case Int((Rnd() * 4))
                Case 0 'arriba'
                    If punteroy > 0 Then 'Solo subo si no estoy arriba del todo, si no puedo subir se descuenta la iteración
                        punteroy = punteroy - 1
                    Else
                        n = n - 1
                    End If
                Case 1 'abajo'
                    If punteroy < 9 Then 'Solo bajo si no estoy abajo del todo, si no puedo bajar se descuenta la iteración
                        punteroy = punteroy + 1
                    Else
                        n = n - 1
                    End If
                Case 2 'izquierda'
                    If punterox > 0 Then 'Solo me muevo si no estoy a la izquierda de todo, si no, se descuenta la iteración
                        punterox = punterox - 1
                    Else
                        n = n - 1
                    End If
                Case 3 'derecha' 
                    If punterox < 9 Then 'Solo me muevo si no estoy a la derecha de todo, si no, se descuenta la iteración
                        punterox = punterox + 1
                    Else
                        n = n - 1
                    End If
            End Select
            Terreno(punterox, punteroy) = 1 ' Vacía la nueva ubicación
        Next n
        Terreno(punterox, punteroy) = 2 'En el último hueco ubicamos el AGV (2)
        agvx = punterox 'Guardo la cordenada X e Y del AGV
        agvy = punteroy
        Redibuja_terreno() 'Actualizamos con los nuevos cambios
        Comprueba_sensores() 'Verifico el estado de los sensores por si estoy junto a un ostáculo o el borde.
        generat = True
        enviarEstatSensors()

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        GenerarTerreno()
    End Sub
    Private Sub enviarEstatSensors()
        ' estat 0 ->boto en vermell
        ' estat 1 -> botó habilitat
        ' estat 2 -> botó desabilitat (no s'ha generat terreny)
        Dim estat As String = "" ' variable que s'enviará per a indicar al remot quin es l'estat dels botons aniran amb l'ordre de : Pujar, Dreta, Baixar, Esquerra
        If Conectat = True Then
            SeguimConectats = True
            If generat = True Then ' si hem generat terreny
                If PuedoMovermeA("S") Then
                    estat = estat + "1"
                Else
                    estat = estat + "0"
                End If
                If PuedoMovermeA("D") Then
                    estat = estat + "1"
                Else
                    estat = estat + "0"
                End If
                If PuedoMovermeA("B") Then
                    estat = estat + "1"
                Else
                    estat = estat + "0"
                End If
                If PuedoMovermeA("I") Then
                    estat = estat + "1"
                Else
                    estat = estat + "0"
                End If
                SerialPort1.WriteLine(estat)
            Else
                SerialPort1.WriteLine("2222") ' si no estem conectats enviem l'estat 2 a tots els botons (inabilitat)
            End If
        End If
    End Sub
    Private Sub subir() ' Acció de pujar en cas de ser posible

        If PuedoMovermeA("S") Then
            Terreno(agvx, agvy) = 1
            agvy = agvy - 1
            Terreno(agvx, agvy) = 2
            Redibuja_terreno()
            Comprueba_sensores()
        End If

    End Sub
    'Subir
    Private Sub ButtonS_Click(sender As System.Object, e As System.EventArgs) Handles ButtonS.Click
        subir()
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación


    End Sub
    Private Sub derecha() ' Acció de anar a la dreta en cas de ser posible

        If PuedoMovermeA("D") Then
            Terreno(agvx, agvy) = 1
            agvx = agvx + 1
            Terreno(agvx, agvy) = 2
            Redibuja_terreno()
            Comprueba_sensores()
        End If


    End Sub
    'Derecha
    Private Sub ButtonD_Click(sender As System.Object, e As System.EventArgs) Handles ButtonD.Click
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación     
        derecha()
    End Sub
    Private Sub bajar() ' Acció de baixar en cas de ser posible
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación     

        If PuedoMovermeA("B") Then
            Terreno(agvx, agvy) = 1
            agvy = agvy + 1
            Terreno(agvx, agvy) = 2
            Redibuja_terreno()
            Comprueba_sensores()
        End If

    End Sub

    'Bajar
    Private Sub ButtonB_Click(sender As System.Object, e As System.EventArgs) Handles ButtonB.Click
        bajar()

    End Sub
    Private Sub izquierda() ' Acció de anar a l'esquerra en cas de ser posible

        If PuedoMovermeA("I") Then
            Terreno(agvx, agvy) = 1
            agvx = agvx - 1
            Terreno(agvx, agvy) = 2
            Redibuja_terreno()
            Comprueba_sensores()
        End If
    End Sub
    'Izquierda
    Private Sub ButtonI_Click(sender As System.Object, e As System.EventArgs) Handles ButtonI.Click
        'Esta es una de las cuatro funciones de movimiento, 
        'si el movimiento es posible, actualiza la posición del AGV i redibuja la nueva situación      
        izquierda()
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
        'obre el form de configuració
        Dim config As New Configuracio
        config.ShowDialog()
        Configurat = True
        'SerialPort1.BaudRate = FormConfig.BPS
    End Sub

    Private Sub btn_LocRem_Click(sender As System.Object, e As System.EventArgs) Handles btn_Connect.Click

        Try

            If Not SerialPort1.IsOpen() Then ' si estem conectats
                If Configurat = True Then 'si s'ha fet la configuració
                    Conectar()
                Else
                    Dim config As New Configuracio ' si no s'ha fet la configuració forcem a l'usuari a fer-la
                    config.ShowDialog()
                    Configurat = True
                    Conectar()
                End If
                Panel1.Visible = False
                lbl_Informacio.Visible = True
                btn_Connect.Text = "DESCONECTAR"
                Desconectador.Start()
                Desconectador.Enabled = True
            Else 'tanquem i posem totes les variables i objectes en estat de desconexió
                SerialPort1.WriteLine("9")
                btn_Connect.Text = "CONECTAR"
                Timer1.Stop()
                Timer1.Enabled = False
                ReiniciarVariables()
                SerialPort1.Close()
                btn_Config.Enabled = True
                lbl_Informacio.Visible = False
                Panel1.Visible = True
                ButtonS.Visible = True
                ButtonB.Visible = True
                ButtonD.Visible = True
                ButtonI.Visible = True

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ReiniciarVariables()
            SerialPort1.Close()
        Finally
            'If com1 IsNot Nothing Then com1.Close()

        End Try
    End Sub

    Public Sub SerialPort1_DataReceived(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived


        If SerialPort1.IsOpen Then
            tempsDesconectador = 0 'reiniciem la variable a 0 per evitar que ens desconecti pensant que no hi ha comunicació
            Dim dada As String ' dada que rebem
            Try
                dada = SerialPort1.ReadLine()
                If Conectat = False Then ' si encara no s'ha establert la conexió degudament
                    If pasword = False Then ' si encara no hem rebut la contrasenya correcta

                        If dada = "1" Then ' si es un 1 senyal que ens ha respost la comunicació que hem establert amb el Timer1
                            Timer1.Start()
                            Timer1.Enabled = True
                            SerialPort1.WriteLine("C") 'demanem la contrasenya enviant-li una C
                            pasword = True
                        End If
                    Else
                        If PSW = CInt(dada) Then ' Comparem el pasword
                            Conectat = True
                            lbl_Informacio.Text = "Esta conectado"
                            If generat = False Then
                                SerialPort1.WriteLine("2222")
                            Else
                                enviarEstatSensors()
                            End If
                        Else
                            lbl_Informacio.Text = "Error Contraseña"
                            btn_Connect.Text = "CONECTAR"
                            btn_Config.Enabled = True
                            ReiniciarVariables()
                            Conectat = False
                            SerialPort1.Close()
                        End If

                    End If

                Else
                    Select Case dada 'si estem conectats pot 
                        Case "OK"
                            SeguimConectats = True
                        Case "S" 'Ens demana pujar
                            subir()
                            enviarEstatSensors()
                            SeguimConectats = True
                        Case "B" 'Ens demana baixar
                            bajar()
                            enviarEstatSensors()
                            SeguimConectats = True
                        Case "D" 'Ens demana anar a la dreta
                            derecha()
                            enviarEstatSensors()
                            SeguimConectats = True
                        Case "I" 'Ens demana la esquerra
                            izquierda()
                            enviarEstatSensors()
                            SeguimConectats = True
                        Case "9" 'ens indica que es desconecta
                            lbl_Informacio.Text = "Desconectat"
                            SerialPort1.Close()
                            btn_Connect.Text = "CONECTAR"
                            Conectat = False
                            pasword = False
                        Case "G" 'Ens indica que volen generar terreny
                            GenerarTerreno()
                            enviarEstatSensors()
                            SeguimConectats = True
                        Case Else
                            lbl_Informacio.Text = "Error de conexió"
                            SerialPort1.Close()
                            btn_Connect.Text = "CONECTAR"
                            Conectat = False
                    End Select
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                ReiniciarVariables()
                SerialPort1.Close()
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Not (SerialPort1.IsOpen) Then
            SerialPort1.Open()
        End If
        If Conectat = False Then
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
            SerialPort1.WriteLine("1") 'Enviem constantment un 1 per saber si ja s'ha conectat
            temps = temps + 1
        Else
            enviarEstatSensors() 'si ja estem conectats el comprobador per saber que es manté la conexió es enviar l'estat dels sensors i ens retornara un OK

        End If

    End Sub

    Protected Overrides Sub Finalize()
        SerialPort1.Close()
        MyBase.Finalize()

    End Sub

    Private Sub Desconectador_Tick(sender As System.Object, e As System.EventArgs) Handles Desconectador.Tick
        tempsDesconectador = tempsDesconectador + 1 ' cada 250ms es puja un valor
        If tempsDesconectador = 20 Then 'si s'arriba a 20 (5s) senyal que s'ha perdut la conexió i desconectem indicant-ho degudament
            ReiniciarVariables()
            SerialPort1.Close()
            lbl_Informacio.Text = "L'altre usuari s'ha desconectat inesperadament"
        End If

    End Sub
End Class
