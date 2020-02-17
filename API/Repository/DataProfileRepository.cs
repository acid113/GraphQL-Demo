using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using API.Models;

namespace API.Repository
{
    public interface IDataProfileRepository
    {
        Task<FileLog> GetFileLog(int fileLogID);
        Task<List<AnalystNote>> GetAnalystNotesHistory(int fileTrackingID);
        bool InsertAnalystNotes(int fileTrackingID, string note, string user);
        bool InsertAnalytNotesObject(AnalystNoteInput input);
        //Task<AnalystNote> GetAnalystNote(int fileTrackingID, int analystNotesHistoryID);
    }

    public class DataProfileRepository : IDataProfileRepository
    {
        private readonly DataProfileDBContext _dataProfileDBContext;
        private readonly CustomDataProfileDBContext _customDataProfileDBContext;

        public DataProfileRepository(DataProfileDBContext dataProfileDBContext
            , CustomDataProfileDBContext customDataProfileDBContext
        )
        {
            _dataProfileDBContext = dataProfileDBContext;
            _customDataProfileDBContext = customDataProfileDBContext;
        }

        public async Task<FileLog> GetFileLog(int fileLogID)
        {
            var fileLog = await _dataProfileDBContext.FileLog.Include(x => x.FileTracking)
                    .SingleOrDefaultAsync(y => y.FileLogId == fileLogID);
            
            return fileLog;
        }

        public async Task<List<AnalystNote>> GetAnalystNotesHistory(int fileTrackingID)
        {
            var notes = new List<AnalystNote>();
            try
            {
                notes = await _customDataProfileDBContext.AnalystNote.FromSqlInterpolated($"EXECUTE dbo.uspGetAnalystNotesHistory {fileTrackingID}").ToListAsync();
            }
            catch (Exception ex)
            {

            }

            return notes;
        }

        public bool InsertAnalystNotes(int fileTrackingID, string note, string user)
        {
            bool isSuccess = false;

            try
            {
                _dataProfileDBContext.Database.ExecuteSqlInterpolated($"uspInsertAnalystNotes {fileTrackingID}, {note}, {user}");

                isSuccess = true;
            }
            catch (Exception ex)
            {

            }

            return isSuccess;
        }

        public bool InsertAnalytNotesObject(AnalystNoteInput input)
        {
            bool isSuccess = false;

            try
            {
                var fileTrackingID = input.FileTrackingID;
                var note = input.Note;
                var analyst = input.Analyst;

                _dataProfileDBContext.Database.ExecuteSqlInterpolated($"uspInsertAnalystNotes {fileTrackingID}, {note}, {analyst}");

                isSuccess = true;
            }
            catch (Exception ex)
            {

            }

            return isSuccess;
        }

        //public async Task<AnalystNote> GetAnalystNote(int fileTrackingID, int analystNotesHistoryID)
        //{
        //    AnalystNote note = null;

        //    try
        //    {
        //        //NOTE: Error when using SingleOrDefault(). Use ToList() even if it returns only a single record.  
        //        //var data = _customDataProfileDBContext.AnalystNote.FromSqlInterpolated($"EXECUTE dbo.uspGetAnalystNotesHistoryById {fileTrackingID}, {analystNotesHistID}").ToList();

        //        var data = await _customDataProfileDBContext.AnalystNote.FromSqlInterpolated($"EXECUTE dbo.uspGetAnalystNotesHistoryById {fileTrackingID}, {analystNotesHistoryID}").ToListAsync();

        //        if (data.Any())
        //        {
        //            note = data.FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return note;
        //}
        
    }
}
