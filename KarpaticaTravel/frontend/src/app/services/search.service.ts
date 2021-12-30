import { SearchFilters } from './../models/searchFilters';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class SearchService {
  public searchFiltersObject = new SearchFilters();

  constructor() {}

  getFilteredResults() {}
}
