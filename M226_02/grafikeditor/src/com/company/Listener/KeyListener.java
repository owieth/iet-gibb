package com.company.Listener;

import com.company.Editor.EditorControl;
import com.company.Figures.FigureType;

import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;

public class KeyListener extends KeyAdapter {
    private EditorControl control;

    public KeyListener(EditorControl control){
        this.control = control;
    }

    @Override
    public void keyTyped(KeyEvent e) {
        char key = e.getKeyChar();

        /*switch (key) {
            case 'k':
                control.setFigureType(FigureType.CIRCLE);
                break;

            case 'r':
                control.setFigureType(FigureType.RECTANGLE);
                break;

            case 'l':
                control.setFigureType(FigureType.LINE);
                break;
        }*/

        for (FigureType type : FigureType.values()) {
            if (key == type.asChar()) {
                control.setFigureType(type);
            }
        }
    }
}
