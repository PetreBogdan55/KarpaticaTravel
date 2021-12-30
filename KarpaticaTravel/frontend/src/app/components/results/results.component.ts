import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SearchService } from 'src/app/services/search.service';
import { Location } from 'src/app/models/location';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss'],
})
export class ResultsComponent implements OnInit {
  public locations: Location[];
  constructor(
    private _router: Router,
    public searchService: SearchService,
    private toastr: ToastrService //private apiService: ApiService
  ) {
    console.log(this.searchService.searchFiltersObject);
  }

  ngOnInit(): void {}
}
