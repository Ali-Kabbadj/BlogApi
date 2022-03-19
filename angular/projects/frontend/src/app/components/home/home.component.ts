import { Component, OnDestroy, OnInit } from '@angular/core';
import { Article } from 'projects/models/article.interface';
import { ApiService } from 'projects/tools/src/lib/api.service';
import { Subject, Subscription, takeUntil } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  template:`
    <app-pagination [articles]="articles"></app-pagination>
  `
})
export class HomeComponent implements OnInit,OnDestroy {

  articles:Article[]=[];
  sub$ = new Subject();

  constructor(private apiService : ApiService) { }

  ngOnInit(): void {

    this.apiService.getAllArticles().pipe(
      takeUntil(this.sub$)
    ).subscribe(res=> this.articles =res);
    console.log(this.articles.entries);

  }

  ngOnDestroy(): void {


      this.sub$.complete()

  }

}
