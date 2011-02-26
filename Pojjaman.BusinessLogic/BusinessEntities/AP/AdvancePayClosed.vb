Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class AdvancePayClosedStatus
        Inherits CodeDescription

#Region "Constructors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "advp_status"
            End Get
        End Property
#End Region

    End Class
    Public Class AdvancePayClosed
        Inherits SimpleBusinessEntityBase
        Implements IGLAble, IReceivable, ICheckPeriod, IVatable, IWitholdingTaxable, ICancelable

#Region "Members"
        Private m_docdate As Date
        Private m_advancepay As AdvancePay
        Private m_remainamt As Decimal
        Private m_vatamt As Decimal
        Private m_amt As Decimal
        Private m_note As String
        Private m_supplier As Supplier
        Private m_costCenter As CostCenter

        Private m_taxType As TaxType
        Private m_receive As Receive
        Private m_je As JournalEntry
        Private m_whtcol As WitholdingTaxCollection
        Private m_vat As Vat
        Private m_status As AdvancePayClosedStatus

        Private m_taxbase As Decimal
        Private m_realGross As Decimal
        Private m_beforetax As Decimal

        Private m_avpvatnotdueremain As Decimal
        Private m_avpvatdueamount As Decimal
        Private m_vatuseamt As Decimal
        Private m_avpvatbasenotdueremain As Decimal

        Private m_novat As Nullable(Of Boolean)


#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal id As Integer)
            MyBase.New(id)
        End Sub
        Public Sub New(ByVal code As String)
            MyBase.New(code)
        End Sub
        Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub

        

        Protected Overloads Overrides Sub Construct()
            MyBase.Construct()
            With Me
                .m_docdate = Now.Date
                .m_advancepay = New AdvancePay
                .m_status = New AdvancePayClosedStatus(-1)
                .m_docdate = Now.Date
                .m_supplier = New Supplier
                Me.m_costCenter = New CostCenter
                .m_receive = New Receive
                .m_receive.DocDate = Me.m_docdate
                .m_je = New JournalEntry(Me)
                .m_je.DocDate = Me.m_docdate
                .m_note = ""
                .m_taxType = New TaxType(2)
                .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
                If .m_taxType.Value = 0 Then
                    .m_taxType.Value = 1
                End If

                .m_supplier = New Supplier
                '----------------------------Tab Entities-----------------------------------------
                .m_vat = New Vat(Me)
                .m_vat.Direction.Value = 1
                .m_whtcol = New WitholdingTaxCollection(CType(Me, IWitholdingTaxable))
                .m_whtcol.Direction = New WitholdingTaxDirection(0)
                .AutoCodeFormat = New AutoCodeFormat(Me)
            End With
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            MyBase.Construct(ds, aliasPrefix)
        End Sub
        Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
            MyBase.Construct(dr, aliasPrefix)
            With Me

                ' docdate
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_docdate") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_docdate") Then
                    .m_docdate = CDate(dr(aliasPrefix & Me.Prefix & "_docdate"))
                End If
                ' account
                If dr.Table.Columns.Contains("advancepay.advp_id") Then
                    If Not dr.IsNull("advancepay.advp_id") Then
                        .m_advancepay = New AdvancePay(dr, "")
                    End If
                Else
                    If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_entity") _
                        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_entity") Then
                        .m_advancepay = New AdvancePay(CInt(dr(aliasPrefix & Me.Prefix & "_entity")))
                        .m_taxType = New TaxType(CInt(dr("advp_taxType")))
                        ' .m_taxbase = CDec(dr("advp_taxbase"))

                    End If
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_remainamt") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_remainamt") Then
                    .m_remainamt = CDec(dr(aliasPrefix & Me.Prefix & "_remainamt"))
                End If


                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_amt") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_amt") Then
                    .m_amt = CDec(dr(aliasPrefix & Me.Prefix & "_amt"))
                End If

                ' note
                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
                End If

                If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
                    AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
                    .m_status = New AdvancePayClosedStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
                End If

                .m_vat = New Vat(Me)
                m_vat.Direction.Value = 1

                SetremainAVP()

                .m_receive = New Receive(Me)

                .m_je = New JournalEntry(Me)

                .m_whtcol = New WitholdingTaxCollection(CType(Me, IWitholdingTaxable))
                .m_whtcol.Direction = New WitholdingTaxDirection(0)
            End With
            Me.AutoCodeFormat = New AutoCodeFormat(Me)
        End Sub
