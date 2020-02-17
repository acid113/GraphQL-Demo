using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using API.Models;
using API.Repository;

namespace API
{
    public class Query
    {
        private readonly IDataProfileRepository _dataProfileRepository;

        public Query(IDataProfileRepository dataProfileRepository)
        {
            _dataProfileRepository = dataProfileRepository 
                ?? throw new ArgumentNullException(nameof(dataProfileRepository));
        }

        public async Task<FileLog> GetFileLog(int fileLogID)
        {
            return await _dataProfileRepository.GetFileLog(fileLogID);
        }

        public async Task<List<AnalystNote>> GetAnalystNotesHistory(int fileTrackingID)
        {
            return await _dataProfileRepository.GetAnalystNotesHistory(fileTrackingID);
        }

        //public async Task<AnalystNote> GetAnalystNote(int fileTrackingID, int analystNotesHistID)
        //{
        //    return await _dataProfileRepository.GetAnalystNote(fileTrackingID, analystNotesHistID);
        //}


    }
}
