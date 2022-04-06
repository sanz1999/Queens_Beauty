# QueensBeauty
An app for the Queens Beauty salon.

Napomene:
    
    -KOD TREBA DA BUDE NA ENGLESKOM
    
    -UI U RAZVOJU NA SRPSKOM KRAJNJA VERZIJA NA NEMACKOM

Struktura projekta:
    
    -View(WPF)
    
        -Images
        
        -UserView.cs
        
        -AppointmentView.cs
        
        -ServiceView.cs
    
    -ViewModel(CL)
        
        -MainWindowViewModel.cs
        
        -UserViewModel.cs
        
        -AppointmentViewModel.cs
        
        -ServiceViewModel.cs
    
    -Model(CL)
        
        -User.cs
        
        -Service.cs 
        
        -Employee.cs
        
        -Appointment.cs
        
        -AppointmentItem.cs
    
    -DataBaseLogic(CL)
    
    -TestingConsoleApp(ConApp)
    
    -Common(CL)
        
        -To be continued...

Zahtevi:

- Evidencija korisnika i termina sa uslugama

- Filtriranje korisnika, termina, usluga:
    
    -SALE NAPISI MI STA TREBA DA SE FILTRIRA TACNO

- Unos korisnika, usluga, termina (validan)

- Skeniranje broja loyalty kartice (bar kod)



Korisnik treba da ima : 
    
    -id
    
    -ime
    
    -prezime
    
    -broj telefona
    
    -mail
    
    -pol
    
    -ostvarene bodove
    
    -loyality card

Usluga treba da ima :
    
    -id
    
    -Ime
    
    -cenu
    
    -trajanje

    -cena bodova
    
    -reward bodova
   
    -kategorija

Zaposleni treba da ima:
    
    -id
    
    -naziv

Termin treba da ima :
    
    -id
    
    -KorisnikId
    
    - Date-time
    
    -final cena (SUM(StavkaTermina.Usluga.cena))
    
    -state (rezervisano-odradjeno)
    
    -zaposleni
    
    List<Stavka Termina>


StavkaTermina:
    
    - id
    
    - Usluga
