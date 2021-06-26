package com.company.Editor;

import com.company.Factory.Factory;
import com.company.Display.DrawingFigures;
import com.company.Figures.Figure;
import com.company.Figures.FigureType;
import com.company.Loader.FigureLoader;

import java.awt.*;

public class EditorControl {
    private DrawingFigures drawing = new DrawingFigures();
    private Factory factory = new Factory();
    private FigureType figureType;
    private FigureLoader figureLoader = new FigureLoader();

    private Point firstPoint;
    private Point secondPoint;

    public void drawEverything(Graphics g) {
        drawing.zeichneFiguren(g);
    }

    public void setFigureType(FigureType figureType) {
        this.figureType = figureType;
        System.out.println(this.figureType);
    }

    public void clearEditor(){
        drawing.deleteAll();
        EditorFrame.labelXCoordinate.setText("X: ");
        EditorFrame.labelYCoordinate.setText("Y: ");
        setFigureType(null);
    }

    public void setFirstPoint(Point firstPoint) {
        this.firstPoint = firstPoint;
    }

    public void createFigureWithSecondPoint(Point zweiterPunkt) {
        this.secondPoint = zweiterPunkt;

        Figure figure = factory.setFigure(figureType, this.firstPoint, this.secondPoint);

        try {
            if (!(figure.equals(null))) {
                this.drawing.hinzufuegen(figure);
            }
        } catch (Exception e) {
            System.out.println("Kein gültiger Typ");
        }
    }

    public FigureLoader getFigureLoader() {
        return figureLoader;
    }

    public DrawingFigures getDrawing() {
        return drawing;
    }
}