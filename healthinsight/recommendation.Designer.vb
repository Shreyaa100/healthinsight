<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class recommendation
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
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(recommendation))
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(components)
        Guna2PictureBox1 = New Guna.UI2.WinForms.Guna2PictureBox()
        Label2 = New Label()
        RichTextBox1 = New RichTextBox()
        Guna2ComboBox1 = New Guna.UI2.WinForms.Guna2ComboBox()
        Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2BorderlessForm1
        ' 
        Guna2BorderlessForm1.ContainerControl = Me
        Guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6R
        Guna2BorderlessForm1.TransparentWhileDrag = True
        ' 
        ' Guna2PictureBox1
        ' 
        Guna2PictureBox1.BackColor = Color.Transparent
        Guna2PictureBox1.CustomizableEdges = CustomizableEdges5
        Guna2PictureBox1.Image = CType(resources.GetObject("Guna2PictureBox1.Image"), Image)
        Guna2PictureBox1.ImageRotate = 0F
        Guna2PictureBox1.Location = New Point(7, 55)
        Guna2PictureBox1.Name = "Guna2PictureBox1"
        Guna2PictureBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Guna2PictureBox1.Size = New Size(464, 556)
        Guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Guna2PictureBox1.TabIndex = 7
        Guna2PictureBox1.TabStop = False
        Guna2PictureBox1.UseTransparentBackground = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Stencil", 15F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(90, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(266, 30)
        Label2.TabIndex = 8
        Label2.Text = "Recommendations"
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.LightCyan
        RichTextBox1.Location = New Point(525, 106)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(444, 453)
        RichTextBox1.TabIndex = 12
        RichTextBox1.Text = ""
        RichTextBox1.Visible = False
        ' 
        ' Guna2ComboBox1
        ' 
        Guna2ComboBox1.BackColor = Color.LightCyan
        Guna2ComboBox1.CustomizableEdges = CustomizableEdges3
        Guna2ComboBox1.DrawMode = DrawMode.OwnerDrawFixed
        Guna2ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        Guna2ComboBox1.FillColor = Color.LightCyan
        Guna2ComboBox1.FocusedColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2ComboBox1.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        Guna2ComboBox1.Font = New Font("Segoe UI", 10F)
        Guna2ComboBox1.ForeColor = Color.FromArgb(CByte(68), CByte(88), CByte(112))
        Guna2ComboBox1.ItemHeight = 30
        Guna2ComboBox1.Items.AddRange(New Object() {"Natural Remedies", "Product Recommendations", "Diet Plan"})
        Guna2ComboBox1.Location = New Point(584, 40)
        Guna2ComboBox1.Name = "Guna2ComboBox1"
        Guna2ComboBox1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2ComboBox1.Size = New Size(331, 36)
        Guna2ComboBox1.TabIndex = 14
        ' 
        ' Guna2Button1
        ' 
        Guna2Button1.BackColor = Color.PaleTurquoise
        Guna2Button1.BorderRadius = 5
        Guna2Button1.CustomizableEdges = CustomizableEdges1
        Guna2Button1.DisabledState.BorderColor = Color.DarkGray
        Guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray
        Guna2Button1.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Guna2Button1.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Guna2Button1.FillColor = Color.PaleTurquoise
        Guna2Button1.Font = New Font("Segoe UI", 9F)
        Guna2Button1.ForeColor = Color.Black
        Guna2Button1.Location = New Point(666, 579)
        Guna2Button1.Name = "Guna2Button1"
        Guna2Button1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2Button1.Size = New Size(176, 32)
        Guna2Button1.TabIndex = 15
        Guna2Button1.Text = "Feedback"
        ' 
        ' recommendation
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.MediumTurquoise
        ClientSize = New Size(1012, 623)
        Controls.Add(Guna2Button1)
        Controls.Add(Guna2ComboBox1)
        Controls.Add(RichTextBox1)
        Controls.Add(Label2)
        Controls.Add(Guna2PictureBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "recommendation"
        Text = "recommendation"
        CType(Guna2PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
    Friend WithEvents Guna2PictureBox1 As Guna.UI2.WinForms.Guna2PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2ComboBox1 As Guna.UI2.WinForms.Guna2ComboBox
End Class
