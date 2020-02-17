/* References:
 * https://hotchocolate.io/docs/filters
 * https://github.com/ChilliCream/hotchocolate/issues/412
*/

using API.Models;
using HotChocolate.Types.Filters;

namespace API.Filter
{
    public class AnalystNotesFilter : FilterInputType<AnalystNote>
    {
        protected override void Configure(IFilterInputTypeDescriptor<AnalystNote> descriptor)
        {
            /* Filter Limitations?
             * - "Contains" is case sensitive, "notes" will not include "NOTES"
             */
            descriptor
                .BindFieldsExplicitly()
                .Filter(x => x.Analyst)
                //.BindOperationsExplicitly
                .AllowEquals().Name("equals").And()
                .AllowContains().Name("Contains_Name")
            ;

            descriptor
                .BindFieldsExplicitly()
                .Filter(x => x.AnalystNotes)
                .AllowContains().Name("Contains_Note")
                ;
        }
    }

    //public class FileLogFilter: FilterInputType<FileLog>
    //{
    //    protected override void Configure(IFilterInputTypeDescriptor<FileLog> descriptor)
    //    {
    //        descriptor
    //            .BindFieldsExplicitly()
    //            .Filter(x => x.FileTracking)
    //        ;
    //    }
    //}
}
