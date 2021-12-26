import { SearchFilters } from './../models/searchFilters';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  searchFiltersObject = new SearchFilters();

  constructor() {}
}
