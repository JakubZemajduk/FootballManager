import { Component } from '@angular/core';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { PlayerService } from '../services/player.service';
import { PlayerDto } from '../teams/models/player.dto';
import { tap } from 'rxjs';
import { PlayerSuccessDialogComponent } from './player-success-dialog/player-success-dialog.component';

@Component({
  selector: 'app-player-form',
  standalone: true,
  imports: [MatInputModule, MatDialogModule, MatButtonModule,ReactiveFormsModule,PlayerSuccessDialogComponent],
  templateUrl: './player-form.component.html',
  styleUrl: './player-form.component.scss',
  providers: [PlayerService]
})
export class PlayerFormComponent {
  constructor(
    private fb: FormBuilder, 
    public dialog: MatDialog,
    public dialogRef:MatDialogRef<PlayerFormComponent>,
    private playerService: PlayerService){}
  form = this.fb.group({
    teamId: [null, [Validators.required]],
    name: [null, [Validators.required]],
    surname: [null, [Validators.required]],
    year: [null, [Validators.required]],
    position: [null, [Validators.required]]
});
submit(){
  //console.log(this.form)
  //alert(JSON.stringify(this.form.getRawValue()))
  //console.log("Dodano");

  const player: PlayerDto = {
    teamId:this.form.get('teamId')?.value!,
    name:this.form.get('name')?.value!,
    surname:this.form.get('surname')?.value!,
    year:this.form.get('year')?.value!,
    position:this.form.get('position')?.value!
  }

  this.playerService.addPlayer$(player)
  .pipe(
    tap(_ => this.openSuccessDialog())
  )
  .subscribe();
}
  openSuccessDialog(){
    this.dialog.open(PlayerSuccessDialogComponent);
  }
}
