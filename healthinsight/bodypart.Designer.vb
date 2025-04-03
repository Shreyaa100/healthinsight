<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bodypart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(bodypart))
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Label1 = New Label()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        ComboBox1 = New ComboBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        CheckBox1 = New CheckBox()
        CheckBox2 = New CheckBox()
        CheckBox3 = New CheckBox()
        CheckBox4 = New CheckBox()
        CheckBox5 = New CheckBox()
        CheckBox6 = New CheckBox()
        CheckBox7 = New CheckBox()
        CheckBox8 = New CheckBox()
        Guna2Button2 = New Guna.UI2.WinForms.Guna2Button()
        CType(Guna2CirclePictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Guna2CirclePictureBox1
        ' 
        Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), Image)
        Guna2CirclePictureBox1.ImageRotate = 0F
        Guna2CirclePictureBox1.Location = New Point(-38, -42)
        Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges5
        Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Guna2CirclePictureBox1.Size = New Size(253, 249)
        Guna2CirclePictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Guna2CirclePictureBox1.TabIndex = 1
        Guna2CirclePictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Stencil", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(315, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(256, 24)
        Label1.TabIndex = 2
        Label1.Text = "Select the body part"
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.CustomizableEdges = CustomizableEdges3
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.DarkTurquoise
        Guna2Button1.Font = New Font("Segoe UI", 9F)
        Guna2Button1.ForeColor = Color.White
        Guna2Button1.Location = New Point(586, 54)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Button1.Size = New Size(121, 28)
        Guna2Button1.TabIndex = 5
        Guna2Button1.Text = "Proceed"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Head (Brain & Scalp)", "Skin (Face & Body)", "Throat & Chest", "Stomach & Abdomen", "Joints & Bones", "Legs & Feet"})
        ComboBox1.Location = New Point(315, 54)
        ComboBox1.MaxDropDownItems = 15
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(256, 28)
        ComboBox1.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Lucida Fax", 16.2F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(27, 195)
        Label2.Name = "Label2"
        Label2.Size = New Size(358, 33)
        Label2.TabIndex = 8
        Label2.Text = "Answer The Questions :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.8F)
        Label3.Location = New Point(27, 279)
        Label3.Name = "Label3"
        Label3.Size = New Size(251, 31)
        Label3.TabIndex = 9
        Label3.Text = "Answer The Questions :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 13.8F)
        Label4.Location = New Point(27, 347)
        Label4.Name = "Label4"
        Label4.Size = New Size(251, 31)
        Label4.TabIndex = 10
        Label4.Text = "Answer The Questions :"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 13.8F)
        Label5.Location = New Point(27, 415)
        Label5.Name = "Label5"
        Label5.Size = New Size(251, 31)
        Label5.TabIndex = 11
        Label5.Text = "Answer The Questions :"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 13.8F)
        Label6.Location = New Point(27, 483)
        Label6.Name = "Label6"
        Label6.Size = New Size(251, 31)
        Label6.TabIndex = 12
        Label6.Text = "Answer The Questions :"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Font = New Font("Segoe UI", 13.8F)
        CheckBox1.Location = New Point(665, 279)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(69, 35)
        CheckBox1.TabIndex = 13
        CheckBox1.Text = "Yes"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' CheckBox2
        ' 
        CheckBox2.AutoSize = True
        CheckBox2.Font = New Font("Segoe UI", 13.8F)
        CheckBox2.Location = New Point(777, 278)
        CheckBox2.Name = "CheckBox2"
        CheckBox2.Size = New Size(66, 35)
        CheckBox2.TabIndex = 14
        CheckBox2.Text = "No"
        CheckBox2.UseVisualStyleBackColor = True
        ' 
        ' CheckBox3
        ' 
        CheckBox3.AutoSize = True
        CheckBox3.Font = New Font("Segoe UI", 13.8F)
        CheckBox3.Location = New Point(665, 347)
        CheckBox3.Name = "CheckBox3"
        CheckBox3.Size = New Size(69, 35)
        CheckBox3.TabIndex = 15
        CheckBox3.Text = "Yes"
        CheckBox3.UseVisualStyleBackColor = True
        ' 
        ' CheckBox4
        ' 
        CheckBox4.AutoSize = True
        CheckBox4.Font = New Font("Segoe UI", 13.8F)
        CheckBox4.Location = New Point(777, 343)
        CheckBox4.Name = "CheckBox4"
        CheckBox4.Size = New Size(66, 35)
        CheckBox4.TabIndex = 16
        CheckBox4.Text = "No"
        CheckBox4.UseVisualStyleBackColor = True
        ' 
        ' CheckBox5
        ' 
        CheckBox5.AutoSize = True
        CheckBox5.Font = New Font("Segoe UI", 13.8F)
        CheckBox5.Location = New Point(665, 411)
        CheckBox5.Name = "CheckBox5"
        CheckBox5.Size = New Size(69, 35)
        CheckBox5.TabIndex = 17
        CheckBox5.Text = "Yes"
        CheckBox5.UseVisualStyleBackColor = True
        ' 
        ' CheckBox6
        ' 
        CheckBox6.AutoSize = True
        CheckBox6.Font = New Font("Segoe UI", 13.8F)
        CheckBox6.Location = New Point(777, 411)
        CheckBox6.Name = "CheckBox6"
        CheckBox6.Size = New Size(66, 35)
        CheckBox6.TabIndex = 18
        CheckBox6.Text = "No"
        CheckBox6.UseVisualStyleBackColor = True
        ' 
        ' CheckBox7
        ' 
        CheckBox7.AutoSize = True
        CheckBox7.Font = New Font("Segoe UI", 13.8F)
        CheckBox7.Location = New Point(665, 483)
        CheckBox7.Name = "CheckBox7"
        CheckBox7.Size = New Size(69, 35)
        CheckBox7.TabIndex = 19
        CheckBox7.Text = "Yes"
        CheckBox7.UseVisualStyleBackColor = True
        ' 
        ' CheckBox8
        ' 
        CheckBox8.AutoSize = True
        CheckBox8.Font = New Font("Segoe UI", 13.8F)
        CheckBox8.Location = New Point(777, 479)
        CheckBox8.Name = "CheckBox8"
        CheckBox8.Size = New Size(66, 35)
        CheckBox8.TabIndex = 20
        CheckBox8.Text = "No"
        CheckBox8.UseVisualStyleBackColor = True
        ' 
        ' Guna2Button2
        ' 
        Guna2Button2.CustomizableEdges = CustomizableEdges1
        Guna2Button2.DisabledState.BorderColor = Color.DarkGray
        Guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button2.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button2.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button2.FillColor = Color.DarkTurquoise
        Guna2Button2.Font = New Font("Segoe UI", 9F)
        Guna2Button2.ForeColor = Color.White
        Guna2Button2.Location = New Point(679, 555)
        Guna2Button2.Name = "Guna2Button2"
        Guna2Button2.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Button2.Size = New Size(121, 28)
        Guna2Button2.TabIndex = 21
        Guna2Button2.Text = "Proceed"
        ' 
        ' bodypart
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightCyan
        ClientSize = New Size(1014, 595)
        Controls.Add(Guna2Button2)
        Controls.Add(CheckBox8)
        Controls.Add(CheckBox7)
        Controls.Add(CheckBox6)
        Controls.Add(CheckBox5)
        Controls.Add(CheckBox4)
        Controls.Add(CheckBox3)
        Controls.Add(CheckBox2)
        Controls.Add(CheckBox1)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(ComboBox1)
        Controls.Add(Guna2Button1)
        Controls.Add(Label1)
        Controls.Add(Guna2CirclePictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "bodypart"
        Text = "bodypart"
        CType(Guna2CirclePictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheckBox8 As CheckBox
    Friend WithEvents CheckBox7 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Guna2Button2 As Guna.UI2.WinForms.Guna2Button
End Class
