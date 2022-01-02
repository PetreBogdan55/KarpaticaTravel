import { Component, OnInit } from '@angular/core';
import { Review } from 'src/app/models/review';
import { Location } from 'src/app/models/location';
import { ApiService } from 'src/app/services/api.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-location-details',
  templateUrl: './location-details.component.html',
  styleUrls: ['./location-details.component.scss'],
})
export class LocationDetailsComponent implements OnInit {
  public reviews: Review[];
  public location: Location;

  constructor(
    private apiService: ApiService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      let apiLocation = this.apiService.getLocation(params['id']);
      apiLocation.subscribe((next: any) => {
        this.location = next as Location;
      });
    });
  }
}
