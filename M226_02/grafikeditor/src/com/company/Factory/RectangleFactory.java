package com.company.Factory;

import com.company.Figures.Figure;
import com.company.Figures.Rectangle;

import java.awt.*;

public class RectangleFactory implements FigureFactory{
    @Override
    public Figure create(Point firstPoint, Point secondPoint) {
        return new Rectangle(firstPoint, secondPoint, Color.BLUE);
    }
}
