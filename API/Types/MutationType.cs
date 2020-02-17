using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using HotChocolate.Types;

namespace API.Types
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            #region Usage
            /* Usage in Playground:
                mutation($fileTrackingID: Long!, $analystNotes: String!, $analyst: String!) {
                  InsertAnalystNotes(
                    fileTrackingID: $fileTrackingID
                    note: $analystNotes
                    user: $analyst
                  )
                }

                Query variables:
                {
                  "fileTrackingID": 1
                  , "analystNotes": "Note added from GraphQL"
                  , "analyst": "Bot 1"
                }
             */
            #endregion
            descriptor
                .Field(x => x.InsertAnalystNotes(default, default, default))
                .Name("InsertAnalystNotes")
                .Description("Inserts an analyst note.")
                .Argument("fileTrackingID", a => a.Description("FileTracking ID input value").Type<NonNullType<LongType>>())
                .Argument("note", b => b.Description("Note to insert").Type<NonNullType<StringType>>())
                .Argument("user", c => c.Description("Name of analyst").Type<NonNullType<StringType>>())
                ;

            #region Usage
            /* Usage in Playground: 
                mutation InsertAnalytNotesObject(
                  $fileTrackingID: Long!
                  $analystNotes: String
                  $analyst: String
                ) {
                  InsertAnalytNotesObject(
                    input: {
                      fileTrackingID: $fileTrackingID
                      analystNotes: $analystNotes
                      analyst: $analyst
                    }
                  )
                }

                Query variables:
                {
                  "fileTrackingID": 1
                  , "note": "Note added from GraphQL by Bot 3"
                  , "user": "Bot 1"
                }
            */
            #endregion
            descriptor
                .Field(x => x.InsertAnalytNotesObject(default))
                .Name("InsertAnalytNotesObject")
                .Description("Inserts an analyst note object.")
                .Argument("input", a => a.Description("Note object input value").Type<NonNullType<InputType>>())
                ;
        }
    }
}
