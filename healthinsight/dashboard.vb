Imports MySql.Data.MySqlClient

Public Class Dashboard
    Private loggedInUserId As Integer
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"

    ' Constructor with userId
    Public Sub New(userId As Integer)
        InitializeComponent()
        loggedInUserId = userId
        LoadUsername() ' Fetch and display username
    End Sub

    ' Default constructor (needed to avoid errors)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Function to fetch the username from the database
    Private Sub LoadUsername()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT email FROM users WHERE userid = @userid"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", loggedInUserId)

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Guna2TextBox1.Text = result.ToString() ' Display username in Guna2TextBox1
                    Else
                        Guna2TextBox1.Text = "User Not Found"
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching username: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Button to open the Feedback Form
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim feedbackForm As New Feedback()
        feedbackForm.Show()
        Me.Hide()
    End Sub

    ' Button to open the Body Part Form
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim reco As New recommendation()
        reco.Show()
        Me.Hide()
    End Sub

    ' Button to open the User Interaction Form
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Application.Exit()
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Dim bodypartForm As New bodypart(loggedInUserId)
        bodypartForm.Show()
        Hide()
    End Sub
End Class

