Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors

Namespace GridControlWithBar
	Public Class VGridScrollerDescendant
		Inherits VGridScroller
		Public Sub New(ByVal grid As VGridControlBase)
			MyBase.New(grid)
			Me.Grid = grid
		End Sub
		Private Grid As VGridControlBase
		Protected Overrides Function CreateScrollStrategy() As VGridScrollStrategy
			If Grid IsNot Nothing Then

				Select Case CType(Grid.Tag, LayoutViewStyle)
					Case LayoutViewStyle.SingleRecordView
						Return New SingleRecordScrollStrategyDescendant(Grid.ViewInfo)
					Case LayoutViewStyle.MultiRecordView
						Return New MultiRecordScrollStrategyDescendant(Grid.ViewInfo)
					Case LayoutViewStyle.BandsView
						Return New BandsScrollStrategyDescendant(Grid.ViewInfo)
					Case Else
						Throw New ApplicationException("Illegal layout view style.")
				End Select
			End If
			Return MyBase.CreateScrollStrategy()
		End Function
		Protected Overrides Sub Update()
			Try

				UpdateHScrollBar()
				UpdateVScrollBar()
				Dim newRect As Rectangle = Me.Grid.DisplayRectangle
				newRect.Width -= 2
				newRect.Y += (TryCast(Grid, PropertyGridControlDescendant)).BarHeight
				newRect.Height -= 34
				ScrollInfo.UpdateScrollerLocation(newRect)
				Dim leftRecord As Integer = LeftVisibleRecord, topRowIndex As Integer = TopVisibleRowIndex
				LeftVisibleRecord = leftRecord
				TopVisibleRowIndex = topRowIndex
				If leftRecord <> LeftVisibleRecord OrElse topRowIndex <> TopVisibleRowIndex Then
					Grid.LayoutChanged()
				End If
			Finally
			End Try
		End Sub
		Protected Sub UpdateVScrollBar()

				ScrollInfo.VScrollVisible = scrollStrategy.IsNeededVScrollBar(Me.Grid.DisplayRectangle.Height)


				Dim n As Integer = scrollStrategy.GetVScrollLargeChange(CInt(Fix(Grid.ViewInfo.ViewRects.Client.Height)))
				If n < 1 Then
					n = 1
				End If
				Dim args As New ScrollArgs()
				args.Maximum = Math.Max(0, Grid.NotFixedRows.Count)
				args.Value = TopVisibleRowIndex+1
				args.LargeChange = n
				If (Not args.IsEquals(ScrollInfo.VScrollArgs)) Then
					args.AssignTo(ScrollInfo.VScroll)
				End If
		End Sub

	End Class
End Namespace
