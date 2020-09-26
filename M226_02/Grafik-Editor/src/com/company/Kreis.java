package com.company;

import java.awt.*;

public class Kreis extends Figur{

    private Point beginPoint;
    private Point endPoint;
    private int arcWidth;
    private int arcHeight;

    public Kreis(Point x, Point y, int arcHeight, int arcWidth, Color farbe){
        super(x, y, farbe);
        beginPoint = x;
        endPoint = y;
        this.arcHeight = arcHeight;
        this.arcWidth = arcWidth;
    }

    @Override
    public void zeichne(Graphics g) {
        g.setColor(this.getFarbe());
        int x = (int) beginPoint.getX();
        int y = (int) beginPoint.getY();
        int width = (int) endPoint.getX() - (int) beginPoint.getX();
        int height = (int) endPoint.getY() - (int) beginPoint.getY();
        g.fillOval(x, y, width, height);
    }
}
