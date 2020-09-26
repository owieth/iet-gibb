package network.client;

import network.Message;

/**
 * Diese Klasse repräsentiert den Server auf der Client-Seite und zwar auf Ebene Netzwerkschicht.
 * Sie definiert die Schnittstelle, welche die Netzwerkschicht der Bomberman-Client-Komponente anbietet.
 * Sie ist abstrakt und muss innerhalb der Netzwerkschicht durch Ableitung implementiert werden.
 * Die Bomberman-Client-Komponente muss beim Start ein Objekt von dieser Implementationsklasse
 * erzeugen.
 * 
 * @author Andres Scheidegger
 *
 */
public abstract class ServerProxy {
  /**
   * Referenz auf dasjenige Objekt innerhalb der Bomberman-Client-Komponente, welches vom Server
   * empfangene Nachrichten verarbeitet (Empfängerobjekt).
   */
  protected final ClientApplicationInterface clientApplication;
  
  /**
   * Konstruktor. Initialisiert das neue ServerProxy-Objekt mit der Referenz auf das Empfängerobjekt.
   * @param clientApplication Das Empfängerobjekt des Bomberman-Clients für Nachrichten.
   */
  public ServerProxy(ClientApplicationInterface clientApplication){
    this.clientApplication = clientApplication;
  }
  
  /**
   * Sendet ein Nachrichtenobjekt an den Server. Diese Methode muss innerhalb der Netzwerkschicht
   * implementiert werden.
   * @param message Das Nachrichtenobjekt, welches an den Server gesendet werden soll.
   */
  public abstract void send(Message message);
}
