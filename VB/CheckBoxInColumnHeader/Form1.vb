Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.ViewInfo
Imports DevExpress.XtraTreeList.Nodes.Operations
Imports DevExpress.XtraTreeList.Nodes

Namespace CheckBoxInColumnHeader
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private checkEdit As RepositoryItemCheckEdit
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim TempXViews As DevExpress.XtraTreeList.Design.XViews = New DevExpress.XtraTreeList.Design.XViews(treeList1)
			treeList1.OptionsSelection.MultiSelect = True
			checkEdit = CType(treeList1.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)
		End Sub


		Protected Sub DrawCheckBox(ByVal g As Graphics, ByVal edit As RepositoryItemCheckEdit, ByVal r As Rectangle, ByVal Checked As Boolean)
			Dim info As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo
			Dim painter As DevExpress.XtraEditors.Drawing.CheckEditPainter
			Dim args As DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs
			info = TryCast(edit.CreateViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
			painter = TryCast(edit.CreatePainter(), DevExpress.XtraEditors.Drawing.CheckEditPainter)
			info.EditValue = Checked
			info.Bounds = r
			info.CalcViewInfo(g)
			args = New DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, New DevExpress.Utils.Drawing.GraphicsCache(g), r)
			painter.Draw(args)
			args.Cache.Dispose()
		End Sub

		Private Sub treeList1_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CustomDrawColumnHeaderEventArgs) Handles treeList1.CustomDrawColumnHeader
			If e.Column IsNot Nothing AndAlso e.Column.VisibleIndex = 0 Then
				Dim checkRect As New Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 12, 12)
				Dim info As ColumnInfo = CType(e.ObjectArgs, ColumnInfo)
				If info.CaptionRect.Left < 30 Then
					info.CaptionRect = New Rectangle(New Point(info.CaptionRect.Left + 15, info.CaptionRect.Top), info.CaptionRect.Size)
				End If
				e.Painter.DrawObject(info)

				DrawCheckBox(e.Graphics, checkEdit, checkRect, IsAllSelected(TryCast(sender, TreeList)))
				e.Handled = True
			End If
		End Sub

		Private Function IsAllSelected(ByVal tree As TreeList) As Boolean
			Return tree.Selection.Count > 0 AndAlso tree.Selection.Count = tree.AllNodesCount
		End Function

		Private Sub treeList1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles treeList1.MouseUp
			Dim tree As TreeList = TryCast(sender, TreeList)
			Dim pt As New Point(e.X, e.Y)
			Dim hit As TreeListHitInfo = tree.CalcHitInfo(pt)
			If hit.Column IsNot Nothing Then
				Dim info As ColumnInfo = tree.ViewInfo.ColumnsInfo(hit.Column)
				Dim checkRect As New Rectangle(info.Bounds.Left + 3, info.Bounds.Top + 3, 12, 12)
				If checkRect.Contains(pt) Then
					EmbeddedCheckBoxChecked(tree)
					Throw New DevExpress.Utils.HideException()
				End If
			End If
		End Sub

		Private Sub EmbeddedCheckBoxChecked(ByVal tree As TreeList)
			If IsAllSelected(tree) Then
				tree.Selection.Clear()
			Else
				SelectAll(tree)
			End If
		End Sub

		Private Class SelectNodeOperation
			Inherits TreeListOperation
			Public Overrides Sub Execute(ByVal node As TreeListNode)
				node.Selected = True
			End Sub
		End Class

		Private Sub SelectAll(ByVal tree As TreeList)
			tree.BeginUpdate()
			tree.NodesIterator.DoOperation(New SelectNodeOperation())
			tree.EndUpdate()
		End Sub

		Private Sub treeList1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles treeList1.SelectionChanged
			treeList1.InvalidateColumnPanel()
		End Sub
	End Class
End Namespace