package com.company.Factory;

import com.company.Figures.Figure;
import com.company.Figures.Line;

import java.awt.*;

public class LineFactory implements FigureFactory {
    @Override
    public Figure create(Point firstPoint, Point secondPoint) {
        return new Line(firstPoint, secondPoint, Color.BLACK);
    }
}
