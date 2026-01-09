# 🔧 Mechtools - Assistente digitale per officina

Questa applicazione multipiattaforma è stata progettata per supportare montatori meccanici e manutentori nelle attività quotidiane di officina e cantiere. Il progetto nasce dalla volontà di unire l'esperienza pratica nel settore metalmeccanico con le competenze di sviluppo software, creando uno strumento che risolve problemi concreti in modo rapido e senza necessità di connessione internet. 📱⚙️

## ⚙️ Funzionalità lato meccanico

L'applicazione è sviluppata seguendo le reali necessità operative di chi lavora sul campo.

### 🔩 Convertitore vite-chiave intelligente
Permette di individuare immediatamente la chiave fissa o la brugola necessaria partendo dalla misura della vite e viceversa. Supporta lo standard ISO e gestisce le eccezioni per le misure pesanti fino a M52.

### 💧 Database raccordi idraulici
*In sviluppo* - Tabella di consultazione rapida per distinguere raccordi GAS (BSP) e NPT, con visualizzazione dei filetti per pollice (TPI) e diametri nominali.

### 🔍 Riconoscimento filettature
Strumento di calcolo per identificare la conicità dei raccordi tramite misurazione col calibro, utile quando non si dispone di un contafiletti.

## 🏗️ Architettura Software

Dal punto di vista tecnico, il progetto è realizzato per dimostrare una gestione pulita del codice e l'utilizzo dei più recenti standard di sviluppo Microsoft.

### 🎯 Framework
Sviluppato in C# su piattaforma **.NET MAUI 9** per garantire la compatibilità nativa su Android e iOS con un'unica base di codice.

### 🎨 Pattern MVVM
L'architettura segue rigorosamente il pattern **model-view-viewmodel** per separare la logica di business dall'interfaccia utente. Questo rende il codice testabile, manutenibile e modulare.

### 🛠️ Community toolkit MVVM
Utilizzo del toolkit ufficiale per la gestione ottimizzata di `ObservableProperty` e `RelayCommand`, riducendo il codice boilerplate e migliorando le performance.

### ✨ Clean code
I dati tecnici (tabelle ISO, misure raccordi) sono isolati in servizi dedicati, rendendo semplice l'aggiornamento delle normative senza intaccare la logica dell'applicazione.

## 🎯 Obiettivi del Progetto

Questo repository serve come dimostrazione di competenza nello sviluppo full-stack mobile, evidenziando la capacità di trasformare un dominio di conoscenza specifico (la meccanica industriale) in una soluzione software strutturata e professionale.

## 📋 Requisiti

- Visual Studio 2022 o successivi
- Workload **.NET multi-platform app UI** installato
- Android SDK (per l'emulazione)

## 🚀 Installazione

```bash
# Clona il repository
git clone https://github.com/tuousername/mechtools.git

# Apri la solution in Visual Studio
cd mechtools
start Mechtools.sln
```

## 💻 Utilizzo

1. Seleziona l'emulatore Android o il dispositivo fisico
2. Premi F5 per avviare l'applicazione in modalità debug
3. Naviga tra le diverse funzionalità tramite il menu principale

## 📁 Struttura del progetto

```
Mechtools/
├── Models/              # Modelli di dominio
├── ViewModels/          # ViewModels MVVM
├── Views/               # Pagine XAML
├── Services/            # Servizi e logica di business
│   ├── BoltKeyService.cs
│   └── ThreadService.cs
└── Resources/           # Risorse condivise
```

## 🗺️ Roadmap

- [x] Convertitore vite-chiave ISO
- [ ] Database completo raccordi idraulici
- [ ] Riconoscimento filettature con algoritmo migliorato
- [ ] Supporto per standard DIN e ANSI
- [ ] Modalità offline con sincronizzazione cloud (opzionale)
- [ ] Versione desktop Windows con .NET MAUI

## 🤝 Contributi

I contributi sono benvenuti! Sentiti libero di aprire issue o pull request per miglioramenti e nuove funzionalità.

## 📄 Licenza

Questo progetto è distribuito sotto licenza MIT. Vedi il file `LICENSE` per maggiori dettagli.

## 📧 Contatti

Per domande o collaborazioni, contattami tramite [il tuo contatto]

---

**⚠️ Nota**: Questo è un progetto in continua evoluzione. Le funzionalità contrassegnate come "in sviluppo" potrebbero non essere completamente disponibili nella versione corrente.