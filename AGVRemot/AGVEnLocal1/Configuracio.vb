Imports System
Imports System.Threading
Imports System.IO.Ports
Public Class Configuracio
    Public BPS, BDD, BStop, PSW As Integer
    Public Parity, CFlux, PortName As String
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        CBox_BPS.SelectedIndex = 5
        CBox_BitsDD.SelectedIndex = 3
        CBox_Paritad.SelectedIndex = 0
        CBox_BitsStop.SelectedIndex = 0
        CBox_CFlujo.SelectedIndex = 0
        CBox_Nom.SelectedIndex = 0
        'CBox_Nom.SelectedIndex = 0
        CBox_Nom.Items.Clear()
        CBox_Nom.Items.AddRange(SerialPort.GetPortNames())
        CBox_Nom.SelectedIndex = 0
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub btn_Cancelar_Click(sender As System.Object, e As System.EventArgs) Handles btn_Cancelar.Click
        Me.Hide()
    End Sub

    Private Sub btn_Aceptar_Click(sender As System.Object, e As System.EventArgs) Handles btn_Aceptar.Click

        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        style = MsgBoxStyle.Critical
        title = "Falta informació"   ' Definim el titol de l'error.

        If CBox_BPS.Text <> "" Then
            If CBox_BitsDD.Text <> "" Then
                If CBox_Paritad.Text <> "" Then
                    If CBox_BitsStop.Text <> "" Then
                        If CBox_CFlujo.Text <> "" Then
                            If txtBox_Password.Text <> "" And IsNumeric(txtBox_Password.Text) And txtBox_Password.Text.Length = 4 Then

                                BPS = CInt(CBox_BPS.Text)
                                BDD = CInt(CBox_BitsDD.Text)
                                Parity = CBox_Paritad.SelectedIndex 'CStr(CBox_Paritad.Text)
                                BStop = CInt(CBox_BitsStop.Text)
                                CFlux = CBox_CFlujo.SelectedIndex 'CStr(CBox_CFlujo.Text)
                                PSW = CInt(txtBox_Password.Text)
                                PortName = CStr(CBox_Nom.Text)

                                Form1.BPS = BPS
                                Form1.BDD = BDD
                                Form1.Parity = Parity
                                Form1.BStop = BStop
                                Form1.CFlux = CFlux
                                Form1.PSW = PSW
                                Form1.PortName = PortName
                                Me.Hide()

                            Else
                                response = MsgBox("Cal introduir un password valid de 4 nombres.", style, title)
                            End If
                        Else
                            response = MsgBox("No s'ha definit el control de flux.", style, title)
                        End If
                    Else
                        response = MsgBox("No s'han definit els bits d'Stop..", style, title)
                    End If
                Else
                    response = MsgBox("No s'ha definit el bit de paritat.", style, title)
                End If
            Else
                response = MsgBox("No s'han definit els bits de dades.", style, title)
            End If
        Else
            response = MsgBox("No s'han definit els bits per segon.", style, title)
        End If

    End Sub

End Class
