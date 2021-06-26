package com.company.Listener;

import com.company.Editor.EditorControl;
import com.company.Editor.EditorFrame;
import com.company.Editor.EditorPanel;

import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

public class MouseListener extends MouseAdapter {
    private Point pointXCoordinate;
    private Point pointYCoordinate;
    private EditorControl editorControl;
    private EditorPanel panel;

    public MouseListener(EditorControl editorControl, EditorPanel panel) {
        this.editorControl = editorControl;
        this.panel = panel;
    }

    @Override
    public void mousePressed(MouseEvent e) {
        super.mousePressed(e);
        pointXCoordinate = e.getPoint();
        panel.repaint();
        panel.grabFocus();
    }

    @Override
    public void mouseReleased(MouseEvent e) {
        super.mouseReleased(e);
        pointYCoordinate = e.getPoint();
        editorControl.setFirstPoint(new Point(pointXCoordinate));
        editorControl.createFigureWithSecondPoint(new Point(e.getX(), e.getY()));
        String pointXCoordinateString = Integer.toString(pointXCoordinate.x);
        String pointYCoordinateString = Integer.toString(pointYCoordinate.y);
        EditorFrame.labelXCoordinate.setText("X: " + pointXCoordinateString);
        EditorFrame.labelYCoordinate.setText("Y: " + pointYCoordinateString);
        panel.repaint();
        panel.grabFocus();
    }
}
