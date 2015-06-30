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
	/// Strongly-typed collection for the LMappingEmac class.
	/// </summary>
    [Serializable]
	public partial class LMappingEmacCollection : ActiveList<LMappingEmac, LMappingEmacCollection>
	{	   
		public LMappingEmacCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>LMappingEmacCollection</returns>
		public LMappingEmacCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                LMappingEmac o = this[i];
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
	/// This is an ActiveRecord class which wraps the L_Mapping_EMAC table.
	/// </summary>
	[Serializable]
	public partial class LMappingEmac : ActiveRecord<LMappingEmac>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public LMappingEmac()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public LMappingEmac(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public LMappingEmac(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public LMappingEmac(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("L_Mapping_EMAC", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int32;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarIdLab = new TableSchema.TableColumn(schema);
				colvarIdLab.ColumnName = "ID_Lab";
				colvarIdLab.DataType = DbType.Int32;
				colvarIdLab.MaxLength = 0;
				colvarIdLab.AutoIncrement = false;
				colvarIdLab.IsNullable = true;
				colvarIdLab.IsPrimaryKey = false;
				colvarIdLab.IsForeignKey = false;
				colvarIdLab.IsReadOnly = false;
				colvarIdLab.DefaultSetting = @"";
				colvarIdLab.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdLab);
				
				TableSchema.TableColumn colvarIdKetNoi = new TableSchema.TableColumn(schema);
				colvarIdKetNoi.ColumnName = "ID_KetNoi";
				colvarIdKetNoi.DataType = DbType.String;
				colvarIdKetNoi.MaxLength = 150;
				colvarIdKetNoi.AutoIncrement = false;
				colvarIdKetNoi.IsNullable = true;
				colvarIdKetNoi.IsPrimaryKey = false;
				colvarIdKetNoi.IsForeignKey = false;
				colvarIdKetNoi.IsReadOnly = false;
				colvarIdKetNoi.DefaultSetting = @"";
				colvarIdKetNoi.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIdKetNoi);
				
				TableSchema.TableColumn colvarSDesc = new TableSchema.TableColumn(schema);
				colvarSDesc.ColumnName = "sDesc";
				colvarSDesc.DataType = DbType.String;
				colvarSDesc.MaxLength = 50;
				colvarSDesc.AutoIncrement = false;
				colvarSDesc.IsNullable = true;
				colvarSDesc.IsPrimaryKey = false;
				colvarSDesc.IsForeignKey = false;
				colvarSDesc.IsReadOnly = false;
				colvarSDesc.DefaultSetting = @"";
				colvarSDesc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSDesc);
				
				TableSchema.TableColumn colvarAliasName = new TableSchema.TableColumn(schema);
				colvarAliasName.ColumnName = "Alias_Name";
				colvarAliasName.DataType = DbType.String;
				colvarAliasName.MaxLength = 50;
				colvarAliasName.AutoIncrement = false;
				colvarAliasName.IsNullable = true;
				colvarAliasName.IsPrimaryKey = false;
				colvarAliasName.IsForeignKey = false;
				colvarAliasName.IsReadOnly = false;
				colvarAliasName.DefaultSetting = @"";
				colvarAliasName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAliasName);
				
				TableSchema.TableColumn colvarTypeMap = new TableSchema.TableColumn(schema);
				colvarTypeMap.ColumnName = "Type_Map";
				colvarTypeMap.DataType = DbType.String;
				colvarTypeMap.MaxLength = 50;
				colvarTypeMap.AutoIncrement = false;
				colvarTypeMap.IsNullable = true;
				colvarTypeMap.IsPrimaryKey = false;
				colvarTypeMap.IsForeignKey = false;
				colvarTypeMap.IsReadOnly = false;
				colvarTypeMap.DefaultSetting = @"";
				colvarTypeMap.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTypeMap);
				
				TableSchema.TableColumn colvarTestTypeId = new TableSchema.TableColumn(schema);
				colvarTestTypeId.ColumnName = "TestType_ID";
				colvarTestTypeId.DataType = DbType.Int32;
				colvarTestTypeId.MaxLength = 0;
				colvarTestTypeId.AutoIncrement = false;
				colvarTestTypeId.IsNullable = true;
				colvarTestTypeId.IsPrimaryKey = false;
				colvarTestTypeId.IsForeignKey = false;
				colvarTestTypeId.IsReadOnly = false;
				colvarTestTypeId.DefaultSetting = @"";
				colvarTestTypeId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTestTypeId);
				
				TableSchema.TableColumn colvarTestDataId = new TableSchema.TableColumn(schema);
				colvarTestDataId.ColumnName = "TestData_ID";
				colvarTestDataId.DataType = DbType.String;
				colvarTestDataId.MaxLength = 100;
				colvarTestDataId.AutoIncrement = false;
				colvarTestDataId.IsNullable = true;
				colvarTestDataId.IsPrimaryKey = false;
				colvarTestDataId.IsForeignKey = false;
				colvarTestDataId.IsReadOnly = false;
				colvarTestDataId.DefaultSetting = @"";
				colvarTestDataId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTestDataId);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("L_Mapping_EMAC",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public int Id 
		{
			get { return GetColumnValue<int>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("IdLab")]
		[Bindable(true)]
		public int? IdLab 
		{
			get { return GetColumnValue<int?>(Columns.IdLab); }
			set { SetColumnValue(Columns.IdLab, value); }
		}
		  
		[XmlAttribute("IdKetNoi")]
		[Bindable(true)]
		public string IdKetNoi 
		{
			get { return GetColumnValue<string>(Columns.IdKetNoi); }
			set { SetColumnValue(Columns.IdKetNoi, value); }
		}
		  
		[XmlAttribute("SDesc")]
		[Bindable(true)]
		public string SDesc 
		{
			get { return GetColumnValue<string>(Columns.SDesc); }
			set { SetColumnValue(Columns.SDesc, value); }
		}
		  
		[XmlAttribute("AliasName")]
		[Bindable(true)]
		public string AliasName 
		{
			get { return GetColumnValue<string>(Columns.AliasName); }
			set { SetColumnValue(Columns.AliasName, value); }
		}
		  
		[XmlAttribute("TypeMap")]
		[Bindable(true)]
		public string TypeMap 
		{
			get { return GetColumnValue<string>(Columns.TypeMap); }
			set { SetColumnValue(Columns.TypeMap, value); }
		}
		  
		[XmlAttribute("TestTypeId")]
		[Bindable(true)]
		public int? TestTypeId 
		{
			get { return GetColumnValue<int?>(Columns.TestTypeId); }
			set { SetColumnValue(Columns.TestTypeId, value); }
		}
		  
		[XmlAttribute("TestDataId")]
		[Bindable(true)]
		public string TestDataId 
		{
			get { return GetColumnValue<string>(Columns.TestDataId); }
			set { SetColumnValue(Columns.TestDataId, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varIdLab,string varIdKetNoi,string varSDesc,string varAliasName,string varTypeMap,int? varTestTypeId,string varTestDataId)
		{
			LMappingEmac item = new LMappingEmac();
			
			item.IdLab = varIdLab;
			
			item.IdKetNoi = varIdKetNoi;
			
			item.SDesc = varSDesc;
			
			item.AliasName = varAliasName;
			
			item.TypeMap = varTypeMap;
			
			item.TestTypeId = varTestTypeId;
			
			item.TestDataId = varTestDataId;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varId,int? varIdLab,string varIdKetNoi,string varSDesc,string varAliasName,string varTypeMap,int? varTestTypeId,string varTestDataId)
		{
			LMappingEmac item = new LMappingEmac();
			
				item.Id = varId;
			
				item.IdLab = varIdLab;
			
				item.IdKetNoi = varIdKetNoi;
			
				item.SDesc = varSDesc;
			
				item.AliasName = varAliasName;
			
				item.TypeMap = varTypeMap;
			
				item.TestTypeId = varTestTypeId;
			
				item.TestDataId = varTestDataId;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn IdLabColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn IdKetNoiColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SDescColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn AliasNameColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TypeMapColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn TestTypeIdColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn TestDataIdColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string IdLab = @"ID_Lab";
			 public static string IdKetNoi = @"ID_KetNoi";
			 public static string SDesc = @"sDesc";
			 public static string AliasName = @"Alias_Name";
			 public static string TypeMap = @"Type_Map";
			 public static string TestTypeId = @"TestType_ID";
			 public static string TestDataId = @"TestData_ID";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
