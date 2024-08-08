import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-player-success-dialog',
  standalone: true,
  imports: [],
  templateUrl: './player-success-dialog.component.html',
  styleUrl: './player-success-dialog.component.scss'
})
export class PlayerSuccessDialogComponent {
  constructor(public dialogRef: MatDialogRef<PlayerSuccessDialogComponent>){}

  closeDialog(){
    this.dialogRef.close();
  }
}
