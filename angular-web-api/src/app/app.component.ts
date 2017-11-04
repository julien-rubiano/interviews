import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private appService: AppService) {}

  title = 'app';
  webApiValues: string[];

  ngOnInit() {
    this.appService.getValues().subscribe(data => {
      this.webApiValues = data;
    });
  }
}
