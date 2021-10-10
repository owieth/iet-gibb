#!/usr/bin/python3.5
# Beispiel

import logging

# Create an configure the logger
LOG_FORMAT = "%(levelname)s %(asctime)s - %(message)s"
logging.basicConfig(filename = "logger3.log",
                    level = logging.DEBUG,
                    format = LOG_FORMAT,
                    # a for append mode, 'w' for overwrite mode
                    filemode = 'w') # 

logger = logging.getLogger()

# Test the logger
logger.debug("This is a hermless debug Message.")
logger.info("Just some useful info.")
logger.warning("I'am sorry, but ...")
logger.error("Error occured ...")
logger.critical ("No connection to the Internet!")

print(logger.level)