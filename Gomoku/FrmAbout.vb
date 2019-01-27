' Gomoku, By Trevor D. Brown
' CS 396 - Dr. Wang
' September 13th, 2016

' frmAbout.vb - The Windows Form that shows the user information about the application.

Public Class frmAbout

    ' Declare variables to be used throughout the form.
    Protected intPauseCount As Integer = 0    ' Integer: to allow text animation to pause for two seconds.

    ' About form loading procedures.
    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblDeveloper.Left = Me.Width    ' Position the Developer information label outside of the form space.
        tmrTextSlide.Start()            ' Start the Text Slide timer.
    End Sub

    ' KeyDown event listener
    Private Sub frmSplash_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ' If Escape is pressed while the form is selected, close the form.
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    ' Mouse down on the form event handler.
    Private Sub frmAbout_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Me.Close()  ' Close the form, if the mouse is pressed down on the form.
    End Sub

    ' Text Slide timer tick event handler.
    Private Sub tmrTextSlide_Tick(sender As Object, e As EventArgs) Handles tmrTextSlide.Tick
        ' Shift the Developer information label to the left by one pixel.
        lblDeveloper.Left = lblDeveloper.Left - 1

        ' If the Developer information label's left side is on the leftmost edge of the form,
        ' pause the text slide for two seconds.
        If (lblDeveloper.Left = 0) Then
            tmrTextSlidePause.Start()
            tmrTextSlide.Stop()
        ElseIf (lblDeveloper.Right = 0) Then
            ' If the right side of the developer information label goes past the lefthand side of the form,
            ' move the label back to its start point.
            lblDeveloper.Left = Me.Width
        End If

    End Sub

    ' Text Slide Pause timer tick event handler.
    Private Sub tmrTextSlidePause_Tick(sender As Object, e As EventArgs) Handles tmrTextSlidePause.Tick

        ' If the pause count is less than two (aka less than two seconds), wait again.
        ' Otherwise, start the animation again, and stop this timer.
        If intPauseCount < 2 Then
            intPauseCount += 1
        ElseIf intPauseCount = 2 Then
            tmrTextSlide.Start()
            intPauseCount = 0
            tmrTextSlidePause.Stop()
        End If
    End Sub
End Class
