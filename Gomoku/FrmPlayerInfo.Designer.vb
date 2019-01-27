<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlayerInfo
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
        Me.mnuPlayerOne = New System.Windows.Forms.MenuStrip()
        Me.mnuPlayerOneAction = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlayerOneResign = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstPlayerOneMoveList = New System.Windows.Forms.ListBox()
        Me.mnuPlayerOne.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPlayerOne
        '
        Me.mnuPlayerOne.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlayerOneAction})
        Me.mnuPlayerOne.Location = New System.Drawing.Point(0, 0)
        Me.mnuPlayerOne.Name = "mnuPlayerOne"
        Me.mnuPlayerOne.Size = New System.Drawing.Size(284, 24)
        Me.mnuPlayerOne.TabIndex = 0
        Me.mnuPlayerOne.Text = "MenuStrip1"
        '
        'mnuPlayerOneAction
        '
        Me.mnuPlayerOneAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlayerOneResign})
        Me.mnuPlayerOneAction.Name = "mnuPlayerOneAction"
        Me.mnuPlayerOneAction.Size = New System.Drawing.Size(54, 20)
        Me.mnuPlayerOneAction.Text = "&Action"
        '
        'mnuPlayerOneResign
        '
        Me.mnuPlayerOneResign.Name = "mnuPlayerOneResign"
        Me.mnuPlayerOneResign.Size = New System.Drawing.Size(152, 22)
        Me.mnuPlayerOneResign.Text = "&Resign"
        '
        'lstPlayerOneMoveList
        '
        Me.lstPlayerOneMoveList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPlayerOneMoveList.FormattingEnabled = True
        Me.lstPlayerOneMoveList.Location = New System.Drawing.Point(0, 24)
        Me.lstPlayerOneMoveList.Name = "lstPlayerOneMoveList"
        Me.lstPlayerOneMoveList.Size = New System.Drawing.Size(284, 337)
        Me.lstPlayerOneMoveList.TabIndex = 1
        '
        'frmPlayerOne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 361)
        Me.Controls.Add(Me.lstPlayerOneMoveList)
        Me.Controls.Add(Me.mnuPlayerOne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MainMenuStrip = Me.mnuPlayerOne
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPlayerOne"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Player One - Name Here"
        Me.TopMost = True
        Me.mnuPlayerOne.ResumeLayout(False)
        Me.mnuPlayerOne.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuPlayerOne As MenuStrip
    Friend WithEvents mnuPlayerOneAction As ToolStripMenuItem
    Friend WithEvents mnuPlayerOneResign As ToolStripMenuItem
    Friend WithEvents lstPlayerOneMoveList As ListBox
End Class
