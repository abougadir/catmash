import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { VoteService } from '../vote.service';
import { VoteResult } from '../models/VoteResult.model';
import { Cat } from '../models/cat.model';

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
