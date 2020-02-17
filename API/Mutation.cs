using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repository;

namespace API
{
    public class Mutation
    {
        private readonly IDataProfileRepository _dataProfileRepository;

        public Mutation(IDataProfileRepository dataProfileRepository)
        {
            _dataProfileRepository = dataProfileRepository 
                ?? throw new ArgumentNullException(nameof(dataProfileRepository));
        }

        public bool InsertAnalystNotes(int fileTrackingID, string note, string user)
        {
            if (string.IsNullOrEmpty(note))
                return false;

            return _dataProfileRepository.InsertAnalystNotes(fileTrackingID, note, user);
        }

        public bool InsertAnalytNotesObject(AnalystNoteInput input)
        {
            if (string.IsNullOrEmpty(input.Note))
                return false;

            return _dataProfileRepository.InsertAnalytNotesObject(input);
        }
    }
}
