
using System;
using System.Xml;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Longkong.XmlForms {
	
	public interface IPropertyValueCreator
	{
		bool CanCreateValueForType(Type propertyType);
		
		object CreateValue(Type propertyType, string valueString);
		
	}
}
