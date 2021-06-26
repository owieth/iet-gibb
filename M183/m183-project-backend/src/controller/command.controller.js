import commandService from "../service/command.service.js";
import logService from "../service/log.service.js";

const commandController = {
    execute(req, res) {
        commandService.execute(req.query.command, (err, callback) => {
            if (callback) {
                logService.success(`Executed Command ${req.query.command}`);
                res.status(200).json({
                    command: callback
                });
            } else {
                logService.failure(`Could not execute command ${req.query.command}`)
                res.status(400).json({error: `Error while executing command ${req.query.command}`});
            }
        })
    },

    getAllCommands(req, res) {
        commandService.getAllCommands((callback) => {
            logService.success('Got all available Commands!');
            res.status(200).json({
                list: callback
            });
        })
    }
};

export default commandController;
