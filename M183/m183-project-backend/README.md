# Dokumentation M183-Backend

In dieser kurzen Dokumentation werden die implementierten Sicherheitsfeatures des Backends (NodeJS) genauer beschrieben.

## Login

Zuerst wird in der Loginmethode überprüft, ob der angegebene Username in der Datenbank enthalten ist. Falls dies nicht
der Fall ist, wird eine Fehlernachricht an den Benutzer zurückgegeben. Wenn der User gefunden wurde, wird das
gespeicherte Password mit dem Passwort aus der Request verglichen. Der User wird zurückgegeben, wenn die Passwörter
übereinstimmen.

### auth.service.js

```
login(user, callback) {
        User.findUserByUserName(user.username, (err, res) => {
            if (err || res === undefined) {
                logService.failure(`User ${user.username} not found!`)
                callback(err, res);
            } else {
                bcrypt.compare(user.password, res.password, (error, result) => {
                    if (error || !result) {
                        logService.failure("Could not compare password")
                        callback(error, null);
                    } else {
                        logService.info(`Password of User ${user.username} did match!`)
                        callback(null, result);
                    }
                })
            }
        })
    }
```

## Signup / Register new User

Wenn ein neuer User erstellt werden soll, wird zuerst überprüft ob bereits ein User mit dem angegebenen Username
existiert. Wenn der Benutzername einzigartig ist, wird zuerst ein Salt mit 10 Saltrounds erstellt, der dann direkt mit
dem gehashten Passwort vermischt wird. Die beiden Hashes werden dem neuen Benutzer zugewiesen und anschliessend wird der
Benutzer in der Datenbank angelegt.

### auth.service.js

````
    signUp(newUser, callback) {
        User.findUserByUserName(newUser.username, (err, existingUser) => {
            if (existingUser) {
                logService.failure("User already exists!")
                callback({message: 'User already exists'}, null);
            } else {
                bcrypt.genSalt(10, function (err, salt) {
                    bcrypt.hash(newUser.password, salt, function (err, hash) {
                        newUser.password = hash;
                        newUser.password_salt = salt;
                        logService.info('Generated hash for user\'s password!')

                        if (!err) {
                            User.createNewUser(newUser, (err, user) => {
                                if (err || !user) {
                                    logService.failure(`User ${newUser.username} could not be created!`)
                                    callback(err, null);
                                } else {
                                    callback(null, user);
                                }
                            })
                        }
                    });
                });
            }
        })
    },
````

## Session Handling

Für jeden Benutzer wird ein Token generiert. Dieses ist 15 Minuten gültig und danach muss man sich erneut anmelden. Das
Token wird mit dem Benutzernamen, mit einem Serversecret und der zeitlichen Gültigkeit signiert. Das Token wird jeweils
im Responseheader zurückgeschickt und im Localstorage hinterlegt.

### auth.controller.js

```
    const token = jwt.sign({username: req.body.username}, process.env.SERVER_SECRET, {expiresIn: "15m"});
    res.header('access_token', token).status(200).json({
            message: `Created User ${req.body.username} with id ${callback}`
    });
```

## Systemkommandos

Durch das importierte Modul 'child_prozess' ist es möglich, Kommandos auf der Serverseite auszuführen. Das Ergebnis des
Commands wird an das Frontend zurückgegeben. Im Frontend werden dabei alle verfügbaren Kommandos (CMD) angezeigt.

### command.service.js

```
    execute(command, callback) {
        exec(command, (err, stdout) => {
            if (err && !stdout) {
                logService.failure(`Failed to execute command ${command}`)
                callback(err, null)
            } else {
                logService.info(`Executed ${command}`)
                callback(null, stdout);
            }
        });
    },
```

## Logging

Dieser Service dient dem serverseitigem Logging. Es gibt drei verschiedene Varianten von Logmessages:
INFO, SUCCESS & FAILURE. Das INFO-Level wird für die Verarbeitung von Daten in den Services verwendet. Bei Fehlern
überall im Code wird das Level FAILURE verwendet und in den Controllern bei der erfolgreichen Abfrage eine SUCCESS
Meldung.

### log.service.js

```
    info(message) {
        console.log(`[logservice] ${getTimestamp()} INFO : ${message}`)
    },

    success(message) {
        console.log(chalk.green(`[logservice] ${getTimestamp()} SUCCESS : ${message}`))
    },

    failure(message) {
        console.log(chalk.red(`[logservice] ${getTimestamp()} ERROR : ${message}`))
    }
```

## Passwortspeicherung

Für jeden neuen User wird jeweils ein Salt generiert. Dieser besteht aus 10 Saltrounds. Nachdem der Salt erstellt wurde,
wird ein Hash aus dem Passwort (Aus Requestbody) und dem Salt generiert. Das Passwort und der Salt überschreiben dann
die Attribute des user.model.ts auf die verschlüsselten Values. Anschliessend wird der User mittels einem SQL-Query
erstellt.

### auth.service.js

```
    bcrypt.genSalt(10, function (err, salt) {
                        bcrypt.hash(newUser.password, salt, function (err, hash) {
                            newUser.password = hash;
                            newUser.password_salt = salt;
                            logService.info('Generated hash for user\'s password!')
    
                            if (!err) {
                                User.createNewUser(newUser, (err, user) => {
                                    if (err || !user) {
                                        logService.failure(`User ${newUser.username} could not be created!`)
                                        callback(err, null);
                                    } else {
                                        callback(null, user);
                                    }
                                })
                            }
                        });
                    });
```

## SSL / TLS

Ein HttpsServer wird mittels zwei Zertifikaten erstellt. Die Expressapp verwendet anschliessend diesen
Server. In der .env Datei ist definiert, von welcher Route CORS einen Zugriff zulässt. 

### app.js
```
const httpsServer = https.createServer({
    key: fs.readFileSync('src/config/serverKey.pem'),
    cert: fs.readFileSync('src/config/certificate.pem'),
}, app);
```

### .env
```
FRONTEND_URL="https://localhost:4200"
```