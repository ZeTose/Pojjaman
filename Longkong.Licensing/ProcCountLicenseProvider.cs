using System.Runtime.Remoting;
using System.ComponentModel.Design;
using System.Diagnostics;
using System;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Longkong.Licensing
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// <include file='doc\LicFileLicenseProvider.uex' path='docs/doc[@for="LicFileLicenseProvider"]/*' />
	/// <devdoc>
	/// <para>Provides an implementation of a <see cref='System.ComponentModel.LicenseProvider'/>. The provider works in
	///    a similar fashion to Microsoft .NET Framework standard licensing module.</para>
	/// </devdoc>
	public class ProcCountLicenseProvider : LicenseProvider 
	{

		/// <include file='doc\LicFileLicenseProvider.uex' path='docs/doc[@for="LicFileLicenseProvider.IsKeyValid"]/*' />
		/// <devdoc>
		/// <para>Determines if the key retrieved by the <see cref='System.ComponentModel.LicFileLicenseProvider.GetLicense'/> method is valid 
		///    for the specified type.</para>
		/// </devdoc>
		protected virtual bool IsKeyValid(string key, Type type) 
		{
			// If string isn't empty
			if (key != null) 
			{
				//Get number of system processors
				SYSTEM_INFO si;
				GetSystemInfo(out si);
				uint procCount = si.dwNumberOfProcessors;
				
				//Get number of processors license is valid for
				int validProcCount = Int32.Parse(key.Substring(key.IndexOf(',') + 1));
				
				Debug.WriteLine("Processors on System: " + procCount + "\n" + " Valid Processors: " + validProcCount);

				//validate license string and number of processors
				return (procCount <= validProcCount && key.StartsWith(string.Format("{0} is a licensed component.",type.FullName)));
			}
			return false;
		}

		/// <include file='doc\LicFileLicenseProvider.uex' path='docs/doc[@for="LicFileLicenseProvider.GetLicense"]/*' />
		/// <devdoc>
		///    <para>Gets a license for the instance of the component and determines if it is valid.</para>
		/// </devdoc>
		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions) 
		{
			ProcCountLicense lic = null;
            
			Debug.Assert(context != null, "No context provided!");
			//if no context is provided, do nothing
			if (context != null) 
			{
				//if this control is in runtime mode
				if (context.UsageMode == LicenseUsageMode.Runtime) 
				{
					//retreive the stored license key
					string key = context.GetSavedLicenseKey(type, null);

					//check if the stored license key is null
					// and call IsKeyValid to make sure its valid
					if (key != null && IsKeyValid(key, type)) 
					{
						//if the key is valid create a new license
						lic = new ProcCountLicense(this, key);
					}
				}

				//if we're in design mode or 
				//a suitable license key wasn't found in 
				//the runtime context.
				//attempt to look for a .LIC file
				if (lic == null) 
				{
					//build up the path where the .LIC file
					//should be
					string modulePath = null;

					// try and locate the file for the assembly
					if (context != null) 
					{
						ITypeResolutionService resolver = (ITypeResolutionService)context.GetService(typeof(ITypeResolutionService));
						if (resolver != null)
							modulePath = resolver.GetPathOfAssembly(type.Assembly.GetName());
					}


					if (modulePath == null)
						modulePath = type.Module.FullyQualifiedName;

					//get the path from the file location
					string moduleDir = Path.GetDirectoryName(modulePath);
					
					//build the path of the .LIC file
					string licenseFile = moduleDir + "\\" + type.FullName + ".lic";

					Debug.WriteLine("Path of license file: " + licenseFile);

					//if the .LIC file exists, dig into it
					if (File.Exists(licenseFile)) 
					{
						//crack the file and get the first line
						Stream licStream = new FileStream(licenseFile, FileMode.Open, FileAccess.Read, FileShare.Read);
						StreamReader sr = new StreamReader(licStream);
						string s = sr.ReadLine();
						sr.Close();

						Debug.WriteLine("Contents of license file: " + s);

						//check if the key is valid
						if (IsKeyValid(s, type)) 
						{
							//valid key so create a new License
							lic = new ProcCountLicense(this, s);
						}
					}

					//if we managed to create a license, stuff it into the context
					if (lic != null) 
					{
						context.SetSavedLicenseKey(type, lic.LicenseKey);
					}
				}

			}
			return lic;
		}

		[DllImport("KERNEL32", CharSet=CharSet.Auto)]
		public static extern void GetSystemInfo(out SYSTEM_INFO si);

		public class ProcCountLicense : License 
		{
			private ProcCountLicenseProvider owner;
			private string key;
			private int validProcCount;

			public ProcCountLicense(ProcCountLicenseProvider owner, string key) 
			{
				this.owner = owner;
				this.key = key;
				this.validProcCount = Int32.Parse(key.Substring(key.IndexOf(',') + 1));
			}
			public override string LicenseKey 
			{ 
				get 
				{
					return key;
				}
			}

			public int ValidProcCount 
			{
				get 
				{
					return validProcCount;
				}
			}

			public override void Dispose() 
			{
			}
		}

		[StructLayout(LayoutKind.Sequential, Pack=1)]
		public struct SYSTEM_INFO 
		{
			public ushort wProcessorArchitecture;
			public ushort wReserved;
			public uint dwPageSize;
			public IntPtr lpMinimumApplicationAddress;
			public IntPtr lpMaximumApplicationAddress;
			public IntPtr dwActiveProcessorMask;
			public uint dwNumberOfProcessors;
			public uint dwProcessorType;
			public uint dwAllocationGranularity;
			public ushort wProcessorLevel;
			public ushort wProcessorRevision;
		};
	}
}
