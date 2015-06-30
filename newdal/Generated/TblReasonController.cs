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
    /// Controller class for tbl_Reason
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TblReasonController
    {
        // Preload our schema..
        TblReason thisSchemaLoad = new TblReason();
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
        public TblReasonCollection FetchAll()
        {
            TblReasonCollection coll = new TblReasonCollection();
            Query qry = new Query(TblReason.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblReasonCollection FetchByID(object Id)
        {
            TblReasonCollection coll = new TblReasonCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblReasonCollection FetchByQuery(Query qry)
        {
            TblReasonCollection coll = new TblReasonCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (TblReason.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (TblReason.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string SName,string SDesc,short IntSTT)
	    {
		    TblReason item = new TblReason();
		    
            item.SName = SName;
            
            item.SDesc = SDesc;
            
            item.IntSTT = IntSTT;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short Id,string SName,string SDesc,short IntSTT)
	    {
		    TblReason item = new TblReason();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SName = SName;
				
			item.SDesc = SDesc;
				
			item.IntSTT = IntSTT;
				
	        item.Save(UserName);
	    }
    }
}
