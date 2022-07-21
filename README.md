<h1>Brandhorst App Development Team 02</h1>

<h2>Einführung</h2>
Dieses Projekt wurde im Rahmen des Design Workshop 2 im Sommersemester 2022 an der LMU in Kooperation mit dem Museum Brandhorst erstellt. Ziel des Kurses war es eine App in Unity zu entwickeln, die die Besucher des Museums nutzen können um die aktuelle Ausstellung “Future Bodies From A Recent Past” auf eine neue Art und Weise zu erleben. 
Das Konzept der App ist ein Spiel, in der die Nutzer vergrößerte Ausschnitte der verschiedenen Kunstwerke auswählen können, um die dazu passenden Kunstwerke über einen QR-Code Scanner zu evaluieren. Hat der Nutzer das richtige Kunstwerk gefunden, erhält er den dazugehörigen Infotext und einen neuen Eintrag in der Trophy Übersicht. Die Trophy Übersicht ist eine Galerie der gefundenen Kunstwerke, dessen Inhalte der Nutzer auch außerhalb des Museums aufrufen und über Social Media teilen kann. Mit dieser App wollen wir dem Nutzer die Möglichkeit geben das Museum Brandhorst auf spielerische Art und Weise zu erkunden und ist daher von jeder Altersgruppe nutzbar.

<h2>Benutzung</h2>
-Tutorial goes here-

<h2>Zu Beachten</h2>

- Der Share Button funktioniert nur im Build auf einem Smartphone, da dieses Feature eine Android Integration beinhaltet.
- Der Prototyp muss in der ersten Szene gestartet werden.

<h2>Besonderheiten bei der Implementierung</h2>
<h3>Qr-Code Scanner</h3>
Der QR-Code-Scanner wurde mithilfe der externen Bibliothek "Zxing" umgesetzt, welche das auslesen der erstellten Bildmaterialen übernimmt. Im Skript "QR-CodeReader" wird zudem das Handling der gescannten Inhalte (mit Daten aus dem "PersistentManagerScript") und die Initialisierung der Device-Kamera durchgeführt.

<h3>Persistent Manager</h3>
Alle globalen Variablen werden im "PersistentManagerScript" gespeichert, welches auf einem empty GameObject in der 1. Szene einmalig erstellt wird (Singleton) und in jede weitere Szene übernommen wird. Der Prototyp ist deshalb auch nur dann voll funktionsfähig, wenn er in der Start-Szene gestartet wird (sonst kann der Persistentmanager nicht erzeugt werden). Im "PersistentManagerScript" werden zudem alle Kunstwere und deren Daten in einer Liste mit einer eigenen Art-Klasse verwaltet.

<h3>Dynamische Erzeugung der Inhalte</h3>
-Chris_

<h3>Social Media Share-Funktion<\h3>
-Chris-

<h2>Das Team</h2>
Das Team hat sich aufgeteilt in Design und Implementierung. Für das optische Design wurde ein erster Prototyp in AdobeXD kreiert, der als Design Guide für die spätere Unity Implementierung diente. Die Verantwortlichen hierfür sind:

* [Theresa Radler](mailto:t.radler@campus.lmu.de)
* [Anastasia Goncharenko](mailto:a.goncharenko@campus.lmu.de)

Die Implementierung erfolgte in Unity, wobei die verschiedenen Frames der App zwischen folgenden Personen aufgeteilt wurde: 
* [Michael Huber](mailto:mi.huber@campus.lmu.de)
* [Agnes Reda](mailto:A.Reda@campus.lmu.de)
* [Philipp Thalhammer](mailto:Philipp.Thalhammer@campus.lmu.de)
* [Christian Schmalzbauer](mailto:c.schmalzbauer@campus.lmu.de)

