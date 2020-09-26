package network.client;

import network.Message;

/**
 * Diese Schnittstelle muss von einer Klasse innerhalb der Bomberman-Client-Komponente
 * implementiert werden. Sie erlaubt dem ServerProxy-Objekt der Netzwerkschicht, vom 
 * Server empfangene Nachrichten zur Verarbeitung an die Applikationsschicht weiterzuleiten.
 * 
 * @author Andres Scheidegger
 *
 */
public interface ClientApplicationInterface {
  /**
   * Diese Methode wird vom ServerProxy-Objekt aufgerufen, wenn eine Nachricht vom Server
   * empfangen wurde.
   * @param message Das empfangene Nachrichtenobjekt.
   */
  public abstract void handleMessage(Message message);
}
