import { Component } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TeamsService } from '../../services/teams.service';
import { Team } from '../../models/team';
import { tap } from 'rxjs';
import { PlayerDto } from '../../models/player.dto';

@Component({
  selector: 'app-team-form',
  standalone: true,
  imports: [MatInputModule, MatDialogModule, MatButtonModule,ReactiveFormsModule],
  templateUrl: './team-form.component.html',
  styleUrl: './team-form.component.scss',
  providers: [TeamsService]
})
export class TeamFormComponent {
  constructor(private fb: FormBuilder, private teamService: TeamsService){}
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
      tap(_ => alert('Team added!'))
    )
    .subscribe();
  }
}