#End Region

#Region "Properties"

        Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate, IVatable.Date, IWitholdingTaxable.Date
            Get
                Return m_docdate
            End Get
            Set(ByVal Value As Date)
                m_docdate = Value
                Me.m_je.DocDate = Value

            End Set
        End Property

        Public Property AdvancePay() As AdvancePay
            Get
                Return m_advancepay
            End Get
            Set(ByVal Value As AdvancePay)
                m_advancepay = Value
            End Set
        End Property

        Public ReadOnly Property EntityType() As Integer
            Get
                Return m_advancepay.EntityId
            End Get

        End Property
        Public Property Amount() As Decimal
            Get
                Return m_amt
            End Get
            Set(ByVal Value As Decimal)
                m_amt = Value
            End Set
        End Property
        Public Property TaxType() As TaxType
            Get
                Return m_taxType
            End Get
            Set(ByVal Value As TaxType)
                m_taxType = Value
                OnPropertyChanged(Me, New PropertyChangedEventArgs)
            End Set
        End Property

        Public Property Note() As String Implements IGLAble.Note
            Get
                Return m_note
            End Get
            Set(ByVal Value As String)
                m_note = Value
            End Set
        End Property
        Public Property RemainAmount() As Decimal
            Get
                Return m_remainamt
            End Get
            Set(ByVal Value As Decimal)
                m_remainamt = Value
            End Set
        End Property

        Public Property VatAmount() As Decimal
            Get
                Return m_vatamt
            End Get
            Set(ByVal Value As Decimal)
                m_vatamt = Value
            End Set
        End Property
        Public Overrides Property Status() As CodeDescription
            Get
                Return m_status
            End Get
            Set(ByVal Value As CodeDescription)
                m_status = CType(Value, AdvancePayClosedStatus)
            End Set
        End Property
        Public Property CostCenter() As CostCenter            Get                Return m_costCenter            End Get            Set(ByVal Value As CostCenter)                m_costCenter = Value            End Set        End Property
        Public Property Vat() As Vat Implements IVatable.Vat
            Get
                Return m_vat
            End Get
            Set(ByVal value As Vat)
                m_vat = value
            End Set
        End Property
        Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
            Get
                Return m_whtcol
            End Get
            Set(ByVal Value As WitholdingTaxCollection)
                m_whtcol = Value
            End Set
        End Property
        Public Property avpcTaxbase As Decimal
            Get
                Return Vat.GetExcludedVatAmount(RemainAmount)
            End Get
            Set(ByVal value As Decimal)

            End Set
        End Property
        Public Property TaxbaseForIVatable As Decimal Implements IVatable.TaxBase
            Get
                If Me.NoVat Then
                    Return 0
                End If
                If Me.AvpVatDueAmount - Me.VatUseAmt > 0 Then
                    Return m_taxbase
                End If
                Return Me.avpcTaxbase
            End Get
            Set(ByVal value As Decimal)

            End Set
        End Property
        Public Property TaxBase() As Decimal 'Implements IVatable.TaxBase
            Get
                Return m_taxbase
            End Get
            Set(ByVal Value As Decimal)
                m_taxbase = Value
            End Set
        End Property
        Public ReadOnly Property AfterTax() As Decimal
            Get
                Return Me.BeforeTax
            End Get
        End Property
        Public ReadOnly Property BeforeTax() As Decimal
            Get
                Return m_beforetax
            End Get
        End Property
        ''' หาได้จากไหน หาจาก vat ขอการปิดเงินมัดจำ
        Private ReadOnly Property VatNotDueAmount As Decimal
            Get
                If Me.AvpVatNotDueRemain > 0 Then
                    Return Me.RemainAmount - Me.avpcTaxbase
                End If
            End Get
        End Property
        ''' หาได้จาก VND มัดจำ ที่เหลืออยู่
        Private Property AvpVatNotDueRemain As Decimal
            Get
                Return m_avpvatnotdueremain
            End Get
            Set(ByVal Value As Decimal)
                m_avpvatnotdueremain = Value
            End Set
        End Property
        ''' หาได้จาก Vat มัดจำ ที่ออกใบกำกับแล้ว
        Private Property AvpVatDueAmount As Decimal
            Get
                Return m_avpvatdueamount
            End Get
            Set(ByVal Value As Decimal)
                m_avpvatdueamount = Value
            End Set
        End Property
        ''' หาได้จาก Vat มัดจำ ที่ใช้ไปแล้ว
        Private Property VatUseAmt As Decimal
            Get
                Return m_vatuseamt
            End Get
            Set(ByVal Value As Decimal)
                m_vatuseamt = Value
            End Set
        End Property
        Private Property AvpVatBaseNotDueRemain As Decimal
            Get
                Return m_avpvatbasenotdueremain
            End Get
            Set(ByVal Value As Decimal)
                m_avpvatbasenotdueremain = Value
            End Set
        End Property
        Public Property Supplier() As Supplier
            Get
                Return m_supplier
            End Get
            Set(ByVal Value As Supplier)
                Dim oldPerson As IBillablePerson = m_supplier
                If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _
                  OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then
                    If Not Me.m_whtcol Is Nothing Then
                        For Each wht As WitholdingTax In m_whtcol
                            wht.UpdateRefDoc(Value, True)
                        Next
                    End If
                End If
                m_supplier = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Public Function GetVatForADVPC(ByVal advp As AdvancePay) As DataSet
            Try
                Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                    Me.ConnectionString _
                    , CommandType.StoredProcedure _
                    , "GetVatForAdvancePayClosed" _
                    , New SqlParameter("@advp_id", advp.Id) _
                    )
                Return ds
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Function
        Private Sub ResetID(ByVal oldid As Integer, ByVal oldreceive As Integer, ByVal oldvat As Integer, ByVal oldje As Integer)
            Me.Id = oldid
            Me.m_receive.Id = oldreceive
            Me.m_vat.Id = oldvat
            Me.m_je.Id = oldje
        End Sub
        Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
            Me.Code = oldCode
            Me.AutoGen = oldautogen
            Me.m_je.Code = oldJecode
            Me.m_je.AutoGen = oldjeautogen
        End Sub
        Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
            'Return New SaveErrorException("Not Yet Implemented")
            'MessageBox.Show(String.Format("{0}:{1}", Me.Amount, Me.Receive.Amount))
            'If Me.Amount < Me.Receive.Amount Then
            '    Return New SaveErrorException("${res:Global.Error.ReceiveAmountExceedGross}", Me.Amount.ToString, Me.Receive.Amount.ToString)
            'ElseIf Me.Amount > Me.Receive.Amount Then
            '    Return New SaveErrorException("${res:Global.Error.ReceiveGrossExceedAmount}", Me.Amount.ToString, Me.Receive.Amount.ToString)
            'End If

            Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
            returnVal.ParameterName = "RETURN_VALUE"
            returnVal.DbType = DbType.Int32
            returnVal.Direction = ParameterDirection.ReturnValue
            returnVal.SourceVersion = DataRowVersion.Current
            Dim paramArrayList As New ArrayList

            paramArrayList.Add(returnVal)
            If Me.Originated Then
                paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
            End If

            Dim theTime As Date = Now
            Dim theUser As New User(currentUserId)

            If Me.m_je.Status.Value = 4 Then
                Me.Status.Value = 4
                Me.m_receive.Status.Value = 4
                Me.m_whtcol.SetStatus(4)
                Me.m_vat.Status.Value = 4
            End If
            If Me.Status.Value = 0 Then
                Me.m_receive.Status.Value = 0
                Me.m_whtcol.SetStatus(0)
                Me.m_vat.Status.Value = 0
                Me.m_je.Status.Value = 0
            End If
            If Me.Status.Value = -1 Then
                Me.Status = New AdvancePayClosedStatus(2)
            End If
            '---- AutoCode Format --------
            Me.m_je.RefreshGLFormat()
            If Not AutoCodeFormat Is Nothing Then
                Select Case Me.AutoCodeFormat.CodeConfig.Value
                    Case 0
                        If Me.AutoGen Then 'And Me.Code.Length = 0 Then

                            Me.Code = Me.GetNextCode
                        End If
                        Me.m_je.DontSave = True
                        Me.m_je.Code = ""
                        Me.m_je.DocDate = Me.DocDate
                    Case 1
                        'ตาม entity
                        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                            Me.Code = Me.GetNextCode
                        End If
                        Me.m_je.Code = Me.Code
                    Case 2
                        'ตาม gl
                        If Me.m_je.AutoGen Then
                            Me.m_je.Code = m_je.GetNextCode
                        End If
                        Me.Code = Me.m_je.Code
                    Case Else
                        'แยก
                        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                            Me.Code = Me.GetNextCode
                        End If
                        If Me.m_je.AutoGen Then
                            Me.m_je.Code = m_je.GetNextCode
                        End If
                End Select
            Else
                If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                    Me.Code = Me.GetNextCode
                End If
                If Me.m_je.AutoGen Then
                    Me.m_je.Code = m_je.GetNextCode
                End If
            End If
            Me.m_je.DocDate = Me.DocDate
            Me.m_receive.Code = m_je.Code
            Me.m_receive.DocDate = m_je.DocDate
            Me.AutoGen = False
            Me.m_receive.AutoGen = False
            Me.m_je.AutoGen = False
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docdate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entity", IIf(Me.AdvancePay.Originated, Me.AdvancePay.Id, DBNull.Value)))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_entitytype", Me.EntityType))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_remainamt", Me.RemainingAmount))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
            paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))

            SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

            ' สร้าง SqlParameter จาก ArrayList ...note
            Dim sqlparams() As SqlParameter
            sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()

            Dim oldid As Integer = Me.Id
            Dim oldreceive As Integer = m_receive.Id
            Dim oldje As Integer = m_je.Id
            Dim oldvat As Integer = Me.m_vat.Id
            Dim oldcode As String
            Dim oldautogen As Boolean
            Dim oldjecode As String
            Dim oldjeautogen As Boolean
            If Not Me.WitholdingTaxCollection Is Nothing Then
                Me.WitholdingTaxCollection.SaveOldID()
            End If

            oldcode = Me.Code
            oldautogen = Me.AutoGen
            oldjecode = Me.m_je.Code
            oldjeautogen = Me.m_je.AutoGen

            Try
                UpdateAdvancePayStatus(False)

                Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1, -2, -5
                            trans.Rollback()
                            Me.ResetID(oldid, oldreceive, oldvat, oldje)
                            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                            Return New SaveErrorException(returnVal.Value.ToString)
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If

                If Not Me.AdvancePay.CostCenter Is Nothing Then
                    Me.m_receive.CcId = Me.AdvancePay.CostCenter.Id
                    Me.m_whtcol.SetCCId(Me.AdvancePay.CostCenter.Id)
                    Me.m_vat.SetCCId(Me.AdvancePay.CostCenter.Id)
                End If

                ''******************************************************************
                Dim saveReceiveError As SaveErrorException = Me.m_receive.Save(currentUserId, conn, trans)
                If Not IsNumeric(saveReceiveError.Message) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveReceiveError
                Else
                    Select Case CInt(saveReceiveError.Message)
                        Case -1, -2
                            trans.Rollback()
                            Me.ResetID(oldid, oldreceive, oldvat, oldje)
                            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                            Return saveReceiveError
                        Case Else
                    End Select
                End If
                ''******************************************************************
                Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
                If Not IsNumeric(saveVatError.Message) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveVatError
                Else
                    Select Case CInt(saveVatError.Message)
                        Case -1, -2, -5
                            trans.Rollback()
                            Me.ResetID(oldid, oldreceive, oldvat, oldje)
                            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                            Return saveVatError
                        Case Else
                    End Select
                End If
                ''******************************************************************
                If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
                    Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
                    If Not IsNumeric(saveWhtError.Message) Then
                        trans.Rollback()
                        Me.ResetID(oldid, oldreceive, oldvat, oldje)
                        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                        Return saveWhtError
                    Else
                        Select Case CInt(saveWhtError.Message)
                            Case -1, -2
                                trans.Rollback()
                                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                                Return saveWhtError
                            Case Else
                        End Select
                    End If
                Else
                    WitholdingTax.DeleteFromRefDoc(Me.Id, Me.EntityId, conn, trans)
                End If
                ''******************************************************************
                If Me.m_je.Status.Value = -1 Then
                    m_je.Status.Value = 3
                End If

                If Not Me.m_je.ManualFormat Then
                    m_je.SetGLFormat(Me.GetDefaultGLFormat)
                End If

                Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
                If Not IsNumeric(saveJeError.Message) Then
                    trans.Rollback()
                    Me.ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveJeError
                Else
                    Select Case CInt(saveJeError.Message)
                        Case -1, -5
                            trans.Rollback()
                            Me.ResetID(oldid, oldreceive, oldvat, oldje)
                            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                            Return saveJeError
                        Case -2
                            'Post ไปแล้ว
                            Return saveJeError
                        Case Else
                    End Select
                End If
                ''******************************************************************
                '==============================AUTOGEN==========================================
                Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
                If Not IsNumeric(saveAutoCodeError.Message) Then
                    trans.Rollback()
                    ResetID(oldid, oldreceive, oldvat, oldje)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveAutoCodeError
                Else
                    Select Case CInt(saveAutoCodeError.Message)
                        Case -1, -2, -5
                            trans.Rollback()
                            ResetID(oldid, oldreceive, oldvat, oldje)
                            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                            Return saveAutoCodeError
                        Case Else
                    End Select
                End If
                '==============================AUTOGEN==========================================

                trans.Commit()

                UpdateAdvancePayStatus(True)

                Return New SaveErrorException(returnVal.Value.ToString)
            Catch ex As SqlException
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(ex.ToString)
            Catch ex As Exception
                trans.Rollback()
                Me.ResetID(oldid, oldreceive, oldvat, oldje)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return New SaveErrorException(ex.ToString)
            Finally
                conn.Close()
            End Try
        End Function
        Public Sub UpdateAdvancePayStatus(ByVal Closed As Boolean)
            ' Execute Store Procedure ...
            If Not Me.Originated Then
                Return
            End If
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "UpdateAdvancePayStatus", New SqlParameter("@advpclosed_id", Me.Id), New SqlParameter("@advp_closed", Closed))
        End Sub

