#!/usr/bin/python3.5
# Beispiel

import logging

# Create an configure the logger
LOG_FORMAT = "%(levelname)s %(asctime)s - %(message)s"
logging.basicConfig(filename = "logger2.log",
                    level = logging.DEBUG,
                    format = LOG_FORMAT,
                    # a for append mode, 'w' for overwrite mode
                    filemode = 'a') # 

logger = logging.getLogger()

# Test the logger
logger.info("Meine erste Meldung")

print(logger.level)