package com.company;

import com.company.Editor.EditorFrame;

public final class GrafikEditor {

    public static void main(String[] args) {
        new GrafikEditor();
    }

    private GrafikEditor() {
        @SuppressWarnings("unused")
        EditorFrame frame = new EditorFrame(800, 600);
    }
}
