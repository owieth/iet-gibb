package com.company.Figures;

import java.awt.*;

public class Circle extends Figure {

    private Point beginPoint;
    private Point endPoint;

    public Circle(Point x, Point y, Color farbe){
        super(x, y, farbe, FigureType.CIRCLE);
        beginPoint = x;
        endPoint = y;
    }

    //TODO Kreis von beiden Seiten zeichnen können

    @Override
    public void draw(Graphics g) {
        g.setColor(this.getColor());
        int x = (int) beginPoint.getX();
        int y = (int) beginPoint.getY();
        int width = (int) endPoint.getX() - (int) beginPoint.getX();
        int height = (int) endPoint.getY() - (int) beginPoint.getY();
        g.fillOval(x, y, width, height);
    }
}
