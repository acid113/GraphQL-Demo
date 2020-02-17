import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { AnalystNote } from './../Models/AnalystNote';
import { GraphqlRepositoryService } from './../../shared/services/graphqlrepository.service';

@Component({
  selector: 'app-formSample',
  templateUrl: './formSample.component.html',
  styleUrls: ['./formSample.component.css']
})
export class FormSampleComponent implements OnInit {

  public noteFormGroup: FormGroup;

  constructor(private repo: GraphqlRepositoryService) { }

  ngOnInit() {
    // this.note = new NoteHistory();

    this.noteFormGroup = new FormGroup({
      fileTrackingID: new FormControl('')
      , analystNote: new FormControl('')
      , userName: new FormControl('')
    });
  }

  public saveNote(noteFormValue) {
    console.log('saving note');
    console.log(noteFormValue);

    this.repo.insertNote(Number(noteFormValue.fileTrackingID), noteFormValue.analystNote, noteFormValue.userName)
      .subscribe(response => {
        console.log('saving note successful');
      });
  }

  public saveNoteObject(noteFormValue) {
    console.log('saving note object');
    // console.log(noteFormValue);

    const input = new AnalystNote();
    input.FileTrackingID = Number(noteFormValue.fileTrackingID);
    input.Note = noteFormValue.analystNote;
    input.Analyst = noteFormValue.userName;

    console.log(input);

    this.repo.insertNoteObject(input)
        .subscribe(response => {
          console.log('saving note object successful');
          console.log(response);
        });
  }
}
