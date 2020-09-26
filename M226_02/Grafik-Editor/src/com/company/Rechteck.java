package com.company;

import java.awt.*;

public class Rechteck extends Figur {

    private Point beginPoint;
    private Point endPoint;

    public Rechteck(Point x, Point y, Color farbe){
        super(x, y, farbe);
        this.beginPoint = x;
        this.endPoint = y;
    }

    @Override
    public void zeichne(Graphics g) {
        g.setColor(this.getFarbe());
        int x = (int) beginPoint.getX();
        int y = (int) beginPoint.getY();
        int width = (int) endPoint.getX() - (int) beginPoint.getX();
        int height = (int) endPoint.getY() - (int) beginPoint.getY();
        g.fillRect(x, y, width, height);//int x, int y, int width, int height
    }
}
