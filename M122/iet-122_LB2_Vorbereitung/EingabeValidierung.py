#!/usr/bin/python3.2
# Modul 122 Aufgabe 1

import re

regex_Name_Vorname = "^[A-Za-z-]{2,} [A-Za-z-]{2,}$"
# Klaus Hammermann
# Irena Dietle-Fankhauser
# Dieter-Thomas Schreck
regex_Strasse_Hausnummer = "^[a-zA-Z]{2,}(\s){0,1}(\d){0,4}(a-z){0,1}$"
# Hauptstrasse 23
# Postfach
# Sackgasse 34c
regex_PLZ_Ort = "^(\d){4}\s[a-zA-Z]{2,}((\s){1}(\d){0,2}){0,1}$"
# 4552 Derendingen
# 3000 Bern 13
regex_Email = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"
# bill@gates.com
# nina.brenner@me.ch
regex_Geburtsdatum = "^([1-9]|[12][0-9]|3[01])\.([1-9]|1[012])\.(19|20)[0-9]{2}$"
# 1.1.1900
# 
regex_Postkontonummer = "^\\d{2}-\\d{1,6}-\\d{1}$|^[1-9]{1}[0-9]{8}$|^90[0-9]{7}$"
# 6-11 stellig numerisch mit 2x '-' ODER 9 stellig numerisch mit 10... bis 90...

while True:
    strName_Vorname = input("Name und Vorname:")
    if re.search(regex_Name_Vorname, strName_Vorname):
        break

while True:
    strStrasse_Hausnummer = input("Strasse und Hausnummer:")
    if re.search(regex_Strasse_Hausnummer, strStrasse_Hausnummer):
        break

while True:
    strPLZ_Ort = input("PLZ und Ort:")
    if re.search(regex_PLZ_Ort, strPLZ_Ort):
        break

while True:
    strEmail = input("Email:")
    if re.search(regex_Email, strEmail):
        break

while True:
    strPostkontonummer = input("Postkontonummer:")
    if re.search(regex_Postkontonummer, strPostkontonummer):
        break

while True:
    strGeburtsdatum = input("Geburtsdatum:")
    if re.search(regex_Geburtsdatum, strGeburtsdatum):
        break



print("Zusammenfassung")
print("Name und Vorname:" + strName_Vorname)
print("Strasse und Hausnummer:" + strStrasse_Hausnummer)
print("PlZ und Ort:" + strPLZ_Ort)
print("Email:" + strEmail)
print("Geburtsdatum:" + strGeburtsdatum)
print("Postkontonummer:" + strPostkontonummer)
