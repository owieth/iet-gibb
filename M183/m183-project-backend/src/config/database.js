import mysql from "mysql";

const database = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'm183_database',
    multipleStatements: true
});

export default database;
