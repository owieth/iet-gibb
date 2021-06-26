package com.company.Figures;

import java.awt.*;

public class Rectangle extends Figure {

    private Point beginPoint;
    private Point endPoint;

    public Rectangle(Point x, Point y, Color farbe){
        super(x, y, farbe, FigureType.RECTANGLE);
        this.beginPoint = x;
        this.endPoint = y;
    }

    @Override
    public void draw(Graphics g) {
        g.setColor(this.getColor());
        int x = (int) beginPoint.getX();
        int y = (int) beginPoint.getY();
        int width = (int) endPoint.getX() - (int) beginPoint.getX();
        int height = (int) endPoint.getY() - (int) beginPoint.getY();
        g.fillRect(x, y, width, height);
    }
}
