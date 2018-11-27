Imports System
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Configuration
Imports System.Web


Public Class DaikonGrantReportSection
    Implements IComparable

    Protected sectID As Integer
    Protected order As Integer
    Protected name As String
    Protected subsectionList As SortedList

    Public Property SectionID() As Integer
        Get
            Return SectionID
        End Get
        Set(ByVal value As Integer)
            sectID = value
        End Set
    End Property
    Public Property Subsections() As SortedList
        Get
            Return subsectionList
        End Get
        Set(ByVal value As SortedList)
            subsectionList = value
        End Set
    End Property
    Public Property SectionName() As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            name = value
        End Set
    End Property
    Public Property SectionOrder() As Integer
        Get
            Return order
        End Get
        Set(ByVal value As Integer)
            order = value
        End Set
    End Property
    Public ReadOnly Property MaxSubSection() As Integer
        Get
            Return subsectionList.GetKeyList.Item(subsectionList.GetKeyList.Count())
        End Get
    End Property

    Public Sub New(ByVal section As Integer, ByVal sectionOrder As Integer, ByVal sectionName As String)
        sectID = section
        order = sectionOrder
        name = sectionName
        subsectionList = New SortedList
    End Sub

    Public Sub UpdateSub(ByVal subsection_uid_in As Integer, ByVal sub_heading_in As String, ByVal sub_text_in As String, ByVal subsection_order_in As Integer, ByVal subsection_type_in As Integer)
        '            subsectionList.GetByIndex(subsectionList.IndexOfKey(subsection_order_in)).Update(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
        subsectionList(subsection_order_in).Update(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
    End Sub

    Public Function getKeyID() As Integer
        getKeyID = sectID
    End Function

    Public Sub addSubSection(ByVal newSubSection As DaikonGrantReportSubSection)
        Dim newSubSectionKey As Integer
        newSubSectionKey = newSubSection.getKeyID()       'getKeyIDs() & "," & newSubSection.getKeyIDs()
        If newSubSectionKey = 0 Then
            newSubSectionKey = 1
        End If
        Do While subsectionList.ContainsKey(newSubSectionKey)
            newSubSectionKey = newSubSectionKey + 1
        Loop
        subsectionList.Add(newSubSectionKey, newSubSection)
    End Sub

    Public Sub MoveSubsection(ByVal currentOrder As Integer, ByVal newOrder As Integer)
        Dim tempSubsection As DaikonGrantReportSubSection
        '           Dim tempList As SortedList

        '            tempSubsection = subsectionList.GetByIndex(subsectionList.IndexOfKey(currentOrder))
        If newOrder > 0 Then
            tempSubsection = subsectionList(currentOrder)
            tempSubsection.SubsectionOrder = newOrder
            '            tempList = subsectionList.Clone

            DeleteSubsection(currentOrder)
            InsertSubsection(tempSubsection)
        End If

        'Dirty? Yes. Two traversals of the list shouldn't be necessary.
    End Sub

    Public Sub InsertSubsection(ByVal newSubSection As DaikonGrantReportSubSection)
        Dim newSubSectionKey As Integer
        Dim currKeyCount As Integer
        currKeyCount = subsectionList.GetKeyList.Count()

        newSubSectionKey = newSubSection.getKeyID()       'getKeyIDs() & "," & newSubSection.getKeyIDs()
        newSubSection.SubsectionHasChanged = True
        If (newSubSectionKey = 0 Or newSubSectionKey > subsectionList.GetKeyList.Item(currKeyCount - 1)) Then
            newSubSectionKey = subsectionList.GetKeyList.Item(currKeyCount - 1) + 1
            newSubSection.SubsectionOrder = newSubSectionKey
            subsectionList.Add(newSubSectionKey, newSubSection)
        Else

            Dim tempList As SortedList
            tempList = New SortedList()

            Dim i As Integer

            If newSubSectionKey > 1 Then
                For i = 1 To (newSubSectionKey - 1)
                    tempList.Add(i, subsectionList.GetValueList(i - 1))
                    tempList(i).SubsectionOrder = i
                Next
            End If

            tempList.Add(newSubSectionKey, newSubSection)

            For i = (newSubSectionKey + 1) To currKeyCount + 1
                tempList.Add(i, subsectionList.GetValueList(i - 2))
                tempList(i).SubsectionOrder = i
            Next

            subsectionList = tempList
            '   Can't use this because it "mutates" the keys
            '                Dim i As Integer
            '               For i = subsectionList.GetKeyList.Count() To newSubSectionKey Step -1
            '                subsectionList.GetValueList(i).SubsectionOrder = i + 1
            '               subsectionList.GetKeyList(i) = i + 1
            '                Next
            '               subsectionList.Add(newSubSectionKey, newSubSection)
        End If

    End Sub

    Public Sub DeleteSubsection(ByVal subSectionKey As Integer)
        subsectionList.Remove(subSectionKey)

        CloseGaps()
    End Sub

    Public Sub DeleteSubsectionPerm(ByVal subSectionKey As Integer)
        subsectionList(subSectionKey).SubsectionHeading = ""
        subsectionList(subSectionKey).SubsectionText = ""
    End Sub

    Public Sub CloseGaps()
        Dim tempList As SortedList
        tempList = New SortedList()

        Dim i As Integer

        For i = 1 To subsectionList.GetKeyList.Count()
            tempList.Add(i, subsectionList.GetValueList(i - 1))
            tempList(i).SubsectionOrder = i
            tempList(i).SubsectionHasChanged = True
        Next

        subsectionList = tempList
    End Sub

    Public Function toHTML() As String

        Dim htmlHolder As String
        'Dim tempSubsection As DaikonGrantReportSubSection
        Dim i As Integer

        htmlHolder = "<p>" & vbCrLf
        htmlHolder = htmlHolder & "Section ID: " & sectID & vbCrLf

        '		For Each tempSubsection In subsections
        '		htmlHolder = htmlHolder & tempSubsection.toHTML()
        '		Next

        For i = 0 To subsectionList.Count - 1
            htmlHolder = htmlHolder & subsectionList.GetByIndex(i).toHTML()
        Next i

        toHTML = htmlHolder
    End Function

    Public Sub toXML(ByRef writer As XmlTextWriter)
        Dim i As Integer

        writer.WriteStartElement("section")
        writer.WriteAttributeString("ID", sectID)
        writer.WriteAttributeString("order", order)
        writer.WriteElementString("name", name)
        For i = 0 To subsectionList.Count - 1
            subsectionList.GetByIndex(i).toXML(writer)
        Next i
        writer.WriteEndElement()

    End Sub

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is DaikonGrantReportSection Then
            Dim temp As DaikonGrantReportSection = CType(obj, DaikonGrantReportSection)

            Return order.CompareTo(temp.order)
        ElseIf TypeOf obj Is Integer Then
            Return order.CompareTo(obj)
        End If

        Throw New ArgumentException("object is not a DaikonGrantReportSection or section order integer")
    End Function
    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal subsection As Integer, ByVal sareConnectionString As String)
        '            subsectionList.GetByIndex(subsectionList.IndexOfKey(subsection)).saveToDB(username, sessionKey, sareConnectionString)
        subsectionList(subsection).saveToDB(username, sessionKey, sareConnectionString)
    End Sub
    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal proj_num As String, ByVal rept_year As Integer, ByVal rept_isfinal As Integer, ByVal proj_type As Integer, ByVal sareConnectionString As String)
        Dim subsection As DaikonGrantReportSubSection
        For Each subsection In subsectionList.Values()
            subsection.saveToDB(username, sessionKey, proj_num, rept_year, rept_isfinal, proj_type, sectID, sareConnectionString)
        Next
    End Sub
    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String)
        Dim subsection As DaikonGrantReportSubSection
        For Each subsection In subsectionList.Values()
            subsection.saveToDB(username, sessionKey, sareConnectionString)
        Next
    End Sub

End Class

Public Class DaikonGrantReportSubSection
    Implements IComparable

    Protected subsection_uid As Integer
    Protected sub_heading As String
    Protected sub_text As String
    Protected subsection_order As Integer
    Protected subsection_type As Integer
    Protected hasChanged As Boolean
    Protected updatedDate As DateTime
    Protected updatedBy As String
    Protected createdDate As DateTime
    Protected createdBy As String
    Protected fileset As DaikonReportImageCollection

    Public Property SubsectionID() As Integer
        Get
            Return subsection_uid
        End Get
        Set(ByVal value As Integer)
            subsection_uid = value
        End Set
    End Property
    Public Property SubsectionHeading() As String
        Get
            Return sub_heading
        End Get
        Set(ByVal value As String)
            sub_heading = value
        End Set
    End Property
    Public Property SubsectionText() As String
        Get
            Return sub_text
        End Get
        Set(ByVal value As String)
            sub_text = value
        End Set
    End Property
    Public Property SubsectionOrder() As Integer
        Get
            Return subsection_order
        End Get
        Set(ByVal value As Integer)
            subsection_order = value
        End Set
    End Property
    Public Property SubsectionType() As Integer
        Get
            Return subsection_type
        End Get
        Set(ByVal value As Integer)
            subsection_type = value
        End Set
    End Property
    Public Property SubsectionHasChanged() As Boolean
        Get
            Return hasChanged
        End Get
        Set(ByVal value As Boolean)
            hasChanged = value
        End Set
    End Property
    Public Property Images() As DaikonReportImageCollection
        Get
            Return fileset
        End Get
        Set(ByVal value As DaikonReportImageCollection)
            fileset = value
        End Set
    End Property

    Public Sub New(ByVal subsection_uid_in As Integer, ByVal sub_heading_in As String, ByVal sub_text_in As String, ByVal subsection_order_in As Integer, ByVal subsection_type_in As Integer)
        subsection_uid = subsection_uid_in
        sub_heading = sub_heading_in
        sub_text = sub_text_in
        subsection_order = subsection_order_in
        subsection_type = subsection_type_in
        hasChanged = False
        fileset = New DaikonReportImageCollection(subsection_uid_in)

    End Sub
    Public Sub New()
        subsection_uid = 0
        sub_heading = ""
        sub_text = ""
        subsection_order = 0
        subsection_type = 0
        hasChanged = False
        fileset = New DaikonReportImageCollection()
    End Sub
    Public Sub Update(ByVal subsection_uid_in As Integer, ByVal sub_heading_in As String, ByVal sub_text_in As String, ByVal subsection_order_in As Integer, ByVal subsection_type_in As Integer)
        If subsection_uid_in <> -1 Then
            '		subsection_uid = subsection_uid_in
            '		hasChanged = True
        End If
        If sub_heading_in <> "-1" Then
            If String.Compare(sub_heading, sub_heading_in) <> 0 Then
                sub_heading = sub_heading_in
                hasChanged = True
            End If
        End If
        If sub_text_in <> "-1" Then
            If String.Compare(sub_text, sub_text_in) <> 0 Then
                sub_text = sub_text_in
                hasChanged = True
            End If
        End If
        If subsection_order_in <> -1 Then
            '		subsection_order = subsection_order_in
        End If
        If subsection_type_in <> -1 Then
            If subsection_type <> subsection_type_in Then
                subsection_type = subsection_type_in
                hasChanged = True
            End If
        End If

    End Sub

    Public Function getKeyID() As Integer
        getKeyID = subsection_order
    End Function

    Public Function getKeyIDstr() As String
        getKeyIDstr = subsection_order.ToString()
    End Function

    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal proj_num As String, ByVal rept_year As Integer, ByVal rept_isfinal As Integer, ByVal proj_type As Integer, ByVal sectionID As Integer, ByVal sareConnectionString As String)
        Dim subsectionSQL As String
        Dim subsectionConnection As SqlConnection
        Dim subsectionCommand As SqlCommand

        ' If condition is commented because their are cases like updating sub_text with empty string
        'If (Trim(sub_text).Length > 0) Then

            If subsection_uid = 0 Then
                subsectionSQL = "DaikonReportingTextSectionInsert"

                subsectionConnection = New SqlConnection(sareConnectionString)

                subsectionCommand = New SqlCommand
                subsectionCommand.Connection = subsectionConnection
                subsectionCommand.CommandText = subsectionSQL
                subsectionCommand.CommandType = CommandType.StoredProcedure

                subsectionCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
                subsectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

                subsectionCommand.Parameters.Add("@in_proj_num", SqlDbType.VarChar, 50).Value = proj_num
                subsectionCommand.Parameters.Add("@in_rept_year", SqlDbType.Int).Value = rept_year
                subsectionCommand.Parameters.Add("@in_rept_isfinal", SqlDbType.Int).Value = rept_isfinal
                subsectionCommand.Parameters.Add("@in_proj_type", SqlDbType.Int).Value = proj_type
                subsectionCommand.Parameters.Add("@in_section", SqlDbType.Int).Value = sectionID

                subsectionCommand.Parameters.Add("@in_sub_heading", SqlDbType.VarChar, 255).Value = sub_heading
            'subsectionCommand.Parameters.Add("@in_sub_text", SqlDbType.NText).Value = HttpUtility.HtmlEncode(sub_text)
            ' This is changed to below line to support tinyMCE text editor
            subsectionCommand.Parameters.Add("@in_sub_text", SqlDbType.NText).Value = sub_text
                subsectionCommand.Parameters.Add("@in_subsection_order", SqlDbType.Int).Value = subsection_order
                subsectionCommand.Parameters.Add("@in_subsection_type", SqlDbType.Int).Value = subsection_type

                subsectionConnection.Open()
                subsectionCommand.ExecuteNonQuery()
                subsectionConnection.Dispose()
            ElseIf hasChanged = True Then
                subsectionSQL = "DaikonReportingTextSectionUpdate"

                subsectionConnection = New SqlConnection(sareConnectionString)

                subsectionCommand = New SqlCommand
                subsectionCommand.Connection = subsectionConnection
                subsectionCommand.CommandText = subsectionSQL
                subsectionCommand.CommandType = CommandType.StoredProcedure

                subsectionCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
                subsectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

                subsectionCommand.Parameters.Add("@in_subsection_uid", SqlDbType.Int).Value = subsection_uid
                subsectionCommand.Parameters.Add("@in_sub_heading", SqlDbType.VarChar, 255).Value = sub_heading
            'subsectionCommand.Parameters.Add("@in_sub_text", SqlDbType.NText).Value = HttpUtility.HtmlEncode(sub_text)
            ' This is changed to below line to support tinyMCE text editor
            ' If sub_text is empty and file(s) exists then add attachment exist(s) text so user donot lose the upload files
            fileset = New DaikonReportImageCollection(subsection_uid)
            If sub_text.Length = 0 And fileset.Count > 0 Then
                sub_text = "[Attachment Exist(s)]"
            End If
            subsectionCommand.Parameters.Add("@in_sub_text", SqlDbType.NText).Value = sub_text
                subsectionCommand.Parameters.Add("@in_subsection_order", SqlDbType.Int).Value = subsection_order
                subsectionCommand.Parameters.Add("@in_subsection_type", SqlDbType.Int).Value = subsection_type
                subsectionConnection.Open()
                subsectionCommand.ExecuteNonQuery()
                subsectionConnection.Dispose()
            Else

            End If
        'End If

    End Sub
    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String)
        Dim subsectionSQL As String
        Dim subsectionConnection As SqlConnection
        Dim subsectionCommand As SqlCommand

        If (Trim(sub_text).Length > 0) Then

            If subsection_uid = 0 Then

            Else
                subsectionSQL = "DaikonReportingTextSectionUpdate"

                subsectionConnection = New SqlConnection(sareConnectionString)

                subsectionCommand = New SqlCommand
                subsectionCommand.Connection = subsectionConnection
                subsectionCommand.CommandText = subsectionSQL
                subsectionCommand.CommandType = CommandType.StoredProcedure

                subsectionCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
                subsectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

                subsectionCommand.Parameters.Add("@in_subsection_uid", SqlDbType.Int).Value = subsection_uid
                subsectionCommand.Parameters.Add("@in_sub_heading", SqlDbType.VarChar, 255).Value = sub_heading
                'subsectionCommand.Parameters.Add("@in_sub_text", SqlDbType.NText).Value = HttpUtility.HtmlEncode(sub_text)
                ' This is changed to below line to support tinyMCE text editor
                subsectionCommand.Parameters.Add("@in_sub_text", SqlDbType.NText).Value = sub_text
                subsectionCommand.Parameters.Add("@in_subsection_order", SqlDbType.Int).Value = subsection_order
                subsectionCommand.Parameters.Add("@in_subsection_type", SqlDbType.Int).Value = subsection_type
                subsectionConnection.Open()
                subsectionCommand.ExecuteNonQuery()
                subsectionConnection.Dispose()
            End If
        End If

    End Sub

    Public Function toHTML() As String
        Dim htmlHolder As String

        htmlHolder = "<p>" & vbCrLf
        htmlHolder = htmlHolder & "Subsection Order: " & subsection_order & vbCrLf
        htmlHolder = htmlHolder & "<br>" & vbCrLf
        htmlHolder = htmlHolder & "Subsection Type: " & subsection_type & vbCrLf
        htmlHolder = htmlHolder & "<br>" & vbCrLf
        htmlHolder = htmlHolder & "Subsection UID: " & subsection_uid & vbCrLf
        htmlHolder = htmlHolder & "<br>" & vbCrLf
        htmlHolder = htmlHolder & "Heading: " & sub_heading & vbCrLf
        htmlHolder = htmlHolder & "<br>" & vbCrLf
        htmlHolder = htmlHolder & "Text: <br>" & sub_text & vbCrLf
        htmlHolder = htmlHolder & "</p>" & vbCrLf

        toHTML = htmlHolder
    End Function

    Public Sub toXML(ByRef writer As XmlTextWriter)
        writer.WriteStartElement("subsection")
        writer.WriteAttributeString("order", subsection_order)
        writer.WriteAttributeString("type", subsection_type)
        writer.WriteAttributeString("uid", subsection_uid)
        writer.WriteAttributeString("hasChanged", hasChanged.ToString())
        writer.WriteElementString("heading", sub_heading)
        writer.WriteElementString("text", sub_text)

        fileset.Refresh()
        fileset.toXml(writer)

        writer.WriteEndElement()
    End Sub

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is DaikonGrantReportSubSection Then
            Dim temp As DaikonGrantReportSubSection = CType(obj, DaikonGrantReportSubSection)

            Return subsection_order.CompareTo(temp.subsection_order)
        ElseIf TypeOf obj Is Integer Then
            Return subsection_order.CompareTo(obj)
        End If

        Throw New ArgumentException("object is not a DaikonGrantReportSubSection or subsection order integer")
    End Function

End Class

Public Class DaikonGrantReportSectionCollection
    Inherits System.Collections.CollectionBase
    'Pulled from VS .NET 2003 documentation

    Public Sub Add(ByVal newSection As DaikonGrantReportSection)
        List.Add(newSection)
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            'Fail, return error
        Else
            List.RemoveAt(index)
        End If
    End Sub

    Public ReadOnly Property Item(ByVal index As Integer) As DaikonGrantReportSection
        Get
            Return CType(List.Item(index), DaikonGrantReportSection)
        End Get
    End Property
End Class 'Might not have to use this--seems too clunky and hard to overload Add, etc. to use keys

Public Class DaikonGrantReportCollection
    Inherits System.Collections.SortedList

End Class

