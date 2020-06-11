import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Vote } from './models/vote.model';
import { VoteResult } from './models/VoteResult.model';

@Injectable({
  providedIn: 'root'
})
export class VoteService {
  private readonly VOTE_API_URL = environment.apiUrl + 'vote/';
  private readonly RANK_API_URL = environment.apiUrl + 'Ranking/';
  private readonly PUT_VOTE_URL = (voteId: number) => { return this.VOTE_API_URL + voteId};
  constructor(private http: HttpClient) 
  {
  }

  chooseCatWinner(voteId: number, isfirstCat: boolean) {
    this.http
      .put(this.PUT_VOTE_URL(voteId), isfirstCat).subscribe(() => {
        return true;
      });
  }

  fetchNextVote() {
    return this.http
      .get<Vote>(this.VOTE_API_URL + 'NextGame');
  }

  getRanking() {
    return this.http
      .get<VoteResult[]>(this.RANK_API_URL + 'Get');
  }
}
