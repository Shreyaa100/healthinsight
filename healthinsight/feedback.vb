Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class Feedback
    Private conn As New MySqlConnection("server=localhost;user id=root;password=Kanha*#0100;database=healthinsights;")

    ' Constructor for Feedback Form
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Load Feedback Form
    Private Sub FeedbackForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the user is logged in

        Try
            ' Your code here
        Catch ex As Exception
            MessageBox.Show("Error during form load: " & ex.Message)
        End Try


        If LoggedInUserId = -1 Then
            MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        ' Retrieve and display user details
        Dim userDetails As (String, String) = GetUserDetails(LoggedInUserId)
        Guna2TextBox1.Text = userDetails.Item1 ' Username
        Guna2TextBox2.Text = userDetails.Item2 ' Email

        ' Make username field uneditable
        Guna2TextBox1.ReadOnly = True
    End Sub

    ' Function to get username and email based on user_id
    Private Function GetUserDetails(userId As Integer) As (String, String)
        Dim username As String = ""
        Dim email As String = ""
        Try
            conn.Open()
            Dim query As String = "SELECT username, email FROM users WHERE userid = @userId"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@userId", userId)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    username = reader("username").ToString()
                    email = reader("email").ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        Return (username, email)
    End Function

    ' Save Feedback Button Click
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Try
            conn.Open

            ' Get input values
            Dim rating As Integer = Guna2RatingStar1.Value
            Dim comments = Guna2TextBox3.Text
            Dim email = Guna2TextBox2.Text

            ' Insert feedback into the database
            Dim query = "INSERT INTO feedback (user_id, email, rating, comments) VALUES (@user_id, @email, @rating, @comments)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@user_id", LoggedInUserId)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@rating", rating)
                cmd.Parameters.AddWithValue("@comments", comments)
                cmd.ExecuteNonQuery
            End Using

            MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim dash As New Dashboard
            dash.Show
            Hide
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close
        End Try
    End Sub
End Class
