using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJModel.Data;
using SJModel.Core;

namespace SJModel.Product
{
    public class FindingDbModel:BaseModel
    {
        //  MainContainer DB = new MainContainer();

        public FindingDbModel(MainContainer DB):base(DB) { }
        public FindingDbModel(IDatabaseFactory iFactory) : base(iFactory) { }
        public Finding GetFindingModel(int findingId)
        {
            if (findingId == 0)
                return null;

            Finding finding = DB.Findings.FirstOrDefault(x => x.FindingId == findingId);
            return finding;

        }

        public void UpdateFinding(Finding finding)
        {

            if (finding == null || finding.FindingId == 0)
                return;

            Finding findingFromDb = GetFindingModel(finding.FindingId);
            if (findingFromDb != null)
            {
                findingFromDb.FindingName = finding.FindingName;
                DB.SaveChanges();
            }

        }


        public void SaveFinding(Finding finding)
        {

            if (finding == null)
                return;

            DB.Findings.Add(finding);
            DB.SaveChanges();

        }
        public List<Finding> GetAllFindingsFromDB()
        {
            List<Finding> allFinding = new List<Finding>();
            allFinding= DB.Findings.Select(x => x).ToList();
            return allFinding;
        }
    }
}
