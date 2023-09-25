Namespace DXApplication3

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.customGrid1 = New DXApplication3.CustomGrid()
            Me.customGridView1 = New DXApplication3.CustomGridView()
            CType((Me.customGrid1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.customGridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' customGrid1
            ' 
            Me.customGrid1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.customGrid1.Location = New System.Drawing.Point(0, 0)
            Me.customGrid1.MainView = Me.customGridView1
            Me.customGrid1.Name = "customGrid1"
            Me.customGrid1.Size = New System.Drawing.Size(632, 278)
            Me.customGrid1.TabIndex = 0
            Me.customGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.customGridView1})
            ' 
            ' customGridView1
            ' 
            Me.customGridView1.GridControl = Me.customGrid1
            Me.customGridView1.Name = "customGridView1"
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(632, 278)
            Me.Controls.Add(Me.customGrid1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.customGrid1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.customGridView1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private customGrid1 As DXApplication3.CustomGrid

        Private customGridView1 As DXApplication3.CustomGridView
    End Class
End Namespace
