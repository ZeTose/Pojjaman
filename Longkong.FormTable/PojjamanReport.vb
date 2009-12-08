Imports Longkong.Pojjaman.Gui.Components
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports Longkong.Pojjaman.BusinessLogic
Namespace Longkong.FormTable
    Public Class PojjamanReport
        Inherits BasePropertyForm

#Region "Members"
        Private m_formFormatCode As String
#End Region

#Region "Properties"
        <ControlProperty("รูปแบบรายงานที่ใช้", Description:="รูปแบบรายงานที่ใช้", Category:="ข้อมูล")> _
        Public Property FormFormatCode() As String            Get                Return m_formFormatCode            End Get            Set(ByVal Value As String)                m_formFormatCode = Value            End Set        End Property
#End Region

    End Class
End Namespace