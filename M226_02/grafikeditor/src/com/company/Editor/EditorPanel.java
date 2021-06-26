package com.company.Editor;

import com.company.Listener.KeyListener;
import com.company.Listener.MouseListener;

import javax.swing.*;
import java.awt.*;

@SuppressWarnings("serial")
public final class EditorPanel extends JPanel {
    private EditorControl editorControl;

    EditorPanel(EditorControl control) {
        editorControl = control;

        addKeyListener(new KeyListener(editorControl));
        addMouseListener(new MouseListener(editorControl, this));
    }


    // Die paintComponent()-Methode wird automatisch aufgerufen, wenn irgendwer die repaint()-
    // Methode beim EditorFrame oder beim EditorPanel aufruft.
    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g);
        editorControl.drawEverything(g);
    }
}