#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property Prefix() As String
            Get
                Return "advpclosed"
            End Get
        End Property
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "AdvancePayClosed"
            End Get
        End Property
        Public Overrides ReadOnly Property TableName() As String
            Get
                Return "AdvancePayClosed"
            End Get
        End Property
        Public Overrides ReadOnly Property GetSprocName() As String
            Get
                Return "Get" & Me.TableName
            End Get
        End Property

        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.AdvancePayClosed.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.AdvancePayClosed"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.AdvancePayClosed"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.AdvancePayClosed.ListLabel}"
            End Get
        End Property
#End Region

#Region "Shared"
        Public Shared Function GetAdvancePayClosed(ByVal txtCode As TextBox, ByRef oldPtc As AdvancePayClosed) As Boolean
            Dim ptc As New AdvancePayClosed(txtCode.Text)
            If txtCode.Text.Length <> 0 AndAlso Not ptc.Originated Then
                MessageBox.Show(txtCode.Text & " ไม่มีในระบบ")
                ptc = oldPtc
            End If
            txtCode.Text = ptc.Code
            If oldPtc.Id <> ptc.Id Then
                oldPtc = ptc
                Return True
            End If
            Return False
        End Function
#End Region
#Region "IVatable"
        Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
            'Todo: ต้อง refresh หรือเปล่า?
            Return Me.TaxbaseForIVatable
        End Function
        Public Property Person() As IBillablePerson Implements IVatable.Person, IWitholdingTaxable.Person
            Get
                Return Me.AdvancePay.Supplier
            End Get
            Set(ByVal Value As IBillablePerson)
                Me.AdvancePay.Supplier = CType(Value, Supplier)
            End Set
        End Property
        Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
            Return Me.AfterTax
        End Function
        Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
            Return Me.BeforeTax
        End Function
        Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
            Get
                If Not m_novat.HasValue Then
                    SetNoVat()
                End If
                Return Me.TaxType.Value = 0 OrElse m_novat.Value
            End Get
        End Property
        Public Sub SetNoVat()
            If Me.TaxType.Value = 0 OrElse Me.Vat.ItemCollection.Count = 0 _
                 OrElse Me.Vat.ItemCollection(0).Code Is Nothing _
                 OrElse (Me.Vat.ItemCollection(0).Code.Length = 0 AndAlso Not Me.Vat.AutoGen) Then
                m_novat = True
            Else
                m_novat = False
            End If
            
        End Sub
