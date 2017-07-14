Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextControl1 As TXTextControl.TextControl
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TextControl1 = New TXTextControl.TextControl()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.SuspendLayout()
        '
        'TextControl1
        '
        Me.TextControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextControl1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextControl1.Location = New System.Drawing.Point(0, 0)
        Me.TextControl1.Name = "TextControl1"
        Me.TextControl1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextControl1.Size = New System.Drawing.Size(1001, 365)
        Me.TextControl1.TabIndex = 0
        Me.TextControl1.Text = "TextControl1"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem5, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Table"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Insert..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.Text = "Resize Tables"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "-"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1001, 365)
        Me.Controls.Add(Me.TextControl1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Table Resize Sample"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Application.ExitThread()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        TextControl1.Tables.Add(3, 4)
    End Sub

    Private Sub resizeTable(ByVal _table As TXTextControl.Table)
        Dim columns As Integer = _table.Columns.Count
        Dim rows As Integer = _table.Rows.Count

        TextControl1.PageUnit = TXTextControl.MeasuringUnit.Twips

        For i As Integer = 1 To rows
            Dim curWidth As Integer = 0

            For e As Integer = 1 To columns
                curWidth += _table.Cells.GetItem(i, e).Width()
            Next

            ' calculate the currently available page width for the first section.
            Dim txWidth As Integer = (TextControl1.Sections(1).Format.PageSize.Width _
            - TextControl1.Sections(1).Format.PageMargins.Left _
            - TextControl1.Sections(1).Format.PageMargins.Right
              )

            ' get the difference between the current table width and the available page width
            Dim percentageDelta As Double = (txWidth / curWidth)

            ' resize the 
            For e As Integer = 1 To columns
                _table.Cells.GetItem(i, e).Width = _table.Cells.GetItem(i, e).Width * percentageDelta
            Next
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextControl1.Load("default.rtf", TXTextControl.StreamType.RichTextFormat)
    End Sub

    Private Sub MenuItem5_Click(sender As Object, e As EventArgs) Handles MenuItem5.Click
        For Each table As TXTextControl.Table In TextControl1.Tables
            resizeTable(table)
        Next
    End Sub
End Class