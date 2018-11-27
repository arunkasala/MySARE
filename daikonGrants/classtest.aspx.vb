Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Text

Imports UrlQuery


Namespace daikon

	Partial Class classtest
		Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

		'This call is required by the Web Form Designer.
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

		End Sub


		Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
			'CODEGEN: This method call is required by the Web Form Designer
			'Do not modify it using the code editor.
			InitializeComponent()
		End Sub

#End Region

		Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			'Put user code to initialize the page here
			Dim testSection As DaikonGrantReportSection
			Dim testSubSection As DaikonGrantReportSubSection
			Dim testReport As DaikonGrantReport
			Dim testProject As DaikonGrant

			If TypeOf Session.Item("currReport") Is DaikonGrantReport Then
				testReport = Session.Item("currReport")
				'			Response.Write(testReport.getEditLink() & "<br>")
			End If

			Dim tempsub1 As DaikonGrantReportSubSection
			Dim tempsub2 As DaikonGrantReportSubSection
			Dim tempsub3 As DaikonGrantReportSubSection
			Dim tempsub4 As DaikonGrantReportSubSection

			Dim writerString As New StringWriter

			Dim tempXmlWriter As New XmlTextWriter(writerString)
			'(Response.Output)	   '(tempStream, Encoding.UTF8)
			tempXmlWriter.Formatting = Formatting.Indented

			'testReport = New DaikonGrantReport(1998, 0, True, Today(), Today())
			'testSection = New DaikonGrantReportSection(4, 1, "Findings")

			'tempsub1 = New DaikonGrantReportSubSection(12, "Sub Header", "Filler String Duodeca", 2, 1)
			'testSection.addSubSection(tempsub1)

			'tempsub2 = New DaikonGrantReportSubSection(8, "", "Filler String Hachi", 4, 1)
			'testSection.addSubSection(tempsub2)

			'tempsub3 = New DaikonGrantReportSubSection(17, "", "Filler String 17", 3, 1)
			'testSection.addSubSection(tempsub3)

			'tempsub4 = New DaikonGrantReportSubSection(5, "", "Filler String Man", 1, 1)
			'testSection.addSubSection(tempsub4)

			'testReport.addSection(testSection)

            testProject = New DaikonGrant("ENE98-037", Application("sareDaikonConnectionString"))
            '		testReport = New DaikonGrantReport("ENE98-888", 2000, 1, Application("sareDaikonConnectionString"))

			'		Session.Add("currReport", testReport)

			testProject.toXml(tempXmlWriter)
			'testProject.toXmlReport(1998, 2, tempXmlWriter)

			'		testReport.toXML(tempXmlWriter)
			'	tempsub1.toXML(tempXmlWriter)

			tempXmlWriter.Flush()

			'		Response.Write(vbCrLf & "Test: " & (tempsub1.CompareTo(1)).ToString())
			'		Response.Write(testSection.toHTML())
			'			Response.Write(tempXmlWriter.ToString())

			Dim readerString As New StringReader(writerString.ToString())

			'			Response.Write(vbCrLf & "XML Output: " & vbCrLf & writerString.ToString())

			Dim xmlDoc As XmlDocument = New XmlDocument
			xmlDoc.Load(readerString)

			Dim xmlTransform As XslCompiledTransform = New XslCompiledTransform
			xmlTransform.Load(MapPath(Page.TemplateSourceDirectory) & "/project2.xsl")
			xmlTransform.Transform(xmlDoc, Nothing, Response.OutputStream)

		End Sub

	End Class

End Namespace
