package com.company;

import javax.swing.*;
import java.awt.*;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

@SuppressWarnings("serial")
final class EditorPanel extends JPanel {
  private EditorControl editorControl;
  private Point punkt;

  EditorPanel(EditorControl control) {
    editorControl = control;
    addMouseListener(new MouseAdapter() {
      @Override
      public void mousePressed(MouseEvent e) {
        super.mousePressed(e);
        punkt = e.getPoint();
      }

      @Override
      public void mouseReleased(MouseEvent e) {
        super.mouseReleased(e);
        editorControl.setErsterPunkt(new Point(punkt));
        editorControl.erzeugeFigurMitZweitemPunkt(new Point(e.getX(), e.getY()));
      }
    });
  }


  // Die paintComponent()-Methode wird automatisch aufgerufen, wenn irgendwer die repaint()-
  // Methode beim EditorFrame oder beim EditorPanel aufruft.
  @Override
  protected void paintComponent(Graphics g) {
    super.paintComponent(g);
    editorControl.allesNeuZeichnen(g);
  }
}