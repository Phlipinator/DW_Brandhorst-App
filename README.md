<h1>Brandhorst App Development Team 02</h1>

[![Präsentations-Video der App](http://img.youtube.com/vi/0tWduAJYHak/0.jpg)](http://www.youtube.com/watch?v=0tWduAJYHak)

<h2>Einführung</h2>
Dieses Projekt wurde im Rahmen des Design Workshop 2 im Sommersemester 2022 an der LMU in Kooperation mit dem Museum Brandhorst erstellt. Ziel des Kurses war es eine App in Unity zu entwickeln, die die Besucher des Museums nutzen können um die aktuelle Ausstellung “Future Bodies From A Recent Past” auf eine neue Art und Weise zu erleben. 
Das Konzept der App ist ein Spiel, in der die Nutzer vergrößerte Ausschnitte der verschiedenen Kunstwerke auswählen können, um die dazu passenden Kunstwerke über einen QR-Code Scanner zu evaluieren. Hat der Nutzer das richtige Kunstwerk gefunden, erhält er den dazugehörigen Infotext und einen neuen Eintrag in der Trophy Übersicht. Die Trophy Übersicht ist eine Galerie der gefundenen Kunstwerke, dessen Inhalte der Nutzer auch außerhalb des Museums aufrufen und über Social Media teilen kann. Mit dieser App wollen wir dem Nutzer die Möglichkeit geben das Museum Brandhorst auf spielerische Art und Weise zu erkunden und ist daher von jeder Altersgruppe nutzbar.

<h2>Benutzung</h2>
Nutzer werden beim ersten öffnen der App mit einer kurzen Einleitung begrüßt. Diese erklärt die grundlegende Spielmechanik und die funktionsweise. Ziel des Spiels ist es, so viele Kunstwerke wie möglich anhand der gezeigten Bildausschnitte zu finden. Auf der Hauptseite der App sind diese Bilder zunächst in Räume, bzw. Etagen aufgeteilt. Wird nun die entsprechende Etage in der man sich gerade befindet ausgewählt, so wird die übersicht aller zu findenden Kunstwerke angezeigt. Ziel ist es nun, durch ein Erkunden der Ausstellung die entsprechenden Kunstwerke den Bildausschnitten zuzuordnen. Wählt man einen der Bildausschnitte aus, so gelangt man zu dessen Übersichtsseite. Hier lassen sich nun, nach Ablauf einer gewissen Wartezeit, optional Tipps anzeigen, die es erleichtern sollen das Kunstwerk zu finden. Ist das Kunstwerk gefunden, lässt sich mit einem Tippen auf das "Scanner"-Icon der QR-Code Reader öffnen, und damit der QR-Code scannen. Nach einem erfolgreichen Scan wird man zur nun ausführlicheren Seite des Kunstwerks mit Titel, Künstler und Infotexten weitergeleitet. Alle gefundenen Kunstwerke, und damit auch die zugehörigen Informationen, lassen sich über die Erfolgsansicht auch im Nachhinein jederzeit einsehen. Jederzeit kann man in der App mit einem Tip auf den "Zurück"-Pfeil einen Schritt in der Navigation zurück gehen.

Die Funktionsweise lässt sich auch anhand des [Präsentations-Videos](http://www.youtube.com/watch?v=0tWduAJYHak) nachvollziehen.

<h2>Zu Beachten</h2>

- Der Share Button funktioniert nur im Build auf einem Smartphone, da dieses Feature eine Android Integration beinhaltet.
- Der Prototyp muss in der ersten Szene gestartet werden.

<h2>Besonderheiten bei der Implementierung</h2>
<h3>Qr-Code Scanner</h3>
Der QR-Code-Scanner wurde mithilfe der externen Bibliothek "Zxing" umgesetzt, welche das auslesen der erstellten Bildmaterialen übernimmt. Im Skript "QR-CodeReader" wird zudem das Handling der gescannten Inhalte (mit Daten aus dem "PersistentManagerScript") und die Initialisierung der Device-Kamera durchgeführt.

<h3>Persistent Manager</h3>
Alle globalen Variablen werden im "PersistentManagerScript" gespeichert, welches auf einem empty GameObject in der 1. Szene einmalig erstellt wird (Singleton) und in jede weitere Szene übernommen wird. Der Prototyp ist deshalb auch nur dann voll funktionsfähig, wenn er in der Start-Szene gestartet wird (sonst kann der Persistentmanager nicht erzeugt werden). Im "PersistentManagerScript" werden zudem alle Kunstwere und deren Daten in einer Liste mit einer eigenen Art-Klasse verwaltet.

<h2>Das Team</h2>
Das Team hat sich aufgeteilt in Design und Implementierung. Für das optische Design wurde ein erster Prototyp in AdobeXD kreiert, der als Design Guide für die spätere Unity Implementierung diente. Die Verantwortlichen hierfür sind:

* [Tessa Radler](mailto:t.radler@campus.lmu.de)
* [Anastasia Goncharenko](mailto:a.goncharenko@campus.lmu.de)

Die Implementierung erfolgte in Unity, wobei die verschiedenen Frames der App zwischen folgenden Personen aufgeteilt wurde: 
* [Michael Huber](mailto:mi.huber@campus.lmu.de)
* [Agnes Reda](mailto:A.Reda@campus.lmu.de)
* [Philipp Thalhammer](mailto:Philipp.Thalhammer@campus.lmu.de)
* [Christian Schmalzbauer](mailto:c.schmalzbauer@campus.lmu.de)

