package network.server;

import java.util.Scanner;

import network.Message;

/**
 * Die Klasse ServerStub dient dazu die Teilkomponente application.server isoliert von der
 * Netzwerkschicht testen zu können. Hierzu muss ein Objekt von dieser Klasse erzeugt werden.
 * Dabei wird ein separater Thread gestartet, welche den Empfang von Meldungen von den Clients
 * simuliert. In der Methode deliverMessageToServer() kann programmiert werden, welche Meldungen
 * dies konkret sind. Die Methode wartet mit der Auslieferung, bis der Benutzer die Taste
 * ENTER drückt. Dies kann je nach Situation hilfreich sein beim Testen. Die Methode kann aber
 * beliebig an die Bedürfnisse des Tests angepasst werden. 
 * Der Server-Komponente selber stehen die send-Methode und die broadcast-Methode zur Verfügung,
 * um eine Antwort an einen oder alle Clients zu simulieren. Die Meldung wird lediglich auf der
 * Konsole ausgegeben.
 * 
 * @author Andres Scheidegger
 *
 */
public class ServerStub extends Server {
  
  /**
   * Konstruktor. Muss von der Server-Komponente aufgerufen werden. Startet einen separaten Thread
   * zum Simulieren der Meldungen, welche von den Clients empfangen werden.
   * @see #deliverMessagesToServer()
   * @param serverApplication Eine Referenz auf ein Objekt der Server-Komponente, welches das 
   *                          ServerApplicationInterface implementiert.
   */
  public ServerStub(ServerApplicationInterface serverApplication) {
    super(serverApplication);
    Thread clientThread = new Thread() {
      @Override
      public void run() {
        deliverMessagesToServer();
      }
    };
    clientThread.start();
  }

  /**
   * Kann von der Server-Komponente aufgerufen werden, um den Versand einer Meldung an
   * einen bestimmten Client zu simulieren. 
   * @see network.client.Server#send(network.Message, String)
   */
  @Override
  public void send(Message message, String connectionId) {
    System.out.println(connectionId + '\n' + message);
  }

  /**
   * Kann von der Server-Komponente aufgerufen werden, um den Versand einer Meldung an
   * alle Clients zu simulieren. 
   * @see network.client.Server#broadcast(network.Message)
   */
  @Override
  public void broadcast(Message message) {
    System.out.println(message);
  }
  
  /**
   * Wartet auf eine Eingabe von der Konsole (ENTER-Taste). Anschliessend werden die weiteren 
   * Anweisungen ausgeführt. Z.B. können Meldungen an den Server ausgeliefert werden, indem die Methode
   * handleMessage() bei der Server-Komponente aufgerufen wird. Diese Methode kann den Bedürfnissen
   * des Tests angepasst werden.
   */
  private void deliverMessagesToServer() {
    System.out.println("Drücken Sie ENTER, um die Auslieferung der Meldungen an den Server zu starten.");
    new Scanner(System.in).nextLine();
    // Hier können Sie die Meldungen, welche nach dem Drücken der ENTER-Taste an Ihren Server gesendet
    // werden sollen programmieren. Z.B.:
    // Message message = new JoinGame("TestA");
    // serverApplication.handleMessage(message, "connection1");
  }
}
