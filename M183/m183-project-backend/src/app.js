import express from 'express';
import authRouter from "./router/auth.router.js";
import commandRouter from "./router/command.router.js";
import database from "./config/database.js";
import bodyParser from "body-parser";
import dotenv from 'dotenv';
import cors from 'cors';
import https from 'https';
import fs from 'fs';
import {isAuthenticated} from "./middleware/auth.js";

const app = express();
dotenv.config();

const sqlInitScript = fs.readFileSync('src/resources/init.sql').toString();

app.use(bodyParser.json({limit: "30mb", extended: true}));
app.use(bodyParser.urlencoded({limit: "30mb", extended: true}));

app.use(cors({
    origin: process.env.FRONTEND_URL,
    exposedHeaders: ['access_token']
}));

app.use('/api/auth', authRouter);
app.use('/api/command', isAuthenticated, commandRouter);

const httpsServer = https.createServer({
    key: fs.readFileSync('src/config/serverKey.pem'),
    cert: fs.readFileSync('src/config/certificate.pem'),
}, app);

database.connect((err) => {
    if (err) throw err;

    httpsServer.listen(process.env.PORT, () => {
        console.log(`Server is running on Port: ${process.env.PORT}`)
    });
});

database.query(sqlInitScript, (err) => {
        if (err) throw err;
    }
);
