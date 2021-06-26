import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MatSnackBar} from '@angular/material/snack-bar';
import {CommandService} from '../../service/command.service';
import {SnackbarService} from '../../service/snackbar.service';

@Component({
  selector: 'app-user',
  templateUrl: './command.component.html',
  styleUrls: ['./command.component.scss']
})
export class CommandComponent implements OnInit {

// @ts-ignore
  formGroup: FormGroup;
  command: string;
  commandResult: string;
  allowedCommands: string[] = [];
  executedCommands: string[] = [];

  constructor(private fb: FormBuilder, private commandService: CommandService, private snackBarService: SnackbarService, private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      commandSelection: ['', Validators.required],
    });

    this.commandService.getAllCommands().subscribe((commands) => {
      // @ts-ignore
      this.allowedCommands = commands.list;
    });
  }

  onSubmit(): void {
    if (this.formGroup.valid) {
      const command = this.formGroup.get('commandSelection')?.value;
      // tslint:disable-next-line:max-line-length
      this.commandService.executeCommand(command).subscribe((result) => {
          // @ts-ignore
          this.commandResult = result.command;
          this.executedCommands.push(command);
          this.snackBarService.openSnackBar(`Successfully executed command ${command}`);
        },
        (err => {
          this.snackBarService.openSnackBar(`${err.error.error}`);
        }));
    }
  }
}
