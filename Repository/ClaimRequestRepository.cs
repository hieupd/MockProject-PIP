using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClaimRequestRepository:Repository<ClaimRequest>,IClaimRequestRepository
    {
    }
}
