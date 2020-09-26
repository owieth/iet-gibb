package com.company;

import javax.swing.*;
import java.awt.*;
import java.util.Timer;

public class Main {

    public static void main(String[] args) {
        Zeichnung zeichnung;
        Display display = new Display();
        //Linie linie = new Linie(200,200,300,300, Color.PINK);
        //Rechteck rechteck = new Rechteck(150,150,50,300, Color.BLUE);
        //Kreis kreis = new Kreis(150,150,50,50, 10, 10, Color.YELLOW);
        //Text text = new Text(50,50,"Grafik-Editor von Winkler Olivier", Color.BLACK);


        //display.hinzufuegen(linie, rechteck, kreis, text);

        try {
            Thread.sleep(2000);
        } catch (InterruptedException ex) {
            ex.printStackTrace();
        }

        //linie.move(100,200);
        display.repaint();
    }
}
