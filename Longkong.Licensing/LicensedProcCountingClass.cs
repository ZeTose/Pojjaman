using System;
using System.ComponentModel;

namespace Longkong.Licensing
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	[LicenseProviderAttribute(typeof(ProcCountLicenseProvider))]
	public class LicensedProcCountingClass : IDisposable 
	{

		private ProcCountLicenseProvider.ProcCountLicense license = null;

		public LicensedProcCountingClass () 
		{
			license = (ProcCountLicenseProvider.ProcCountLicense)LicenseManager.Validate(typeof(LicensedProcCountingClass), this);
			Console.WriteLine("License valid for " + license.ValidProcCount + " processors.");
		}

		public void Dispose() 
		{
			if (license != null) 
			{
				license.Dispose();
				license = null;
			}
		}
	}
}
