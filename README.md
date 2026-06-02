# 🔧 MechTools v1.5.0 — Assistente digitale per officina

Applicazione multipiattaforma progettata per supportare montatori meccanici e manutentori nelle attività quotidiane di officina e cantiere. Il progetto nasce dalla volontà di unire l'esperienza pratica nel settore metalmeccanico con le competenze di sviluppo software, creando uno strumento che risolve problemi concreti in modo rapido e senza necessità di connessione internet.

---

## ⚙️ Funzionalità

### 🗺️ Tabelloni simbologia *(novità v1.5.0)*

Consultazione rapida di schemi complessi tramite "poster" digitali interattivi.

- **Pneumatica:** tabellone valvole e cilindri secondo standard ISO 1219.
- **Elettrotecnica:** comparativa simboli IEC (Europa) vs NEMA (USA), fondamentale per macchinari d'importazione.
- **Zoom nativo hardware:** esplorazione fluida a 60 FPS con pinch-to-zoom estremo (fino a 30x) e doppio tap, garantita dall'accelerazione GPU della WebView.

### 💧 Database raccordi & Workshop Mode

Interfaccia a schede (**Strumenti** vs **Tabelle**) per ottimizzare lo spazio su schermo.

- **Standard supportati:** GAS (BSP — blu), NPT (USA — rosso) e JIC 37° (oleodinamica — viola).
- **Riconoscimento filettature:** identifica il raccordo misurando punta e fondo col calibro.
- **Trova adattatore:** calcolatore logico per individuare il raccordo di giunzione (nipplo, manicotto, riduzione) dati due attacchi maschio/femmina.

### 🔦 Torcia & utilità

- **Torcia integrata:** pulsante rapido per illuminare zone di lavoro buie direttamente dall'app.
- **Feedback tattile:** vibrazione alla pressione dei tasti per conferma operativa (utile con i guanti).

### 🔩 Convertitore vite-chiave

Permette di individuare immediatamente la chiave fissa o la brugola necessaria partendo dalla misura della vite e viceversa. Supporta lo standard ISO e gestisce le eccezioni per le misure pesanti fino a M52.

### 🔄 Convertitori tecnici

- **Pollici/millimetri:** conversione bidirezionale con supporto frazioni (es. `3/8`).
- **Pressione:** convertitore istantaneo Bar ↔ PSI.

---

## 🏗️ Architettura software

### 🎯 Framework

Sviluppato in C# su piattaforma **.NET MAUI 9** per garantire la compatibilità nativa su Android (ed espandibile su iOS) con un'unica base di codice.

### 🎨 Pattern MVVM

L'architettura segue rigorosamente il pattern **Model-View-ViewModel** per separare la logica di business dall'interfaccia utente.

- **Views:** XAML puro con binding.
- **ViewModels:** logica di presentazione gestita tramite `CommunityToolkit.Mvvm`.
- **Services:** logica di calcolo (algoritmi di riconoscimento raccordi, tabelle dati statiche).

### 🚀 WebView rendering engine

Per la gestione di immagini tecniche ad altissima risoluzione (tabelloni), i controlli nativi di MAUI sono stati bypassati in favore di un'architettura **WebView accelerata via hardware**. Il caricamento avviene offline convertendo asset `.png` locali in stringhe Base64, e configurando il WebKit di Android per supportare lo zoom fisico (`SupportZoom`, `WideViewPort`).

### 🛠️ Community Toolkit MVVM

Utilizzo del toolkit ufficiale per la gestione ottimizzata di `ObservableProperty` e `RelayCommand`, riducendo il codice boilerplate e migliorando le performance.

### ✨ Clean code & best practices

- Nessun dato hardcoded nelle viste.
- Dependency injection (ove necessario).
- Gestione asincrona dei comandi e risorse (stream, Base64).
- Struttura modulare scalabile.

---

## 📋 Requisiti

