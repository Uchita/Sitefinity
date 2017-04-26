#region Using directives

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal.Data.Bases;

#endregion

namespace JXTPortal.Data
{
	/// <summary>
	/// This class represents the Data source repository and gives access to all the underlying providers.
	/// </summary>
	[CLSCompliant(true)]
	public sealed class DataRepository 
	{
		private static volatile NetTiersProvider _provider = null;
        private static volatile NetTiersProviderCollection _providers = null;
		private static volatile NetTiersServiceSection _section = null;
		private static volatile Configuration _config = null;
        
        private static object SyncRoot = new object();
				
		private DataRepository()
		{
		}
		
		#region Public LoadProvider
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        public static void LoadProvider(NetTiersProvider provider)
        {
			LoadProvider(provider, false);
        }
		
		/// <summary>
        /// Enables the DataRepository to programatically create and 
        /// pass in a <c>NetTiersProvider</c> during runtime.
        /// </summary>
        /// <param name="provider">An instatiated NetTiersProvider.</param>
        /// <param name="setAsDefault">ability to set any valid provider as the default provider for the DataRepository.</param>
		public static void LoadProvider(NetTiersProvider provider, bool setAsDefault)
        {
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (_providers == null)
			{
				lock(SyncRoot)
				{
            		if (_providers == null)
						_providers = new NetTiersProviderCollection();
				}
			}
			
            if (_providers[provider.Name] == null)
            {
                lock (_providers.SyncRoot)
                {
                    _providers.Add(provider);
                }
            }

            if (_provider == null || setAsDefault)
            {
                lock (SyncRoot)
                {
                    if(_provider == null || setAsDefault)
                         _provider = provider;
                }
            }
        }
		#endregion 
		
		///<summary>
		/// Configuration based provider loading, will load the providers on first call.
		///</summary>
		private static void LoadProviders()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (SyncRoot)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Load registered providers and point _provider to the default provider
                        _providers = new NetTiersProviderCollection();

                        ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
						_provider = _providers[NetTiersSection.DefaultProvider];

