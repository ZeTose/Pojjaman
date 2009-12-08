Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.Services
Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.BusinessLogic
    Public Class POPlaceOfDelivery
        Inherits SimpleBusinessEntityBase
        Implements IHasName

#Region "Members"
        Private m_name As String
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            MyBase.New(dr, aliasPrefix)
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Construct(dr, aliasPrefix)
        End Sub

        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_name") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_name") Then
                    .m_name = CStr(dr(aliasPrefix & Me.Prefix & "_name"))
                End If
            End With
        End Sub
#End Region

#Region "Properties"
        Public Property Name() As String Implements IHasName.Name            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
                OnPropertyChanged(Me, New PropertyChangedEventArgs)
            End Set
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "POPlaceOfDelivery"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.POPlaceOfDelivery.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.POPlaceOfDelivery"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.POPlaceOfDelivery"
            End Get
        End Property
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "poplaceofdelivery"
            End Get
        End Property

        Public Overrides ReadOnly Property TabPageText() As String
            Get
                Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
                Dim blankSuffix As String = "()"
                If tpt.EndsWith(blankSuffix) Then
                    tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
                End If
                Return tpt
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.POPlaceOfDelivery.ListLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property UseSiteConnString() As Boolean
            Get
                Return True
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Function GetPOPlaceOfDelivery(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPOPlaceOfDelivery As POPlaceOfDelivery) As Boolean
            Dim myPOPlaceOfDelivery As New POPlaceOfDelivery(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not myPOPlaceOfDelivery.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                myPOPlaceOfDelivery = oldPOPlaceOfDelivery
            End If
            txtCode.Text = myPOPlaceOfDelivery.Code
            txtName.Text = myPOPlaceOfDelivery.Name
            If oldPOPlaceOfDelivery.Id <> myPOPlaceOfDelivery.Id Then
                oldPOPlaceOfDelivery = myPOPlaceOfDelivery
                Return True
            End If
            Return False
        End Function
        Public Shared Sub ListInComboBox(ByVal cmb As ComboBox, Optional ByVal includeNothing As Boolean = False)
            Dim ds As DataSet = SqlHelper.ExecuteDataset(ConnectionString _
            , CommandType.StoredProcedure _
            , "GetPOPlaceOfDeliveryList" _
            )
            Dim dt As DataTable = ds.Tables(0)
            If dt Is Nothing Then
                Return
            End If
            cmb.Items.Clear()
            For Each row As DataRow In dt.Rows
                Dim item As New IdValuePair(CInt(row("poplaceofdelivery_id")), CStr(row("poplaceofdelivery_name")))
                cmb.Items.Add(item)
            Next
            If includeNothing Then
                Dim myService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
                cmb.Items.Insert(0, New IdValuePair(-1, myService.Parse("${res:Global.Unspecified}")))
            End If
        End Sub

        Public Sub ComboSelect(ByVal cmb As ComboBox)
            For Each item As IdValuePair In cmb.Items
                If Me.Id = item.Id Then
                    cmb.SelectedItem = item
                    Return
                End If
            Next
            cmb.SelectedIndex = -1
        End Sub
#End Region

#Region "Method"
        Public Overrides Function ToString() As String
            Return m_name
        End Function
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            returnVal.ParameterName = "RETURN_VALUE"
            returnVal.DbType = DbType.Int32
            returnVal.Direction = ParameterDirection.ReturnValue
            returnVal.SourceVersion = DataRowVersion.Current

            Dim paramArrayList As New ArrayList

            If Me.Originated Then
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
            End If

            Dim theTime As Date = Now
            Dim theUser As New User(currentUserId)

            If Me.AutoGen And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
            End If
            Me.AutoGen = False

            paramArrayList.Add(returnVal)
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_name", Me.Name))

            SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

            ' สร้าง SqlParameter จาก ArrayList ...
            Dim sqlparams() As SqlParameter
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)

            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()
            trans = conn.BeginTransaction

            Try
                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                trans.Commit()
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(returnVal.Value.ToString)
            Finally
                conn.Close()
            End Try
        End Function

#End Region

    End Class
End Namespace

