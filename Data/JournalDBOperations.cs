using Commons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsCalculator.Models;

namespace Data
{
    public class JournalDBOperations
    {
        public void PersistOperation(OperationDTO operationDTO)
        {
            using (JournalContext db = new JournalContext())
            {
                db.OperationDTOes.Add(operationDTO);
                db.SaveChanges();
            }
        }
        public List<OperationDTO> GetOperationsById(string id)
        {
            using (JournalContext db = new JournalContext())
            {
                List<OperationDTO> operations = db.OperationDTOes.Where(obj => obj.Id == id).ToList<OperationDTO>();
                return operations;
            }
        }
    }
}
