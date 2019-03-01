<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonD = New System.Windows.Forms.Button()
        Me.ButtonI = New System.Windows.Forms.Button()
        Me.ButtonB = New System.Windows.Forms.Button()
        Me.ButtonS = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btn_Config = New System.Windows.Forms.Button()
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_Informacio = New System.Windows.Forms.Label()
        Me.Desconectador = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Silver
        Me.PictureBox1.Location = New System.Drawing.Point(39, 23)
        Me.PictureBox1.MaximumSize = New System.Drawing.Size(400, 400)
        Me.PictureBox1.MinimumSize = New System.Drawing.Size(400, 400)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(400, 400)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(503, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(126, 48)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "GENERAR AREA DE TRABAJO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButtonD)
        Me.Panel1.Controls.Add(Me.ButtonI)
        Me.Panel1.Controls.Add(Me.ButtonB)
        Me.Panel1.Controls.Add(Me.ButtonS)
        Me.Panel1.Location = New System.Drawing.Point(462, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(210, 210)
        Me.Panel1.TabIndex = 2
        '
        'ButtonD
        '
        Me.ButtonD.Location = New System.Drawing.Point(140, 70)
        Me.ButtonD.Name = "ButtonD"
        Me.ButtonD.Size = New System.Drawing.Size(70, 70)
        Me.ButtonD.TabIndex = 3
        Me.ButtonD.Text = "DERECHA"
        Me.ButtonD.UseVisualStyleBackColor = True
        '
        'ButtonI
        '
        Me.ButtonI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonI.Location = New System.Drawing.Point(0, 70)
        Me.ButtonI.Name = "ButtonI"
        Me.ButtonI.Size = New System.Drawing.Size(70, 70)
        Me.ButtonI.TabIndex = 2
        Me.ButtonI.Text = "IZQ"
        Me.ButtonI.UseVisualStyleBackColor = True
        '
        'ButtonB
        '
        Me.ButtonB.Location = New System.Drawing.Point(70, 140)
        Me.ButtonB.Name = "ButtonB"
        Me.ButtonB.Size = New System.Drawing.Size(70, 70)
        Me.ButtonB.TabIndex = 1
        Me.ButtonB.Text = "BAJAR"
        Me.ButtonB.UseVisualStyleBackColor = True
        '
        'ButtonS
        '
        Me.ButtonS.Location = New System.Drawing.Point(70, 0)
        Me.ButtonS.Name = "ButtonS"
        Me.ButtonS.Size = New System.Drawing.Size(70, 70)
        Me.ButtonS.TabIndex = 0
        Me.ButtonS.Text = "SUBIR"
        Me.ButtonS.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.ReadBufferSize = 8
        '
        'btn_Config
        '
        Me.btn_Config.Location = New System.Drawing.Point(503, 77)
        Me.btn_Config.Name = "btn_Config"
        Me.btn_Config.Size = New System.Drawing.Size(126, 33)
        Me.btn_Config.TabIndex = 3
        Me.btn_Config.Text = "CONFIGURAR"
        Me.btn_Config.UseVisualStyleBackColor = True
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(503, 116)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(126, 33)
        Me.btn_Connect.TabIndex = 4
        Me.btn_Connect.Text = "CONNECTAR"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'lbl_Informacio
        '
        Me.lbl_Informacio.AutoEllipsis = True
        Me.lbl_Informacio.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Informacio.Location = New System.Drawing.Point(445, 152)
        Me.lbl_Informacio.Name = "lbl_Informacio"
        Me.lbl_Informacio.Size = New System.Drawing.Size(227, 37)
        Me.lbl_Informacio.TabIndex = 7
        Me.lbl_Informacio.Text = "Conectar"
        Me.lbl_Informacio.Visible = False
        '
        'Desconectador
        '
        Me.Desconectador.Interval = 250
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 481)
        Me.Controls.Add(Me.lbl_Informacio)
        Me.Controls.Add(Me.btn_Connect)
        Me.Controls.Add(Me.btn_Config)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "GESTOR MOVIMIENTO AGV LOCAL"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonD As System.Windows.Forms.Button
    Friend WithEvents ButtonI As System.Windows.Forms.Button
    Friend WithEvents ButtonB As System.Windows.Forms.Button
    Friend WithEvents ButtonS As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btn_Config As System.Windows.Forms.Button
    Friend WithEvents btn_Connect As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbl_Informacio As System.Windows.Forms.Label
    Friend WithEvents Desconectador As System.Windows.Forms.Timer

End Class
