import {Component} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { Observable } from 'rxjs';
import { Team } from '../../models/team';
import { TeamsService } from '../../services/teams.service';
import { CommonModule } from '@angular/common';
import { PlayerDto } from '../../models/player.dto';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
  MatDialogModule,
} from '@angular/material/dialog';
import { TeamFormComponent } from '../team-form/team-form.component';
/**
 * @title Table with expandable rows
 */
@Component({
  selector: 'app-teams-list',
  styleUrl: 'teams-list.component.scss',
  templateUrl: 'teams-list.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
  standalone: true,
  imports: [MatTableModule, MatButtonModule, MatIconModule, MatDialogModule, CommonModule],
})
export class TeamsListComponent {
  teams$: Observable<Team[]> = this.teamsService.getTeams$();
  columnsToDisplay = ['id', 'name', 'city', 'year'];
  columnsToDisplayWithExpand = [...this.columnsToDisplay, 'expand'];
  expandedElement: PlayerDto | null=null;

  constructor(private teamsService:TeamsService, private dialog: MatDialog){}

  openDialog(): void {
    const dialogRef = this.dialog.open(TeamFormComponent);
  }
  openPlayerDialog(): void {
    
  }
}
