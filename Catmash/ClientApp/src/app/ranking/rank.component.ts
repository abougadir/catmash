import { Component, OnInit } from '@angular/core';
import { VoteResult } from '../core/models/VoteResult.model';
import { VoteService } from '../core/services/vote.service';

@Component({
  selector: 'app-rank',
  templateUrl: './rank.component.html',
  styleUrls: ['./rank.component.css']
})
export class RankComponent implements OnInit {
    public VoteResults: VoteResult[];
    public loading: boolean = true;

    constructor(public voteService: VoteService) { }

  ngOnInit() {
    this.voteService
    .getRanking()
    .subscribe(voteResults => {
      this.VoteResults = voteResults;
      this.loading = false;
    })
  }
}
