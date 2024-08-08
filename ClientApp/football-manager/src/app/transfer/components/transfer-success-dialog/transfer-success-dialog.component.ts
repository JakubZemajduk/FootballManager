import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-transfer-success-dialog',
  standalone: true,
  imports: [],
  templateUrl: './transfer-success-dialog.component.html',
  styleUrl: './transfer-success-dialog.component.scss'
})
export class TransferSuccessDialogComponent {
  constructor(public dialogRef: MatDialogRef<TransferSuccessDialogComponent>){}

  closeDialog(){
    this.dialogRef.close();
  }
}
