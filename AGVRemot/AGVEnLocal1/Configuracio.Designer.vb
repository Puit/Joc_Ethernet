<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuracio
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
        Me.lbl_bitsPS = New System.Windows.Forms.Label()
        Me.lbl_BitsDD = New System.Windows.Forms.Label()
        Me.lbl_Paritad = New System.Windows.Forms.Label()
        Me.lbl_BitsStop = New System.Windows.Forms.Label()
        Me.lbl_CFlux = New System.Windows.Forms.Label()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.btn_Cancelar = New System.Windows.Forms.Button()
        Me.lbl_Password = New System.Windows.Forms.Label()
        Me.lbl_Nom = New System.Windows.Forms.Label()
        Me.txtBox_Password = New System.Windows.Forms.TextBox()
        Me.CBox_Nom = New System.Windows.Forms.ComboBox()
        Me.CBox_CFlujo = New System.Windows.Forms.ComboBox()
        Me.CBox_BitsStop = New System.Windows.Forms.ComboBox()
        Me.CBox_Paritad = New System.Windows.Forms.ComboBox()
        Me.CBox_BitsDD = New System.Windows.Forms.ComboBox()
        Me.CBox_BPS = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lbl_bitsPS
        '
        Me.lbl_bitsPS.AutoSize = True
        Me.lbl_bitsPS.Location = New System.Drawing.Point(41, 33)
        Me.lbl_bitsPS.Name = "lbl_bitsPS"
        Me.lbl_bitsPS.Size = New System.Drawing.Size(74, 13)
        Me.lbl_bitsPS.TabIndex = 0
        Me.lbl_bitsPS.Text = "Bits per segon"
        '
        'lbl_BitsDD
        '
        Me.lbl_BitsDD.AutoSize = True
        Me.lbl_BitsDD.Location = New System.Drawing.Point(44, 60)
        Me.lbl_BitsDD.Name = "lbl_BitsDD"
        Me.lbl_BitsDD.Size = New System.Drawing.Size(71, 13)
        Me.lbl_BitsDD.TabIndex = 2
        Me.lbl_BitsDD.Text = "Bits de dades"
        '
        'lbl_Paritad
        '
        Me.lbl_Paritad.AutoSize = True
        Me.lbl_Paritad.Location = New System.Drawing.Point(72, 87)
        Me.lbl_Paritad.Name = "lbl_Paritad"
        Me.lbl_Paritad.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Paritad.TabIndex = 4
        Me.lbl_Paritad.Text = "Paritat"
        '
        'lbl_BitsStop
        '
        Me.lbl_BitsStop.AutoSize = True
        Me.lbl_BitsStop.Location = New System.Drawing.Point(44, 114)
        Me.lbl_BitsStop.Name = "lbl_BitsStop"
        Me.lbl_BitsStop.Size = New System.Drawing.Size(71, 13)
        Me.lbl_BitsStop.TabIndex = 6
        Me.lbl_BitsStop.Text = "Bits de STOP"
        '
        'lbl_CFlux
        '
        Me.lbl_CFlux.AutoSize = True
        Me.lbl_CFlux.Location = New System.Drawing.Point(35, 141)
        Me.lbl_CFlux.Name = "lbl_CFlux"
        Me.lbl_CFlux.Size = New System.Drawing.Size(77, 13)
        Me.lbl_CFlux.TabIndex = 8
        Me.lbl_CFlux.Text = "Control de Flux"
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(37, 229)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Aceptar.TabIndex = 7
        Me.btn_Aceptar.Text = "ACEPTAR"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'btn_Cancelar
        '
        Me.btn_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancelar.Location = New System.Drawing.Point(167, 229)
        Me.btn_Cancelar.MaximumSize = New System.Drawing.Size(75, 23)
        Me.btn_Cancelar.MinimumSize = New System.Drawing.Size(75, 23)
        Me.btn_Cancelar.Name = "btn_Cancelar"
        Me.btn_Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Cancelar.TabIndex = 8
        Me.btn_Cancelar.Text = "CANCELAR"
        Me.btn_Cancelar.UseVisualStyleBackColor = True
        '
        'lbl_Password
        '
        Me.lbl_Password.AutoSize = True
        Me.lbl_Password.Location = New System.Drawing.Point(64, 196)
        Me.lbl_Password.Name = "lbl_Password"
        Me.lbl_Password.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Password.TabIndex = 12
        Me.lbl_Password.Text = "Pasword"
        '
        'lbl_Nom
        '
        Me.lbl_Nom.AutoSize = True
        Me.lbl_Nom.Location = New System.Drawing.Point(35, 168)
        Me.lbl_Nom.Name = "lbl_Nom"
        Me.lbl_Nom.Size = New System.Drawing.Size(68, 13)
        Me.lbl_Nom.TabIndex = 16
        Me.lbl_Nom.Text = "Nom del Port"
        '
        'txtBox_Password
        '
        Me.txtBox_Password.Location = New System.Drawing.Point(121, 194)
        Me.txtBox_Password.Name = "txtBox_Password"
        Me.txtBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(248)
        Me.txtBox_Password.Size = New System.Drawing.Size(63, 20)
        Me.txtBox_Password.TabIndex = 6
        Me.txtBox_Password.Text = "1234"
        '
        'CBox_Nom
        '
        Me.CBox_Nom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBox_Nom.FormattingEnabled = True
        Me.CBox_Nom.Items.AddRange(New Object() {"COM1", "COM3", "COM8"})
        Me.CBox_Nom.Location = New System.Drawing.Point(121, 168)
        Me.CBox_Nom.Name = "CBox_Nom"
        Me.CBox_Nom.Size = New System.Drawing.Size(121, 21)
        Me.CBox_Nom.TabIndex = 22
        '
        'CBox_CFlujo
        '
        Me.CBox_CFlujo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBox_CFlujo.FormattingEnabled = True
        Me.CBox_CFlujo.Items.AddRange(New Object() {"None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff"})
        Me.CBox_CFlujo.Location = New System.Drawing.Point(121, 141)
        Me.CBox_CFlujo.Name = "CBox_CFlujo"
        Me.CBox_CFlujo.Size = New System.Drawing.Size(121, 21)
        Me.CBox_CFlujo.TabIndex = 21
        '
        'CBox_BitsStop
        '
        Me.CBox_BitsStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBox_BitsStop.FormattingEnabled = True
        Me.CBox_BitsStop.Items.AddRange(New Object() {"1", "1.5", "2"})
        Me.CBox_BitsStop.Location = New System.Drawing.Point(121, 114)
        Me.CBox_BitsStop.Name = "CBox_BitsStop"
        Me.CBox_BitsStop.Size = New System.Drawing.Size(121, 21)
        Me.CBox_BitsStop.TabIndex = 20
        '
        'CBox_Paritad
        '
        Me.CBox_Paritad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBox_Paritad.FormattingEnabled = True
        Me.CBox_Paritad.Items.AddRange(New Object() {"None", "Odd", "Even", "Markj", "Space"})
        Me.CBox_Paritad.Location = New System.Drawing.Point(121, 87)
        Me.CBox_Paritad.Name = "CBox_Paritad"
        Me.CBox_Paritad.Size = New System.Drawing.Size(121, 21)
        Me.CBox_Paritad.TabIndex = 19
        '
        'CBox_BitsDD
        '
        Me.CBox_BitsDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBox_BitsDD.FormattingEnabled = True
        Me.CBox_BitsDD.Items.AddRange(New Object() {"5", "6", "7", "8"})
        Me.CBox_BitsDD.Location = New System.Drawing.Point(121, 60)
        Me.CBox_BitsDD.Name = "CBox_BitsDD"
        Me.CBox_BitsDD.Size = New System.Drawing.Size(121, 21)
        Me.CBox_BitsDD.TabIndex = 18
        '
        'CBox_BPS
        '
        Me.CBox_BPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBox_BPS.FormattingEnabled = True
        Me.CBox_BPS.Items.AddRange(New Object() {"110", "300", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600"})
        Me.CBox_BPS.Location = New System.Drawing.Point(121, 33)
        Me.CBox_BPS.Name = "CBox_BPS"
        Me.CBox_BPS.Size = New System.Drawing.Size(121, 21)
        Me.CBox_BPS.TabIndex = 17
        '
        'Configuracio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.CBox_Nom)
        Me.Controls.Add(Me.CBox_CFlujo)
        Me.Controls.Add(Me.CBox_BitsStop)
        Me.Controls.Add(Me.CBox_Paritad)
        Me.Controls.Add(Me.CBox_BitsDD)
        Me.Controls.Add(Me.CBox_BPS)
        Me.Controls.Add(Me.lbl_Nom)
        Me.Controls.Add(Me.txtBox_Password)
        Me.Controls.Add(Me.lbl_Password)
        Me.Controls.Add(Me.btn_Cancelar)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Controls.Add(Me.lbl_CFlux)
        Me.Controls.Add(Me.lbl_BitsStop)
        Me.Controls.Add(Me.lbl_Paritad)
        Me.Controls.Add(Me.lbl_BitsDD)
        Me.Controls.Add(Me.lbl_bitsPS)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 302)
        Me.MinimumSize = New System.Drawing.Size(300, 302)
        Me.Name = "Configuracio"
        Me.Text = "Configuracio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_bitsPS As System.Windows.Forms.Label
    Friend WithEvents lbl_BitsDD As System.Windows.Forms.Label
    Friend WithEvents lbl_Paritad As System.Windows.Forms.Label
    Friend WithEvents lbl_BitsStop As System.Windows.Forms.Label
    Friend WithEvents lbl_CFlux As System.Windows.Forms.Label
    Friend WithEvents btn_Aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents lbl_Password As System.Windows.Forms.Label
    Friend WithEvents lbl_Nom As System.Windows.Forms.Label
    Friend WithEvents txtBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents CBox_Nom As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_CFlujo As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_BitsStop As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_Paritad As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_BitsDD As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_BPS As System.Windows.Forms.ComboBox
End Class
