# Dokumentation M183-Frontend

In dieser kurzen Dokumentation werden die verschiedenen Features des Frontends (Angular) beschrieben.

## Login

In der Logincomponete werden die beiden Attribute 'Username' & 'Password' durch den Benutzer abgefüllt. Falls das
Backend einen Code 200 zurückgibt, wird das erhaltene Accesstoken in den Localstorage gespeichert und der Benutzer wird
automatisch auf die Kommandoseite weitergeleitet.

Im Service wird eine POST Reqeust ausgeführt, welche die Userdaten enthalten.

### login.component.ts

````
  loginUser(): void {
      if (this.loginFormGroup.valid) {
        this.authService.login(this.loginFormGroup.value).subscribe(res => {
            // @ts-ignore
            if (res.body.message) {
              this.authService.setToken(res.headers.get('access_token'));
              this.router.navigateByUrl('');
            }
          },
          (err => {
            this.snackBarService.openSnackBar(`${err.error}`);
          }));
      }
    }
````

### auth.service.ts

````
  login(user: User): Observable<HttpResponse<string>> {
    return this.http.post<string>(this.url + '/login', user, {observe: 'response'});
  }
````

## Signup / Register new User

Das Prinzip des Registrieren ist fast identisch wie beim Loginvorgang

### signup.component.ts

````
  signUpUser(): void {
    this.authService.signUp(this.signUpFormGroup.value).subscribe(res => {
        // @ts-ignore
        if (res.body.message) {
          this.authService.setToken(res.headers.get('access_token'));
          this.router.navigateByUrl('');
        }
      },
      (err => {
        this.snackBarService.openSnackBar(`${err.error}`);
      }));
  }
````

### auth.service.ts

````
  signUp(user: User): Observable<HttpResponse<string>> {
    return this.http.post<string>(this.url + '/signup', user, {observe: 'response'});
  }
````

## Session Handling

Im Frontend wird der CommandComponent erst freigegeben, wenn ein Token vorhanden ist. Dies wird mit dem auth.guard.ts
geregelt. Im auth.service.ts wird das Token bei Requests aus dem Header in den Localstorage gespeichert.

Im app.component.ts wird überprüft ob bereits ein Token vorhanden ist. Wenn eines vorhanden ist, wird man direkt von der
Loginseite auf die Commandseite weitergeleitet.

### auth.guard.ts

```
  canActivate(): boolean {
    if (!this.authService.isAuthenticated()) {
      this.router.navigateByUrl('login');
      return false;
    }
    return true;
  }
```

### auth.service.ts

```
  get token(): string {
    return localStorage.getItem('access_token') || '';
  }

  setToken(token: string | null): void {
    if (typeof token === 'string') {
      localStorage.setItem('access_token', token);
    }
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('access_token');
    // @ts-ignore
    return !this.jwtHelper.isTokenExpired(token);
  }
```

### app.component.ts

````
  ngOnInit(): void {
    this.authService.verify().subscribe((res) => {
        // @ts-ignore
        if (res.body.token && this.router.url !== '/signup') {
          this.router.navigateByUrl('');
        }
      },
      (err => {
        if (err.error.error === 'jwt expired') {
          localStorage.removeItem('access_token');
          this.snackBarService.openSnackBar('Token is expired! Please login again');
        } else {
          this.snackBarService.openSnackBar(`${err.error}`);
        }
      }));
  }
````

## Systemkommandos

Zuerst werden alle verfügbaren Commands (CMD) in eine Liste geladen. So kann der Benutzer nur diese bestimmtem Commands
ausführen. Wenn der Benutzer einen Command ausführt, wird dieser im Backend ausgeführt und das Resultat wird im Frontend
direkt dargestellt.

### command.service.ts

```
  getAllCommands(): Observable<string[]> {
    return this.http.get<string[]>(this.url + '/list', {
      headers: {access_token: this.authService.token}
    });
  }

  executeCommand(command: string): Observable<string> {
    return this.http.get<string>(this.url, {
      params: new HttpParams().set('command', command),
      headers: {access_token: this.authService.token}
    });
  }
```

## Messaging

Für das Messagehandling wird eine Snackbar aus Angular Material verwendet. Für Error- und Success Meldungen wird diese
verwendet. Sie verschwiendet automatisch nach drei Sekunden.

### snackbar.service.ts

```
  openSnackBar(message: string): void {
    // @ts-ignore
    this._snackBar.open(message, '',{
      duration: this.durationInSeconds * 1000,
    });
  }
  
  this.snackBarService.openSnackBar(`Successfully executed command ${command}`);
```

## SSL / TLS

Im angular.json werden die Zertifikate des Backends verwendet. Zusätzlich wurde
das Zertifikat lokal auf dem Computer heruntergeladen.

### angular.json
````
"serve": {
  "builder": "@angular-devkit/build-angular:dev-server",
  "options": {
  "browserTarget": "m183-frontend:build",
    "ssl": true,
    "sslKey": "../m183-project-backend/src/config/serverKey.pem",
    "sslCert": "../m183-project-backend/src/config/certificate.pem"
  },
````

