import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vote } from '../models/vote.model';
import { VoteResult } from '../models/VoteResult.model';

@Injectable({
  providedIn: 'root'
})
export class VoteService {
  private VOTE_API_URL;
  private RANK_API_URL;
  private readonly PUT_VOTE_URL = (voteId: number) => { return this.VOTE_API_URL + '/' + voteId};
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.VOTE_API_URL = baseUrl + 'api/vote';
    this.RANK_API_URL = baseUrl + 'api/Ranking';
  }

  chooseCatWinner(voteId: number, isfirstCat: boolean) {
    this.http
      .put(this.PUT_VOTE_URL(voteId), isfirstCat).subscribe(() => {
        return true;
      });
  }

  fetchNextVote() {
    return this.http
      .get<Vote>(this.VOTE_API_URL + '/NextGame');
  }

  getRanking() {
    return this.http
      .get<VoteResult[]>(this.RANK_API_URL + '/Get');
  }
}
