Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.XtraPivotGrid
Imports System.ComponentModel
Imports System.IO

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim ds As PivotDrillDownDataSource = ASPxPivotGrid1.CreateDrillDownDataSource(0, 0)
		Dim props As PropertyDescriptorCollection = (CType(ds, ITypedList)).GetItemProperties(Nothing)

		Dim table As New DataTable("drilldown")
		For i As Integer = 0 To props.Count - 1
			table.Columns.Add(props(i).Name, props(i).PropertyType)
		Next i
		Dim row(props.Count - 1) As Object
		For i As Integer = 0 To ds.RowCount - 1
			For j As Integer = 0 To props.Count - 1
				row(j) = ds.GetValue(i, j)
			Next j
			table.Rows.Add(row)
		Next i
		Using writer As New StringWriter()
			table.WriteXml(writer, XmlWriteMode.WriteSchema)
			Session("drilldown") = writer.ToString()
		End Using
	End Sub
	Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
		Dim serializedXml As String = TryCast(Session("drilldown"), String)
		If String.IsNullOrEmpty(serializedXml) Then
			Return
		End If
		Dim table As New DataTable()
		Using reader As New StringReader(serializedXml)
			table.ReadXml(reader)
		End Using
	End Sub
End Class
