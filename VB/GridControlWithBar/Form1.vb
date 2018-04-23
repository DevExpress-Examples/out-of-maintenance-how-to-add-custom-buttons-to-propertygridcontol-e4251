Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace GridControlWithBar
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			propertyGridControlDescendant1.SelectedObject = propertyGridControlDescendant1
			propertyGridControlDescendant1.AddButton("Alphabetical")
			propertyGridControlDescendant1.AddButton("ImageAlphabetical", GetImageByName("Alphabetical.png"))
			propertyGridControlDescendant1.AddButton("Categorized")
			propertyGridControlDescendant1.AddButton("ImageCategorized", GetImageByName("Categorized.png"))

			AddHandler propertyGridControlDescendant1.CustomButtonHited, AddressOf propertyGridControlDescendant1_CustomButtonHited
		End Sub

		Private Sub propertyGridControlDescendant1_CustomButtonHited(ByVal sendet As Object, ByVal e As CustomButtonsEventArgs)
			If e.Name = "Alphabetical" OrElse e.Name = "ImageAlphabetical" Then
				propertyGridControlDescendant1.OptionsView.ShowRootCategories = False
			End If
			If e.Name = "Categorized" OrElse e.Name = "ImageCategorized" Then
				propertyGridControlDescendant1.OptionsView.ShowRootCategories = True
			End If
		End Sub

		Private Function GetImageByName(ByVal imageName As String) As Image
			Return Image.FromStream(Me.GetType().Assembly.GetManifestResourceStream(String.Format("GridControlWithBar.{0}", imageName)))
		End Function
	End Class
End Namespace
