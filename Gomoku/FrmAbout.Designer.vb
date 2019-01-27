<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.components = New System.ComponentModel.Container()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDeveloper = New System.Windows.Forms.Label()
        Me.tmrTextSlide = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTextSlidePause = New System.Windows.Forms.Timer(Me.components)
        Me.picMe = New System.Windows.Forms.PictureBox()
        CType(Me.picMe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(179, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(139, 37)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Gomoku"
        '
        'lblDeveloper
        '
        Me.lblDeveloper.AutoSize = True
        Me.lblDeveloper.Location = New System.Drawing.Point(12, 281)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(869, 13)
        Me.lblDeveloper.TabIndex = 2
        Me.lblDeveloper.Text = "By Trevor D. Brown. Submitted September 13th, 2016. This project was in fulfillme" &
    "nt of the Project 1 requirements for Dr. Wang's CS 396 course                   " &
    " Thank you for reading this."
        '
        'tmrTextSlide
        '
        Me.tmrTextSlide.Interval = 10
        '
        'tmrTextSlidePause
        '
        Me.tmrTextSlidePause.Interval = 2000
        '
        'picMe
        '
        Me.picMe.Image = Global.Gomoku.My.Resources.Resources.IMG_2015
        Me.picMe.Location = New System.Drawing.Point(186, 49)
        Me.picMe.Name = "picMe"
        Me.picMe.Size = New System.Drawing.Size(132, 229)
        Me.picMe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMe.TabIndex = 3
        Me.picMe.TabStop = False
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.picMe)
        Me.Controls.Add(Me.lblDeveloper)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.picMe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDeveloper As Label
    Friend WithEvents tmrTextSlide As Timer
    Friend WithEvents tmrTextSlidePause As Timer
    Friend WithEvents picMe As PictureBox
End Class