#End Region
#Region "IWitholdingTaxable"
        Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
            Return Me.TaxBase
        End Function
#End Region
#Region " IGLAble "
        Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
            If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
                Return Me.AutoCodeFormat.GLFormat
            End If
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
                        , CommandType.StoredProcedure _
                        , "GetGLFormatForEntity" _
                        , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
            Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
            Return glf
        End Function

        Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
            Dim jiColl As New JournalEntryItemCollection
            Dim ji As JournalEntryItem

            '--===- Cr. เงินมัดจำจ่าย ============

            If Me.RemainAmount > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "B9.1"
                ji.Account = Me.AdvancePay.ToAccount
                'หาค่า AVP Remain ที่ไม่รวม Vat
                ji.Amount = Me.avpcTaxbase
                If Not Me.AdvancePay.CostCenter Is Nothing Then
                    ji.CostCenter = Me.AdvancePay.CostCenter
                Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
            End If

            '--===- Cr. เงินมัดจำจ่าย ============



            '======= ว่าด้วยเรื่อง Vat  ===========
            'ภาษีซื้อลดหนี้ Vat
            If Me.Amount > 0 AndAlso (Me.Vat IsNot Nothing AndAlso Me.Vat.ItemCollection.Count > 0 AndAlso Me.Vat.ItemCollection(0).Code IsNot Nothing AndAlso (Me.Vat.ItemCollection(0).Code.Length > 0)) Then
                ji = New JournalEntryItem
                ji.Mapping = "B9.2"
                'ยอดภาษีที่ออกใบกำกับมาแล้ว เกินจาก ยอดมูลค่า vat ที่ใช้หักมัดจำไป
                ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
                If Me.CostCenter.Originated Then
                    ji.CostCenter = Me.CostCenter
                Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
            End If

            'ล้าง ภาษีซื้อยังไม่ถึงกำหนด Vat Not Due 
            If Math.Min(Me.VatNotDueAmount, Me.AvpVatNotDueRemain) > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "B9.2.1"
                'ยอด Vat Not Due ของมัดจำที่เหลืออยู่ เทียบกับที่ ปิดเงินปัดจำ  เอาอันที่น้อยกว่า
                ji.Amount = Configuration.Format(Math.Min(Me.VatNotDueAmount, Me.AvpVatNotDueRemain), DigitConfig.Price)
                If Me.CostCenter.Originated Then
                    ji.CostCenter = Me.CostCenter
                Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
            End If

            'รายได้จากส่วนต่างการออก Vat
            If Me.AvpVatDueAmount - Me.VatUseAmt > 0 AndAlso (Me.NoVat) Then
                ji = New JournalEntryItem
                ji.Mapping = "B9.4"
                'ยอดมูลค่า vat ที่ได้รับใบกำกับ มากกกว่า ยอดภาษีที่หักใช้ไป 
                ji.Amount = Configuration.Format(Me.AvpVatDueAmount - Me.VatUseAmt, DigitConfig.Price)
                If Me.CostCenter.Originated Then
                    ji.CostCenter = Me.CostCenter
                Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
            End If
            '======= ว่าด้วยเรื่อง Vat  ===========



            ' TODO : Implements GL ...

            '===========  ฝั่งรับชำระ - =========--
            'ยอดรับชำระต้องเป็นยอดที่รวมภาษีไว้ด้วย
            If Not Me.Receive Is Nothing Then
                jiColl.AddRange(Me.Receive.GetJournalEntries)
            End If

            'ภาษีถูกหัก ณ ที่จ่าย
            If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
                ji = New JournalEntryItem
                ji.Mapping = "B9.3"
                ji.Amount = Me.WitholdingTaxCollection.Amount
                If Me.CostCenter.Originated Then
                    ji.CostCenter = Me.CostCenter
                Else
                    ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                End If
                jiColl.Add(ji)
            End If
            Dim WHTTypeSum As New Hashtable

            For Each wht As WitholdingTax In Me.WitholdingTaxCollection
                If WHTTypeSum.Contains(wht.Type.Value) Then
                    WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
                Else
                    WHTTypeSum(wht.Type.Value) = wht.Amount
                End If
            Next
            Dim typeNum As String
            For Each obj As Object In WHTTypeSum.Keys
                typeNum = CStr(obj)
                If Not (typeNum.Length > 1) Then
                    typeNum = "0" & typeNum
                End If
                If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
                    ji = New JournalEntryItem
                    ji.Mapping = "E3.18"
                    ji.Amount = CDec(WHTTypeSum(obj))
                    ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
                    If Me.CostCenter.Originated Then
                        ji.CostCenter = Me.CostCenter
                    Else
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    End If
                    ji.Note = Me.Person.Name
                    jiColl.Add(ji)
                End If
            Next
            For Each wht As WitholdingTax In Me.WitholdingTaxCollection
                typeNum = CStr(wht.Type.Value)
                If Not (typeNum.Length > 1) Then
                    typeNum = "0" & typeNum
                End If
                If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
                    ji = New JournalEntryItem
                    ji.Mapping = "E3.18D"
                    ji.Amount = wht.Amount
                    ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
                    If Me.CostCenter.Originated Then
                        ji.CostCenter = Me.CostCenter
                    Else
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    End If
                    ji.Note = Me.Person.Name
                    jiColl.Add(ji)
                End If
            Next
            For Each wht As WitholdingTax In Me.WitholdingTaxCollection
                typeNum = CStr(wht.Type.Value)
                If Not (typeNum.Length > 1) Then
                    typeNum = "0" & typeNum
                End If
                If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
                    ji = New JournalEntryItem
                    ji.Mapping = "E3.18W"
                    ji.Amount = wht.Amount
                    ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
                    If Me.CostCenter.Originated Then
                        ji.CostCenter = Me.CostCenter
                    Else
                        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
                    End If
                    ji.Note = Me.Person.Name
                    jiColl.Add(ji)
                End If
            Next

            '------ =======
            Return jiColl
        End Function

        Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
            Get
                Return Me.m_je
            End Get
            Set(ByVal Value As JournalEntry)
                Me.m_je = Value
            End Set
        End Property
