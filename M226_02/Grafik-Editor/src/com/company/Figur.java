package com.company;

import java.awt.*;

public abstract class Figur {

    private Point x;
    private Point y;
    private Color farbe;

    public Figur(Point x, Point y, Color farbe){
        this.x = x;
        this.y = y;
        this.farbe = farbe;
    }

    public Color getFarbe() {
        return farbe;
    }

    public void setFarbe(Color farbe) {
        this.farbe = farbe;
    }

    public Point getX() {
        return x;
    }

    public Point getY() {
        return y;
    }

    public void move(int deltaX, int deltaY){
        //x += deltaX;
        //y += deltaY;
    }

    public abstract void zeichne(Graphics g);
}
