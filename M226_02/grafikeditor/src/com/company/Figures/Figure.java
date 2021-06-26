package com.company.Figures;

import java.awt.*;

public abstract class Figure {

    private Point x;
    private Point y;
    private Color color;
    private FigureType type;

    public Figure(Point x, Point y, Color color, FigureType type){
        this.x = x;
        this.y = y;
        this.color = color;
        this.type = type;
    }

    public Color getColor() {
        return color;
    }

    public Point getX() {
        return x;
    }

    public Point getY() {
        return y;
    }

    public FigureType getType() {
        return type;
    }

    public abstract void draw(Graphics g);
}