package com.company;

import java.awt.*;

final class EditorControl {
    Display display = new Display();
    private char figurTyp;
    private Point ersterPunkt;
    private Point zweiterPunkt;

    public void allesNeuZeichnen(Graphics g) {
        //TODO: Erg�nzen
    }

    public void setFigurTyp(char figurTyp) {
        this.figurTyp = figurTyp;
    }

    public void setErsterPunkt(Point ersterPunkt) {
        this.ersterPunkt = ersterPunkt;
    }

    public void erzeugeFigurMitZweitemPunkt(Point zweiterPunkt) {
        this.zweiterPunkt = zweiterPunkt;


        switch (figurTyp) {
            case 'l':
                Linie linie = new Linie(this.ersterPunkt, this.zweiterPunkt, Color.PINK);
                display.hinzufuegen(linie);
                break;

            case 'r':
                Rechteck rechteck = new Rechteck(this.ersterPunkt, this.zweiterPunkt, Color.BLUE);
                display.hinzufuegen(rechteck);
                break;

            case 'k':
                Kreis kreis = new Kreis(this.ersterPunkt, this.zweiterPunkt, 1, 1, Color.YELLOW);
                display.hinzufuegen(kreis);
                break;
        }
    }
}
