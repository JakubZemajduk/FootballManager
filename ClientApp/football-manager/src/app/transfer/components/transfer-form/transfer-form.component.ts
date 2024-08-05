import { Component } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { tap } from 'rxjs';
import { TransferDto } from '../../model/transfer.dto';
import { TransferService } from '../../services/transfer.service';
@Component({
  selector: 'app-transfer-form',
  standalone: true,
  imports: [MatInputModule, MatDialogModule, MatButtonModule,ReactiveFormsModule],
  templateUrl: './transfer-form.component.html',
  styleUrl: './transfer-form.component.scss',
  providers: [TransferService]
})
export class TransferFormComponent {
  constructor(private fb: FormBuilder, private transferService: TransferService){}
  form = this.fb.group({
    targetTeamId: [null, [Validators.required]],
    playerId:[null, [Validators.required]]
});
submit(){
  //console.log(this.form)
  //alert(JSON.stringify(this.form.getRawValue()))
  //console.log("Dodano");

  const transfer: TransferDto = {
    targetTeamId:this.form.get('targetTeamId')?.value!,
    playerId:this.form.get('playerId')?.value!
  }

  this.transferService.addTransfer$(transfer)
  .pipe(
    tap(_ => alert('Transfer done!'))
  )
  .subscribe();
}
}

