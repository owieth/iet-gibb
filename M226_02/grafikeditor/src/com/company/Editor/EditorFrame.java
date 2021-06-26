package com.company.Editor;

import javax.swing.*;
import java.awt.*;

@SuppressWarnings("serial")
public class EditorFrame extends JFrame {
    private Point PointX = new Point(0,0);
    private Point PointY = new Point(0,0);

    private JPanel mainPanel = new JPanel();
    public static JLabel FigurType = new JLabel();
    private JMenuBar jMenuBar = new JMenuBar();
    public static Label labelXCoordinate = new Label();
    public static Label labelYCoordinate = new Label();

    public EditorFrame(int width, int height) {
        setEditorPanel();
        centerWindow(width, height);
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        setVisible(true);
        super.setTitle("Grafikeditor");
    }

    private void setEditorPanel() {
        super.setContentPane(mainPanel);

        EditorControl control = new EditorControl();
        BorderLayout layout = new BorderLayout();

        mainPanel.setLayout(layout);
        mainPanel.add(new EditorPanel(control), BorderLayout.CENTER);
        mainPanel.add(new MenuBarEditor(control, this), BorderLayout.NORTH);
        jMenuBar.add(labelXCoordinate);
        jMenuBar.add(labelYCoordinate);
        labelXCoordinate.setText("X: " + PointX.getX());
        labelYCoordinate.setText("Y: " + PointY.getY());

        mainPanel.add(jMenuBar, BorderLayout.SOUTH);
    }

    private void centerWindow(int width, int height) {
        Dimension windowSize = Toolkit.getDefaultToolkit().getScreenSize();
        Rectangle windowSnippet = new Rectangle();
        windowSnippet.width = width;
        windowSnippet.height = height;
        windowSnippet.x = (windowSize.width - windowSnippet.width) / 2;
        windowSnippet.y = (windowSize.height - windowSnippet.height) / 2;
        setBounds(windowSnippet);
    }
}
