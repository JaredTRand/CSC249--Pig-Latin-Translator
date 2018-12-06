<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.ButtonShh = New System.Windows.Forms.Button()
        Me.ButtonShh2 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ButtonShh
        '
        Me.ButtonShh.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonShh.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.ButtonShh.FlatAppearance.BorderSize = 0
        Me.ButtonShh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonShh.Location = New System.Drawing.Point(948, 599)
        Me.ButtonShh.Name = "ButtonShh"
        Me.ButtonShh.Size = New System.Drawing.Size(88, 25)
        Me.ButtonShh.TabIndex = 5
        Me.ButtonShh.UseVisualStyleBackColor = False
        '
        'ButtonShh2
        '
        Me.ButtonShh2.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonShh2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.ButtonShh2.FlatAppearance.BorderSize = 0
        Me.ButtonShh2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonShh2.Location = New System.Drawing.Point(949, 599)
        Me.ButtonShh2.Name = "ButtonShh2"
        Me.ButtonShh2.Size = New System.Drawing.Size(88, 25)
        Me.ButtonShh2.TabIndex = 6
        Me.ButtonShh2.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 31
        Me.ListBox1.Items.AddRange(New Object() {"THERES NOTHING HERE, GO BACK"})
        Me.ListBox1.Location = New System.Drawing.Point(245, 191)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(499, 407)
        Me.ListBox1.TabIndex = 8
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 626)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ButtonShh2)
        Me.Controls.Add(Me.ButtonShh)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonShh As Button
    Friend WithEvents ButtonShh2 As Button
    Friend WithEvents ListBox1 As ListBox
End Class