- Visual Studio 2022 (v17.8+)
- Workload **.NET Multi-platform App UI** installato
- Android SDK (API 33+)

---

## 🚀 Installazione

### 📱 Per utenti (Android)

Scarica il file APK direttamente sul tuo smartphone:

👉 [MechTools v1.5.0 APK](https://github.com/Mugen85/MechTools/releases/download/v1.5.0/MechTools-v1.5.0.apk)

### 💻 Per sviluppatori

```bash
# Clona il repository
git clone https://github.com/Mugen85/MechTools.git

# Apri la solution in Visual Studio
cd MechTools
start MechTools.sln
```

---

## 💡 Utilizzo

1. Seleziona l'emulatore Android o il dispositivo fisico (debug USB attivo).
2. Premi `F5` per avviare l'applicazione.
3. Esplora le macro-categorie dal menu laterale per accedere a strumenti, convertitori e tabelloni grafici.

---

## 📁 Struttura del progetto

```
MechTools/
├── Models/                     # Definizioni degli oggetti (dati)
│   ├── Fitting.cs              # Modello raccordi (GAS/NPT/JIC)
│   └── ...
│
├── ViewModels/                 # Logica di presentazione (MVVM)
│   ├── MainViewModel.cs        # Dashboard
│   ├── FittingsViewModel.cs    # Logica raccordi, JIC, adattatori
│   └── ...
│
├── Views/                      # Interfaccia utente (XAML)
│   ├── FittingsPage.xaml       # UI dual-mode (Strumenti/Tabelle)
│   ├── PneumaticPage.xaml      # Poster WebView con script Base64
│   └── ...
│
├── Services/                   # Logica di business e database statici
│   ├── FittingService.cs       # Algoritmo detector e tabelle dati
│   └── ...
│
└── Resources/                  # Asset grafici e dati grezzi
    ├── AppIcon/                # Icone adattive
    ├── Splash/                 # Splash screen
    └── Raw/                    # Asset tecnici (poster in alta risoluzione)
```

---

## 🗺️ Roadmap

| Stato | Funzionalità |
|-------|-------------|
| ✅ | Setup architettura MVVM con .NET MAUI 9 |
| ✅ | Design system "Industrial" (dark mode, contrasti elevati) |
| ✅ | Navigazione tramite AppShell |
| ✅ | Motore WebView per accelerazione hardware |
| ✅ | Tabelloni ISO 1219 (pneumatica) e IEC/NEMA (elettrotecnica) |
| ✅ | Zoom nativo Android |
| ✅ | Database standard GAS, NPT e JIC 37° |
| ✅ | UI Workshop Mode (Strumenti/Tabelle) |
| ✅ | Smart Detector — algoritmo identificazione filetti |
| ✅ | Adapter Finder — calcolatore nippli/riduzioni |
| ✅ | Color coding (🔵🔴🟣) |
| ✅ | Convertitori pollici/millimetri e Bar/PSI |
| ✅ | Calcolo giri/min mandrino (RPM) |
| ✅ | Tabella coppie di serraggio |
| ✅ | Torcia integrata |
| ✅ | Convertitore chiavi fisse ↔ diametro viti (metrico) |

---

## 🤝 Contributi

I contributi sono benvenuti! Sentiti libero di aprire issue o pull request per miglioramenti e nuove funzionalità.

---

## 📄 Licenza

Distribuito sotto licenza MIT. Vedi il file `LICENSE` per maggiori dettagli.

---

## 👤 Autore

Progetto sviluppato e mantenuto da **Marco Morello**, sviluppatore .NET e appassionato di meccanica.

- 💼 [LinkedIn](https://www.linkedin.com/in/marco-morello-b43b2a108)
- 📧 [doppiam1@gmail.com](mailto:doppiam1@gmail.com)
- 🌐 [Il Viaggio del Programmatore](https://www.ilviaggiodelprogrammatore.com)
