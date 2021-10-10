#!/usr/bin/python3.5
import csv

# Daten einlesen
ifile = open('adressen.csv', newline='')
reader = csv.reader(ifile, delimiter=",")
headers = next(reader, None)  # liest die Feldnamen oder 'None', wenn keine Daten

# Datei fuer die Ausgabe
ofile  = open('adressen_out.csv', "w", newline='')
writer = csv.writer(ofile, delimiter=";")
if headers:
    writer.writerow(headers)

# Jede Zeile lesen und ausgeben
for row in reader:
    j = 0
    for col in row:
        if headers[j] == "name":
            print("Nachname: "+ col)
            row[3] = 'ok'
            writer.writerow(row)
        j += 1
        
        
# Programmende: Ausgabe am Bildschirm
print (chr(10)+"Programm erfolgreich beendet"+chr(10))

# Dateiobjekte schliessen
ifile.close()
ofile.close()
