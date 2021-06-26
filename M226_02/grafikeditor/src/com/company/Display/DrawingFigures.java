package com.company.Display;

import com.company.Figures.Figure;

import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class DrawingFigures {
    private List<Figure> figuren = new ArrayList<Figure>();

    public DrawingFigures(){}

    public void zeichneFiguren(Graphics g) {
        for (Figure f : figuren) {
            f.draw(g);
        }
    }

    /**
     * Fügt eine weitere FigureFileHelper hinzu und l�st die Auffrischung des Fensterinhaltes aus.
     * @param figure Referenz auf das weitere FigureFileHelper-Objekt.
     */
    public void hinzufuegen(Figure figure){
        figuren.add(figure);
    }


    /*public void hinzufuegen(FigureFileHelper[] figuren){
        for(FigureFileHelper figur: figuren){
            this.figuren.add(figur);
        }
    }*/
    public List<Figure> getFiguren() {
        return figuren;
    }

    /**
     * L�scht alle Figures und l�st die Auffrischung des Fensterinhaltes aus.
     */
    public void deleteAll() {
        figuren.clear();
    }
}
