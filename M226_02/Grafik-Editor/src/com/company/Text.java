package com.company;

import java.awt.*;

public class Text extends Figur{

    private String value;

    public Text(Point x, Point y, String value, Color farbe){
        super(x, y, farbe);
        this.value = value;
        Label label = new Label();
        label.setText(value);
    }

    @Override
    public void zeichne(Graphics g) {
        g.setColor(this.getFarbe());
        g.drawString(this.getValue(), 10, 10);
    }

    public String getValue() {
        return value;
    }
}

