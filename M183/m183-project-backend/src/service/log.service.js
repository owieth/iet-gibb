import chalk from 'chalk';

const logService = {
    info(message) {
        console.log(`[logservice] ${getTimestamp()} INFO : ${message}`)
    },

    success(message) {
        console.log(chalk.green(`[logservice] ${getTimestamp()} SUCCESS : ${message}`))
    },

    failure(message) {
        console.log(chalk.red(`[logservice] ${getTimestamp()} ERROR : ${message}`))
    }
};

function getTimestamp() {
    const currentDate = new Date();
    return `${currentDate.getDate()}-${currentDate.getMonth() + 1}-${currentDate.getFullYear()} ${currentDate.getHours()}:${currentDate.getMinutes()}:${currentDate.getSeconds()}`;
}

export default logService;
