Imports MySql.Data.MySqlClient

Public Class recommendation
    Dim connStr As String = "server=localhost;userid=root;password=Kanha*#0100;database=healthinsights"
    Dim conn As New MySqlConnection(connStr)

    Private Sub recommendation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear textboxes initially
        Guna2TextBox1.Clear()
        Guna2TextBox2.Clear()
        Guna2TextBox3.Clear()
    End Sub

    ' ✅ Fetch the latest result_id from diagnosis_result
    Private Function GetLatestResultId() As Integer
        Dim resultId As Integer = -1
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim cmd As New MySqlCommand("SELECT MAX(result_id) FROM diagnosis_result", conn)
            Dim result = cmd.ExecuteScalar()
            If Not IsDBNull(result) Then resultId = Convert.ToInt32(result)
        Catch ex As Exception
            MessageBox.Show("Error fetching latest result ID: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        Return resultId
    End Function

    ' ✅ Load recommendation text by type into specified textbox
    Private Sub LoadRecommendationText(recommendationType As String, textBox As Guna.UI2.WinForms.Guna2TextBox)
        Dim resultId As Integer = GetLatestResultId()
        If resultId = -1 Then Return

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()
            Dim query As String = "SELECT recommendation_text FROM recommendations WHERE result_id = @result_id AND recommendation_type = @type LIMIT 1"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@result_id", resultId)
            cmd.Parameters.AddWithValue("@type", recommendationType)

            Dim result = cmd.ExecuteScalar()
            textBox.Text = If(result IsNot Nothing, result.ToString(), "No recommendation available.")

        Catch ex As Exception
            MessageBox.Show("Error loading " & recommendationType & " recommendation: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' ✅ Event handlers for checkboxes
    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked Then
            LoadRecommendationText("Natural", Guna2TextBox2)
        Else
            Guna2TextBox2.Clear()
        End If
    End Sub

    Private Sub Guna2CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox2.CheckedChanged
        If Guna2CheckBox2.Checked Then
            LoadRecommendationText("Commercial", Guna2TextBox1)
        Else
            Guna2TextBox1.Clear()
        End If
    End Sub

    Private Sub Guna2CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox3.CheckedChanged
        If Guna2CheckBox3.Checked Then
            LoadRecommendationText("Diet/Exercise", Guna2TextBox3)
        Else
            Guna2TextBox3.Clear()
        End If
    End Sub

    ' ✅ Back to Dashboard button
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim dash As New Dashboard()
        dash.Show()
        Me.Hide()
    End Sub
End Class





