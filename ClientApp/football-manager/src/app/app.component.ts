import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TeamsService } from './teams/services/teams.service';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Team } from './teams/models/team';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss', 
  providers: [TeamsService]
})
export class AppComponent {
  title = 'football-manager';
  teams$: Observable<Team[]> = this.teamsService.getTeams$();
  constructor(private teamsService:TeamsService){}
}
