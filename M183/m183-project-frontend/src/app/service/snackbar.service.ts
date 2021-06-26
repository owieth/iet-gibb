import {Component, ElementRef, Injectable} from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';
import {ComponentType} from '@angular/cdk/overlay';

export enum SnackBarType {
  SUCCESS,
  ERROR
}

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  durationInSeconds = 3;

  constructor(private _snackBar: MatSnackBar) {}

  openSnackBar(message: string): void {
    // @ts-ignore
    this._snackBar.open(message, '',{
      duration: this.durationInSeconds * 1000,
    });
  }
}
