Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.Painters

Namespace GridControlWithBar
	Public Class PropertyGridControlDescendant
		Inherits PropertyGridControl
		Public Sub New()

			fButtonList = New List(Of EditorButton)()

		End Sub

		Public VGridPainter As VGridPainterDescendant

		Public Sub AddButton(ByVal NameAndCaption As String)
			Dim Button As New EditorButton()
			Button.Kind = ButtonPredefines.Glyph
			Button.Caption = NameAndCaption
			Button.Tag = NameAndCaption
			Button.Width = TextRenderer.MeasureText(NameAndCaption, DefaultFont).Width
			ButtonList.Add(Button)
			CalcButtonInfo()

		End Sub
		Public Sub AddButton(ByVal Name As String, ByVal image As Image)
			Dim Button As New EditorButton()
			Button.Kind = ButtonPredefines.Glyph
			Button.Image = image
			Button.Tag = Name
			If image.HorizontalResolution > 60 Then
				Button.Width = 60
			Else
				Button.Width = CInt(Fix(image.HorizontalResolution))
			End If
			ButtonList.Add(Button)
			CalcButtonInfo()

		End Sub
		Public BarHeight As Integer = 30
		Public fButtonList As List(Of EditorButton)
		Private ReadOnly Property ButtonList() As List(Of EditorButton)
			Get
				Return fButtonList
			End Get
		End Property
		Public ButtonInfoList As List(Of EditorButtonObjectInfoArgs)
		Public Delegate Sub CustomButtonHitedHandler(ByVal sendet As Object, ByVal e As CustomButtonsEventArgs)
		Public Event CustomButtonHited As CustomButtonHitedHandler
		Public Overridable Sub OnCustomButtonHited(ByVal e As CustomButtonsEventArgs)
			RaiseEvent CustomButtonHited(Me, e)
		End Sub

		Private buttonInfo_Renamed As EditorButtonObjectInfoArgs
		Friend ReadOnly Property ButtonInfo() As EditorButtonObjectInfoArgs
			Get
				Return buttonInfo_Renamed
			End Get
		End Property

		Protected Overridable Sub CalcButtonInfo()
			If ButtonInfoList Is Nothing Then
				ButtonInfoList = New List(Of EditorButtonObjectInfoArgs)()
			End If
			ButtonInfoList.Clear()
			If ButtonList IsNot Nothing Then
				If ButtonList.Count > 0 Then
					For Each EB As EditorButton In ButtonList
						buttonInfo_Renamed = New EditorButtonObjectInfoArgs(EB, EB.Appearance)
						Dim rect As New Rectangle(2, 2, EB.Width, BarHeight)
						If ButtonInfoList.Count > 0 Then
							Dim PrevButton As EditorButtonObjectInfoArgs = ButtonInfoList(ButtonInfoList.Count - 1)
							rect = New Rectangle(2 + PrevButton.Bounds.Width + PrevButton.Bounds.X, 2, EB.Width, BarHeight)
						End If
						buttonInfo_Renamed.Bounds = rect
						ButtonInfoList.Add(buttonInfo_Renamed)
					Next EB
				End If
			End If
		End Sub



		#Region "ClassDescendants"
		Protected Overrides Function CreateScroller() As VGridScroller
			Return New VGridScrollerDescendant(Me)
		End Function

		Protected Overrides Function CreatePainterCore(ByVal eventHelper As DevExpress.XtraVerticalGrid.Painters.PaintEventHelper) As DevExpress.XtraVerticalGrid.Painters.VGridPainter
			Return New VGridPainterDescendant(eventHelper)
		End Function

		Protected Overrides Function CreateViewInfo(ByVal isPrinting As Boolean) As DevExpress.XtraVerticalGrid.ViewInfo.BaseViewInfo
			Me.Tag = LayoutStyle
			If LayoutStyle = LayoutViewStyle.SingleRecordView Then
				Return New SingleRecordViewInfoDescendant(Me, isPrinting)
			End If
			If LayoutStyle = LayoutViewStyle.MultiRecordView Then
				Return New MultiRecordViewInfoDescendant(Me, isPrinting)
			End If
			Return New BandsViewInfoDescendant(Me, isPrinting)
		End Function

		#End Region




		Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
			MyBase.OnMouseDown(e)
			For Each info As EditorButtonObjectInfoArgs In ButtonInfoList
				If ButtonHited(e.Location) Is info.Button.Tag Then
					info.State = ObjectState.Pressed
					Me.Invalidate(info.Bounds)
				End If
			Next info
			If ButtonHited(e.Location) IsNot Nothing Then
			OnCustomButtonHited(New CustomButtonsEventArgs(CStr(ButtonHited(e.Location))))
			End If

		End Sub

		Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)

			MyBase.OnMouseMove(e)
			CustomButtonHotTrack(e)
		End Sub


		Private Sub CustomButtonHotTrack(ByVal e As System.Windows.Forms.MouseEventArgs)
			If ButtonInfoList IsNot Nothing Then
			For Each info As EditorButtonObjectInfoArgs In ButtonInfoList
				If ButtonHited(e.Location) Is info.Button.Tag Then
					info.State = ObjectState.Hot
					Me.Invalidate(info.Bounds)

				Else
					info.State = ObjectState.Normal
					Me.Invalidate(info.Bounds)
				End If
			Next info
			End If
		End Sub


		Protected Function ButtonHited(ByVal location As Point) As Object
			If ButtonInfoList Is Nothing Then
				Return False
			End If
			For Each info As EditorButtonObjectInfoArgs In ButtonInfoList
				If info.Bounds.Contains(location) Then
					Return info.Button.Tag
				End If
			Next info
			Return Nothing
		End Function

	End Class
End Namespace
