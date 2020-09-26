package com.company;

import javax.swing.*;
import java.awt.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Zeichnung extends JFrame {
    //private Figur[] figurArray;
    //public List<Figur> figuren = new ArrayList<Figur>();
    public List<Figur> figuren;

    public Zeichnung(List<Figur> figuren){
        //this.figuren = new ArrayList<Figur>(figuren);
        this.figuren = figuren;
    }

    /**
     * Zeichnet alle Figuren.
     * @param g Referenz auf das Graphics-Objekt zum zeichnen.
     */
    public void zeichneFiguren(Graphics g) {
        for (Figur f : figuren) {
            f.zeichne(g);

            /* TODO: Hier muss f�r jede weitere Figur-Klasse, welche dargestellt werden k�nnen muss,
             * ein analoger Abschnitt, wie f�r die Rechteck-Klasse folgen.
             */
        }
    }

    /**
     * Fügt eine weitere Figur hinzu und l�st die Auffrischung des Fensterinhaltes aus.
     * @param figur Referenz auf das weitere Figur-Objekt.
     */
    public void hinzufuegen(Figur... figur) {
        figuren.addAll(Arrays.asList(figur));
        repaint();
    }

    /**
     * L�scht alle Figuren und l�st die Auffrischung des Fensterinhaltes aus.
     */
    public void allesLoeschen() {
        figuren.clear();
        repaint();
    }
}
