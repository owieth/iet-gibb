package com.company.Factory;

import com.company.Figures.Figure;
import com.company.Figures.FigureType;

import java.awt.*;

public interface FigureFactory {
    Figure create(Point firstPoint, Point secondPoint);
}