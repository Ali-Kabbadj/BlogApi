import { Component, OnInit ,Input} from '@angular/core';
import { Article } from 'projects/models/article.interface';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Input() articles:Article[]=[];
  p:number;

  constructor() {
    this.p=0;
   }

  ngOnInit(): void {
  }

}
