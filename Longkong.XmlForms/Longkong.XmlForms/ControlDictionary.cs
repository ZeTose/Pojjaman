
using System;
using System.Xml;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Longkong.XmlForms {
	
	/// <summary>
	/// A custom dictionary, for storing controls
	/// </summary>
	public class ControlDictionary
	{
		ArrayList arr = new ArrayList();
		Hashtable baseHashtable = new Hashtable();
		
		public Control this[object key] {
			get {
				return (Control)baseHashtable[key];
			}
			set {
				baseHashtable[key] = value;
				if (!arr.Contains(value))
				{
					arr.Add(value);
				}
			}
		}
		public Hashtable Hashtable {
			get 
			{
				return baseHashtable;
			}
		}
		public ArrayList ArrayList 
		{
			get 
			{
				return arr;
			}
		}
	}
}
