import { Component } from '@angular/core';
import { MatDialog, MatDialogModule,MatDialogRef } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TeamsService } from '../../services/teams.service';
import { Team } from '../../models/team';
import { tap } from 'rxjs';
import { TeamSuccessDialogComponent } from '../team-success-dialog/team-success-dialog.component';

@Component({
  selector: 'app-team-form',
  standalone: true,
  imports: [MatInputModule, MatDialogModule, MatButtonModule,ReactiveFormsModule,TeamSuccessDialogComponent],
  templateUrl: './team-form.component.html',
  styleUrl: './team-form.component.scss',
  providers: [TeamsService]
})
export class TeamFormComponent {
  constructor(
    private fb: FormBuilder, 
    private teamService: TeamsService,
    public dialog: MatDialog,
    public dialogRef:MatDialogRef<TeamFormComponent>,){}
  form = this.fb.group({
    name: [null, [Validators.required]],
    city: [null, [Validators.required]],
    year: [null, [Validators.required]]
});

  submit(){
    //console.log(this.form)
    //alert(JSON.stringify(this.form.getRawValue()))
    //console.log("Dodano");
    const team: Team = {
      name:this.form.get('name')?.value,
      city:this.form.get('city')?.value,
      year:this.form.get('year')?.value,
      players:[]
    }
    this.teamService.addTeam$(team)
    .pipe(
      tap(_ => this.openSuccessDialog())
    )
    .subscribe();
  }
  openSuccessDialog(){
    this.dialog.open(TeamSuccessDialogComponent);
  }
}
