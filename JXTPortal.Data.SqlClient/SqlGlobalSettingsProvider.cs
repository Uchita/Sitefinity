#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;

using JXTPortal.Entities;
using JXTPortal.Data;

#endregion

namespace JXTPortal.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="GlobalSettings"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class SqlGlobalSettingsProvider: SqlGlobalSettingsProviderBase
	{
		/// <summary>
		/// Creates a new <see cref="SqlGlobalSettingsProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="connectionString">The connection string to the database.</param>
		/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
		/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
		public SqlGlobalSettingsProvider(string connectionString, bool useStoredProcedure, string providerInvariantName): base(connectionString, useStoredProcedure, providerInvariantName){}
	}
}