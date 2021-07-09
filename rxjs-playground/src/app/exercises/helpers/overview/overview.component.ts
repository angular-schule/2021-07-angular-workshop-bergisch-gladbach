import { Component, OnInit } from '@angular/core';

import { Exercises } from '../../types';
import { exercisesList } from '../../exercises';

@Component({
  selector: 'rxw-overview',
  templateUrl: './overview.component.html',
})
export class OverviewComponent implements OnInit {

  exercises: Exercises = exercisesList;
  generationDate = 1625832723898;

  ngOnInit() {
  }

}
