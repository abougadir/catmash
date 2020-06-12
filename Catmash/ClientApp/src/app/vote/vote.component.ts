import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vote } from '../core/models/vote.model';
import { VoteService } from '../core/services/vote.service';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.css']
})
export class VoteComponent implements OnInit {

    public Vote: Vote;
    public canVote: boolean = false;

    constructor(
    public voteService: VoteService,
    public activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute
      .params
      .subscribe(data => {
        this.initializeVote()
      })
  }

  private initializeVote() { 
    this.voteService
    .fetchNextVote()
    .subscribe(vote => {
      this.Vote = vote;
      this.canVote = true;
    })
  }

  submitVote(isfirstCat: boolean) {
    if (this.Vote != undefined) {
        this.canVote = false;
        this.voteService.chooseCatWinner(this.Vote.id, isfirstCat);
        this.initializeVote();
    }
  }
}
