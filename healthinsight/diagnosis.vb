Imports MySql.Data.MySqlClient

Public Class diagnosis
    Private connectionString As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"
    Private LoggedInUserId As Integer
    Private SelectedBodyPart As String

    ' Constructor to accept parameters
    Public Sub New(userId As Integer, bodyPart As String)
        InitializeComponent()
        LoggedInUserId = userId
        SelectedBodyPart = bodyPart
    End Sub

    ' Form Load Event
    Private Sub diagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Assign selected body part to Guna2TextBox1
        Guna2TextBox1.Text = SelectedBodyPart

        ' Load questions & diagnosis
        LoadQuestions()
        LoadDiagnosis() ' ✅ Load Disease Name & Cause
    End Sub

    ' Function to load questions based on user's assigned question_id
    Private Sub LoadQuestions()
        Dim query As String = "SELECT q.question1, q.question2, q.question3, q.question4 
                               FROM user_answer ua 
                               INNER JOIN questionnaire q ON ua.question_id = q.question_id 
                               WHERE ua.userid = @userid"

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@userid", LoggedInUserId)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' Display all questions in Guna2TextBox2
                        Dim allQuestions As String = reader("question1").ToString() & vbCrLf & vbCrLf &
                                                     reader("question2").ToString() & vbCrLf & vbCrLf &
                                                     reader("question3").ToString() & vbCrLf & vbCrLf &
                                                     reader("question4").ToString()

                        Guna2TextBox2.Text = allQuestions
                        Guna2TextBox2.ReadOnly = True
                    Else
                        MessageBox.Show("No questions found for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ' ✅ Function to Load Disease Name & Cause based on question_id
    Private Sub LoadDiagnosis()
        Dim questionId As Integer = -1 ' Default invalid ID

        ' 🔹 First, get question_id from user_answer
        Dim getQuestionIdQuery As String = "SELECT question_id FROM user_answer WHERE userid = @userid"

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(getQuestionIdQuery, conn)
                    cmd.Parameters.AddWithValue("@userid", LoggedInUserId)
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing Then
                        questionId = Convert.ToInt32(result)
                    Else
                        MessageBox.Show("No question ID found for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub ' No need to continue if no question_id
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error fetching question ID: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End Using

        ' 🔹 Next, get disease_name & cause using the question_id
        Dim getDiagnosisQuery As String = "SELECT disease_name, cause FROM diagnosis_result WHERE question_id = @questionId"

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using cmd As New MySqlCommand(getDiagnosisQuery, conn)
                    cmd.Parameters.AddWithValue("@questionId", questionId)
                    Dim reader As MySqlDataReader = cmd.ExecuteReader()

                    If reader.Read() Then
                        ' ✅ Load disease name & cause into textboxes
                        Guna2TextBox3.Text = reader("disease_name").ToString()
                        Guna2TextBox4.Text = reader("cause").ToString()
                    Else
                        MessageBox.Show("No diagnosis found for question ID " & questionId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading diagnosis: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim dash As New Dashboard(LoggedInUserId)
        dash.Show()
        Hide()
    End Sub
End Class