                        if (_provider == null)
                        {
                            throw new ProviderException("Unable to load default NetTiersProvider");
                        }
                    }
                }
            }
        }

		/// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>The provider.</value>
        public static NetTiersProvider Provider
        {
            get { LoadProviders(); return _provider; }
        }

		/// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>The providers.</value>
        public static NetTiersProviderCollection Providers
        {
            get { LoadProviders(); return _providers; }
        }
		
		/// <summary>
		/// Creates a new <c cref="TransactionManager"/> instance from the current datasource.
		/// </summary>
		/// <returns></returns>
		public TransactionManager CreateTransaction()
		{
			return _provider.CreateTransaction();
		}

		#region Configuration

		/// <summary>
		/// Gets a reference to the configured NetTiersServiceSection object.
		/// </summary>
		public static NetTiersServiceSection NetTiersSection
		{
			get
			{
				// Try to get a reference to the default <netTiersService> section
				_section = WebConfigurationManager.GetSection("netTiersService") as NetTiersServiceSection;

				if ( _section == null )
				{
					// otherwise look for section based on the assembly name
					_section = WebConfigurationManager.GetSection("JXTPortal.Data") as NetTiersServiceSection;
				}

				#region Design-Time Support

				if ( _section == null )
				{
					// lastly, try to find the specific NetTiersServiceSection for this assembly
					foreach ( ConfigurationSection temp in Configuration.Sections )
					{
						if ( temp is NetTiersServiceSection )
						{
							_section = temp as NetTiersServiceSection;
							break;
						}
					}
				}

				#endregion Design-Time Support
				
				if ( _section == null )
				{
					throw new ProviderException("Unable to load NetTiersServiceSection");
				}

				return _section;
			}
		}

		#region Design-Time Support

		/// <summary>
		/// Gets a reference to the application configuration object.
		/// </summary>
		public static Configuration Configuration
		{
			get
			{
				if ( _config == null )
				{
					// load specific config file
					if ( HttpContext.Current != null )
					{
						_config = WebConfigurationManager.OpenWebConfiguration("~");
					}
					else
					{
						String configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(".config", "").Replace(".temp", "");

						// check for design mode
						if ( configFile.ToLower().Contains("devenv.exe") )
						{
							_config = GetDesignTimeConfig();
						}
						else
						{
							_config = ConfigurationManager.OpenExeConfiguration(configFile);
						}
					}
				}

				return _config;
			}
		}

		private static Configuration GetDesignTimeConfig()
		{
			ExeConfigurationFileMap configMap = null;
			Configuration config = null;
			String path = null;

			// Get an instance of the currently running Visual Studio IDE.
			EnvDTE80.DTE2 dte = (EnvDTE80.DTE2) System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
			
			if ( dte != null )
			{
				dte.SuppressUI = true;

				EnvDTE.ProjectItem item = dte.Solution.FindProjectItem("web.config");
				if ( item != null )
				{
					if (!item.ContainingProject.FullName.ToLower().StartsWith("http:"))
               {
                  System.IO.FileInfo info = new System.IO.FileInfo(item.ContainingProject.FullName);
                  path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = path;
               }
               else
               {
                  configMap = new ExeConfigurationFileMap();
                  configMap.ExeConfigFilename = item.get_FileNames(0);
               }}

				/*
				Array projects = (Array) dte2.ActiveSolutionProjects;
				EnvDTE.Project project = (EnvDTE.Project) projects.GetValue(0);
				System.IO.FileInfo info;

				foreach ( EnvDTE.ProjectItem item in project.ProjectItems )
				{
					if ( String.Compare(item.Name, "web.config", true) == 0 )
					{
						info = new System.IO.FileInfo(project.FullName);
						path = String.Format("{0}\\{1}", info.Directory.FullName, item.Name);
						configMap = new ExeConfigurationFileMap();
						configMap.ExeConfigFilename = path;
						break;
					}
				}
				*/
			}

			config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
			return config;
		}

		#endregion Design-Time Support

		#endregion Configuration

		#region Connections

		/// <summary>
		/// Gets a reference to the ConnectionStringSettings collection.
		/// </summary>
		public static ConnectionStringSettingsCollection ConnectionStrings
		{
			get
			{
				// use default ConnectionStrings if _section has already been discovered
				if ( _config == null && _section != null )
				{
					return WebConfigurationManager.ConnectionStrings;
				}
				
				return Configuration.ConnectionStrings.ConnectionStrings;
			}
		}

		// dictionary of connection providers
		private static Dictionary<String, ConnectionProvider> _connections;

		/// <summary>
		/// Gets the dictionary of connection providers.
		/// </summary>
		public static Dictionary<String, ConnectionProvider> Connections
		{
			get
			{
				if ( _connections == null )
				{
					lock (SyncRoot)
                	{
						if (_connections == null)
						{
							_connections = new Dictionary<String, ConnectionProvider>();
		
							// add a connection provider for each configured connection string
							foreach ( ConnectionStringSettings conn in ConnectionStrings )
							{
								_connections.Add(conn.Name, new ConnectionProvider(conn.Name, conn.ConnectionString));
							}
						}
					}
				}

				return _connections;
			}
		}

		/// <summary>
		/// Adds the specified connection string to the map of connection strings.
		/// </summary>
		/// <param name="connectionStringName">The connection string name.</param>
		/// <param name="connectionString">The provider specific connection information.</param>
		public static void AddConnection(String connectionStringName, String connectionString)
		{
			lock (SyncRoot)
            {
				Connections.Remove(connectionStringName);
				ConnectionProvider connection = new ConnectionProvider(connectionStringName, connectionString);
				Connections.Add(connectionStringName, connection);
			}
		}

		/// <summary>
		/// Provides ability to switch connection string at runtime.
		/// </summary>
		public sealed class ConnectionProvider
		{
			private NetTiersProvider _provider;
			private NetTiersProviderCollection _providers;
			private String _connectionStringName;
			private String _connectionString;


			/// <summary>
			/// Initializes a new instance of the ConnectionProvider class.
			/// </summary>
			/// <param name="connectionStringName">The connection string name.</param>
			/// <param name="connectionString">The provider specific connection information.</param>
			public ConnectionProvider(String connectionStringName, String connectionString)
			{
				_connectionString = connectionString;
				_connectionStringName = connectionStringName;
			}

			/// <summary>
			/// Gets the provider.
			/// </summary>
			public NetTiersProvider Provider
			{
				get { LoadProviders(); return _provider; }
			}

			/// <summary>
			/// Gets the provider collection.
			/// </summary>
			public NetTiersProviderCollection Providers
			{
				get { LoadProviders(); return _providers; }
			}

			/// <summary>
			/// Instantiates the configured providers based on the supplied connection string.
			/// </summary>
			private void LoadProviders()
			{
				DataRepository.LoadProviders();

				// Avoid claiming lock if providers are already loaded
				if ( _providers == null )
				{
					lock ( SyncRoot )
					{
						// Do this again to make sure _provider is still null
						if ( _providers == null )
						{
							// apply connection information to each provider
							for ( int i = 0; i < NetTiersSection.Providers.Count; i++ )
							{
								NetTiersSection.Providers[i].Parameters["connectionStringName"] = _connectionStringName;
								// remove previous connection string, if any
								NetTiersSection.Providers[i].Parameters.Remove("connectionString");

								if ( !String.IsNullOrEmpty(_connectionString) )
								{
									NetTiersSection.Providers[i].Parameters["connectionString"] = _connectionString;
								}
							}

							// Load registered providers and point _provider to the default provider
							_providers = new NetTiersProviderCollection();

							ProvidersHelper.InstantiateProviders(NetTiersSection.Providers, _providers, typeof(NetTiersProvider));
							_provider = _providers[NetTiersSection.DefaultProvider];
						}
					}
				}
			}
		}

		#endregion Connections

		#region Static properties
		
		#region JobCustomQuestionnaireProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobCustomQuestionnaire"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobCustomQuestionnaireProviderBase JobCustomQuestionnaireProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobCustomQuestionnaireProvider;
			}
		}
		
		#endregion
		
		#region SiteWebPartTypesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteWebPartTypes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteWebPartTypesProviderBase SiteWebPartTypesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteWebPartTypesProvider;
			}
		}
		
		#endregion
		
		#region AdminRolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminRolesProviderBase AdminRolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminRolesProvider;
			}
		}
		
		#endregion
		
		#region GlobalLocationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="GlobalLocation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GlobalLocationProviderBase GlobalLocationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GlobalLocationProvider;
			}
		}
		
		#endregion
		
		#region KnowledgeBaseProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="KnowledgeBase"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KnowledgeBaseProviderBase KnowledgeBaseProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KnowledgeBaseProvider;
			}
		}
		
		#endregion
		
		#region EmailFormatsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmailFormats"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmailFormatsProviderBase EmailFormatsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmailFormatsProvider;
			}
		}
		
		#endregion
		
		#region GlobalAreaProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="GlobalArea"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GlobalAreaProviderBase GlobalAreaProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GlobalAreaProvider;
			}
		}
		
		#endregion
		
		#region ExceptionTableProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ExceptionTable"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ExceptionTableProviderBase ExceptionTableProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ExceptionTableProvider;
			}
		}
		
		#endregion
		
		#region KnowledgeBaseCategoriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="KnowledgeBaseCategories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static KnowledgeBaseCategoriesProviderBase KnowledgeBaseCategoriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.KnowledgeBaseCategoriesProvider;
			}
		}
		
		#endregion
		
		#region FileTypesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="FileTypes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FileTypesProviderBase FileTypesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FileTypesProvider;
			}
		}
		
		#endregion
		
		#region SalaryTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SalaryType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalaryTypeProviderBase SalaryTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalaryTypeProvider;
			}
		}
		
		#endregion
		
		#region LanguagesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Languages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LanguagesProviderBase LanguagesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LanguagesProvider;
			}
		}
		
		#endregion
		
		#region SchemaVersionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SchemaVersions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SchemaVersionsProviderBase SchemaVersionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SchemaVersionsProvider;
			}
		}
		
		#endregion
		
		#region SalaryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Salary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SalaryProviderBase SalaryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SalaryProvider;
			}
		}
		
		#endregion
		
		#region SiteSummaryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteSummary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteSummaryProviderBase SiteSummaryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteSummaryProvider;
			}
		}
		
		#endregion
		
		#region LocationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Location"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static LocationProviderBase LocationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.LocationProvider;
			}
		}
		
		#endregion
		
		#region NewsTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="NewsType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NewsTypeProviderBase NewsTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NewsTypeProvider;
			}
		}
		
		#endregion
		
		#region MemberFileTypesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberFileTypes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberFileTypesProviderBase MemberFileTypesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberFileTypesProvider;
			}
		}
		
		#endregion
		
		#region DynamicPageRevisionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicPageRevisions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicPageRevisionsProviderBase DynamicPageRevisionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicPageRevisionsProvider;
			}
		}
		
		#endregion
		
		#region NewsIndustryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="NewsIndustry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NewsIndustryProviderBase NewsIndustryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NewsIndustryProvider;
			}
		}
		
		#endregion
		
		#region AdminUsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdminUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdminUsersProviderBase AdminUsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdminUsersProvider;
			}
		}
		
		#endregion
		
		#region CurrenciesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Currencies"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CurrenciesProviderBase CurrenciesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CurrenciesProvider;
			}
		}
		
		#endregion
		
		#region AdvertiserBusinessTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvertiserBusinessType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertiserBusinessTypeProviderBase AdvertiserBusinessTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertiserBusinessTypeProvider;
			}
		}
		
		#endregion
		
		#region AdvertiserAccountTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvertiserAccountType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertiserAccountTypeProviderBase AdvertiserAccountTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertiserAccountTypeProvider;
			}
		}
		
		#endregion
		
		#region SitesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Sites"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SitesProviderBase SitesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SitesProvider;
			}
		}
		
		#endregion
		
		#region MemberQualificationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberQualification"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberQualificationProviderBase MemberQualificationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberQualificationProvider;
			}
		}
		
		#endregion
		
		#region AdvertiserAccountStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvertiserAccountStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertiserAccountStatusProviderBase AdvertiserAccountStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertiserAccountStatusProvider;
			}
		}
		
		#endregion
		
		#region SiteAreaProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteArea"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteAreaProviderBase SiteAreaProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteAreaProvider;
			}
		}
		
		#endregion
		
		#region RolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Roles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RolesProviderBase RolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RolesProvider;
			}
		}
		
		#endregion
		
		#region AdvertisersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Advertisers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertisersProviderBase AdvertisersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertisersProvider;
			}
		}
		
		#endregion
		
		#region RelatedDynamicPagesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="RelatedDynamicPages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static RelatedDynamicPagesProviderBase RelatedDynamicPagesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.RelatedDynamicPagesProvider;
			}
		}
		
		#endregion
		
		#region NewsCategoriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="NewsCategories"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NewsCategoriesProviderBase NewsCategoriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NewsCategoriesProvider;
			}
		}
		
		#endregion
		
		#region SiteCountriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteCountries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteCountriesProviderBase SiteCountriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteCountriesProvider;
			}
		}
		
		#endregion
		
		#region MemberStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberStatusProviderBase MemberStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberStatusProvider;
			}
		}
		
		#endregion
		
		#region MembersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Members"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MembersProviderBase MembersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MembersProvider;
			}
		}
		
		#endregion
		
		#region MemberWizardProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberWizard"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberWizardProviderBase MemberWizardProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberWizardProvider;
			}
		}
		
		#endregion
		
		#region NewsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="News"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static NewsProviderBase NewsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.NewsProvider;
			}
		}
		
		#endregion
		
		#region ProfessionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Profession"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ProfessionProviderBase ProfessionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ProfessionProvider;
			}
		}
		
		#endregion
		
		#region MemberReferencesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberReferences"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberReferencesProviderBase MemberReferencesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberReferencesProvider;
			}
		}
		
		#endregion
		
		#region SiteCurrenciesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteCurrencies"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteCurrenciesProviderBase SiteCurrenciesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteCurrenciesProvider;
			}
		}
		
		#endregion
		
		#region WorkTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WorkType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WorkTypeProviderBase WorkTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WorkTypeProvider;
			}
		}
		
		#endregion
		
		#region SiteWebPartsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteWebParts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteWebPartsProviderBase SiteWebPartsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteWebPartsProvider;
			}
		}
		
		#endregion
		
		#region AdvertiserJobTemplateLogoProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvertiserJobTemplateLogo"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertiserJobTemplateLogoProviderBase AdvertiserJobTemplateLogoProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertiserJobTemplateLogoProvider;
			}
		}
		
		#endregion
		
		#region JobTemplatesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobTemplatesProviderBase JobTemplatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobTemplatesProvider;
			}
		}
		
		#endregion
		
		#region AdvertiserJobPricingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvertiserJobPricing"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertiserJobPricingProviderBase AdvertiserJobPricingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertiserJobPricingProvider;
			}
		}
		
		#endregion
		
		#region SiteWorkTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteWorkType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteWorkTypeProviderBase SiteWorkTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteWorkTypeProvider;
			}
		}
		
		#endregion
		
		#region AdvertiserUsersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AdvertiserUsers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AdvertiserUsersProviderBase AdvertiserUsersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AdvertiserUsersProvider;
			}
		}
		
		#endregion
		
		#region MemberPositionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberPositions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberPositionsProviderBase MemberPositionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberPositionsProvider;
			}
		}
		
		#endregion
		
		#region DynamicPageFilesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicPageFiles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicPageFilesProviderBase DynamicPageFilesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicPageFilesProvider;
			}
		}
		
		#endregion
		
		#region ScreeningQuestionsTemplatesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ScreeningQuestionsTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ScreeningQuestionsTemplatesProviderBase ScreeningQuestionsTemplatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ScreeningQuestionsTemplatesProvider;
			}
		}
		
		#endregion
		
		#region WidgetContainersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WidgetContainers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WidgetContainersProviderBase WidgetContainersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WidgetContainersProvider;
			}
		}
		
		#endregion
		
		#region WebServiceLogProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="WebServiceLog"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static WebServiceLogProviderBase WebServiceLogProvider
		{
			get 
			{
				LoadProviders();
				return _provider.WebServiceLogProvider;
			}
		}
		
		#endregion
		
		#region SiteSalaryTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteSalaryType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteSalaryTypeProviderBase SiteSalaryTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteSalaryTypeProvider;
			}
		}
		
		#endregion
		
		#region JobsArchiveProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobsArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobsArchiveProviderBase JobsArchiveProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobsArchiveProvider;
			}
		}
		
		#endregion
		
		#region JobsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Jobs"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobsProviderBase JobsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobsProvider;
			}
		}
		
		#endregion
		
		#region ScreeningQuestionsMappingsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ScreeningQuestionsMappings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ScreeningQuestionsMappingsProviderBase ScreeningQuestionsMappingsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ScreeningQuestionsMappingsProvider;
			}
		}
		
		#endregion
		
		#region SiteLanguagesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteLanguages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteLanguagesProviderBase SiteLanguagesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteLanguagesProvider;
			}
		}
		
		#endregion
		
		#region SiteAdvertiserFilterProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteAdvertiserFilter"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteAdvertiserFilterProviderBase SiteAdvertiserFilterProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteAdvertiserFilterProvider;
			}
		}
		
		#endregion
		
		#region SiteCustomMappingProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteCustomMapping"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteCustomMappingProviderBase SiteCustomMappingProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteCustomMappingProvider;
			}
		}
		
		#endregion
		
		#region ScreeningQuestionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ScreeningQuestions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ScreeningQuestionsProviderBase ScreeningQuestionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ScreeningQuestionsProvider;
			}
		}
		
		#endregion
		
		#region SiteLocationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteLocation"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteLocationProviderBase SiteLocationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteLocationProvider;
			}
		}
		
		#endregion
		
		#region SiteMappingsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteMappings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteMappingsProviderBase SiteMappingsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteMappingsProvider;
			}
		}
		
		#endregion
		
		#region SiteRolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteRolesProviderBase SiteRolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteRolesProvider;
			}
		}
		
		#endregion
		
		#region SiteResourcesXmlProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteResourcesXml"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteResourcesXmlProviderBase SiteResourcesXmlProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteResourcesXmlProvider;
			}
		}
		
		#endregion
		
		#region SiteResourcesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteResources"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteResourcesProviderBase SiteResourcesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteResourcesProvider;
			}
		}
		
		#endregion
		
		#region SiteProfessionProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="SiteProfession"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static SiteProfessionProviderBase SiteProfessionProvider
		{
			get 
			{
				LoadProviders();
				return _provider.SiteProfessionProvider;
			}
		}
		
		#endregion
		
		#region ScreeningQuestionsTemplateOwnersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ScreeningQuestionsTemplateOwners"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ScreeningQuestionsTemplateOwnersProviderBase ScreeningQuestionsTemplateOwnersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ScreeningQuestionsTemplateOwnersProvider;
			}
		}
		
		#endregion
		
		#region MemberMembershipsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberMemberships"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberMembershipsProviderBase MemberMembershipsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberMembershipsProvider;
			}
		}
		
		#endregion
		
		#region MemberLicensesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberLicenses"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberLicensesProviderBase MemberLicensesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberLicensesProvider;
			}
		}
		
		#endregion
		
		#region CustomWidgetCssSelectorProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomWidgetCssSelector"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomWidgetCssSelectorProviderBase CustomWidgetCssSelectorProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomWidgetCssSelectorProvider;
			}
		}
		
		#endregion
		
		#region FoldersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Folders"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FoldersProviderBase FoldersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FoldersProvider;
			}
		}
		
		#endregion
		
		#region CustomWidgetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomWidget"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomWidgetProviderBase CustomWidgetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomWidgetProvider;
			}
		}
		
		#endregion
		
		#region CustomPaymentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="CustomPayment"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CustomPaymentProviderBase CustomPaymentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CustomPaymentProvider;
			}
		}
		
		#endregion
		
		#region IntegrationsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Integrations"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IntegrationsProviderBase IntegrationsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IntegrationsProvider;
			}
		}
		
		#endregion
		
		#region IndustryProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Industry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IndustryProviderBase IndustryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IndustryProvider;
			}
		}
		
		#endregion
		
		#region FilesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Files"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static FilesProviderBase FilesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.FilesProvider;
			}
		}
		
		#endregion
		
		#region IntegrationMappingsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="IntegrationMappings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static IntegrationMappingsProviderBase IntegrationMappingsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.IntegrationMappingsProvider;
			}
		}
		
		#endregion
		
		#region DynamicPageWebPartTemplatesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicPageWebPartTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicPageWebPartTemplatesProviderBase DynamicPageWebPartTemplatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicPageWebPartTemplatesProvider;
			}
		}
		
		#endregion
		
		#region DefaultResourcesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DefaultResources"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DefaultResourcesProviderBase DefaultResourcesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DefaultResourcesProvider;
			}
		}
		
		#endregion
		
		#region DynamicPageWebPartTemplatesLinkProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicPageWebPartTemplatesLink"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicPageWebPartTemplatesLinkProviderBase DynamicPageWebPartTemplatesLinkProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicPageWebPartTemplatesLinkProvider;
			}
		}
		
		#endregion
		
		#region DynamicpagesCustomWidgetProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicpagesCustomWidget"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicpagesCustomWidgetProviderBase DynamicpagesCustomWidgetProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicpagesCustomWidgetProvider;
			}
		}
		
		#endregion
		
		#region GlobalSettingsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="GlobalSettings"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static GlobalSettingsProviderBase GlobalSettingsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.GlobalSettingsProvider;
			}
		}
		
		#endregion
		
		#region EnquiriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Enquiries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EnquiriesProviderBase EnquiriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EnquiriesProvider;
			}
		}
		
		#endregion
		
		#region EducationsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Educations"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EducationsProviderBase EducationsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EducationsProvider;
			}
		}
		
		#endregion
		
		#region EmailTemplatesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="EmailTemplates"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static EmailTemplatesProviderBase EmailTemplatesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.EmailTemplatesProvider;
			}
		}
		
		#endregion
		
		#region InvoiceOrderProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="InvoiceOrder"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoiceOrderProviderBase InvoiceOrderProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoiceOrderProvider;
			}
		}
		
		#endregion
		
		#region DynamicContentProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicContent"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicContentProviderBase DynamicContentProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicContentProvider;
			}
		}
		
		#endregion
		
		#region JobAlertsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobAlerts"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobAlertsProviderBase JobAlertsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobAlertsProvider;
			}
		}
		
		#endregion
		
		#region JobScreeningQuestionsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobScreeningQuestions"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobScreeningQuestionsProviderBase JobScreeningQuestionsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobScreeningQuestionsProvider;
			}
		}
		
		#endregion
		
		#region JobRolesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobRoles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobRolesProviderBase JobRolesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobRolesProvider;
			}
		}
		
		#endregion
		
		#region CountriesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Countries"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static CountriesProviderBase CountriesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.CountriesProvider;
			}
		}
		
		#endregion
		
		#region JobViewsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobViews"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobViewsProviderBase JobViewsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobViewsProvider;
			}
		}
		
		#endregion
		
		#region ConsultantsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Consultants"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ConsultantsProviderBase ConsultantsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ConsultantsProvider;
			}
		}
		
		#endregion
		
		#region AvailableStatusProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="AvailableStatus"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AvailableStatusProviderBase AvailableStatusProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AvailableStatusProvider;
			}
		}
		
		#endregion
		
		#region JobItemsTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobItemsType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobItemsTypeProviderBase JobItemsTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobItemsTypeProvider;
			}
		}
		
		#endregion
		
		#region JobCustomXmlProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobCustomXml"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobCustomXmlProviderBase JobCustomXmlProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobCustomXmlProvider;
			}
		}
		
		#endregion
		
		#region JobAreaProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobArea"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobAreaProviderBase JobAreaProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobAreaProvider;
			}
		}
		
		#endregion
		
		#region InvoiceProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Invoice"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoiceProviderBase InvoiceProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoiceProvider;
			}
		}
		
		#endregion
		
		#region MemberCertificateMembershipsProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberCertificateMemberships"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberCertificateMembershipsProviderBase MemberCertificateMembershipsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberCertificateMembershipsProvider;
			}
		}
		
		#endregion
		
		#region MemberFilesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberFiles"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberFilesProviderBase MemberFilesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberFilesProvider;
			}
		}
		
		#endregion
		
		#region DynamicPagesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="DynamicPages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static DynamicPagesProviderBase DynamicPagesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.DynamicPagesProvider;
			}
		}
		
		#endregion
		
		#region MemberLanguagesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="MemberLanguages"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static MemberLanguagesProviderBase MemberLanguagesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.MemberLanguagesProvider;
			}
		}
		
		#endregion
		
		#region AreaProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="Area"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static AreaProviderBase AreaProvider
		{
			get 
			{
				LoadProviders();
				return _provider.AreaProvider;
			}
		}
		
		#endregion
		
		#region InvoiceItemProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="InvoiceItem"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static InvoiceItemProviderBase InvoiceItemProvider
		{
			get 
			{
				LoadProviders();
				return _provider.InvoiceItemProvider;
			}
		}
		
		#endregion
		
		#region JobApplicationTypeProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobApplicationType"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobApplicationTypeProviderBase JobApplicationTypeProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobApplicationTypeProvider;
			}
		}
		
		#endregion
		
		#region JobApplicationScreeningAnswersProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobApplicationScreeningAnswers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobApplicationScreeningAnswersProviderBase JobApplicationScreeningAnswersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobApplicationScreeningAnswersProvider;
			}
		}
		
		#endregion
		
		#region JobsSavedProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobsSaved"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobsSavedProviderBase JobsSavedProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobsSavedProvider;
			}
		}
		
		#endregion
		
		#region JobApplicationProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobApplication"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobApplicationProviderBase JobApplicationProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobApplicationProvider;
			}
		}
		
		#endregion
		
		#region JobApplicationNotesProvider

		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="JobApplicationNotes"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static JobApplicationNotesProviderBase JobApplicationNotesProvider
		{
			get 
			{
				LoadProviders();
				return _provider.JobApplicationNotesProvider;
			}
		}
		
		#endregion
		
		
		#region ViewJobsProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ViewJobs"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ViewJobsProviderBase ViewJobsProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ViewJobsProvider;
			}
		}
		
		#endregion
		
		#region ViewJobsArchiveProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ViewJobsArchive"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ViewJobsArchiveProviderBase ViewJobsArchiveProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ViewJobsArchiveProvider;
			}
		}
		
		#endregion
		
		#region ViewJobSearchProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ViewJobSearch"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ViewJobSearchProviderBase ViewJobSearchProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ViewJobSearchProvider;
			}
		}
		
		#endregion
		
		#region ViewSalaryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ViewSalary"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ViewSalaryProviderBase ViewSalaryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ViewSalaryProvider;
			}
		}
		
		#endregion
		
		#region ViewSiteAdvertisersProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ViewSiteAdvertisers"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ViewSiteAdvertisersProviderBase ViewSiteAdvertisersProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ViewSiteAdvertisersProvider;
			}
		}
		
		#endregion
		
		#region ViewSiteAreaLocationCountryProvider
		
		///<summary>
		/// Gets the current instance of the Data Access Logic Component for the <see cref="ViewSiteAreaLocationCountry"/> business entity.
		/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
		///</summary>
		public static ViewSiteAreaLocationCountryProviderBase ViewSiteAreaLocationCountryProvider
		{
			get 
			{
				LoadProviders();
				return _provider.ViewSiteAreaLocationCountryProvider;
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#region Query/Filters
		
	#region JobCustomQuestionnaireFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomQuestionnaire"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomQuestionnaireFilters : JobCustomQuestionnaireFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireFilters class.
		/// </summary>
		public JobCustomQuestionnaireFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomQuestionnaireFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomQuestionnaireFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomQuestionnaireFilters
	
	#region JobCustomQuestionnaireQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobCustomQuestionnaireParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobCustomQuestionnaire"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomQuestionnaireQuery : JobCustomQuestionnaireParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireQuery class.
		/// </summary>
		public JobCustomQuestionnaireQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomQuestionnaireQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomQuestionnaireQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomQuestionnaireQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomQuestionnaireQuery
		
	#region SiteWebPartTypesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesFilters : SiteWebPartTypesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesFilters class.
		/// </summary>
		public SiteWebPartTypesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartTypesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartTypesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartTypesFilters
	
	#region SiteWebPartTypesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteWebPartTypesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesQuery : SiteWebPartTypesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesQuery class.
		/// </summary>
		public SiteWebPartTypesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartTypesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartTypesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartTypesQuery
		
	#region AdminRolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesFilters : AdminRolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesFilters class.
		/// </summary>
		public AdminRolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminRolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminRolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminRolesFilters
	
	#region AdminRolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminRolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesQuery : AdminRolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesQuery class.
		/// </summary>
		public AdminRolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminRolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminRolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminRolesQuery
		
	#region GlobalLocationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalLocationFilters : GlobalLocationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalLocationFilters class.
		/// </summary>
		public GlobalLocationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalLocationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalLocationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalLocationFilters
	
	#region GlobalLocationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GlobalLocationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="GlobalLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalLocationQuery : GlobalLocationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalLocationQuery class.
		/// </summary>
		public GlobalLocationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalLocationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalLocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalLocationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalLocationQuery
		
	#region KnowledgeBaseFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseFilters : KnowledgeBaseFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseFilters class.
		/// </summary>
		public KnowledgeBaseFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseFilters
	
	#region KnowledgeBaseQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KnowledgeBaseParameterBuilder"/> class
	/// that is used exclusively with a <see cref="KnowledgeBase"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseQuery : KnowledgeBaseParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseQuery class.
		/// </summary>
		public KnowledgeBaseQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseQuery
		
	#region EmailFormatsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsFilters : EmailFormatsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsFilters class.
		/// </summary>
		public EmailFormatsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailFormatsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailFormatsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailFormatsFilters
	
	#region EmailFormatsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmailFormatsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsQuery : EmailFormatsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsQuery class.
		/// </summary>
		public EmailFormatsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailFormatsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailFormatsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailFormatsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailFormatsQuery
		
	#region GlobalAreaFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalAreaFilters : GlobalAreaFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalAreaFilters class.
		/// </summary>
		public GlobalAreaFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalAreaFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalAreaFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalAreaFilters
	
	#region GlobalAreaQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GlobalAreaParameterBuilder"/> class
	/// that is used exclusively with a <see cref="GlobalArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalAreaQuery : GlobalAreaParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalAreaQuery class.
		/// </summary>
		public GlobalAreaQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalAreaQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalAreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalAreaQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalAreaQuery
		
	#region ExceptionTableFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableFilters : ExceptionTableFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableFilters class.
		/// </summary>
		public ExceptionTableFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExceptionTableFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExceptionTableFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExceptionTableFilters
	
	#region ExceptionTableQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ExceptionTableParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ExceptionTable"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ExceptionTableQuery : ExceptionTableParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ExceptionTableQuery class.
		/// </summary>
		public ExceptionTableQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ExceptionTableQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ExceptionTableQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ExceptionTableQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ExceptionTableQuery
		
	#region KnowledgeBaseCategoriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="KnowledgeBaseCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseCategoriesFilters : KnowledgeBaseCategoriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesFilters class.
		/// </summary>
		public KnowledgeBaseCategoriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseCategoriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseCategoriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseCategoriesFilters
	
	#region KnowledgeBaseCategoriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="KnowledgeBaseCategoriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="KnowledgeBaseCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class KnowledgeBaseCategoriesQuery : KnowledgeBaseCategoriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesQuery class.
		/// </summary>
		public KnowledgeBaseCategoriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public KnowledgeBaseCategoriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the KnowledgeBaseCategoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public KnowledgeBaseCategoriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion KnowledgeBaseCategoriesQuery
		
	#region FileTypesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesFilters : FileTypesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesFilters class.
		/// </summary>
		public FileTypesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FileTypesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FileTypesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FileTypesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FileTypesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FileTypesFilters
	
	#region FileTypesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FileTypesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesQuery : FileTypesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesQuery class.
		/// </summary>
		public FileTypesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FileTypesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FileTypesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FileTypesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FileTypesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FileTypesQuery
		
	#region SalaryTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeFilters : SalaryTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeFilters class.
		/// </summary>
		public SalaryTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryTypeFilters
	
	#region SalaryTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalaryTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryTypeQuery : SalaryTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryTypeQuery class.
		/// </summary>
		public SalaryTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryTypeQuery
		
	#region LanguagesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesFilters : LanguagesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesFilters class.
		/// </summary>
		public LanguagesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguagesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguagesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguagesFilters
	
	#region LanguagesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LanguagesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesQuery : LanguagesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesQuery class.
		/// </summary>
		public LanguagesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LanguagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LanguagesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LanguagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LanguagesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LanguagesQuery
		
	#region SchemaVersionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchemaVersionsFilters : SchemaVersionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsFilters class.
		/// </summary>
		public SchemaVersionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchemaVersionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchemaVersionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchemaVersionsFilters
	
	#region SchemaVersionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SchemaVersionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SchemaVersions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SchemaVersionsQuery : SchemaVersionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsQuery class.
		/// </summary>
		public SchemaVersionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SchemaVersionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SchemaVersionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SchemaVersionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SchemaVersionsQuery
		
	#region SalaryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Salary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryFilters : SalaryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryFilters class.
		/// </summary>
		public SalaryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryFilters
	
	#region SalaryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SalaryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Salary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SalaryQuery : SalaryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SalaryQuery class.
		/// </summary>
		public SalaryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SalaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SalaryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SalaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SalaryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SalaryQuery
		
	#region SiteSummaryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSummaryFilters : SiteSummaryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSummaryFilters class.
		/// </summary>
		public SiteSummaryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSummaryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSummaryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSummaryFilters
	
	#region SiteSummaryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteSummaryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteSummary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSummaryQuery : SiteSummaryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSummaryQuery class.
		/// </summary>
		public SiteSummaryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSummaryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSummaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSummaryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSummaryQuery
		
	#region LocationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationFilters : LocationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationFilters class.
		/// </summary>
		public LocationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the LocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LocationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LocationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LocationFilters
	
	#region LocationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="LocationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Location"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LocationQuery : LocationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LocationQuery class.
		/// </summary>
		public LocationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the LocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public LocationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the LocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public LocationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion LocationQuery
		
	#region NewsTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsTypeFilters : NewsTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsTypeFilters class.
		/// </summary>
		public NewsTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsTypeFilters
	
	#region NewsTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NewsTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="NewsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsTypeQuery : NewsTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsTypeQuery class.
		/// </summary>
		public NewsTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsTypeQuery
		
	#region MemberFileTypesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesFilters : MemberFileTypesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesFilters class.
		/// </summary>
		public MemberFileTypesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFileTypesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFileTypesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFileTypesFilters
	
	#region MemberFileTypesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberFileTypesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesQuery : MemberFileTypesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesQuery class.
		/// </summary>
		public MemberFileTypesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFileTypesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFileTypesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFileTypesQuery
		
	#region DynamicPageRevisionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageRevisions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageRevisionsFilters : DynamicPageRevisionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsFilters class.
		/// </summary>
		public DynamicPageRevisionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageRevisionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageRevisionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageRevisionsFilters
	
	#region DynamicPageRevisionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicPageRevisionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicPageRevisions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageRevisionsQuery : DynamicPageRevisionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsQuery class.
		/// </summary>
		public DynamicPageRevisionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageRevisionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageRevisionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageRevisionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageRevisionsQuery
		
	#region NewsIndustryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsIndustry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsIndustryFilters : NewsIndustryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsIndustryFilters class.
		/// </summary>
		public NewsIndustryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsIndustryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsIndustryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsIndustryFilters
	
	#region NewsIndustryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NewsIndustryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="NewsIndustry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsIndustryQuery : NewsIndustryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsIndustryQuery class.
		/// </summary>
		public NewsIndustryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsIndustryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsIndustryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsIndustryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsIndustryQuery
		
	#region AdminUsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersFilters : AdminUsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilters class.
		/// </summary>
		public AdminUsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersFilters
	
	#region AdminUsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdminUsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdminUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminUsersQuery : AdminUsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminUsersQuery class.
		/// </summary>
		public AdminUsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdminUsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdminUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdminUsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdminUsersQuery
		
	#region CurrenciesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Currencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrenciesFilters : CurrenciesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrenciesFilters class.
		/// </summary>
		public CurrenciesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrenciesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrenciesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrenciesFilters
	
	#region CurrenciesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CurrenciesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Currencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CurrenciesQuery : CurrenciesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CurrenciesQuery class.
		/// </summary>
		public CurrenciesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CurrenciesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CurrenciesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CurrenciesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CurrenciesQuery
		
	#region AdvertiserBusinessTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeFilters : AdvertiserBusinessTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeFilters class.
		/// </summary>
		public AdvertiserBusinessTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserBusinessTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserBusinessTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserBusinessTypeFilters
	
	#region AdvertiserBusinessTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertiserBusinessTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdvertiserBusinessType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserBusinessTypeQuery : AdvertiserBusinessTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeQuery class.
		/// </summary>
		public AdvertiserBusinessTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserBusinessTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserBusinessTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserBusinessTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserBusinessTypeQuery
		
	#region AdvertiserAccountTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeFilters : AdvertiserAccountTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeFilters class.
		/// </summary>
		public AdvertiserAccountTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserAccountTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserAccountTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserAccountTypeFilters
	
	#region AdvertiserAccountTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertiserAccountTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountTypeQuery : AdvertiserAccountTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeQuery class.
		/// </summary>
		public AdvertiserAccountTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserAccountTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserAccountTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserAccountTypeQuery
		
	#region SitesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesFilters : SitesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesFilters class.
		/// </summary>
		public SitesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SitesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SitesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SitesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SitesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SitesFilters
	
	#region SitesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SitesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesQuery : SitesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesQuery class.
		/// </summary>
		public SitesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SitesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SitesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SitesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SitesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SitesQuery
		
	#region MemberQualificationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationFilters : MemberQualificationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationFilters class.
		/// </summary>
		public MemberQualificationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberQualificationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberQualificationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberQualificationFilters
	
	#region MemberQualificationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberQualificationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationQuery : MemberQualificationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationQuery class.
		/// </summary>
		public MemberQualificationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberQualificationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberQualificationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberQualificationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberQualificationQuery
		
	#region AdvertiserAccountStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountStatusFilters : AdvertiserAccountStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusFilters class.
		/// </summary>
		public AdvertiserAccountStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserAccountStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserAccountStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserAccountStatusFilters
	
	#region AdvertiserAccountStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertiserAccountStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdvertiserAccountStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserAccountStatusQuery : AdvertiserAccountStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusQuery class.
		/// </summary>
		public AdvertiserAccountStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserAccountStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserAccountStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserAccountStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserAccountStatusQuery
		
	#region SiteAreaFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaFilters : SiteAreaFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaFilters class.
		/// </summary>
		public SiteAreaFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAreaFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAreaFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAreaFilters
	
	#region SiteAreaQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteAreaParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaQuery : SiteAreaParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaQuery class.
		/// </summary>
		public SiteAreaQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAreaQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAreaQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAreaQuery
		
	#region RolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesFilters : RolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesFilters class.
		/// </summary>
		public RolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RolesFilters
	
	#region RolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesQuery : RolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesQuery class.
		/// </summary>
		public RolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RolesQuery
		
	#region AdvertisersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersFilters : AdvertisersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersFilters class.
		/// </summary>
		public AdvertisersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertisersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertisersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertisersFilters
	
	#region AdvertisersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertisersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Advertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertisersQuery : AdvertisersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertisersQuery class.
		/// </summary>
		public AdvertisersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertisersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertisersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertisersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertisersQuery
		
	#region RelatedDynamicPagesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="RelatedDynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedDynamicPagesFilters : RelatedDynamicPagesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesFilters class.
		/// </summary>
		public RelatedDynamicPagesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RelatedDynamicPagesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RelatedDynamicPagesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RelatedDynamicPagesFilters
	
	#region RelatedDynamicPagesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="RelatedDynamicPagesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="RelatedDynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RelatedDynamicPagesQuery : RelatedDynamicPagesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesQuery class.
		/// </summary>
		public RelatedDynamicPagesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public RelatedDynamicPagesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the RelatedDynamicPagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public RelatedDynamicPagesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion RelatedDynamicPagesQuery
		
	#region NewsCategoriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesFilters : NewsCategoriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesFilters class.
		/// </summary>
		public NewsCategoriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsCategoriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsCategoriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsCategoriesFilters
	
	#region NewsCategoriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NewsCategoriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="NewsCategories"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsCategoriesQuery : NewsCategoriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesQuery class.
		/// </summary>
		public NewsCategoriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsCategoriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsCategoriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsCategoriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsCategoriesQuery
		
	#region SiteCountriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesFilters : SiteCountriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesFilters class.
		/// </summary>
		public SiteCountriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCountriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCountriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCountriesFilters
	
	#region SiteCountriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteCountriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesQuery : SiteCountriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesQuery class.
		/// </summary>
		public SiteCountriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCountriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCountriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCountriesQuery
		
	#region MemberStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusFilters : MemberStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusFilters class.
		/// </summary>
		public MemberStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberStatusFilters
	
	#region MemberStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusQuery : MemberStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusQuery class.
		/// </summary>
		public MemberStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberStatusQuery
		
	#region MembersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersFilters : MembersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersFilters class.
		/// </summary>
		public MembersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MembersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MembersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MembersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MembersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MembersFilters
	
	#region MembersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MembersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersQuery : MembersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersQuery class.
		/// </summary>
		public MembersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MembersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MembersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MembersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MembersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MembersQuery
		
	#region MemberWizardFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardFilters : MemberWizardFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardFilters class.
		/// </summary>
		public MemberWizardFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberWizardFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberWizardFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberWizardFilters
	
	#region MemberWizardQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberWizardParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardQuery : MemberWizardParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardQuery class.
		/// </summary>
		public MemberWizardQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberWizardQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberWizardQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberWizardQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberWizardQuery
		
	#region NewsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsFilters : NewsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsFilters class.
		/// </summary>
		public NewsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsFilters
	
	#region NewsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="NewsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="News"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class NewsQuery : NewsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the NewsQuery class.
		/// </summary>
		public NewsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the NewsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public NewsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the NewsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public NewsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion NewsQuery
		
	#region ProfessionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionFilters : ProfessionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionFilters class.
		/// </summary>
		public ProfessionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfessionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfessionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfessionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfessionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfessionFilters
	
	#region ProfessionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ProfessionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionQuery : ProfessionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionQuery class.
		/// </summary>
		public ProfessionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ProfessionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ProfessionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ProfessionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ProfessionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ProfessionQuery
		
	#region MemberReferencesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberReferences"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberReferencesFilters : MemberReferencesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberReferencesFilters class.
		/// </summary>
		public MemberReferencesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberReferencesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberReferencesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberReferencesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberReferencesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberReferencesFilters
	
	#region MemberReferencesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberReferencesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberReferences"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberReferencesQuery : MemberReferencesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberReferencesQuery class.
		/// </summary>
		public MemberReferencesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberReferencesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberReferencesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberReferencesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberReferencesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberReferencesQuery
		
	#region SiteCurrenciesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCurrencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCurrenciesFilters : SiteCurrenciesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesFilters class.
		/// </summary>
		public SiteCurrenciesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCurrenciesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCurrenciesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCurrenciesFilters
	
	#region SiteCurrenciesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteCurrenciesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteCurrencies"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCurrenciesQuery : SiteCurrenciesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesQuery class.
		/// </summary>
		public SiteCurrenciesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCurrenciesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCurrenciesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCurrenciesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCurrenciesQuery
		
	#region WorkTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeFilters : WorkTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeFilters class.
		/// </summary>
		public WorkTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkTypeFilters
	
	#region WorkTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WorkTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WorkTypeQuery : WorkTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WorkTypeQuery class.
		/// </summary>
		public WorkTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WorkTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WorkTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WorkTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WorkTypeQuery
		
	#region SiteWebPartsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsFilters : SiteWebPartsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsFilters class.
		/// </summary>
		public SiteWebPartsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartsFilters
	
	#region SiteWebPartsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteWebPartsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsQuery : SiteWebPartsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsQuery class.
		/// </summary>
		public SiteWebPartsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWebPartsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWebPartsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWebPartsQuery
		
	#region AdvertiserJobTemplateLogoFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobTemplateLogo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobTemplateLogoFilters : AdvertiserJobTemplateLogoFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoFilters class.
		/// </summary>
		public AdvertiserJobTemplateLogoFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobTemplateLogoFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobTemplateLogoFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobTemplateLogoFilters
	
	#region AdvertiserJobTemplateLogoQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertiserJobTemplateLogoParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobTemplateLogo"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobTemplateLogoQuery : AdvertiserJobTemplateLogoParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoQuery class.
		/// </summary>
		public AdvertiserJobTemplateLogoQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobTemplateLogoQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobTemplateLogoQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobTemplateLogoQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobTemplateLogoQuery
		
	#region JobTemplatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesFilters : JobTemplatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesFilters class.
		/// </summary>
		public JobTemplatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobTemplatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobTemplatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobTemplatesFilters
	
	#region JobTemplatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobTemplatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesQuery : JobTemplatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesQuery class.
		/// </summary>
		public JobTemplatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobTemplatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobTemplatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobTemplatesQuery
		
	#region AdvertiserJobPricingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingFilters : AdvertiserJobPricingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingFilters class.
		/// </summary>
		public AdvertiserJobPricingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobPricingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobPricingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobPricingFilters
	
	#region AdvertiserJobPricingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertiserJobPricingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdvertiserJobPricing"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserJobPricingQuery : AdvertiserJobPricingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingQuery class.
		/// </summary>
		public AdvertiserJobPricingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserJobPricingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserJobPricingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserJobPricingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserJobPricingQuery
		
	#region SiteWorkTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeFilters : SiteWorkTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeFilters class.
		/// </summary>
		public SiteWorkTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWorkTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWorkTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWorkTypeFilters
	
	#region SiteWorkTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteWorkTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteWorkType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWorkTypeQuery : SiteWorkTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeQuery class.
		/// </summary>
		public SiteWorkTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteWorkTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteWorkTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteWorkTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteWorkTypeQuery
		
	#region AdvertiserUsersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersFilters : AdvertiserUsersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersFilters class.
		/// </summary>
		public AdvertiserUsersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserUsersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserUsersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserUsersFilters
	
	#region AdvertiserUsersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AdvertiserUsersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersQuery : AdvertiserUsersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersQuery class.
		/// </summary>
		public AdvertiserUsersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AdvertiserUsersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AdvertiserUsersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AdvertiserUsersQuery
		
	#region MemberPositionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsFilters : MemberPositionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsFilters class.
		/// </summary>
		public MemberPositionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberPositionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberPositionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberPositionsFilters
	
	#region MemberPositionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberPositionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsQuery : MemberPositionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsQuery class.
		/// </summary>
		public MemberPositionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberPositionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberPositionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberPositionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberPositionsQuery
		
	#region DynamicPageFilesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesFilters : DynamicPageFilesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesFilters class.
		/// </summary>
		public DynamicPageFilesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageFilesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageFilesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageFilesFilters
	
	#region DynamicPageFilesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicPageFilesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicPageFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageFilesQuery : DynamicPageFilesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesQuery class.
		/// </summary>
		public DynamicPageFilesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageFilesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageFilesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageFilesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageFilesQuery
		
	#region ScreeningQuestionsTemplatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplatesFilters : ScreeningQuestionsTemplatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesFilters class.
		/// </summary>
		public ScreeningQuestionsTemplatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplatesFilters
	
	#region ScreeningQuestionsTemplatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ScreeningQuestionsTemplatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplatesQuery : ScreeningQuestionsTemplatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesQuery class.
		/// </summary>
		public ScreeningQuestionsTemplatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplatesQuery
		
	#region WidgetContainersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersFilters : WidgetContainersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersFilters class.
		/// </summary>
		public WidgetContainersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WidgetContainersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WidgetContainersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WidgetContainersFilters
	
	#region WidgetContainersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WidgetContainersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersQuery : WidgetContainersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersQuery class.
		/// </summary>
		public WidgetContainersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WidgetContainersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WidgetContainersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WidgetContainersQuery
		
	#region WebServiceLogFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogFilters : WebServiceLogFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogFilters class.
		/// </summary>
		public WebServiceLogFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WebServiceLogFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WebServiceLogFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WebServiceLogFilters
	
	#region WebServiceLogQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="WebServiceLogParameterBuilder"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogQuery : WebServiceLogParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogQuery class.
		/// </summary>
		public WebServiceLogQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WebServiceLogQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WebServiceLogQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WebServiceLogQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WebServiceLogQuery
		
	#region SiteSalaryTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeFilters : SiteSalaryTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeFilters class.
		/// </summary>
		public SiteSalaryTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSalaryTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSalaryTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSalaryTypeFilters
	
	#region SiteSalaryTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteSalaryTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteSalaryType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteSalaryTypeQuery : SiteSalaryTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeQuery class.
		/// </summary>
		public SiteSalaryTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteSalaryTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteSalaryTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteSalaryTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteSalaryTypeQuery
		
	#region JobsArchiveFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveFilters : JobsArchiveFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveFilters class.
		/// </summary>
		public JobsArchiveFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsArchiveFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsArchiveFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsArchiveFilters
	
	#region JobsArchiveQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobsArchiveParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveQuery : JobsArchiveParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveQuery class.
		/// </summary>
		public JobsArchiveQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsArchiveQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsArchiveQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsArchiveQuery
		
	#region JobsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsFilters : JobsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsFilters class.
		/// </summary>
		public JobsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsFilters
	
	#region JobsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsQuery : JobsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsQuery class.
		/// </summary>
		public JobsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsQuery
		
	#region ScreeningQuestionsMappingsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsMappingsFilters : ScreeningQuestionsMappingsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsFilters class.
		/// </summary>
		public ScreeningQuestionsMappingsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsMappingsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsMappingsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsMappingsFilters
	
	#region ScreeningQuestionsMappingsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ScreeningQuestionsMappingsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsMappingsQuery : ScreeningQuestionsMappingsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsQuery class.
		/// </summary>
		public ScreeningQuestionsMappingsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsMappingsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsMappingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsMappingsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsMappingsQuery
		
	#region SiteLanguagesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLanguagesFilters : SiteLanguagesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesFilters class.
		/// </summary>
		public SiteLanguagesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLanguagesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLanguagesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLanguagesFilters
	
	#region SiteLanguagesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteLanguagesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLanguagesQuery : SiteLanguagesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesQuery class.
		/// </summary>
		public SiteLanguagesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLanguagesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLanguagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLanguagesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLanguagesQuery
		
	#region SiteAdvertiserFilterFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterFilters : SiteAdvertiserFilterFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterFilters class.
		/// </summary>
		public SiteAdvertiserFilterFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAdvertiserFilterFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAdvertiserFilterFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAdvertiserFilterFilters
	
	#region SiteAdvertiserFilterQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteAdvertiserFilterParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteAdvertiserFilter"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAdvertiserFilterQuery : SiteAdvertiserFilterParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterQuery class.
		/// </summary>
		public SiteAdvertiserFilterQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteAdvertiserFilterQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteAdvertiserFilterQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteAdvertiserFilterQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteAdvertiserFilterQuery
		
	#region SiteCustomMappingFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCustomMapping"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCustomMappingFilters : SiteCustomMappingFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCustomMappingFilters class.
		/// </summary>
		public SiteCustomMappingFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCustomMappingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCustomMappingFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCustomMappingFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCustomMappingFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCustomMappingFilters
	
	#region SiteCustomMappingQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteCustomMappingParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteCustomMapping"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCustomMappingQuery : SiteCustomMappingParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCustomMappingQuery class.
		/// </summary>
		public SiteCustomMappingQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteCustomMappingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteCustomMappingQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteCustomMappingQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteCustomMappingQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteCustomMappingQuery
		
	#region ScreeningQuestionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsFilters : ScreeningQuestionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsFilters class.
		/// </summary>
		public ScreeningQuestionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsFilters
	
	#region ScreeningQuestionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ScreeningQuestionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsQuery : ScreeningQuestionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsQuery class.
		/// </summary>
		public ScreeningQuestionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsQuery
		
	#region SiteLocationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationFilters : SiteLocationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationFilters class.
		/// </summary>
		public SiteLocationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLocationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLocationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLocationFilters
	
	#region SiteLocationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteLocationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationQuery : SiteLocationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationQuery class.
		/// </summary>
		public SiteLocationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteLocationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteLocationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteLocationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteLocationQuery
		
	#region SiteMappingsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteMappingsFilters : SiteMappingsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteMappingsFilters class.
		/// </summary>
		public SiteMappingsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteMappingsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteMappingsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteMappingsFilters
	
	#region SiteMappingsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteMappingsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteMappingsQuery : SiteMappingsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteMappingsQuery class.
		/// </summary>
		public SiteMappingsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteMappingsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteMappingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteMappingsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteMappingsQuery
		
	#region SiteRolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesFilters : SiteRolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesFilters class.
		/// </summary>
		public SiteRolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteRolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteRolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteRolesFilters
	
	#region SiteRolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteRolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesQuery : SiteRolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesQuery class.
		/// </summary>
		public SiteRolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteRolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteRolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteRolesQuery
		
	#region SiteResourcesXmlFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResourcesXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesXmlFilters : SiteResourcesXmlFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlFilters class.
		/// </summary>
		public SiteResourcesXmlFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesXmlFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesXmlFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesXmlFilters
	
	#region SiteResourcesXmlQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteResourcesXmlParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteResourcesXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesXmlQuery : SiteResourcesXmlParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlQuery class.
		/// </summary>
		public SiteResourcesXmlQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesXmlQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesXmlQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesXmlQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesXmlQuery
		
	#region SiteResourcesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesFilters : SiteResourcesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesFilters class.
		/// </summary>
		public SiteResourcesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesFilters
	
	#region SiteResourcesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteResourcesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteResourcesQuery : SiteResourcesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteResourcesQuery class.
		/// </summary>
		public SiteResourcesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteResourcesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteResourcesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteResourcesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteResourcesQuery
		
	#region SiteProfessionFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionFilters : SiteProfessionFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionFilters class.
		/// </summary>
		public SiteProfessionFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteProfessionFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteProfessionFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteProfessionFilters
	
	#region SiteProfessionQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SiteProfessionParameterBuilder"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionQuery : SiteProfessionParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionQuery class.
		/// </summary>
		public SiteProfessionQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public SiteProfessionQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the SiteProfessionQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public SiteProfessionQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion SiteProfessionQuery
		
	#region ScreeningQuestionsTemplateOwnersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplateOwners"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplateOwnersFilters : ScreeningQuestionsTemplateOwnersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersFilters class.
		/// </summary>
		public ScreeningQuestionsTemplateOwnersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplateOwnersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplateOwnersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplateOwnersFilters
	
	#region ScreeningQuestionsTemplateOwnersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ScreeningQuestionsTemplateOwnersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ScreeningQuestionsTemplateOwners"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ScreeningQuestionsTemplateOwnersQuery : ScreeningQuestionsTemplateOwnersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersQuery class.
		/// </summary>
		public ScreeningQuestionsTemplateOwnersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ScreeningQuestionsTemplateOwnersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ScreeningQuestionsTemplateOwnersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ScreeningQuestionsTemplateOwnersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ScreeningQuestionsTemplateOwnersQuery
		
	#region MemberMembershipsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberMembershipsFilters : MemberMembershipsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsFilters class.
		/// </summary>
		public MemberMembershipsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberMembershipsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberMembershipsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberMembershipsFilters
	
	#region MemberMembershipsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberMembershipsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberMembershipsQuery : MemberMembershipsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsQuery class.
		/// </summary>
		public MemberMembershipsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberMembershipsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberMembershipsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberMembershipsQuery
		
	#region MemberLicensesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLicenses"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLicensesFilters : MemberLicensesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLicensesFilters class.
		/// </summary>
		public MemberLicensesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLicensesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLicensesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLicensesFilters
	
	#region MemberLicensesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberLicensesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberLicenses"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLicensesQuery : MemberLicensesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLicensesQuery class.
		/// </summary>
		public MemberLicensesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLicensesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLicensesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLicensesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLicensesQuery
		
	#region CustomWidgetCssSelectorFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorFilters : CustomWidgetCssSelectorFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorFilters class.
		/// </summary>
		public CustomWidgetCssSelectorFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetCssSelectorFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetCssSelectorFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetCssSelectorFilters
	
	#region CustomWidgetCssSelectorQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomWidgetCssSelectorParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorQuery : CustomWidgetCssSelectorParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorQuery class.
		/// </summary>
		public CustomWidgetCssSelectorQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetCssSelectorQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetCssSelectorQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetCssSelectorQuery
		
	#region FoldersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersFilters : FoldersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersFilters class.
		/// </summary>
		public FoldersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FoldersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FoldersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FoldersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FoldersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FoldersFilters
	
	#region FoldersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FoldersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersQuery : FoldersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersQuery class.
		/// </summary>
		public FoldersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FoldersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FoldersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FoldersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FoldersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FoldersQuery
		
	#region CustomWidgetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetFilters : CustomWidgetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetFilters class.
		/// </summary>
		public CustomWidgetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetFilters
	
	#region CustomWidgetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomWidgetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetQuery : CustomWidgetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetQuery class.
		/// </summary>
		public CustomWidgetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomWidgetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomWidgetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomWidgetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomWidgetQuery
		
	#region CustomPaymentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomPayment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomPaymentFilters : CustomPaymentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomPaymentFilters class.
		/// </summary>
		public CustomPaymentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomPaymentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomPaymentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomPaymentFilters
	
	#region CustomPaymentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CustomPaymentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="CustomPayment"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomPaymentQuery : CustomPaymentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomPaymentQuery class.
		/// </summary>
		public CustomPaymentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CustomPaymentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CustomPaymentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CustomPaymentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CustomPaymentQuery
		
	#region IntegrationsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Integrations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationsFilters : IntegrationsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationsFilters class.
		/// </summary>
		public IntegrationsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationsFilters
	
	#region IntegrationsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IntegrationsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Integrations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationsQuery : IntegrationsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationsQuery class.
		/// </summary>
		public IntegrationsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationsQuery
		
	#region IndustryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Industry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndustryFilters : IndustryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndustryFilters class.
		/// </summary>
		public IndustryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndustryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndustryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndustryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndustryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndustryFilters
	
	#region IndustryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IndustryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Industry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IndustryQuery : IndustryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IndustryQuery class.
		/// </summary>
		public IndustryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IndustryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IndustryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IndustryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IndustryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IndustryQuery
		
	#region FilesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesFilters : FilesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesFilters class.
		/// </summary>
		public FilesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the FilesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FilesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FilesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FilesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FilesFilters
	
	#region FilesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="FilesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesQuery : FilesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesQuery class.
		/// </summary>
		public FilesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the FilesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public FilesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the FilesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public FilesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion FilesQuery
		
	#region IntegrationMappingsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="IntegrationMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationMappingsFilters : IntegrationMappingsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsFilters class.
		/// </summary>
		public IntegrationMappingsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationMappingsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationMappingsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationMappingsFilters
	
	#region IntegrationMappingsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="IntegrationMappingsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="IntegrationMappings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class IntegrationMappingsQuery : IntegrationMappingsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsQuery class.
		/// </summary>
		public IntegrationMappingsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public IntegrationMappingsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the IntegrationMappingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public IntegrationMappingsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion IntegrationMappingsQuery
		
	#region DynamicPageWebPartTemplatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesFilters : DynamicPageWebPartTemplatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesFilters class.
		/// </summary>
		public DynamicPageWebPartTemplatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesFilters
	
	#region DynamicPageWebPartTemplatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicPageWebPartTemplatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesQuery : DynamicPageWebPartTemplatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesQuery class.
		/// </summary>
		public DynamicPageWebPartTemplatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesQuery
		
	#region DefaultResourcesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesFilters : DefaultResourcesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesFilters class.
		/// </summary>
		public DefaultResourcesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DefaultResourcesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DefaultResourcesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DefaultResourcesFilters
	
	#region DefaultResourcesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DefaultResourcesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DefaultResources"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DefaultResourcesQuery : DefaultResourcesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesQuery class.
		/// </summary>
		public DefaultResourcesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DefaultResourcesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DefaultResourcesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DefaultResourcesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DefaultResourcesQuery
		
	#region DynamicPageWebPartTemplatesLinkFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkFilters : DynamicPageWebPartTemplatesLinkFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkFilters class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesLinkFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesLinkFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesLinkFilters
	
	#region DynamicPageWebPartTemplatesLinkQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicPageWebPartTemplatesLinkParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkQuery : DynamicPageWebPartTemplatesLinkParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkQuery class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPageWebPartTemplatesLinkQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPageWebPartTemplatesLinkQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPageWebPartTemplatesLinkQuery
		
	#region DynamicpagesCustomWidgetFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetFilters : DynamicpagesCustomWidgetFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetFilters class.
		/// </summary>
		public DynamicpagesCustomWidgetFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicpagesCustomWidgetFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicpagesCustomWidgetFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicpagesCustomWidgetFilters
	
	#region DynamicpagesCustomWidgetQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicpagesCustomWidgetParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetQuery : DynamicpagesCustomWidgetParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetQuery class.
		/// </summary>
		public DynamicpagesCustomWidgetQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicpagesCustomWidgetQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicpagesCustomWidgetQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicpagesCustomWidgetQuery
		
	#region GlobalSettingsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsFilters : GlobalSettingsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsFilters class.
		/// </summary>
		public GlobalSettingsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalSettingsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalSettingsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalSettingsFilters
	
	#region GlobalSettingsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="GlobalSettingsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="GlobalSettings"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class GlobalSettingsQuery : GlobalSettingsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsQuery class.
		/// </summary>
		public GlobalSettingsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public GlobalSettingsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the GlobalSettingsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public GlobalSettingsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion GlobalSettingsQuery
		
	#region EnquiriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesFilters : EnquiriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesFilters class.
		/// </summary>
		public EnquiriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EnquiriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EnquiriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EnquiriesFilters
	
	#region EnquiriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EnquiriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesQuery : EnquiriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesQuery class.
		/// </summary>
		public EnquiriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EnquiriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EnquiriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EnquiriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EnquiriesQuery
		
	#region EducationsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Educations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationsFilters : EducationsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationsFilters class.
		/// </summary>
		public EducationsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EducationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EducationsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EducationsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EducationsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EducationsFilters
	
	#region EducationsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EducationsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Educations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationsQuery : EducationsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationsQuery class.
		/// </summary>
		public EducationsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EducationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EducationsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EducationsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EducationsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EducationsQuery
		
	#region EmailTemplatesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesFilters : EmailTemplatesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesFilters class.
		/// </summary>
		public EmailTemplatesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplatesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplatesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplatesFilters
	
	#region EmailTemplatesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="EmailTemplatesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesQuery : EmailTemplatesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesQuery class.
		/// </summary>
		public EmailTemplatesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailTemplatesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailTemplatesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailTemplatesQuery
		
	#region InvoiceOrderFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceOrderFilters : InvoiceOrderFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderFilters class.
		/// </summary>
		public InvoiceOrderFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceOrderFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceOrderFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceOrderFilters
	
	#region InvoiceOrderQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoiceOrderParameterBuilder"/> class
	/// that is used exclusively with a <see cref="InvoiceOrder"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceOrderQuery : InvoiceOrderParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderQuery class.
		/// </summary>
		public InvoiceOrderQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceOrderQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceOrderQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceOrderQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceOrderQuery
		
	#region DynamicContentFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicContent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicContentFilters : DynamicContentFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicContentFilters class.
		/// </summary>
		public DynamicContentFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicContentFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicContentFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicContentFilters
	
	#region DynamicContentQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicContentParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicContent"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicContentQuery : DynamicContentParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicContentQuery class.
		/// </summary>
		public DynamicContentQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicContentQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicContentQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicContentQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicContentQuery
		
	#region JobAlertsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsFilters : JobAlertsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsFilters class.
		/// </summary>
		public JobAlertsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAlertsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAlertsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAlertsFilters
	
	#region JobAlertsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobAlertsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsQuery : JobAlertsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsQuery class.
		/// </summary>
		public JobAlertsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAlertsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAlertsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAlertsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAlertsQuery
		
	#region JobScreeningQuestionsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobScreeningQuestionsFilters : JobScreeningQuestionsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsFilters class.
		/// </summary>
		public JobScreeningQuestionsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobScreeningQuestionsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobScreeningQuestionsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobScreeningQuestionsFilters
	
	#region JobScreeningQuestionsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobScreeningQuestionsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobScreeningQuestions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobScreeningQuestionsQuery : JobScreeningQuestionsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsQuery class.
		/// </summary>
		public JobScreeningQuestionsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobScreeningQuestionsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobScreeningQuestionsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobScreeningQuestionsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobScreeningQuestionsQuery
		
	#region JobRolesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesFilters : JobRolesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesFilters class.
		/// </summary>
		public JobRolesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobRolesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobRolesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobRolesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobRolesFilters
	
	#region JobRolesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobRolesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesQuery : JobRolesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesQuery class.
		/// </summary>
		public JobRolesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobRolesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobRolesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobRolesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobRolesQuery
		
	#region CountriesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesFilters : CountriesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		public CountriesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesFilters
	
	#region CountriesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="CountriesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesQuery : CountriesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		public CountriesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public CountriesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the CountriesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public CountriesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion CountriesQuery
		
	#region JobViewsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobViews"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobViewsFilters : JobViewsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobViewsFilters class.
		/// </summary>
		public JobViewsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobViewsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobViewsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobViewsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobViewsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobViewsFilters
	
	#region JobViewsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobViewsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobViews"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobViewsQuery : JobViewsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobViewsQuery class.
		/// </summary>
		public JobViewsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobViewsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobViewsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobViewsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobViewsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobViewsQuery
		
	#region ConsultantsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Consultants"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConsultantsFilters : ConsultantsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConsultantsFilters class.
		/// </summary>
		public ConsultantsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConsultantsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConsultantsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConsultantsFilters
	
	#region ConsultantsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ConsultantsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Consultants"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ConsultantsQuery : ConsultantsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ConsultantsQuery class.
		/// </summary>
		public ConsultantsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ConsultantsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ConsultantsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ConsultantsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ConsultantsQuery
		
	#region AvailableStatusFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AvailableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AvailableStatusFilters : AvailableStatusFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AvailableStatusFilters class.
		/// </summary>
		public AvailableStatusFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AvailableStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AvailableStatusFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AvailableStatusFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AvailableStatusFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AvailableStatusFilters
	
	#region AvailableStatusQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AvailableStatusParameterBuilder"/> class
	/// that is used exclusively with a <see cref="AvailableStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AvailableStatusQuery : AvailableStatusParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AvailableStatusQuery class.
		/// </summary>
		public AvailableStatusQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AvailableStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AvailableStatusQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AvailableStatusQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AvailableStatusQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AvailableStatusQuery
		
	#region JobItemsTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeFilters : JobItemsTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeFilters class.
		/// </summary>
		public JobItemsTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobItemsTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobItemsTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobItemsTypeFilters
	
	#region JobItemsTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobItemsTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeQuery : JobItemsTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeQuery class.
		/// </summary>
		public JobItemsTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobItemsTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobItemsTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobItemsTypeQuery
		
	#region JobCustomXmlFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobCustomXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomXmlFilters : JobCustomXmlFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlFilters class.
		/// </summary>
		public JobCustomXmlFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomXmlFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomXmlFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomXmlFilters
	
	#region JobCustomXmlQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobCustomXmlParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobCustomXml"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobCustomXmlQuery : JobCustomXmlParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlQuery class.
		/// </summary>
		public JobCustomXmlQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobCustomXmlQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobCustomXmlQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobCustomXmlQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobCustomXmlQuery
		
	#region JobAreaFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaFilters : JobAreaFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaFilters class.
		/// </summary>
		public JobAreaFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAreaFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAreaFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAreaFilters
	
	#region JobAreaQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobAreaParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaQuery : JobAreaParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaQuery class.
		/// </summary>
		public JobAreaQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobAreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobAreaQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobAreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobAreaQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobAreaQuery
		
	#region InvoiceFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceFilters : InvoiceFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceFilters class.
		/// </summary>
		public InvoiceFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceFilters
	
	#region InvoiceQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoiceParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Invoice"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceQuery : InvoiceParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceQuery class.
		/// </summary>
		public InvoiceQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceQuery
		
	#region MemberCertificateMembershipsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberCertificateMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberCertificateMembershipsFilters : MemberCertificateMembershipsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsFilters class.
		/// </summary>
		public MemberCertificateMembershipsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberCertificateMembershipsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberCertificateMembershipsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberCertificateMembershipsFilters
	
	#region MemberCertificateMembershipsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberCertificateMembershipsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberCertificateMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberCertificateMembershipsQuery : MemberCertificateMembershipsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsQuery class.
		/// </summary>
		public MemberCertificateMembershipsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberCertificateMembershipsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberCertificateMembershipsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberCertificateMembershipsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberCertificateMembershipsQuery
		
	#region MemberFilesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesFilters : MemberFilesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesFilters class.
		/// </summary>
		public MemberFilesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFilesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFilesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFilesFilters
	
	#region MemberFilesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberFilesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesQuery : MemberFilesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesQuery class.
		/// </summary>
		public MemberFilesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberFilesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberFilesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberFilesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberFilesQuery
		
	#region DynamicPagesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesFilters : DynamicPagesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesFilters class.
		/// </summary>
		public DynamicPagesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPagesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPagesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPagesFilters
	
	#region DynamicPagesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="DynamicPagesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="DynamicPages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPagesQuery : DynamicPagesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPagesQuery class.
		/// </summary>
		public DynamicPagesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicPagesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicPagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicPagesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicPagesQuery
		
	#region MemberLanguagesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLanguagesFilters : MemberLanguagesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesFilters class.
		/// </summary>
		public MemberLanguagesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLanguagesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLanguagesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLanguagesFilters
	
	#region MemberLanguagesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="MemberLanguagesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="MemberLanguages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberLanguagesQuery : MemberLanguagesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesQuery class.
		/// </summary>
		public MemberLanguagesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public MemberLanguagesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the MemberLanguagesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public MemberLanguagesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion MemberLanguagesQuery
		
	#region AreaFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaFilters : AreaFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaFilters class.
		/// </summary>
		public AreaFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaFilters
	
	#region AreaQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="AreaParameterBuilder"/> class
	/// that is used exclusively with a <see cref="Area"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AreaQuery : AreaParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AreaQuery class.
		/// </summary>
		public AreaQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the AreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public AreaQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the AreaQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public AreaQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion AreaQuery
		
	#region InvoiceItemFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="InvoiceItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceItemFilters : InvoiceItemFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceItemFilters class.
		/// </summary>
		public InvoiceItemFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceItemFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceItemFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceItemFilters
	
	#region InvoiceItemQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="InvoiceItemParameterBuilder"/> class
	/// that is used exclusively with a <see cref="InvoiceItem"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class InvoiceItemQuery : InvoiceItemParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the InvoiceItemQuery class.
		/// </summary>
		public InvoiceItemQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public InvoiceItemQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the InvoiceItemQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public InvoiceItemQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion InvoiceItemQuery
		
	#region JobApplicationTypeFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationTypeFilters : JobApplicationTypeFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeFilters class.
		/// </summary>
		public JobApplicationTypeFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationTypeFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationTypeFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationTypeFilters
	
	#region JobApplicationTypeQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobApplicationTypeParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobApplicationType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationTypeQuery : JobApplicationTypeParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeQuery class.
		/// </summary>
		public JobApplicationTypeQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationTypeQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationTypeQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationTypeQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationTypeQuery
		
	#region JobApplicationScreeningAnswersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationScreeningAnswers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationScreeningAnswersFilters : JobApplicationScreeningAnswersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersFilters class.
		/// </summary>
		public JobApplicationScreeningAnswersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationScreeningAnswersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationScreeningAnswersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationScreeningAnswersFilters
	
	#region JobApplicationScreeningAnswersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobApplicationScreeningAnswersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobApplicationScreeningAnswers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationScreeningAnswersQuery : JobApplicationScreeningAnswersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersQuery class.
		/// </summary>
		public JobApplicationScreeningAnswersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationScreeningAnswersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationScreeningAnswersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationScreeningAnswersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationScreeningAnswersQuery
		
	#region JobsSavedFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsSaved"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsSavedFilters : JobsSavedFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsSavedFilters class.
		/// </summary>
		public JobsSavedFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsSavedFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsSavedFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsSavedFilters
	
	#region JobsSavedQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobsSavedParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobsSaved"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsSavedQuery : JobsSavedParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsSavedQuery class.
		/// </summary>
		public JobsSavedQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobsSavedQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobsSavedQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobsSavedQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobsSavedQuery
		
	#region JobApplicationFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationFilters : JobApplicationFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationFilters class.
		/// </summary>
		public JobApplicationFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationFilters
	
	#region JobApplicationQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobApplicationParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobApplication"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationQuery : JobApplicationParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationQuery class.
		/// </summary>
		public JobApplicationQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationQuery
		
	#region JobApplicationNotesFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobApplicationNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationNotesFilters : JobApplicationNotesFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesFilters class.
		/// </summary>
		public JobApplicationNotesFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationNotesFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationNotesFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationNotesFilters
	
	#region JobApplicationNotesQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="JobApplicationNotesParameterBuilder"/> class
	/// that is used exclusively with a <see cref="JobApplicationNotes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobApplicationNotesQuery : JobApplicationNotesParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesQuery class.
		/// </summary>
		public JobApplicationNotesQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public JobApplicationNotesQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the JobApplicationNotesQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public JobApplicationNotesQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion JobApplicationNotesQuery
		
	#region ViewJobsFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsFilters : ViewJobsFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsFilters class.
		/// </summary>
		public ViewJobsFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobsFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobsFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobsFilters
	
	#region ViewJobsQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ViewJobsParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsQuery : ViewJobsParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsQuery class.
		/// </summary>
		public ViewJobsQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobsQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobsQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobsQuery
		
	#region ViewJobsArchiveFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsArchiveFilters : ViewJobsArchiveFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveFilters class.
		/// </summary>
		public ViewJobsArchiveFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobsArchiveFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobsArchiveFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobsArchiveFilters
	
	#region ViewJobsArchiveQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ViewJobsArchiveParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ViewJobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsArchiveQuery : ViewJobsArchiveParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveQuery class.
		/// </summary>
		public ViewJobsArchiveQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobsArchiveQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobsArchiveQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobsArchiveQuery
		
	#region ViewJobSearchFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobSearchFilters : ViewJobSearchFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchFilters class.
		/// </summary>
		public ViewJobSearchFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobSearchFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobSearchFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobSearchFilters
	
	#region ViewJobSearchQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ViewJobSearchParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobSearchQuery : ViewJobSearchParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchQuery class.
		/// </summary>
		public ViewJobSearchQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewJobSearchQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewJobSearchQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewJobSearchQuery
		
	#region ViewSalaryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSalaryFilters : ViewSalaryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSalaryFilters class.
		/// </summary>
		public ViewSalaryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSalaryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSalaryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSalaryFilters
	
	#region ViewSalaryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ViewSalaryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ViewSalary"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSalaryQuery : ViewSalaryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSalaryQuery class.
		/// </summary>
		public ViewSalaryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSalaryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSalaryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSalaryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSalaryQuery
		
	#region ViewSiteAdvertisersFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAdvertisersFilters : ViewSiteAdvertisersFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersFilters class.
		/// </summary>
		public ViewSiteAdvertisersFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAdvertisersFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAdvertisersFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAdvertisersFilters
	
	#region ViewSiteAdvertisersQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ViewSiteAdvertisersParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAdvertisersQuery : ViewSiteAdvertisersParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersQuery class.
		/// </summary>
		public ViewSiteAdvertisersQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAdvertisersQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAdvertisersQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAdvertisersQuery
		
	#region ViewSiteAreaLocationCountryFilters
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAreaLocationCountry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAreaLocationCountryFilters : ViewSiteAreaLocationCountryFilterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryFilters class.
		/// </summary>
		public ViewSiteAreaLocationCountryFilters() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAreaLocationCountryFilters(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryFilters class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAreaLocationCountryFilters(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAreaLocationCountryFilters
	
	#region ViewSiteAreaLocationCountryQuery
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ViewSiteAreaLocationCountryParameterBuilder"/> class
	/// that is used exclusively with a <see cref="ViewSiteAreaLocationCountry"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAreaLocationCountryQuery : ViewSiteAreaLocationCountryParameterBuilder
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryQuery class.
		/// </summary>
		public ViewSiteAreaLocationCountryQuery() : base() { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ViewSiteAreaLocationCountryQuery(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ViewSiteAreaLocationCountryQuery class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ViewSiteAreaLocationCountryQuery(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ViewSiteAreaLocationCountryQuery
	#endregion

	
}
