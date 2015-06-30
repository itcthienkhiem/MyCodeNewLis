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
    /// Controller class for T_TEST_CONTENT
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TTestContentController
    {
        // Preload our schema..
        TTestContent thisSchemaLoad = new TTestContent();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TTestContentCollection FetchAll()
        {
            TTestContentCollection coll = new TTestContentCollection();
            Query qry = new Query(TTestContent.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TTestContentCollection FetchByID(object TestId)
        {
            TTestContentCollection coll = new TTestContentCollection().Where("Test_ID", TestId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TTestContentCollection FetchByQuery(Query qry)
        {
            TTestContentCollection coll = new TTestContentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TestId)
        {
            return (TTestContent.Delete(TestId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TestId)
        {
            return (TTestContent.Destroy(TestId) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(decimal TestId,string PatientId)
        {
            Query qry = new Query(TTestContent.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("TestId", TestId).AND("PatientId", PatientId);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal TestId,string PatientId,short? Status,decimal? DataId,decimal? UpdateUser,decimal? UpdateDate)
	    {
		    TTestContent item = new TTestContent();
		    
            item.TestId = TestId;
            
            item.PatientId = PatientId;
            
            item.Status = Status;
            
            item.DataId = DataId;
            
            item.UpdateUser = UpdateUser;
            
            item.UpdateDate = UpdateDate;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(decimal TestId,string PatientId,short? Status,decimal? DataId,decimal? UpdateUser,decimal? UpdateDate)
	    {
		    TTestContent item = new TTestContent();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TestId = TestId;
				
			item.PatientId = PatientId;
				
			item.Status = Status;
				
			item.DataId = DataId;
				
			item.UpdateUser = UpdateUser;
				
			item.UpdateDate = UpdateDate;
				
	        item.Save(UserName);
	    }
    }
}
