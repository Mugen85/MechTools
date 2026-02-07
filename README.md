# 🔧 Mechtools v1.4 - Assistente digitale per officina

Questa applicazione multipiattaforma è stata progettata per supportare montatori meccanici e manutentori nelle attività quotidiane di officina e cantiere. Il progetto nasce dalla volontà di unire l'esperienza pratica nel settore metalmeccanico con le competenze di sviluppo software, creando uno strumento che risolve problemi concreti in modo rapido e senza necessità di connessione internet. 📱⚙️

## ⚙️ Funzionalità lato meccanico

L'applicazione è sviluppata seguendo le reali necessità operative di chi lavora sul campo.

### 💧 Database Raccordi & Workshop Mode (Novità v1.4)
Nuova interfaccia a schede (**Strumenti** vs **Tabelle**) per ottimizzare lo spazio su schermo.
* **Standard Supportati:** GAS (BSP - Blu), NPT (USA - Rosso) e **JIC 37°** (Oleodinamica - Viola).
* **Riconoscimento Filettature:** Identifica il raccordo misurando punta e fondo col calibro.
* **Trova Adattatore:** Calcolatore logico per individuare il raccordo di giunzione (Nipplo, Manicotto, Riduzione) dati due attacchi Maschio/Femmina.

### 🔦 Torcia & Utilità
* **Torcia Integrata:** Pulsante rapido per illuminare zone di lavoro buie direttamente dall'app.
* **Feedback Tattile:** Vibrazione alla pressione dei tasti per conferma operativa (utile con i guanti).

### 🔩 Convertitore Vite-Chiave
Permette di individuare immediatamente la chiave fissa o la brugola necessaria partendo dalla misura della vite e viceversa. Supporta lo standard ISO e gestisce le eccezioni per le misure pesanti fino a M52.

### 🔄 Convertitori Tecnici
* **Pollici/Millimetri:** Conversione bidirezionale con supporto frazioni (es. "3/8").
* **Pressione:** Convertitore istantaneo **Bar ↔ PSI**.

## 🏗️ Architettura Software

Dal punto di vista tecnico, il progetto è realizzato per dimostrare una gestione pulita del codice e l'utilizzo dei più recenti standard di sviluppo Microsoft.

### 🎯 Framework
Sviluppato in C# su piattaforma **.NET MAUI 9** per garantire la compatibilità nativa su Android e iOS con un'unica base di codice.

### 🎨 Pattern MVVM
L'architettura segue rigorosamente il pattern **Model-View-ViewModel** per separare la logica di business dall'interfaccia utente.
* **Views:** XAML puro con Binding.
* **ViewModels:** Logica di presentazione gestita tramite `CommunityToolkit.Mvvm`.
* **Services:** Logica di calcolo (algoritmi di riconoscimento raccordi, tabelle dati statiche).

### 🛠️ Community Toolkit MVVM
Utilizzo del toolkit ufficiale per la gestione ottimizzata di `ObservableProperty` e `RelayCommand`, riducendo il codice boilerplate e migliorando le performance.

### ✨ Clean Code & Best Practices
* Nessun dato *hardcoded* nelle viste.
* Utilizzo di `Dependency Injection` (ove necessario).
* Gestione asincrona dei comandi.
* Struttura modulare scalabile (facile aggiunta di nuovi standard come ORFS o Metrico).

## 🎯 Obiettivi del Progetto

Questo repository serve come dimostrazione di competenza nello sviluppo full-stack mobile, evidenziando la capacità di trasformare un dominio di conoscenza specifico (la meccanica industriale) in una soluzione software strutturata e professionale.

## 📋 Requisiti

- Visual Studio 2022 (v17.8+)
- Workload **.NET Multi-platform App UI** installato
- Android SDK (API 33+)

## 🚀 Installazione

```bash
# Clona il repository
git clone https://github.com/tuousername/mechtools.git

# Apri la solution in Visual Studio
cd mechtools
start Mechtools.sln
```

## 💻 Utilizzo

1. Seleziona l'emulatore Android o il dispositivo fisico (Debug USB attivo).
2. Premi F5 per avviare l'applicazione.
3. Usa la **Workshop Mode** nella pagina raccordi per switchare tra Calcolatori e Tabelle.

## 📁 Struttura del Progetto

```
Mechtools/
├── Models/                  # Definizioni degli oggetti (Dati)
│   ├── Fitting.cs           # Modello Raccordi (Gas/NPT/JIC)
│   └── ...
│
├── ViewModels/              # Logica di presentazione (MVVM)
│   ├── MainViewModel.cs     # Dashboard
│   ├── FittingsViewModel.cs # Logica Raccordi, JIC, Adattatori
│   └── ...
│
├── Views/                   # Interfaccia Utente (XAML)
│   ├── FittingsPage.xaml    # UI con Dual-Mode (Strumenti/Tabelle)
│   └── ...
│
├── Services/                # Logica di Business e Database statici
│   ├── FittingService.cs    # Algoritmo Detector e Tabelle Dati
│   └── ...
│
└── Resources/               # Asset Grafici
    ├── AppIcon/             # Icone adattive
    └── Splash/              # Splash Screen brandizzata
```

## 🗺️ Roadmap e Funzionalità

Il progetto è in continuo sviluppo. Ecco lo stato attuale dei lavori:

* [x] **Core & UI**
* [x] Setup architettura MVVM con .NET MAUI 9.
* [x] Design System "Industrial" (Dark Mode, Contrasti elevati).
* [x] Navigazione tramite AppShell.


* [x] **Modulo Raccordi (Fittings)**
* [x] Database Standard GAS, NPT e **JIC 37°**.
* [x] **UI Workshop Mode:** Divisione Strumenti/Tabelle.
* [x] *Smart Detector*: Algoritmo identificazione filetti.
* [x] *Adapter Finder*: Calcolatore Nippli/Riduzioni.
* [x] Color Coding (🔵🔴🟣).


* [x] **Modulo Convertitori**
* [x] Pollici/Millimetri.
* [x] Pressione (Bar/PSI).


* [x] **Modulo Officina**
* [x] Torcia integrata.
* [x] Calcolo Giri/min ().
* [x] Tabelle Filettature e Serraggi.

## 🤝 Contributi

I contributi sono benvenuti! Sentiti libero di aprire issue o pull request per miglioramenti e nuove funzionalità.

## 📄 Licenza

Questo progetto è distribuito sotto licenza MIT. Vedi il file `LICENSE` per maggiori dettagli.

---

## 👤 Autore e Contatti

Questo progetto è sviluppato e mantenuto da **Marco Morello**, sviluppatore .NET e appassionato di meccanica.

* 💼 **LinkedIn:** [Marco Morello](https://www.linkedin.com/in/marco-morello-b43b2a108)
* 📧 **Email:** [doppiam1@gmail.com](mailto:doppiam1@gmail.com)
* 🌐 **Blog:** [Il Viaggio del Programmatore](https://www.ilviaggiodelprogrammatore.com)

---

*Progetto Open Source distribuito con licenza MIT.*
