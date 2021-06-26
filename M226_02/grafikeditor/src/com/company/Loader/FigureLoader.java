package com.company.Loader;

import com.company.Display.DrawingFigures;
import com.company.Editor.EditorControl;
import com.company.Figures.Figure;

import javax.swing.*;
import javax.swing.filechooser.FileFilter;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.awt.*;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class FigureLoader {
    public String importZeichnung(EditorControl controller) {
        String figures = getFileAsString();
        if (figures != null) {
            if (!figures.equals("")) {
                List<String> figuesAsString = FigureFileHelper.parseFigures(figures);
                drawFigures(figuesAsString, controller);
            } else {
                System.out.println("Error: FileLoader ist leer");
            }
        } else {
            System.out.println("Error: FileLoader nicht gefunden");
        }
        return null;
    }

    private void drawFigures(List<String> figuesAsString, EditorControl controller) {
        for (String figure : figuesAsString) {
            Figure figur = FigureFileHelper.stringToFigure(figure);
            controller.setFigureType(figur.getType());
            controller.setFirstPoint(figur.getX());
            controller.createFigureWithSecondPoint(figur.getY());
        }
    }

    private String getFileAsString() {
        String file = openFileChooser();
        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            while (line != null) {
                sb.append(line);
                sb.append(System.lineSeparator());
                line = br.readLine();
            }
            return sb.toString();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void exportZeichnung(JFrame frame, DrawingFigures drawingFigures) {
        if (drawingFigures.getFiguren().size() != 0) {
            FileFilter filter = new FileNameExtensionFilter("Text FileLoader", ".txt");
            JFileChooser fileChooser = new JFileChooser();
            fileChooser.setFileFilter(filter);
            if (fileChooser.showSaveDialog(frame) == JFileChooser.APPROVE_OPTION) {
                try {
                    File file = fileChooser.getSelectedFile();
                    List<String> figuresAsString = new ArrayList<>();
                    for (Figure figure : drawingFigures.getFiguren()) {
                        figuresAsString.add(FigureFileHelper.figureToString(figure));
                    }
                    createFile(file.getAbsolutePath() + ".txt", figuresAsString);
                    System.out.println("Export erfolgreich");
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        } else {
            System.out.println("Keine Figuren vorhanden");
        }
    }

    private void createFile(String pathWithFilename, List<String> figuresAsString) throws IOException {
        Path file = Paths.get(pathWithFilename);
        Files.write(file, figuresAsString, Charset.forName("UTF-8"));
    }

    private String openFileChooser() {
        FileDialog dialog = new FileDialog((Frame) null, "Select FileLoader to Open");
        dialog.setMode(FileDialog.LOAD);
        dialog.setVisible(true);
        return dialog.getDirectory() + dialog.getFile();
    }
}
