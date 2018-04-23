Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace GridControlWithBar
	Public Class CustomButtonsEventArgs
		Inherits EventArgs
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Public Sub New(ByVal _name As String)
			Name = _name
		End Sub
	End Class
End Namespace