#End Region

#Region " IReceiveable "
        Public Function AmountToReceive() As Decimal Implements IReceivable.AmountToReceive
            Return Me.RemainingAmount
            'Return Me.Amount
        End Function

        Public Property Date2() As Date Implements IReceivable.Date
            Get
                Return Me.m_receive.DocDate
            End Get
            Set(ByVal Value As Date)
                Me.m_receive.DocDate = Value
            End Set
        End Property

        Public Property DueDate() As Date Implements IReceivable.DueDate
            Get
                Return Me.m_receive.DocDate
            End Get
            Set(ByVal Value As Date)

            End Set
        End Property

        Public Property IReceivableNote() As String Implements IReceivable.Note
            Get
                Return Me.m_receive.Note
            End Get
            Set(ByVal Value As String)
                Me.m_receive.Note = Value
            End Set
        End Property
        Public ReadOnly Property Payer() As IBillablePerson Implements IReceivable.Payer
            Get

            End Get
        End Property

        Public Property Receive() As Receive Implements IReceivable.Receive
            Get
                Return Me.m_receive
            End Get
            Set(ByVal Value As Receive)
                Me.m_receive = Value
            End Set
        End Property
        Public Function RemainingAmount() As Decimal Implements IReceivable.RemainingAmount
            Return Me.RemainAmount
        End Function

