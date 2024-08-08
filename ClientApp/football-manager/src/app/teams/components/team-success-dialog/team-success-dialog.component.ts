import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-team-success-dialog',
  standalone: true,
  imports: [],
  templateUrl: './team-success-dialog.component.html',
  styleUrl: './team-success-dialog.component.scss'
})
export class TeamSuccessDialogComponent {
  constructor(public dialogRef: MatDialogRef<TeamSuccessDialogComponent>){}

  closeDialog(){
    this.dialogRef.close();
  }
}
