'========================================================================
' This conversion was produced by the Free Edition of
' Instant VB courtesy of Tangible Software Solutions.
' Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
'========================================================================

Namespace CheckBoxInColumnHeader
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.Size = New System.Drawing.Size(509, 409)
			Me.treeList1.TabIndex = 0
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.treeList1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseUp);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.treeList1.SelectionChanged += new System.EventHandler(this.treeList1_SelectionChanged);
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.treeList1.CustomDrawColumnHeader += new DevExpress.XtraTreeList.CustomDrawColumnHeaderEventHandler(this.treeList1_CustomDrawColumnHeader);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(509, 409)
			Me.Controls.Add(Me.treeList1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private WithEvents treeList1 As DevExpress.XtraTreeList.TreeList
	End Class
End Namespace

