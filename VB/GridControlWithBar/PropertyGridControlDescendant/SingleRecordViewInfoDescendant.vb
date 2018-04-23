Imports Microsoft.VisualBasic
Imports System.Drawing
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.ViewInfo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Drawing
Imports System
Imports System.Collections.Generic



Namespace GridControlWithBar
	Public Class SingleRecordViewInfoDescendant
		Inherits SingleRecordViewInfo
		Public Sub New(ByVal grid As VGridControlBase, ByVal isPrinting As Boolean)
			MyBase.New(grid, isPrinting)

		End Sub



		Protected Overrides Sub CreateBand(ByVal bandHeight As Integer, ByVal bandWidth As Integer)
			Dim left As Integer = (If(ViewRects.BandRects.Count = 0, ViewRects.Client.Left, (CType(ViewRects.BandRects(ViewRects.BandRects.Count - 1), Rectangle)).Right))
			Dim br As New Rectangle(left, ViewRects.Client.Top + (TryCast(Grid, PropertyGridControlDescendant)).BarHeight, bandWidth, Math.Min(bandHeight, ViewRects.Client.Height))
			ViewRects.BandRects.Add(br)

		End Sub

	End Class
End Namespace

