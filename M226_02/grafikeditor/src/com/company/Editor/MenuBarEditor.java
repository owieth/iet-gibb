package com.company.Editor;

import com.company.Figures.FigureType;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionListener;
import java.io.IOException;

public class MenuBarEditor extends JMenuBar {
    private JButton importButton = new JButton();
    private JButton exportButton = new JButton();

    protected MenuBarEditor(EditorControl editorControl, JFrame frame) {
        try {
            importButton.setName("importButton");
            importButton.setSize(50, 50);
            importButton.setIcon(getIconsImport("/images/import_icon.png"));
            importButton.setContentAreaFilled(false);
            importButton.setBorderPainted(false);

            exportButton.setName("exportButton");
            exportButton.setSize(50, 50);
            exportButton.setIcon(getIconsImport("/images/export_icon.png"));
            exportButton.setContentAreaFilled(false);
            exportButton.setBorderPainted(false);

            super.add(createButton("/images/delete.png", e -> editorControl.clearEditor()));
            super.add(createButton("/images/rectangle.png", e -> editorControl.setFigureType(FigureType.RECTANGLE)));
            super.add(createButton("/images/circle.png", e -> editorControl.setFigureType(FigureType.CIRCLE)));
            super.add(createButton("/images/line.png", e -> editorControl.setFigureType(FigureType.LINE)));
            super.add(createButton("/images/import_icon.png", e -> editorControl.getFigureLoader().importZeichnung(editorControl)));
            super.add(createButton("/images/export_icon.png", e -> editorControl.getFigureLoader().exportZeichnung(frame, editorControl.getDrawing())));

            super.add(EditorFrame.FigurType);
        } catch (IOException e) {
            System.out.println("Error: Bild(er) nicht gefunden");
        }
    }

    private ImageIcon getIconsImport(String imageSrc) throws IOException {
        ImageIcon imageIcon = new ImageIcon(ImageIO.read(getClass().getResourceAsStream(imageSrc)));
        Image image = imageIcon.getImage();
        Image newimg = image.getScaledInstance(20, 20, java.awt.Image.SCALE_SMOOTH);
        return new ImageIcon(newimg);
    }

    private JButton createButton(String imgSrc, ActionListener actionListener) throws IOException {
        JButton button = new JButton();
        button.setBorderPainted(false);
        button.setFocusPainted(false);
        button.setContentAreaFilled(false);
        button.setIcon(getScaledImage(imgSrc));
        button.addActionListener(actionListener);
        return button;
    }

    private ImageIcon getScaledImage(String imageSrc) throws IOException {
        ImageIcon imageIcon = new ImageIcon(ImageIO.read(getClass().getResourceAsStream(imageSrc)));
        Image image = imageIcon.getImage();
        Image newimg = image.getScaledInstance(20, 20, java.awt.Image.SCALE_SMOOTH);
        return new ImageIcon(newimg);
    }
}
