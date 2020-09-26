package com.company;

public final class Grafikeditor {

    public static void main(String[] args) {
    new Grafikeditor();
  }

  private Grafikeditor() {
    @SuppressWarnings("unused")
    EditorFrame frame = new EditorFrame(800, 600);
  }
}
