<h1>Branhorst App Development Team 02</h1>

<h2>Einführung</h2>
Dieses Projekt wurde im Ramen des Designworkshop 2 im Sommersemester 2022 an der LMU erstellt.

<h2>Benutzung</h2>
-Tutorial goes here-

<h2>Zu beachten</h2>
- Der Share Button funktioniert nur im Build auf einem Smartphone, da dieses Feature eine Android Integration beinhaltet.
- Der Prototyp muss in der ersten Szene gestartet werden.

<h2>Besonderheiten</h2>
<h3>Qr-Code Scanner</h3>
Der QR-Code-Scanner wurde mithilfe der externen Bibliothek "Zxing" umgesetzt, welche das auslesen der erstellten Bildmaterialen übernimmt. Im Skript "QR-CodeReader" wird zudem das Handling der gescannten Inhalte (mit Daten aus dem "PersistentManagerScript") und die Initialisierung der Device-Kamera durchgeführt.

<h3>Persistent Manager</h3>
Alle globalen Variablen werden im "PersistentManagerScript" gespeichert, welches auf einem empty GameObject in der 1. Szene einmalig erstellt wird (Singleton) und in jede weitere Szene übernommen wird. Der Prototyp ist deshalb auch nur dann voll funktionsfähig, wenn er in der Start-Szene gestartet wird (sonst kann der Persistentmanager nicht erzeugt werden). Im "PersistentManagerScript" werden zudem alle Kunstwere und deren Daten in einer Liste mit einer eigenen Art-Klasse verwaltet.

<h3>Dynamische Erzeugung der Inhalte</h3>
-Chris_

<h3>Social Media share-Funktion<\h3>
-Chris-

<h2>Team</h2>
-Team goes here-
