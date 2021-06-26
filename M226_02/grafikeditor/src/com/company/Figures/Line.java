package com.company.Figures;

import java.awt.*;

public class Line extends Figure {

    private int x;
    private int y;
    private int endX;
    private int endY;

    public Line(Point x, Point y, Color farbe) {
        super(x, y, farbe, FigureType.LINE);
        this.x = (int) x.getX();
        this.y = (int) x.getY();
        this.endX = (int) y.getX();
        this.endY = (int) y.getY();
    }

    @Override
    public void draw(Graphics g) {
        g.setColor(this.getColor());
        g.drawLine(x, y, endX, endY);
    }
}