Public Class DaikonGrantReport
    Implements IComparable

    '	Protected rept_uid As Integer
    Protected search_relevance As Integer
    Protected rept_year As Integer
    Protected rept_isfinal As Integer
    Protected rept_isapproved As Boolean
    Protected rept_uid As Integer
    Protected rept_period_start As Date
    Protected rept_period_end As Date

    Protected submit As Boolean
    Protected not_Approved As Boolean
    Protected hasChanged As Boolean
    Protected wasSubmitted As Boolean
    Protected updatedDate As Date
    Protected updatedBy As String
    Protected createdDate As Date
    Protected createdBy As String
    Protected approvedDate As Date
    Protected approvedBy As String

    Protected reptSections As SortedList

    Public Property Sections() As SortedList
        Get
            Return reptSections
        End Get
        Set(ByVal value As SortedList)
            reptSections = value
        End Set
    End Property
    Public ReadOnly Property SearchRelevance() As Integer
        Get
            Return search_relevance
        End Get
        '            Set(ByVal value As Integer)
        '               search_relevance = value
        '          End Set
    End Property
    Public Property Year() As Integer
        Get
            Return rept_year
        End Get
        Set(ByVal value As Integer)
            rept_year = value
        End Set
    End Property
    Public Property Type() As Integer
        Get
            Return rept_isfinal
        End Get
        Set(ByVal value As Integer)
            rept_isfinal = value
        End Set
    End Property
    Public ReadOnly Property StrType() As String
        Get
            Select Case rept_isfinal
                Case 0
                    Return "annual"
                Case 1
                    Return "final"
                Case 2
                    Return "proposal"
                Case Else
                    Return "unknown"
            End Select
        End Get
    End Property
    Public Property Status() As Boolean
        Get
            Return rept_isapproved
        End Get
        Set(ByVal value As Boolean)
            rept_isapproved = value
        End Set
    End Property
    Public Property SubmitStatus() As Boolean
        Get
            Return submit
        End Get
        Set(ByVal value As Boolean)
            submit = value
            wasSubmitted = value
        End Set
    End Property

    Public Property NotApproved() As Boolean
        Get
            Return not_Approved
        End Get
        Set(ByVal value As Boolean)
            not_Approved = value
        End Set
    End Property

    Public Sub New(ByVal search_relevance_in As Integer, ByVal rept_year_in As Integer, ByVal rept_isfinal_in As Integer, ByVal rept_isapproved_in As Boolean, ByVal rept_submitted_in As Boolean, ByVal rept_updateddate_in As Date, ByVal rept_period_start_in As Date, ByVal rept_period_end_in As Date)
        '	ByVal rept_uid_in As Integer,
        '		rept_uid = rept_uid_in
        search_relevance = search_relevance_in
        rept_year = rept_year_in
        rept_isfinal = rept_isfinal_in
        rept_isapproved = rept_isapproved_in
        wasSubmitted = rept_submitted_in
        updatedDate = rept_updateddate_in
        not_Approved = False


        submit = rept_submitted_in
        rept_period_start = rept_period_start_in
        rept_period_end = rept_period_end_in
        reptSections = New SortedList
    End Sub
    Public Sub New(ByVal search_relevance_in As Integer, ByVal rept_year_in As Integer, ByVal rept_isfinal_in As Integer, ByVal rept_isapproved_in As Boolean, ByVal rept_submitted_in As Boolean, ByVal rept_updateddate_in As Date)
        '	ByVal rept_uid_in As Integer,
        '		rept_uid = rept_uid_in
        search_relevance = search_relevance_in
        rept_year = rept_year_in
        rept_isfinal = rept_isfinal_in
        rept_isapproved = rept_isapproved_in
        wasSubmitted = rept_submitted_in
        updatedDate = rept_updateddate_in
        not_Approved = False

        submit = rept_submitted_in
        rept_period_start = New Date
        rept_period_end = New Date
        reptSections = New SortedList
    End Sub
    Public Sub New(ByVal rept_year_in As Integer, ByVal rept_isfinal_in As Integer)
        '	ByVal rept_uid_in As Integer,
        '		rept_uid = rept_uid_in
        rept_year = rept_year_in
        rept_isfinal = rept_isfinal_in
        rept_isapproved = False
        wasSubmitted = False
        not_Approved = False
        updatedDate = New Date

        submit = False
        rept_period_start = New Date
        rept_period_end = New Date
        reptSections = New SortedList
    End Sub
    Public Sub New(ByVal proj_num As String, ByVal rept_year_in As Integer, ByVal rept_isfinal_in As Integer, ByVal sareConnectionString As String)

        reptSections = New SortedList

        'Dim rept_uid_in As Integer
        'Dim rept_isapproved_in As Boolean
        'Dim rept_period_start_in As Date
        'Dim rept_period_end_in As Date

        Dim tempSection As DaikonGrantReportSection
        Dim section_in As Integer
        Dim sectionOrder_in As Integer
        Dim sectionName_in As String

        Dim tempSubSection As DaikonGrantReportSubSection
        Dim subsection_uid_in As Integer
        Dim sub_heading_in As String
        Dim sub_text_in As String
        Dim subsection_order_in As Integer
        Dim subsection_type_in As Integer

        Dim reportSQL As String

        reportSQL = "DaikonReportingRetrieveReportByProj"

        Dim reportConnection As SqlConnection
        Dim reportCommand As SqlCommand
        Dim reportDataReader As SqlDataReader

        reportConnection = New SqlConnection(sareConnectionString)

        reportCommand = New SqlCommand
        reportCommand.Connection = reportConnection
        reportCommand.CommandText = reportSQL
        reportCommand.CommandType = CommandType.StoredProcedure

        reportCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 255).Value = proj_num
        reportCommand.Parameters.Add("@rept_year", SqlDbType.Int).Value = rept_year_in
        reportCommand.Parameters.Add("@rept_isfinal", SqlDbType.TinyInt).Value = rept_isfinal_in
        reportConnection.Open()
        reportDataReader = reportCommand.ExecuteReader()

        reportDataReader.Read()

        reportDataReader.NextResult()

        reportDataReader.Read()
        If reportDataReader.HasRows Then
            rept_uid = reportDataReader("rept_uid")
            rept_year = reportDataReader("rept_year")
            rept_isfinal = reportDataReader("rept_isfinal")
            rept_isapproved = reportDataReader("rept_isapproved")
            rept_period_start = reportDataReader("rept_period_start")
            rept_period_end = reportDataReader("rept_period_end")
            wasSubmitted = reportDataReader("submitted")
            submit = reportDataReader("submitted")
            updatedDate = reportDataReader("updatedDate")
            not_Approved = False
        Else
            rept_uid = 0
            rept_year = rept_year_in
            rept_isfinal = rept_isfinal_in
            rept_isapproved = False
            rept_period_start = Today.Date
            rept_period_end = Today.Date
            wasSubmitted = False
            submit = False
            not_Approved = False
            updatedDate = Today.Date
        End If

        reportDataReader.NextResult()

        reportDataReader.NextResult()

        Do While reportDataReader.Read()
            section_in = reportDataReader("section")
            sectionOrder_in = reportDataReader("section_order")
            sectionName_in = reportDataReader("section_name")

            If reptSections.ContainsKey(section_in) Then
                '                    tempSubSection = New DaikonGrantReportSubSection(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
                '                   reptSections(section_in).addSubSection(tempSubSection)
            Else
                tempSection = New DaikonGrantReportSection(section_in, sectionOrder_in, sectionName_in)
                '                tempSubSection = New DaikonGrantReportSubSection(0, "", "", 100, 0)
                '               tempSection.addSubSection(tempSubSection)
                addSection(tempSection)
            End If

        Loop

        reportDataReader.NextResult()

        Do While reportDataReader.Read()
            section_in = reportDataReader("section")
            sectionOrder_in = reportDataReader("section_order")
            sectionName_in = reportDataReader("section_name")

            subsection_uid_in = reportDataReader("subsection_uid")
            sub_heading_in = reportDataReader("sub_heading")
            sub_text_in = reportDataReader("sub_text")
            sub_text_in = sub_text_in.Replace("&amp;", "&") ' TinyMCE saving, so need to replace for XSL
            subsection_order_in = reportDataReader("subsection_order")
            subsection_type_in = reportDataReader("subsection_type")

            If reptSections.ContainsKey(section_in) Then
                tempSubSection = New DaikonGrantReportSubSection(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
                reptSections(section_in).addSubSection(tempSubSection)
            Else
                tempSection = New DaikonGrantReportSection(section_in, sectionOrder_in, sectionName_in)
                tempSubSection = New DaikonGrantReportSubSection(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
                tempSection.addSubSection(tempSubSection)
                addSection(tempSection)
            End If

        Loop

        For Each section As DaikonGrantReportSection In reptSections.Values()
            section.CloseGaps()
            If section.Subsections.Count = 0 Then
                tempSubSection = New DaikonGrantReportSubSection(0, "", "", 100, 0)
                section.addSubSection(tempSubSection)
            End If
        Next

        reportDataReader.Close()
        reportConnection.Dispose()

    End Sub
    Public Sub Refresh(ByVal sareConnectionString As String)
        reptSections = New SortedList

        Dim tempSection As DaikonGrantReportSection
        Dim section_in As Integer
        Dim sectionOrder_in As Integer
        Dim sectionName_in As String

        Dim tempSubSection As DaikonGrantReportSubSection
        Dim subsection_uid_in As Integer
        Dim sub_heading_in As String
        Dim sub_text_in As String
        Dim subsection_order_in As Integer
        Dim subsection_type_in As Integer

        Dim reportSQL As String

        reportSQL = "DaikonReportingRetrieveReportByReptUID"

        Dim reportConnection As SqlConnection
        Dim reportCommand As SqlCommand
        Dim reportDataReader As SqlDataReader

        reportConnection = New SqlConnection(sareConnectionString)

        reportCommand = New SqlCommand
        reportCommand.Connection = reportConnection
        reportCommand.CommandText = reportSQL
        reportCommand.CommandType = CommandType.StoredProcedure

        reportCommand.Parameters.Add("@rept_uid", SqlDbType.Int).Value = rept_uid
        reportConnection.Open()
        reportDataReader = reportCommand.ExecuteReader()

        reportDataReader.Read()

        reportDataReader.NextResult()

        reportDataReader.Read()
        If reportDataReader.HasRows Then
            '            rept_uid = reportDataReader("rept_uid")
            rept_year = reportDataReader("rept_year")
            rept_isfinal = reportDataReader("rept_isfinal")
            rept_isapproved = reportDataReader("rept_isapproved")
            rept_period_start = reportDataReader("rept_period_start")
            rept_period_end = reportDataReader("rept_period_end")
            wasSubmitted = reportDataReader("submitted")
            submit = reportDataReader("submitted")
            not_Approved = False
            updatedDate = reportDataReader("updatedDate")
        Else
            rept_uid = 0
            rept_year = 0
            rept_isfinal = 0
            rept_isapproved = False
            rept_period_start = Today.Date
            rept_period_end = Today.Date
            wasSubmitted = False
            submit = False
            not_Approved = False
            updatedDate = Today.Date
        End If

        reportDataReader.NextResult()

        reportDataReader.NextResult()

        Do While reportDataReader.Read()
            section_in = reportDataReader("section")
            sectionOrder_in = reportDataReader("section_order")
            sectionName_in = reportDataReader("section_name")

            If reptSections.ContainsKey(section_in) Then
                '                    tempSubSection = New DaikonGrantReportSubSection(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
                '                   reptSections(section_in).addSubSection(tempSubSection)
            Else
                tempSection = New DaikonGrantReportSection(section_in, sectionOrder_in, sectionName_in)
                '                tempSubSection = New DaikonGrantReportSubSection(0, "", "", 100, 0)
                '                tempSection.addSubSection(tempSubSection)
                addSection(tempSection)
            End If

        Loop

        reportDataReader.NextResult()

        Do While reportDataReader.Read()
            section_in = reportDataReader("section")
            sectionOrder_in = reportDataReader("section_order")
            sectionName_in = reportDataReader("section_name")

            subsection_uid_in = reportDataReader("subsection_uid")
            sub_heading_in = reportDataReader("sub_heading")
            sub_text_in = reportDataReader("sub_text")
            subsection_order_in = reportDataReader("subsection_order")
            subsection_type_in = reportDataReader("subsection_type")

            If reptSections.ContainsKey(section_in) Then
                tempSubSection = New DaikonGrantReportSubSection(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
                reptSections(section_in).addSubSection(tempSubSection)
            Else
                tempSection = New DaikonGrantReportSection(section_in, sectionOrder_in, sectionName_in)
                tempSubSection = New DaikonGrantReportSubSection(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
                tempSection.addSubSection(tempSubSection)
                addSection(tempSection)
            End If

        Loop

        For Each section As DaikonGrantReportSection In reptSections.Values()
            section.CloseGaps()
            If section.Subsections.Count = 0 Then
                tempSubSection = New DaikonGrantReportSubSection(0, "", "", 100, 0)
                section.addSubSection(tempSubSection)
            End If
        Next

        reportDataReader.Close()
        reportConnection.Dispose()

    End Sub
    Public Function getEditLink()
        Dim linkString As String
        linkString = "&ry=" & rept_year & "&rf=" & rept_isfinal & Chr(34) & ">"
        Select Case rept_isfinal
            Case 0
                linkString = linkString & rept_year & " Annual Report"
            Case 1
                linkString = linkString & rept_year & " Final Report"
            Case 2
                linkString = linkString & "Project Proposal"
        End Select
        getEditLink = linkString
    End Function
    Public Function getKeyID() As String
        getKeyID = rept_year.ToString() & rept_isfinal.ToString()
    End Function
    Public Function getKeyID(ByVal year As Integer, ByVal isfinal As Integer) As String
        getKeyID = year.ToString() & isfinal.ToString()
    End Function

    Public Sub addSection(ByVal newSection As DaikonGrantReportSection)
        Dim newSectionKey As Integer
        newSectionKey = newSection.getKeyID()
        reptSections.Add(newSectionKey, newSection)
    End Sub
    Public Sub toXML(ByRef writer As XmlTextWriter)
        Dim i As Integer

        writer.WriteStartElement("report")
        writer.WriteAttributeString("ID", rept_uid)
        writer.WriteAttributeString("year", rept_year)
        writer.WriteAttributeString("type", rept_isfinal)
        writer.WriteAttributeString("approvedstatus", rept_isapproved)
        writer.WriteAttributeString("submittedstatus", wasSubmitted)
        writer.WriteAttributeString("updateddate", updatedDate.ToShortDateString())
        writer.WriteAttributeString("startdate", rept_period_start.ToShortDateString())
        writer.WriteAttributeString("enddate", rept_period_end.ToShortDateString())
        For i = 0 To reptSections.Count - 1
            reptSections.GetByIndex(i).toXML(writer)
            'reptSections(i).toXML(writer)
        Next i
        writer.WriteEndElement()

    End Sub

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is DaikonGrantReport Then
            Dim temp As DaikonGrantReport = CType(obj, DaikonGrantReport)
            Dim comparisonString As String
            Dim tempComparisonString As String

            comparisonString = rept_year.ToString() & rept_isfinal.ToString()
            tempComparisonString = temp.rept_year.ToString() & temp.rept_isfinal.ToString()

            Return comparisonString.CompareTo(tempComparisonString)
        ElseIf TypeOf obj Is Integer Then
            Return rept_year.CompareTo(obj)
        ElseIf TypeOf obj Is String Then
            Dim comparisonString As String
            comparisonString = rept_year.ToString() & rept_isfinal.ToString()
            Return comparisonString.CompareTo(obj)
        End If

        Throw New ArgumentException("object is not a DaikonGrantReport, Year, or Year + Report Status grouping")
    End Function

    Public Sub UpdateSub(ByVal section As Integer, ByVal subsection_uid_in As Integer, ByVal sub_heading_in As String, ByVal sub_text_in As String, ByVal subsection_order_in As Integer, ByVal subsection_type_in As Integer)
        '            reptSections.GetByIndex(reptSections.IndexOfKey(section)).UpdateSub(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
        reptSections(section).UpdateSub(subsection_uid_in, sub_heading_in, sub_text_in, subsection_order_in, subsection_type_in)
    End Sub
    Public Sub MoveSub(ByVal section As Integer, ByVal currentOrder As Integer, ByVal newOrder As Integer)
        '            reptSections.GetByIndex(reptSections.IndexOfKey(section)).MoveSubsection(currentOrder, newOrder)
        reptSections(section).MoveSubsection(currentOrder, newOrder)
    End Sub
    Public Sub InsertSub(ByVal section As Integer, ByVal currentOrder As Integer)
        '            reptSections.GetByIndex(reptSections.IndexOfKey(section)).MoveSubsection(currentOrder, newOrder)
        Dim tempSubsection As DaikonGrantReportSubSection
        tempSubsection = New DaikonGrantReportSubSection()
        tempSubsection.SubsectionOrder = currentOrder + 1

        reptSections(section).InsertSubsection(tempSubsection)
    End Sub
    Public Sub DeleteSub(ByVal section As Integer, ByVal currentOrder As Integer)
        '            reptSections.GetByIndex(reptSections.IndexOfKey(section)).MoveSubsection(currentOrder, newOrder)
        reptSections(section).DeleteSubsection(currentOrder)
    End Sub
    Public Sub CloseSubsectionGaps(ByVal section As Integer)
        '            reptSections.GetByIndex(reptSections.IndexOfKey(section)).CloseGaps()
        reptSections(section).CloseGaps()
    End Sub
    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal section As Integer, ByVal subsection As Integer, ByVal sareConnectionString As String)
        Dim reportSQL As String
        Dim reportConnection As SqlConnection
        Dim reportCommand As SqlCommand

        reportSQL = "DaikonReportingReportUpdate"

        reportConnection = New SqlConnection(sareConnectionString)

        reportCommand = New SqlCommand
        reportCommand.Connection = reportConnection
        reportCommand.CommandText = reportSQL
        reportCommand.CommandType = CommandType.StoredProcedure

        reportCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
        reportCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

        reportCommand.Parameters.Add("@in_rept_uid", SqlDbType.Int).Value = rept_uid
        reportCommand.Parameters.Add("@in_rept_isapproved", SqlDbType.Bit).Value = rept_isapproved
        reportCommand.Parameters.Add("@in_submitted", SqlDbType.Bit).Value = submit
        reportCommand.Parameters.Add("@in_rept_period_start", SqlDbType.DateTime).Value = rept_period_start
        reportCommand.Parameters.Add("@in_rept_period_end", SqlDbType.DateTime).Value = rept_period_end
        reportConnection.Open()
        reportCommand.ExecuteNonQuery()
        reportConnection.Dispose()

        '            reptSections.GetByIndex(reptSections.IndexOfKey(section)).saveToDB(username, sessionKey, subsection, sareConnectionString)
        reptSections(section).saveToDB(username, sessionKey, subsection, sareConnectionString)
    End Sub

    Public Sub saveToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal proj_num As String, ByVal proj_type As Integer, ByVal sareConnectionString As String)
        Dim reportSQL As String
        Dim reportConnection As SqlConnection
        Dim reportCommand As SqlCommand

        Dim section As DaikonGrantReportSection

        If (rept_uid = 0) Then
            reportSQL = "DaikonReportingReportInsert"

            reportConnection = New SqlConnection(sareConnectionString)

            reportCommand = New SqlCommand
            reportCommand.Connection = reportConnection
            reportCommand.CommandText = reportSQL
            reportCommand.CommandType = CommandType.StoredProcedure

            Dim keyOutput As SqlParameter
            keyOutput = New SqlParameter("@ID", SqlDbType.Int)
            keyOutput.Direction = ParameterDirection.Output

            reportCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
            reportCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

            reportCommand.Parameters.Add("@in_proj_num", SqlDbType.VarChar, 50).Value = proj_num
            reportCommand.Parameters.Add("@in_rept_year", SqlDbType.Int).Value = rept_year
            reportCommand.Parameters.Add("@in_rept_isfinal", SqlDbType.TinyInt).Value = rept_isfinal
            reportCommand.Parameters.Add("@in_rept_isapproved", SqlDbType.Bit).Value = rept_isapproved
            reportCommand.Parameters.Add("@in_submitted", SqlDbType.Bit).Value = submit
            reportCommand.Parameters.Add("@in_rept_period_start", SqlDbType.DateTime).Value = rept_period_start
            reportCommand.Parameters.Add("@in_rept_period_end", SqlDbType.DateTime).Value = rept_period_end
            reportCommand.Parameters.Add(keyOutput)

            reportConnection.Open()
            reportCommand.ExecuteNonQuery()

            rept_uid = keyOutput.Value

            reportConnection.Dispose()

        Else
            reportSQL = "DaikonReportingReportUpdate"

            reportConnection = New SqlConnection(sareConnectionString)

            reportCommand = New SqlCommand
            reportCommand.Connection = reportConnection
            reportCommand.CommandText = reportSQL
            reportCommand.CommandType = CommandType.StoredProcedure

            reportCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
            reportCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

            reportCommand.Parameters.Add("@in_rept_uid", SqlDbType.Int).Value = rept_uid
            reportCommand.Parameters.Add("@in_rept_isapproved", SqlDbType.Bit).Value = rept_isapproved
            If (not_Approved = True) Then
                reportCommand.Parameters.Add("@in_submitted", SqlDbType.Bit).Value = False
            Else
                reportCommand.Parameters.Add("@in_submitted", SqlDbType.Bit).Value = submit
            End If


            reportCommand.Parameters.Add("@in_rept_period_start", SqlDbType.DateTime).Value = rept_period_start
            reportCommand.Parameters.Add("@in_rept_period_end", SqlDbType.DateTime).Value = rept_period_end
            reportConnection.Open()
            reportCommand.ExecuteNonQuery()
            reportConnection.Dispose()
        End If

        For Each section In reptSections.Values()
            '                If section.SectionID() = 0 Then
            '               section.saveToDB(username, sessionKey, sareConnectionString)
            '              End If
            section.saveToDB(username, sessionKey, proj_num, rept_year, rept_isfinal, proj_type, sareConnectionString)
        Next
    End Sub
    Public Sub saveNewToDB(ByVal username As String, ByVal sessionKey As Integer, ByVal proj_num As String, ByVal proj_type As Integer, ByVal sareConnectionString As String)
        Dim reportSQL As String
        Dim reportConnection As SqlConnection
        Dim reportCommand As SqlCommand

        Dim section As DaikonGrantReportSection

        reportSQL = "DaikonReportingReportInsert"

        reportConnection = New SqlConnection(sareConnectionString)

        reportCommand = New SqlCommand
        reportCommand.Connection = reportConnection
        reportCommand.CommandText = reportSQL
        reportCommand.CommandType = CommandType.StoredProcedure

        Dim keyOutput As SqlParameter
        keyOutput = New SqlParameter("@ID", SqlDbType.Int)
        keyOutput.Direction = ParameterDirection.Output

        reportCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
        reportCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey

        reportCommand.Parameters.Add("@in_proj_num", SqlDbType.VarChar, 50).Value = proj_num
        reportCommand.Parameters.Add("@in_rept_year", SqlDbType.Int).Value = rept_year
        reportCommand.Parameters.Add("@in_rept_isfinal", SqlDbType.TinyInt).Value = rept_isfinal
        reportCommand.Parameters.Add("@in_rept_isapproved", SqlDbType.Bit).Value = rept_isapproved
        reportCommand.Parameters.Add("@in_submitted", SqlDbType.Bit).Value = submit
        reportCommand.Parameters.Add("@in_rept_period_start", SqlDbType.DateTime).Value = rept_period_start
        reportCommand.Parameters.Add("@in_rept_period_end", SqlDbType.DateTime).Value = rept_period_end
        reportCommand.Parameters.Add(keyOutput)

        reportConnection.Open()
        reportCommand.ExecuteNonQuery()

        rept_uid = keyOutput.Value

        reportConnection.Dispose()

        For Each section In reptSections.Values()
            '                If section.SectionID() = 0 Then
            '               section.saveToDB(username, sessionKey, sareConnectionString)
            '              End If
            section.saveToDB(username, sessionKey, proj_num, rept_year, rept_isfinal, proj_type, sareConnectionString)
        Next
    End Sub

    Public Sub deleteFromDB(ByVal username As String, ByVal sessionKey As Integer, ByVal projectNum As String, ByVal sareConnectionString As String)
        Dim reportSQL As String
        Dim reportConnection As SqlConnection
        Dim reportCommand As SqlCommand

        reportSQL = "DaikonReportingReportDelete"

        reportConnection = New SqlConnection(sareConnectionString)

        reportCommand = New SqlCommand
        reportCommand.Connection = reportConnection
        reportCommand.CommandText = reportSQL
        reportCommand.CommandType = CommandType.StoredProcedure

        reportCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = username
        reportCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        reportCommand.Parameters.Add("@projnum", SqlDbType.VarChar, 50).Value = projectNum
        reportCommand.Parameters.Add("@reptyear", SqlDbType.Int).Value = rept_year
        reportCommand.Parameters.Add("@reptisfinal", SqlDbType.TinyInt).Value = rept_isfinal
        reportCommand.Parameters.Add("@reptUID", SqlDbType.Int).Value = rept_uid

        reportConnection.Open()
        reportCommand.ExecuteNonQuery()
        reportConnection.Dispose()

    End Sub

End Class

Public Class DaikonGrant
    Implements IComparable

	Protected proj_coreID As Integer
    Protected extUID As Integer
    Protected claimKey As String
    Protected searchRelevance As Integer
    Protected proj_num As String
    Protected proj_title As String
    Protected proj_region As String
    Protected proj_region_text As String
    Protected proj_state_abbr As String
    Protected proj_year As Integer
    Protected proj_endyear As Integer
    Protected proj_type As Integer
    Protected proj_type_text As String
    Protected proj_state As String
    Protected funds_sare As Decimal
    Protected funds_matching_fed As Decimal
    Protected funds_matching_nonfed As Decimal
    Protected submitted As Boolean
    Protected approved As Boolean
    Protected grantReports As SortedList(Of String, DaikonGrantReport)
    Protected grantProfile As DaikonProfile
    Protected grantRow As Boolean

    '		Protected proposalReports As SortedList
    '		Protected annualReports As SortedList
    '		Protected finalReports As SortedList

    Public Property HasGrantRow() As Boolean
        Get
            Return grantRow
        End Get
        Set(ByVal value As Boolean)
            grantRow = value
        End Set
    End Property

    Public ReadOnly Property ClaimCode() As String
        Get
            Return claimKey
        End Get
    End Property

    Public ReadOnly Property Profile() As DaikonProfile
        Get
            Return grantProfile
        End Get
    End Property

    Public Property projNum() As String
        Get
            Return proj_num
        End Get
        Set(ByVal value As String)
            proj_num = value
        End Set
    End Property

    Public Property projTitle() As String
        Get
            Return proj_title
        End Get
        Set(ByVal value As String)
            proj_title = value
        End Set
    End Property
	Public Property Region() As String
		Get
			Return proj_region
		End Get
		Set(ByVal value As String)
			proj_region = value
		End Set
    End Property
    Public Property ProjEndYear() As Integer
        Get
            Return proj_endyear
        End Get
        Set(ByVal value As Integer)
            proj_endyear = value
        End Set
    End Property
	Public Property fundsSare() As Decimal

		Get
			Return funds_sare
		End Get
		Set(ByVal value As Decimal)
			funds_sare = value
		End Set
	End Property
    Public Property fundsMatchingFed() As Decimal
        Get
            Return funds_matching_fed
        End Get
        Set(ByVal value As Decimal)
            funds_matching_fed = value
        End Set
    End Property
    Public Property fundsMatchingNonfed() As Decimal
        Get
            Return funds_matching_nonfed
        End Get
        Set(ByVal value As Decimal)
            funds_matching_nonfed = value
        End Set
    End Property
    Public Property ProjectState() As String
        Get
            Return proj_state
        End Get
        Set(ByVal value As String)
            proj_state = value
        End Set
    End Property
        Public Property Type() As Integer
            Get
                Return proj_type
            End Get
            Set(ByVal value As Integer)
                proj_type = value
            End Set
        End Property
	Public Property CoreID() As Integer
		Get
			Return proj_coreID
		End Get
		Set(ByVal value As Integer)
			proj_coreID = value
		End Set
	End Property

    Public Property Reports() As SortedList(Of String, DaikonGrantReport)
        Get
            Return grantReports
        End Get
        Set(ByVal value As SortedList(Of String, DaikonGrantReport))
            grantReports = value
        End Set
    End Property
    'Public Property ProposalRepts() As SortedList
    '	Get
    '		Return proposalReports
    '	End Get
    '	Set(ByVal value As SortedList)
    '		proposalReports = value
    '	End Set
    'End Property
    'Public Property AnnualRepts() As SortedList
    '	Get
    '		Return annualReports
    '	End Get
    '	Set(ByVal value As SortedList)
    '		annualReports = value
    '	End Set
    'End Property
    'Public Property FinalRepts() As SortedList
    '	Get
    '		Return finalReports
    '	End Get
    '	Set(ByVal value As SortedList)
    '		finalReports = value
    '	End Set
    'End Property
    'Public Function Reports(ByVal reptType As Integer) As SortedList
    '	'wanted to make this a property, but I can't pass parameters to Get
    '	Select Case reptType
    '		Case 0
    '			Return annualReports
    '		Case 1
    '			Return finalReports
    '		Case 2
    '			Return proposalReports
    '		Case Else
    '			Return annualReports
    '	End Select
    'End Function

    Public Function Create(ByVal userName As String, ByVal sessionKey As Integer, ByVal projEndYear As Integer, ByVal sareConnectionString As String) As Integer

        Dim projectSQL As String

        projectSQL = "DaikonReportingProjectInsert"

        Dim projectConnection As SqlConnection
        Dim projectCommand As SqlCommand
        Dim projectDataReader As SqlDataReader

        Dim sqlreturnval As SqlParameter
        sqlreturnval = New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        sqlreturnval.Direction = ParameterDirection.ReturnValue

        projectConnection = New SqlConnection(sareConnectionString)

        projectCommand = New SqlCommand
        projectCommand.Connection = projectConnection
        projectCommand.CommandText = projectSQL
        projectCommand.CommandType = CommandType.StoredProcedure


        ' Convert proj_num into XXX00-000 or XX00-00format
        Dim projectNum As String
        If proj_num.Contains("-") Then
            projectNum = proj_num
        Else
            If (proj_num.Length() > 7) Then
                projectNum = proj_num.Substring(0, 5)
                projectNum = projectNum + "-"
                projectNum = projectNum + proj_num.Substring(5)
                proj_num = projectNum
            Else
                projectNum = proj_num.Substring(0, 4)
                projectNum = projectNum + "-"
                projectNum = projectNum + proj_num.Substring(4)
                proj_num = projectNum
            End If

        End If

        projectCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        projectCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        projectCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = proj_num.ToUpper()
        projectCommand.Parameters.Add("@projEndYear", SqlDbType.Int).Value = projEndYear
        projectCommand.Parameters.Add(sqlreturnval)

        'projectCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = projectNum
        'proj_num = projectNum

        projectConnection.Open()
        projectDataReader = projectCommand.ExecuteReader()
        projectDataReader.Read()


        If projectDataReader.HasRows() Then
            claimKey = projectDataReader("claimKey")
        End If

        projectConnection.Dispose()

        Return sqlreturnval.Value

    End Function

    Public Function Create(ByVal userName As String, ByVal sessionKey As Integer, ByVal projEndYear As Integer, ByVal projRegion As String, ByVal sareConnectionString As String) As Integer

        Dim projectSQL As String

        projectSQL = "DaikonReportingPDPInsert"

        Dim projectConnection As SqlConnection
        Dim projectCommand As SqlCommand
        Dim projectDataReader As SqlDataReader

        Dim sqlreturnval As SqlParameter
        sqlreturnval = New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        sqlreturnval.Direction = ParameterDirection.ReturnValue

        projectConnection = New SqlConnection(sareConnectionString)

        projectCommand = New SqlCommand
        projectCommand.Connection = projectConnection
        projectCommand.CommandText = projectSQL
        projectCommand.CommandType = CommandType.StoredProcedure


        ' Convert proj_num into XXX00-000 or XX00-00format
        Dim projectNum As String
        If proj_num.Contains("-") Then
            projectNum = proj_num
        Else
            If (proj_num.Length() > 7) Then
                projectNum = proj_num.Substring(0, 5)
                projectNum = projectNum + "-"
                projectNum = projectNum + proj_num.Substring(5)
                proj_num = projectNum
            Else
                projectNum = proj_num.Substring(0, 4)
                projectNum = projectNum + "-"
                projectNum = projectNum + proj_num.Substring(4)
                proj_num = projectNum
            End If

        End If

        projectCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        projectCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        projectCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = proj_num.ToUpper()
        projectCommand.Parameters.Add("@projRegion", SqlDbType.VarChar, 2).Value = projRegion.ToUpper()
        projectCommand.Parameters.Add("@projType", SqlDbType.Int).Value = 10
        projectCommand.Parameters.Add("@projEndYear", SqlDbType.Int).Value = projEndYear
        projectCommand.Parameters.Add(sqlreturnval)

        'projectCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = projectNum
        'proj_num = projectNum

        projectConnection.Open()
        projectDataReader = projectCommand.ExecuteReader()
        projectDataReader.Read()


        If projectDataReader.HasRows() Then
            claimKey = projectDataReader("claimKey")
        End If

        projectConnection.Dispose()

        Return sqlreturnval.Value

    End Function

    Public Function DeleteProject(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String) As Integer

        Dim projectSQL As String

        projectSQL = "DaikonReportingProjectDelete"

        Dim projectConnection As SqlConnection
        Dim projectCommand As SqlCommand
        Dim projectDataReader As SqlDataReader

        Dim sqlreturnval As SqlParameter
        sqlreturnval = New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        sqlreturnval.Direction = ParameterDirection.ReturnValue

        projectConnection = New SqlConnection(sareConnectionString)

        projectCommand = New SqlCommand
        projectCommand.Connection = projectConnection
        projectCommand.CommandText = projectSQL
        projectCommand.CommandType = CommandType.StoredProcedure


        projectCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        projectCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        projectCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = proj_num
        projectCommand.Parameters.Add(sqlreturnval)
        

        projectConnection.Open()
        projectDataReader = projectCommand.ExecuteReader()
        projectDataReader.Read()
       
        projectConnection.Dispose()

        Return sqlreturnval.Value

    End Function

	Public Function AssignClaimKey(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String) As String

		Dim projectSQL As String

		projectSQL = "DaikonCoreAssignClaimCode"

		Dim projectConnection As SqlConnection
		Dim projectCommand As SqlCommand
		Dim projectDataReader As SqlDataReader

		projectConnection = New SqlConnection(sareConnectionString)

		projectCommand = New SqlCommand
		projectCommand.Connection = projectConnection
		projectCommand.CommandText = projectSQL
		projectCommand.CommandType = CommandType.StoredProcedure

		projectCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
		projectCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
		projectCommand.Parameters.Add("@coreObjID", SqlDbType.BigInt).Value = CoreID

		'projectCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = projectNum
		'proj_num = projectNum

		projectConnection.Open()
		projectDataReader = projectCommand.ExecuteReader()
		projectDataReader.Read()


		If projectDataReader.HasRows() Then
			claimKey = projectDataReader("claimCode")
		End If

		projectConnection.Dispose()

		Return claimKey

	End Function

    Public Sub SaveToDB(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String)

        Dim projectSQL As String

        projectSQL = "DaikonReportingProjectUpdate"

        Dim projectConnection As SqlConnection
        Dim projectCommand As SqlCommand
        Dim projectDataReader As SqlDataReader

        projectConnection = New SqlConnection(sareConnectionString)

        projectCommand = New SqlCommand
        projectCommand.Connection = projectConnection
        projectCommand.CommandText = projectSQL
        projectCommand.CommandType = CommandType.StoredProcedure

        projectCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        projectCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        projectCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 50).Value = proj_num
        projectCommand.Parameters.Add("@proj_title", SqlDbType.VarChar, 255).Value = proj_title
        projectCommand.Parameters.Add("@proj_state", SqlDbType.VarChar, 4).Value = proj_state
        projectCommand.Parameters.Add("@funds_sare", SqlDbType.Money).Value = funds_sare
        projectCommand.Parameters.Add("@funds_matching_fed", SqlDbType.Money).Value = funds_matching_fed
        projectCommand.Parameters.Add("@funds_matching_nonfed", SqlDbType.Money).Value = funds_matching_nonfed
        projectCommand.Parameters.Add("@projEndYear", SqlDbType.Int).Value = proj_endyear


        projectConnection.Open()
        projectDataReader = projectCommand.ExecuteScalar()
        projectConnection.Dispose()

    End Sub

    Public Sub New(ByVal proj_num_in As String, ByVal searchRelevance_in As Integer, ByVal proj_title_in As String, ByVal proj_region_in As String, ByVal proj_year_in As String, ByVal proj_type_in As String, ByVal funds_sare_in As String, ByVal funds_matching_fed_in As String, ByVal funds_matching_nonfed_in As String)
        proj_num = proj_num_in
        searchRelevance = searchRelevance_in
        proj_title = proj_title_in
        proj_region = proj_region_in
        proj_year = proj_year_in
        proj_type = proj_type_in
        funds_sare = funds_sare_in
        funds_matching_fed = funds_matching_fed_in
        funds_matching_nonfed = funds_matching_nonfed_in
        grantReports = New SortedList(Of String, DaikonGrantReport)
    End Sub

    Public Sub New(ByVal proj_num_in As String, ByVal searchRelevance_in As Integer, ByVal proj_title_in As String, ByVal proj_region_in As String, ByVal proj_year_in As String, ByVal proj_type_in As String, ByVal proj_region_text_in As String, ByVal proj_type_text_in As String)
        proj_num = proj_num_in
        searchRelevance = searchRelevance_in
        proj_title = proj_title_in
        proj_region = proj_region_in
        proj_year = proj_year_in
        proj_type = proj_type_in
        proj_region_text = proj_region_text_in
        proj_type_text = proj_type_text_in
        grantReports = New SortedList(Of String, DaikonGrantReport)
    End Sub

    Public Sub New(ByVal proj_num_in As String)
        proj_num = proj_num_in
    End Sub

    Public Sub New(ByVal proj_num_in As String, ByVal sareConnectionString As String)
        proj_num = proj_num_in

        Dim tempReport As DaikonGrantReport

        'Dim rept_uid_in As Integer
        Dim rept_year_in As Integer
        Dim rept_isfinal_in As Integer
        Dim rept_isapproved_in As Boolean
        'Dim rept_period_start_in As Date
        'Dim rept_period_end_in As Date

        'Dim section As Integer
        'Dim sectionOrder As Integer
        'Dim sectionName As String

        'Dim subsection_uid_in As Integer
        'Dim sub_heading_in As String
        'Dim sub_text_in As String
        'Dim subsection_order_in As Integer
        'Dim subsection_type_in As Integer

        Dim projOverviewSQL As String

        If (String.IsNullOrEmpty(proj_num) = False) Then

            projOverviewSQL = "DaikonReportingProjectOverview"

            Dim projOverviewConnection As SqlConnection
            Dim projOverviewCommand As SqlCommand
            Dim projOverviewDataReader As SqlDataReader

            projOverviewConnection = New SqlConnection(sareConnectionString)

            projOverviewCommand = New SqlCommand
            projOverviewCommand.Connection = projOverviewConnection
            projOverviewCommand.CommandText = projOverviewSQL
            projOverviewCommand.CommandType = CommandType.StoredProcedure

            projOverviewCommand.Parameters.Add("@proj_num", SqlDbType.VarChar, 255).Value = proj_num
            projOverviewConnection.Open()
            projOverviewDataReader = projOverviewCommand.ExecuteReader()

            '	Response.Write("")

            grantRow = projOverviewDataReader.Read()

            If grantRow Then

                CoreID = projOverviewDataReader("coreID")

                proj_title = projOverviewDataReader("proj_title")
                proj_region = projOverviewDataReader("proj_region")
                proj_type = projOverviewDataReader("proj_type")
                proj_region_text = projOverviewDataReader("proj_region_text")
                proj_type_text = projOverviewDataReader("proj_type_text")
                proj_year = projOverviewDataReader("proj_year")
                proj_endyear = projOverviewDataReader("proj_endyear")
                proj_state_abbr = projOverviewDataReader("proj_state")

                funds_sare = projOverviewDataReader("funds_sare")
                funds_matching_fed = projOverviewDataReader("funds_matching_fed")
                funds_matching_nonfed = projOverviewDataReader("funds_matching_nonfed")
                submitted = projOverviewDataReader("submitted")
                approved = projOverviewDataReader("approved")

                projOverviewDataReader.NextResult()

                'Do While projOverviewDataReader.Read()
                '	participant_fname = projOverviewDataReader("participant_fname")
                '	participant_lname = projOverviewDataReader("participant_lname")
                '	participant_iscoord = projOverviewDataReader("participant_iscoord")
                '	participant_org = projOverviewDataReader("organization")
                '	participant_uid = projOverviewDataReader("participants_key")
                '	participant_name = participant_fname & " " & participant_lname

                '	If (participant_name = " ") Then
                '		participant_name = participant_org
                '	Else
                '		If (participant_org <> "") Then
                '			participant_name = participant_name & ", " & participant_org
                '		End If
                '	End If
                '	If (participant_iscoord = True) Then
                '		participant_name = "Coordinator: " & participant_name
                '	End If

                '	Response.Write("<a href=" & Chr(34) & "editParticipant.aspx?participant=" & participant_uid & Chr(34) & ">")
                '	Response.Write(participant_name & "</a><br>")
                'Loop

                'proposalReports = New SortedList
                'annualReports = New SortedList
                'finalReports = New SortedList
                grantReports = New SortedList(Of String, DaikonGrantReport)
                grantProfile = New DaikonProfile(proj_num)

                projOverviewDataReader.NextResult()
                Do While projOverviewDataReader.Read()
                    If projOverviewDataReader.HasRows Then
                        rept_year_in = projOverviewDataReader("rept_year")
                        rept_isfinal_in = projOverviewDataReader("rept_isfinal")
                        rept_isapproved_in = projOverviewDataReader("rept_isapproved")

                        tempReport = New DaikonGrantReport(proj_num, rept_year_in, rept_isfinal_in, sareConnectionString)
                        addProposalReport(tempReport)
                    Else

                    End If
                Loop
                projOverviewDataReader.NextResult()
                Do While projOverviewDataReader.Read()
                    If projOverviewDataReader.HasRows Then
                        rept_year_in = projOverviewDataReader("rept_year")
                        rept_isfinal_in = projOverviewDataReader("rept_isfinal")
                        rept_isapproved_in = projOverviewDataReader("rept_isapproved")

                        tempReport = New DaikonGrantReport(proj_num, rept_year_in, rept_isfinal_in, sareConnectionString)
                        addAnnualReport(tempReport)
                    Else

                    End If
                Loop
                projOverviewDataReader.NextResult()
                Do While projOverviewDataReader.Read()
                    If projOverviewDataReader.HasRows Then
                        rept_year_in = projOverviewDataReader("rept_year")
                        rept_isfinal_in = projOverviewDataReader("rept_isfinal")
                        rept_isapproved_in = projOverviewDataReader("rept_isapproved")

                        tempReport = New DaikonGrantReport(proj_num, rept_year_in, rept_isfinal_in, sareConnectionString)
                        addFinalReport(tempReport)
                    Else

                    End If
                Loop

            End If

            projOverviewDataReader.Close()
            projOverviewConnection.Dispose()
        End If

    End Sub
    Public Sub addReport(ByVal newReport As DaikonGrantReport)
        Dim newReportKey As Integer
		newReportKey = newReport.getKeyID()
		If (grantReports.ContainsKey(newReportKey)) Then
		Else
            grantReports.Add(newReportKey, newReport)
		End If
	End Sub
    Public Sub addProposalReport(ByVal newReport As DaikonGrantReport)
        Dim newReportKey As Integer
        newReportKey = newReport.getKeyID()
        grantReports.Add(newReportKey, newReport)
    End Sub
    Public Sub addAnnualReport(ByVal newReport As DaikonGrantReport)
        Dim newReportKey As Integer
        newReportKey = newReport.getKeyID()
        grantReports.Add(newReportKey, newReport)
    End Sub
    Public Sub addFinalReport(ByVal newReport As DaikonGrantReport)
        Dim newReportKey As String
        newReportKey = newReport.getKeyID()
        grantReports.Add(newReportKey, newReport)
    End Sub

    Public Sub toXml(ByRef writer As XmlTextWriter)
        toXmlFull(writer)
    End Sub

    Public Sub toXmlFull(ByRef writer As XmlTextWriter)
        'Dim i As Integer

        writer.WriteStartElement("SAREgrant")

        toXmlBasics(writer)

        'For i = 0 To proposalReports.Count - 1
        '	proposalReports.GetByIndex(i).toXML(writer)
        'Next i
        'For i = 0 To annualReports.Count - 1
        '	annualReports.GetByIndex(i).toXML(writer)
        'Next i
        'For i = 0 To finalReports.Count - 1
        '	finalReports.GetByIndex(i).toXML(writer)
        'Next i
        If (grantReports IsNot Nothing) Then
            For Each cKey As String In grantReports.Keys()

                grantReports(cKey).toXML(writer)

            Next
        End If

        'For i = 0 To grantReports.Count - 1
        '	grantReports.GetByIndex(i).toXML(writer)
        'Next i

        grantProfile = New DaikonProfile(proj_num)
        If (grantProfile IsNot Nothing) Then
            grantProfile.toXml(writer)
        End If

        writer.WriteEndElement()

    End Sub

    Public Sub toXmlSummary(ByRef writer As XmlTextWriter)
        'Dim i As Integer

        writer.WriteStartElement("SAREgrant")

        toXmlBasics(writer)

        'ProductInfo
        toXmlProductInfo(writer)

        'For i = 0 To proposalReports.Count - 1
        '	proposalReports.GetByIndex(i).toXML(writer)
        'Next i
        'For i = 0 To annualReports.Count - 1
        '	annualReports.GetByIndex(i).toXML(writer)
        'Next i
        'For i = 0 To finalReports.Count - 1
        '	finalReports.GetByIndex(i).toXML(writer)
        'Next i
        'For i = 0 To grantReports.Count - 1
        '	grantReports.GetByIndex(i).toXML(writer)
        'Next i
        For Each cKey As String In grantReports.Keys()
            grantReports(cKey).toXML(writer)
        Next

        writer.WriteEndElement()

    End Sub

    Public Sub toXmlSummaryForNonReports(ByRef writer As XmlTextWriter)
        'Dim i As Integer

        writer.WriteStartElement("SAREgrant")

        toXmlBasics(writer)
        
        For Each cKey As String In grantReports.Keys()
            grantReports(cKey).toXML(writer)
        Next

        writer.WriteEndElement()

    End Sub

    Public Sub toXmlProductInfo(ByRef writer As XmlTextWriter)

        Dim sareConnectionString As String
        Dim productInfoSQL As String

        sareConnectionString = ConfigurationManager.ConnectionStrings("sareDaikonConnectionString").ConnectionString

        productInfoSQL = "DaikonProjectProductInfoListSubmittedByResProjNum"

        Dim productInfoConnection As New SqlConnection(sareConnectionString)
        Dim productInfoCommand As New SqlCommand
        Dim productInfoDataReader As SqlDataReader
        
        productInfoCommand.Connection = productInfoConnection
        productInfoCommand.CommandText = productInfoSQL
        productInfoCommand.CommandType = CommandType.StoredProcedure

        productInfoCommand.Parameters.Add("@res_projnum", SqlDbType.VarChar, 255).Value = proj_num

        If productInfoConnection.State = ConnectionState.Closed Then
            productInfoConnection.Open()
        End If
        productInfoDataReader = productInfoCommand.ExecuteReader()

        productInfoDataReader.Read()

        If productInfoDataReader.HasRows Then
            writer.WriteStartElement("resource")
            writer.WriteAttributeString("projNum", proj_num)
            writer.WriteAttributeString("typeCode", proj_type)
            ' productInfoDataReader("proj_num")
            writer.WriteElementString("title", proj_title)
            writer.WriteElementString("Submitted", "True")
            writer.WriteElementString("Approved", "False")
            writer.WriteEndElement()
        End If

        'productInfoDataReader.Close()

    End Sub

    Public Sub toXmlProductInfoPublic(ByRef writer As XmlTextWriter)

        Dim sareConnectionString As String
        Dim productInfoSQL As String

        sareConnectionString = ConfigurationManager.ConnectionStrings("sareDaikonConnectionString").ConnectionString

        productInfoSQL = "DaikonProjectProductInfoListApprovedByResProjNum"

        Dim productInfoConnection As SqlConnection
        Dim productInfoCommand As SqlCommand
        Dim productInfoDataReader As SqlDataReader

        productInfoConnection = New SqlConnection(sareConnectionString)

        productInfoCommand = New SqlCommand
        productInfoCommand.Connection = productInfoConnection
        productInfoCommand.CommandText = productInfoSQL
        productInfoCommand.CommandType = CommandType.StoredProcedure

        productInfoCommand.Parameters.Add("@res_projnum", SqlDbType.VarChar, 255).Value = proj_num

        productInfoConnection.Open()
        productInfoDataReader = productInfoCommand.ExecuteReader()

        writer.WriteStartElement("productInfo")
        writer.WriteAttributeString("projNum", projNum)

        Do While productInfoDataReader.Read()
            If productInfoDataReader.HasRows Then
                writer.WriteStartElement("resource")
                writer.WriteAttributeString("resourceID", productInfoDataReader("Resource_ID").ToString())
                writer.WriteElementString("title", productInfoDataReader("Title").ToString())
                writer.WriteElementString("Approved", "True")
                writer.WriteEndElement()
            Else

            End If
        Loop

        writer.WriteEndElement()

        productInfoDataReader.Close()

    End Sub

    Public Sub toXmlBasics(ByRef writer As XmlTextWriter)
        writer.WriteAttributeString("projNum", proj_num)
        If proj_endyear = 0 Then
            proj_endyear = proj_year + 1
        End If
        If proj_endyear.ToString().Length = 2 Then
            Dim projectEndYear As String
            projectEndYear = proj_year.ToString().Substring(0, 2) + proj_endyear.ToString()
            proj_endyear = Convert.ToInt32(projectEndYear)
        End If
        writer.WriteAttributeString("regionCode", proj_region)
        writer.WriteAttributeString("regionText", proj_region_text)
        writer.WriteAttributeString("year", proj_year)
        writer.WriteAttributeString("projectedEndYear", proj_endyear)
        writer.WriteAttributeString("typeCode", proj_type)
        writer.WriteAttributeString("typeText", proj_type_text)
        writer.WriteAttributeString("projectState", proj_state_abbr)
        If (searchRelevance > 0) Then
            writer.WriteAttributeString("searchRelevance", searchRelevance)
        End If

        writer.WriteElementString("title", proj_title)
        writer.WriteStartElement("funds")
        If funds_sare = 0 Then
            writer.WriteElementString("SARE", "0.0")
        Else
            writer.WriteElementString("SARE", funds_sare)
        End If
        If funds_matching_fed = 0 Then
            writer.WriteElementString("Fed", "0.0")
        Else
            writer.WriteElementString("Fed", funds_matching_fed)
        End If

        If funds_matching_nonfed = 0 Then
            writer.WriteElementString("NonFed", "0.0")
        Else
            writer.WriteElementString("NonFed", funds_matching_nonfed)
        End If
        writer.WriteElementString("Submitted", submitted)
        writer.WriteElementString("Approved", approved)
        writer.WriteEndElement()
    End Sub
    Public Sub toXmlReport(ByVal rept_year As Integer, ByVal rept_isfinal As Integer, ByRef writer As XmlTextWriter)

        writer.WriteStartElement("SAREgrant")
        toXmlBasics(writer)

        Dim reptKey As Integer
        reptKey = CInt(rept_year.ToString() & rept_isfinal.ToString())

        'Select Case rept_isfinal
        '	Case 0
        '		If annualReports.ContainsKey(reptKey) Then
        '			annualReports(reptKey).toXml(writer)
        '		End If
        '	Case 1
        '		If finalReports.ContainsKey(reptKey) Then
        '			finalReports(reptKey).toXml(writer)
        '		End If
        '	Case 2
        '		If proposalReports.ContainsKey(reptKey) Then
        '			proposalReports(reptKey).toXml(writer)
        '		End If

        'End Select

        If grantReports.ContainsKey(reptKey) Then
            grantReports(reptKey).toXML(writer)
        End If

        writer.WriteEndElement()
    End Sub

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is DaikonGrant Then
            Dim temp As DaikonGrant = CType(obj, DaikonGrant)

            Return proj_year.CompareTo(temp.proj_year)
        ElseIf TypeOf obj Is Integer Then
            Return proj_year.CompareTo(obj)
        ElseIf TypeOf obj Is String Then
            Dim comparisonString As String
            comparisonString = proj_year.ToString()
            Return comparisonString.CompareTo(obj)
        End If

        Throw New ArgumentException("object is not a DaikonGrant or valid Year")
    End Function
End Class

Public Class DaikonGrantCollection
    Inherits System.Collections.Generic.Dictionary(Of String, DaikonGrant)
    'Pulled from VS .NET 2003 documentation

    Protected maxRecords As Integer
    Public ReadOnly Property MaxRecord() As Integer
        Get
            Return maxRecords
        End Get
        '            Set(ByVal value As Integer)
        '               maxRecords = value
        '          End Set
    End Property

    Protected searchSelect As String
    Public Property SearchSelection() As String
        Get
            Return searchSelect
        End Get
        Set(ByVal value As String)
            searchSelect = value
        End Set
    End Property

    Public Sub populateByUsername(ByVal userName As String, ByVal sareConnectionString As String)
        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempProjNum As String

        grantCollectionSQL = "DaikonReportingGetProjectsByUser"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@username", SqlDbType.VarChar, 12).Value = userName
        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()

        '	Response.Write("")

        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")

                tempProject = New DaikonGrant(tempProjNum, sareConnectionString)
                Add(tempProjNum, tempProject)
            Else

            End If
        Loop

        grantCollectionConnection.Dispose()

    End Sub

    Public Sub populateByAdminAuth(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String)
        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempProjNum As String

        Dim tempReport As DaikonGrantReport

        '            Dim searchID As Integer
        '           Dim totalRank As Integer
		Dim proj_coreID As String
		Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        Dim rept_year As Integer
        Dim rept_isfinal As Integer
        Dim rept_isapproved As Boolean
        Dim wasSubmitted As Boolean
        Dim updatedDate As Date

        '          Dim partRank As Integer

        grantCollectionSQL = "DaikonReportingGetProjectsByAdmin2"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@username", SqlDbType.VarChar, 12).Value = userName
        grantCollectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()

        '	Response.Write("")
        '/*
        '         Do While grantCollectionDataReader.Read()
        '              If grantCollectionDataReader.HasRows Then
        '                   tempProjNum = grantCollectionDataReader("proj_num")
        '
        '                 tempProject = New DaikonGrant(tempProjNum, sareConnectionString)
        '                  Add(tempProjNum, tempProject)
        '               Else
        '
        '              End If
        '           Loop
        '*/

        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
				proj_coreID = grantCollectionDataReader("coreID")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                proj_region = grantCollectionDataReader("proj_region")
                proj_type = grantCollectionDataReader("proj_type")
                proj_year = grantCollectionDataReader("proj_year")

                If (grantCollectionDataReader("rept_year").Equals(DBNull.Value)) Then
                    rept_year = 0
                Else
                    rept_year = grantCollectionDataReader("rept_year")
                End If
                If (grantCollectionDataReader("rept_isfinal").Equals(DBNull.Value)) Then
                    rept_isfinal = 0
                Else
                    rept_isfinal = Math.Abs(CInt(grantCollectionDataReader("rept_isfinal")))
                End If

                If (grantCollectionDataReader("rept_isapproved").Equals(DBNull.Value)) Then
                    rept_isapproved = False
                Else
                    rept_isapproved = CBool(grantCollectionDataReader("rept_isapproved"))
                End If
                If (grantCollectionDataReader("submitted").Equals(DBNull.Value)) Then
                    wasSubmitted = False
                Else
                    wasSubmitted = CBool(grantCollectionDataReader("submitted"))
                End If

                If (grantCollectionDataReader("updatedDate").Equals(DBNull.Value)) Then
                    updatedDate = CDate("1/1/2000")
                Else
                    updatedDate = CDate(grantCollectionDataReader("updatedDate"))
                End If

                If (ContainsKey(tempProjNum) And rept_year > 0) Then
                    tempReport = New DaikonGrantReport(1, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                    Item(tempProjNum).addReport(tempReport)
                Else
                    tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, "0", "0", "0")

                    Add(tempProjNum, tempProject)
                    If rept_year > 0 Then
                        tempReport = New DaikonGrantReport(1, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                        Item(tempProjNum).addReport(tempReport)
                    End If
                End If
            Else

            End If
        Loop

        grantCollectionDataReader.NextResult()
        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                proj_coreID = grantCollectionDataReader("coreID")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                proj_region = grantCollectionDataReader("proj_region")
                proj_type = grantCollectionDataReader("proj_type")
                proj_year = grantCollectionDataReader("proj_year")

                If (grantCollectionDataReader("rept_year").Equals(DBNull.Value)) Then
                    rept_year = 0
                Else
                    rept_year = grantCollectionDataReader("rept_year")
                End If
                If (grantCollectionDataReader("rept_isfinal").Equals(DBNull.Value)) Then
                    rept_isfinal = 0
                Else
                    rept_isfinal = Math.Abs(CInt(grantCollectionDataReader("rept_isfinal")))
                End If

                If (grantCollectionDataReader("rept_isapproved").Equals(DBNull.Value)) Then
                    rept_isapproved = False
                Else
                    rept_isapproved = CBool(grantCollectionDataReader("rept_isapproved"))
                End If
                If (grantCollectionDataReader("submitted").Equals(DBNull.Value)) Then
                    wasSubmitted = False
                Else
                    wasSubmitted = CBool(grantCollectionDataReader("submitted"))
                End If

                If (grantCollectionDataReader("updatedDate").Equals(DBNull.Value)) Then
                    updatedDate = CDate("1/1/2000")
                Else
                    updatedDate = CDate(grantCollectionDataReader("updatedDate"))
                End If

                If (ContainsKey(tempProjNum) And rept_year > 0) Then
                    tempReport = New DaikonGrantReport(1, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                    Item(tempProjNum).addReport(tempReport)
                Else
                    tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, "0", "0", "0")

                    Add(tempProjNum, tempProject)
                    If rept_year > 0 Then
                        tempReport = New DaikonGrantReport(1, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                        Item(tempProjNum).addReport(tempReport)
                    End If
                End If
            Else

            End If
        Loop
        

    End Sub

    Public Sub populateByAdminUncliamedProjects(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String, ByVal region As String, ByVal projectNumber As String)

        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempProjNum As String

        Dim proj_coreID As String
        Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        Dim proj_region_text As String
        Dim proj_type_text As String
        Dim rept_isapproved As Boolean
        Dim wasSubmitted As Boolean
        Dim updatedDate As Date
        Dim projIndex As Integer

        grantCollectionSQL = "DaikonReportingGetProjectsUnclaimed"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        grantCollectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        grantCollectionCommand.Parameters.Add("@region", SqlDbType.VarChar, 2).Value = region
        grantCollectionCommand.Parameters.Add("@projNum", SqlDbType.VarChar, 50).Value = projectNumber
        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()


        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                proj_coreID = grantCollectionDataReader("coreID")
                proj_region = grantCollectionDataReader("proj_region")
                proj_region_text = grantCollectionDataReader("region_name")
                proj_type_text = grantCollectionDataReader("type_name")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                If (grantCollectionDataReader("proj_year").Equals(DBNull.Value)) Then
                    'proj_year = "0"
                    projIndex = tempProjNum.LastIndexOf("-")
                    proj_year = "20" + tempProjNum.Substring(projIndex - 2, 2)
                Else
                    proj_year = grantCollectionDataReader("proj_year")
                End If

                If (grantCollectionDataReader("proj_type").Equals(DBNull.Value)) Then
                    proj_type = "0"
                Else
                    proj_type = grantCollectionDataReader("proj_type")
                End If

                If (grantCollectionDataReader("approved").Equals(DBNull.Value)) Then
                    rept_isapproved = False
                Else
                    rept_isapproved = CBool(grantCollectionDataReader("approved"))
                End If
                If (grantCollectionDataReader("submitted").Equals(DBNull.Value)) Then
                    wasSubmitted = False
                Else
                    wasSubmitted = CBool(grantCollectionDataReader("submitted"))
                End If
                If (grantCollectionDataReader("updatedDate").Equals(DBNull.Value)) Then
                    updatedDate = CDate("1/1/2000")
                Else
                    updatedDate = CDate(grantCollectionDataReader("updatedDate"))
                End If

                tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, proj_region_text, proj_type_text)

                Add(tempProjNum, tempProject)

            Else

            End If
        Loop

        grantCollectionConnection.Dispose()

    End Sub

    Public Sub populateByCoordinateNameSearch(ByVal Name As String, ByVal sareConnectionString As String)

        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempProjNum As String

        Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        Dim lastName As String
        Dim firstName As String

        Dim projIndex As Integer

        grantCollectionSQL = "DaikonReportingGetProjectsByCoordName"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@CoordName", SqlDbType.VarChar, 120).Value = Name
        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()


        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                If (grantCollectionDataReader("proj_region").Equals(DBNull.Value)) Then
                    proj_region = ""
                Else
                    proj_region = grantCollectionDataReader("proj_region")
                End If
                lastName = grantCollectionDataReader("lastName")
                firstName = grantCollectionDataReader("firstName")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                If (grantCollectionDataReader("proj_year").Equals(DBNull.Value)) Then
                    projIndex = tempProjNum.LastIndexOf("-")
                    If (tempProjNum.Substring(projIndex - 2, 2) > 85) Then
                        proj_year = "19" + tempProjNum.Substring(projIndex - 2, 2)
                    Else
                        proj_year = "20" + tempProjNum.Substring(projIndex - 2, 2)
                    End If
                Else
                    proj_year = grantCollectionDataReader("proj_year")
                End If

                If (grantCollectionDataReader("proj_type").Equals(DBNull.Value)) Then
                    proj_type = "0"
                Else
                    proj_type = grantCollectionDataReader("proj_type")
                End If

                tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, lastName, firstName)

                If (ContainsKey(tempProjNum)) Then

                Else
                    Add(tempProjNum, tempProject)
                End If

            Else

            End If
        Loop

        grantCollectionDataReader.NextResult()

        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                proj_region = grantCollectionDataReader("proj_region")
                lastName = grantCollectionDataReader("lastName")
                firstName = grantCollectionDataReader("firstName")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                If (grantCollectionDataReader("proj_year").Equals(DBNull.Value)) Then
                    projIndex = tempProjNum.LastIndexOf("-")
                    If (tempProjNum.Substring(projIndex - 2, 2) > 85) Then
                        proj_year = "19" + tempProjNum.Substring(projIndex - 2, 2)
                    Else
                        proj_year = "20" + tempProjNum.Substring(projIndex - 2, 2)
                    End If
                Else
                    proj_year = grantCollectionDataReader("proj_year")
                End If

                If (grantCollectionDataReader("proj_type").Equals(DBNull.Value)) Then
                    proj_type = "0"
                Else
                    proj_type = grantCollectionDataReader("proj_type")
                End If

                tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, lastName, firstName)

                Add(tempProjNum, tempProject)

            Else

            End If
        Loop


        grantCollectionConnection.Dispose()

    End Sub

    Public Sub populateByAdminProjectsOverviewNotSubmit(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String, ByVal region As String)

        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempProjNum As String

        Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        Dim proj_region_text As String
        Dim proj_type_text As String
        Dim projIndex As Integer

        grantCollectionSQL = "DaikonReportingGetProjectsOverviewNotSubmitted"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        grantCollectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        grantCollectionCommand.Parameters.Add("@region", SqlDbType.VarChar, 2).Value = region
        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()


        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                proj_region = grantCollectionDataReader("proj_region")
                proj_region_text = grantCollectionDataReader("region_name")
                proj_type_text = grantCollectionDataReader("type_name")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                If (grantCollectionDataReader("proj_year").Equals(DBNull.Value)) Then
                    'proj_year = "0"
                    projIndex = tempProjNum.LastIndexOf("-")
                    proj_year = "20" + tempProjNum.Substring(projIndex - 2, 2)
                Else
                    proj_year = grantCollectionDataReader("proj_year")
                End If

                If (grantCollectionDataReader("proj_type").Equals(DBNull.Value)) Then
                    proj_type = "0"
                Else
                    proj_type = grantCollectionDataReader("proj_type")
                End If
                
                tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, proj_region_text, proj_type_text)

                Add(tempProjNum, tempProject)

            Else

            End If
        Loop

        grantCollectionConnection.Dispose()

    End Sub

    Public Sub populateByAdminProjectsNoReports(ByVal userName As String, ByVal sessionKey As Integer, ByVal sareConnectionString As String, ByVal region As String)

        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempProjNum As String

        Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        Dim proj_region_text As String
        Dim proj_type_text As String
        Dim projIndex As Integer

        grantCollectionSQL = "DaikonReportingGetProjectsNoReports"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@user", SqlDbType.VarChar, 12).Value = userName
        grantCollectionCommand.Parameters.Add("@sKey", SqlDbType.Int).Value = sessionKey
        grantCollectionCommand.Parameters.Add("@region", SqlDbType.VarChar, 2).Value = region
        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()


        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                proj_region = grantCollectionDataReader("proj_region")
                proj_region_text = grantCollectionDataReader("region_name")
                proj_type_text = grantCollectionDataReader("type_name")

                If (grantCollectionDataReader("proj_title").Equals(DBNull.Value)) Then
                    proj_title = ""
                Else
                    proj_title = grantCollectionDataReader("proj_title")
                End If

                If (grantCollectionDataReader("proj_year").Equals(DBNull.Value)) Then
                    projIndex = tempProjNum.LastIndexOf("-")
                    If tempProjNum.Substring(projIndex - 2, 1) = 0 Or tempProjNum.Substring(projIndex - 2, 1) = 1 Then
                        proj_year = "20" + tempProjNum.Substring(projIndex - 2, 2)
                    Else
                        proj_year = "19" + tempProjNum.Substring(projIndex - 2, 2)
                    End If

                Else
                    proj_year = grantCollectionDataReader("proj_year")
                End If

                If (grantCollectionDataReader("proj_type").Equals(DBNull.Value)) Then
                    proj_type = "0"
                Else
                    proj_type = grantCollectionDataReader("proj_type")
                End If

                tempProject = New DaikonGrant(tempProjNum, 1, proj_title, proj_region, proj_year, proj_type, proj_region_text, proj_type_text)

                Add(tempProjNum, tempProject)

            Else

            End If
        Loop

        grantCollectionConnection.Dispose()

    End Sub

    Public Function StripNoiseWords(ByVal s As String) As String
        'Dim NoiseWordsRegex As String = "1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 0 | $ | ! | @ | # | $ | % | ^ | & | * | ( | ) | - | _ | + | = | [ | ] | { | } | about | after | all | also | an | and | another | any | are | as | at | be | because | been | before | being | between | both | but | by | came | can | come | could | did | do | does | each | else | for | from | get | got | has | had | he | have | her | here | him | himself | his | how | if | in | into | is | it | its | just | like | make | many | me | might | more | most | much | must | my | never | now | of | on | only | or | other | our | out | over | re | said | same | see | should | since | so | some | still | such | take | than | that | the | their | them | then | there | these | they | this | those | through | to | too | under | up | use | very | want | was | way | we | well | were | what | when | where | which | while | who | will | with | would | you | your | a | b | c | d | e | f | g | h | i | j | k | l | m | n | o | p | q | r | s | t | u | v | w | x | y | z"
        'Dim NoiseWordsRegex As String = Regex.Replace(NoiseWords, "\s+", "|") ' about|after|all|also etc.
        Dim NoiseWordsRegex As String = "about|after|all|also|an|and|another|any|are|as|at|be|because|been|before|being|between|both|but|by|came|can|come|could|did|do|does|each|else|for|from|get|got|has|had|he|have|her|here|him|himself|his|how|if|in|into|is|it|its|just|like|make|many|me|might|more|most|much|must|my|never|now|of|on|only|or|other|our|out|over|re|said|same|see|should|since|so|some|still|such|take|than|that|the|their|them|then|there|these|they|this|those|through|to|too|under|up|use|very|want|was|way|we|well|were|what|when|where|which|while|who|will|with|would|you|your|a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z|$|1|2|3|4|5|6|7|8|9|0|-"
        NoiseWordsRegex = String.Format("\s?\b(?:{0})\b\s?", NoiseWordsRegex)
        Dim Result As String = Regex.Replace(s, NoiseWordsRegex, " ", RegexOptions.IgnoreCase) ' replace each noise word with a space
        Result = Regex.Replace(Result, "\s+", " ") ' eliminate any multiple spaces
        Return Result
    End Function

    Public Sub populateBySearch(ByVal searchTerms As String, ByVal condRegion As String, ByVal condState As String, ByVal condProjType As Integer, ByVal orderRanked As Integer, ByVal orderDesc As Boolean, ByVal rowsPerPage As Integer, ByVal thisPage As Integer, ByVal sareConnectionString As String, ByVal searchBy As String)
        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        Dim tempReport As DaikonGrantReport

        Dim tempProjNum As String
        Dim searchID As Integer
        Dim totalRank As Integer
        Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        Dim rept_year As Integer
        Dim rept_isfinal As Integer
        Dim rept_isapproved As Boolean
        Dim wasSubmitted As Boolean
        Dim updatedDate As Date

        Dim partRank As Integer

        If (String.IsNullOrEmpty(searchTerms)) Then
            searchTerms = ""
        ElseIf searchSelect = "phrase" Then
            searchTerms = Regex.Replace(searchTerms, "\b(\w{1,})\b", "formsof(inflectional, " & Chr(34) & searchTerms & Chr(34) & ")")
            'searchTerms = searchTerms.Insert(searchTerms.IndexOf(")") + 1, " AND")
            searchTerms = searchTerms.Substring(0, searchTerms.IndexOf(")") + 1)
        Else
            searchTerms = StripNoiseWords(searchTerms)
            searchTerms = ParseQueryString(searchTerms)
        End If

        If searchBy = "public" Then
            If condState = "" Then
                grantCollectionSQL = "DaikonReportingPagedRankedSearch"
            Else
                grantCollectionSQL = "DaikonReportingPagedRankedSearchWithProjectState"
            End If
        Else
            If condState = "" Then
                grantCollectionSQL = "DaikonReportingPagedRankedSearchAdminOptimized"
            Else
                grantCollectionSQL = "DaikonReportingPagedRankedSearchAdminForProjectState"
            End If
        End If

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@condTerms", SqlDbType.VarChar, 2025).Value = searchTerms
        grantCollectionCommand.Parameters.Add("@condRegion", SqlDbType.VarChar, 2).Value = condRegion
        grantCollectionCommand.Parameters.Add("@condState", SqlDbType.VarChar, 4).Value = condState
        grantCollectionCommand.Parameters.Add("@condProjType", SqlDbType.Int).Value = condProjType
        grantCollectionCommand.Parameters.Add("@orderRanked", SqlDbType.TinyInt).Value = orderRanked
        grantCollectionCommand.Parameters.Add("@orderDesc", SqlDbType.Bit).Value = orderDesc
        grantCollectionCommand.Parameters.Add("@rowsPerPage", SqlDbType.Int).Value = rowsPerPage
        grantCollectionCommand.Parameters.Add("@thisPage", SqlDbType.Int).Value = thisPage
        grantCollectionConnection.Open()
        grantCollectionCommand.CommandTimeout = 300
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()

        '	Response.Write("")
        'ignore the first result table for now
        grantCollectionDataReader.Read()
        maxRecords = grantCollectionDataReader("maxProjRes")

        grantCollectionDataReader.NextResult()

        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                searchID = grantCollectionDataReader("searchID")
                totalRank = grantCollectionDataReader("totalRank")
                proj_title = grantCollectionDataReader("proj_title")
                proj_region = grantCollectionDataReader("proj_region")
                proj_type = grantCollectionDataReader("proj_type")
                proj_year = grantCollectionDataReader("proj_year")
                If (grantCollectionDataReader("rept_year").Equals(DBNull.Value)) Then
                    rept_year = 0
                Else
                    rept_year = grantCollectionDataReader("rept_year")
                End If
                If (grantCollectionDataReader("rept_isfinal").Equals(DBNull.Value)) Then
                    rept_isfinal = 0
                Else
                    rept_isfinal = Math.Abs(CInt(grantCollectionDataReader("rept_isfinal")))
                End If

                If (grantCollectionDataReader("rept_isapproved").Equals(DBNull.Value)) Then
                    rept_isapproved = False
                Else
                    rept_isapproved = CBool(grantCollectionDataReader("rept_isapproved"))
                End If
                If (grantCollectionDataReader("submitted").Equals(DBNull.Value)) Then
                    wasSubmitted = False
                Else
                    wasSubmitted = CBool(grantCollectionDataReader("submitted"))
                End If
                If (grantCollectionDataReader("updatedDate").Equals(DBNull.Value)) Then
                    updatedDate = CDate("1/1/2000")
                Else
                    updatedDate = CDate(grantCollectionDataReader("updatedDate"))
                End If

                partRank = grantCollectionDataReader("partRank")

                If (ContainsKey(tempProjNum) And rept_year > 0) Then
                    tempReport = New DaikonGrantReport(partRank, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                    Item(tempProjNum).addReport(tempReport)
                Else
                    tempProject = New DaikonGrant(tempProjNum, totalRank, proj_title, proj_region, proj_year, proj_type, "0", "0", "0")
                    Add(tempProjNum, tempProject)
                    If rept_year > 0 Then
                        tempReport = New DaikonGrantReport(partRank, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                        Item(tempProjNum).addReport(tempReport)
                    End If
                End If
            Else

            End If
        Loop

        grantCollectionDataReader.Close()
        grantCollectionConnection.Dispose()

    End Sub
    Public Sub populateByProfileSearch(ByVal searchTerms As String, ByVal condRegion As String, ByVal condState As String, ByVal condProjType As Integer, ByVal numChosenFields As Integer, ByVal orderRanked As Boolean, ByVal orderDesc As Boolean, ByVal rowsPerPage As Integer, ByVal thisPage As Integer, ByVal searchProfile As DaikonSearchProfile, ByVal sareConnectionString As String)
        Dim grantCollectionSQL As String
        Dim tempProject As DaikonGrant
        'Dim tempReport As DaikonGrantReport

        Dim tempProjNum As String
        Dim searchID As Integer
        Dim totalRank As Integer
        Dim proj_title As String
        Dim proj_region As String
        Dim proj_type As String
        Dim proj_year As String
        'Dim rept_year As Integer
        'Dim rept_isfinal As Integer
        'Dim rept_isapproved As Boolean
        'Dim wasSubmitted As Boolean
        'Dim updatedDate As Date

        'Dim partRank As Integer

        If (String.IsNullOrEmpty(searchTerms)) Then
            searchTerms = ""
        Else
            searchTerms = ParseQueryString(searchTerms)
        End If

        grantCollectionSQL = "DaikonProfilesProfileSearch2"

        Dim grantCollectionConnection As SqlConnection
        Dim grantCollectionCommand As SqlCommand
        Dim grantCollectionDataReader As SqlDataReader

        grantCollectionConnection = New SqlConnection(sareConnectionString)

        grantCollectionCommand = New SqlCommand
        grantCollectionCommand.Connection = grantCollectionConnection
        grantCollectionCommand.CommandText = grantCollectionSQL
        grantCollectionCommand.CommandType = CommandType.StoredProcedure

        grantCollectionCommand.Parameters.Add("@condTerms", SqlDbType.VarChar, 255).Value = searchTerms
        grantCollectionCommand.Parameters.Add("@condRegion", SqlDbType.VarChar, 2).Value = condRegion
        grantCollectionCommand.Parameters.Add("@condState", SqlDbType.VarChar, 4).Value = condState
        grantCollectionCommand.Parameters.Add("@condProjType", SqlDbType.Int).Value = condProjType
        grantCollectionCommand.Parameters.Add("@numChosenFields", SqlDbType.Int).Value = numChosenFields
        grantCollectionCommand.Parameters.Add("@orderRanked", SqlDbType.Bit).Value = orderRanked
        grantCollectionCommand.Parameters.Add("@orderDesc", SqlDbType.Bit).Value = orderDesc
        grantCollectionCommand.Parameters.Add("@rowsPerPage", SqlDbType.Int).Value = rowsPerPage
        grantCollectionCommand.Parameters.Add("@thisPage", SqlDbType.Int).Value = thisPage

        grantCollectionCommand.Parameters.Add("@categoryA", SqlDbType.VarChar, 50)
        grantCollectionCommand.Parameters.Add("@catAother", SqlDbType.VarChar, 80)
        grantCollectionCommand.Parameters.Add("@categoryB", SqlDbType.VarChar, 50)
        grantCollectionCommand.Parameters.Add("@catBother", SqlDbType.VarChar, 80)

        grantCollectionCommand.Parameters.Add("@aud_farmranchers", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@aud_educators", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@aud_researchers", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@aud_consumers", SqlDbType.Bit)

        grantCollectionCommand.Parameters.Add("@techlvl_beginner", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@techlvl_intermediate", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@techlvl_advanced", SqlDbType.Bit)

        grantCollectionCommand.Parameters.Add("@inv_planning", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@inv_present", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@inv_research", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@inv_land", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@inv_planningcount", SqlDbType.Int)
        grantCollectionCommand.Parameters.Add("@inv_presentcount", SqlDbType.Int)
        grantCollectionCommand.Parameters.Add("@inv_researchcount", SqlDbType.Int)
        grantCollectionCommand.Parameters.Add("@inv_landcount", SqlDbType.Int)
        grantCollectionCommand.Parameters.Add("@inv_numparticipants", SqlDbType.Int)
        grantCollectionCommand.Parameters.Add("@inv_numideas", SqlDbType.Int)
        grantCollectionCommand.Parameters.Add("@inv_extplanning", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@inv_extapplied", SqlDbType.Bit)

        grantCollectionCommand.Parameters("@categoryA").Value = searchProfile.CategoryA
        grantCollectionCommand.Parameters("@catAother").Value = searchProfile.CatAother
        grantCollectionCommand.Parameters("@categoryB").Value = searchProfile.CategoryB
        grantCollectionCommand.Parameters("@catBother").Value = searchProfile.CatBother

        grantCollectionCommand.Parameters("@aud_farmranchers").Value = searchProfile.AudFarmRanchers
        grantCollectionCommand.Parameters("@aud_educators").Value = searchProfile.AudEducators
        grantCollectionCommand.Parameters("@aud_researchers").Value = searchProfile.AudResearchers
        grantCollectionCommand.Parameters("@aud_consumers").Value = searchProfile.Audconsumers

        grantCollectionCommand.Parameters("@techlvl_beginner").Value = searchProfile.TechlvlBeginner
        grantCollectionCommand.Parameters("@techlvl_intermediate").Value = searchProfile.TechlvlIntermediate
        grantCollectionCommand.Parameters("@techlvl_advanced").Value = searchProfile.TechlvlAdvanced

        grantCollectionCommand.Parameters("@inv_planning").Value = searchProfile.InvPlanning
        grantCollectionCommand.Parameters("@inv_present").Value = searchProfile.InvPresent
        grantCollectionCommand.Parameters("@inv_research").Value = searchProfile.InvResearch
        grantCollectionCommand.Parameters("@inv_land").Value = searchProfile.InvLand
        grantCollectionCommand.Parameters("@inv_planningcount").Value = searchProfile.InvNumPlanning
        grantCollectionCommand.Parameters("@inv_presentcount").Value = searchProfile.InvNumPresent
        grantCollectionCommand.Parameters("@inv_researchcount").Value = searchProfile.InvNumResearch
        grantCollectionCommand.Parameters("@inv_landcount").Value = searchProfile.InvNumLand
        grantCollectionCommand.Parameters("@inv_extplanning").Value = searchProfile.InvExtPlanning
        grantCollectionCommand.Parameters("@inv_extapplied").Value = searchProfile.InvExtApplied

        grantCollectionCommand.Parameters.Add("@intgfrs_AgroecosystemAnalysis", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@intgfrs_WholeFarmPlanning", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@intgfrs_HolisticManagement", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@intgfrs_OrganicAgriculture", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@intgfrs_Permaculture", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@intgfrs_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@cropprd_Agroforestry", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_FoliarFeeding", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_NutrientCycling", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_StripCropping", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_BiologicalInoculants", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Forestry", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_OrganicFertilizers", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_StubbleMulching", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_ContinuousCropping", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_GreenManures", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_OrganicMatter", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_TissueAnalysis", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_CoverCrops", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Intercropping", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Permaculture", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Transitioning", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_DoubleCropping", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_MinimumTillage", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_ReducedApplications", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Earthworms", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_MultipleCropping", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_RelayCropping", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Fallow", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_MunicipalWastes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_RidgeTillage", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Fertigation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_NoTill", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_SoilAnalysis", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_CatchCrops", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_CropRotation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Irrigation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_CropBreeding", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@cropprd_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@animprd_AlternativeFeedstuffs", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_FeedRations", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_MultispeciesGrazing", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_StockpiledForages", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_AlternativeHousing", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_FreeRange", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_PastureFertility", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Vaccines", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_AlternParasiteControl", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_HerbalMedicines", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_PastureRenovation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_WateringSystem", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_AnimalProtection", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Homeopathy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_PreventivePractices", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_WinterForage", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Composting", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Implants", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Probiotics", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_ContinuousGrazing", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Inoculants", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_RangeImprovement", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_FeedAdditives", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_ManureManagement", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_RotationalGrazing", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_FeedFormulation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_MineralSupplements", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_ShadeShelter", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Therapeutics", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_LivestockBreeding", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_StockingRate", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_grazingmanagement", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@animprd_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@pestmgt_Allelopathy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_EconomicThreshold", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_MechanicalControl", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_SmotherCrops", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_BiologicalControl", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Eradication", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_PhysicalControl", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Traps", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_BiorationalPesticides", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Flame", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_PlasticMulching", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_TrapCrops", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_BotanicalPesticides", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_FieldMonitoring", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_PrecisionCultivation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_VegetativeMulching", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_ChemicalControl", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_GeneticResistance", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_PrecisionHerbicideUse", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_WeatherMonitoring", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Competition", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_IPM", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Prevention", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_WeedEcology", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_CompostExtracts", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_KilledMulches", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_RowCovers", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_WeederGeese", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_CulturalControl", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_LivingMulches", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Sanitation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_DiseaseVectors", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_MatingDisruption", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_SoilSolarization", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@pestmgt_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@soilmgt_NutrientMineralization", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_SoilMicrobiology", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_SoilOrganicMatter", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_SoilQuality", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_CarbonSequestration", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_SoilChemistry", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_SoilPhysics", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@soilmgt_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@nresenv_Afforestation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_GrassHedges", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_RiparianPlantings", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Wildlife", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Biodiversity", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_GrassWaterways", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_RiverbankProtection", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Windbreaks", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Biosphere", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_HabitatEnhancement", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_SoilStabilization", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_WoodyHedges", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_ConservationTillage", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Hedgerows", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Terraces", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_ContourCultivation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Indicators", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Wetlands", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@nresenv_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@edtrain_CaseStudy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Demonstration", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_FocusGroup", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_StudyCircle", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Conference", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Display", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Mentor", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Workshop", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Curriculum", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Extension", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Network", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Database", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_FactSheet", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_OnFarmResearch", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_DecisionSupportSystem", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_FarmerToFarmer", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_ParticipatoryResearch", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_YouthEducation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@edtrain_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@econmkt_AlternativeEnterprise", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_CSA", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_FeasibilityStudy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_RiskManagement", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_Budget", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_CostAndReturns", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_FinancialAnalysis", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_ValueAdded", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_Cooperatives", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_DirectMarketing", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_MarketStudy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_FoodProductQualitySafety", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_LaborEmployment", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_Ecommerce", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_FarmToInstitution", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@econmkt_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@commdev_InfrastructureAnalysis", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_TechnicalAssistance", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_NewBusinessOpportunities", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_Partnerships", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_UrbanAgriculture", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_PublicParticipation", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_UrbanRuralIntegration", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_LocalRegionalCommunityFoodSystems", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_Agritourism", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_PublicPolicy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_CommunityPlanning", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_LeadershipDevelopment", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_EthnicDifferencesCulturalDemographicChange", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commdev_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@qoflife_AnalysisOfPersonalFamilyLife", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_SocialCapitol", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_SustainabilityMeasures", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_CommunityServices", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_SocialNetworks", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_EmploymentOpportunities", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_SocialPsychologicalIndicators", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@qoflife_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@energy_BioenergyBiofuels", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@energy_WindPower", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@energy_EnergyUseConsumption", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@energy_SolarEnergy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@energy_EnergyConservationEfficiency", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@energy_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@commPlAgr_Barley", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_GrassLegumeHay", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Peanuts", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Sorghum", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Sweetpotatoes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Canola", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_LegumeHay", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Potatoes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Soybeans", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Tobacco", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Corn", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Hops", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Rapeseed", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Spelt", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Wheat", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Cotton", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Kenaf", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Rice", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Sugarbeets", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Flax", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Millet", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Rye", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Sugarcane", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_GrassHay", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Oats", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Safflower", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Sunflower", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAgr_Other", SqlDbType.NVarChar, 80)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Artichokes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Cabbage", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Escarole", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Onions", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_SweetCorn", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Asparagus", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Carrots", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Garlic", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Parsnips", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Tomatoes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Beans", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Cauliflower", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Greens", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Peas", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Turnips", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Beets", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Celery", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Kale", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Peppers", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Watermelon", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Broccoli", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Cucumbers", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Lentils", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Rutabagas", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_BrusselSprouts", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Eggplant", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Lettuce", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Spinach", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commplveg_leeks", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Pumpkins", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Squashes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Radishes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlVeg_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@commPlFruit_Apples", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Cherries", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Lemons", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Peaches", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Strawberries", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Apricots", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Cranberries", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Limes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Pears", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Tangerines", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Avocados", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Figs", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Melons", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Pineapples", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Bananas", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Grapefruit", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Olives", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Plums", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Berries", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Grapes", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Oranges", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Quinces", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Brambles", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Blueberries", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlFruit_Other", SqlDbType.NVarChar, 80)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Almonds", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Hazelnuts", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Pecans", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Walnuts", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commplnuts_chestnuts", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Macadamia", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Pistachios", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlNuts_Other", SqlDbType.NVarChar, 80)
        grantCollectionCommand.Parameters.Add("@commPlAdd_Herbs", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAdd_Ornamentals", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAdd_Trees", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAdd_Mushrooms", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAdd_NativePlants", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commPlAdd_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters.Add("@commAnim_Beef", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Chicken", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Rabbits", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Swine", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Dairy", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Goats", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Sheep", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Turkeys", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commAnim_Other", SqlDbType.NVarChar, 80)
        grantCollectionCommand.Parameters.Add("@commMisc_Bees", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commMisc_Fish", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commMisc_Ratites", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commMisc_Shellfish", SqlDbType.Bit)
        grantCollectionCommand.Parameters.Add("@commMisc_Other", SqlDbType.NVarChar, 80)

        grantCollectionCommand.Parameters("@intgfrs_AgroecosystemAnalysis").Value = searchProfile.IntgfrsAgroEcoSystemAnalysis
        grantCollectionCommand.Parameters("@intgfrs_WholeFarmPlanning").Value = searchProfile.IntgfrsWholeFarmPlanning
        grantCollectionCommand.Parameters("@intgfrs_HolisticManagement").Value = searchProfile.IntgfrsHolisticMgmt
        grantCollectionCommand.Parameters("@intgfrs_OrganicAgriculture").Value = searchProfile.IntgfrsOrgAgri
        grantCollectionCommand.Parameters("@intgfrs_Permaculture").Value = searchProfile.IntgfrsPermaCulture
        grantCollectionCommand.Parameters("@intgfrs_Other").Value = searchProfile.IntgfrsOther

        grantCollectionCommand.Parameters("@cropprd_Agroforestry").Value = searchProfile.CropprdAgroforesty
        grantCollectionCommand.Parameters("@cropprd_FoliarFeeding").Value = searchProfile.CropprdFoliarFeeding
        grantCollectionCommand.Parameters("@cropprd_NutrientCycling").Value = searchProfile.CropprdNutriCycling
        grantCollectionCommand.Parameters("@cropprd_StripCropping").Value = searchProfile.CropprdStripCropping
        grantCollectionCommand.Parameters("@cropprd_BiologicalInoculants").Value = searchProfile.CropprdBioInoculants
        grantCollectionCommand.Parameters("@cropprd_Forestry").Value = 0
        grantCollectionCommand.Parameters("@cropprd_OrganicFertilizers").Value = searchProfile.CropprdOrgFertilizers
        grantCollectionCommand.Parameters("@cropprd_StubbleMulching").Value = searchProfile.CropprdStubbleMulch
        grantCollectionCommand.Parameters("@cropprd_ContinuousCropping").Value = searchProfile.CropprdContinousCrop
        grantCollectionCommand.Parameters("@cropprd_GreenManures").Value = searchProfile.CropprdGreenManures
        grantCollectionCommand.Parameters("@cropprd_OrganicMatter").Value = searchProfile.CropprdOrgMatter
        grantCollectionCommand.Parameters("@cropprd_TissueAnalysis").Value = searchProfile.CropprdTissueAnalysis
        grantCollectionCommand.Parameters("@cropprd_CoverCrops").Value = searchProfile.CropprdCoverCrops
        grantCollectionCommand.Parameters("@cropprd_Intercropping").Value = searchProfile.CropprdInterCropping
        grantCollectionCommand.Parameters("@cropprd_Permaculture").Value = searchProfile.CropprdPermaCulture
        grantCollectionCommand.Parameters("@cropprd_Transitioning").Value = searchProfile.CropprdTrans
        grantCollectionCommand.Parameters("@cropprd_DoubleCropping").Value = searchProfile.CropprdDoubleCropping
        grantCollectionCommand.Parameters("@cropprd_MinimumTillage").Value = searchProfile.CropprdMiniTillage
        grantCollectionCommand.Parameters("@cropprd_ReducedApplications").Value = searchProfile.CropprdReduceApps
        grantCollectionCommand.Parameters("@cropprd_Earthworms").Value = searchProfile.CropprdEarthworms
        grantCollectionCommand.Parameters("@cropprd_MultipleCropping").Value = searchProfile.CropprdMultiCropping
        grantCollectionCommand.Parameters("@cropprd_RelayCropping").Value = searchProfile.CropprdRelayCropping
        grantCollectionCommand.Parameters("@cropprd_Fallow").Value = searchProfile.CropprdFallow
        grantCollectionCommand.Parameters("@cropprd_MunicipalWastes").Value = searchProfile.CropprdMunicipalWastes
        grantCollectionCommand.Parameters("@cropprd_RidgeTillage").Value = searchProfile.CropprdRidgeTillage
        grantCollectionCommand.Parameters("@cropprd_Fertigation").Value = searchProfile.CropprdFertigation
        grantCollectionCommand.Parameters("@cropprd_NoTill").Value = searchProfile.CropprdNoTill
        grantCollectionCommand.Parameters("@cropprd_SoilAnalysis").Value = searchProfile.CropprdSoilAnalysis
        grantCollectionCommand.Parameters("@cropprd_CatchCrops").Value = searchProfile.CropprdCatchCrops
        grantCollectionCommand.Parameters("@cropprd_CropRotation").Value = searchProfile.CropprdCropRotation
        grantCollectionCommand.Parameters("@cropprd_CropBreeding").Value = searchProfile.CropprdCropBreeding
        grantCollectionCommand.Parameters("@cropprd_Irrigation").Value = searchProfile.CropprdIrrigation
        grantCollectionCommand.Parameters("@cropprd_Other").Value = searchProfile.CropprdOther

        grantCollectionCommand.Parameters("@animprd_AlternativeFeedstuffs").Value = searchProfile.AnimprdAltFeedstuffs
        grantCollectionCommand.Parameters("@animprd_FeedRations").Value = searchProfile.AnimprdFeedRations
        grantCollectionCommand.Parameters("@animprd_MultispeciesGrazing").Value = searchProfile.AnimprdMultiSpeciesGrazing
        grantCollectionCommand.Parameters("@animprd_StockpiledForages").Value = searchProfile.AnimprdStockpiledForages
        grantCollectionCommand.Parameters("@animprd_AlternativeHousing").Value = searchProfile.AnimprdAltHousing
        grantCollectionCommand.Parameters("@animprd_FreeRange").Value = searchProfile.AnimprdFreeRange
        grantCollectionCommand.Parameters("@animprd_PastureFertility").Value = searchProfile.AnimprdPastureFerti
        grantCollectionCommand.Parameters("@animprd_Vaccines").Value = searchProfile.AnimprdVaccines
        grantCollectionCommand.Parameters("@animprd_AlternParasiteControl").Value = searchProfile.AnimprdAltParasiteControl
        grantCollectionCommand.Parameters("@animprd_HerbalMedicines").Value = searchProfile.AnimprdHerbalMed
        grantCollectionCommand.Parameters("@animprd_PastureRenovation").Value = searchProfile.AnimprdPastureRenovation
        grantCollectionCommand.Parameters("@animprd_WateringSystem").Value = searchProfile.AnimprdWateringSys
        grantCollectionCommand.Parameters("@animprd_AnimalProtection").Value = searchProfile.AnimprdAnimalProtection
        grantCollectionCommand.Parameters("@animprd_Homeopathy").Value = searchProfile.AnimprdHomeopathy
        grantCollectionCommand.Parameters("@animprd_PreventivePractices").Value = searchProfile.AnimprdPreventivePract
        grantCollectionCommand.Parameters("@animprd_WinterForage").Value = searchProfile.AnimprdWinterForage
        grantCollectionCommand.Parameters("@animprd_Composting").Value = searchProfile.AnimprdComposting
        grantCollectionCommand.Parameters("@animprd_Implants").Value = searchProfile.AnimprdImplants
        grantCollectionCommand.Parameters("@animprd_Probiotics").Value = searchProfile.AnimprdProbiotics
        grantCollectionCommand.Parameters("@animprd_ContinuousGrazing").Value = searchProfile.AnimprdContGrazing
        grantCollectionCommand.Parameters("@animprd_Inoculants").Value = searchProfile.AnimprdInoculants
        grantCollectionCommand.Parameters("@animprd_RangeImprovement").Value = searchProfile.AnimprdRangeImprovement
        grantCollectionCommand.Parameters("@animprd_FeedAdditives").Value = searchProfile.AnimprdFeedAdditives
        grantCollectionCommand.Parameters("@animprd_ManureManagement").Value = searchProfile.AnimprdManureMgmt
        grantCollectionCommand.Parameters("@animprd_RotationalGrazing").Value = searchProfile.AnimprdRotGrazing
        grantCollectionCommand.Parameters("@animprd_FeedFormulation").Value = searchProfile.AnimprdFeedFormulation
        grantCollectionCommand.Parameters("@animprd_MineralSupplements").Value = searchProfile.AnimprdMineralSupp
        grantCollectionCommand.Parameters("@animprd_ShadeShelter").Value = searchProfile.AnimprdShadeShelter
        grantCollectionCommand.Parameters("@animprd_Therapeutics").Value = searchProfile.AnimprdTherapeutics
        grantCollectionCommand.Parameters("@animprd_LivestockBreeding").Value = searchProfile.AnimprdLivestockBreeding
        grantCollectionCommand.Parameters("@animprd_StockingRate").Value = searchProfile.AnimprdStockingRate
        grantCollectionCommand.Parameters("@animprd_grazingmanagement").Value = searchProfile.AnimprdGrazMgmt
        grantCollectionCommand.Parameters("@animprd_Other").Value = searchProfile.AnimprdOther

        grantCollectionCommand.Parameters("@pestmgt_Allelopathy").Value = searchProfile.PestMgmtAllelopathy
        grantCollectionCommand.Parameters("@pestmgt_EconomicThreshold").Value = searchProfile.PestMgmtEcoThreshold
        grantCollectionCommand.Parameters("@pestmgt_MechanicalControl").Value = searchProfile.PestMgmtMechControl
        grantCollectionCommand.Parameters("@pestmgt_SmotherCrops").Value = searchProfile.PestMgmtSmotherCrops
        grantCollectionCommand.Parameters("@pestmgt_BiologicalControl").Value = searchProfile.PestMgmtBioControl
        grantCollectionCommand.Parameters("@pestmgt_Eradication").Value = searchProfile.PestMgmtEradication
        grantCollectionCommand.Parameters("@pestmgt_PhysicalControl").Value = searchProfile.PestMgmtPhyControl
        grantCollectionCommand.Parameters("@pestmgt_Traps").Value = searchProfile.PestMgmtTraps
        grantCollectionCommand.Parameters("@pestmgt_BiorationalPesticides").Value = searchProfile.PestMgmtBioPest
        grantCollectionCommand.Parameters("@pestmgt_Flame").Value = searchProfile.PestMgmtFlame
        grantCollectionCommand.Parameters("@pestmgt_PlasticMulching").Value = searchProfile.PestMgmtPlasticMulch
        grantCollectionCommand.Parameters("@pestmgt_TrapCrops").Value = searchProfile.PestMgmtTrapCrops
        grantCollectionCommand.Parameters("@pestmgt_BotanicalPesticides").Value = searchProfile.PestMgmtBotaPest
        grantCollectionCommand.Parameters("@pestmgt_FieldMonitoring").Value = searchProfile.PestMgmtFieldMonitoring
        grantCollectionCommand.Parameters("@pestmgt_PrecisionCultivation").Value = searchProfile.PestMgmtPrecisiCulti
        grantCollectionCommand.Parameters("@pestmgt_VegetativeMulching").Value = searchProfile.PestMgmtVegMulch
        grantCollectionCommand.Parameters("@pestmgt_ChemicalControl").Value = searchProfile.PestMgmtChemControl
        grantCollectionCommand.Parameters("@pestmgt_GeneticResistance").Value = searchProfile.PestMgmtGeneticResis
        grantCollectionCommand.Parameters("@pestmgt_PrecisionHerbicideUse").Value = searchProfile.PestMgmtPrecisiHerbicideUse
        grantCollectionCommand.Parameters("@pestmgt_WeatherMonitoring").Value = searchProfile.PestMgmtWeatherMoni
        grantCollectionCommand.Parameters("@pestmgt_Competition").Value = searchProfile.PestMgmtCompetition
        grantCollectionCommand.Parameters("@pestmgt_IPM").Value = searchProfile.PestMgmtIPM
        grantCollectionCommand.Parameters("@pestmgt_Prevention").Value = searchProfile.PestMgmtPrevention
        grantCollectionCommand.Parameters("@pestmgt_WeedEcology").Value = searchProfile.PestMgmtWeedEco
        grantCollectionCommand.Parameters("@pestmgt_CompostExtracts").Value = searchProfile.PestMgmtCompostExtracts
        grantCollectionCommand.Parameters("@pestmgt_KilledMulches").Value = searchProfile.PestMgmtKilledMulches
        grantCollectionCommand.Parameters("@pestmgt_RowCovers").Value = searchProfile.PestMgmtRowCovers
        grantCollectionCommand.Parameters("@pestmgt_WeederGeese").Value = searchProfile.PestMgmtWeedGeese
        grantCollectionCommand.Parameters("@pestmgt_CulturalControl").Value = searchProfile.PestMgmtCulturalControl
        grantCollectionCommand.Parameters("@pestmgt_LivingMulches").Value = searchProfile.PestMgmtLivingMulches
        grantCollectionCommand.Parameters("@pestmgt_Sanitation").Value = searchProfile.PestMgmtSanitation
        grantCollectionCommand.Parameters("@pestmgt_DiseaseVectors").Value = searchProfile.PestMgmtDiseaseVectors
        grantCollectionCommand.Parameters("@pestmgt_MatingDisruption").Value = searchProfile.PestMgmtMatingDisruption
        grantCollectionCommand.Parameters("@pestmgt_SoilSolarization").Value = searchProfile.PestMgmtSoilSolar
        grantCollectionCommand.Parameters("@pestmgt_Other").Value = searchProfile.PestMgmtOther

        grantCollectionCommand.Parameters("@soilmgt_NutrientMineralization").Value = searchProfile.SoilMgmtNutriMineralization
        grantCollectionCommand.Parameters("@soilmgt_SoilMicrobiology").Value = searchProfile.SoilMgmtSoilMicroBio
        grantCollectionCommand.Parameters("@soilmgt_SoilOrganicMatter").Value = searchProfile.SoilMgmtOrgtMatter
        grantCollectionCommand.Parameters("@soilmgt_SoilQuality").Value = searchProfile.SoilMgmtQty
        grantCollectionCommand.Parameters("@soilmgt_CarbonSequestration").Value = searchProfile.SoilMgmtCarbonSequestration
        grantCollectionCommand.Parameters("@soilmgt_SoilChemistry").Value = searchProfile.SoilMgmtSoilChem
        grantCollectionCommand.Parameters("@soilmgt_SoilPhysics").Value = searchProfile.SoilMgmtSoilPhy
        grantCollectionCommand.Parameters("@soilmgt_Other").Value = searchProfile.SoilMgmtOther

        grantCollectionCommand.Parameters("@nresenv_Afforestation").Value = searchProfile.NResEnvAfforestation
        grantCollectionCommand.Parameters("@nresenv_GrassHedges").Value = searchProfile.NResEnvGrassHedges
        grantCollectionCommand.Parameters("@nresenv_RiparianPlantings").Value = searchProfile.NResEnvRiparianPlantings
        grantCollectionCommand.Parameters("@nresenv_Wildlife").Value = searchProfile.NResEnvWildlife
        grantCollectionCommand.Parameters("@nresenv_Biodiversity").Value = searchProfile.NResEnvBiodiver
        grantCollectionCommand.Parameters("@nresenv_GrassWaterways").Value = searchProfile.NResEnvGrassWaterWays
        grantCollectionCommand.Parameters("@nresenv_RiverbankProtection").Value = searchProfile.NResEnvRiverBnkProtect
        grantCollectionCommand.Parameters("@nresenv_Windbreaks").Value = searchProfile.NResEnvWindbreaks
        grantCollectionCommand.Parameters("@nresenv_Biosphere").Value = searchProfile.NResEnvBiosphere
        grantCollectionCommand.Parameters("@nresenv_HabitatEnhancement").Value = searchProfile.NResEnvHabitatEnhance
        grantCollectionCommand.Parameters("@nresenv_SoilStabilization").Value = searchProfile.NResEnvSoilStabilization
        grantCollectionCommand.Parameters("@nresenv_WoodyHedges").Value = searchProfile.NResEnvWoodyHedges
        grantCollectionCommand.Parameters("@nresenv_ConservationTillage").Value = searchProfile.NResEnvConserTillage
        grantCollectionCommand.Parameters("@nresenv_Hedgerows").Value = searchProfile.NResEnvHedgerows
        grantCollectionCommand.Parameters("@nresenv_Terraces").Value = searchProfile.NResEnvTerraces
        grantCollectionCommand.Parameters("@nresenv_ContourCultivation").Value = searchProfile.NResEnvContourCulti
        grantCollectionCommand.Parameters("@nresenv_Indicators").Value = searchProfile.NResEnvIndi
        grantCollectionCommand.Parameters("@nresenv_Wetlands").Value = searchProfile.NResEnvWetlands
        grantCollectionCommand.Parameters("@nresenv_Other").Value = searchProfile.NResEnvOther

        grantCollectionCommand.Parameters("@edtrain_CaseStudy").Value = searchProfile.EdTrainCaseStudy
        grantCollectionCommand.Parameters("@edtrain_Demonstration").Value = searchProfile.EdTrainDemo
        grantCollectionCommand.Parameters("@edtrain_FocusGroup").Value = searchProfile.EdTrainFocusGroup
        grantCollectionCommand.Parameters("@edtrain_StudyCircle").Value = searchProfile.EdTrainStudyCircle
        grantCollectionCommand.Parameters("@edtrain_Conference").Value = searchProfile.EdTrainConference
        grantCollectionCommand.Parameters("@edtrain_Display").Value = searchProfile.EdTrainDisplay
        grantCollectionCommand.Parameters("@edtrain_Mentor").Value = searchProfile.EdTrainMentor
        grantCollectionCommand.Parameters("@edtrain_Workshop").Value = searchProfile.EdTrainWorkshop
        grantCollectionCommand.Parameters("@edtrain_Curriculum").Value = searchProfile.EdTrainCurriculum
        grantCollectionCommand.Parameters("@edtrain_Extension").Value = searchProfile.EdTrainExt
        grantCollectionCommand.Parameters("@edtrain_Network").Value = searchProfile.EdTrainNet
        grantCollectionCommand.Parameters("@edtrain_Database").Value = searchProfile.EdTrainDB
        grantCollectionCommand.Parameters("@edtrain_FactSheet").Value = searchProfile.EdTrainFactSheet
        grantCollectionCommand.Parameters("@edtrain_OnFarmResearch").Value = searchProfile.EdTrainOnFarmResearch
        grantCollectionCommand.Parameters("@edtrain_DecisionSupportSystem").Value = searchProfile.EdTrainDecisionSupportSys
        grantCollectionCommand.Parameters("@edtrain_FarmerToFarmer").Value = searchProfile.EdTrainFarmerToFarmer
        grantCollectionCommand.Parameters("@edtrain_ParticipatoryResearch").Value = searchProfile.EdTrainParticipatoryResearch
        grantCollectionCommand.Parameters("@edtrain_YouthEducation").Value = searchProfile.EdTrainYouthEdu
        grantCollectionCommand.Parameters("@edtrain_Other").Value = searchProfile.EdTrainOther

        grantCollectionCommand.Parameters("@econmkt_AlternativeEnterprise").Value = searchProfile.EconMktAltEnt
        grantCollectionCommand.Parameters("@econmkt_CSA").Value = searchProfile.EconMktCSA
        grantCollectionCommand.Parameters("@econmkt_FeasibilityStudy").Value = searchProfile.EconMktFeasibilityStudy
        grantCollectionCommand.Parameters("@econmkt_RiskManagement").Value = searchProfile.EconMktRiskMgmt
        grantCollectionCommand.Parameters("@econmkt_Budget").Value = searchProfile.EconMktBudget
        grantCollectionCommand.Parameters("@econmkt_CostAndReturns").Value = searchProfile.EconMktCostNReturns
        grantCollectionCommand.Parameters("@econmkt_FinancialAnalysis").Value = searchProfile.EconMktFinAnalysis
        grantCollectionCommand.Parameters("@econmkt_ValueAdded").Value = searchProfile.EconMktValueAdd
        grantCollectionCommand.Parameters("@econmkt_Cooperatives").Value = searchProfile.EconMktCoop
        grantCollectionCommand.Parameters("@econmkt_DirectMarketing").Value = searchProfile.EconMktDirectMkt
        grantCollectionCommand.Parameters("@econmkt_MarketStudy").Value = searchProfile.EconMktMarketStudy
        grantCollectionCommand.Parameters("@econmkt_FoodProductQualitySafety").Value = searchProfile.EconMktFoodProductQtySafety
        grantCollectionCommand.Parameters("@econmkt_LaborEmployment").Value = searchProfile.EconMktLaborEmp
        grantCollectionCommand.Parameters("@econmkt_Ecommerce").Value = searchProfile.EconMktECom
        grantCollectionCommand.Parameters("@econmkt_FarmToInstitution").Value = searchProfile.EconMktFarmToInstitution
        grantCollectionCommand.Parameters("@econmkt_Other").Value = searchProfile.EconMktOther

        grantCollectionCommand.Parameters("@commdev_InfrastructureAnalysis").Value = searchProfile.CommDevInfraAnalysis
        grantCollectionCommand.Parameters("@commdev_TechnicalAssistance").Value = searchProfile.CommDevTechAssist
        grantCollectionCommand.Parameters("@commdev_NewBusinessOpportunities").Value = searchProfile.CommDevNewBusOpp
        grantCollectionCommand.Parameters("@commdev_Partnerships").Value = searchProfile.CommDevPartner
        grantCollectionCommand.Parameters("@commdev_UrbanAgriculture").Value = searchProfile.CommDevUrbanAgri
        grantCollectionCommand.Parameters("@commdev_PublicParticipation").Value = searchProfile.CommDevPubPart
        grantCollectionCommand.Parameters("@commdev_UrbanRuralIntegration").Value = searchProfile.CommDevUrbanRuralInt
        grantCollectionCommand.Parameters("@commdev_LocalRegionalCommunityFoodSystems").Value = searchProfile.CommDevLocalRegionalCommunityFoodSys
        grantCollectionCommand.Parameters("@commdev_Agritourism").Value = searchProfile.CommDevAgritourism
        grantCollectionCommand.Parameters("@commdev_CommunityPlanning").Value = searchProfile.CommDevCommunityPlanning
        grantCollectionCommand.Parameters("@commdev_PublicPolicy").Value = searchProfile.CommDevPublicPolicy
        grantCollectionCommand.Parameters("@commdev_LeadershipDevelopment").Value = searchProfile.CommDevLeadershipDev
        grantCollectionCommand.Parameters("@commdev_EthnicDifferencesCulturalDemographicChange").Value = searchProfile.CommDevEthnicDiffCulturDemoChange
        grantCollectionCommand.Parameters("@commdev_Other").Value = searchProfile.CommDevOther

        grantCollectionCommand.Parameters("@qoflife_AnalysisOfPersonalFamilyLife").Value = searchProfile.QofLifeAnalysisOfPersonalFamilyLife
        grantCollectionCommand.Parameters("@qoflife_SocialCapitol").Value = searchProfile.QofLifeSocialCap
        grantCollectionCommand.Parameters("@qoflife_SustainabilityMeasures").Value = searchProfile.QofLifeSustainMeasures
        grantCollectionCommand.Parameters("@qoflife_CommunityServices").Value = searchProfile.QofLifeCommunitySrv
        grantCollectionCommand.Parameters("@qoflife_SocialNetworks").Value = searchProfile.QofLifeSocialNet
        grantCollectionCommand.Parameters("@qoflife_EmploymentOpportunities").Value = searchProfile.QofLifeEmpOpp
        grantCollectionCommand.Parameters("@qoflife_SocialPsychologicalIndicators").Value = searchProfile.QofLifeSocialPsyInd
        grantCollectionCommand.Parameters("@qoflife_Other").Value = searchProfile.QofLifeOther

        grantCollectionCommand.Parameters("@energy_BioenergyBiofuels").Value = searchProfile.EngBioEngFuels
        grantCollectionCommand.Parameters("@energy_WindPower").Value = searchProfile.EngWindPower
        grantCollectionCommand.Parameters("@energy_EnergyUseConsumption").Value = searchProfile.EngEngUseConsumption
        grantCollectionCommand.Parameters("@energy_SolarEnergy").Value = searchProfile.EngSolarEng
        grantCollectionCommand.Parameters("@energy_EnergyConservationEfficiency").Value = searchProfile.EngEngConservEff
        grantCollectionCommand.Parameters("@energy_Other").Value = searchProfile.EngOther

        grantCollectionCommand.Parameters("@commPlAgr_Barley").Value = searchProfile.CommPlAgrBarley
        grantCollectionCommand.Parameters("@commPlAgr_GrassLegumeHay").Value = searchProfile.CommPlAgrGrassLegHay
        grantCollectionCommand.Parameters("@commPlAgr_Peanuts").Value = searchProfile.CommPlAgrPeanuts
        grantCollectionCommand.Parameters("@commPlAgr_Sorghum").Value = searchProfile.CommPlAgrSorghum
        grantCollectionCommand.Parameters("@commPlAgr_Sweetpotatoes").Value = searchProfile.CommPlAgrSweetpotatoes
        grantCollectionCommand.Parameters("@commPlAgr_Canola").Value = searchProfile.CommPlAgrCanola
        grantCollectionCommand.Parameters("@commPlAgr_LegumeHay").Value = searchProfile.CommPlAgrLegHay
        grantCollectionCommand.Parameters("@commPlAgr_Potatoes").Value = searchProfile.CommPlAgrPotatoes
        grantCollectionCommand.Parameters("@commPlAgr_Soybeans").Value = searchProfile.CommPlAgrSoybeans
        grantCollectionCommand.Parameters("@commPlAgr_Tobacco").Value = searchProfile.CommPlAgrTobacco
        grantCollectionCommand.Parameters("@commPlAgr_Corn").Value = searchProfile.CommPlAgrCorn
        grantCollectionCommand.Parameters("@commPlAgr_Hops").Value = searchProfile.CommPlAgrHops
        grantCollectionCommand.Parameters("@commPlAgr_Rapeseed").Value = searchProfile.CommPlAgrRapeseed
        grantCollectionCommand.Parameters("@commPlAgr_Spelt").Value = searchProfile.CommPlAgrSpelt
        grantCollectionCommand.Parameters("@commPlAgr_Wheat").Value = searchProfile.CommPlAgrWheat
        grantCollectionCommand.Parameters("@commPlAgr_Cotton").Value = searchProfile.CommPlAgrCotton
        grantCollectionCommand.Parameters("@commPlAgr_Kenaf").Value = searchProfile.CommPlAgrKenaf
        grantCollectionCommand.Parameters("@commPlAgr_Rice").Value = searchProfile.CommPlAgrRice
        grantCollectionCommand.Parameters("@commPlAgr_Sugarbeets").Value = searchProfile.CommPlAgrSugarbeets
        grantCollectionCommand.Parameters("@commPlAgr_Flax").Value = searchProfile.CommPlAgrFlax
        grantCollectionCommand.Parameters("@commPlAgr_Millet").Value = searchProfile.CommPlAgrMillet
        grantCollectionCommand.Parameters("@commPlAgr_Rye").Value = searchProfile.CommPlAgrRye
        grantCollectionCommand.Parameters("@commPlAgr_Sugarcane").Value = searchProfile.CommPlAgrSugarcane
        grantCollectionCommand.Parameters("@commPlAgr_GrassHay").Value = searchProfile.CommPlAgrGrassHay
        grantCollectionCommand.Parameters("@commPlAgr_Oats").Value = searchProfile.CommPlAgrOats
        grantCollectionCommand.Parameters("@commPlAgr_Safflower").Value = searchProfile.CommPlAgrSafflower
        grantCollectionCommand.Parameters("@commPlAgr_Sunflower").Value = searchProfile.CommPlAgrSunflower
        grantCollectionCommand.Parameters("@commPlAgr_Other").Value = searchProfile.CommPlAgrOther

        grantCollectionCommand.Parameters("@commPlVeg_Artichokes").Value = searchProfile.CommPlVegArtichokes
        grantCollectionCommand.Parameters("@commPlVeg_Cabbage").Value = searchProfile.CommPlVegCabbage
        grantCollectionCommand.Parameters("@commPlVeg_Escarole").Value = searchProfile.CommPlVegEscarole
        grantCollectionCommand.Parameters("@commPlVeg_Onions").Value = searchProfile.CommPlVegOnions
        grantCollectionCommand.Parameters("@commPlVeg_SweetCorn").Value = searchProfile.CommPlVegSweetCorn
        grantCollectionCommand.Parameters("@commPlVeg_Asparagus").Value = searchProfile.CommPlVegAsparagus
        grantCollectionCommand.Parameters("@commPlVeg_Carrots").Value = searchProfile.CommPlVegCarrots
        grantCollectionCommand.Parameters("@commPlVeg_Garlic").Value = searchProfile.CommPlVegGarlic
        grantCollectionCommand.Parameters("@commPlVeg_Parsnips").Value = searchProfile.CommPlVegParsnips
        grantCollectionCommand.Parameters("@commPlVeg_Tomatoes").Value = searchProfile.CommPlVegTomatoes
        grantCollectionCommand.Parameters("@commPlVeg_Beans").Value = searchProfile.CommPlVegBeans
        grantCollectionCommand.Parameters("@commPlVeg_Cauliflower").Value = searchProfile.CommPlVegCauliflower
        grantCollectionCommand.Parameters("@commPlVeg_Greens").Value = searchProfile.CommPlVegGreens
        grantCollectionCommand.Parameters("@commPlVeg_Peas").Value = searchProfile.CommPlVegPeas
        grantCollectionCommand.Parameters("@commPlVeg_Turnips").Value = searchProfile.CommPlVegTurnips
        grantCollectionCommand.Parameters("@commPlVeg_Beets").Value = searchProfile.CommPlVegBeets
        grantCollectionCommand.Parameters("@commPlVeg_Celery").Value = searchProfile.CommPlVegCelery
        grantCollectionCommand.Parameters("@commPlVeg_Kale").Value = searchProfile.CommPlVegKale
        grantCollectionCommand.Parameters("@commPlVeg_Peppers").Value = searchProfile.CommPlVegPeppers
        grantCollectionCommand.Parameters("@commPlVeg_Watermelon").Value = searchProfile.CommPlVegWatermelon
        grantCollectionCommand.Parameters("@commPlVeg_Broccoli").Value = searchProfile.CommPlVegBroccoli
        grantCollectionCommand.Parameters("@commPlVeg_Cucumbers").Value = searchProfile.CommPlVegCucumbers
        grantCollectionCommand.Parameters("@commPlVeg_Lentils").Value = searchProfile.CommPlVegLentils
        grantCollectionCommand.Parameters("@commPlVeg_Rutabagas").Value = searchProfile.CommPlVegRutabagas
        grantCollectionCommand.Parameters("@commPlVeg_BrusselSprouts").Value = searchProfile.CommPlVegBrusselSprouts
        grantCollectionCommand.Parameters("@commPlVeg_Eggplant").Value = searchProfile.CommPlVegEggplant
        grantCollectionCommand.Parameters("@commPlVeg_Lettuce").Value = searchProfile.CommPlVegLettuce
        grantCollectionCommand.Parameters("@commPlVeg_Spinach").Value = searchProfile.CommPlVegSpinach
        grantCollectionCommand.Parameters("@commplveg_leeks").Value = searchProfile.CommPlVegLeeks
        grantCollectionCommand.Parameters("@commPlVeg_Pumpkins").Value = searchProfile.CommPlVegPumpkins
        grantCollectionCommand.Parameters("@commPlVeg_Squashes").Value = searchProfile.CommPlVegSquashes
        grantCollectionCommand.Parameters("@commPlVeg_Radishes").Value = searchProfile.CommPlVegRadishes
        grantCollectionCommand.Parameters("@commPlVeg_Other").Value = searchProfile.CommPlVegOther

        grantCollectionCommand.Parameters("@commPlFruit_Apples").Value = searchProfile.CommPlFruitApples
        grantCollectionCommand.Parameters("@commPlFruit_Cherries").Value = searchProfile.CommPlFruitCherries
        grantCollectionCommand.Parameters("@commPlFruit_Lemons").Value = searchProfile.CommPlFruitLemons
        grantCollectionCommand.Parameters("@commPlFruit_Peaches").Value = searchProfile.CommPlFruitPeaches
        grantCollectionCommand.Parameters("@commPlFruit_Strawberries").Value = searchProfile.CommPlFruitStrawberries
        grantCollectionCommand.Parameters("@commPlFruit_Apricots").Value = searchProfile.CommPlFruitApricots
        grantCollectionCommand.Parameters("@commPlFruit_Cranberries").Value = searchProfile.CommPlFruitCranberries
        grantCollectionCommand.Parameters("@commPlFruit_Limes").Value = searchProfile.CommPlFruitLimes
        grantCollectionCommand.Parameters("@commPlFruit_Pears").Value = searchProfile.CommPlFruitPears
        grantCollectionCommand.Parameters("@commPlFruit_Tangerines").Value = searchProfile.CommPlFruitTangerines
        grantCollectionCommand.Parameters("@commPlFruit_Avocados").Value = searchProfile.CommPlFruitAvocados
        grantCollectionCommand.Parameters("@commPlFruit_Figs").Value = searchProfile.CommPlFruitFigs
        grantCollectionCommand.Parameters("@commPlFruit_Melons").Value = searchProfile.CommPlFruitMelons
        grantCollectionCommand.Parameters("@commPlFruit_Pineapples").Value = searchProfile.CommPlFruitPineapples
        grantCollectionCommand.Parameters("@commPlFruit_Bananas").Value = searchProfile.CommPlFruitBananas
        grantCollectionCommand.Parameters("@commPlFruit_Grapefruit").Value = searchProfile.CommPlFruitGrapefruit
        grantCollectionCommand.Parameters("@commPlFruit_Olives").Value = searchProfile.CommPlFruitOlives
        grantCollectionCommand.Parameters("@commPlFruit_Plums").Value = searchProfile.CommPlFruitPlums
        grantCollectionCommand.Parameters("@commPlFruit_Berries").Value = searchProfile.CommPlFruitBerries
        grantCollectionCommand.Parameters("@commPlFruit_Grapes").Value = searchProfile.CommPlFruitGrapes
        grantCollectionCommand.Parameters("@commPlFruit_Oranges").Value = searchProfile.CommPlFruitOranges
        grantCollectionCommand.Parameters("@commPlFruit_Quinces").Value = searchProfile.CommPlFruitQuinces
        grantCollectionCommand.Parameters("@commPlFruit_Brambles").Value = searchProfile.CommPlFruitBrambles
        grantCollectionCommand.Parameters("@commPlFruit_Blueberries").Value = searchProfile.CommPlFruitBlueberries
        grantCollectionCommand.Parameters("@commPlFruit_Other").Value = searchProfile.CommPlFruitOther

        grantCollectionCommand.Parameters("@commPlNuts_Almonds").Value = searchProfile.CommPlNutsAlmonds
        grantCollectionCommand.Parameters("@commPlNuts_Hazelnuts").Value = searchProfile.CommPlNutsHazel
        grantCollectionCommand.Parameters("@commPlNuts_Pecans").Value = searchProfile.CommPlNutsPecans
        grantCollectionCommand.Parameters("@commPlNuts_Walnuts").Value = searchProfile.CommPlNutsWalnuts
        grantCollectionCommand.Parameters("@commplnuts_chestnuts").Value = searchProfile.CommPlNutsChestnuts
        grantCollectionCommand.Parameters("@commPlNuts_Macadamia").Value = searchProfile.CommPlNutsMacadamia
        grantCollectionCommand.Parameters("@commPlNuts_Pistachios").Value = searchProfile.CommPlNutsPistachios
        grantCollectionCommand.Parameters("@commPlNuts_Other").Value = searchProfile.CommPlNutsOther

        grantCollectionCommand.Parameters("@commPlAdd_Herbs").Value = searchProfile.CommPlAddHerbs
        grantCollectionCommand.Parameters("@commPlAdd_Ornamentals").Value = searchProfile.CommPlAddOrnamentals
        grantCollectionCommand.Parameters("@commPlAdd_Trees").Value = searchProfile.CommPlAddTrees
        grantCollectionCommand.Parameters("@commPlAdd_Mushrooms").Value = searchProfile.CommPlAddMushrooms
        grantCollectionCommand.Parameters("@commPlAdd_NativePlants").Value = searchProfile.CommPlAddNativePlants
        grantCollectionCommand.Parameters("@commPlAdd_Other").Value = searchProfile.CommPlAddOther

        grantCollectionCommand.Parameters("@commAnim_Beef").Value = searchProfile.CommAnimBeef
        grantCollectionCommand.Parameters("@commAnim_Chicken").Value = searchProfile.CommAnimChicken
        grantCollectionCommand.Parameters("@commAnim_Rabbits").Value = searchProfile.CommAnimRabbits
        grantCollectionCommand.Parameters("@commAnim_Swine").Value = searchProfile.CommAnimSwine
        grantCollectionCommand.Parameters("@commAnim_Dairy").Value = searchProfile.CommAnimDairy
        grantCollectionCommand.Parameters("@commAnim_Goats").Value = searchProfile.CommAnimGoats
        grantCollectionCommand.Parameters("@commAnim_Sheep").Value = searchProfile.CommAnimSheep
        grantCollectionCommand.Parameters("@commAnim_Turkeys").Value = searchProfile.CommAnimTurkeys
        grantCollectionCommand.Parameters("@commAnim_Other").Value = searchProfile.CommAnimOther

        grantCollectionCommand.Parameters("@commMisc_Bees").Value = searchProfile.CommMiscBees
        grantCollectionCommand.Parameters("@commMisc_Fish").Value = searchProfile.CommMiscFish
        grantCollectionCommand.Parameters("@commMisc_Ratites").Value = searchProfile.CommMiscRatites
        grantCollectionCommand.Parameters("@commMisc_Shellfish").Value = searchProfile.CommMiscShellfish
        grantCollectionCommand.Parameters("@commMisc_Other").Value = searchProfile.CommMiscOther

        grantCollectionConnection.Open()
        grantCollectionDataReader = grantCollectionCommand.ExecuteReader()

        '	Response.Write("")
        'ignore the first result table for now
        grantCollectionDataReader.Read()
        maxRecords = grantCollectionDataReader("maxProjRes")

        grantCollectionDataReader.NextResult()

        Do While grantCollectionDataReader.Read()
            If grantCollectionDataReader.HasRows Then
                tempProjNum = grantCollectionDataReader("proj_num")
                searchID = grantCollectionDataReader("searchID")
                totalRank = grantCollectionDataReader("totalRank")
                proj_title = grantCollectionDataReader("proj_title")
                proj_region = grantCollectionDataReader("proj_region")
                proj_type = grantCollectionDataReader("proj_type")
                proj_year = grantCollectionDataReader("proj_year")

                'If (grantCollectionDataReader("rept_year").Equals(DBNull.Value)) Then
                '    rept_year = 0
                'Else
                '    rept_year = grantCollectionDataReader("rept_year")
                'End If
                'If (grantCollectionDataReader("rept_isfinal").Equals(DBNull.Value)) Then
                '    rept_isfinal = 0
                'Else
                '    rept_isfinal = Math.Abs(CInt(grantCollectionDataReader("rept_isfinal")))
                'End If

                'If (grantCollectionDataReader("rept_isapproved").Equals(DBNull.Value)) Then
                '    rept_isapproved = False
                'Else
                '    rept_isapproved = CBool(grantCollectionDataReader("rept_isapproved"))
                'End If
                'If (grantCollectionDataReader("submitted").Equals(DBNull.Value)) Then
                '    wasSubmitted = False
                'Else
                '    wasSubmitted = CBool(grantCollectionDataReader("submitted"))
                'End If
                'If (grantCollectionDataReader("updatedDate").Equals(DBNull.Value)) Then
                '    updatedDate = CDate("1/1/2000")
                'Else
                '    updatedDate = CDate(grantCollectionDataReader("updatedDate"))
                'End If

                'partRank = grantCollectionDataReader("partRank")

                'If (ContainsKey(tempProjNum) And rept_year > 0) Then
                '    tempReport = New DaikonGrantReport(partRank, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                '    Item(tempProjNum).addReport(tempReport)
                'Else
                '    tempProject = New DaikonGrant(tempProjNum, totalRank, proj_title, proj_region, proj_year, proj_type, "0", "0", "0")
                '    Add(tempProjNum, tempProject)
                '    If rept_year > 0 Then
                '        tempReport = New DaikonGrantReport(partRank, rept_year, rept_isfinal, rept_isapproved, wasSubmitted, updatedDate)
                '        Item(tempProjNum).addReport(tempReport)
                '    End If
                'End If

                If (ContainsKey(tempProjNum)) Then
                Else
                    tempProject = New DaikonGrant(tempProjNum, totalRank, proj_title, proj_region, proj_year, proj_type, "0", "0", "0")
                    Add(tempProjNum, tempProject)
                End If

            Else

            End If
        Loop

        grantCollectionDataReader.Close()
        grantCollectionConnection.Dispose()

    End Sub
    Function ParseQueryString(ByVal inputString As String) As String
        ' Original Version by Daniel A.K.M. Halsey (estragon@ufl.edu)
        ' for UF/IFAS (it.ifas.ufl.edu) under grant from USDA/SARE (www.sare.org)
        Dim newString As String
        Dim containsWildcards As Boolean
        'Dim regExp As Regex
        '	Handy page: http://www.regular-expressions.info/reference.html
        '		regExp = New Regex("[^a-z^A-Z^0-9]")

        newString = Regex.Replace(inputString, "[^a-z^A-Z^0-9^\'^\-^_^\*]", " ")
        '	Clean up extra dashes, hold places so \b ignores it
        newString = Regex.Replace(newString, "\-{1,}", "abulafiafindstheconnections").Trim()
        '	Clean up extra single-quotes/apostrophes, hold places so \b ignores it
        newString = Regex.Replace(newString, "[\'`]{1,}", "causobonfindsthetruth").Trim()
        '	Clean up extra spaces
        newString = Regex.Replace(newString, "\s{2,}", " ").Trim()

        ''	Replace asterisks at end of words with ?
        containsWildcards = Regex.IsMatch(newString, "\b([a-zA-Z0-9\'\-_]+)[\*]\W")
        If containsWildcards Then
            '	Response.Write("Yes, It Contains Wildcards!<br>")
            newString = Regex.Replace(newString, "\b([a-zA-Z0-9\'\-_]+)[\*](\W)", "$1asteriskreplacementtext$2")
        End If
        '	Clean out asterisks not at end of words
        newString = Regex.Replace(newString, "\*", "")

        '	Replace permutations of "and not" with "!"
        newString = Regex.Replace(newString, "\s{0,}\b[aA][nN][dD]\s[nN][oO][tT]\b\s{0,}", "!")
        newString = Regex.Replace(newString, "\s{0,}\b[nN][oO][tT]\s[aA][nN][dD]\b\s{0,}", "!")
        newString = Regex.Replace(newString, "\s{0,}\b[nN][oO][tT]\b\s{0,}", "!")
        '	Replace permutations of "near" with "@"
        newString = Regex.Replace(newString, "\s{0,}\b[nN][eE][aA][rR]\b\s{0,}", "@")

        '	Replace permutations of "and" with "+"
        newString = Regex.Replace(newString, "\s{0,}\b[aA][nN][dD]\b\s{0,}", "+")
        '	Replace permutations of "or" with "|"
        newString = Regex.Replace(newString, "\s{0,}\b[oO][rR]\b\s{0,}", "|")

        ''	Add double quotes
        'newString = Regex.Replace(newString, "\b", Chr(34))

        ''	Add wildcard "??" to strings of 3 characters or fewer
        ''	Note: appears to be unneccessary when using double-quote-enclosed strings, except for ignored words
        If containsWildcards Then

            newString = Regex.Replace(newString, "\b(\w{0,1})\b", "")
            newString = Regex.Replace(newString, "\b(\w{1,3})\b", "$1asteriskreplacementtext")

            '			newString = Regex.Replace(newString, "\b(\w{1,})\b", Chr(34) & "$1" & Chr(34))
            newString = Regex.Replace(newString, "\b", Chr(34))

            '	Replace remaining whitespace with ANDs/ORs
            If searchSelect = "or" Then
                newString = Regex.Replace(newString, "\s", "|")
            End If
            If searchSelect = "and" Then
                newString = Regex.Replace(newString, "\s", "+")
            End If
        Else
            '	Replace remaining whitespace with ANDs/ORs
            If searchSelect = "or" Then
                newString = Regex.Replace(newString, "\s", "|")
            End If
            If searchSelect = "and" Then
                newString = Regex.Replace(newString, "\s", "+")
            End If

            '	For use with CONTAINS query using generation terms
            newString = Regex.Replace(newString, "\b(\w{0,2})\b", "")
            newString = Regex.Replace(newString, "\b(\w{1,})\b", "formsof(inflectional, " & Chr(34) & "$1" & Chr(34) & ")")

        End If

        '	Clean out any operators at the beginning
        While (Regex.IsMatch(newString, "^\s{0,}[\+!\|\@]\s{0,}"))
            newString = Regex.Replace(newString, "^\s{0,}[\+!\|\@]\s{0,}", "")
        End While
        '	Clean out any operators at the end
        While (Regex.IsMatch(newString, "\s{0,}[\+!\|\@]\s{0,}$"))
            newString = Regex.Replace(newString, "\s{0,}[\+!\|\@]\s{0,}$", "")
        End While

        '	Revert replacements to original and constructed operators
        newString = Regex.Replace(newString, "asteriskreplacementtext", "*")
        newString = Regex.Replace(newString, "abulafiafindstheconnections", "-")
        newString = Regex.Replace(newString, "causobonfindsthetruth", "'")
        'newString = Regex.Replace(newString, "!", " AND NOT ")
        newString = Regex.Replace(newString, "\+", " AND ")
        newString = Regex.Replace(newString, "\|", " OR ")
        newString = Regex.Replace(newString, "\@", " NEAR ")

        '	newString = Chr(34) & newString & Chr(34)

        ParseQueryString = newString

    End Function
    Function ParseQueryStringForURL(ByVal inputString As String) As String
        Dim newString As String
        Dim containsWildcards As Boolean
        'Dim regExp As Regex
        '	Handy page: http://www.regular-expressions.info/reference.html
        '		regExp = New Regex("[^a-z^A-Z^0-9]")

        newString = Regex.Replace(inputString, "[^a-z^A-Z^0-9^\'^\-^_^\*]", " ")
        '	Clean up extra dashes, hold places so \b ignores it
        newString = Regex.Replace(newString, "\-{1,}", "abulafiafindstheconnections").Trim()
        '	Clean up extra single-quotes/apostrophes, hold places so \b ignores it
        newString = Regex.Replace(newString, "[\'`]{1,}", "causobonfindsthetruth").Trim()
        '	Clean up extra spaces
        newString = Regex.Replace(newString, "\s{2,}", " ").Trim()

        ''	Replace asterisks at end of words with ?
        containsWildcards = Regex.IsMatch(newString, "\b([a-zA-Z0-9\'\-_]+)[\*]\W")
        If containsWildcards Then
            '	Response.Write("Yes, It Contains Wildcards!<br>")
            newString = Regex.Replace(newString, "\b([a-zA-Z0-9\'\-_]+)[\*](\W)", "$1asteriskreplacementtext$2")
        End If
        '	Clean out asterisks not at end of words
        newString = Regex.Replace(newString, "\*", "")

        '	Replace permutations of "and not" with "!"
        newString = Regex.Replace(newString, "\s{0,}\b[aA][nN][dD]\s[nN][oO][tT]\b\s{0,}", "!")
        newString = Regex.Replace(newString, "\s{0,}\b[nN][oO][tT]\s[aA][nN][dD]\b\s{0,}", "!")
        newString = Regex.Replace(newString, "\s{0,}\b[nN][oO][tT]\b\s{0,}", "!")
        '	Replace permutations of "near" with "@"
        newString = Regex.Replace(newString, "\s{0,}\b[nN][eE][aA][rR]\b\s{0,}", "@")

        '	Replace permutations of "and" with "+"
        newString = Regex.Replace(newString, "\s{0,}\b[aA][nN][dD]\b\s{0,}", "+")
        '	Replace permutations of "or" with "|"
        newString = Regex.Replace(newString, "\s{0,}\b[oO][rR]\b\s{0,}", "|")

        ''	Add wildcard "??" to strings of 3 characters or fewer
        ''	Note: appears to be unneccessary when using double-quote-enclosed strings, except for ignored words
        'newString = Regex.Replace(newString, "\b(\w{1,3})\b", "$1asteriskreplacementtext")
        If containsWildcards Then

            newString = Regex.Replace(newString, "\b(\w{0,1})\b", "")
            newString = Regex.Replace(newString, "\b(\w{1,3})\b", "$1asteriskreplacementtext")

            '	newString = Regex.Replace(newString, "\b(\w{1,})\b", Chr(34) & "$1" & Chr(34))

            '	Replace remaining whitespace with ANDs
            newString = Regex.Replace(newString, "\s", "+")
        Else
            '	Replace remaining whitespace with ANDs
            newString = Regex.Replace(newString, "\s", "+")

            '	For use with CONTAINS query using generation terms
            newString = Regex.Replace(newString, "\b(\w{0,2})\b", "")
            'newString = Regex.Replace(newString, "\b(\w{1,})\b", "formsof(inflectional, " & Chr(34) & "$1" & Chr(34) & ")")
        End If

        '	Add double quotes
        '            newString = Regex.Replace(newString, "\b", Chr(34))

        '	Clean out any operators at the beginning
        While (Regex.IsMatch(newString, "^\s{0,}[\+!\|\@]\s{0,}"))
            newString = Regex.Replace(newString, "^\s{0,}[\+!\|\@]\s{0,}", "")
        End While
        '	Clean out any operators at the end
        While (Regex.IsMatch(newString, "\s{0,}[\+!\|\@]\s{0,}$"))
            newString = Regex.Replace(newString, "\s{0,}[\+!\|\@]\s{0,}$", "")
        End While

        '	Revert replacements to original and constructed operators
        newString = Regex.Replace(newString, "asteriskreplacementtext", "*")
        newString = Regex.Replace(newString, "abulafiafindstheconnections", "-")
        newString = Regex.Replace(newString, "causobonfindsthetruth", "'")
        newString = Regex.Replace(newString, "!", " AND NOT ")
        newString = Regex.Replace(newString, "\+", " AND ")
        newString = Regex.Replace(newString, "\|", " OR ")
        newString = Regex.Replace(newString, "\@", " NEAR ")

        '	Replace whitespace with plusses for URL friendliness
        newString = Regex.Replace(newString, "\s", "+")

        '	newString = Chr(34) & newString & Chr(34)

        ParseQueryStringForURL = newString

    End Function
    Function ParseQueryStringForDisplay(ByVal inputString As String) As String
        Dim newString As String
        Dim containsWildcards As Boolean
        'Dim regExp As Regex
        '	Handy page: http://www.regular-expressions.info/reference.html
        '		regExp = New Regex("[^a-z^A-Z^0-9]")

        newString = Regex.Replace(inputString, "[^a-z^A-Z^0-9^\'^\-^_^\*]", " ")
        '	Clean up extra dashes, hold places so \b ignores it
        newString = Regex.Replace(newString, "\-{1,}", "abulafiafindstheconnections").Trim()
        '	Clean up extra single-quotes/apostrophes, hold places so \b ignores it
        newString = Regex.Replace(newString, "[\'`]{1,}", "causobonfindsthetruth").Trim()
        '	Clean up extra spaces
        newString = Regex.Replace(newString, "\s{2,}", " ").Trim()

        ''	Replace asterisks at end of words with ?
        containsWildcards = Regex.IsMatch(newString, "\b([a-zA-Z0-9\'\-_]+)[\*]\W")
        If containsWildcards Then
            '	Response.Write("Yes, It Contains Wildcards!<br>")
            newString = Regex.Replace(newString, "\b([a-zA-Z0-9\'\-_]+)[\*](\W)", "$1asteriskreplacementtext$2")
        End If
        '	Clean out asterisks not at end of words
        newString = Regex.Replace(newString, "\*", "")

        '	Replace permutations of "and not" with "!"
        newString = Regex.Replace(newString, "\s{0,}\b[aA][nN][dD]\s[nN][oO][tT]\b\s{0,}", "!")
        newString = Regex.Replace(newString, "\s{0,}\b[nN][oO][tT]\s[aA][nN][dD]\b\s{0,}", "!")
        newString = Regex.Replace(newString, "\s{0,}\b[nN][oO][tT]\b\s{0,}", "!")
        '	Replace permutations of "near" with "@"
        newString = Regex.Replace(newString, "\s{0,}\b[nN][eE][aA][rR]\b\s{0,}", "@")

        '	Replace permutations of "and" with "+"
        newString = Regex.Replace(newString, "\s{0,}\b[aA][nN][dD]\b\s{0,}", "+")
        '	Replace permutations of "or" with "|"
        newString = Regex.Replace(newString, "\s{0,}\b[oO][rR]\b\s{0,}", "|")

        ''	Add wildcard "??" to strings of 3 characters or fewer
        ''	Note: appears to be unneccessary when using double-quote-enclosed strings, except for ignored words
        'newString = Regex.Replace(newString, "\b(\w{1,3})\b", "$1asteriskreplacementtext")
        If containsWildcards Then

            newString = Regex.Replace(newString, "\b(\w{0,1})\b", "")
            newString = Regex.Replace(newString, "\b(\w{1,3})\b", "$1asteriskreplacementtext")

            '	newString = Regex.Replace(newString, "\b(\w{1,})\b", Chr(34) & "$1" & Chr(34))

            '	Replace remaining whitespace with ANDs
            newString = Regex.Replace(newString, "\s", "+")
        Else
            '	Replace remaining whitespace with ANDs
            newString = Regex.Replace(newString, "\s", "+")

            '	For use with CONTAINS query using generation terms
            newString = Regex.Replace(newString, "\b(\w{0,2})\b", "")
            'newString = Regex.Replace(newString, "\b(\w{1,})\b", "formsof(inflectional, " & Chr(34) & "$1" & Chr(34) & ")")
        End If

        '	Add double quotes
        newString = Regex.Replace(newString, "\b", Chr(34))

        '	Clean out any operators at the beginning
        While (Regex.IsMatch(newString, "^\s{0,}[\+!\|\@]\s{0,}"))
            newString = Regex.Replace(newString, "^\s{0,}[\+!\|\@]\s{0,}", "")
        End While
        '	Clean out any operators at the end
        While (Regex.IsMatch(newString, "\s{0,}[\+!\|\@]\s{0,}$"))
            newString = Regex.Replace(newString, "\s{0,}[\+!\|\@]\s{0,}$", "")
        End While

        '	Revert replacements to original and constructed operators
        newString = Regex.Replace(newString, "asteriskreplacementtext", "*")
        newString = Regex.Replace(newString, "abulafiafindstheconnections", "-")
        newString = Regex.Replace(newString, "causobonfindsthetruth", "'")
        newString = Regex.Replace(newString, "!", " AND NOT ")
        newString = Regex.Replace(newString, "\+", " AND ")
        newString = Regex.Replace(newString, "\|", " OR ")
        newString = Regex.Replace(newString, "\@", " NEAR ")

        '	newString = Chr(34) & newString & Chr(34)

        ParseQueryStringForDisplay = newString

    End Function
End Class

Public Class DaikonGrantFieldValues
    Protected stateInfo As String
    Protected regionInfo As String
    Protected textSectionInfo As String
    Protected subsectionTypeInfo As String
    Protected projTypeInfo As String
    Protected userRoleInfo As String

    Public Property pStateInfo() As String
        Get
            Return stateInfo
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property pRegionInfo() As String
        Get
            Return regionInfo
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property pProjTypeInfo() As String
        Get
            Return projTypeInfo
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property pTextSectionInfo() As String
        Get
            Return textSectionInfo
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property pSubsectionTypeInfo() As String
        Get
            Return subsectionTypeInfo
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property pUserRoleInfo() As String
        Get
            Return userRoleInfo
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Sub DaikonGrantFieldValues(ByVal sareConnectionString)
        '			Dim staticValsWriterString = New StringWriter()
        '			Dim staticValsXmlWriter = New XmlTextWriter(staticValsWriterString)
        '			staticValsXmlWriter.Formatting = Formatting.Indented

        Dim statesWriterString = New StringWriter()
        Dim statesXmlWriter = New XmlTextWriter(statesWriterString)
        statesXmlWriter.Formatting = Formatting.Indented

        Dim regionsWriterString = New StringWriter()
        Dim regionsXmlWriter = New XmlTextWriter(regionsWriterString)
        regionsXmlWriter.Formatting = Formatting.Indented

        Dim projtypesWriterString = New StringWriter()
        Dim projtypesXmlWriter = New XmlTextWriter(projtypesWriterString)
        projtypesXmlWriter.Formatting = Formatting.Indented

        Dim textsectionsWriterString = New StringWriter()
        Dim textsectionsXmlWriter = New XmlTextWriter(textsectionsWriterString)
        textsectionsXmlWriter.Formatting = Formatting.Indented

        Dim texttypesWriterString = New StringWriter()
        Dim texttypesXmlWriter = New XmlTextWriter(texttypesWriterString)
        texttypesXmlWriter.Formatting = Formatting.Indented

        Dim userrolesWriterString = New StringWriter()
        Dim userrolesXmlWriter = New XmlTextWriter(userrolesWriterString)
        userrolesXmlWriter.Formatting = Formatting.Indented

        Dim staticvalsSQL As String

        staticvalsSQL = "DaikonReportingReturnStaticValues"

        Dim staticvalsConnection As SqlConnection
        Dim staticvalsCommand As SqlCommand
        Dim staticvalsDataReader As SqlDataReader

        staticvalsConnection = New SqlConnection(sareConnectionString)

        staticvalsCommand = New SqlCommand
        staticvalsCommand.Connection = staticvalsConnection
        staticvalsCommand.CommandText = staticvalsSQL
        staticvalsCommand.CommandType = CommandType.StoredProcedure

        staticvalsConnection.Open()
        staticvalsDataReader = staticvalsCommand.ExecuteReader()

        statesXmlWriter.WriteStartElement("states")
        statesXmlWriter.WriteAttributeString("nationality", "U.S. and Territories")
        statesXmlWriter.WriteAttributeString("description", "U.S. States and Territories")
		'Empty entry for "no state"
		statesXmlWriter.WriteStartElement("state")
		statesXmlWriter.WriteElementString("name", "")
		statesXmlWriter.WriteElementString("abbr", "")
		statesXmlWriter.WriteElementString("regionCode", "")
		statesXmlWriter.WriteEndElement()

		Do While staticvalsDataReader.Read()
			statesXmlWriter.WriteStartElement("state")
			statesXmlWriter.WriteElementString("name", staticvalsDataReader("state_name"))
			statesXmlWriter.WriteElementString("abbr", staticvalsDataReader("state_abbr"))
			statesXmlWriter.WriteElementString("regionCode", staticvalsDataReader("region_code"))
			statesXmlWriter.WriteEndElement()
		Loop
        statesXmlWriter.WriteEndElement()
        statesXmlWriter.Flush()
        stateInfo = statesWriterString.ToString()
        '			stateInfo = staticvalsDataReader(0)

        staticvalsDataReader.NextResult()

        regionsXmlWriter.WriteStartElement("regions")
        regionsXmlWriter.WriteAttributeString("nationality", "U.S. and Territories")
        regionsXmlWriter.WriteAttributeString("description", "SARE Regions")
        Do While staticvalsDataReader.Read()
            regionsXmlWriter.WriteStartElement("region")
            regionsXmlWriter.WriteElementString("name", staticvalsDataReader("region_name"))
            regionsXmlWriter.WriteElementString("regionCode", staticvalsDataReader("region_code"))
            regionsXmlWriter.WriteEndElement()
        Loop
        regionsXmlWriter.WriteEndElement()
        regionsXmlWriter.Flush()
        regionInfo = regionsWriterString.ToString()
        '			regionInfo = staticvalsDataReader(0)

        staticvalsDataReader.NextResult()

        projtypesXmlWriter.WriteStartElement("projTypes")
        projtypesXmlWriter.WriteAttributeString("description", "Types of SARE-Funded Projects")
        Do While staticvalsDataReader.Read()
            projtypesXmlWriter.WriteStartElement("projType")
            projtypesXmlWriter.WriteElementString("name", staticvalsDataReader("type_name"))
            projtypesXmlWriter.WriteElementString("typeCode", staticvalsDataReader("proj_type"))
            projtypesXmlWriter.WriteEndElement()
        Loop
        projtypesXmlWriter.WriteEndElement()
        projtypesXmlWriter.Flush()
        projTypeInfo = projtypesWriterString.ToString()
        '			projTypeInfo = staticvalsDataReader(0)

        staticvalsDataReader.NextResult()

        textsectionsXmlWriter.WriteStartElement("reptSections")
        textsectionsXmlWriter.WriteAttributeString("description", "Report Sections by Project Type")
        Do While staticvalsDataReader.Read()
            textsectionsXmlWriter.WriteStartElement("section")
            textsectionsXmlWriter.WriteElementString("name", staticvalsDataReader("section_name"))
            textsectionsXmlWriter.WriteElementString("reptType", staticvalsDataReader("rept_isfinal"))
            textsectionsXmlWriter.WriteElementString("projTypeCode", staticvalsDataReader("proj_type"))
            textsectionsXmlWriter.WriteElementString("order", staticvalsDataReader("section_order"))
            textsectionsXmlWriter.WriteElementString("ID", staticvalsDataReader("section"))
            textsectionsXmlWriter.WriteEndElement()
        Loop
        textsectionsXmlWriter.WriteEndElement()
        textsectionsXmlWriter.Flush()
        textSectionInfo = textsectionsWriterString.ToString()
        '			textSectionInfo = staticvalsDataReader(0)

        staticvalsDataReader.NextResult()

        texttypesXmlWriter.WriteStartElement("textTypes")
        texttypesXmlWriter.WriteAttributeString("description", "Report Text-block Styles")
        Do While staticvalsDataReader.Read()
            texttypesXmlWriter.WriteStartElement("textType")
            texttypesXmlWriter.WriteElementString("name", staticvalsDataReader("type_name"))
            texttypesXmlWriter.WriteElementString("typeCode", staticvalsDataReader("type_num"))
            texttypesXmlWriter.WriteEndElement()
        Loop
        texttypesXmlWriter.WriteEndElement()
        texttypesXmlWriter.Flush()
        subsectionTypeInfo = texttypesWriterString.ToString()

        staticvalsDataReader.NextResult()

        userrolesXmlWriter.WriteStartElement("userRoles")
        userrolesXmlWriter.WriteAttributeString("description", "Available User Roles")
        Do While staticvalsDataReader.Read()
            userrolesXmlWriter.WriteStartElement("userRole")
            userrolesXmlWriter.WriteAttributeString("code", staticvalsDataReader("userRole"))
            userrolesXmlWriter.WriteAttributeString("description", staticvalsDataReader("roleDescription"))
            userrolesXmlWriter.WriteAttributeString("priority", staticvalsDataReader("rolePriority"))
            userrolesXmlWriter.WriteAttributeString("coreType", staticvalsDataReader("typeCode"))
            userrolesXmlWriter.WriteAttributeString("typeAdmin", staticvalsDataReader("typeAdmin"))
            userrolesXmlWriter.WriteEndElement()
        Loop
        userrolesXmlWriter.WriteEndElement()
        userrolesXmlWriter.Flush()
        userRoleInfo = userrolesWriterString.ToString()

        '			subsectionTypeInfo = staticvalsDataReader(0)

        statesXmlWriter.Close()
        regionsXmlWriter.Close()
        projtypesXmlWriter.Close()
        textsectionsXmlWriter.Close()
        texttypesXmlWriter.Close()
        userrolesXmlWriter.Close()

        staticvalsDataReader.Close()
        staticvalsConnection.Close()
        staticvalsConnection.Dispose()

    End Sub
End Class
