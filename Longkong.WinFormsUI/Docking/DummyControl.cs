using System;
using System.Windows.Forms;

namespace Longkong.WinFormsUI
{
	internal class DummyControl : Control
	{
		public DummyControl()
		{
			SetStyle(ControlStyles.Selectable, false);
		}
	}
}
