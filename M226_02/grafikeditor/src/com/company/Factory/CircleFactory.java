package com.company.Factory;

import com.company.Figures.Circle;
import com.company.Figures.Figure;

import java.awt.*;

public class CircleFactory implements FigureFactory{
    @Override
    public Figure create(Point firstPoint, Point secondPoint) {
        return new Circle(firstPoint, secondPoint, Color.YELLOW);
    }
}
