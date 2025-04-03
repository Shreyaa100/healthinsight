Public Class diagnosis
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"

    Private LoggedInUserId As Integer
    Private SelectedBodyPart As String
    Private SelectedQuestions As String

    ' Constructor to accept parameters
    Private Sub diagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure textboxes show the correct data
        Guna2TextBox1.Text = SelectedBodyPart
        Guna2TextBox2.Text = SelectedQuestions
    End Sub


    Public Sub New(userId As Integer, bodyPart As String, allQuestions As String)
        InitializeComponent()
        LoggedInUserId = userId
        SelectedBodyPart = bodyPart

        ' Assign values
        Guna2TextBox1.Text = SelectedBodyPart
        Guna2TextBox2.Text = allQuestions ' Display all questions in a single textbox
    End Sub



End Class