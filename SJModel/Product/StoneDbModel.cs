using SJModel.Core;
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.Product
{

    public class StoneDbModel : BaseModel
    {
        //  MainContainer DB = new MainContainer();

        public StoneDbModel(MainContainer DB) : base(DB) { }
        public StoneDbModel(IDatabaseFactory iFactory) : base(iFactory) { }
        public Stone GetStoneModel(int stoneId)
        {
            if (stoneId == 0)
                return null;

            Stone stone = DB.Stones.FirstOrDefault(x => x.StoneId == stoneId);
            return stone;

        }

        public void UpdateStone(Stone stone)
        {

            if (stone == null || stone.StoneId == 0)
                return;

            Stone stoneFromDb = GetStoneModel(stone.StoneId);
            if (stoneFromDb != null)
            {
                stoneFromDb.StoneName = stone.StoneName;
                DB.SaveChanges();
            }
        }


        public void SaveStone(Stone stone)
        {
            if (stone == null)
                return;

            DB.Stones.Add(stone);
            DB.SaveChanges();

        }
        public List<Stone> GetAllStonesFromDB()
        {
            List<Stone> allStone = new List<Stone>();
            allStone = DB.Stones.Where(x => x.IsActive!=null && x.IsActive.Value).ToList();
            return allStone;
        }

        public void DeleteStone(int stoneId)
        {
            if (stoneId == 0)
                return;
            Stone stone = DB.Stones.FirstOrDefault(x => x.StoneId == stoneId);
           
            if (stone != null)
            {
                stone.IsActive = false;
                DB.SaveChanges();
            }
        }
    }
}
