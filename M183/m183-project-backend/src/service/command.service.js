import {exec} from 'child_process';
import logService from "./log.service.js";

const forbiddenCommands = [
    "C",
    "L",
    "S",
    "F",
    "G",
    "H",
];

const commandService = {
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

    getAllCommands(callback) {
        exec('help', (err, stdout) => {
            const upperCaseWords = stdout.match(/([\r\n]+\b[A-Z][A-Z]+|\b[A-Z]\b)/g);
            const words = [...upperCaseWords];
            logService.info('Processing wrapping of commands')

            words.slice().forEach(word => {
                if (forbiddenCommands.includes(word)) {
                    words.splice(words.indexOf(word), 1);
                }

                words[words.indexOf(word)] = word.replace('\r\n', '');
            })
            callback(words);
        });
    }
};

export default commandService;
