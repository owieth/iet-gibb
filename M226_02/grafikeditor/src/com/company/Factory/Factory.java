package com.company.Factory;

import com.company.Editor.EditorFrame;
import com.company.Figures.Figure;
import com.company.Figures.FigureType;

import java.awt.*;

public class Factory {
    private LineFactory lineFactory = new LineFactory();
    private RectangleFactory rectangleFactory = new RectangleFactory();
    private CircleFactory circleFactory = new CircleFactory();

    public Figure setFigure(FigureType figureType, Point firstPoint, Point secondPoint) {
        if (figureType == FigureType.LINE) {
            EditorFrame.FigurType.setText(FigureType.RECTANGLE.toString());
            return lineFactory.create(firstPoint, secondPoint);
        }
        if (figureType == FigureType.RECTANGLE) {
            EditorFrame.FigurType.setText(FigureType.RECTANGLE.toString());
            return rectangleFactory.create(firstPoint, secondPoint);
        }
        if (figureType == FigureType.CIRCLE) {
            EditorFrame.FigurType.setText(FigureType.CIRCLE.toString());
            return circleFactory.create(firstPoint, secondPoint);
        }
        return null;
    }
}