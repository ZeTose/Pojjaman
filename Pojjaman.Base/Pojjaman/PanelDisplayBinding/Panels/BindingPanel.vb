Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Longkong.Core.Services
Imports Longkong.Core.Properties
Imports System.Drawing
Imports Longkong.Pojjaman.Services
Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports Microsoft.Win32
Imports System.Text
Imports System.Threading
Imports Longkong.Pojjaman.FormDisplayBinding

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class BindingPanel
        Inherits UserControl

#Region "Methods"
        Protected Overridable Sub AddBinding(ByVal ctrl As System.Windows.Forms.Control, ByVal ds As Object, ByVal prop As String, ByVal name As String)
            If Not IsNothing(ctrl.DataBindings(prop)) Then
                ctrl.DataBindings.Remove(ctrl.DataBindings(prop))
            End If
            Dim b As Binding = ctrl.DataBindings.Add(prop, ds, name)
        End Sub
        Protected Sub RefreshBindings(ByVal dataSource As Object)
            Me.BindingContext(dataSource).SuspendBinding()
            Me.BindingContext(dataSource).ResumeBinding()
        End Sub
        Protected Sub DecimalToCurrencyString(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
            ' This method is the Format event handler. Whenever the 
            ' control displays a new value, the value is converted from 
            ' its native Decimal type to a string. The ToString method 
            ' then formats the value as a Currency, by using the 
            ' formatting character "c".

            ' The application can only convert to string type. 

            If Not cevent.DesiredType Is GetType(String) Then
                Exit Sub
            End If
            If Not IsNumeric(cevent.Value) Then
                Exit Sub
            End If
            cevent.Value = CType(cevent.Value, Decimal).ToString("c")
        End Sub
        Protected Sub CurrencyStringToDecimal(ByVal sender As Object, ByVal cevent As ConvertEventArgs)
            ' This method is the Parse event handler. The Parse event 
            ' occurs whenever the displayed value changes. The static 
            ' ToDecimal method of the Convert class converts the 
            ' value back to its native Decimal type.

            ' Can only convert to decimal type.
            If Not cevent.DesiredType Is GetType(Decimal) Then
                Exit Sub
            End If

            cevent.Value = Decimal.Parse(cevent.Value.ToString, Globalization.NumberStyles.Currency, Nothing)

        End Sub
#End Region

    End Class
End Namespace

