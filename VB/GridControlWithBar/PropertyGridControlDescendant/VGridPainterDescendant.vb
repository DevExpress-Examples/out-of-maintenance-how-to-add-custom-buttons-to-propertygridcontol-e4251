Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraVerticalGrid.Painters
Imports DevExpress.XtraVerticalGrid.ViewInfo

Namespace GridControlWithBar
	Public Class VGridPainterDescendant
		Inherits VGridPainter
		Public Sub New(ByVal eventHelper As DevExpress.XtraVerticalGrid.Painters.PaintEventHelper)
			MyBase.New(eventHelper)

		End Sub

		Protected Overrides Sub DoDrawCore(ByVal vi As DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo)
			MyBase.DoDrawCore(vi)
			DrawButton(vi)

		End Sub
		Protected Sub DrawButton(ByVal vi As BaseViewInfo)
			If (CType(vi.Grid, PropertyGridControlDescendant)).ButtonInfoList IsNot Nothing Then
			For Each info As EditorButtonObjectInfoArgs In (CType(vi.Grid, PropertyGridControlDescendant)).ButtonInfoList
				If info IsNot Nothing Then
					Dim painter As EditorButtonPainter = EditorButtonHelper.GetPainter(BorderStyles.Default)
					info.Cache = Me.DrawInfo.Cache
					painter.DrawObject(info)
				End If
			Next info
			End If
		End Sub


	End Class
End Namespace
