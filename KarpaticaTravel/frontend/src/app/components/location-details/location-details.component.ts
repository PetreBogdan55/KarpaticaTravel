import { Component, OnInit } from '@angular/core';
import { Review } from 'src/app/models/review';

@Component({
  selector: 'app-location-details',
  templateUrl: './location-details.component.html',
  styleUrls: ['./location-details.component.scss'],
})
export class LocationDetailsComponent implements OnInit {
  public reviews: Review[];
  public location: Location;
  constructor() {}

  ngOnInit(): void {}
}
