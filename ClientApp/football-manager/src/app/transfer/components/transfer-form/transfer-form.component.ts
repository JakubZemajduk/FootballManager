import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { tap } from 'rxjs';
import { TransferDto } from '../../model/transfer.dto';
import { TransferService } from '../../services/transfer.service';
import { TeamsService } from '../../../teams/services/teams.service';
import { PlayerService } from '../../../services/player.service';
import { TransferSuccessDialogComponent } from '../transfer-success-dialog/transfer-success-dialog.component';
@Component({
  selector: 'app-transfer-form',
  standalone: true,
  imports: [MatInputModule, MatDialogModule, MatButtonModule,ReactiveFormsModule,MatOptionModule,MatSelectModule,CommonModule,TransferSuccessDialogComponent],
  templateUrl: './transfer-form.component.html',
  styleUrl: './transfer-form.component.scss',
  providers: [TransferService,TeamsService,PlayerService]
})
export class TransferFormComponent implements OnInit{
  teams: any[] = [];  
  players: any[] = [];  
  constructor(
    private fb: FormBuilder, 
    public dialog: MatDialog,
    public dialogRef:MatDialogRef<TransferFormComponent>,
    private transferService: TransferService,
    private teamService: TeamsService,
    private playerService: PlayerService){}
  form = this.fb.group({
    sourceTeamId: [null, [Validators.required]],
    targetTeamId: [null, [Validators.required]],
    playerId:[null, [Validators.required]]
});
ngOnInit() {
  this.teamService.getTeams$().subscribe(teams => {
    this.teams = teams;
  });
}

onSourceTeamChange(event: any) {
  const teamId = event.value;
  if (teamId) {
    this.playerService.getPlayersByTeam(teamId).subscribe(players => {
      this.players = players;
      this.form.get('playerId')
    });
  } else {
    this.players = [];
    this.form.get('playerId')?.reset();
  }
}

submit(){
  //console.log(this.form)
  //alert(JSON.stringify(this.form.getRawValue()))
  //console.log("Dodano");

  const transfer: TransferDto = {
    sourceTeamId:this.form.get('sourceTeamId')?.value!,
    targetTeamId:this.form.get('targetTeamId')?.value!,
    playerId:this.form.get('playerId')?.value!
  }

  this.transferService.addTransfer$(transfer)
  .pipe(
    tap(_ => this.openSuccessDialog())
  )
  .subscribe();
}
  openSuccessDialog(){
    this.dialog.open(TransferSuccessDialogComponent);
  }
}

