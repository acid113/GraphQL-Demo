using API.Filter;
using HotChocolate.Types;


namespace API.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field(x => x.GetFileLog(default))
                .Name("GetFileLog")
                .Argument("fileLogID", x => x.Description("FileLogID input value").Type<NonNullType<IntType>>())
                .Description("Gets File Log data.")
                //.UseFiltering<FileLogFilter>();   //Filter for List type property not yet supported?
                ;

            //descriptor
            //    .Field(x => x.GetAnalystNote(default, default))
            //    .Name("GetAnalystNote")
            //    .Description("Gets a single analyst note.")
            //    ;

            descriptor
                .Field(x => x.GetAnalystNotesHistory(default))
                .Name("GetAnalystNotesHistory")
                .Argument("fileTrackingID", x => x.Description("FileTracking ID input value").Type<NonNullType<IntType>>())
                .Description("Gets the analyst notes history.")
                .UseFiltering<AnalystNotesFilter>()
                ;
        }
    }
}
