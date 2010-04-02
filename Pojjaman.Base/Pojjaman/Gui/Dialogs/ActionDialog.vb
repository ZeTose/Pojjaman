Imports System.Windows.Forms
Imports Longkong.Pojjaman.BusinessLogic
Public Class ActionDialog

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Public Sub SetWarning(ByVal p1 As Decimal, ByVal amount As Decimal)
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.Label1.Text = "Amount: " & Configuration.FormatToString(amount, DigitConfig.Price) & "THB, please approve carefully."
  End Sub
End Class
