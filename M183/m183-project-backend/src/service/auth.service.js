import User from '../model/user.model.js'
import bcrypt from "bcrypt";
import logService from "./log.service.js";

const authService = {
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
}

export default authService;
