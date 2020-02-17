/* References:
- https://www.apollographql.com/docs/angular/basics/queries/
- https://dzone.com/articles/beginners-guide-graphql-angular-apollo
*/

import { Injectable } from '@angular/core';

import { Apollo } from 'apollo-angular';
// import { HttpLink } from 'apollo-angular-link-http';
// import { InMemoryCache } from 'apollo-cache-inmemory';
import gql from 'graphql-tag';

import { AnalystNote } from './../../crud/Models/AnalystNote';

// import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class GraphqlRepositoryService {

  private GetNoteHistoryListQuery = gql`query($fileTrackingID: Int!) {
    GetAnalystNotesHistory(fileTrackingID: $fileTrackingID) {
      analystNotesHistoryID
      analyst
      analystNotes
    }
  }`;

  // with WHERE filter
  // private GetNoteHistoryListQuery = gql`query($fileTrackingID: Int!) {
  //   GetAnalystNotesHistory(fileTrackingID: $fileTrackingID, where: {Contains_Name: \"Marvs\"}) {
  //     analystNotesHistoryID
  //     analyst
  //     analystNotes
  //   }
  // }`;

  private AddNoteMutation = gql`mutation($fileTrackingID: Long!, $analystNotes: String!, $analyst: String!) {
    InsertAnalystNotes(
      fileTrackingID: $fileTrackingID
      note: $analystNotes
      user: $analyst
    )
  }`;

  private AddNoteMutationObject = gql`mutation InsertAnalytNotesObject(
    $fileTrackingID: Long!
    $analystNotes: String
    $analyst: String
  ) {
    InsertAnalytNotesObject(
      input: {
        fileTrackingID: $fileTrackingID
        note: $analystNotes
        analyst: $analyst
      }
    )
  }`;

  constructor(private apollo: Apollo
    // , private httpLink: HttpLink, private envUrl: EnvironmentUrlService
  ) {

    // * Removed since this is already initialized in app.module.ts
    // const graphQLUrl = `${this.envUrl.urlAddress}/graphql`;
    // apollo.create({
    //   link: httpLink.create({ uri: graphQLUrl})
    //   , cache: new InMemoryCache()
    // });
  }

  

  public getNotesHistory(id: number) {
    return this.apollo.query({
      query: this.GetNoteHistoryListQuery
      , variables: { fileTrackingID: id }
    });
  }

  public insertNote(id: number, note: string, userName: string) {
    return this.apollo.mutate({
      mutation: this.AddNoteMutation
      , variables : { fileTrackingID: id, analystNotes: note, analyst: userName }
    });
  }

  public insertNoteObject(input: AnalystNote) {
    return this.apollo.mutate({
      mutation: this.AddNoteMutationObject
      , variables: { fileTrackingID: input.FileTrackingID, analystNotes: input.Note, analyst: input.Analyst }
    });
  }

}
