<img src="https://assets.angular.schule/header-testing-jest.png">

#### **mit Johannes Hoppe**

<hr>

**Herzlich Willkommen – und schön, dass du dabei bist!**  
In diesem Repository findest du während des Workshops den Quelltext unserer Beispielanwendung.

Damit wir gleich durchstarten können, solltest Du ein paar Vorbereitungen treffen.
Die gesamte Installation wird rund 30 Minuten dauern.

> **Wir machen einen Praxisworkshop zum Mitmachen! Du benötigst also einen eigenen Computer mit Entwicklungsumgebung.**

# Software installieren

1. **Node.js 14** (aktuelle LTS-Version): [https://nodejs.org](https://nodejs.org)
   + Mac-Nutzer:innen bitte Homebrew verwenden! ([siehe Anleitung](https://presentations.angular.schule/HOMEBREW_NODE))
2. **Google Chrome:** [https://www.google.com/chrome/](https://www.google.com/chrome/)
3. **Visual Studio Code:** [https://code.visualstudio.com](https://code.visualstudio.com)
4. optional: **Git**

Wir empfehlen dir eine Auswahl an Extensions für Visual Studio Code.
Dazu haben wir ein Extension Pack vorbereitet, das alles Nötige einrichtet:
+ [Angular-Schule: Extension Pack](https://marketplace.visualstudio.com/items?itemName=angular-schule.angular-schule-extension-pack)


## Proxy?

Für die Proxykonfiguration im Unternehmensnetz sind gesonderte Einstellungen nötig.
Wir haben dir hierfür folgende Anleitung erstellt:
https://presentations.angular.schule/PROXY.html  
Sollte es Probleme mit dem Proxy geben, melde Dich bitte bei uns, dann finden wir eine Lösung.


# Projekt installieren

In diesem Repository findest Du ein vorbereitetes Angular-Projekt.
Im Workshop werden wir Tests für diese Anwendung entwickeln.

## Projekt herunterladen

Bitte lade dir das Repository auf deinen Rechner.
Dazu kannst Du entweder das Git-Repo klonen oder direkt [als ZIP herunterladen](https://github.com/angular-schule/2021-07-angular-workshop-bergisch-gladbach/archive/refs/heads/main.zip).


```bash
cd 2021-07-angular-workshop-bergisch-gladbach
cd book-rating-jest
npm install
```

## App starten

Nach der Installation (dauert lange!) kannst Du das Projekt vom Hauptverzeichnis aus starten:

```bash
npm start
```

> Unter http://localhost:4200 sollte nun die Anwendung zu sehen sein.


## Tests ausführen

Wenn das Projekt läuft, führe bitte die Tests aus:

```bash
npm run test

# ODER interaktiver Watch-Modus:
npm run test:watch
```

**Achtung: Die Tests schlagen fehl – das ist zum Beginn in Ordnung!**

# Code studieren

Bitte mach dich mit dem Code der Anwendung vertraut: Schau dir alle Komponenten und Services an, sodass Du den Aufbau der App im Workshop gut kennst.

----

Sollte es zu Fehlern kommen, dann melde dich einfach per Mail bei uns unter [team@angular.schule](mailto:team@angular.schule).  
Wir werden schnell eine Lösung finden.



### Wir freuen uns schon! 🙂

<hr>

<img src="https://assets.angular.schule/logo-angular-schule.png" height="60">

### &copy; https://angular.schule | Stand: 05.07.2021
