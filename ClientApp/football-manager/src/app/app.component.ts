import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TeamsService } from './teams/services/teams.service';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { Team } from './teams/models/team';
import { HttpClientModule } from '@angular/common/http';
import { TeamsListComponent } from './teams/components/teams-list/teams-list.component';
import { PlayerFormComponent } from './player-form/player-form.component';
import { PlayerService } from './services/player.service';
import { TransferService } from './transfer/services/transfer.service';
import { TransferFormComponent } from './transfer/components/transfer-form/transfer-form.component';
import { TransferSuccessDialogComponent } from './transfer/components/transfer-success-dialog/transfer-success-dialog.component';
import { TeamSuccessDialogComponent } from './teams/components/team-success-dialog/team-success-dialog.component';
import { PlayerSuccessDialogComponent } from './player-form/player-success-dialog/player-success-dialog.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HttpClientModule,TeamsListComponent,TransferSuccessDialogComponent,TeamSuccessDialogComponent, PlayerSuccessDialogComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss', 
  providers: [TeamsService,PlayerService,TransferService]
})
export class AppComponent {
  title = 'football-manager';
  teams$: Observable<Team[]> = this.teamsService.getTeams$();
  constructor(private teamsService:TeamsService){}
}
