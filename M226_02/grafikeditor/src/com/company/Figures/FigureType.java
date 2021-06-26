package com.company.Figures;

public enum FigureType {
    LINE('l'),
    RECTANGLE('r'),
    CIRCLE('k');

    public char asChar() {
        return figureAsChar;
    }

    private final char figureAsChar;

    FigureType(char figureAsChar){
        this.figureAsChar = figureAsChar;
    }
}
