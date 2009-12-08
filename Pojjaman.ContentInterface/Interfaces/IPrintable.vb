Imports System.Windows.Forms
Imports System.Drawing.Printing
Namespace Longkong.Pojjaman.Gui
    Public Interface IPrintable
        ' Properties
        ReadOnly Property PrintDocument() As PrintDocument
        ReadOnly Property CanPrint() As Boolean
        ReadOnly Property PrintDocuments() As ArrayList
    End Interface
End Namespace



