import { Component, OnInit } from '@angular/core';

import { NoteHistory } from './../interfaces/NoteHistory';
import { CustomDataResponse } from './../interfaces/CustomDataResponse';

import { RepositoryService } from './../../shared/services/repository.service';
import { GraphqlRepositoryService } from './../../shared/services/graphqlrepository.service';

@Component({
  selector: 'app-gridSample',
  templateUrl: './gridSample.component.html',
  styleUrls: ['./gridSample.component.css']
})

export class GridSampleComponent implements OnInit {

  public notesHistory: NoteHistory[];

  constructor(private repo: RepositoryService, private graphQLRepo: GraphqlRepositoryService) { }

  ngOnInit() {
    // this.getNotesHistoryUsingHTTP(1);
    this.getNotesHistoryUsingGraphQL(1);
  }

  public getNotesHistoryUsingGraphQL(fileTrackingID: number) {
    this.notesHistory = [];

    this.graphQLRepo.getNotesHistory(fileTrackingID)
      .subscribe( (response: CustomDataResponse) => {
        console.log('From GraphQL client.');
        console.log(response.data);
        this.notesHistory = response.data.GetAnalystNotesHistory as NoteHistory[];
    });
  }

  /*
  public getNotesHistoryUsingHTTP(fileTrackingID: number) {
    const query = 'graphql?query={GetAnalystNotesHistory(fileTrackingID:' + fileTrackingID + '){analystNotesHistoryID analyst analystNotes}}';
    // console.log(query);

    this.repo.getData(query)
      .subscribe( (response: CustomDataResponse) => {
        console.log('From HTTP client.');
        this.notesHistory = [];
        console.log(response.data.GetAnalystNotesHistory);
        this.notesHistory = response.data.GetAnalystNotesHistory as NoteHistory[];
      });
  }
  */

}
