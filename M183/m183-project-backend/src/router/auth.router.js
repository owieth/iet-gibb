import express from 'express';
import authController from "../controller/auth.controller.js";
import {isAuthenticated} from "../middleware/auth.js";

const authRouter = express.Router();

authRouter.post('', authController.verify);
authRouter.post('/signup', authController.signUp);
authRouter.post('/login', authController.login);

export default authRouter;
