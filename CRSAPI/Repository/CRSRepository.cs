using CRSAPI.DbContexts;
using CRSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRSAPI.Repository
{
    public class CRSRepository:ICRSRepostiory
    {
        MasterDataDbContext db;
        
        public CRSRepository (MasterDataDbContext _db)
        {
            db = _db;
        }

        public List<Associate> GetAllAssociates()
        {
            if(db!=null)
            {
                return db.Associate.ToList();
            }
            return null;
        }

        public List<Associate> GetAllAssociatebyid(int id)
        {
            if(db!=null)
            {
                return db.Associate.Where(a=>a.AssociateId==id).ToList();
            }
            return null;
        }

        public int AddAssociate(Associate associatelist)
        {
            if (db!=null)
            {
                db.Associate.Add(associatelist);
                db.SaveChanges();
                return associatelist.AssociateId;
            }
            return 0;
        }
        
    }
}
