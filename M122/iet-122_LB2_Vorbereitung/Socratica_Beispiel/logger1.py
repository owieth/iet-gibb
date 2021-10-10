#!/usr/bin/python3.5
# Beispiel

import logging

logging.basicConfig(filename = "logger1.log",
                    level = logging.DEBUG)

logger = logging.getLogger()

# Test the logger
logger.info("Meine erste Meldung")

print(logger.level)