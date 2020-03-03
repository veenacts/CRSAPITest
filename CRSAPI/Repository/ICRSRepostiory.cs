using CRSAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRSAPI.Repository
{
   public  interface ICRSRepostiory
    {
        public List<Associate> GetAllAssociates();


        public List<Associate> GetAllAssociatebyid(int id);

        public int AddAssociate(Associate value);
    }
}
