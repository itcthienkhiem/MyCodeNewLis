using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace LIS.DAL
{
	/// <summary>
	/// Strongly-typed collection for the DDevicePort class.
	/// </summary>
    [Serializable]
	public partial class DDevicePortCollection : ActiveList<DDevicePort, DDevicePortCollection>
	{	   
		public DDevicePortCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>DDevicePortCollection</returns>
		public DDevicePortCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                DDevicePort o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the D_Device_Port table.
	/// </summary>
	[Serializable]
	public partial class DDevicePort : ActiveRecord<DDevicePort>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public DDevicePort()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public DDevicePort(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public DDevicePort(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public DDevicePort(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("D_Device_Port", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPortId = new TableSchema.TableColumn(schema);
				colvarPortId.ColumnName = "Port_ID";
				colvarPortId.DataType = DbType.Int32;
				colvarPortId.MaxLength = 0;
				colvarPortId.AutoIncrement = false;
				colvarPortId.IsNullable = false;
				colvarPortId.IsPrimaryKey = true;
				colvarPortId.IsForeignKey = false;
				colvarPortId.IsReadOnly = false;
				colvarPortId.DefaultSetting = @"";
				colvarPortId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPortId);
				
				TableSchema.TableColumn colvarPortName = new TableSchema.TableColumn(schema);
				colvarPortName.ColumnName = "Port_Name";
				colvarPortName.DataType = DbType.AnsiString;
				colvarPortName.MaxLength = 50;
				colvarPortName.AutoIncrement = false;
				colvarPortName.IsNullable = false;
				colvarPortName.IsPrimaryKey = false;
				colvarPortName.IsForeignKey = false;
				colvarPortName.IsReadOnly = false;
				colvarPortName.DefaultSetting = @"";
				colvarPortName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPortName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 1073741823;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = true;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("D_Device_Port",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PortId")]
		[Bindable(true)]
		public int PortId 
		{
			get { return GetColumnValue<int>(Columns.PortId); }
			set { SetColumnValue(Columns.PortId, value); }
		}
		  
		[XmlAttribute("PortName")]
		[Bindable(true)]
		public string PortName 
		{
			get { return GetColumnValue<string>(Columns.PortName); }
			set { SetColumnValue(Columns.PortName, value); }
		}
		  
		[XmlAttribute("Description")]
		[Bindable(true)]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }
			set { SetColumnValue(Columns.Description, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varPortId,string varPortName,string varDescription)
		{
			DDevicePort item = new DDevicePort();
			
			item.PortId = varPortId;
			
			item.PortName = varPortName;
			
			item.Description = varDescription;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPortId,string varPortName,string varDescription)
		{
			DDevicePort item = new DDevicePort();
			
				item.PortId = varPortId;
			
				item.PortName = varPortName;
			
				item.Description = varDescription;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PortIdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn PortNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PortId = @"Port_ID";
			 public static string PortName = @"Port_Name";
			 public static string Description = @"Description";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
