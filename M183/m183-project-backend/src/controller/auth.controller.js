import jwt from 'jsonwebtoken';
import authService from '../service/auth.service.js'
import logService from "../service/log.service.js";
import TokenExpiredError from "jsonwebtoken/lib/TokenExpiredError.js";

const authController = {
    verify(req, res) {
        const token = req.header('access_token');
        if (!token) {
            res.status(401).send("You are not authorized!");
        } else {
            try {
                res.status(200).json({
                    token: jwt.verify(token, process.env.SERVER_SECRET)
                });
                logService.success('Verified token')
            } catch (err) {
                if (err instanceof TokenExpiredError) {
                    logService.failure('Token in localStorage is expired!');
                } else {
                    logService.failure('Could not verify token!')
                }

                res.status(401).json({error: err.message});
            }
        }
    },

    signUp(req, res) {
        authService.signUp(req.body, (err, callback) => {
            if (callback) {
                logService.success(`Created new User ${req.body.username}`)
                const token = jwt.sign({username: req.body.username}, process.env.SERVER_SECRET, {expiresIn: "15m"});
                res.header('access_token', token).status(200).json({
                    message: `Created User ${req.body.username} with id ${callback}`
                });
            } else {
                logService.failure(`Could not create User ${req.body.username}`)
                res.status(400).json({error: err.message});
            }
        })
    },

    login(req, res) {
        authService.login(req.body, (err, callback) => {
            if (callback) {
                logService.success(`Got User with username ${req.body.username}`)
                const token = jwt.sign({username: req.body.username}, process.env.SERVER_SECRET, {expiresIn: "15m"});
                res.header('access_token', token).status(200).json({
                    message: `Logged in User ${req.body.username} with id ${callback}`
                });
            } else {
                logService.failure(`Could not get User with username ${req.body.username}`)
                res.status(400).json({error: err.message});
            }
        })
    }
};

export default authController;
