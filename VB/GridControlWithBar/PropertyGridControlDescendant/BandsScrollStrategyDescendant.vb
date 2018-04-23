Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraVerticalGrid
Imports DevExpress.XtraVerticalGrid.ViewInfo

Namespace GridControlWithBar
	Public Class BandsScrollStrategyDescendant
		Inherits BandsScrollStrategy
		Public Sub New(ByVal viewInfo As BaseViewInfo)
			MyBase.New(viewInfo)

		End Sub
		Public Overrides Function GetCorrectTopIndex(ByVal scrollRectHeight As Integer, ByVal value As Integer) As Integer

			Return MyBase.GetCorrectTopIndex(scrollRectHeight - (TryCast(ViewInfo.Grid, PropertyGridControlDescendant)).BarHeight, value)
		End Function
	End Class
End Namespace