#End Region

#Region "Delete"
        Public Overrides ReadOnly Property CanDelete() As Boolean
            Get
                If Me.Originated Then
                    Return Me.Status.Value <= 2
                Else
                    Return False
                End If
            End Get
        End Property
        Public Overrides Function Delete() As SaveErrorException
            If Not Me.Originated Then
                Return New SaveErrorException("${res:Global.Error.NoIdError}")
            End If
            Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim format(0) As String
            format(0) = Me.Code
            If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteAdvancePayClosed}", format) Then
                Return New SaveErrorException("${res:Global.CencelDelete}")
            End If
            Dim trans As SqlTransaction
            Dim conn As New SqlConnection(Me.ConnectionString)
            conn.Open()
            trans = conn.BeginTransaction()
            Try
                Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
                returnVal.ParameterName = "RETURN_VALUE"
                returnVal.DbType = DbType.Int32
                returnVal.Direction = ParameterDirection.ReturnValue
                returnVal.SourceVersion = DataRowVersion.Current
                SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteAdvancePayClosed", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
                If IsNumeric(returnVal.Value) Then
                    Select Case CInt(returnVal.Value)
                        Case -1
                            trans.Rollback()
                            Return New SaveErrorException("${res:Global.AdvancePayClosedIsReferencedCannotBeDeleted}")
                        Case Else
                    End Select
                ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
                    trans.Rollback()
                    Return New SaveErrorException(returnVal.Value.ToString)
                End If
                trans.Commit()
                Return New SaveErrorException("1")
            Catch ex As SqlException
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Catch ex As Exception
                trans.Rollback()
                Return New SaveErrorException(ex.Message)
            Finally
                conn.Close()
            End Try
        End Function
