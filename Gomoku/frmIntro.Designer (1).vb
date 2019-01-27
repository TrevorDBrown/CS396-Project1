<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIntro
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.tmrTextSlideStart = New System.Windows.Forms.Timer(Me.components)
        Me.tmrTextSlide = New System.Windows.Forms.Timer(Me.components)
        Me.btnStartGame = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.grpBoardSize = New System.Windows.Forms.GroupBox()
        Me.radNineteen = New System.Windows.Forms.RadioButton()
        Me.radFifteen = New System.Windows.Forms.RadioButton()
        Me.radTwelve = New System.Windows.Forms.RadioButton()
        Me.grpPlayerMode = New System.Windows.Forms.GroupBox()
        Me.radComputerVsComputer = New System.Windows.Forms.RadioButton()
        Me.radPlayerVsComputer = New System.Windows.Forms.RadioButton()
        Me.radPlayerVsPlayer = New System.Windows.Forms.RadioButton()
        Me.btnPlayNow = New System.Windows.Forms.Button()
        Me.btnCancelGame = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnHowToPlay = New System.Windows.Forms.Button()
        Me.grpBoardSize.SuspendLayout()
        Me.grpPlayerMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(179, 133)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(139, 37)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Gomoku"
        '
        'tmrTextSlideStart
        '
        Me.tmrTextSlideStart.Interval = 1000
        '
        'tmrTextSlide
        '
        Me.tmrTextSlide.Interval = 10
        '
        'btnStartGame
        '
        Me.btnStartGame.Location = New System.Drawing.Point(198, 98)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(100, 32)
        Me.btnStartGame.TabIndex = 1
        Me.btnStartGame.Text = "&Start a Game"
        Me.btnStartGame.UseVisualStyleBackColor = True
        Me.btnStartGame.Visible = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(198, 212)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(100, 32)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.Visible = False
        '
        'grpBoardSize
        '
        Me.grpBoardSize.Controls.Add(Me.radNineteen)
        Me.grpBoardSize.Controls.Add(Me.radFifteen)
        Me.grpBoardSize.Controls.Add(Me.radTwelve)
        Me.grpBoardSize.Location = New System.Drawing.Point(198, 136)
        Me.grpBoardSize.Name = "grpBoardSize"
        Me.grpBoardSize.Size = New System.Drawing.Size(215, 105)
        Me.grpBoardSize.TabIndex = 3
        Me.grpBoardSize.TabStop = False
        Me.grpBoardSize.Text = "Board Size"
        Me.grpBoardSize.Visible = False
        '
        'radNineteen
        '
        Me.radNineteen.AutoSize = True
        Me.radNineteen.Location = New System.Drawing.Point(7, 68)
        Me.radNineteen.Name = "radNineteen"
        Me.radNineteen.Size = New System.Drawing.Size(60, 17)
        Me.radNineteen.TabIndex = 2
        Me.radNineteen.TabStop = True
        Me.radNineteen.Text = "19 x 19"
        Me.radNineteen.UseVisualStyleBackColor = True
        '
        'radFifteen
        '
        Me.radFifteen.AutoSize = True
        Me.radFifteen.Location = New System.Drawing.Point(7, 44)
        Me.radFifteen.Name = "radFifteen"
        Me.radFifteen.Size = New System.Drawing.Size(60, 17)
        Me.radFifteen.TabIndex = 1
        Me.radFifteen.TabStop = True
        Me.radFifteen.Text = "15 x 15"
        Me.radFifteen.UseVisualStyleBackColor = True
        '
        'radTwelve
        '
        Me.radTwelve.AutoSize = True
        Me.radTwelve.Location = New System.Drawing.Point(7, 20)
        Me.radTwelve.Name = "radTwelve"
        Me.radTwelve.Size = New System.Drawing.Size(60, 17)
        Me.radTwelve.TabIndex = 0
        Me.radTwelve.TabStop = True
        Me.radTwelve.Text = "12 x 12"
        Me.radTwelve.UseVisualStyleBackColor = True
        '
        'grpPlayerMode
        '
        Me.grpPlayerMode.Controls.Add(Me.radComputerVsComputer)
        Me.grpPlayerMode.Controls.Add(Me.radPlayerVsComputer)
        Me.grpPlayerMode.Controls.Add(Me.radPlayerVsPlayer)
        Me.grpPlayerMode.Location = New System.Drawing.Point(198, 25)
        Me.grpPlayerMode.Name = "grpPlayerMode"
        Me.grpPlayerMode.Size = New System.Drawing.Size(215, 105)
        Me.grpPlayerMode.TabIndex = 4
        Me.grpPlayerMode.TabStop = False
        Me.grpPlayerMode.Text = "Player Mode"
        Me.grpPlayerMode.Visible = False
        '
        'radComputerVsComputer
        '
        Me.radComputerVsComputer.AutoSize = True
        Me.radComputerVsComputer.Location = New System.Drawing.Point(7, 68)
        Me.radComputerVsComputer.Name = "radComputerVsComputer"
        Me.radComputerVsComputer.Size = New System.Drawing.Size(135, 17)
        Me.radComputerVsComputer.TabIndex = 2
        Me.radComputerVsComputer.TabStop = True
        Me.radComputerVsComputer.Text = "Computer vs. Computer"
        Me.radComputerVsComputer.UseVisualStyleBackColor = True
        '
        'radPlayerVsComputer
        '
        Me.radPlayerVsComputer.AutoSize = True
        Me.radPlayerVsComputer.Location = New System.Drawing.Point(7, 44)
        Me.radPlayerVsComputer.Name = "radPlayerVsComputer"
        Me.radPlayerVsComputer.Size = New System.Drawing.Size(119, 17)
        Me.radPlayerVsComputer.TabIndex = 1
        Me.radPlayerVsComputer.TabStop = True
        Me.radPlayerVsComputer.Text = "Player vs. Computer"
        Me.radPlayerVsComputer.UseVisualStyleBackColor = True
        '
        'radPlayerVsPlayer
        '
        Me.radPlayerVsPlayer.AutoSize = True
        Me.radPlayerVsPlayer.Location = New System.Drawing.Point(7, 20)
        Me.radPlayerVsPlayer.Name = "radPlayerVsPlayer"
        Me.radPlayerVsPlayer.Size = New System.Drawing.Size(103, 17)
        Me.radPlayerVsPlayer.TabIndex = 0
        Me.radPlayerVsPlayer.TabStop = True
        Me.radPlayerVsPlayer.Text = "Player vs. Player"
        Me.radPlayerVsPlayer.UseVisualStyleBackColor = True
        '
        'btnPlayNow
        '
        Me.btnPlayNow.Location = New System.Drawing.Point(160, 247)
        Me.btnPlayNow.Name = "btnPlayNow"
        Me.btnPlayNow.Size = New System.Drawing.Size(85, 40)
        Me.btnPlayNow.TabIndex = 5
        Me.btnPlayNow.Text = "Begin!"
        Me.btnPlayNow.UseVisualStyleBackColor = True
        Me.btnPlayNow.Visible = False
        '
        'btnCancelGame
        '
        Me.btnCancelGame.Location = New System.Drawing.Point(251, 247)
        Me.btnCancelGame.Name = "btnCancelGame"
        Me.btnCancelGame.Size = New System.Drawing.Size(85, 40)
        Me.btnCancelGame.TabIndex = 6
        Me.btnCancelGame.Text = "Cancel Game"
        Me.btnCancelGame.UseVisualStyleBackColor = True
        Me.btnCancelGame.Visible = False
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(198, 174)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(100, 32)
        Me.btnAbout.TabIndex = 7
        Me.btnAbout.Text = "&About"
        Me.btnAbout.UseVisualStyleBackColor = True
        Me.btnAbout.Visible = False
        '
        'btnHowToPlay
        '
        Me.btnHowToPlay.Location = New System.Drawing.Point(198, 136)
        Me.btnHowToPlay.Name = "btnHowToPlay"
        Me.btnHowToPlay.Size = New System.Drawing.Size(100, 32)
        Me.btnHowToPlay.TabIndex = 8
        Me.btnHowToPlay.Text = "&How to Play"
        Me.btnHowToPlay.UseVisualStyleBackColor = True
        Me.btnHowToPlay.Visible = False
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnHowToPlay)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnCancelGame)
        Me.Controls.Add(Me.grpBoardSize)
        Me.Controls.Add(Me.btnPlayNow)
        Me.Controls.Add(Me.grpPlayerMode)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnStartGame)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpBoardSize.ResumeLayout(False)
        Me.grpBoardSize.PerformLayout()
        Me.grpPlayerMode.ResumeLayout(False)
        Me.grpPlayerMode.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents tmrTextSlideStart As Timer
    Friend WithEvents tmrTextSlide As Timer
    Friend WithEvents btnStartGame As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents grpBoardSize As GroupBox
    Friend WithEvents grpPlayerMode As GroupBox
    Friend WithEvents radNineteen As RadioButton
    Friend WithEvents radFifteen As RadioButton
    Friend WithEvents radTwelve As RadioButton
    Friend WithEvents radComputerVsComputer As RadioButton
    Friend WithEvents radPlayerVsComputer As RadioButton
    Friend WithEvents radPlayerVsPlayer As RadioButton
    Friend WithEvents btnPlayNow As Button
    Friend WithEvents btnCancelGame As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnHowToPlay As Button
End Class
