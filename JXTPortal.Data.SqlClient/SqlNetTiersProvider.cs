
#region Using directives

using System;
using System.Collections;
using System.Collections.Specialized;


using System.Web.Configuration;
using System.Data;
using System.Data.Common;
using System.Configuration.Provider;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal.Data.Bases;

#endregion

namespace JXTPortal.Data.SqlClient
{
	/// <summary>
	/// This class is the Sql implementation of the NetTiersProvider.
	/// </summary>
	public sealed class SqlNetTiersProvider : JXTPortal.Data.Bases.NetTiersProvider
	{
		private static object syncRoot = new Object();
		private string _applicationName;
        private string _connectionString;
        private bool _useStoredProcedure;
        string _providerInvariantName;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SqlNetTiersProvider"/> class.
		///</summary>
		public SqlNetTiersProvider()
		{	
		}		
		
		/// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"></see> on a provider after the provider has already been initialized.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
		public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                name = "SqlNetTiersProvider";
            }

            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NetTiers Sql provider");
            }

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _applicationName
            _applicationName = config["applicationName"];

            if (string.IsNullOrEmpty(_applicationName))
            {
                _applicationName = "/";
            }
            config.Remove("applicationName");


            #region "Initialize UseStoredProcedure"
            string storedProcedure  = config["useStoredProcedure"];
           	if (string.IsNullOrEmpty(storedProcedure))
            {
                throw new ProviderException("Empty or missing useStoredProcedure");
            }
            this._useStoredProcedure = Convert.ToBoolean(config["useStoredProcedure"]);
            config.Remove("useStoredProcedure");
            #endregion

			#region ConnectionString

			// Initialize _connectionString
			_connectionString = config["connectionString"];
			config.Remove("connectionString");

			string connect = config["connectionStringName"];
			config.Remove("connectionStringName");

			if ( String.IsNullOrEmpty(_connectionString) )
			{
				if ( String.IsNullOrEmpty(connect) )
				{
					throw new ProviderException("Empty or missing connectionStringName");
				}

				if ( DataRepository.ConnectionStrings[connect] == null )
				{
					throw new ProviderException("Missing connection string");
				}

				_connectionString = DataRepository.ConnectionStrings[connect].ConnectionString;
			}

            if ( String.IsNullOrEmpty(_connectionString) )
            {
                throw new ProviderException("Empty connection string");
			}

			#endregion
            
             #region "_providerInvariantName"

            // initialize _providerInvariantName
            this._providerInvariantName = config["providerInvariantName"];

            if (String.IsNullOrEmpty(_providerInvariantName))
            {
                throw new ProviderException("Empty or missing providerInvariantName");
            }
            config.Remove("providerInvariantName");

            #endregion

        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public override TransactionManager CreateTransaction()
		{
			return new TransactionManager(this._connectionString);
		}
		
		/// <summary>
		/// Gets a value indicating whether to use stored procedure or not.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this repository use stored procedures; otherwise, <c>false</c>.
		/// </value>
		public bool UseStoredProcedure
		{
			get {return this._useStoredProcedure;}
			set {this._useStoredProcedure = value;}
		}
		
		 /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
		public string ConnectionString
		{
			get {return this._connectionString;}
			set {this._connectionString = value;}
		}
		
		/// <summary>
	    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
	    /// </summary>
	    /// <value>The name of the provider invariant.</value>
	    public string ProviderInvariantName
	    {
	        get { return this._providerInvariantName; }
	        set { this._providerInvariantName = value; }
	    }		
		
		///<summary>
		/// Indicates if the current <c cref="NetTiersProvider"/> implementation supports Transacton.
		///</summary>
		public override bool IsTransactionSupported
		{
			get
			{
				return true;
			}
		}

		
		#region "JobCustomQuestionnaireProvider"
			
		private SqlJobCustomQuestionnaireProvider innerSqlJobCustomQuestionnaireProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobCustomQuestionnaire"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobCustomQuestionnaireProviderBase JobCustomQuestionnaireProvider
		{
			get
			{
				if (innerSqlJobCustomQuestionnaireProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobCustomQuestionnaireProvider == null)
						{
							this.innerSqlJobCustomQuestionnaireProvider = new SqlJobCustomQuestionnaireProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobCustomQuestionnaireProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobCustomQuestionnaireProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobCustomQuestionnaireProvider SqlJobCustomQuestionnaireProvider
		{
			get {return JobCustomQuestionnaireProvider as SqlJobCustomQuestionnaireProvider;}
		}
		
		#endregion
		
		
		#region "SiteWebPartTypesProvider"
			
		private SqlSiteWebPartTypesProvider innerSqlSiteWebPartTypesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteWebPartTypes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteWebPartTypesProviderBase SiteWebPartTypesProvider
		{
			get
			{
				if (innerSqlSiteWebPartTypesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteWebPartTypesProvider == null)
						{
							this.innerSqlSiteWebPartTypesProvider = new SqlSiteWebPartTypesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteWebPartTypesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteWebPartTypesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteWebPartTypesProvider SqlSiteWebPartTypesProvider
		{
			get {return SiteWebPartTypesProvider as SqlSiteWebPartTypesProvider;}
		}
		
		#endregion
		
		
		#region "AdminRolesProvider"
			
		private SqlAdminRolesProvider innerSqlAdminRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminRolesProviderBase AdminRolesProvider
		{
			get
			{
				if (innerSqlAdminRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminRolesProvider == null)
						{
							this.innerSqlAdminRolesProvider = new SqlAdminRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminRolesProvider SqlAdminRolesProvider
		{
			get {return AdminRolesProvider as SqlAdminRolesProvider;}
		}
		
		#endregion
		
		
		#region "GlobalLocationProvider"
			
		private SqlGlobalLocationProvider innerSqlGlobalLocationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="GlobalLocation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GlobalLocationProviderBase GlobalLocationProvider
		{
			get
			{
				if (innerSqlGlobalLocationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGlobalLocationProvider == null)
						{
							this.innerSqlGlobalLocationProvider = new SqlGlobalLocationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGlobalLocationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGlobalLocationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGlobalLocationProvider SqlGlobalLocationProvider
		{
			get {return GlobalLocationProvider as SqlGlobalLocationProvider;}
		}
		
		#endregion
		
		
		#region "KnowledgeBaseProvider"
			
		private SqlKnowledgeBaseProvider innerSqlKnowledgeBaseProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="KnowledgeBase"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KnowledgeBaseProviderBase KnowledgeBaseProvider
		{
			get
			{
				if (innerSqlKnowledgeBaseProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKnowledgeBaseProvider == null)
						{
							this.innerSqlKnowledgeBaseProvider = new SqlKnowledgeBaseProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKnowledgeBaseProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlKnowledgeBaseProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKnowledgeBaseProvider SqlKnowledgeBaseProvider
		{
			get {return KnowledgeBaseProvider as SqlKnowledgeBaseProvider;}
		}
		
		#endregion
		
		
		#region "EmailFormatsProvider"
			
		private SqlEmailFormatsProvider innerSqlEmailFormatsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmailFormats"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmailFormatsProviderBase EmailFormatsProvider
		{
			get
			{
				if (innerSqlEmailFormatsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmailFormatsProvider == null)
						{
							this.innerSqlEmailFormatsProvider = new SqlEmailFormatsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmailFormatsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEmailFormatsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmailFormatsProvider SqlEmailFormatsProvider
		{
			get {return EmailFormatsProvider as SqlEmailFormatsProvider;}
		}
		
		#endregion
		
		
		#region "GlobalAreaProvider"
			
		private SqlGlobalAreaProvider innerSqlGlobalAreaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="GlobalArea"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GlobalAreaProviderBase GlobalAreaProvider
		{
			get
			{
				if (innerSqlGlobalAreaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGlobalAreaProvider == null)
						{
							this.innerSqlGlobalAreaProvider = new SqlGlobalAreaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGlobalAreaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGlobalAreaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGlobalAreaProvider SqlGlobalAreaProvider
		{
			get {return GlobalAreaProvider as SqlGlobalAreaProvider;}
		}
		
		#endregion
		
		
		#region "ExceptionTableProvider"
			
		private SqlExceptionTableProvider innerSqlExceptionTableProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ExceptionTable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ExceptionTableProviderBase ExceptionTableProvider
		{
			get
			{
				if (innerSqlExceptionTableProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlExceptionTableProvider == null)
						{
							this.innerSqlExceptionTableProvider = new SqlExceptionTableProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlExceptionTableProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlExceptionTableProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlExceptionTableProvider SqlExceptionTableProvider
		{
			get {return ExceptionTableProvider as SqlExceptionTableProvider;}
		}
		
		#endregion
		
		
		#region "KnowledgeBaseCategoriesProvider"
			
		private SqlKnowledgeBaseCategoriesProvider innerSqlKnowledgeBaseCategoriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="KnowledgeBaseCategories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override KnowledgeBaseCategoriesProviderBase KnowledgeBaseCategoriesProvider
		{
			get
			{
				if (innerSqlKnowledgeBaseCategoriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlKnowledgeBaseCategoriesProvider == null)
						{
							this.innerSqlKnowledgeBaseCategoriesProvider = new SqlKnowledgeBaseCategoriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlKnowledgeBaseCategoriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlKnowledgeBaseCategoriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlKnowledgeBaseCategoriesProvider SqlKnowledgeBaseCategoriesProvider
		{
			get {return KnowledgeBaseCategoriesProvider as SqlKnowledgeBaseCategoriesProvider;}
		}
		
		#endregion
		
		
		#region "FileTypesProvider"
			
		private SqlFileTypesProvider innerSqlFileTypesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="FileTypes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FileTypesProviderBase FileTypesProvider
		{
			get
			{
				if (innerSqlFileTypesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFileTypesProvider == null)
						{
							this.innerSqlFileTypesProvider = new SqlFileTypesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFileTypesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFileTypesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFileTypesProvider SqlFileTypesProvider
		{
			get {return FileTypesProvider as SqlFileTypesProvider;}
		}
		
		#endregion
		
		
		#region "SalaryTypeProvider"
			
		private SqlSalaryTypeProvider innerSqlSalaryTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SalaryType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalaryTypeProviderBase SalaryTypeProvider
		{
			get
			{
				if (innerSqlSalaryTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalaryTypeProvider == null)
						{
							this.innerSqlSalaryTypeProvider = new SqlSalaryTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalaryTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSalaryTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalaryTypeProvider SqlSalaryTypeProvider
		{
			get {return SalaryTypeProvider as SqlSalaryTypeProvider;}
		}
		
		#endregion
		
		
		#region "LanguagesProvider"
			
		private SqlLanguagesProvider innerSqlLanguagesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Languages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LanguagesProviderBase LanguagesProvider
		{
			get
			{
				if (innerSqlLanguagesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLanguagesProvider == null)
						{
							this.innerSqlLanguagesProvider = new SqlLanguagesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLanguagesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLanguagesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLanguagesProvider SqlLanguagesProvider
		{
			get {return LanguagesProvider as SqlLanguagesProvider;}
		}
		
		#endregion
		
		
		#region "SchemaVersionsProvider"
			
		private SqlSchemaVersionsProvider innerSqlSchemaVersionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SchemaVersions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SchemaVersionsProviderBase SchemaVersionsProvider
		{
			get
			{
				if (innerSqlSchemaVersionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSchemaVersionsProvider == null)
						{
							this.innerSqlSchemaVersionsProvider = new SqlSchemaVersionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSchemaVersionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSchemaVersionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSchemaVersionsProvider SqlSchemaVersionsProvider
		{
			get {return SchemaVersionsProvider as SqlSchemaVersionsProvider;}
		}
		
		#endregion
		
		
		#region "SalaryProvider"
			
		private SqlSalaryProvider innerSqlSalaryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Salary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SalaryProviderBase SalaryProvider
		{
			get
			{
				if (innerSqlSalaryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSalaryProvider == null)
						{
							this.innerSqlSalaryProvider = new SqlSalaryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSalaryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSalaryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSalaryProvider SqlSalaryProvider
		{
			get {return SalaryProvider as SqlSalaryProvider;}
		}
		
		#endregion
		
		
		#region "SiteSummaryProvider"
			
		private SqlSiteSummaryProvider innerSqlSiteSummaryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteSummary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteSummaryProviderBase SiteSummaryProvider
		{
			get
			{
				if (innerSqlSiteSummaryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteSummaryProvider == null)
						{
							this.innerSqlSiteSummaryProvider = new SqlSiteSummaryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteSummaryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteSummaryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteSummaryProvider SqlSiteSummaryProvider
		{
			get {return SiteSummaryProvider as SqlSiteSummaryProvider;}
		}
		
		#endregion
		
		
		#region "LocationProvider"
			
		private SqlLocationProvider innerSqlLocationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Location"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override LocationProviderBase LocationProvider
		{
			get
			{
				if (innerSqlLocationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlLocationProvider == null)
						{
							this.innerSqlLocationProvider = new SqlLocationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlLocationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlLocationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlLocationProvider SqlLocationProvider
		{
			get {return LocationProvider as SqlLocationProvider;}
		}
		
		#endregion
		
		
		#region "NewsTypeProvider"
			
		private SqlNewsTypeProvider innerSqlNewsTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NewsType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NewsTypeProviderBase NewsTypeProvider
		{
			get
			{
				if (innerSqlNewsTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNewsTypeProvider == null)
						{
							this.innerSqlNewsTypeProvider = new SqlNewsTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNewsTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlNewsTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNewsTypeProvider SqlNewsTypeProvider
		{
			get {return NewsTypeProvider as SqlNewsTypeProvider;}
		}
		
		#endregion
		
		
		#region "MemberFileTypesProvider"
			
		private SqlMemberFileTypesProvider innerSqlMemberFileTypesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberFileTypes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberFileTypesProviderBase MemberFileTypesProvider
		{
			get
			{
				if (innerSqlMemberFileTypesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberFileTypesProvider == null)
						{
							this.innerSqlMemberFileTypesProvider = new SqlMemberFileTypesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberFileTypesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberFileTypesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberFileTypesProvider SqlMemberFileTypesProvider
		{
			get {return MemberFileTypesProvider as SqlMemberFileTypesProvider;}
		}
		
		#endregion
		
		
		#region "DynamicPageRevisionsProvider"
			
		private SqlDynamicPageRevisionsProvider innerSqlDynamicPageRevisionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicPageRevisions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicPageRevisionsProviderBase DynamicPageRevisionsProvider
		{
			get
			{
				if (innerSqlDynamicPageRevisionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicPageRevisionsProvider == null)
						{
							this.innerSqlDynamicPageRevisionsProvider = new SqlDynamicPageRevisionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicPageRevisionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicPageRevisionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicPageRevisionsProvider SqlDynamicPageRevisionsProvider
		{
			get {return DynamicPageRevisionsProvider as SqlDynamicPageRevisionsProvider;}
		}
		
		#endregion
		
		
		#region "NewsIndustryProvider"
			
		private SqlNewsIndustryProvider innerSqlNewsIndustryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NewsIndustry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NewsIndustryProviderBase NewsIndustryProvider
		{
			get
			{
				if (innerSqlNewsIndustryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNewsIndustryProvider == null)
						{
							this.innerSqlNewsIndustryProvider = new SqlNewsIndustryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNewsIndustryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlNewsIndustryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNewsIndustryProvider SqlNewsIndustryProvider
		{
			get {return NewsIndustryProvider as SqlNewsIndustryProvider;}
		}
		
		#endregion
		
		
		#region "AdminUsersProvider"
			
		private SqlAdminUsersProvider innerSqlAdminUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdminUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdminUsersProviderBase AdminUsersProvider
		{
			get
			{
				if (innerSqlAdminUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdminUsersProvider == null)
						{
							this.innerSqlAdminUsersProvider = new SqlAdminUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdminUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdminUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdminUsersProvider SqlAdminUsersProvider
		{
			get {return AdminUsersProvider as SqlAdminUsersProvider;}
		}
		
		#endregion
		
		
		#region "CurrenciesProvider"
			
		private SqlCurrenciesProvider innerSqlCurrenciesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Currencies"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CurrenciesProviderBase CurrenciesProvider
		{
			get
			{
				if (innerSqlCurrenciesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCurrenciesProvider == null)
						{
							this.innerSqlCurrenciesProvider = new SqlCurrenciesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCurrenciesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCurrenciesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCurrenciesProvider SqlCurrenciesProvider
		{
			get {return CurrenciesProvider as SqlCurrenciesProvider;}
		}
		
		#endregion
		
		
		#region "AdvertiserBusinessTypeProvider"
			
		private SqlAdvertiserBusinessTypeProvider innerSqlAdvertiserBusinessTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvertiserBusinessType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertiserBusinessTypeProviderBase AdvertiserBusinessTypeProvider
		{
			get
			{
				if (innerSqlAdvertiserBusinessTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertiserBusinessTypeProvider == null)
						{
							this.innerSqlAdvertiserBusinessTypeProvider = new SqlAdvertiserBusinessTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertiserBusinessTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertiserBusinessTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertiserBusinessTypeProvider SqlAdvertiserBusinessTypeProvider
		{
			get {return AdvertiserBusinessTypeProvider as SqlAdvertiserBusinessTypeProvider;}
		}
		
		#endregion
		
		
		#region "AdvertiserAccountTypeProvider"
			
		private SqlAdvertiserAccountTypeProvider innerSqlAdvertiserAccountTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvertiserAccountType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertiserAccountTypeProviderBase AdvertiserAccountTypeProvider
		{
			get
			{
				if (innerSqlAdvertiserAccountTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertiserAccountTypeProvider == null)
						{
							this.innerSqlAdvertiserAccountTypeProvider = new SqlAdvertiserAccountTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertiserAccountTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertiserAccountTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertiserAccountTypeProvider SqlAdvertiserAccountTypeProvider
		{
			get {return AdvertiserAccountTypeProvider as SqlAdvertiserAccountTypeProvider;}
		}
		
		#endregion
		
		
		#region "SitesProvider"
			
		private SqlSitesProvider innerSqlSitesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Sites"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SitesProviderBase SitesProvider
		{
			get
			{
				if (innerSqlSitesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSitesProvider == null)
						{
							this.innerSqlSitesProvider = new SqlSitesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSitesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSitesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSitesProvider SqlSitesProvider
		{
			get {return SitesProvider as SqlSitesProvider;}
		}
		
		#endregion
		
		
		#region "MemberQualificationProvider"
			
		private SqlMemberQualificationProvider innerSqlMemberQualificationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberQualification"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberQualificationProviderBase MemberQualificationProvider
		{
			get
			{
				if (innerSqlMemberQualificationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberQualificationProvider == null)
						{
							this.innerSqlMemberQualificationProvider = new SqlMemberQualificationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberQualificationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberQualificationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberQualificationProvider SqlMemberQualificationProvider
		{
			get {return MemberQualificationProvider as SqlMemberQualificationProvider;}
		}
		
		#endregion
		
		
		#region "AdvertiserAccountStatusProvider"
			
		private SqlAdvertiserAccountStatusProvider innerSqlAdvertiserAccountStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvertiserAccountStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertiserAccountStatusProviderBase AdvertiserAccountStatusProvider
		{
			get
			{
				if (innerSqlAdvertiserAccountStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertiserAccountStatusProvider == null)
						{
							this.innerSqlAdvertiserAccountStatusProvider = new SqlAdvertiserAccountStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertiserAccountStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertiserAccountStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertiserAccountStatusProvider SqlAdvertiserAccountStatusProvider
		{
			get {return AdvertiserAccountStatusProvider as SqlAdvertiserAccountStatusProvider;}
		}
		
		#endregion
		
		
		#region "SiteAreaProvider"
			
		private SqlSiteAreaProvider innerSqlSiteAreaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteArea"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteAreaProviderBase SiteAreaProvider
		{
			get
			{
				if (innerSqlSiteAreaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteAreaProvider == null)
						{
							this.innerSqlSiteAreaProvider = new SqlSiteAreaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteAreaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteAreaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteAreaProvider SqlSiteAreaProvider
		{
			get {return SiteAreaProvider as SqlSiteAreaProvider;}
		}
		
		#endregion
		
		
		#region "RolesProvider"
			
		private SqlRolesProvider innerSqlRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Roles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RolesProviderBase RolesProvider
		{
			get
			{
				if (innerSqlRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRolesProvider == null)
						{
							this.innerSqlRolesProvider = new SqlRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRolesProvider SqlRolesProvider
		{
			get {return RolesProvider as SqlRolesProvider;}
		}
		
		#endregion
		
		
		#region "AdvertisersProvider"
			
		private SqlAdvertisersProvider innerSqlAdvertisersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Advertisers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertisersProviderBase AdvertisersProvider
		{
			get
			{
				if (innerSqlAdvertisersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertisersProvider == null)
						{
							this.innerSqlAdvertisersProvider = new SqlAdvertisersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertisersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertisersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertisersProvider SqlAdvertisersProvider
		{
			get {return AdvertisersProvider as SqlAdvertisersProvider;}
		}
		
		#endregion
		
		
		#region "RelatedDynamicPagesProvider"
			
		private SqlRelatedDynamicPagesProvider innerSqlRelatedDynamicPagesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="RelatedDynamicPages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override RelatedDynamicPagesProviderBase RelatedDynamicPagesProvider
		{
			get
			{
				if (innerSqlRelatedDynamicPagesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlRelatedDynamicPagesProvider == null)
						{
							this.innerSqlRelatedDynamicPagesProvider = new SqlRelatedDynamicPagesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlRelatedDynamicPagesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlRelatedDynamicPagesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlRelatedDynamicPagesProvider SqlRelatedDynamicPagesProvider
		{
			get {return RelatedDynamicPagesProvider as SqlRelatedDynamicPagesProvider;}
		}
		
		#endregion
		
		
		#region "NewsCategoriesProvider"
			
		private SqlNewsCategoriesProvider innerSqlNewsCategoriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="NewsCategories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NewsCategoriesProviderBase NewsCategoriesProvider
		{
			get
			{
				if (innerSqlNewsCategoriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNewsCategoriesProvider == null)
						{
							this.innerSqlNewsCategoriesProvider = new SqlNewsCategoriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNewsCategoriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlNewsCategoriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNewsCategoriesProvider SqlNewsCategoriesProvider
		{
			get {return NewsCategoriesProvider as SqlNewsCategoriesProvider;}
		}
		
		#endregion
		
		
		#region "SiteCountriesProvider"
			
		private SqlSiteCountriesProvider innerSqlSiteCountriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteCountries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteCountriesProviderBase SiteCountriesProvider
		{
			get
			{
				if (innerSqlSiteCountriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteCountriesProvider == null)
						{
							this.innerSqlSiteCountriesProvider = new SqlSiteCountriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteCountriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteCountriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteCountriesProvider SqlSiteCountriesProvider
		{
			get {return SiteCountriesProvider as SqlSiteCountriesProvider;}
		}
		
		#endregion
		
		
		#region "MemberStatusProvider"
			
		private SqlMemberStatusProvider innerSqlMemberStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberStatusProviderBase MemberStatusProvider
		{
			get
			{
				if (innerSqlMemberStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberStatusProvider == null)
						{
							this.innerSqlMemberStatusProvider = new SqlMemberStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberStatusProvider SqlMemberStatusProvider
		{
			get {return MemberStatusProvider as SqlMemberStatusProvider;}
		}
		
		#endregion
		
		
		#region "MembersProvider"
			
		private SqlMembersProvider innerSqlMembersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Members"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MembersProviderBase MembersProvider
		{
			get
			{
				if (innerSqlMembersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMembersProvider == null)
						{
							this.innerSqlMembersProvider = new SqlMembersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMembersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMembersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMembersProvider SqlMembersProvider
		{
			get {return MembersProvider as SqlMembersProvider;}
		}
		
		#endregion
		
		
		#region "MemberWizardProvider"
			
		private SqlMemberWizardProvider innerSqlMemberWizardProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberWizard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberWizardProviderBase MemberWizardProvider
		{
			get
			{
				if (innerSqlMemberWizardProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberWizardProvider == null)
						{
							this.innerSqlMemberWizardProvider = new SqlMemberWizardProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberWizardProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberWizardProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberWizardProvider SqlMemberWizardProvider
		{
			get {return MemberWizardProvider as SqlMemberWizardProvider;}
		}
		
		#endregion
		
		
		#region "NewsProvider"
			
		private SqlNewsProvider innerSqlNewsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="News"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override NewsProviderBase NewsProvider
		{
			get
			{
				if (innerSqlNewsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlNewsProvider == null)
						{
							this.innerSqlNewsProvider = new SqlNewsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlNewsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlNewsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlNewsProvider SqlNewsProvider
		{
			get {return NewsProvider as SqlNewsProvider;}
		}
		
		#endregion
		
		
		#region "ProfessionProvider"
			
		private SqlProfessionProvider innerSqlProfessionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Profession"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ProfessionProviderBase ProfessionProvider
		{
			get
			{
				if (innerSqlProfessionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlProfessionProvider == null)
						{
							this.innerSqlProfessionProvider = new SqlProfessionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlProfessionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlProfessionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlProfessionProvider SqlProfessionProvider
		{
			get {return ProfessionProvider as SqlProfessionProvider;}
		}
		
		#endregion
		
		
		#region "MemberReferencesProvider"
			
		private SqlMemberReferencesProvider innerSqlMemberReferencesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberReferences"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberReferencesProviderBase MemberReferencesProvider
		{
			get
			{
				if (innerSqlMemberReferencesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberReferencesProvider == null)
						{
							this.innerSqlMemberReferencesProvider = new SqlMemberReferencesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberReferencesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberReferencesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberReferencesProvider SqlMemberReferencesProvider
		{
			get {return MemberReferencesProvider as SqlMemberReferencesProvider;}
		}
		
		#endregion
		
		
		#region "SiteCurrenciesProvider"
			
		private SqlSiteCurrenciesProvider innerSqlSiteCurrenciesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteCurrencies"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteCurrenciesProviderBase SiteCurrenciesProvider
		{
			get
			{
				if (innerSqlSiteCurrenciesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteCurrenciesProvider == null)
						{
							this.innerSqlSiteCurrenciesProvider = new SqlSiteCurrenciesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteCurrenciesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteCurrenciesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteCurrenciesProvider SqlSiteCurrenciesProvider
		{
			get {return SiteCurrenciesProvider as SqlSiteCurrenciesProvider;}
		}
		
		#endregion
		
		
		#region "WorkTypeProvider"
			
		private SqlWorkTypeProvider innerSqlWorkTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WorkType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WorkTypeProviderBase WorkTypeProvider
		{
			get
			{
				if (innerSqlWorkTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWorkTypeProvider == null)
						{
							this.innerSqlWorkTypeProvider = new SqlWorkTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWorkTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWorkTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWorkTypeProvider SqlWorkTypeProvider
		{
			get {return WorkTypeProvider as SqlWorkTypeProvider;}
		}
		
		#endregion
		
		
		#region "SiteWebPartsProvider"
			
		private SqlSiteWebPartsProvider innerSqlSiteWebPartsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteWebParts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteWebPartsProviderBase SiteWebPartsProvider
		{
			get
			{
				if (innerSqlSiteWebPartsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteWebPartsProvider == null)
						{
							this.innerSqlSiteWebPartsProvider = new SqlSiteWebPartsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteWebPartsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteWebPartsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteWebPartsProvider SqlSiteWebPartsProvider
		{
			get {return SiteWebPartsProvider as SqlSiteWebPartsProvider;}
		}
		
		#endregion
		
		
		#region "AdvertiserJobTemplateLogoProvider"
			
		private SqlAdvertiserJobTemplateLogoProvider innerSqlAdvertiserJobTemplateLogoProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvertiserJobTemplateLogo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertiserJobTemplateLogoProviderBase AdvertiserJobTemplateLogoProvider
		{
			get
			{
				if (innerSqlAdvertiserJobTemplateLogoProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertiserJobTemplateLogoProvider == null)
						{
							this.innerSqlAdvertiserJobTemplateLogoProvider = new SqlAdvertiserJobTemplateLogoProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertiserJobTemplateLogoProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertiserJobTemplateLogoProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertiserJobTemplateLogoProvider SqlAdvertiserJobTemplateLogoProvider
		{
			get {return AdvertiserJobTemplateLogoProvider as SqlAdvertiserJobTemplateLogoProvider;}
		}
		
		#endregion
		
		
		#region "JobTemplatesProvider"
			
		private SqlJobTemplatesProvider innerSqlJobTemplatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobTemplatesProviderBase JobTemplatesProvider
		{
			get
			{
				if (innerSqlJobTemplatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobTemplatesProvider == null)
						{
							this.innerSqlJobTemplatesProvider = new SqlJobTemplatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobTemplatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobTemplatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobTemplatesProvider SqlJobTemplatesProvider
		{
			get {return JobTemplatesProvider as SqlJobTemplatesProvider;}
		}
		
		#endregion
		
		
		#region "AdvertiserJobPricingProvider"
			
		private SqlAdvertiserJobPricingProvider innerSqlAdvertiserJobPricingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvertiserJobPricing"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertiserJobPricingProviderBase AdvertiserJobPricingProvider
		{
			get
			{
				if (innerSqlAdvertiserJobPricingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertiserJobPricingProvider == null)
						{
							this.innerSqlAdvertiserJobPricingProvider = new SqlAdvertiserJobPricingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertiserJobPricingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertiserJobPricingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertiserJobPricingProvider SqlAdvertiserJobPricingProvider
		{
			get {return AdvertiserJobPricingProvider as SqlAdvertiserJobPricingProvider;}
		}
		
		#endregion
		
		
		#region "SiteWorkTypeProvider"
			
		private SqlSiteWorkTypeProvider innerSqlSiteWorkTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteWorkType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteWorkTypeProviderBase SiteWorkTypeProvider
		{
			get
			{
				if (innerSqlSiteWorkTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteWorkTypeProvider == null)
						{
							this.innerSqlSiteWorkTypeProvider = new SqlSiteWorkTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteWorkTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteWorkTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteWorkTypeProvider SqlSiteWorkTypeProvider
		{
			get {return SiteWorkTypeProvider as SqlSiteWorkTypeProvider;}
		}
		
		#endregion
		
		
		#region "AdvertiserUsersProvider"
			
		private SqlAdvertiserUsersProvider innerSqlAdvertiserUsersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AdvertiserUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AdvertiserUsersProviderBase AdvertiserUsersProvider
		{
			get
			{
				if (innerSqlAdvertiserUsersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAdvertiserUsersProvider == null)
						{
							this.innerSqlAdvertiserUsersProvider = new SqlAdvertiserUsersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAdvertiserUsersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAdvertiserUsersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAdvertiserUsersProvider SqlAdvertiserUsersProvider
		{
			get {return AdvertiserUsersProvider as SqlAdvertiserUsersProvider;}
		}
		
		#endregion
		
		
		#region "MemberPositionsProvider"
			
		private SqlMemberPositionsProvider innerSqlMemberPositionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberPositions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberPositionsProviderBase MemberPositionsProvider
		{
			get
			{
				if (innerSqlMemberPositionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberPositionsProvider == null)
						{
							this.innerSqlMemberPositionsProvider = new SqlMemberPositionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberPositionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberPositionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberPositionsProvider SqlMemberPositionsProvider
		{
			get {return MemberPositionsProvider as SqlMemberPositionsProvider;}
		}
		
		#endregion
		
		
		#region "DynamicPageFilesProvider"
			
		private SqlDynamicPageFilesProvider innerSqlDynamicPageFilesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicPageFiles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicPageFilesProviderBase DynamicPageFilesProvider
		{
			get
			{
				if (innerSqlDynamicPageFilesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicPageFilesProvider == null)
						{
							this.innerSqlDynamicPageFilesProvider = new SqlDynamicPageFilesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicPageFilesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicPageFilesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicPageFilesProvider SqlDynamicPageFilesProvider
		{
			get {return DynamicPageFilesProvider as SqlDynamicPageFilesProvider;}
		}
		
		#endregion
		
		
		#region "ScreeningQuestionsTemplatesProvider"
			
		private SqlScreeningQuestionsTemplatesProvider innerSqlScreeningQuestionsTemplatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ScreeningQuestionsTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ScreeningQuestionsTemplatesProviderBase ScreeningQuestionsTemplatesProvider
		{
			get
			{
				if (innerSqlScreeningQuestionsTemplatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlScreeningQuestionsTemplatesProvider == null)
						{
							this.innerSqlScreeningQuestionsTemplatesProvider = new SqlScreeningQuestionsTemplatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlScreeningQuestionsTemplatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlScreeningQuestionsTemplatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlScreeningQuestionsTemplatesProvider SqlScreeningQuestionsTemplatesProvider
		{
			get {return ScreeningQuestionsTemplatesProvider as SqlScreeningQuestionsTemplatesProvider;}
		}
		
		#endregion
		
		
		#region "WidgetContainersProvider"
			
		private SqlWidgetContainersProvider innerSqlWidgetContainersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WidgetContainers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WidgetContainersProviderBase WidgetContainersProvider
		{
			get
			{
				if (innerSqlWidgetContainersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWidgetContainersProvider == null)
						{
							this.innerSqlWidgetContainersProvider = new SqlWidgetContainersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWidgetContainersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWidgetContainersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWidgetContainersProvider SqlWidgetContainersProvider
		{
			get {return WidgetContainersProvider as SqlWidgetContainersProvider;}
		}
		
		#endregion
		
		
		#region "WebServiceLogProvider"
			
		private SqlWebServiceLogProvider innerSqlWebServiceLogProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="WebServiceLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override WebServiceLogProviderBase WebServiceLogProvider
		{
			get
			{
				if (innerSqlWebServiceLogProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlWebServiceLogProvider == null)
						{
							this.innerSqlWebServiceLogProvider = new SqlWebServiceLogProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlWebServiceLogProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlWebServiceLogProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlWebServiceLogProvider SqlWebServiceLogProvider
		{
			get {return WebServiceLogProvider as SqlWebServiceLogProvider;}
		}
		
		#endregion
		
		
		#region "SiteSalaryTypeProvider"
			
		private SqlSiteSalaryTypeProvider innerSqlSiteSalaryTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteSalaryType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteSalaryTypeProviderBase SiteSalaryTypeProvider
		{
			get
			{
				if (innerSqlSiteSalaryTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteSalaryTypeProvider == null)
						{
							this.innerSqlSiteSalaryTypeProvider = new SqlSiteSalaryTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteSalaryTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteSalaryTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteSalaryTypeProvider SqlSiteSalaryTypeProvider
		{
			get {return SiteSalaryTypeProvider as SqlSiteSalaryTypeProvider;}
		}
		
		#endregion
		
		
		#region "JobsArchiveProvider"
			
		private SqlJobsArchiveProvider innerSqlJobsArchiveProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobsArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobsArchiveProviderBase JobsArchiveProvider
		{
			get
			{
				if (innerSqlJobsArchiveProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobsArchiveProvider == null)
						{
							this.innerSqlJobsArchiveProvider = new SqlJobsArchiveProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobsArchiveProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobsArchiveProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobsArchiveProvider SqlJobsArchiveProvider
		{
			get {return JobsArchiveProvider as SqlJobsArchiveProvider;}
		}
		
		#endregion
		
		
		#region "JobsProvider"
			
		private SqlJobsProvider innerSqlJobsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Jobs"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobsProviderBase JobsProvider
		{
			get
			{
				if (innerSqlJobsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobsProvider == null)
						{
							this.innerSqlJobsProvider = new SqlJobsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobsProvider SqlJobsProvider
		{
			get {return JobsProvider as SqlJobsProvider;}
		}
		
		#endregion
		
		
		#region "ScreeningQuestionsMappingsProvider"
			
		private SqlScreeningQuestionsMappingsProvider innerSqlScreeningQuestionsMappingsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ScreeningQuestionsMappings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ScreeningQuestionsMappingsProviderBase ScreeningQuestionsMappingsProvider
		{
			get
			{
				if (innerSqlScreeningQuestionsMappingsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlScreeningQuestionsMappingsProvider == null)
						{
							this.innerSqlScreeningQuestionsMappingsProvider = new SqlScreeningQuestionsMappingsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlScreeningQuestionsMappingsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlScreeningQuestionsMappingsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlScreeningQuestionsMappingsProvider SqlScreeningQuestionsMappingsProvider
		{
			get {return ScreeningQuestionsMappingsProvider as SqlScreeningQuestionsMappingsProvider;}
		}
		
		#endregion
		
		
		#region "SiteLanguagesProvider"
			
		private SqlSiteLanguagesProvider innerSqlSiteLanguagesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteLanguages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteLanguagesProviderBase SiteLanguagesProvider
		{
			get
			{
				if (innerSqlSiteLanguagesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteLanguagesProvider == null)
						{
							this.innerSqlSiteLanguagesProvider = new SqlSiteLanguagesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteLanguagesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteLanguagesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteLanguagesProvider SqlSiteLanguagesProvider
		{
			get {return SiteLanguagesProvider as SqlSiteLanguagesProvider;}
		}
		
		#endregion
		
		
		#region "SiteAdvertiserFilterProvider"
			
		private SqlSiteAdvertiserFilterProvider innerSqlSiteAdvertiserFilterProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteAdvertiserFilter"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteAdvertiserFilterProviderBase SiteAdvertiserFilterProvider
		{
			get
			{
				if (innerSqlSiteAdvertiserFilterProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteAdvertiserFilterProvider == null)
						{
							this.innerSqlSiteAdvertiserFilterProvider = new SqlSiteAdvertiserFilterProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteAdvertiserFilterProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteAdvertiserFilterProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteAdvertiserFilterProvider SqlSiteAdvertiserFilterProvider
		{
			get {return SiteAdvertiserFilterProvider as SqlSiteAdvertiserFilterProvider;}
		}
		
		#endregion
		
		
		#region "SiteCustomMappingProvider"
			
		private SqlSiteCustomMappingProvider innerSqlSiteCustomMappingProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteCustomMapping"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteCustomMappingProviderBase SiteCustomMappingProvider
		{
			get
			{
				if (innerSqlSiteCustomMappingProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteCustomMappingProvider == null)
						{
							this.innerSqlSiteCustomMappingProvider = new SqlSiteCustomMappingProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteCustomMappingProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteCustomMappingProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteCustomMappingProvider SqlSiteCustomMappingProvider
		{
			get {return SiteCustomMappingProvider as SqlSiteCustomMappingProvider;}
		}
		
		#endregion
		
		
		#region "ScreeningQuestionsProvider"
			
		private SqlScreeningQuestionsProvider innerSqlScreeningQuestionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ScreeningQuestions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ScreeningQuestionsProviderBase ScreeningQuestionsProvider
		{
			get
			{
				if (innerSqlScreeningQuestionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlScreeningQuestionsProvider == null)
						{
							this.innerSqlScreeningQuestionsProvider = new SqlScreeningQuestionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlScreeningQuestionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlScreeningQuestionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlScreeningQuestionsProvider SqlScreeningQuestionsProvider
		{
			get {return ScreeningQuestionsProvider as SqlScreeningQuestionsProvider;}
		}
		
		#endregion
		
		
		#region "SiteLocationProvider"
			
		private SqlSiteLocationProvider innerSqlSiteLocationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteLocation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteLocationProviderBase SiteLocationProvider
		{
			get
			{
				if (innerSqlSiteLocationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteLocationProvider == null)
						{
							this.innerSqlSiteLocationProvider = new SqlSiteLocationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteLocationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteLocationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteLocationProvider SqlSiteLocationProvider
		{
			get {return SiteLocationProvider as SqlSiteLocationProvider;}
		}
		
		#endregion
		
		
		#region "SiteMappingsProvider"
			
		private SqlSiteMappingsProvider innerSqlSiteMappingsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteMappings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteMappingsProviderBase SiteMappingsProvider
		{
			get
			{
				if (innerSqlSiteMappingsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteMappingsProvider == null)
						{
							this.innerSqlSiteMappingsProvider = new SqlSiteMappingsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteMappingsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteMappingsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteMappingsProvider SqlSiteMappingsProvider
		{
			get {return SiteMappingsProvider as SqlSiteMappingsProvider;}
		}
		
		#endregion
		
		
		#region "SiteRolesProvider"
			
		private SqlSiteRolesProvider innerSqlSiteRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteRolesProviderBase SiteRolesProvider
		{
			get
			{
				if (innerSqlSiteRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteRolesProvider == null)
						{
							this.innerSqlSiteRolesProvider = new SqlSiteRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteRolesProvider SqlSiteRolesProvider
		{
			get {return SiteRolesProvider as SqlSiteRolesProvider;}
		}
		
		#endregion
		
		
		#region "SiteResourcesXmlProvider"
			
		private SqlSiteResourcesXmlProvider innerSqlSiteResourcesXmlProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteResourcesXml"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteResourcesXmlProviderBase SiteResourcesXmlProvider
		{
			get
			{
				if (innerSqlSiteResourcesXmlProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteResourcesXmlProvider == null)
						{
							this.innerSqlSiteResourcesXmlProvider = new SqlSiteResourcesXmlProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteResourcesXmlProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteResourcesXmlProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteResourcesXmlProvider SqlSiteResourcesXmlProvider
		{
			get {return SiteResourcesXmlProvider as SqlSiteResourcesXmlProvider;}
		}
		
		#endregion
		
		
		#region "SiteResourcesProvider"
			
		private SqlSiteResourcesProvider innerSqlSiteResourcesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteResources"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteResourcesProviderBase SiteResourcesProvider
		{
			get
			{
				if (innerSqlSiteResourcesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteResourcesProvider == null)
						{
							this.innerSqlSiteResourcesProvider = new SqlSiteResourcesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteResourcesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteResourcesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteResourcesProvider SqlSiteResourcesProvider
		{
			get {return SiteResourcesProvider as SqlSiteResourcesProvider;}
		}
		
		#endregion
		
		
		#region "SiteProfessionProvider"
			
		private SqlSiteProfessionProvider innerSqlSiteProfessionProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="SiteProfession"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override SiteProfessionProviderBase SiteProfessionProvider
		{
			get
			{
				if (innerSqlSiteProfessionProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlSiteProfessionProvider == null)
						{
							this.innerSqlSiteProfessionProvider = new SqlSiteProfessionProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlSiteProfessionProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlSiteProfessionProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlSiteProfessionProvider SqlSiteProfessionProvider
		{
			get {return SiteProfessionProvider as SqlSiteProfessionProvider;}
		}
		
		#endregion
		
		
		#region "ScreeningQuestionsTemplateOwnersProvider"
			
		private SqlScreeningQuestionsTemplateOwnersProvider innerSqlScreeningQuestionsTemplateOwnersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ScreeningQuestionsTemplateOwners"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ScreeningQuestionsTemplateOwnersProviderBase ScreeningQuestionsTemplateOwnersProvider
		{
			get
			{
				if (innerSqlScreeningQuestionsTemplateOwnersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlScreeningQuestionsTemplateOwnersProvider == null)
						{
							this.innerSqlScreeningQuestionsTemplateOwnersProvider = new SqlScreeningQuestionsTemplateOwnersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlScreeningQuestionsTemplateOwnersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlScreeningQuestionsTemplateOwnersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlScreeningQuestionsTemplateOwnersProvider SqlScreeningQuestionsTemplateOwnersProvider
		{
			get {return ScreeningQuestionsTemplateOwnersProvider as SqlScreeningQuestionsTemplateOwnersProvider;}
		}
		
		#endregion
		
		
		#region "MemberMembershipsProvider"
			
		private SqlMemberMembershipsProvider innerSqlMemberMembershipsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberMemberships"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberMembershipsProviderBase MemberMembershipsProvider
		{
			get
			{
				if (innerSqlMemberMembershipsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberMembershipsProvider == null)
						{
							this.innerSqlMemberMembershipsProvider = new SqlMemberMembershipsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberMembershipsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberMembershipsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberMembershipsProvider SqlMemberMembershipsProvider
		{
			get {return MemberMembershipsProvider as SqlMemberMembershipsProvider;}
		}
		
		#endregion
		
		
		#region "MemberLicensesProvider"
			
		private SqlMemberLicensesProvider innerSqlMemberLicensesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberLicenses"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberLicensesProviderBase MemberLicensesProvider
		{
			get
			{
				if (innerSqlMemberLicensesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberLicensesProvider == null)
						{
							this.innerSqlMemberLicensesProvider = new SqlMemberLicensesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberLicensesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberLicensesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberLicensesProvider SqlMemberLicensesProvider
		{
			get {return MemberLicensesProvider as SqlMemberLicensesProvider;}
		}
		
		#endregion
		
		
		#region "CustomWidgetCssSelectorProvider"
			
		private SqlCustomWidgetCssSelectorProvider innerSqlCustomWidgetCssSelectorProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomWidgetCssSelector"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomWidgetCssSelectorProviderBase CustomWidgetCssSelectorProvider
		{
			get
			{
				if (innerSqlCustomWidgetCssSelectorProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomWidgetCssSelectorProvider == null)
						{
							this.innerSqlCustomWidgetCssSelectorProvider = new SqlCustomWidgetCssSelectorProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomWidgetCssSelectorProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomWidgetCssSelectorProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomWidgetCssSelectorProvider SqlCustomWidgetCssSelectorProvider
		{
			get {return CustomWidgetCssSelectorProvider as SqlCustomWidgetCssSelectorProvider;}
		}
		
		#endregion
		
		
		#region "FoldersProvider"
			
		private SqlFoldersProvider innerSqlFoldersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Folders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FoldersProviderBase FoldersProvider
		{
			get
			{
				if (innerSqlFoldersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFoldersProvider == null)
						{
							this.innerSqlFoldersProvider = new SqlFoldersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFoldersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFoldersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFoldersProvider SqlFoldersProvider
		{
			get {return FoldersProvider as SqlFoldersProvider;}
		}
		
		#endregion
		
		
		#region "CustomWidgetProvider"
			
		private SqlCustomWidgetProvider innerSqlCustomWidgetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomWidget"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomWidgetProviderBase CustomWidgetProvider
		{
			get
			{
				if (innerSqlCustomWidgetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomWidgetProvider == null)
						{
							this.innerSqlCustomWidgetProvider = new SqlCustomWidgetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomWidgetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomWidgetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomWidgetProvider SqlCustomWidgetProvider
		{
			get {return CustomWidgetProvider as SqlCustomWidgetProvider;}
		}
		
		#endregion
		
		
		#region "CustomPaymentProvider"
			
		private SqlCustomPaymentProvider innerSqlCustomPaymentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="CustomPayment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CustomPaymentProviderBase CustomPaymentProvider
		{
			get
			{
				if (innerSqlCustomPaymentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCustomPaymentProvider == null)
						{
							this.innerSqlCustomPaymentProvider = new SqlCustomPaymentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCustomPaymentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCustomPaymentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCustomPaymentProvider SqlCustomPaymentProvider
		{
			get {return CustomPaymentProvider as SqlCustomPaymentProvider;}
		}
		
		#endregion
		
		
		#region "IntegrationsProvider"
			
		private SqlIntegrationsProvider innerSqlIntegrationsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Integrations"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IntegrationsProviderBase IntegrationsProvider
		{
			get
			{
				if (innerSqlIntegrationsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIntegrationsProvider == null)
						{
							this.innerSqlIntegrationsProvider = new SqlIntegrationsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIntegrationsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlIntegrationsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIntegrationsProvider SqlIntegrationsProvider
		{
			get {return IntegrationsProvider as SqlIntegrationsProvider;}
		}
		
		#endregion
		
		
		#region "IndustryProvider"
			
		private SqlIndustryProvider innerSqlIndustryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Industry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IndustryProviderBase IndustryProvider
		{
			get
			{
				if (innerSqlIndustryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIndustryProvider == null)
						{
							this.innerSqlIndustryProvider = new SqlIndustryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIndustryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlIndustryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIndustryProvider SqlIndustryProvider
		{
			get {return IndustryProvider as SqlIndustryProvider;}
		}
		
		#endregion
		
		
		#region "FilesProvider"
			
		private SqlFilesProvider innerSqlFilesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Files"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override FilesProviderBase FilesProvider
		{
			get
			{
				if (innerSqlFilesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlFilesProvider == null)
						{
							this.innerSqlFilesProvider = new SqlFilesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlFilesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlFilesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlFilesProvider SqlFilesProvider
		{
			get {return FilesProvider as SqlFilesProvider;}
		}
		
		#endregion
		
		
		#region "IntegrationMappingsProvider"
			
		private SqlIntegrationMappingsProvider innerSqlIntegrationMappingsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="IntegrationMappings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override IntegrationMappingsProviderBase IntegrationMappingsProvider
		{
			get
			{
				if (innerSqlIntegrationMappingsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlIntegrationMappingsProvider == null)
						{
							this.innerSqlIntegrationMappingsProvider = new SqlIntegrationMappingsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlIntegrationMappingsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlIntegrationMappingsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlIntegrationMappingsProvider SqlIntegrationMappingsProvider
		{
			get {return IntegrationMappingsProvider as SqlIntegrationMappingsProvider;}
		}
		
		#endregion
		
		
		#region "DynamicPageWebPartTemplatesProvider"
			
		private SqlDynamicPageWebPartTemplatesProvider innerSqlDynamicPageWebPartTemplatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicPageWebPartTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicPageWebPartTemplatesProviderBase DynamicPageWebPartTemplatesProvider
		{
			get
			{
				if (innerSqlDynamicPageWebPartTemplatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicPageWebPartTemplatesProvider == null)
						{
							this.innerSqlDynamicPageWebPartTemplatesProvider = new SqlDynamicPageWebPartTemplatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicPageWebPartTemplatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicPageWebPartTemplatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicPageWebPartTemplatesProvider SqlDynamicPageWebPartTemplatesProvider
		{
			get {return DynamicPageWebPartTemplatesProvider as SqlDynamicPageWebPartTemplatesProvider;}
		}
		
		#endregion
		
		
		#region "DefaultResourcesProvider"
			
		private SqlDefaultResourcesProvider innerSqlDefaultResourcesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DefaultResources"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DefaultResourcesProviderBase DefaultResourcesProvider
		{
			get
			{
				if (innerSqlDefaultResourcesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDefaultResourcesProvider == null)
						{
							this.innerSqlDefaultResourcesProvider = new SqlDefaultResourcesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDefaultResourcesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDefaultResourcesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDefaultResourcesProvider SqlDefaultResourcesProvider
		{
			get {return DefaultResourcesProvider as SqlDefaultResourcesProvider;}
		}
		
		#endregion
		
		
		#region "DynamicPageWebPartTemplatesLinkProvider"
			
		private SqlDynamicPageWebPartTemplatesLinkProvider innerSqlDynamicPageWebPartTemplatesLinkProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicPageWebPartTemplatesLink"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicPageWebPartTemplatesLinkProviderBase DynamicPageWebPartTemplatesLinkProvider
		{
			get
			{
				if (innerSqlDynamicPageWebPartTemplatesLinkProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicPageWebPartTemplatesLinkProvider == null)
						{
							this.innerSqlDynamicPageWebPartTemplatesLinkProvider = new SqlDynamicPageWebPartTemplatesLinkProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicPageWebPartTemplatesLinkProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicPageWebPartTemplatesLinkProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicPageWebPartTemplatesLinkProvider SqlDynamicPageWebPartTemplatesLinkProvider
		{
			get {return DynamicPageWebPartTemplatesLinkProvider as SqlDynamicPageWebPartTemplatesLinkProvider;}
		}
		
		#endregion
		
		
		#region "DynamicpagesCustomWidgetProvider"
			
		private SqlDynamicpagesCustomWidgetProvider innerSqlDynamicpagesCustomWidgetProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicpagesCustomWidget"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicpagesCustomWidgetProviderBase DynamicpagesCustomWidgetProvider
		{
			get
			{
				if (innerSqlDynamicpagesCustomWidgetProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicpagesCustomWidgetProvider == null)
						{
							this.innerSqlDynamicpagesCustomWidgetProvider = new SqlDynamicpagesCustomWidgetProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicpagesCustomWidgetProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicpagesCustomWidgetProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicpagesCustomWidgetProvider SqlDynamicpagesCustomWidgetProvider
		{
			get {return DynamicpagesCustomWidgetProvider as SqlDynamicpagesCustomWidgetProvider;}
		}
		
		#endregion
		
		
		#region "GlobalSettingsProvider"
			
		private SqlGlobalSettingsProvider innerSqlGlobalSettingsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="GlobalSettings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override GlobalSettingsProviderBase GlobalSettingsProvider
		{
			get
			{
				if (innerSqlGlobalSettingsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlGlobalSettingsProvider == null)
						{
							this.innerSqlGlobalSettingsProvider = new SqlGlobalSettingsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlGlobalSettingsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlGlobalSettingsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlGlobalSettingsProvider SqlGlobalSettingsProvider
		{
			get {return GlobalSettingsProvider as SqlGlobalSettingsProvider;}
		}
		
		#endregion
		
		
		#region "EnquiriesProvider"
			
		private SqlEnquiriesProvider innerSqlEnquiriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Enquiries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EnquiriesProviderBase EnquiriesProvider
		{
			get
			{
				if (innerSqlEnquiriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEnquiriesProvider == null)
						{
							this.innerSqlEnquiriesProvider = new SqlEnquiriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEnquiriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEnquiriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEnquiriesProvider SqlEnquiriesProvider
		{
			get {return EnquiriesProvider as SqlEnquiriesProvider;}
		}
		
		#endregion
		
		
		#region "EducationsProvider"
			
		private SqlEducationsProvider innerSqlEducationsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Educations"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EducationsProviderBase EducationsProvider
		{
			get
			{
				if (innerSqlEducationsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEducationsProvider == null)
						{
							this.innerSqlEducationsProvider = new SqlEducationsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEducationsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEducationsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEducationsProvider SqlEducationsProvider
		{
			get {return EducationsProvider as SqlEducationsProvider;}
		}
		
		#endregion
		
		
		#region "EmailTemplatesProvider"
			
		private SqlEmailTemplatesProvider innerSqlEmailTemplatesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="EmailTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override EmailTemplatesProviderBase EmailTemplatesProvider
		{
			get
			{
				if (innerSqlEmailTemplatesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlEmailTemplatesProvider == null)
						{
							this.innerSqlEmailTemplatesProvider = new SqlEmailTemplatesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlEmailTemplatesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlEmailTemplatesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlEmailTemplatesProvider SqlEmailTemplatesProvider
		{
			get {return EmailTemplatesProvider as SqlEmailTemplatesProvider;}
		}
		
		#endregion
		
		
		#region "InvoiceOrderProvider"
			
		private SqlInvoiceOrderProvider innerSqlInvoiceOrderProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="InvoiceOrder"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoiceOrderProviderBase InvoiceOrderProvider
		{
			get
			{
				if (innerSqlInvoiceOrderProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoiceOrderProvider == null)
						{
							this.innerSqlInvoiceOrderProvider = new SqlInvoiceOrderProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoiceOrderProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInvoiceOrderProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoiceOrderProvider SqlInvoiceOrderProvider
		{
			get {return InvoiceOrderProvider as SqlInvoiceOrderProvider;}
		}
		
		#endregion
		
		
		#region "DynamicContentProvider"
			
		private SqlDynamicContentProvider innerSqlDynamicContentProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicContent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicContentProviderBase DynamicContentProvider
		{
			get
			{
				if (innerSqlDynamicContentProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicContentProvider == null)
						{
							this.innerSqlDynamicContentProvider = new SqlDynamicContentProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicContentProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicContentProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicContentProvider SqlDynamicContentProvider
		{
			get {return DynamicContentProvider as SqlDynamicContentProvider;}
		}
		
		#endregion
		
		
		#region "JobAlertsProvider"
			
		private SqlJobAlertsProvider innerSqlJobAlertsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobAlerts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobAlertsProviderBase JobAlertsProvider
		{
			get
			{
				if (innerSqlJobAlertsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobAlertsProvider == null)
						{
							this.innerSqlJobAlertsProvider = new SqlJobAlertsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobAlertsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobAlertsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobAlertsProvider SqlJobAlertsProvider
		{
			get {return JobAlertsProvider as SqlJobAlertsProvider;}
		}
		
		#endregion
		
		
		#region "JobScreeningQuestionsProvider"
			
		private SqlJobScreeningQuestionsProvider innerSqlJobScreeningQuestionsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobScreeningQuestions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobScreeningQuestionsProviderBase JobScreeningQuestionsProvider
		{
			get
			{
				if (innerSqlJobScreeningQuestionsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobScreeningQuestionsProvider == null)
						{
							this.innerSqlJobScreeningQuestionsProvider = new SqlJobScreeningQuestionsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobScreeningQuestionsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobScreeningQuestionsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobScreeningQuestionsProvider SqlJobScreeningQuestionsProvider
		{
			get {return JobScreeningQuestionsProvider as SqlJobScreeningQuestionsProvider;}
		}
		
		#endregion
		
		
		#region "JobRolesProvider"
			
		private SqlJobRolesProvider innerSqlJobRolesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobRolesProviderBase JobRolesProvider
		{
			get
			{
				if (innerSqlJobRolesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobRolesProvider == null)
						{
							this.innerSqlJobRolesProvider = new SqlJobRolesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobRolesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobRolesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobRolesProvider SqlJobRolesProvider
		{
			get {return JobRolesProvider as SqlJobRolesProvider;}
		}
		
		#endregion
		
		
		#region "CountriesProvider"
			
		private SqlCountriesProvider innerSqlCountriesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Countries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override CountriesProviderBase CountriesProvider
		{
			get
			{
				if (innerSqlCountriesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlCountriesProvider == null)
						{
							this.innerSqlCountriesProvider = new SqlCountriesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlCountriesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlCountriesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlCountriesProvider SqlCountriesProvider
		{
			get {return CountriesProvider as SqlCountriesProvider;}
		}
		
		#endregion
		
		
		#region "JobViewsProvider"
			
		private SqlJobViewsProvider innerSqlJobViewsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobViews"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobViewsProviderBase JobViewsProvider
		{
			get
			{
				if (innerSqlJobViewsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobViewsProvider == null)
						{
							this.innerSqlJobViewsProvider = new SqlJobViewsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobViewsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobViewsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobViewsProvider SqlJobViewsProvider
		{
			get {return JobViewsProvider as SqlJobViewsProvider;}
		}
		
		#endregion
		
		
		#region "ConsultantsProvider"
			
		private SqlConsultantsProvider innerSqlConsultantsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Consultants"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ConsultantsProviderBase ConsultantsProvider
		{
			get
			{
				if (innerSqlConsultantsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlConsultantsProvider == null)
						{
							this.innerSqlConsultantsProvider = new SqlConsultantsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlConsultantsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlConsultantsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlConsultantsProvider SqlConsultantsProvider
		{
			get {return ConsultantsProvider as SqlConsultantsProvider;}
		}
		
		#endregion
		
		
		#region "AvailableStatusProvider"
			
		private SqlAvailableStatusProvider innerSqlAvailableStatusProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="AvailableStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AvailableStatusProviderBase AvailableStatusProvider
		{
			get
			{
				if (innerSqlAvailableStatusProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAvailableStatusProvider == null)
						{
							this.innerSqlAvailableStatusProvider = new SqlAvailableStatusProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAvailableStatusProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAvailableStatusProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAvailableStatusProvider SqlAvailableStatusProvider
		{
			get {return AvailableStatusProvider as SqlAvailableStatusProvider;}
		}
		
		#endregion
		
		
		#region "JobItemsTypeProvider"
			
		private SqlJobItemsTypeProvider innerSqlJobItemsTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobItemsType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobItemsTypeProviderBase JobItemsTypeProvider
		{
			get
			{
				if (innerSqlJobItemsTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobItemsTypeProvider == null)
						{
							this.innerSqlJobItemsTypeProvider = new SqlJobItemsTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobItemsTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobItemsTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobItemsTypeProvider SqlJobItemsTypeProvider
		{
			get {return JobItemsTypeProvider as SqlJobItemsTypeProvider;}
		}
		
		#endregion
		
		
		#region "JobCustomXmlProvider"
			
		private SqlJobCustomXmlProvider innerSqlJobCustomXmlProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobCustomXml"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobCustomXmlProviderBase JobCustomXmlProvider
		{
			get
			{
				if (innerSqlJobCustomXmlProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobCustomXmlProvider == null)
						{
							this.innerSqlJobCustomXmlProvider = new SqlJobCustomXmlProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobCustomXmlProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobCustomXmlProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobCustomXmlProvider SqlJobCustomXmlProvider
		{
			get {return JobCustomXmlProvider as SqlJobCustomXmlProvider;}
		}
		
		#endregion
		
		
		#region "JobAreaProvider"
			
		private SqlJobAreaProvider innerSqlJobAreaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobArea"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobAreaProviderBase JobAreaProvider
		{
			get
			{
				if (innerSqlJobAreaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobAreaProvider == null)
						{
							this.innerSqlJobAreaProvider = new SqlJobAreaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobAreaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobAreaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobAreaProvider SqlJobAreaProvider
		{
			get {return JobAreaProvider as SqlJobAreaProvider;}
		}
		
		#endregion
		
		
		#region "InvoiceProvider"
			
		private SqlInvoiceProvider innerSqlInvoiceProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Invoice"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoiceProviderBase InvoiceProvider
		{
			get
			{
				if (innerSqlInvoiceProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoiceProvider == null)
						{
							this.innerSqlInvoiceProvider = new SqlInvoiceProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoiceProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInvoiceProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoiceProvider SqlInvoiceProvider
		{
			get {return InvoiceProvider as SqlInvoiceProvider;}
		}
		
		#endregion
		
		
		#region "MemberCertificateMembershipsProvider"
			
		private SqlMemberCertificateMembershipsProvider innerSqlMemberCertificateMembershipsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberCertificateMemberships"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberCertificateMembershipsProviderBase MemberCertificateMembershipsProvider
		{
			get
			{
				if (innerSqlMemberCertificateMembershipsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberCertificateMembershipsProvider == null)
						{
							this.innerSqlMemberCertificateMembershipsProvider = new SqlMemberCertificateMembershipsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberCertificateMembershipsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberCertificateMembershipsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberCertificateMembershipsProvider SqlMemberCertificateMembershipsProvider
		{
			get {return MemberCertificateMembershipsProvider as SqlMemberCertificateMembershipsProvider;}
		}
		
		#endregion
		
		
		#region "MemberFilesProvider"
			
		private SqlMemberFilesProvider innerSqlMemberFilesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberFiles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberFilesProviderBase MemberFilesProvider
		{
			get
			{
				if (innerSqlMemberFilesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberFilesProvider == null)
						{
							this.innerSqlMemberFilesProvider = new SqlMemberFilesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberFilesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberFilesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberFilesProvider SqlMemberFilesProvider
		{
			get {return MemberFilesProvider as SqlMemberFilesProvider;}
		}
		
		#endregion
		
		
		#region "DynamicPagesProvider"
			
		private SqlDynamicPagesProvider innerSqlDynamicPagesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="DynamicPages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override DynamicPagesProviderBase DynamicPagesProvider
		{
			get
			{
				if (innerSqlDynamicPagesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlDynamicPagesProvider == null)
						{
							this.innerSqlDynamicPagesProvider = new SqlDynamicPagesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlDynamicPagesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlDynamicPagesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlDynamicPagesProvider SqlDynamicPagesProvider
		{
			get {return DynamicPagesProvider as SqlDynamicPagesProvider;}
		}
		
		#endregion
		
		
		#region "MemberLanguagesProvider"
			
		private SqlMemberLanguagesProvider innerSqlMemberLanguagesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="MemberLanguages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override MemberLanguagesProviderBase MemberLanguagesProvider
		{
			get
			{
				if (innerSqlMemberLanguagesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlMemberLanguagesProvider == null)
						{
							this.innerSqlMemberLanguagesProvider = new SqlMemberLanguagesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlMemberLanguagesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlMemberLanguagesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlMemberLanguagesProvider SqlMemberLanguagesProvider
		{
			get {return MemberLanguagesProvider as SqlMemberLanguagesProvider;}
		}
		
		#endregion
		
		
		#region "AreaProvider"
			
		private SqlAreaProvider innerSqlAreaProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="Area"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override AreaProviderBase AreaProvider
		{
			get
			{
				if (innerSqlAreaProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlAreaProvider == null)
						{
							this.innerSqlAreaProvider = new SqlAreaProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlAreaProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlAreaProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlAreaProvider SqlAreaProvider
		{
			get {return AreaProvider as SqlAreaProvider;}
		}
		
		#endregion
		
		
		#region "InvoiceItemProvider"
			
		private SqlInvoiceItemProvider innerSqlInvoiceItemProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="InvoiceItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override InvoiceItemProviderBase InvoiceItemProvider
		{
			get
			{
				if (innerSqlInvoiceItemProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlInvoiceItemProvider == null)
						{
							this.innerSqlInvoiceItemProvider = new SqlInvoiceItemProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlInvoiceItemProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlInvoiceItemProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlInvoiceItemProvider SqlInvoiceItemProvider
		{
			get {return InvoiceItemProvider as SqlInvoiceItemProvider;}
		}
		
		#endregion
		
		
		#region "JobApplicationTypeProvider"
			
		private SqlJobApplicationTypeProvider innerSqlJobApplicationTypeProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobApplicationType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobApplicationTypeProviderBase JobApplicationTypeProvider
		{
			get
			{
				if (innerSqlJobApplicationTypeProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobApplicationTypeProvider == null)
						{
							this.innerSqlJobApplicationTypeProvider = new SqlJobApplicationTypeProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobApplicationTypeProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobApplicationTypeProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobApplicationTypeProvider SqlJobApplicationTypeProvider
		{
			get {return JobApplicationTypeProvider as SqlJobApplicationTypeProvider;}
		}
		
		#endregion
		
		
		#region "JobApplicationScreeningAnswersProvider"
			
		private SqlJobApplicationScreeningAnswersProvider innerSqlJobApplicationScreeningAnswersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobApplicationScreeningAnswers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobApplicationScreeningAnswersProviderBase JobApplicationScreeningAnswersProvider
		{
			get
			{
				if (innerSqlJobApplicationScreeningAnswersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobApplicationScreeningAnswersProvider == null)
						{
							this.innerSqlJobApplicationScreeningAnswersProvider = new SqlJobApplicationScreeningAnswersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobApplicationScreeningAnswersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobApplicationScreeningAnswersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobApplicationScreeningAnswersProvider SqlJobApplicationScreeningAnswersProvider
		{
			get {return JobApplicationScreeningAnswersProvider as SqlJobApplicationScreeningAnswersProvider;}
		}
		
		#endregion
		
		
		#region "JobsSavedProvider"
			
		private SqlJobsSavedProvider innerSqlJobsSavedProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobsSaved"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobsSavedProviderBase JobsSavedProvider
		{
			get
			{
				if (innerSqlJobsSavedProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobsSavedProvider == null)
						{
							this.innerSqlJobsSavedProvider = new SqlJobsSavedProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobsSavedProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobsSavedProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobsSavedProvider SqlJobsSavedProvider
		{
			get {return JobsSavedProvider as SqlJobsSavedProvider;}
		}
		
		#endregion
		
		
		#region "JobApplicationProvider"
			
		private SqlJobApplicationProvider innerSqlJobApplicationProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobApplication"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobApplicationProviderBase JobApplicationProvider
		{
			get
			{
				if (innerSqlJobApplicationProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobApplicationProvider == null)
						{
							this.innerSqlJobApplicationProvider = new SqlJobApplicationProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobApplicationProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobApplicationProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobApplicationProvider SqlJobApplicationProvider
		{
			get {return JobApplicationProvider as SqlJobApplicationProvider;}
		}
		
		#endregion
		
		
		#region "JobApplicationNotesProvider"
			
		private SqlJobApplicationNotesProvider innerSqlJobApplicationNotesProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="JobApplicationNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override JobApplicationNotesProviderBase JobApplicationNotesProvider
		{
			get
			{
				if (innerSqlJobApplicationNotesProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlJobApplicationNotesProvider == null)
						{
							this.innerSqlJobApplicationNotesProvider = new SqlJobApplicationNotesProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlJobApplicationNotesProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlJobApplicationNotesProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlJobApplicationNotesProvider SqlJobApplicationNotesProvider
		{
			get {return JobApplicationNotesProvider as SqlJobApplicationNotesProvider;}
		}
		
		#endregion
		
		
		
		#region "ViewJobsProvider"
		
		private SqlViewJobsProvider innerSqlViewJobsProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ViewJobs"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ViewJobsProviderBase ViewJobsProvider
		{
			get
			{
				if (innerSqlViewJobsProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlViewJobsProvider == null)
						{
							this.innerSqlViewJobsProvider = new SqlViewJobsProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlViewJobsProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlViewJobsProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlViewJobsProvider SqlViewJobsProvider
		{
			get {return ViewJobsProvider as SqlViewJobsProvider;}
		}
		
		#endregion
		
		
		#region "ViewJobsArchiveProvider"
		
		private SqlViewJobsArchiveProvider innerSqlViewJobsArchiveProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ViewJobsArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ViewJobsArchiveProviderBase ViewJobsArchiveProvider
		{
			get
			{
				if (innerSqlViewJobsArchiveProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlViewJobsArchiveProvider == null)
						{
							this.innerSqlViewJobsArchiveProvider = new SqlViewJobsArchiveProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlViewJobsArchiveProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlViewJobsArchiveProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlViewJobsArchiveProvider SqlViewJobsArchiveProvider
		{
			get {return ViewJobsArchiveProvider as SqlViewJobsArchiveProvider;}
		}
		
		#endregion
		
		
		#region "ViewJobSearchProvider"
		
		private SqlViewJobSearchProvider innerSqlViewJobSearchProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ViewJobSearch"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ViewJobSearchProviderBase ViewJobSearchProvider
		{
			get
			{
				if (innerSqlViewJobSearchProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlViewJobSearchProvider == null)
						{
							this.innerSqlViewJobSearchProvider = new SqlViewJobSearchProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlViewJobSearchProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlViewJobSearchProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlViewJobSearchProvider SqlViewJobSearchProvider
		{
			get {return ViewJobSearchProvider as SqlViewJobSearchProvider;}
		}
		
		#endregion
		
		
		#region "ViewSalaryProvider"
		
		private SqlViewSalaryProvider innerSqlViewSalaryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ViewSalary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ViewSalaryProviderBase ViewSalaryProvider
		{
			get
			{
				if (innerSqlViewSalaryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlViewSalaryProvider == null)
						{
							this.innerSqlViewSalaryProvider = new SqlViewSalaryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlViewSalaryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlViewSalaryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlViewSalaryProvider SqlViewSalaryProvider
		{
			get {return ViewSalaryProvider as SqlViewSalaryProvider;}
		}
		
		#endregion
		
		
		#region "ViewSiteAdvertisersProvider"
		
		private SqlViewSiteAdvertisersProvider innerSqlViewSiteAdvertisersProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ViewSiteAdvertisers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ViewSiteAdvertisersProviderBase ViewSiteAdvertisersProvider
		{
			get
			{
				if (innerSqlViewSiteAdvertisersProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlViewSiteAdvertisersProvider == null)
						{
							this.innerSqlViewSiteAdvertisersProvider = new SqlViewSiteAdvertisersProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlViewSiteAdvertisersProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlViewSiteAdvertisersProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlViewSiteAdvertisersProvider SqlViewSiteAdvertisersProvider
		{
			get {return ViewSiteAdvertisersProvider as SqlViewSiteAdvertisersProvider;}
		}
		
		#endregion
		
		
		#region "ViewSiteAreaLocationCountryProvider"
		
		private SqlViewSiteAreaLocationCountryProvider innerSqlViewSiteAreaLocationCountryProvider;

		///<summary>
		/// This class is the Data Access Logic Component for the <see cref="ViewSiteAreaLocationCountry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		/// <value></value>
		public override ViewSiteAreaLocationCountryProviderBase ViewSiteAreaLocationCountryProvider
		{
			get
			{
				if (innerSqlViewSiteAreaLocationCountryProvider == null) 
				{
					lock (syncRoot) 
					{
						if (innerSqlViewSiteAreaLocationCountryProvider == null)
						{
							this.innerSqlViewSiteAreaLocationCountryProvider = new SqlViewSiteAreaLocationCountryProvider(_connectionString, _useStoredProcedure, _providerInvariantName);
						}
					}
				}
				return innerSqlViewSiteAreaLocationCountryProvider;
			}
		}
		
		/// <summary>
		/// Gets the current <c cref="SqlViewSiteAreaLocationCountryProvider"/>.
		/// </summary>
		/// <value></value>
		public SqlViewSiteAreaLocationCountryProvider SqlViewSiteAreaLocationCountryProvider
		{
			get {return ViewSiteAreaLocationCountryProvider as SqlViewSiteAreaLocationCountryProvider;}
		}
		
		#endregion
		
		
		#region "General data access methods"

		#region "ExecuteNonQuery"
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper);	
			
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		public override void ExecuteNonQuery(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			database.ExecuteNonQuery(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteNonQuery(commandType, commandText);	
		}
		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override int ExecuteNonQuery(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteNonQuery(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataReader"
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteReader(commandWrapper);	
		}

		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteReader(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteReader(commandType, commandText);	
		}
		/// <summary>
		/// Executes the reader.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override IDataReader ExecuteReader(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteReader(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteDataSet"
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteDataSet(commandWrapper);	
		}

		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteDataSet(commandWrapper, transactionManager.TransactionObject);	
		}


		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteDataSet(commandType, commandText);	
		}
		/// <summary>
		/// Executes the data set.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override DataSet ExecuteDataSet(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteDataSet(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#region "ExecuteScalar"
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="storedProcedureName">Name of the stored procedure.</param>
		/// <param name="parameterValues">The parameter values.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, string storedProcedureName, params object[] parameterValues)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(transactionManager.TransactionObject, storedProcedureName, parameterValues);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(DbCommand commandWrapper)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);			
			return database.ExecuteScalar(commandWrapper);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandWrapper">The command wrapper.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, DbCommand commandWrapper)
		{
			Database database = transactionManager.Database;
			return database.ExecuteScalar(commandWrapper, transactionManager.TransactionObject);	
		}

		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(CommandType commandType, string commandText)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			return database.ExecuteScalar(commandType, commandText);	
		}
		/// <summary>
		/// Executes the scalar.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="commandType">Type of the command.</param>
		/// <param name="commandText">The command text.</param>
		/// <returns></returns>
		public override object ExecuteScalar(TransactionManager transactionManager, CommandType commandType, string commandText)
		{
			Database database = transactionManager.Database;			
			return database.ExecuteScalar(transactionManager.TransactionObject , commandType, commandText);				
		}
		#endregion

		#endregion


	}
}
