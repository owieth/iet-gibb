import express from 'express';
import commandController from "../controller/command.controller.js";

const commandRouter = express.Router();

commandRouter.get('', commandController.execute);
commandRouter.get('/list', commandController.getAllCommands);

export default commandRouter;