#End Region
#Region "ICancelable"
        Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
            Get
                Return Me.Status.Value > 1 AndAlso Me.IsCancelable
            End Get
        End Property
        Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
            Me.Status.Value = 0
            Return Me.Save(currentUserId)
        End Function
#End Region

        Public Sub GenVatAmount(Optional ByVal force As Boolean = False)
            If (Not Me.Vat.ItemCollection Is Nothing AndAlso Not Me.Vat.Originated AndAlso Me.TaxType.Value <> 0) OrElse force Then
                Dim remain As Decimal
                remain = Vat.GetExcludedVatAmount(RemainAmount) - Me.AvpVatBaseNotDueRemain
                If Me.Vat.ItemCollection.Count = 0 Then
                    Dim vi As New VatItem
                    Me.Vat.ItemCollection.Add(vi)
                End If
                If remain <= 0 Then
                    Me.TaxBase = 0
                    Me.m_novat = True
                Else
                    Me.TaxBase = remain
                    Me.SetNoVat()
                End If

                Me.VatAmount = Vat.GetVatAmount(Me.TaxBase)

                Vat.ItemCollection.Item(0).Amount = Me.VatAmount
                Vat.ItemCollection.Item(0).TaxBase = Me.TaxBase
            End If
        End Sub

        Public Sub SetremainAVP()
            Dim dr As DataRow = Me.AdvancePay.GetRemainingAmountasDataRow()
            Dim drh As New DataRowHelper(dr)

            Dim remainamt As Decimal = drh.GetValue(Of Decimal)("ADVPRemain")     ' ยอดมัดจำคงเหลือรวม vat
            Me.AvpVatBaseNotDueRemain = drh.GetValue(Of Decimal)("AdvpNotDueExV")    ' ยอดมัดจำไม่รวม vat & ไม่ได้ออกใบกำกับภาษี
            Me.AvpVatNotDueRemain = drh.GetValue(Of Decimal)("VatNotDue")      ' ยอด vat & ไม่ได้ออกใบกำกับภาษี
            Me.AvpVatDueAmount = drh.GetValue(Of Decimal)("VatDue")           ' ยอด vat & ออกใบกำกับภาษี
            Me.VatUseAmt = drh.GetValue(Of Decimal)("VatUse")                 ' ยอด vat ที่ใช้ไป
            Me.AdvancePay.ADVPRemainingAmount = remainamt
            Me.Amount = Me.AdvancePay.AfterTax
            Me.RemainAmount = remainamt
        End Sub
    End Class
End Namespace
