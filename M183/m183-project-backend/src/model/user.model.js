import database from "../config/database.js";

const User = {
    id: Number,
    lastname: String,
    firstname: String,
    username: String,
    email: String,
    password: String,
    password_salt: String,

    createNewUser(newUser, callback) {
        database.query('INSERT INTO users (lastname, firstname, username, email, password, password_salt ) VALUES' +
            '(?, ?, ?, ?, ?, ?)', [newUser.lastname, newUser.firstname, newUser.username, newUser.email, newUser.password, newUser.password_salt],
            function (err, res) {
                if (err)  {
                    callback(err, null);
                } else {
                    callback(null, res.insertId);
                }
            });
    },

    findUserByUserName(username, callback) {
        database.query('SELECT * FROM users WHERE username = ?', username, function (err, res) {
            if (err)  {
                callback(err, null);
            } else {
                callback(null, res[0]);
            }
        });
    }
}

export default User;
